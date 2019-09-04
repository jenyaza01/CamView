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
            this.comboBoxDevices = new System.Windows.Forms.ComboBox();
            this.comboBoxSize = new System.Windows.Forms.ComboBox();
            this.panelMain = new System.Windows.Forms.Panel();
            this.bSettings = new System.Windows.Forms.Button();
            this.button7 = new System.Windows.Forms.Button();
            this.bTopMost = new System.Windows.Forms.Button();
            this.bShowScale = new System.Windows.Forms.Button();
            this.bRotateCW = new System.Windows.Forms.Button();
            this.bFlipH = new System.Windows.Forms.Button();
            this.bFlipV = new System.Windows.Forms.Button();
            this.timFPS_Counter = new System.Windows.Forms.Timer(this.components);
            this.tbZoom = new System.Windows.Forms.TrackBar();
            this.bRefresh = new System.Windows.Forms.Button();
            this.bHidePanel = new System.Windows.Forms.Button();
            this.pictureBoxWithInterpolationMode1 = new PictureBoxWithInterpolationMode();
            this.panelMain.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tbZoom)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxWithInterpolationMode1)).BeginInit();
            this.SuspendLayout();
            // 
            // bStart
            // 
            this.bStart.Location = new System.Drawing.Point(333, 3);
            this.bStart.Name = "bStart";
            this.bStart.Size = new System.Drawing.Size(74, 23);
            this.bStart.TabIndex = 1;
            this.bStart.Text = "Start";
            this.bStart.UseVisualStyleBackColor = true;
            this.bStart.Click += new System.EventHandler(this.StartStop_Click);
            // 
            // comboBoxDevices
            // 
            this.comboBoxDevices.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.comboBoxDevices.FormattingEnabled = true;
            this.comboBoxDevices.Location = new System.Drawing.Point(57, 2);
            this.comboBoxDevices.Name = "comboBoxDevices";
            this.comboBoxDevices.Size = new System.Drawing.Size(154, 23);
            this.comboBoxDevices.TabIndex = 4;
            this.comboBoxDevices.SelectedIndexChanged += new System.EventHandler(this.comboBox1_SelectedIndexChanged);
            // 
            // comboBoxSize
            // 
            this.comboBoxSize.Enabled = false;
            this.comboBoxSize.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.comboBoxSize.FormattingEnabled = true;
            this.comboBoxSize.Location = new System.Drawing.Point(213, 2);
            this.comboBoxSize.Name = "comboBoxSize";
            this.comboBoxSize.Size = new System.Drawing.Size(119, 23);
            this.comboBoxSize.TabIndex = 7;
            this.comboBoxSize.SelectedIndexChanged += new System.EventHandler(this.comboBoxSize_SelectedIndexChanged);
            // 
            // panelMain
            // 
            this.panelMain.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panelMain.Controls.Add(this.bRefresh);
            this.panelMain.Controls.Add(this.bHidePanel);
            this.panelMain.Controls.Add(this.bSettings);
            this.panelMain.Controls.Add(this.comboBoxSize);
            this.panelMain.Controls.Add(this.bStart);
            this.panelMain.Controls.Add(this.comboBoxDevices);
            this.panelMain.Controls.Add(this.button7);
            this.panelMain.Controls.Add(this.bTopMost);
            this.panelMain.Controls.Add(this.bShowScale);
            this.panelMain.Controls.Add(this.bRotateCW);
            this.panelMain.Controls.Add(this.bFlipH);
            this.panelMain.Controls.Add(this.bFlipV);
            this.panelMain.Location = new System.Drawing.Point(0, 393);
            this.panelMain.Name = "panelMain";
            this.panelMain.Size = new System.Drawing.Size(648, 26);
            this.panelMain.TabIndex = 8;
            // 
            // bSettings
            // 
            this.bSettings.Enabled = false;
            this.bSettings.Location = new System.Drawing.Point(408, 3);
            this.bSettings.Name = "bSettings";
            this.bSettings.Size = new System.Drawing.Size(67, 23);
            this.bSettings.TabIndex = 9;
            this.bSettings.Text = "Settings";
            this.bSettings.UseVisualStyleBackColor = true;
            this.bSettings.Click += new System.EventHandler(this.bSettings_Click);
            // 
            // button7
            // 
            this.button7.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button7.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.button7.Location = new System.Drawing.Point(613, -3);
            this.button7.Name = "button7";
            this.button7.Size = new System.Drawing.Size(25, 33);
            this.button7.TabIndex = 16;
            this.button7.TabStop = false;
            this.button7.Text = "▼";
            this.button7.UseVisualStyleBackColor = true;
            this.button7.Click += new System.EventHandler(this.button7_Click);
            this.button7.Enter += new System.EventHandler(this.buttonToggler_Enter);
            // 
            // bTopMost
            // 
            this.bTopMost.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.bTopMost.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.bTopMost.Location = new System.Drawing.Point(586, -1);
            this.bTopMost.Name = "bTopMost";
            this.bTopMost.Size = new System.Drawing.Size(25, 28);
            this.bTopMost.TabIndex = 15;
            this.bTopMost.TabStop = false;
            this.bTopMost.Text = "▲";
            this.bTopMost.UseVisualStyleBackColor = true;
            this.bTopMost.Click += new System.EventHandler(this.button6_Click);
            this.bTopMost.Enter += new System.EventHandler(this.buttonToggler_Enter);
            // 
            // bShowScale
            // 
            this.bShowScale.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.bShowScale.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.bShowScale.Location = new System.Drawing.Point(559, -1);
            this.bShowScale.Name = "bShowScale";
            this.bShowScale.Size = new System.Drawing.Size(25, 28);
            this.bShowScale.TabIndex = 14;
            this.bShowScale.TabStop = false;
            this.bShowScale.Text = "⇕";
            this.bShowScale.UseVisualStyleBackColor = true;
            this.bShowScale.Click += new System.EventHandler(this.button5_Click);
            this.bShowScale.Enter += new System.EventHandler(this.buttonToggler_Enter);
            // 
            // bRotateCW
            // 
            this.bRotateCW.BackColor = System.Drawing.Color.WhiteSmoke;
            this.bRotateCW.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.bRotateCW.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.bRotateCW.Location = new System.Drawing.Point(532, -1);
            this.bRotateCW.Name = "bRotateCW";
            this.bRotateCW.Size = new System.Drawing.Size(25, 28);
            this.bRotateCW.TabIndex = 13;
            this.bRotateCW.TabStop = false;
            this.bRotateCW.Text = "↷";
            this.bRotateCW.UseVisualStyleBackColor = false;
            this.bRotateCW.Click += new System.EventHandler(this.button4_Click);
            this.bRotateCW.Enter += new System.EventHandler(this.buttonToggler_Enter);
            // 
            // bFlipH
            // 
            this.bFlipH.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.bFlipH.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.bFlipH.Location = new System.Drawing.Point(505, -3);
            this.bFlipH.Name = "bFlipH";
            this.bFlipH.Size = new System.Drawing.Size(25, 36);
            this.bFlipH.TabIndex = 12;
            this.bFlipH.TabStop = false;
            this.bFlipH.Text = "↔";
            this.bFlipH.UseVisualStyleBackColor = true;
            this.bFlipH.Click += new System.EventHandler(this.button3_Click);
            this.bFlipH.Enter += new System.EventHandler(this.buttonToggler_Enter);
            // 
            // bFlipV
            // 
            this.bFlipV.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.bFlipV.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.bFlipV.Location = new System.Drawing.Point(478, -1);
            this.bFlipV.Name = "bFlipV";
            this.bFlipV.Size = new System.Drawing.Size(25, 28);
            this.bFlipV.TabIndex = 11;
            this.bFlipV.TabStop = false;
            this.bFlipV.Text = "↕";
            this.bFlipV.UseVisualStyleBackColor = true;
            this.bFlipV.Click += new System.EventHandler(this.button2_Click);
            this.bFlipV.Enter += new System.EventHandler(this.buttonToggler_Enter);
            // 
            // timFPS_Counter
            // 
            this.timFPS_Counter.Interval = 998;
            this.timFPS_Counter.Tick += new System.EventHandler(this.timFPS_Tick);
            // 
            // tbZoom
            // 
            this.tbZoom.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tbZoom.AutoSize = false;
            this.tbZoom.Enabled = false;
            this.tbZoom.Location = new System.Drawing.Point(0, 0);
            this.tbZoom.Margin = new System.Windows.Forms.Padding(1);
            this.tbZoom.Maximum = 465;
            this.tbZoom.Name = "tbZoom";
            this.tbZoom.Size = new System.Drawing.Size(648, 23);
            this.tbZoom.TabIndex = 9;
            this.tbZoom.TabStop = false;
            this.tbZoom.TickStyle = System.Windows.Forms.TickStyle.None;
            this.tbZoom.Visible = false;
            this.tbZoom.Scroll += new System.EventHandler(this.trackBar1_Scroll);
            // 
            // bRefresh
            // 
            this.bRefresh.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.bRefresh.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.bRefresh.Location = new System.Drawing.Point(28, -4);
            this.bRefresh.Name = "bRefresh";
            this.bRefresh.Size = new System.Drawing.Size(25, 36);
            this.bRefresh.TabIndex = 18;
            this.bRefresh.TabStop = false;
            this.bRefresh.Text = "↻";
            this.bRefresh.UseVisualStyleBackColor = true;
            this.bRefresh.Click += new System.EventHandler(this.bRefresh_Click);
            this.bRefresh.Enter += new System.EventHandler(this.buttonToggler_Enter);
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
            this.bHidePanel.UseVisualStyleBackColor = true;
            this.bHidePanel.Click += new System.EventHandler(this.bHidePanel_Click);
            this.bHidePanel.Enter += new System.EventHandler(this.buttonToggler_Enter);
            // 
            // pictureBoxWithInterpolationMode1
            // 
            this.pictureBoxWithInterpolationMode1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pictureBoxWithInterpolationMode1.BackColor = System.Drawing.SystemColors.InactiveCaptionText;
            this.pictureBoxWithInterpolationMode1.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.NearestNeighbor;
            this.pictureBoxWithInterpolationMode1.Location = new System.Drawing.Point(0, 0);
            this.pictureBoxWithInterpolationMode1.Name = "pictureBoxWithInterpolationMode1";
            this.pictureBoxWithInterpolationMode1.Size = new System.Drawing.Size(646, 419);
            this.pictureBoxWithInterpolationMode1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBoxWithInterpolationMode1.TabIndex = 5;
            this.pictureBoxWithInterpolationMode1.TabStop = false;
            this.pictureBoxWithInterpolationMode1.SizeChanged += new System.EventHandler(this.pictureBoxWithInterpolationMode1_SizeChanged);
            this.pictureBoxWithInterpolationMode1.DoubleClick += new System.EventHandler(this.StartStop_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.ClientSize = new System.Drawing.Size(646, 418);
            this.Controls.Add(this.tbZoom);
            this.Controls.Add(this.panelMain);
            this.Controls.Add(this.pictureBoxWithInterpolationMode1);
            this.DoubleBuffered = true;
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.Name = "Form1";
            this.ShowIcon = false;
            this.Text = "CamView";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.Load += new System.EventHandler(this.Form1_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Form1_KeyDown);
            this.panelMain.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.tbZoom)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxWithInterpolationMode1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Button bStart;
        private System.Windows.Forms.ComboBox comboBoxDevices;
        private System.Windows.Forms.ComboBox comboBoxSize;
        private System.Windows.Forms.Panel panelMain;
        private System.Windows.Forms.Timer timFPS_Counter;
        private System.Windows.Forms.TrackBar tbZoom;
        private System.Windows.Forms.Button bSettings;
        private PictureBoxWithInterpolationMode pictureBoxWithInterpolationMode1;
        private System.Windows.Forms.Button bFlipV;
        private System.Windows.Forms.Button button7;
        private System.Windows.Forms.Button bTopMost;
        private System.Windows.Forms.Button bShowScale;
        private System.Windows.Forms.Button bRotateCW;
        private System.Windows.Forms.Button bFlipH;
        private System.Windows.Forms.Button bRefresh;
        private System.Windows.Forms.Button bHidePanel;
    }
}

