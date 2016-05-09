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
            this.btnDrawOnDesktop = new System.Windows.Forms.Button();
            this.btnSaveLatestImage = new System.Windows.Forms.Button();
            this.tabControl = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.pictureBoxCapturedImage = new System.Windows.Forms.PictureBox();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.gbSettings = new System.Windows.Forms.GroupBox();
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
            this.tabControl.SuspendLayout();
            this.tabPage1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxCapturedImage)).BeginInit();
            this.tabPage3.SuspendLayout();
            this.gbSettings.SuspendLayout();
            this.gbAutoSave.SuspendLayout();
            this.gbFormSettings.SuspendLayout();
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
            // btnDrawOnDesktop
            // 
            this.btnDrawOnDesktop.Location = new System.Drawing.Point(6, 35);
            this.btnDrawOnDesktop.Name = "btnDrawOnDesktop";
            this.btnDrawOnDesktop.Size = new System.Drawing.Size(75, 23);
            this.btnDrawOnDesktop.TabIndex = 2;
            this.btnDrawOnDesktop.Text = "Draw";
            this.btnDrawOnDesktop.UseVisualStyleBackColor = true;
            this.btnDrawOnDesktop.Click += new System.EventHandler(this.btnDrawOnDesktop_Click);
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
            this.tabControl.Controls.Add(this.tabPage1);
            this.tabControl.Controls.Add(this.tabPage2);
            this.tabControl.Controls.Add(this.tabPage3);
            this.tabControl.Location = new System.Drawing.Point(10, 10);
            this.tabControl.Name = "tabControl";
            this.tabControl.SelectedIndex = 0;
            this.tabControl.Size = new System.Drawing.Size(357, 370);
            this.tabControl.TabIndex = 5;
            this.tabControl.SelectedIndexChanged += new System.EventHandler(this.tabControl_SelectedIndexChanged);
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.pictureBoxCapturedImage);
            this.tabPage1.Controls.Add(this.btnCaptureDesktop);
            this.tabPage1.Controls.Add(this.btnSaveLatestImage);
            this.tabPage1.Controls.Add(this.btnDrawOnDesktop);
            this.tabPage1.Controls.Add(this.btnCapturePartDesktop);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(349, 344);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Image";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // pictureBoxCapturedImage
            // 
            this.pictureBoxCapturedImage.Location = new System.Drawing.Point(5, 65);
            this.pictureBoxCapturedImage.Name = "pictureBoxCapturedImage";
            this.pictureBoxCapturedImage.Size = new System.Drawing.Size(337, 274);
            this.pictureBoxCapturedImage.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBoxCapturedImage.TabIndex = 5;
            this.pictureBoxCapturedImage.TabStop = false;
            // 
            // tabPage2
            // 
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(349, 344);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "CapturedImages";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // tabPage3
            // 
            this.tabPage3.Controls.Add(this.gbSettings);
            this.tabPage3.Location = new System.Drawing.Point(4, 22);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Size = new System.Drawing.Size(349, 344);
            this.tabPage3.TabIndex = 2;
            this.tabPage3.Text = "Settings";
            this.tabPage3.UseVisualStyleBackColor = true;
            // 
            // gbSettings
            // 
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
            // gbAutoSave
            // 
            this.gbAutoSave.Controls.Add(this.btnAutoSavePath);
            this.gbAutoSave.Controls.Add(this.tbAutoSaveDirectory);
            this.gbAutoSave.Controls.Add(this.cbAutoSave);
            this.gbAutoSave.Location = new System.Drawing.Point(7, 120);
            this.gbAutoSave.Name = "gbAutoSave";
            this.gbAutoSave.Size = new System.Drawing.Size(329, 85);
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
            this.gbFormSettings.Location = new System.Drawing.Point(6, 211);
            this.gbFormSettings.Name = "gbFormSettings";
            this.gbFormSettings.Size = new System.Drawing.Size(330, 81);
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
            this.tabPage1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxCapturedImage)).EndInit();
            this.tabPage3.ResumeLayout(false);
            this.gbSettings.ResumeLayout(false);
            this.gbSettings.PerformLayout();
            this.gbAutoSave.ResumeLayout(false);
            this.gbAutoSave.PerformLayout();
            this.gbFormSettings.ResumeLayout(false);
            this.gbFormSettings.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnCaptureDesktop;
        private System.Windows.Forms.Button btnCapturePartDesktop;
        private System.Windows.Forms.Button btnDrawOnDesktop;
        private System.Windows.Forms.Button btnSaveLatestImage;
        private System.Windows.Forms.TabControl tabControl;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.PictureBox pictureBoxCapturedImage;
        private System.Windows.Forms.TabPage tabPage3;
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
    }
}

