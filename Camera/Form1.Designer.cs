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
            this.cbDevices = new System.Windows.Forms.ComboBox();
            this.comboBoxSize = new System.Windows.Forms.ComboBox();
            this.panelMain = new System.Windows.Forms.Panel();
            this.bRefresh = new System.Windows.Forms.Button();
            this.bSettings = new System.Windows.Forms.Button();
            this.bShowScale = new System.Windows.Forms.Button();
            this.bRotateCW = new System.Windows.Forms.Button();
            this.bFlipH = new System.Windows.Forms.Button();
            this.bFlipV = new System.Windows.Forms.Button();
            this.timFPS_Counter = new System.Windows.Forms.Timer(this.components);
            this.tbZoom = new System.Windows.Forms.TrackBar();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.showPanelToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.saveImageToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.pWindowTitle = new System.Windows.Forms.Panel();
            this.button1 = new System.Windows.Forms.Button();
            this.bAbout = new System.Windows.Forms.Button();
            this.bTopMost = new System.Windows.Forms.Button();
            this.bMinimise = new System.Windows.Forms.Button();
            this.bClose = new System.Windows.Forms.Button();
            this.labelWindowTitle = new System.Windows.Forms.Label();
            this.pictureBoxWithInterpolationMode1 = new PictureBoxWithInterpolationMode();
            this.panelMain.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tbZoom)).BeginInit();
            this.contextMenuStrip1.SuspendLayout();
            this.pWindowTitle.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxWithInterpolationMode1)).BeginInit();
            this.SuspendLayout();
            // 
            // bStart
            // 
            this.bStart.Location = new System.Drawing.Point(335, 2);
            this.bStart.Name = "bStart";
            this.bStart.Size = new System.Drawing.Size(67, 23);
            this.bStart.TabIndex = 1;
            this.bStart.Text = "Start";
            this.bStart.UseVisualStyleBackColor = true;
            this.bStart.Click += new System.EventHandler(this.StartStop_Click);
            // 
            // cbDevices
            // 
            this.cbDevices.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.cbDevices.FormattingEnabled = true;
            this.cbDevices.Location = new System.Drawing.Point(37, 2);
            this.cbDevices.Name = "cbDevices";
            this.cbDevices.Size = new System.Drawing.Size(178, 23);
            this.cbDevices.TabIndex = 4;
            this.cbDevices.SelectedIndexChanged += new System.EventHandler(this.comboBox1_SelectedIndexChanged);
            // 
            // comboBoxSize
            // 
            this.comboBoxSize.Enabled = false;
            this.comboBoxSize.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.comboBoxSize.FormattingEnabled = true;
            this.comboBoxSize.Location = new System.Drawing.Point(217, 2);
            this.comboBoxSize.Name = "comboBoxSize";
            this.comboBoxSize.Size = new System.Drawing.Size(115, 23);
            this.comboBoxSize.TabIndex = 7;
            this.comboBoxSize.SelectedIndexChanged += new System.EventHandler(this.comboBoxSize_SelectedIndexChanged);
            // 
            // panelMain
            // 
            this.panelMain.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panelMain.Controls.Add(this.bRefresh);
            this.panelMain.Controls.Add(this.bSettings);
            this.panelMain.Controls.Add(this.comboBoxSize);
            this.panelMain.Controls.Add(this.bStart);
            this.panelMain.Controls.Add(this.cbDevices);
            this.panelMain.Location = new System.Drawing.Point(0, 462);
            this.panelMain.Name = "panelMain";
            this.panelMain.Size = new System.Drawing.Size(640, 26);
            this.panelMain.TabIndex = 8;
            // 
            // bRefresh
            // 
            this.bRefresh.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.bRefresh.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.bRefresh.Location = new System.Drawing.Point(4, -3);
            this.bRefresh.Name = "bRefresh";
            this.bRefresh.Size = new System.Drawing.Size(32, 31);
            this.bRefresh.TabIndex = 18;
            this.bRefresh.TabStop = false;
            this.bRefresh.Text = "↻";
            this.toolTip1.SetToolTip(this.bRefresh, "Refresh devices");
            this.bRefresh.UseVisualStyleBackColor = true;
            this.bRefresh.Click += new System.EventHandler(this.bRefresh_Click);
            this.bRefresh.Enter += new System.EventHandler(this.buttonToggler_Enter);
            // 
            // bSettings
            // 
            this.bSettings.Enabled = false;
            this.bSettings.Location = new System.Drawing.Point(406, 2);
            this.bSettings.Name = "bSettings";
            this.bSettings.Size = new System.Drawing.Size(76, 23);
            this.bSettings.TabIndex = 9;
            this.bSettings.Text = "Device";
            this.bSettings.UseVisualStyleBackColor = true;
            this.bSettings.Click += new System.EventHandler(this.bSettings_Click);
            // 
            // bShowScale
            // 
            this.bShowScale.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.bShowScale.BackColor = System.Drawing.Color.LightGray;
            this.bShowScale.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.bShowScale.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.bShowScale.Location = new System.Drawing.Point(435, -3);
            this.bShowScale.Name = "bShowScale";
            this.bShowScale.Size = new System.Drawing.Size(29, 28);
            this.bShowScale.TabIndex = 14;
            this.bShowScale.TabStop = false;
            this.bShowScale.Text = "🔍";
            this.toolTip1.SetToolTip(this.bShowScale, "Show Scale");
            this.bShowScale.UseVisualStyleBackColor = false;
            this.bShowScale.Click += new System.EventHandler(this.button5_Click);
            this.bShowScale.Enter += new System.EventHandler(this.buttonToggler_Enter);
            // 
            // bRotateCW
            // 
            this.bRotateCW.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.bRotateCW.BackColor = System.Drawing.Color.LightGray;
            this.bRotateCW.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.bRotateCW.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.bRotateCW.Location = new System.Drawing.Point(407, -4);
            this.bRotateCW.Name = "bRotateCW";
            this.bRotateCW.Size = new System.Drawing.Size(29, 28);
            this.bRotateCW.TabIndex = 13;
            this.bRotateCW.TabStop = false;
            this.bRotateCW.Text = "↷";
            this.toolTip1.SetToolTip(this.bRotateCW, "Rotate 90°");
            this.bRotateCW.UseVisualStyleBackColor = false;
            this.bRotateCW.Click += new System.EventHandler(this.button4_Click);
            this.bRotateCW.Enter += new System.EventHandler(this.buttonToggler_Enter);
            // 
            // bFlipH
            // 
            this.bFlipH.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.bFlipH.BackColor = System.Drawing.Color.LightGray;
            this.bFlipH.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.bFlipH.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.bFlipH.Location = new System.Drawing.Point(379, -4);
            this.bFlipH.Name = "bFlipH";
            this.bFlipH.Size = new System.Drawing.Size(29, 28);
            this.bFlipH.TabIndex = 12;
            this.bFlipH.TabStop = false;
            this.bFlipH.Text = "↔";
            this.toolTip1.SetToolTip(this.bFlipH, "Flip Horisontal");
            this.bFlipH.UseVisualStyleBackColor = false;
            this.bFlipH.Click += new System.EventHandler(this.button3_Click);
            this.bFlipH.Enter += new System.EventHandler(this.buttonToggler_Enter);
            // 
            // bFlipV
            // 
            this.bFlipV.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.bFlipV.BackColor = System.Drawing.Color.LightGray;
            this.bFlipV.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.bFlipV.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.bFlipV.Location = new System.Drawing.Point(351, -4);
            this.bFlipV.Name = "bFlipV";
            this.bFlipV.Size = new System.Drawing.Size(29, 28);
            this.bFlipV.TabIndex = 11;
            this.bFlipV.TabStop = false;
            this.bFlipV.Text = "↕";
            this.toolTip1.SetToolTip(this.bFlipV, "Flip vertical");
            this.bFlipV.UseVisualStyleBackColor = false;
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
            this.tbZoom.Location = new System.Drawing.Point(0, 24);
            this.tbZoom.Margin = new System.Windows.Forms.Padding(1);
            this.tbZoom.Maximum = 475;
            this.tbZoom.Name = "tbZoom";
            this.tbZoom.Size = new System.Drawing.Size(642, 23);
            this.tbZoom.TabIndex = 9;
            this.tbZoom.TabStop = false;
            this.tbZoom.TickStyle = System.Windows.Forms.TickStyle.None;
            this.tbZoom.Visible = false;
            this.tbZoom.Scroll += new System.EventHandler(this.tbZomom_Scroll);
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.showPanelToolStripMenuItem,
            this.toolStripSeparator1,
            this.saveImageToolStripMenuItem});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(141, 54);
            // 
            // showPanelToolStripMenuItem
            // 
            this.showPanelToolStripMenuItem.Name = "showPanelToolStripMenuItem";
            this.showPanelToolStripMenuItem.Size = new System.Drawing.Size(140, 22);
            this.showPanelToolStripMenuItem.Text = "Show panels";
            this.showPanelToolStripMenuItem.Click += new System.EventHandler(this.bHidePanel_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(137, 6);
            // 
            // saveImageToolStripMenuItem
            // 
            this.saveImageToolStripMenuItem.Name = "saveImageToolStripMenuItem";
            this.saveImageToolStripMenuItem.Size = new System.Drawing.Size(140, 22);
            this.saveImageToolStripMenuItem.Text = "Save image";
            this.saveImageToolStripMenuItem.Click += new System.EventHandler(this.ImageSave_Click);
            // 
            // pWindowTitle
            // 
            this.pWindowTitle.BackColor = System.Drawing.Color.LightGray;
            this.pWindowTitle.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pWindowTitle.Controls.Add(this.button1);
            this.pWindowTitle.Controls.Add(this.bFlipV);
            this.pWindowTitle.Controls.Add(this.bAbout);
            this.pWindowTitle.Controls.Add(this.bFlipH);
            this.pWindowTitle.Controls.Add(this.bShowScale);
            this.pWindowTitle.Controls.Add(this.bTopMost);
            this.pWindowTitle.Controls.Add(this.bRotateCW);
            this.pWindowTitle.Controls.Add(this.bMinimise);
            this.pWindowTitle.Controls.Add(this.bClose);
            this.pWindowTitle.Controls.Add(this.labelWindowTitle);
            this.pWindowTitle.Dock = System.Windows.Forms.DockStyle.Top;
            this.pWindowTitle.Location = new System.Drawing.Point(0, 0);
            this.pWindowTitle.Name = "pWindowTitle";
            this.pWindowTitle.Size = new System.Drawing.Size(640, 24);
            this.pWindowTitle.TabIndex = 19;
            this.pWindowTitle.MouseDown += new System.Windows.Forms.MouseEventHandler(this.title_MouseDown);
            this.pWindowTitle.MouseMove += new System.Windows.Forms.MouseEventHandler(this.title_MouseMove);
            this.pWindowTitle.MouseUp += new System.Windows.Forms.MouseEventHandler(this.title_MouseUp);
            // 
            // button1
            // 
            this.button1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.button1.BackColor = System.Drawing.SystemColors.ButtonShadow;
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.button1.Location = new System.Drawing.Point(561, -5);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(30, 32);
            this.button1.TabIndex = 15;
            this.button1.Text = "🞏";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // bAbout
            // 
            this.bAbout.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.bAbout.BackColor = System.Drawing.SystemColors.ButtonShadow;
            this.bAbout.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.bAbout.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.bAbout.Location = new System.Drawing.Point(498, -5);
            this.bAbout.Name = "bAbout";
            this.bAbout.Size = new System.Drawing.Size(28, 32);
            this.bAbout.TabIndex = 5;
            this.bAbout.Text = "?";
            this.bAbout.UseVisualStyleBackColor = false;
            this.bAbout.Click += new System.EventHandler(this.bAbout_Click);
            // 
            // bTopMost
            // 
            this.bTopMost.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.bTopMost.BackColor = System.Drawing.Color.LightGray;
            this.bTopMost.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.bTopMost.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.bTopMost.Location = new System.Drawing.Point(463, -6);
            this.bTopMost.Name = "bTopMost";
            this.bTopMost.Size = new System.Drawing.Size(29, 32);
            this.bTopMost.TabIndex = 4;
            this.bTopMost.Text = "↑";
            this.bTopMost.UseVisualStyleBackColor = false;
            this.bTopMost.Click += new System.EventHandler(this.bTopMost_Click);
            // 
            // bMinimise
            // 
            this.bMinimise.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.bMinimise.BackColor = System.Drawing.SystemColors.ButtonShadow;
            this.bMinimise.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.bMinimise.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.bMinimise.Location = new System.Drawing.Point(532, -6);
            this.bMinimise.Name = "bMinimise";
            this.bMinimise.Size = new System.Drawing.Size(30, 32);
            this.bMinimise.TabIndex = 2;
            this.bMinimise.Text = "_";
            this.bMinimise.UseVisualStyleBackColor = false;
            this.bMinimise.Click += new System.EventHandler(this.bMinimise_Click);
            // 
            // bClose
            // 
            this.bClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.bClose.BackColor = System.Drawing.Color.Crimson;
            this.bClose.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.bClose.Location = new System.Drawing.Point(591, -5);
            this.bClose.Name = "bClose";
            this.bClose.Size = new System.Drawing.Size(48, 33);
            this.bClose.TabIndex = 1;
            this.bClose.Text = "X";
            this.bClose.UseVisualStyleBackColor = false;
            this.bClose.Click += new System.EventHandler(this.bClose_Click);
            // 
            // labelWindowTitle
            // 
            this.labelWindowTitle.AutoSize = true;
            this.labelWindowTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.labelWindowTitle.Location = new System.Drawing.Point(6, 1);
            this.labelWindowTitle.Name = "labelWindowTitle";
            this.labelWindowTitle.Size = new System.Drawing.Size(59, 15);
            this.labelWindowTitle.TabIndex = 0;
            this.labelWindowTitle.Text = "CamView";
            // 
            // pictureBoxWithInterpolationMode1
            // 
            this.pictureBoxWithInterpolationMode1.BackColor = System.Drawing.SystemColors.InactiveCaptionText;
            this.pictureBoxWithInterpolationMode1.ContextMenuStrip = this.contextMenuStrip1;
            this.pictureBoxWithInterpolationMode1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pictureBoxWithInterpolationMode1.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.NearestNeighbor;
            this.pictureBoxWithInterpolationMode1.Location = new System.Drawing.Point(0, 0);
            this.pictureBoxWithInterpolationMode1.Name = "pictureBoxWithInterpolationMode1";
            this.pictureBoxWithInterpolationMode1.Size = new System.Drawing.Size(640, 487);
            this.pictureBoxWithInterpolationMode1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBoxWithInterpolationMode1.TabIndex = 5;
            this.pictureBoxWithInterpolationMode1.TabStop = false;
            this.pictureBoxWithInterpolationMode1.SizeChanged += new System.EventHandler(this.pictureBoxWithInterpolationMode1_SizeChanged);
            this.pictureBoxWithInterpolationMode1.DoubleClick += new System.EventHandler(this.StartStop_Click);
            this.pictureBoxWithInterpolationMode1.MouseDown += new System.Windows.Forms.MouseEventHandler(this.title_MouseDown);
            this.pictureBoxWithInterpolationMode1.MouseMove += new System.Windows.Forms.MouseEventHandler(this.title_MouseMove);
            this.pictureBoxWithInterpolationMode1.MouseUp += new System.Windows.Forms.MouseEventHandler(this.title_MouseUp);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(640, 487);
            this.Controls.Add(this.pWindowTitle);
            this.Controls.Add(this.tbZoom);
            this.Controls.Add(this.panelMain);
            this.Controls.Add(this.pictureBoxWithInterpolationMode1);
            this.DoubleBuffered = true;
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
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
            this.contextMenuStrip1.ResumeLayout(false);
            this.pWindowTitle.ResumeLayout(false);
            this.pWindowTitle.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxWithInterpolationMode1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Button bStart;
        private System.Windows.Forms.ComboBox cbDevices;
        private System.Windows.Forms.ComboBox comboBoxSize;
        private System.Windows.Forms.Panel panelMain;
        private System.Windows.Forms.Timer timFPS_Counter;
        private System.Windows.Forms.TrackBar tbZoom;
        private System.Windows.Forms.Button bSettings;
        private PictureBoxWithInterpolationMode pictureBoxWithInterpolationMode1;
        private System.Windows.Forms.Button bFlipV;
        private System.Windows.Forms.Button bShowScale;
        private System.Windows.Forms.Button bRotateCW;
        private System.Windows.Forms.Button bFlipH;
        private System.Windows.Forms.Button bRefresh;
		private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem showPanelToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem saveImageToolStripMenuItem;
        private System.Windows.Forms.Panel pWindowTitle;
        private System.Windows.Forms.Button bAbout;
        private System.Windows.Forms.Button bTopMost;
        private System.Windows.Forms.Button bMinimise;
        private System.Windows.Forms.Button bClose;
        private System.Windows.Forms.Label labelWindowTitle;
        private System.Windows.Forms.Button button1;
    }
}

