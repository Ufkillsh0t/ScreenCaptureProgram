using System;
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
        private KeyboardHook keyboardHook;
        private MouseHook mouseHook;


        public ScreenshotCapturer()
        {
            controller = new Controller();
            InitializeComponent();
            keyboardHook = new KeyboardHook();
            mouseHook = new MouseHook();
        }

        private void btnCaptureDesktop_Click(object sender, EventArgs e)
        {
            controller.CaptureDesktop();
        }

        private void btnCapturePartDesktop_Click(object sender, EventArgs e)
        {

        }

        private void btnDrawOnDesktop_Click(object sender, EventArgs e)
        {
            Point pt = Cursor.Position;
            Graphics g = Graphics.FromHwnd(IntPtr.Zero);
            g.DrawEllipse(Pens.Black, pt.X - 10, pt.Y - 10, 20, 20);
        }
    }
}
