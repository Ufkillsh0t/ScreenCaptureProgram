using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace ScreenCaptureProgram
{
    public partial class ScreenshotCapturer : Form
    {
        private Controller controller;

        public bool resizeChecked { get { return cbResize.Checked; } set { cbResize.Checked = value; } }

        public ScreenshotCapturer()
        {
            InitializeComponent();
            controller = new Controller(this);
            cbBringApplicationForward.Checked = controller.BringFormToFront;
            cbImageToClipBoard.Checked = controller.ImageToClipboard;
        }

        private void btnCaptureDesktop_Click(object sender, EventArgs e)
        {
            controller.CaptureDesktop();
        }

        private void btnCapturePartDesktop_Click(object sender, EventArgs e)
        {
            controller.KeyCapture = true;
        }

        private void btnSaveLatestImage_Click(object sender, EventArgs e)
        {
            controller.SaveFileDialog();
        }

        private void btnDrawOnDesktop_Click(object sender, EventArgs e)
        {
            Point pt = Cursor.Position;
            Graphics g = Graphics.FromHwnd(IntPtr.Zero);
            g.DrawEllipse(Pens.Black, pt.X - 10, pt.Y - 10, 20, 20);
        }

        public void SetImageBoxImage(Bitmap b)
        {
            pictureBoxCapturedImage.Image = b;
        }

        private void ScreenshotCapturer_SizeChanged(object sender, EventArgs e)
        {
            if (!resizeChecked)
            {
                ResizeForm();
            }
        }

        private void ScreenshotCapturer_ResizeEnd(object sender, EventArgs e)
        {
            if (resizeChecked)
            {
                ResizeForm();
            }
        }

        private void ResizeForm()
        {
            tabControl.Width = this.Width - (tabControl.Location.X * 4);
            tabControl.Height = this.Height - (tabControl.Location.Y * 6);
            if (tabControl.SelectedIndex == 0)
            {
                pictureBoxCapturedImage.Width = tabControl.Width - 10;
                pictureBoxCapturedImage.Height = tabControl.Height - pictureBoxCapturedImage.Location.Y - 20;
            }
        }

        private void tabControl_SelectedIndexChanged(object sender, EventArgs e)
        {
            ResizeForm();
        }

        private void btnSaveSettings_Click(object sender, EventArgs e)
        {
            string path = Application.StartupPath + "\\XML";
            if (Directory.Exists(path))
            {
                controller.SaveXML(path);
            }
            else
            {
                Directory.CreateDirectory(path);
                controller.SaveXML(path);
            }
        }

        private void cbImageToClipBoard_CheckedChanged(object sender, EventArgs e)
        {
            controller.ImageToClipboard = cbImageToClipBoard.Checked;
        }

        private void cbBringApplicationForward_CheckedChanged(object sender, EventArgs e)
        {
            controller.BringFormToFront = cbBringApplicationForward.Checked;
        }

        private void btnResetSettings_Click(object sender, EventArgs e)
        {
            controller.ResetSettings();
            cbAutoSave.Checked = controller.AutoSave;
            cbBringApplicationForward.Checked = controller.BringFormToFront;
            cbImageToClipBoard.Checked = controller.ImageToClipboard;
        }
    }
}
