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
using System.Drawing.Drawing2D;
using System.Diagnostics;

namespace ScreenCaptureProgram
{
    public partial class ScreenshotCapturer : Form
    {
        private Controller controller;
        private int index;
        private Graphics dekstop;
        private GraphicsState state;

        public bool resizeChecked { get { return cbResize.Checked; } set { cbResize.Checked = value; } }

        public ScreenshotCapturer()
        {
            InitializeComponent();
            controller = new Controller(this);
            cbBringApplicationForward.Checked = controller.BringFormToFront;
            cbImageToClipBoard.Checked = controller.ImageToClipboard;
            cbAutoSave.Checked = controller.AutoSave;
            cbCache.Checked = controller.Caching;
            tbAutoSaveDirectory.Text = controller.AutoSavePath;
            index = controller.Screenshots.Count - 1;
            dekstop = Graphics.FromHwnd(IntPtr.Zero);
            state = dekstop.Save();
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
            controller.Save();
        }

        private void btnDrawOnDesktop_Click(object sender, EventArgs e)
        {
            Point pt = Cursor.Position;
            dekstop.DrawEllipse(Pens.Black, pt.X - 1000, pt.Y - 10, 300, 300);
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            Point pt = Cursor.Position;
            Graphics g = Graphics.FromHwnd(IntPtr.Zero);
            dekstop.Restore(state);
        }

        public void SetImageBoxImage(Bitmap b)
        {
            pbCapturedImage.Image = b;
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
            switch (tabControl.SelectedIndex)
            {
                case 0:
                    pbCapturedImage.Width = tabControl.Width - 10;
                    pbCapturedImage.Height = tabControl.Height - pbCapturedImage.Location.Y - 20;
                    break;
                case 1:
                    gbCachedImage.Width = tabControl.Width - 20;
                    gbCachedImage.Height = tabControl.Height - (gbCachedImage.Location.Y * 12);
                    pbCachedImage.Width = gbCachedImage.Width - 10;
                    pbCachedImage.Height = gbCachedImage.Height - gbCachedImage.Location.Y - (pbCachedImage.Location.Y * 2);
                    btnPrevious.Location = new Point(btnPrevious.Location.X, gbCachedImage.Location.Y + gbCachedImage.Height + 10);
                    btnNext.Location = new Point(btnNext.Location.X, gbCachedImage.Location.Y + gbCachedImage.Height + 10);
                    btnOpen.Location = new Point(btnOpen.Location.X, gbCachedImage.Location.Y + gbCachedImage.Height + 10);
                    btnOpenMap.Location = new Point(btnOpenMap.Location.X, gbCachedImage.Location.Y + gbCachedImage.Height + 10);
                    break;
                case 2:
                    gbSettings.Width = tabControl.Width - 20;
                    gbSettings.Height = tabControl.Height - 30;
                    gbAutoSave.Width = gbSettings.Width - (gbAutoSave.Location.X * 2);
                    gbFormSettings.Width = gbSettings.Width - (gbFormSettings.Location.X * 2);
                    btnAutoSavePath.Location = new Point(gbAutoSave.Width - btnAutoSavePath.Width - 10, btnAutoSavePath.Location.Y);
                    tbAutoSaveDirectory.Width = btnAutoSavePath.Location.X - tbAutoSaveDirectory.Location.X - 10;
                    break;
            }
        }

        private void tabControl_SelectedIndexChanged(object sender, EventArgs e)
        {
            ResizeForm();
            if (tabControl.SelectedIndex == 1)
            {
                if (pbCachedImage.Image == null)
                    SetImage();
            }
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

        private void cbAutoSave_CheckedChanged(object sender, EventArgs e)
        {
            controller.AutoSave = cbAutoSave.Checked;
        }

        private void btnAutoSavePath_Click(object sender, EventArgs e)
        {
            controller.SetAutoSavePath();
            tbAutoSaveDirectory.Text = controller.AutoSavePath;
        }

        private void cbCache_CheckedChanged(object sender, EventArgs e)
        {
            controller.Caching = cbCache.Checked;
        }

        private void btnPrevious_Click(object sender, EventArgs e)
        {
            index++;
            SetImage();
        }

        private void btnNext_Click(object sender, EventArgs e)
        {
            index--;
            SetImage();
        }

        private void SetImage()
        {
            if (index < controller.Screenshots.Count && index > 0)
            {
                SetImage(index);
            }
            else if (index < 0)
            {
                index = controller.Screenshots.Count - 1;
                SetImage(index);
            }
            else
            {
                index = 0;
                SetImage(index);
            }
        }

        private void SetImage(int index)
        {
            if (controller.Caching && controller.Screenshots.Count > 0)
            {
                pbCachedImage.Image = controller.Screenshots[index].GetScreenshot();
                gbCachedImage.Text = controller.Screenshots[index].Path.Substring(
                                    (controller.Screenshots[index].Path.LastIndexOf("\\") + 1),
                                    (controller.Screenshots[index].Path.Length - controller.Screenshots[index].Path.LastIndexOf("\\") - 1));
            }
            else if (controller.Screenshots.Count > 0)
            {
                pbCachedImage.Image = controller.Screenshots[index].GetScreenshot();
                gbCachedImage.Text = controller.Screenshots[index].Path.Substring(
                                    (controller.Screenshots[index].Path.LastIndexOf("\\") + 1),
                                    (controller.Screenshots[index].Path.Length - controller.Screenshots[index].Path.LastIndexOf("\\") - 1));
            }
            else
            {
                gbCachedImage.Text = "Enable caching and/or capture and save some screenshots to view your cached screenshots";
            }
        }

        private void btnOpen_Click(object sender, EventArgs e)
        {
            if(controller.Screenshots.Count > 0)
                Process.Start(@controller.Screenshots[index].Path);
        }

        private void btnOpenMap_Click(object sender, EventArgs e)
        {
            if (controller.Screenshots.Count > 0)
                Process.Start(@controller.Screenshots[index].Path.Substring(
                                    0,
                                    controller.Screenshots[index].Path.LastIndexOf("\\") + 1));
        }
    }
}
