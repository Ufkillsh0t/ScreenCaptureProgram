﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ScreenCaptureProgram
{
    public partial class ScreenshotCapturer : Form
    {
        private Controller controller;

        public bool resizeChecked { get { return cbResize.Checked; } set { resizeChecked = value; } }

        public ScreenshotCapturer()
        {
            InitializeComponent();
            controller = new Controller(this);
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
    }
}
