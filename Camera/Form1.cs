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

		public volatile bool needScale;
		public volatile bool needRotate = false;
		public volatile bool needMirrorV = false;
		public volatile bool needMirrorH = false;
		private float trackbarScale;
		private int bmp_width, bmp_heigth, pictbox_width, pictbox_heigth, x, y;
		private bool lastFPS0;

		public Form1()
		{
			InitializeComponent();
		}

		private int FPS;

		private void updateTitle()
		{
			Text = $"CamView - {bmp_width}x{bmp_heigth} in {pictbox_width}x{pictbox_heigth} @ {FPS}fps";
		}

		private int lastCamIndex = 0;
		private void getCamList()
		{
			videoDevices = new FilterInfoCollection(FilterCategory.VideoInputDevice);
			if (cbDevices.SelectedIndex != -1) lastCamIndex = cbDevices.SelectedIndex;
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
			getCamList();
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

			Invoke((MethodInvoker)delegate
			{
				pictureBoxWithInterpolationMode1.Image = bmp;
			});

			eventArgs.Frame.Dispose();
			GC.Collect(0, GCCollectionMode.Forced, false);
		}


		//private Bitmap Add2Img(out Bitmap b0, Bitmap b1)
		//{
		//    Rectangle rect = new Rectangle(0, 0, b0.Width, b0.Height);

		//    BitmapData bmp0Data = b0.LockBits(rect, ImageLockMode.ReadOnly, PixelFormat.Format32bppArgb);
		//    BitmapData bmp1Data = b1.LockBits(rect, ImageLockMode.ReadOnly, PixelFormat.Format32bppArgb);

		//    int size = bmp1Data.Stride * bmp1Data.Height;
		//    byte[] data0 = new byte[size];
		//    byte[] data1 = new byte[size];

		//    System.Runtime.InteropServices.Marshal.Copy(bmp0Data.Scan0, data0, 0, size);
		//    System.Runtime.InteropServices.Marshal.Copy(bmp1Data.Scan0, data1, 0, size);
		//
		//    b1.UnlockBits(bmp1Data);

		//    byte OV = (byte)hsbOversample.Value;

		//    for (int y = 0; y < bmp_heigth; y++)
		//    {
		//        for (int x = 0; x < bmp_width; x++)
		//        {
		//            int index0 = y * bmp0Data.Stride + x * 4;
		//            int index1 = y * bmp1Data.Stride + x * 4;

		//            data0[index2 + 3] = 255; // Alpha
		//            data0[index2 + 2] = (byte)((data0[index0 + 2] + OV * data1[index1 + 2]) / (OV + 1));
		//            data0[index2 + 1] = (byte)((data0[index0 + 1] + OV * data1[index1 + 1]) / (OV + 1));
		//            data0[index2 + 0] = (byte)((data0[index0 + 0] + OV * data1[index1 + 0]) / (OV + 1));
		//        }
		//    }

		//    System.Runtime.InteropServices.Marshal.Copy(data0, 0, bmp0Data.Scan0, data0.Length);
		//    b0.UnlockBits(bmp0Data);
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
			Height = 517;
			Width = 656;
			getCamList();
			trackbarScale = (tbZoom.Value - 100.0f) / 1000.0f;

		}


		private void bStopClick()
		{
			timFPS_Counter.Enabled = false;
			Text = "CamView";
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
			CloseVideoSource();
			videoSource = new VideoCaptureDevice(videoDevices[cbDevices.SelectedIndex].MonikerString);
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
			videoSource = new VideoCaptureDevice(videoDevices[cbDevices.SelectedIndex].MonikerString);
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
				Text = "CamView - NO SIGNAL";
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
			pictbox_width = pictureBoxWithInterpolationMode1.Width;
			pictbox_heigth = pictureBoxWithInterpolationMode1.Height;
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


		private void button2_Click(object sender, EventArgs e)
		{
			bFlipV.BackColor = (needMirrorV = !needMirrorV) ? Color.Gray : Color.WhiteSmoke;
		}

		private void bSettings_Click(object sender, EventArgs e)
		{
			if (videoSource.IsRunning)
				videoSource.DisplayPropertyPage(Handle);
		}

		private void button7_Click(object sender, EventArgs e)
		{
			ImageSave(true);
		}

		private bool panelMinimised = false;
		private void bHidePanel_Click(object sender, EventArgs e)
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
				panelMain.Width = Width - 14;
				panelMain.Anchor = (AnchorStyles)14;
			}
		}

		private void bBorderless_Click(object sender, EventArgs e)
		{
			if (FormBorderStyle == FormBorderStyle.Sizable)
			{
				FormBorderStyle = FormBorderStyle.None;
				Location = new Point(Location.X + 8, Location.Y + 30);
				bBorderless.BackColor = Color.Gray;
			}
			else
			{
				Location = new Point(Location.X - 8, Location.Y - 30);
				FormBorderStyle = FormBorderStyle.Sizable;
				bBorderless.BackColor = Color.WhiteSmoke;
			}
		}

		private void buttonToggler_Enter(object sender, EventArgs e)
		{
			bStart.Focus();
		}

		private void button3_Click(object sender, EventArgs e)
		{
			bFlipH.BackColor = (needMirrorH = !needMirrorH) ? Color.Gray : Color.WhiteSmoke;
		}

		private void button4_Click(object sender, EventArgs e)
		{
			bRotateCW.BackColor = (needRotate = !needRotate) ? Color.Gray : Color.WhiteSmoke;
		}

		private void button5_Click(object sender, EventArgs e)
		{
			bShowScale.BackColor = (tbZoom.Visible = !tbZoom.Visible) ? Color.Gray : Color.WhiteSmoke;
		}

		private void button6_Click(object sender, EventArgs e)
		{
			bTopMost.BackColor = (TopMost = !TopMost) ? Color.Gray : Color.WhiteSmoke;
		}
	}
}