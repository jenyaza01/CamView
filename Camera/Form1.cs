using System;
using System.Drawing;
using System.Drawing.Imaging;
using System.Threading.Tasks;
using System.Windows.Forms;
using AForge.Video;
using AForge.Video.DirectShow;


namespace Camera
{
	public partial class Form1 : Form
	{
		private FilterInfoCollection videoDevices;
		private VideoCaptureDevice videoSourceLeft = null;
		private VideoCaptureDevice videoSourceRight = null;
		private VideoCapabilities[] videoSizesLeft;
		private VideoCapabilities[] videoSizesRight;
		private Bitmap bmpLeft, bmpRight, maskLeft, maskRight;

		//	public volatile bool needRotate = false;
		//	public volatile bool needMirrorV = false;
		//	public volatile bool needMirrorH = false;

		public Form1()
		{
			InitializeComponent();
		}

		private void getCamList()
		{
			videoDevices = new FilterInfoCollection(FilterCategory.VideoInputDevice);
			cbDevicesLeft.Items.Clear();
			cbDevicesRight.Items.Clear();

			if (videoDevices.Count == 0)
			{
				cbDevicesLeft.Items.Add("-No devices-");
				cbDevicesLeft.Enabled = false;
				comboBoxSizeLeft.Enabled = false;

				cbDevicesRight.Items.Add("-No devices-");
				cbDevicesRight.Enabled = false;
				comboBoxSizeRight.Enabled = false;
			}
			else
			{
				cbDevicesLeft.Enabled = true;
				comboBoxSizeLeft.Enabled = true;
				cbDevicesRight.Enabled = true;
				comboBoxSizeRight.Enabled = true;

				foreach (FilterInfo device in videoDevices)
				{
					cbDevicesLeft.Items.Add(device.Name);
					cbDevicesRight.Items.Add(device.Name);
				}
				cbDevicesLeft.SelectedIndex = 0;
				cbDevicesRight.SelectedIndex = 1;
			}
		}



		private void bRefresh_Click(object sender, EventArgs e)
		{
			getCamList();
		}

		private void bStartClick()
		{
			videoSourceLeft.Start();
			videoSourceRight.Start();
			bRefresh.Enabled = false;
			cbDevicesLeft.Enabled = false;
			comboBoxSizeLeft.Enabled = false;
			cbDevicesRight.Enabled = false;
			comboBoxSizeRight.Enabled = false;
		}



		private Rectangle rct = new Rectangle(0, 230, 640, 20);
		private void video_NewFrameLeft(object sender, NewFrameEventArgs eventArgs)
		{
			bmpLeft = eventArgs.Frame.Clone(rct, PixelFormat.Format32bppArgb);
			bmpLeft.RotateFlip(RotateFlipType.RotateNoneFlipX);

			if (maskLeft != null)
				if (imageToAdd == 0)
					bmpLeft = Compare2Img(bmpLeft, maskLeft);
				else
					maskLeft = Add2Img(maskLeft, bmpLeft);

			Invoke((MethodInvoker)delegate
			{
				pictureBoxILeft.Image = bmpLeft;
			});
		}

		private void video_NewFrameRight(object sender, NewFrameEventArgs eventArgs)
		{
			bmpRight = eventArgs.Frame.Clone(rct, PixelFormat.Format32bppArgb);
			bmpRight.RotateFlip(RotateFlipType.RotateNoneFlipX);

			if (maskRight != null)
				if (imageToAdd == 0)
					bmpRight = Compare2Img(bmpRight, maskRight);
				else
					maskRight = Add2Img(maskRight, bmpRight);
			

			Invoke((MethodInvoker)delegate
			{
				pictureBoxIRight.Image = bmpRight;
			});
		}





