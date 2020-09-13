using System;
using System.Drawing;
using System.Windows.Forms;
using AForge.Video;
using AForge.Video.DirectShow;


namespace Camera
{
    public partial class Form1 : Form
    {
        private FilterInfoCollection videoDevices;
        private VideoCaptureDevice videoSource = null;
        private VideoCapabilities[] videoSizes;
        private Bitmap bmp;

        public volatile bool needScale = false;
        public volatile bool needRotate = false;
        public volatile bool needMirrorV = false;
        public volatile bool needMirrorH = false;
        private float ZoomScale, zoom = 1.0f;
        private int bmp_width, bmp_heigth, pictbox_width, pictbox_heigth, x, y;
        private bool lastFPS0;

        public Form1()
        {
            this.InitializeComponent();
        }

        private int FPS;

        private void updateTitle()
        {
            labelWindowTitle.Text =
                $"CamView - {bmp_width}x{bmp_heigth} in {pictbox_width}x{pictbox_heigth} @ {FPS}fps  x{zoom:F1}";
        }

        private int lastCamIndex = 0;
        private void getCamList()
        {
            videoDevices = new FilterInfoCollection(FilterCategory.VideoInputDevice);
            if (cbDevices.SelectedIndex != -1)
                lastCamIndex = cbDevices.SelectedIndex;
            cbDevices.Items.Clear();

            if (videoDevices.Count == 0)
            {
                cbDevices.Items.Add("-No devices-");
                cbDevices.Enabled = false;
                comboBoxSize.Enabled = false;
            }
            else
            {
                cbDevices.Enabled = true;
                comboBoxSize.Enabled = true;
                foreach (FilterInfo device in videoDevices)
                {
                    cbDevices.Items.Add(device.Name);
                }

                cbDevices.SelectedIndex = cbDevices.Items.Count - 1 >= lastCamIndex ? lastCamIndex : 1;
            }
        }



        private void bRefresh_Click(object sender, EventArgs e)
        {
            this.getCamList();
        }

        private void bStartClick()
        {
            videoSource.Start();
            bRefresh.Enabled = false;
            cbDevices.Enabled = false;
            comboBoxSize.Enabled = false;
            timFPS_Counter.Enabled = true;
            tbZoom.Enabled = true;
        }

        private void video_NewFrame(object sender, NewFrameEventArgs eventArgs)
        {
            FPS++;

            bmp = (Bitmap)eventArgs.Frame.Clone();

            if (needRotate)
                bmp.RotateFlip(RotateFlipType.Rotate90FlipNone);
            if (needMirrorH)
                bmp.RotateFlip(RotateFlipType.RotateNoneFlipX);
            if (needMirrorV)
                bmp.RotateFlip(RotateFlipType.RotateNoneFlipY);

            if (needScale)
            {
                x = (int)(bmp.Width * ZoomScale);
                y = (int)(bmp.Height * ZoomScale);
                bmp = bmp.Clone(new Rectangle(x, y, bmp.Width - 2 * x, bmp.Height - 2 * y), bmp.PixelFormat);
            }

            bmp_width = bmp.Width;
            bmp_heigth = bmp.Height;

            this.Invoke((MethodInvoker)delegate
            {
                pictureBoxWithInterpolationMode1.Image = bmp;
            });

            eventArgs.Frame.Dispose();
            GC.Collect(0, GCCollectionMode.Forced, false);
        }

        private void CloseVideoSource()
        {
            if (!(videoSource == null))
                if (videoSource.IsRunning)
                {
                    videoSource.SignalToStop();
                    videoSource = null;
                }
        }


        public void Form1_Load(object sender, EventArgs e)
        {
            Height = 517;
            Width = 656;
            this.getCamList();
            ZoomScale = (tbZoom.Value - 100.0f) / 1000.0f;

            FormBorderStyle = FormBorderStyle.None;

        }

        private const int WM_NCHITTEST = 0x0084;
        private const int HTCLIENT = 1;
        private const int HTCAPTION = 2;
        protected override void WndProc(ref Message m)
        {
            base.WndProc(ref m);
            switch (m.Msg)
            {
                case WM_NCHITTEST:
                    if (m.Result == (IntPtr)HTCLIENT)
                    {
                        m.Result = (IntPtr)HTCAPTION;
                    }
                    break;
            }
        }
        protected override CreateParams CreateParams
        {
            get
            {
                CreateParams cp = base.CreateParams;
                cp.Style |= 0x40000;
                return cp;
            }
        }



        private void bStopClick()
        {
            timFPS_Counter.Enabled = false;
            labelWindowTitle.Text = "CamView";
            videoSource.SignalToStop();
            videoSource.Stop();

            bRefresh.Enabled = true;
            cbDevices.Enabled = true;
            comboBoxSize.Enabled = true;
            needScale = false;
            tbZoom.Enabled = false;
        }


        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.CloseVideoSource();
            videoSource = new VideoCaptureDevice(videoDevices[cbDevices.SelectedIndex].MonikerString);
            videoSource.NewFrame += new NewFrameEventHandler(this.video_NewFrame);

            int i = 0;
            videoSizes = new VideoCapabilities[videoSource.VideoCapabilities.Length];
            comboBoxSize.Items.Clear();

            foreach (VideoCapabilities VC in videoSource.VideoCapabilities)
            {
                comboBoxSize.Items.Add(VC.FrameSize.Width.ToString() + " x " + VC.FrameSize.Height.ToString()
                      + " @ " + VC.AverageFrameRate.ToString());
                videoSizes[i] = VC;
                i++;
            }
            if (comboBoxSize.Items.Count == 0)
                comboBoxSize.Text = "No data";
            else
                comboBoxSize.SelectedIndex = 0;
        }


