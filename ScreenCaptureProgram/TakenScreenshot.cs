using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
            return false;
        }

        public override string ToString()
        {
            return captureTime.ToFileTime().ToString();
        }
    }
}
