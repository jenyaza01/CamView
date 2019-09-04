using AForge.Video;
using AForge.Video.DirectShow;
using System;
using System.Drawing;
using System.Windows.Forms;



namespace Camera
{
    public partial class Form1 : Form
    {
        private FilterInfoCollection videoDevices;
        private VideoCaptureDevice videoSource = null;
        private VideoCapabilities[] videoSizes;
        private Bitmap bmp;

        public volatile bool needScale;
        public volatile bool needRotate = false;
        public volatile bool needMirrorV = false;
        public volatile bool needMirrorH = false;
        private float trackbarScale;
        private int bmp_width, bmp_heigth, image_width, image_heigth, x, y;
        private bool lastFPS0;

        public Form1()
        {
            InitializeComponent();
        }

        private int FPS;

        private void updateTitle()
        {
            this.Text = "CamView - " +
                   bmp_width.ToString() + "x" + bmp_heigth.ToString() + " in " + image_width.ToString() +
                       "x" + image_heigth.ToString() + " @ " + FPS.ToString() + "fps";
        }

        private int lastIndex = 0;
        private void getCamList()
        {
            videoDevices = new FilterInfoCollection(FilterCategory.VideoInputDevice);
            if (comboBoxDevices.SelectedIndex != -1) lastIndex = comboBoxDevices.SelectedIndex;
            comboBoxDevices.Items.Clear();

            if (videoDevices.Count == 0)
            {
                comboBoxDevices.Items.Add("-No devices-");
                comboBoxDevices.Enabled = false;
                comboBoxSize.Enabled = false;
            }
            else
            {
                comboBoxDevices.Enabled = true;
                comboBoxSize.Enabled = true;
                foreach (FilterInfo device in videoDevices)
                {
                    comboBoxDevices.Items.Add(device.Name);
                }
                if (comboBoxDevices.Items.Count - 1 >= lastIndex)
                    comboBoxDevices.SelectedIndex = lastIndex;
                else
                    comboBoxDevices.SelectedIndex = 1;
            }
        }



        private void bRefresh_Click(object sender, EventArgs e)
        {
            getCamList();
        }



        private void bStartClick()
        {
            videoSource.Start();
            bRefresh.Enabled = false;
            comboBoxDevices.Enabled = false;
            comboBoxSize.Enabled = false;
            timFPS_Counter.Enabled = true;
            tbZoom.Enabled = true;
        }

        private void video_NewFrame(object sender, NewFrameEventArgs eventArgs)
        {
            FPS++;

            bmp = (Bitmap)eventArgs.Frame.Clone();

            if (needRotate) bmp.RotateFlip(RotateFlipType.Rotate90FlipNone);
            if (needMirrorH) bmp.RotateFlip(RotateFlipType.RotateNoneFlipX);
            if (needMirrorV) bmp.RotateFlip(RotateFlipType.RotateNoneFlipY);

            if (needScale)
            {
                x = (int)(bmp.Width * trackbarScale);
                y = (int)(bmp.Height * trackbarScale);
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


        //private Bitmap Add2Img(Bitmap b0, Bitmap b1)
        //{
        //    Bitmap b2 = new Bitmap(b1);

        //    Rectangle rect = new Rectangle(0, 0, b0.Width, b0.Height);

        //    BitmapData bmp0Data = b0.LockBits(rect, ImageLockMode.ReadOnly, PixelFormat.Format32bppArgb);
        //    BitmapData bmp1Data = b1.LockBits(rect, ImageLockMode.ReadOnly, PixelFormat.Format32bppArgb);
        //    BitmapData bmp2Data = b2.LockBits(rect, ImageLockMode.WriteOnly, PixelFormat.Format32bppArgb);

        //    int size = bmp1Data.Stride * bmp1Data.Height;
        //    byte[] data0 = new byte[size];
        //    byte[] data1 = new byte[size];
        //    byte[] data2 = new byte[size];

        //    System.Runtime.InteropServices.Marshal.Copy(bmp0Data.Scan0, data0, 0, size);
        //    System.Runtime.InteropServices.Marshal.Copy(bmp1Data.Scan0, data1, 0, size);

        //    b0.UnlockBits(bmp0Data);
        //    b1.UnlockBits(bmp1Data);

        //    byte OV = (byte)hsbOversample.Value;

        //    for (int y = 0; y < bmp_heigth; y++)
        //    {
        //        for (int x = 0; x < bmp_width; x++)
        //        {
        //            int index0 = y * bmp0Data.Stride + x * 4;
        //            int index1 = y * bmp1Data.Stride + x * 4;
        //            int index2 = y * bmp2Data.Stride + x * 4;

        //            data2[index2 + 3] = 255; // Alpha
        //            data2[index2 + 2] = (byte)((data0[index0 + 2] + OV * data1[index1 + 2]) / (OV + 1));
        //            data2[index2 + 1] = (byte)((data0[index0 + 1] + OV * data1[index1 + 1]) / (OV + 1));
        //            data2[index2 + 0] = (byte)((data0[index0 + 0] + OV * data1[index1 + 0]) / (OV + 1));
        //        }
        //    }


        //    System.Runtime.InteropServices.Marshal.Copy(data2, 0, bmp2Data.Scan0, data2.Length);
        //    b2.UnlockBits(bmp2Data);

        //    return b2;
        //}


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
            this.Height = 517;
            this.Width = 656;
            getCamList();
            trackbarScale = (tbZoom.Value - 100.0f) / 1000.0f;


        }


        private void bStopClick()
        {
            timFPS_Counter.Enabled = false;
            this.Text = "CamView";
            videoSource.SignalToStop();
            videoSource.Stop();

            bRefresh.Enabled = true;
            comboBoxDevices.Enabled = true;
            comboBoxSize.Enabled = true;
            needScale = false;
            tbZoom.Enabled = false;
        }


        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            CloseVideoSource();
            videoSource = new VideoCaptureDevice(videoDevices[comboBoxDevices.SelectedIndex].MonikerString);
            videoSource.NewFrame += new NewFrameEventHandler(video_NewFrame);

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
            if (comboBoxSize.Items.Count == 0) comboBoxSize.Text = "No data";
            else comboBoxSize.SelectedIndex = 0;
        }


