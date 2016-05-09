using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
            return false;
        }

        public override string ToString()
        {
            return captureTime.ToFileTime().ToString();
        }
    }
}
