namespace Camera
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
			this.components = new System.ComponentModel.Container();
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
			this.bStart = new System.Windows.Forms.Button();
			this.cbDevicesLeft = new System.Windows.Forms.ComboBox();
			this.comboBoxSizeLeft = new System.Windows.Forms.ComboBox();
			this.panelMain = new System.Windows.Forms.Panel();
			this.bSettingsRight = new System.Windows.Forms.Button();
			this.comboBoxSizeRight = new System.Windows.Forms.ComboBox();
			this.cbDevicesRight = new System.Windows.Forms.ComboBox();
			this.bRefresh = new System.Windows.Forms.Button();
			this.bHidePanel = new System.Windows.Forms.Button();
			this.bSettingsLeft = new System.Windows.Forms.Button();
			this.timGC = new System.Windows.Forms.Timer(this.components);
			this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
			this.button1 = new System.Windows.Forms.Button();
			this.pictureBoxIRight = new PictureBoxWithInterpolationMode();
			this.pictureBoxILeft = new PictureBoxWithInterpolationMode();
			this.panelMain.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.pictureBoxIRight)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.pictureBoxILeft)).BeginInit();
			this.SuspendLayout();
			// 
			// bStart
			// 
			this.bStart.Location = new System.Drawing.Point(324, 2);
			this.bStart.Name = "bStart";
			this.bStart.Size = new System.Drawing.Size(59, 23);
			this.bStart.TabIndex = 1;
			this.bStart.Text = "Start";
			this.bStart.UseVisualStyleBackColor = true;
			this.bStart.Click += new System.EventHandler(this.StartStop_Click);
			// 
			// cbDevicesLeft
			// 
			this.cbDevicesLeft.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.cbDevicesLeft.FormattingEnabled = true;
			this.cbDevicesLeft.Location = new System.Drawing.Point(53, 2);
			this.cbDevicesLeft.Name = "cbDevicesLeft";
			this.cbDevicesLeft.Size = new System.Drawing.Size(154, 23);
			this.cbDevicesLeft.TabIndex = 4;
			this.cbDevicesLeft.SelectedIndexChanged += new System.EventHandler(this.cbDevicesLeft_SelectedIndexChanged);
			// 
			// comboBoxSizeLeft
			// 
			this.comboBoxSizeLeft.Enabled = false;
			this.comboBoxSizeLeft.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.comboBoxSizeLeft.FormattingEnabled = true;
			this.comboBoxSizeLeft.Location = new System.Drawing.Point(207, 2);
			this.comboBoxSizeLeft.Name = "comboBoxSizeLeft";
			this.comboBoxSizeLeft.Size = new System.Drawing.Size(115, 23);
			this.comboBoxSizeLeft.TabIndex = 7;
			this.comboBoxSizeLeft.SelectedIndexChanged += new System.EventHandler(this.comboBoxSizeLeft_SelectedIndexChanged);
			// 
			// panelMain
			// 
			this.panelMain.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.panelMain.Controls.Add(this.button1);
			this.panelMain.Controls.Add(this.bSettingsRight);
			this.panelMain.Controls.Add(this.comboBoxSizeRight);
			this.panelMain.Controls.Add(this.cbDevicesRight);
			this.panelMain.Controls.Add(this.bRefresh);
			this.panelMain.Controls.Add(this.bHidePanel);
			this.panelMain.Controls.Add(this.bSettingsLeft);
			this.panelMain.Controls.Add(this.comboBoxSizeLeft);
			this.panelMain.Controls.Add(this.bStart);
			this.panelMain.Controls.Add(this.cbDevicesLeft);
			this.panelMain.Location = new System.Drawing.Point(0, 347);
			this.panelMain.Name = "panelMain";
			this.panelMain.Size = new System.Drawing.Size(879, 26);
			this.panelMain.TabIndex = 8;
			// 
			// bSettingsRight
			// 
			this.bSettingsRight.Enabled = false;
			this.bSettingsRight.Location = new System.Drawing.Point(786, 2);
			this.bSettingsRight.Name = "bSettingsRight";
			this.bSettingsRight.Size = new System.Drawing.Size(63, 23);
			this.bSettingsRight.TabIndex = 22;
			this.bSettingsRight.Text = "Settings";
			this.bSettingsRight.UseVisualStyleBackColor = true;
			this.bSettingsRight.Click += new System.EventHandler(this.bSettingsRight_Click);
			// 
			// comboBoxSizeRight
			// 
			this.comboBoxSizeRight.Enabled = false;
			this.comboBoxSizeRight.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.comboBoxSizeRight.FormattingEnabled = true;
			this.comboBoxSizeRight.Location = new System.Drawing.Point(607, 2);
			this.comboBoxSizeRight.Name = "comboBoxSizeRight";
			this.comboBoxSizeRight.Size = new System.Drawing.Size(115, 23);
			this.comboBoxSizeRight.TabIndex = 20;
			this.comboBoxSizeRight.SelectedIndexChanged += new System.EventHandler(this.comboBoxSizeRight_SelectedIndexChanged);
			// 
			// cbDevicesRight
			// 
			this.cbDevicesRight.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.cbDevicesRight.FormattingEnabled = true;
			this.cbDevicesRight.Location = new System.Drawing.Point(453, 2);
			this.cbDevicesRight.Name = "cbDevicesRight";
			this.cbDevicesRight.Size = new System.Drawing.Size(154, 23);
			this.cbDevicesRight.TabIndex = 19;
			this.cbDevicesRight.SelectedIndexChanged += new System.EventHandler(this.cbDevicesRight_SelectedIndexChanged);
			// 
			// bRefresh
			// 
			this.bRefresh.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.bRefresh.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.bRefresh.Location = new System.Drawing.Point(27, -4);
			this.bRefresh.Name = "bRefresh";
			this.bRefresh.Size = new System.Drawing.Size(25, 36);
			this.bRefresh.TabIndex = 18;
			this.bRefresh.TabStop = false;
			this.bRefresh.Text = "↻";
			this.toolTip1.SetToolTip(this.bRefresh, "Refresh devices");
			this.bRefresh.UseVisualStyleBackColor = true;
			this.bRefresh.Click += new System.EventHandler(this.bRefresh_Click);
			// 
			// bHidePanel
			// 
			this.bHidePanel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.bHidePanel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.bHidePanel.Location = new System.Drawing.Point(0, -1);
			this.bHidePanel.Name = "bHidePanel";
			this.bHidePanel.Size = new System.Drawing.Size(25, 28);
			this.bHidePanel.TabIndex = 17;
			this.bHidePanel.TabStop = false;
			this.bHidePanel.Text = "⇦ ";
			this.toolTip1.SetToolTip(this.bHidePanel, "Show|Hide panel");
			this.bHidePanel.UseVisualStyleBackColor = true;
			this.bHidePanel.Click += new System.EventHandler(this.bHidePanel_Click);
			// 
			// bSettingsLeft
			// 
			this.bSettingsLeft.Enabled = false;
			this.bSettingsLeft.Location = new System.Drawing.Point(384, 2);
			this.bSettingsLeft.Name = "bSettingsLeft";
			this.bSettingsLeft.Size = new System.Drawing.Size(63, 23);
			this.bSettingsLeft.TabIndex = 9;
			this.bSettingsLeft.Text = "Settings";
			this.bSettingsLeft.UseVisualStyleBackColor = true;
			this.bSettingsLeft.Click += new System.EventHandler(this.bSettingsLeft_Click);
			// 
			// timGC
			// 
			this.timGC.Interval = 1000;
			this.timGC.Tick += new System.EventHandler(this.timGC_Tick);
			// 
			// button1
			// 
			this.button1.Location = new System.Drawing.Point(721, 2);
			this.button1.Name = "button1";
			this.button1.Size = new System.Drawing.Size(59, 23);
			this.button1.TabIndex = 23;
			this.button1.Text = "Mask";
			this.button1.UseVisualStyleBackColor = true;
			this.button1.Click += new System.EventHandler(this.button1_Click);
			// 
			// pictureBoxIRight
			// 
			this.pictureBoxIRight.BackColor = System.Drawing.SystemColors.InactiveCaptionText;
			this.pictureBoxIRight.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.NearestNeighbor;
			this.pictureBoxIRight.Location = new System.Drawing.Point(0, 149);
			this.pictureBoxIRight.Name = "pictureBoxIRight";
			this.pictureBoxIRight.Size = new System.Drawing.Size(869, 176);
			this.pictureBoxIRight.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
			this.pictureBoxIRight.TabIndex = 9;
			this.pictureBoxIRight.TabStop = false;
			// 
			// pictureBoxILeft
			// 
			this.pictureBoxILeft.BackColor = System.Drawing.SystemColors.InactiveCaptionText;
			this.pictureBoxILeft.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.NearestNeighbor;
			this.pictureBoxILeft.Location = new System.Drawing.Point(0, 0);
			this.pictureBoxILeft.Name = "pictureBoxILeft";
			this.pictureBoxILeft.Size = new System.Drawing.Size(869, 143);
			this.pictureBoxILeft.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
			this.pictureBoxILeft.TabIndex = 5;
			this.pictureBoxILeft.TabStop = false;
			this.pictureBoxILeft.DoubleClick += new System.EventHandler(this.StartStop_Click);
			// 
			// Form1
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
			this.ClientSize = new System.Drawing.Size(877, 372);
			this.Controls.Add(this.pictureBoxIRight);
			this.Controls.Add(this.panelMain);
			this.Controls.Add(this.pictureBoxILeft);
			this.DoubleBuffered = true;
			this.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.KeyPreview = true;
			this.Name = "Form1";
			this.ShowIcon = false;
			this.Text = "CamView";
			this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
			this.Load += new System.EventHandler(this.Form1_Load);
			this.panelMain.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.pictureBoxIRight)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.pictureBoxILeft)).EndInit();
			this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Button bStart;
        private System.Windows.Forms.ComboBox cbDevicesLeft;
        private System.Windows.Forms.ComboBox comboBoxSizeLeft;
        private System.Windows.Forms.Panel panelMain;
        private System.Windows.Forms.Timer timGC;
        private System.Windows.Forms.Button bSettingsLeft;
        private PictureBoxWithInterpolationMode pictureBoxILeft;
        private System.Windows.Forms.Button bRefresh;
        private System.Windows.Forms.Button bHidePanel;
		private System.Windows.Forms.ToolTip toolTip1;
		private System.Windows.Forms.Button bSettingsRight;
		private System.Windows.Forms.ComboBox comboBoxSizeRight;
		private System.Windows.Forms.ComboBox cbDevicesRight;
		private PictureBoxWithInterpolationMode pictureBoxIRight;
		private System.Windows.Forms.Button button1;
	}
}

