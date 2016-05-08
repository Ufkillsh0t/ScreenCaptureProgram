using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ScreenCaptureProgram
{
    public class KeyBinding
    {
        private int id;
        public int ID { get { return id; } }
        public List<Key> BindingKeys { get; set; }

        public KeyBinding(int id)
        {
            this.id = id;
            BindingKeys = new List<Key>();
        }

        public bool CheckBinding(Keys pressedKey)
        {
            if (BindingKeys.Count != 0)
            {
                Keys keyToCheck = CheckKeys(pressedKey);

                bool allKeysPressed = true;
                bool pressedKeyInBinding = false;
                foreach (Key k in BindingKeys)
                {
                    if (k.KeyToPress == keyToCheck)
                    {
                        pressedKeyInBinding = true;
                        k.KeyPressed = true;
                    }

                    if (!k.KeyPressed)
                    {
                        allKeysPressed = false;
                    }
                }

                if (!pressedKeyInBinding)
                {
                    SetKeyPressesToFalse();
                }

                if (allKeysPressed)
                {
                    SetKeyPressesToFalse();
                    return true;
                }
                return false;
            }
            return false;
        }

        private void SetKeyPressesToFalse()
        {
            foreach (Key k in BindingKeys)
            {
                k.KeyPressed = false;
            }
        }

        private Keys CheckKeys(Keys pressedKey)
        {
            Keys keyToCheck;
            if (pressedKey == Keys.Control || pressedKey == Keys.LControlKey || pressedKey == Keys.RControlKey)
            {
                keyToCheck = Keys.Control;
            }
            else if (pressedKey == Keys.Alt || pressedKey == Keys.LMenu || pressedKey == Keys.RMenu)
            {
                keyToCheck = Keys.Alt;
            }
            else
            {
                keyToCheck = pressedKey;
            }
            return keyToCheck;
        }

        public void AddKey(Keys key)
        {
            if (key == Keys.Control || key == Keys.LControlKey || key == Keys.RControlKey)
            {
                BindingKeys.Add(new Key(Keys.Control));
            }
            else if (key == Keys.Alt || key == Keys.LMenu || key == Keys.RMenu)
            {
                BindingKeys.Add(new Key(Keys.Alt));
            }
            else
            {
                BindingKeys.Add(new Key(key));
            }
        }
    }
}