		private Bitmap Add2Img(Bitmap b0, Bitmap b1)
		{
			imageToAdd--;
			Rectangle rect = new Rectangle(0, 0, b0.Width, b0.Height);

			BitmapData bmp0Data = b0.LockBits(rect, ImageLockMode.ReadOnly, PixelFormat.Format32bppArgb);
			BitmapData bmp1Data = b1.LockBits(rect, ImageLockMode.ReadOnly, PixelFormat.Format32bppArgb);

			int size = bmp1Data.Stride * bmp1Data.Height;
			byte[] data0 = new byte[size];
			byte[] data1 = new byte[size];

			System.Runtime.InteropServices.Marshal.Copy(bmp0Data.Scan0, data0, 0, size);
			System.Runtime.InteropServices.Marshal.Copy(bmp1Data.Scan0, data1, 0, size);

			b1.UnlockBits(bmp1Data);
	

			for (int y = 0; y < b0.Height; y++)
			{
				for (int x = 0; x < b0.Width; x++)
				{
					int index0 = y * bmp0Data.Stride + x * 4;
					int index1 = y * bmp1Data.Stride + x * 4;

					data0[index0 + 3] = 255; // Alpha
					data0[index0 + 2] = (byte)((data0[index0 + 2]*2 + data0[index0 + 2]) / 3);
					data0[index0 + 1] = (byte)((data0[index0 + 1]*2 + data0[index0 + 1]) / 3);
					data0[index0 + 0] = (byte)((data0[index0]*2 + data0[index0]) / 3);
				}
			}

			System.Runtime.InteropServices.Marshal.Copy(data0, 0, bmp0Data.Scan0, data0.Length);
			b0.UnlockBits(bmp0Data);
			return b0;
		}

		private Bitmap Compare2Img(Bitmap b0, Bitmap b1)
		{
			Rectangle rect = new Rectangle(0, 0, b0.Width, b0.Height);

			BitmapData bmp0Data = b0.LockBits(rect, ImageLockMode.ReadOnly, PixelFormat.Format32bppArgb);
			BitmapData bmp1Data = b1.LockBits(rect, ImageLockMode.ReadOnly, PixelFormat.Format32bppArgb);

			int size = bmp1Data.Stride * bmp1Data.Height;
			byte[] data0 = new byte[size];
			byte[] data1 = new byte[size];

			System.Runtime.InteropServices.Marshal.Copy(bmp0Data.Scan0, data0, 0, size);
			System.Runtime.InteropServices.Marshal.Copy(bmp1Data.Scan0, data1, 0, size);

			b1.UnlockBits(bmp1Data);


			byte tr = 24;
			for (int y = 0; y < b0.Height; y++)
			{
				for (int x = 0; x < b0.Width; x++)
				{
					int index0 = y * bmp0Data.Stride + x * 4;
					int index1 = y * bmp1Data.Stride + x * 4;

					data0[index0 + 3] = 255; // Alpha

					bool diff = (abs(data0[index0 + 2] - data1[index1 + 2]) * 0.25 + abs(data0[index0 + 1] - data1[index1 + 1]) * 0.5 + abs(data0[index0 + 1] - data1[index1 + 0]) * 0.25) < tr; 
					data0[index0 + 2] = (byte)(diff ? 0 : 255);
					data0[index0 + 1] = (byte)(diff ? 0 : 255);
					data0[index0 + 0] = (byte)(diff ? 0 : 255);
				}
			}

			System.Runtime.InteropServices.Marshal.Copy(data0, 0, bmp0Data.Scan0, data0.Length);
			b0.UnlockBits(bmp0Data);
			return b0;
		}

		private int abs(int v)
		{
			return v < 0 ? -v : v;
		}

		private void CloseVideoSourceLeft()
		{
			if (!(videoSourceLeft == null))
				if (videoSourceLeft.IsRunning)
				{
					videoSourceLeft.SignalToStop();
					videoSourceLeft = null;
				}
		}

		private void CloseVideoSourceRight()
		{
			if (!(videoSourceRight == null))
				if (videoSourceRight.IsRunning)
				{
					videoSourceRight.SignalToStop();
					videoSourceRight = null;
				}
		}


		public void Form1_Load(object sender, EventArgs e)
		{
			getCamList();
		}


		private void bStopClick()
		{
			timGC.Enabled = false;

			Task.Run(new Action(() =>
			{
				videoSourceLeft.SignalToStop();
				videoSourceLeft.Stop();
			}));

			Task.Run(new Action(() =>
			{
				videoSourceRight.SignalToStop();
				videoSourceRight.Stop();
			}));

			bRefresh.Enabled = true;
			cbDevicesLeft.Enabled = true;
			comboBoxSizeLeft.Enabled = true;
			cbDevicesRight.Enabled = true;
			comboBoxSizeRight.Enabled = true;
		}


		public Bitmap CropImage(Bitmap source, Rectangle section)
		{
			Bitmap bitmap = new Bitmap(section.Width, section.Height);
			using (Graphics g = Graphics.FromImage(bitmap))
			{
				g.DrawImage(source, 0, 0, section, GraphicsUnit.Pixel);
				return bitmap;
			}
		}


