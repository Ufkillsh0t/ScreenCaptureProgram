using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ScreenCaptureProgram
{
    public class Controller
    {
        [DllImport("User32.dll")]
        public static extern Int32 SetForegroundWindow(int hWnd);

        //Form
        private ScreenshotCapturer sc;

        private KeyboardHook keyboardHook;
        private MouseHook mouseHook;

        private bool imageToClipboard = true;
        private bool bringFormToFront = true;
        private bool keyCapture = false;
        private bool capturing = false;
        private bool cancelled = false;

        public bool ImageToClipboard { get { return imageToClipboard; } set { imageToClipboard = value; } }
        public bool KeyCapture { get { return keyCapture; } set { keyCapture = value; } }

        private bool testPress = false;

        //Capture points.
        public Point startPoint;
        public Point endPoint;

        //Keybindings
        private List<KeyBinding> keyBindings;

        //Screenshots
        private List<Screenshot> screenshots;
        private Screenshot latestCapturedScreenshot;

        public Controller(ScreenshotCapturer sc)
        {
            screenshots = new List<Screenshot>();
            this.sc = sc;

            keyboardHook = new KeyboardHook();
            mouseHook = new MouseHook();

            keyboardHook.KeyDown += KeyboardHook_KeyDown;

            //Muis omlaag
            mouseHook.LeftButtonDown += MouseHook_LeftButtonDown;
            mouseHook.RightButtonDown += MouseHook_RightButtonDown;

            //Muis omhoog
            mouseHook.LeftButtonUp += MouseHook_LeftButtonUp;

            AddKeyBindings();
        }

        private void AddKeyBindings()
        {
            //Capture part dekstop keybinding
            KeyBinding kb = new KeyBinding(1);
            kb.AddKey(Keys.Control);
            kb.AddKey(Keys.Alt);
            kb.AddKey(Keys.D5);

            //Capture dekstop keybinding (Primary Screen)
            KeyBinding kb2 = new KeyBinding(2);
            kb2.AddKey(Keys.Control);
            kb2.AddKey(Keys.Alt);
            kb2.AddKey(Keys.D6);

            keyBindings = new List<KeyBinding>();
            keyBindings.Add(kb);
            keyBindings.Add(kb2);
        }

        private void MouseHook_LeftButtonUp(MouseHook.MSLLHOOKSTRUCT mouseStruct)
        {
            if (capturing && cancelled)
            {
                capturing = false;
                cancelled = false;
            }
        }

        private void MouseHook_RightButtonDown(MouseHook.MSLLHOOKSTRUCT mouseStruct)
        {
            if (capturing)
            {
                capturing = false;
                cancelled = true;
            }
            else if (keyCapture)
            {
                keyCapture = false;
            }
        }

        private void MouseHook_LeftButtonDown(MouseHook.MSLLHOOKSTRUCT mouseStruct)
        {
            if (keyCapture)
            {
                Console.WriteLine("Capturing {X=" + mouseStruct.pt.x + ",Y=" + mouseStruct.pt.y + "}");
                startPoint = new Point(mouseStruct.pt.x, mouseStruct.pt.y);
                capturing = true;
                keyCapture = false;
            }
            else if (capturing)
            {
                //draw on screen...
                if (!cancelled)
                {
                    endPoint = new Point(mouseStruct.pt.x, mouseStruct.pt.y);
                    Console.WriteLine("EndCapture {X=" + mouseStruct.pt.x + ",Y=" + mouseStruct.pt.y + "}");
                    CapturePartDesktop(startPoint, endPoint);
                    capturing = false;
                }
            }
        }


        private void KeyboardHook_KeyDown(object sender, KeyEventArgs e)
        {
            foreach(KeyBinding kb in keyBindings)
            {
                if (kb.CheckBinding(e.KeyCode))
                {
                    ExecuteCommands(kb.ID);
                }
            }
        }


        private void ExecuteCommands(int id)
        {
            switch (id)
            {
                case 1:
                    keyCapture = true;
                    Console.WriteLine("Capture Part Dekstop");
                    break;
                case 2:
                    CaptureDesktop();
                    Console.WriteLine("Capture Dekstop");
                    break;
            }
        }
        /*

                        if (e.KeyCode == Keys.Control || e.KeyCode == Keys.LControlKey || e.KeyCode == Keys.RControlKey)
            {
                Console.WriteLine("Pressed control");
                testPress = true;
            }
            else if (e.KeyCode == Keys.Alt || e.KeyCode == Keys.LMenu || e.KeyCode == Keys.RMenu)
            {
                Console.WriteLine("Pressed alt");
                testPress = true;

            }
            else if (e.KeyCode == Keys.D5)
            {
                Console.WriteLine("Pressed 5");
                if (testPress && !capturing)
                {
                    Console.WriteLine("keyCapture enabled");
                    keyCapture = true;
                }
            }
            else
            {
                testPress = false;
            }


    */

        /// <summary>
        /// Captures the desktop.
        /// </summary>
        public void CaptureDesktop()
        {
            Rectangle rect = Screen.GetBounds(Point.Empty);
            Bitmap image = new Bitmap(rect.Width, rect.Height);
            Graphics g = Graphics.FromImage(image);
            g.CopyFromScreen(Point.Empty, Point.Empty, rect.Size);
            latestCapturedScreenshot = new Screenshot(image, DateTime.Now);
            screenshots.Add(latestCapturedScreenshot);
            CapturedImage(image);
        }

        /// <summary>
        /// Overload for the function with a rectangle paramater, this function decides the rectangle of the screenshot.
        /// </summary>
        /// <param name="startPoint">Starting point for the image</param>
        /// <param name="endPoint">End point for the image</param>
        public void CapturePartDesktop(Point startPoint, Point endPoint)
        {
            Rectangle rect;
            if (startPoint.X < endPoint.X)
            {
                if (startPoint.Y < endPoint.Y)
                {
                    rect = new Rectangle(startPoint.X, startPoint.Y, (endPoint.X - startPoint.X), (endPoint.Y - startPoint.Y));
                    CapturePartDesktop(rect);
                }
                else if (endPoint.Y < startPoint.Y)
                {
                    rect = new Rectangle(startPoint.X, endPoint.Y, (endPoint.X - startPoint.X), (startPoint.Y - endPoint.Y));
                    CapturePartDesktop(rect);
                }
                else
                {
                    Console.WriteLine("Can't take a image with no height");
                }
            }
            else if (endPoint.X < startPoint.X)
            {
                if (startPoint.Y < endPoint.Y)
                {
                    rect = new Rectangle(endPoint.X, startPoint.Y, (startPoint.X - endPoint.X), (endPoint.Y - startPoint.Y));
                    CapturePartDesktop(rect);
                }
                else if (endPoint.Y < startPoint.Y)
                {
                    rect = new Rectangle(endPoint.X, endPoint.Y, (startPoint.X - endPoint.X), (startPoint.Y - endPoint.Y));
                    CapturePartDesktop(rect);
                }
                else
                {
                    Console.WriteLine("Can't take a image with no height");
                }
            }
            else
            {
                Console.WriteLine("Can't take a image with no width!");
            }
        }

        /// <summary>
        /// Captures a part of the desktop based on the given rectangle.
        /// </summary>
        /// <param name="rect"></param>
        public void CapturePartDesktop(Rectangle rect)
        {
            Bitmap image = new Bitmap(rect.Width, rect.Height);
            Graphics g = Graphics.FromImage(image);
            g.CopyFromScreen(rect.Left, rect.Top, 0, 0, rect.Size);
            latestCapturedScreenshot = new Screenshot(image, DateTime.Now);
            screenshots.Add(latestCapturedScreenshot);
            CapturedImage(image);
        }

        private void CapturedImage(Bitmap image)
        {
            if (imageToClipboard)
                SetCapturedImageToClipboard(image);
            if (bringFormToFront)
                SetForegroundWindow(sc.Handle.ToInt32());

            sc.SetImageBoxImage(image);
        }

        /// <summary>
        /// Copies the captured bitmap to your clipboard.
        /// </summary>
        /// <param name="captured"></param>
        public void SetCapturedImageToClipboard(Bitmap captured)
        {
            Clipboard.SetImage(captured);
        }

        /// <summary>
        /// Saves the screenshot that was captured the latest.
        /// </summary>
        /// <returns>if it has been saved succesfully</returns>
        public bool SaveFileDialog()
        {
            if (latestCapturedScreenshot != null && latestCapturedScreenshot.Bitmap != null)
            {
                SaveFileDialog sfd = new SaveFileDialog();
                sfd.Filter = ".png file|*.png|JPeg Image|*.jpg|Bitmap Image|*.bmp|Gif Image|*.gif";
                sfd.Title = "Save captured image";
                if (sfd.ShowDialog() == DialogResult.OK && sfd.FileName != "")
                {
                    latestCapturedScreenshot.Bitmap.Save(sfd.FileName);
                }
                return true;
            }
            return false;
        }

        public bool SaveFileDialog(Screenshot s)
        {
            if (s != null && s.Bitmap != null)
            {
                SaveFileDialog sfd = new SaveFileDialog();
                sfd.Filter = ".png file|*.png|JPeg Image|*.jpg|Bitmap Image|*.bmp|Gif Image|*.gif";
                sfd.Title = "Save captured image";
                if (sfd.ShowDialog() == DialogResult.OK && sfd.FileName != "")
                {
                    s.Bitmap.Save(sfd.FileName);
                }
                return true;
            }
            return false;
        }
    }
}