        private void ImageSave(bool showSFD = true)
        {
            if (pictureBoxWithInterpolationMode1.Image == null) return;
            SaveFileDialog sfd = new SaveFileDialog
            {
                FileName = "img_" + DateTime.Now.ToString("yy-MM-dd_HH.mm.ss"),
                Filter = "PNG Image|*.png"
            };

            if (sfd.ShowDialog() == DialogResult.OK)
            {
                pictureBoxWithInterpolationMode1.Image.Save(sfd.FileName);
            }
        }


        private void comboBoxSize_SelectedIndexChanged(object sender, EventArgs e)
        {
            CloseVideoSource();
            videoSource = new VideoCaptureDevice(videoDevices[comboBoxDevices.SelectedIndex].MonikerString);
            videoSource.NewFrame += new NewFrameEventHandler(video_NewFrame);
            videoSource.VideoResolution = videoSizes[comboBoxSize.SelectedIndex];
        }


        private void StartStop_Click(object sender, EventArgs e)
        {
            if (videoSource.IsRunning)
            {
                bStopClick();
                bStart.Text = "Start";
                bSettings.Enabled = false;
            }
            else
            {
                bStartClick();
                bStart.Text = "Stop";
                lastFPS0 = false;
                bSettings.Enabled = true;
            }
        }


        private void timFPS_Tick(object sender, EventArgs e)
        {
            if (FPS > 0)
            {
                updateTitle();
                FPS = 0;
                lastFPS0 = false;
            }
            else
            {
                if (lastFPS0) bStopClick();
                lastFPS0 = true;
                this.Text = "CamView - NO SIGNAL";
            }
        }

       

        private int getWidthForRatio()
        {
            float q = bmp_width / ((float)bmp_heigth);
            return (int)(480 * q);

        }

      

        private void trackBar1_Scroll(object sender, EventArgs e)
        {
            trackbarScale = tbZoom.Value / 1000.0f;
            needScale = true;
        }

        private void pictureBoxWithInterpolationMode1_SizeChanged(object sender, EventArgs e)
        {
            image_width = pictureBoxWithInterpolationMode1.Width;
            image_heigth = pictureBoxWithInterpolationMode1.Height;
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (bStart.Text == "Stop")
            {
                CloseVideoSource();
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
        
        
        private void button2_Click(Object sender, EventArgs e)
        {
            if (needMirrorV = !needMirrorV) bFlipV.BackColor = Color.Gray; else bFlipV.BackColor = Color.WhiteSmoke;
        }

        private void bSettings_Click(Object sender, EventArgs e)
        {
            if (videoSource.IsRunning)
                videoSource.DisplayPropertyPage(this.Handle);
        }

        private void button7_Click(Object sender, EventArgs e)
        {
            ImageSave(true);
        }

        volatile bool panelMinimised = false;
        private void bHidePanel_Click(Object sender, EventArgs e)
        {
            if (panelMinimised = !panelMinimised)
            {
                panelMain.Width = 25;
                panelMain.Anchor = (AnchorStyles)6;
                bHidePanel.Text = "⇨";
            }
            else
            {
                bHidePanel.Text = "⇦";
                panelMain.Width = this.Width - 14;
                panelMain.Anchor = (AnchorStyles)14;
            }
        }

        private void buttonToggler_Enter(Object sender, EventArgs e)
        {
            bStart.Focus();
        }

        private void button3_Click(Object sender, EventArgs e)
        {
            if (needMirrorH = !needMirrorH) bFlipH.BackColor = Color.Gray; else bFlipH.BackColor = Color.WhiteSmoke;
        }

        private void button4_Click(Object sender, EventArgs e)
        {
            if (needRotate = !needRotate) bRotateCW.BackColor = Color.Gray; else bRotateCW.BackColor = Color.WhiteSmoke;
        }

        private void button5_Click(Object sender, EventArgs e)
        {
            if (tbZoom.Visible = !tbZoom.Visible) bShowScale.BackColor = Color.Gray; else bShowScale.BackColor = Color.WhiteSmoke;
        }

        private void button6_Click(Object sender, EventArgs e)
        {
            if (this.TopMost = !this.TopMost) bTopMost.BackColor = Color.Gray; else bTopMost.BackColor = Color.WhiteSmoke;
        }
    }
}