		private void cbDevicesLeft_SelectedIndexChanged(object sender, EventArgs e)
		{
			CloseVideoSourceLeft();
			videoSourceLeft = new VideoCaptureDevice(videoDevices[cbDevicesLeft.SelectedIndex].MonikerString);
			videoSourceLeft.NewFrame += new NewFrameEventHandler(video_NewFrameLeft);

			int i = 0;
			videoSizesLeft = new VideoCapabilities[videoSourceLeft.VideoCapabilities.Length];
			comboBoxSizeLeft.Items.Clear();

			foreach (VideoCapabilities VC in videoSourceLeft.VideoCapabilities)
			{
				comboBoxSizeLeft.Items.Add(VC.FrameSize.Width.ToString() + " x " + VC.FrameSize.Height.ToString()
					  + " @ " + VC.AverageFrameRate.ToString());
				videoSizesLeft[i] = VC;
				i++;
			}
			if (comboBoxSizeLeft.Items.Count == 0) comboBoxSizeLeft.Text = "No data";
			else comboBoxSizeLeft.SelectedIndex = 0;
		}


		private void cbDevicesRight_SelectedIndexChanged(object sender, EventArgs e)
		{
			CloseVideoSourceRight();
			videoSourceRight = new VideoCaptureDevice(videoDevices[cbDevicesRight.SelectedIndex].MonikerString);
			videoSourceRight.NewFrame += new NewFrameEventHandler(video_NewFrameRight);

			int i = 0;
			videoSizesRight = new VideoCapabilities[videoSourceRight.VideoCapabilities.Length];
			comboBoxSizeRight.Items.Clear();

			foreach (VideoCapabilities VC in videoSourceRight.VideoCapabilities)
			{
				comboBoxSizeRight.Items.Add(VC.FrameSize.Width.ToString() + " x " + VC.FrameSize.Height.ToString()
					  + " @ " + VC.AverageFrameRate.ToString());
				videoSizesRight[i] = VC;
				i++;
			}
			if (comboBoxSizeRight.Items.Count == 0) comboBoxSizeRight.Text = "No data";
			else comboBoxSizeRight.SelectedIndex = 0;
		}





		private void comboBoxSizeLeft_SelectedIndexChanged(object sender, EventArgs e)
		{
			CloseVideoSourceLeft();
			videoSourceLeft = new VideoCaptureDevice(videoDevices[cbDevicesLeft.SelectedIndex].MonikerString);
			videoSourceLeft.NewFrame += new NewFrameEventHandler(video_NewFrameLeft);
			videoSourceLeft.VideoResolution = videoSizesLeft[comboBoxSizeLeft.SelectedIndex];
		}

		private void comboBoxSizeRight_SelectedIndexChanged(object sender, EventArgs e)
		{
			CloseVideoSourceRight();
			videoSourceRight = new VideoCaptureDevice(videoDevices[cbDevicesRight.SelectedIndex].MonikerString);
			videoSourceRight.NewFrame += new NewFrameEventHandler(video_NewFrameRight);
			videoSourceRight.VideoResolution = videoSizesRight[comboBoxSizeRight.SelectedIndex];
		}


		private void StartStop_Click(object sender, EventArgs e)
		{
			if (videoSourceLeft.IsRunning || videoSourceLeft.IsRunning)
			{
				bStopClick();
				bStart.Text = "Start";
				bSettingsLeft.Enabled = false;
				bSettingsRight.Enabled = false;
			}
			else
			{
				bStartClick();
				bStart.Text = "Stop";
				bSettingsLeft.Enabled = true;
				bSettingsRight.Enabled = true;
			}
		}


		private void timGC_Tick(object sender, EventArgs e)
		{
			GC.Collect(0, GCCollectionMode.Forced, false);
		}





		private void Form1_FormClosing(object sender, FormClosingEventArgs e)
		{
			if (bStart.Text == "Stop")
			{
				CloseVideoSourceLeft();
				CloseVideoSourceRight();
			}

		}

		//	private int Clamp(int a, int min, int max)
		//	{
		//		return Math.Max(Math.Min(a, max), min);
		//	}



		private void bSettingsLeft_Click(object sender, EventArgs e)
		{
			if (videoSourceLeft.IsRunning)
				videoSourceLeft.DisplayPropertyPage(Handle);
		}

		int imageToAdd = 0;
		private void button1_Click(object sender, EventArgs e)
		{
			if (maskLeft == null)
			{
				maskLeft = bmpLeft;
				maskRight = bmpRight;
				imageToAdd = 18;
			}
			else
			{
				maskLeft = null;
				maskRight = null;
			}
		}

		private void bSettingsRight_Click(object sender, EventArgs e)
		{
			if (videoSourceRight.IsRunning)
				videoSourceRight.DisplayPropertyPage(Handle);
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
	}
}