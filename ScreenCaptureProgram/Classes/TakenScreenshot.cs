using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ScreenCaptureProgram
{
    [Serializable]
    public class TakenScreenshot
    {
        private DateTime captureTime;
        private string path;

        public DateTime CaptureTime { get { return captureTime; } }
        public string Path { get { return path; } }

        public TakenScreenshot(string path, DateTime captureTime)
        {
            this.captureTime = captureTime;
            this.path = path;
        }

        public bool Save()
        {
            if (HasScreenshot())
            {
                SaveFileDialog sfd = new SaveFileDialog();
                sfd.Filter = "PNG file|*.png|JPeg Image|*.jpg|Bitmap Image|*.bmp|Gif Image|*.gif";
                sfd.Title = "Save captured image";
                if (sfd.ShowDialog() == DialogResult.OK && sfd.FileName != "")
                {
                    Image b = Bitmap.FromFile(path);
                    b.Save(sfd.FileName);
                }
                return true;
            }
            return false;
        }

        public Image GetScreenshot()
        {
            if (HasScreenshot())
            {
                return Bitmap.FromFile(path);
            }
            else
            {
                return null;
            }
        }

        public bool HasScreenshot()
        {
            if (File.Exists(path))
            {
                if (path.IndexOf(".png") >= 0 || path.IndexOf(".jpeg") >= 0 || path.IndexOf(".bmp") >= 0 || path.IndexOf(".gif") >= 0)
                    return true;
                else
                    return false;
            }
            else
            {
                return false;
            }
        }

        public override string ToString()
        {
            return captureTime.ToFileTime().ToString();
        }
    }
}
