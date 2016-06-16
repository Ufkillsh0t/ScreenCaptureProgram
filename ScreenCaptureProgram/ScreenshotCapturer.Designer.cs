namespace ScreenCaptureProgram
{
    partial class ScreenshotCapturer
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
            this.btnCaptureDesktop = new System.Windows.Forms.Button();
            this.btnCapturePartDesktop = new System.Windows.Forms.Button();
            this.btnSaveLatestImage = new System.Windows.Forms.Button();
            this.tabControl = new System.Windows.Forms.TabControl();
            this.tabImage = new System.Windows.Forms.TabPage();
            this.pbCapturedImage = new System.Windows.Forms.PictureBox();
            this.tabCapturedImages = new System.Windows.Forms.TabPage();
            this.btnOpenMap = new System.Windows.Forms.Button();
            this.gbCachedImage = new System.Windows.Forms.GroupBox();
            this.pbCachedImage = new System.Windows.Forms.PictureBox();
            this.btnOpen = new System.Windows.Forms.Button();
            this.btnNext = new System.Windows.Forms.Button();
            this.btnPrevious = new System.Windows.Forms.Button();
            this.tabSettings = new System.Windows.Forms.TabPage();
            this.gbSettings = new System.Windows.Forms.GroupBox();
            this.cbCache = new System.Windows.Forms.CheckBox();
            this.gbAutoSave = new System.Windows.Forms.GroupBox();
            this.btnAutoSavePath = new System.Windows.Forms.Button();
            this.tbAutoSaveDirectory = new System.Windows.Forms.TextBox();
            this.cbAutoSave = new System.Windows.Forms.CheckBox();
            this.btnResetSettings = new System.Windows.Forms.Button();
            this.btnSaveSettings = new System.Windows.Forms.Button();
            this.cbBringApplicationForward = new System.Windows.Forms.CheckBox();
            this.cbImageToClipBoard = new System.Windows.Forms.CheckBox();
            this.gbFormSettings = new System.Windows.Forms.GroupBox();
            this.cbResize = new System.Windows.Forms.CheckBox();
            this.gbKeybindings = new System.Windows.Forms.GroupBox();
            this.lblKeybind1 = new System.Windows.Forms.Label();
            this.lblKeybind2 = new System.Windows.Forms.Label();
            this.tabControl.SuspendLayout();
            this.tabImage.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbCapturedImage)).BeginInit();
            this.tabCapturedImages.SuspendLayout();
            this.gbCachedImage.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbCachedImage)).BeginInit();
            this.tabSettings.SuspendLayout();
            this.gbSettings.SuspendLayout();
            this.gbAutoSave.SuspendLayout();
            this.gbFormSettings.SuspendLayout();
            this.gbKeybindings.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnCaptureDesktop
            // 
            this.btnCaptureDesktop.Location = new System.Drawing.Point(6, 6);
            this.btnCaptureDesktop.Name = "btnCaptureDesktop";
            this.btnCaptureDesktop.Size = new System.Drawing.Size(75, 23);
            this.btnCaptureDesktop.TabIndex = 0;
            this.btnCaptureDesktop.Text = "Capture";
            this.btnCaptureDesktop.UseVisualStyleBackColor = true;
            this.btnCaptureDesktop.Click += new System.EventHandler(this.btnCaptureDesktop_Click);
            // 
            // btnCapturePartDesktop
            // 
            this.btnCapturePartDesktop.Location = new System.Drawing.Point(87, 6);
            this.btnCapturePartDesktop.Name = "btnCapturePartDesktop";
            this.btnCapturePartDesktop.Size = new System.Drawing.Size(99, 23);
            this.btnCapturePartDesktop.TabIndex = 1;
            this.btnCapturePartDesktop.Text = "Capture Selected";
            this.btnCapturePartDesktop.UseVisualStyleBackColor = true;
            this.btnCapturePartDesktop.Click += new System.EventHandler(this.btnCapturePartDesktop_Click);
            // 
            // btnSaveLatestImage
            // 
            this.btnSaveLatestImage.Location = new System.Drawing.Point(192, 6);
            this.btnSaveLatestImage.Name = "btnSaveLatestImage";
            this.btnSaveLatestImage.Size = new System.Drawing.Size(75, 23);
            this.btnSaveLatestImage.TabIndex = 4;
            this.btnSaveLatestImage.Text = "Save";
            this.btnSaveLatestImage.UseVisualStyleBackColor = true;
            this.btnSaveLatestImage.Click += new System.EventHandler(this.btnSaveLatestImage_Click);
            // 
            // tabControl
            // 
            this.tabControl.Controls.Add(this.tabImage);
            this.tabControl.Controls.Add(this.tabCapturedImages);
            this.tabControl.Controls.Add(this.tabSettings);
            this.tabControl.Location = new System.Drawing.Point(12, 12);
            this.tabControl.Name = "tabControl";
            this.tabControl.SelectedIndex = 0;
            this.tabControl.Size = new System.Drawing.Size(357, 370);
            this.tabControl.TabIndex = 5;
            this.tabControl.SelectedIndexChanged += new System.EventHandler(this.tabControl_SelectedIndexChanged);
            // 
            // tabImage
            // 
            this.tabImage.Controls.Add(this.pbCapturedImage);
            this.tabImage.Controls.Add(this.btnCaptureDesktop);
            this.tabImage.Controls.Add(this.btnSaveLatestImage);
            this.tabImage.Controls.Add(this.btnCapturePartDesktop);
            this.tabImage.Location = new System.Drawing.Point(4, 22);
            this.tabImage.Name = "tabImage";
            this.tabImage.Padding = new System.Windows.Forms.Padding(3);
            this.tabImage.Size = new System.Drawing.Size(349, 344);
            this.tabImage.TabIndex = 0;
            this.tabImage.Text = "Image";
            this.tabImage.UseVisualStyleBackColor = true;
            // 
            // pbCapturedImage
            // 
            this.pbCapturedImage.Location = new System.Drawing.Point(5, 35);
            this.pbCapturedImage.Name = "pbCapturedImage";
            this.pbCapturedImage.Size = new System.Drawing.Size(337, 304);
            this.pbCapturedImage.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pbCapturedImage.TabIndex = 5;
            this.pbCapturedImage.TabStop = false;
            // 
            // tabCapturedImages
            // 
            this.tabCapturedImages.Controls.Add(this.btnOpenMap);
            this.tabCapturedImages.Controls.Add(this.gbCachedImage);
            this.tabCapturedImages.Controls.Add(this.btnOpen);
            this.tabCapturedImages.Controls.Add(this.btnNext);
            this.tabCapturedImages.Controls.Add(this.btnPrevious);
            this.tabCapturedImages.Location = new System.Drawing.Point(4, 22);
            this.tabCapturedImages.Name = "tabCapturedImages";
            this.tabCapturedImages.Padding = new System.Windows.Forms.Padding(3);
            this.tabCapturedImages.Size = new System.Drawing.Size(349, 344);
            this.tabCapturedImages.TabIndex = 1;
            this.tabCapturedImages.Text = "CapturedImages";
            this.tabCapturedImages.UseVisualStyleBackColor = true;
            // 
            // btnOpenMap
            // 
            this.btnOpenMap.Location = new System.Drawing.Point(258, 306);
            this.btnOpenMap.Name = "btnOpenMap";
            this.btnOpenMap.Size = new System.Drawing.Size(75, 23);
            this.btnOpenMap.TabIndex = 7;
            this.btnOpenMap.Text = "Open map";
            this.btnOpenMap.UseVisualStyleBackColor = true;
            this.btnOpenMap.Click += new System.EventHandler(this.btnOpenMap_Click);
            // 
            // gbCachedImage
            // 
            this.gbCachedImage.Controls.Add(this.pbCachedImage);
            this.gbCachedImage.Location = new System.Drawing.Point(7, 6);
            this.gbCachedImage.Name = "gbCachedImage";
            this.gbCachedImage.Size = new System.Drawing.Size(336, 294);
            this.gbCachedImage.TabIndex = 6;
            this.gbCachedImage.TabStop = false;
            this.gbCachedImage.Text = "groupBox1";
            // 
            // pbCachedImage
            // 
            this.pbCachedImage.Location = new System.Drawing.Point(6, 19);
            this.pbCachedImage.Name = "pbCachedImage";
            this.pbCachedImage.Size = new System.Drawing.Size(324, 269);
            this.pbCachedImage.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pbCachedImage.TabIndex = 0;
            this.pbCachedImage.TabStop = false;
            // 
            // btnOpen
            // 
            this.btnOpen.Location = new System.Drawing.Point(177, 306);
            this.btnOpen.Name = "btnOpen";
            this.btnOpen.Size = new System.Drawing.Size(75, 23);
            this.btnOpen.TabIndex = 3;
            this.btnOpen.Text = "Open";
            this.btnOpen.UseVisualStyleBackColor = true;
            this.btnOpen.Click += new System.EventHandler(this.btnOpen_Click);
            // 
            // btnNext
            // 
            this.btnNext.Location = new System.Drawing.Point(96, 306);
            this.btnNext.Name = "btnNext";
            this.btnNext.Size = new System.Drawing.Size(75, 23);
            this.btnNext.TabIndex = 2;
            this.btnNext.Text = "Next";
            this.btnNext.UseVisualStyleBackColor = true;
            this.btnNext.Click += new System.EventHandler(this.btnNext_Click);
            // 
            // btnPrevious
            // 
            this.btnPrevious.Location = new System.Drawing.Point(15, 306);
            this.btnPrevious.Name = "btnPrevious";
            this.btnPrevious.Size = new System.Drawing.Size(75, 23);
            this.btnPrevious.TabIndex = 1;
            this.btnPrevious.Text = "Previous";
            this.btnPrevious.UseVisualStyleBackColor = true;
            this.btnPrevious.Click += new System.EventHandler(this.btnPrevious_Click);
            // 
            // tabSettings
            // 
            this.tabSettings.Controls.Add(this.gbSettings);
            this.tabSettings.Location = new System.Drawing.Point(4, 22);
            this.tabSettings.Name = "tabSettings";
            this.tabSettings.Size = new System.Drawing.Size(349, 344);
            this.tabSettings.TabIndex = 2;
            this.tabSettings.Text = "Settings";
            this.tabSettings.UseVisualStyleBackColor = true;
            // 
            // gbSettings
            // 
            this.gbSettings.Controls.Add(this.gbKeybindings);
            this.gbSettings.Controls.Add(this.cbCache);
            this.gbSettings.Controls.Add(this.gbAutoSave);
            this.gbSettings.Controls.Add(this.btnResetSettings);
            this.gbSettings.Controls.Add(this.btnSaveSettings);
            this.gbSettings.Controls.Add(this.cbBringApplicationForward);
            this.gbSettings.Controls.Add(this.cbImageToClipBoard);
            this.gbSettings.Controls.Add(this.gbFormSettings);
            this.gbSettings.Location = new System.Drawing.Point(4, 3);
            this.gbSettings.Name = "gbSettings";
            this.gbSettings.Size = new System.Drawing.Size(342, 338);
            this.gbSettings.TabIndex = 0;
            this.gbSettings.TabStop = false;
            this.gbSettings.Text = "Settings";
            // 
            // cbCache
            // 
            this.cbCache.AutoSize = true;
            this.cbCache.Location = new System.Drawing.Point(7, 67);
            this.cbCache.Name = "cbCache";
            this.cbCache.Size = new System.Drawing.Size(149, 17);
            this.cbCache.TabIndex = 7;
            this.cbCache.Text = "Cache saved screenshots";
            this.cbCache.UseVisualStyleBackColor = true;
            this.cbCache.CheckedChanged += new System.EventHandler(this.cbCache_CheckedChanged);
            // 
            // gbAutoSave
            // 
            this.gbAutoSave.Controls.Add(this.btnAutoSavePath);
            this.gbAutoSave.Controls.Add(this.tbAutoSaveDirectory);
            this.gbAutoSave.Controls.Add(this.cbAutoSave);
            this.gbAutoSave.Location = new System.Drawing.Point(7, 90);
            this.gbAutoSave.Name = "gbAutoSave";
            this.gbAutoSave.Size = new System.Drawing.Size(329, 73);
            this.gbAutoSave.TabIndex = 6;
            this.gbAutoSave.TabStop = false;
            this.gbAutoSave.Text = "Save captured screenshots automatically";
            // 
            // btnAutoSavePath
            // 
            this.btnAutoSavePath.Location = new System.Drawing.Point(248, 40);
            this.btnAutoSavePath.Name = "btnAutoSavePath";
            this.btnAutoSavePath.Size = new System.Drawing.Size(75, 23);
            this.btnAutoSavePath.TabIndex = 2;
            this.btnAutoSavePath.Text = "Set path";
            this.btnAutoSavePath.UseVisualStyleBackColor = true;
            this.btnAutoSavePath.Click += new System.EventHandler(this.btnAutoSavePath_Click);
            // 
            // tbAutoSaveDirectory
            // 
            this.tbAutoSaveDirectory.Enabled = false;
            this.tbAutoSaveDirectory.Location = new System.Drawing.Point(5, 42);
            this.tbAutoSaveDirectory.Name = "tbAutoSaveDirectory";
            this.tbAutoSaveDirectory.Size = new System.Drawing.Size(237, 20);
            this.tbAutoSaveDirectory.TabIndex = 1;
            // 
            // cbAutoSave
            // 
            this.cbAutoSave.AutoSize = true;
            this.cbAutoSave.Location = new System.Drawing.Point(6, 19);
            this.cbAutoSave.Name = "cbAutoSave";
            this.cbAutoSave.Size = new System.Drawing.Size(74, 17);
            this.cbAutoSave.TabIndex = 0;
            this.cbAutoSave.Text = "Auto save";
            this.cbAutoSave.UseVisualStyleBackColor = true;
            this.cbAutoSave.CheckedChanged += new System.EventHandler(this.cbAutoSave_CheckedChanged);
            // 
            // btnResetSettings
            // 
            this.btnResetSettings.Location = new System.Drawing.Point(99, 298);
            this.btnResetSettings.Name = "btnResetSettings";
            this.btnResetSettings.Size = new System.Drawing.Size(75, 23);
            this.btnResetSettings.TabIndex = 5;
            this.btnResetSettings.Text = "Reset settings";
            this.btnResetSettings.UseVisualStyleBackColor = true;
            this.btnResetSettings.Click += new System.EventHandler(this.btnResetSettings_Click);
            // 
            // btnSaveSettings
            // 
            this.btnSaveSettings.Location = new System.Drawing.Point(7, 298);
            this.btnSaveSettings.Name = "btnSaveSettings";
            this.btnSaveSettings.Size = new System.Drawing.Size(86, 23);
            this.btnSaveSettings.TabIndex = 4;
            this.btnSaveSettings.Text = "Save settings";
            this.btnSaveSettings.UseVisualStyleBackColor = true;
            this.btnSaveSettings.Click += new System.EventHandler(this.btnSaveSettings_Click);
            // 
            // cbBringApplicationForward
            // 
            this.cbBringApplicationForward.AutoSize = true;
            this.cbBringApplicationForward.Location = new System.Drawing.Point(7, 43);
            this.cbBringApplicationForward.Name = "cbBringApplicationForward";
            this.cbBringApplicationForward.Size = new System.Drawing.Size(234, 17);
            this.cbBringApplicationForward.TabIndex = 3;
            this.cbBringApplicationForward.Text = "Bring application forward after capturing one";
            this.cbBringApplicationForward.UseVisualStyleBackColor = true;
            this.cbBringApplicationForward.CheckedChanged += new System.EventHandler(this.cbBringApplicationForward_CheckedChanged);
            // 
            // cbImageToClipBoard
            // 
            this.cbImageToClipBoard.AutoSize = true;
            this.cbImageToClipBoard.Location = new System.Drawing.Point(7, 20);
            this.cbImageToClipBoard.Name = "cbImageToClipBoard";
            this.cbImageToClipBoard.Size = new System.Drawing.Size(141, 17);
            this.cbImageToClipBoard.TabIndex = 2;
            this.cbImageToClipBoard.Text = "Copy image to ClipBoard";
            this.cbImageToClipBoard.UseVisualStyleBackColor = true;
            this.cbImageToClipBoard.CheckedChanged += new System.EventHandler(this.cbImageToClipBoard_CheckedChanged);
            // 
            // gbFormSettings
            // 
            this.gbFormSettings.Controls.Add(this.cbResize);
            this.gbFormSettings.Location = new System.Drawing.Point(7, 169);
            this.gbFormSettings.Name = "gbFormSettings";
            this.gbFormSettings.Size = new System.Drawing.Size(330, 44);
            this.gbFormSettings.TabIndex = 1;
            this.gbFormSettings.TabStop = false;
            this.gbFormSettings.Text = "FormSettings";
            // 
            // cbResize
            // 
            this.cbResize.AutoSize = true;
            this.cbResize.Location = new System.Drawing.Point(6, 19);
            this.cbResize.Name = "cbResize";
            this.cbResize.Size = new System.Drawing.Size(195, 17);
            this.cbResize.TabIndex = 0;
            this.cbResize.Text = "Resize image at end of resizing form";
            this.cbResize.UseVisualStyleBackColor = true;
            // 
            // gbKeybindings
            // 
            this.gbKeybindings.Controls.Add(this.lblKeybind2);
            this.gbKeybindings.Controls.Add(this.lblKeybind1);
            this.gbKeybindings.Location = new System.Drawing.Point(7, 220);
            this.gbKeybindings.Name = "gbKeybindings";
            this.gbKeybindings.Size = new System.Drawing.Size(329, 72);
            this.gbKeybindings.TabIndex = 8;
            this.gbKeybindings.TabStop = false;
            this.gbKeybindings.Text = "Keybindings";
            // 
            // lblKeybind1
            // 
            this.lblKeybind1.AutoSize = true;
            this.lblKeybind1.Location = new System.Drawing.Point(17, 20);
            this.lblKeybind1.Name = "lblKeybind1";
            this.lblKeybind1.Size = new System.Drawing.Size(228, 13);
            this.lblKeybind1.TabIndex = 0;
            this.lblKeybind1.Text = "Capture entire primary screen: CTRL + ALT + 6";
            // 
            // lblKeybind2
            // 
            this.lblKeybind2.AutoSize = true;
            this.lblKeybind2.Location = new System.Drawing.Point(17, 42);
            this.lblKeybind2.Name = "lblKeybind2";
            this.lblKeybind2.Size = new System.Drawing.Size(205, 13);
            this.lblKeybind2.TabIndex = 1;
            this.lblKeybind2.Text = "Capture part of dekstop: CTRL  + ALT + 5";
            // 
            // ScreenshotCapturer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(375, 388);
            this.Controls.Add(this.tabControl);
            this.Name = "ScreenshotCapturer";
            this.Text = "ScreenshotCapturer";
            this.ResizeEnd += new System.EventHandler(this.ScreenshotCapturer_ResizeEnd);
            this.SizeChanged += new System.EventHandler(this.ScreenshotCapturer_SizeChanged);
            this.tabControl.ResumeLayout(false);
            this.tabImage.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pbCapturedImage)).EndInit();
            this.tabCapturedImages.ResumeLayout(false);
            this.gbCachedImage.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pbCachedImage)).EndInit();
            this.tabSettings.ResumeLayout(false);
            this.gbSettings.ResumeLayout(false);
            this.gbSettings.PerformLayout();
            this.gbAutoSave.ResumeLayout(false);
            this.gbAutoSave.PerformLayout();
            this.gbFormSettings.ResumeLayout(false);
            this.gbFormSettings.PerformLayout();
            this.gbKeybindings.ResumeLayout(false);
            this.gbKeybindings.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnCaptureDesktop;
        private System.Windows.Forms.Button btnCapturePartDesktop;
        private System.Windows.Forms.Button btnSaveLatestImage;
        private System.Windows.Forms.TabControl tabControl;
        private System.Windows.Forms.TabPage tabImage;
        private System.Windows.Forms.TabPage tabCapturedImages;
        private System.Windows.Forms.PictureBox pbCapturedImage;
        private System.Windows.Forms.TabPage tabSettings;
        private System.Windows.Forms.GroupBox gbSettings;
        private System.Windows.Forms.GroupBox gbFormSettings;
        private System.Windows.Forms.CheckBox cbResize;
        private System.Windows.Forms.Button btnResetSettings;
        private System.Windows.Forms.Button btnSaveSettings;
        private System.Windows.Forms.CheckBox cbBringApplicationForward;
        private System.Windows.Forms.CheckBox cbImageToClipBoard;
        private System.Windows.Forms.GroupBox gbAutoSave;
        private System.Windows.Forms.Button btnAutoSavePath;
        private System.Windows.Forms.TextBox tbAutoSaveDirectory;
        private System.Windows.Forms.CheckBox cbAutoSave;
        private System.Windows.Forms.CheckBox cbCache;
        private System.Windows.Forms.Button btnOpen;
        private System.Windows.Forms.Button btnNext;
        private System.Windows.Forms.Button btnPrevious;
        private System.Windows.Forms.PictureBox pbCachedImage;
        private System.Windows.Forms.GroupBox gbCachedImage;
        private System.Windows.Forms.Button btnOpenMap;
        private System.Windows.Forms.GroupBox gbKeybindings;
        private System.Windows.Forms.Label lblKeybind2;
        private System.Windows.Forms.Label lblKeybind1;
    }
}

