using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ScreenCaptureProgram
{
    public class Key
    {
        public Keys KeyToPress { get; set; }
        public bool KeyPressed { get; set; }

        public Key(Keys key)
        {
            this.KeyToPress = key;
            this.KeyPressed = false;
        }
    }
}
