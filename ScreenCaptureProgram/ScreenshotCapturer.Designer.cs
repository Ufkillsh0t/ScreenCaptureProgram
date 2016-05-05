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
            this.tbTestHooks = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // btnCaptureDesktop
            // 
            this.btnCaptureDesktop.Location = new System.Drawing.Point(13, 13);
            this.btnCaptureDesktop.Name = "btnCaptureDesktop";
            this.btnCaptureDesktop.Size = new System.Drawing.Size(75, 23);
            this.btnCaptureDesktop.TabIndex = 0;
            this.btnCaptureDesktop.Text = "Capture";
            this.btnCaptureDesktop.UseVisualStyleBackColor = true;
            this.btnCaptureDesktop.Click += new System.EventHandler(this.btnCaptureDesktop_Click);
            // 
            // btnCapturePartDesktop
            // 
            this.btnCapturePartDesktop.Location = new System.Drawing.Point(94, 13);
            this.btnCapturePartDesktop.Name = "btnCapturePartDesktop";
            this.btnCapturePartDesktop.Size = new System.Drawing.Size(99, 23);
            this.btnCapturePartDesktop.TabIndex = 1;
            this.btnCapturePartDesktop.Text = "Capture Selected";
            this.btnCapturePartDesktop.UseVisualStyleBackColor = true;
            this.btnCapturePartDesktop.Click += new System.EventHandler(this.btnCapturePartDesktop_Click);
            // 
            // btnDrawOnDesktop
            // 
            this.btnDrawOnDesktop.Location = new System.Drawing.Point(13, 64);
            this.btnDrawOnDesktop.Name = "btnDrawOnDesktop";
            this.btnDrawOnDesktop.Size = new System.Drawing.Size(75, 23);
            this.btnDrawOnDesktop.TabIndex = 2;
            this.btnDrawOnDesktop.Text = "Draw";
            this.btnDrawOnDesktop.UseVisualStyleBackColor = true;
            this.btnDrawOnDesktop.Click += new System.EventHandler(this.btnDrawOnDesktop_Click);
            // 
            // tbTestHooks
            // 
            this.tbTestHooks.Location = new System.Drawing.Point(13, 106);
            this.tbTestHooks.Multiline = true;
            this.tbTestHooks.Name = "tbTestHooks";
            this.tbTestHooks.Size = new System.Drawing.Size(356, 276);
            this.tbTestHooks.TabIndex = 3;
            // 
            // ScreenshotCapturer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(381, 394);
            this.Controls.Add(this.tbTestHooks);
            this.Controls.Add(this.btnDrawOnDesktop);
            this.Controls.Add(this.btnCapturePartDesktop);
            this.Controls.Add(this.btnCaptureDesktop);
            this.Name = "ScreenshotCapturer";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnCaptureDesktop;
        private System.Windows.Forms.Button btnCapturePartDesktop;
        private System.Windows.Forms.Button btnDrawOnDesktop;
        private System.Windows.Forms.TextBox tbTestHooks;
    }
}