        private void ImageSave()
        {
            if (pictureBoxWithInterpolationMode1.Image == null)
                return;

            Image image = pictureBoxWithInterpolationMode1.Image;

            SaveFileDialog sfd = new SaveFileDialog
            {
                FileName = "img_" + DateTime.Now.ToString("yy-MM-dd_HH.mm.ss"),
                Filter = "PNG Image|*.png"
            };

            if (sfd.ShowDialog() == DialogResult.OK)
            {
                image.Save(sfd.FileName);
            }
        }


        private void comboBoxSize_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.CloseVideoSource();
            videoSource = new VideoCaptureDevice(videoDevices[cbDevices.SelectedIndex].MonikerString);
            videoSource.NewFrame += new NewFrameEventHandler(this.video_NewFrame);
            videoSource.VideoResolution = videoSizes[comboBoxSize.SelectedIndex];
        }


        private void StartStop_Click(object sender, EventArgs e)
        {
            if (videoSource.IsRunning)
            {
                this.bStopClick();
                bStart.Text = "Start";
                bSettings.Enabled = false;
            }
            else
            {
                this.bStartClick();
                bStart.Text = "Stop";
                lastFPS0 = false;
                bSettings.Enabled = true;
            }
        }


        private void timFPS_Tick(object sender, EventArgs e)
        {
            if (FPS > 0)
            {
                this.updateTitle();
                FPS = 0;
                lastFPS0 = false;
            }
            else
            {
                if (lastFPS0)
                    this.bStopClick();
                lastFPS0 = true;
                Text = "CamView - NO SIGNAL";
            }
        }



        private void tbZomom_Scroll(object sender, EventArgs e)
        {
            ZoomScale = tbZoom.Value / 1000.0f;
            zoom = 500f / (500 - tbZoom.Value);
            needScale = true;
        }

        private void pictureBoxWithInterpolationMode1_SizeChanged(object sender, EventArgs e)
        {
            pictbox_width = pictureBoxWithInterpolationMode1.Width;
            pictbox_heigth = pictureBoxWithInterpolationMode1.Height;
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (bStart.Text == "Stop")
            {
                this.CloseVideoSource();
            }

        }

        private int Clamp(int a, int min, int max)
        {
            return Math.Max(Math.Min(a, max), min);
        }








        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.C && e.Modifiers == Keys.Control)
            {
                Clipboard.SetImage(pictureBoxWithInterpolationMode1.Image);
            }
        }


        private void button2_Click(object sender, EventArgs e)
        {
            bFlipV.BackColor = (needMirrorV = !needMirrorV) ? Color.Gray : Color.LightGray;
        }

        private void bSettings_Click(object sender, EventArgs e)
        {
            if (videoSource.IsRunning)
                videoSource.DisplayPropertyPage(Handle);
        }

        private void ImageSave_Click(object sender, EventArgs e)
        {
            this.ImageSave();
        }

        private bool panelMinimised = false;
        private void bHidePanel_Click(object sender, EventArgs e)
        {
            if (panelMinimised = !panelMinimised)
            {
                panelMain.Visible = false;
                pWindowTitle.Visible = false;
                tbZoom.Visible = false;
            }
            else
            {
                pWindowTitle.Visible = true;
                panelMain.Visible = true;
                tbZoom.Visible = IsZoomScaleShow;
            }
        }

        private void bBorderless_Click(object sender, EventArgs e)
        {
            if (FormBorderStyle == FormBorderStyle.Sizable)
            {
                FormBorderStyle = FormBorderStyle.None;
                Location = new Point(Location.X + 8, Location.Y + 30);
            }
            else
            {
                Location = new Point(Location.X - 8, Location.Y - 30);
                FormBorderStyle = FormBorderStyle.Sizable;
            }
        }

        private void bClose_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void bMinimise_Click(object sender, EventArgs e)
        {
            WindowState = FormWindowState.Minimized;
        }

        private void bTopMost_Click(object sender, EventArgs e)
        {
            bTopMost.BackColor = (TopMost = !TopMost) ? Color.Gray : Color.LightGray;
        }

        private void buttonToggler_Enter(object sender, EventArgs e)
        {
            bStart.Focus();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            bFlipH.BackColor = (needMirrorH = !needMirrorH) ? Color.Gray : Color.LightGray;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            bRotateCW.BackColor = (needRotate = !needRotate) ? Color.Gray : Color.LightGray;
        }

        private bool IsZoomScaleShow = false;
        private void button5_Click(object sender, EventArgs e)
        {
            IsZoomScaleShow = !IsZoomScaleShow;

            tbZoom.Visible = IsZoomScaleShow;
            bShowScale.BackColor = IsZoomScaleShow ? Color.Gray : Color.LightGray;
        }

        private void bAbout_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            WindowState = (WindowState == FormWindowState.Normal)
            ? FormWindowState.Maximized
            : FormWindowState.Normal;
        }




        private int titleX, titleY;
        private bool titleMove = false;

        private void title_MouseDown(object sender, MouseEventArgs e)
        {
            titleX = Cursor.Position.X;
            titleY = Cursor.Position.Y;
            titleMove = true;
        }

        private void title_MouseMove(object sender, MouseEventArgs e)
        {
            if (titleMove)
            {
                Left += (Cursor.Position.X - titleX);
                Top += (Cursor.Position.Y - titleY);

                titleX = Cursor.Position.X;
                titleY = Cursor.Position.Y;
            }
        }

        private void title_MouseUp(object sender, MouseEventArgs e)
        {
            titleMove = false;
        }
    }
}
