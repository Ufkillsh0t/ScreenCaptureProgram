using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ScreenCaptureProgram
{
    public class Screenshot
    {
        private DateTime captureTime;
        private Bitmap bitmap;

        public DateTime CaptureTime { get { return captureTime; } }
        public Bitmap Bitmap { get { return bitmap; } }

        public Screenshot(Bitmap bitmap, DateTime captureTime)
        {
            this.captureTime = captureTime;
            this.bitmap = bitmap;
        }

        public bool Save()
        {
            if (Bitmap != null)
            {
                SaveFileDialog sfd = new SaveFileDialog();
                sfd.Filter = "PNG file|*.png|JPeg Image|*.jpg|Bitmap Image|*.bmp|Gif Image|*.gif";
                sfd.Title = "Save captured image";
                if (sfd.ShowDialog() == DialogResult.OK && sfd.FileName != "")
                {
                    Bitmap.Save(sfd.FileName);
                }
                return true;
            }
            return false;
        }

        public override string ToString()
        {
            return captureTime.ToFileTime().ToString();
        }
    }
}
