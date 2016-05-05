using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ScreenCaptureProgram
{
    public class Controller
    {
        //Form
        private ScreenshotCapturer sc;

        private KeyboardHook keyboardHook;
        private MouseHook mouseHook;

        private bool imageToClipboard = true;
        private bool bringFormToFront = false;
        private bool keyCapture = false;
        private bool capturing = false;
        private bool cancelled = false;

        public bool ImageToClipboard { get { return imageToClipboard; } set { imageToClipboard = value; } }

        private bool testPress = false;

        //Capture points.
        public Point startPoint;
        public Point endPoint;

        private List<Screenshot> screenshots;

        public Controller(ScreenshotCapturer sc)
        {
            screenshots = new List<Screenshot>();

            keyboardHook = new KeyboardHook();
            mouseHook = new MouseHook();

            keyboardHook.KeyDown += KeyboardHook_KeyDown;

            //Muis omlaag
            mouseHook.LeftButtonDown += MouseHook_LeftButtonDown;
            mouseHook.RightButtonDown += MouseHook_RightButtonDown;

            //Muis omhoog
            mouseHook.LeftButtonUp += MouseHook_LeftButtonUp;
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
        }

        /// <summary>
        /// Captures the desktop.
        /// </summary>
        public void CaptureDesktop()
        {
            Rectangle rect = Screen.GetBounds(Point.Empty);
            Bitmap image = new Bitmap(rect.Width, rect.Height);
            Graphics g = Graphics.FromImage(image);
            g.CopyFromScreen(Point.Empty, Point.Empty, rect.Size);
            screenshots.Add(new Screenshot(image, DateTime.Now));

            if (imageToClipboard)
                SetCapturedImageToClipboard(image);

            if (bringFormToFront)
                sc.BringToFront();
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
            screenshots.Add(new Screenshot(image, DateTime.Now));

            if (imageToClipboard)
                SetCapturedImageToClipboard(image);

            if (bringFormToFront)
                sc.BringToFront();
        }

        /// <summary>
        /// Copies the captured bitmap to your clipboard.
        /// </summary>
        /// <param name="captured"></param>
        public void SetCapturedImageToClipboard(Bitmap captured)
        {
            Clipboard.SetImage(captured);
        }
    }
}
