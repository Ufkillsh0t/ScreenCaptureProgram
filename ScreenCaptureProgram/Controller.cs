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
        private bool imageToClipboard = true;
        public bool ImageToClipboard { get { return imageToClipboard; } set { imageToClipboard = value; } }

        private List<Screenshot> screenshots;

        public Controller()
        {
            screenshots = new List<Screenshot>();
        }

        public void CaptureDesktop()
        {
            Rectangle rect = Screen.GetBounds(Point.Empty);
            Bitmap image = new Bitmap(rect.Width, rect.Height);
            Graphics g = Graphics.FromImage(image);
            g.CopyFromScreen(Point.Empty, Point.Empty, rect.Size);
            screenshots.Add(new Screenshot(image, DateTime.Now));

            if (imageToClipboard)
                SetCapturedImageToClipboard(image);

            Console.Write(Cursor.Position);
        }

        public void CapturePartDesktop()
        {

        }

        public void SetCapturedImageToClipboard(Bitmap captured)
        {
            Clipboard.SetImage(captured);
        }
    }
}
