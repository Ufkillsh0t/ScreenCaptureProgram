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

            keyboardHook.KeyDown += KeyboardHook_KeyDown;
            mouseHook.LeftButtonDown += MouseHook_LeftButtonDown;

        }

        private void MouseHook_LeftButtonDown(MouseHook.MSLLHOOKSTRUCT mouseStruct)
        {
            tbTestHooks.Text += "MBUTTON_LEFT";
        }

        private void KeyboardHook_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Control || e.KeyCode == Keys.LControlKey || e.KeyCode == Keys.RControlKey)
            {
                tbTestHooks.Text += "Control";
            }
            else if (e.KeyCode == Keys.Alt || e.KeyCode == Keys.LMenu || e.KeyCode == Keys.RMenu)
            {
                tbTestHooks.Text += "Alt";
            }
            else if(e.KeyCode == Keys.D5)
            {
                tbTestHooks.Text += "|D5";
            }
            else
            {
                tbTestHooks.Text += e.KeyCode;
            }
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
