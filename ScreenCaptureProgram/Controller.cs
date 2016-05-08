using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;
using System.Xml.Linq;
using System.IO;

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
        private bool autoSave = false;

        //capture booleans
        private bool keyCapture = false;
        private bool capturing = false;
        private bool cancelled = false;

        public bool ImageToClipboard { get { return imageToClipboard; } set { imageToClipboard = value; } }
        public bool BringFormToFront { get { return bringFormToFront; } set { bringFormToFront = value; } }
        public bool KeyCapture { get { return keyCapture; } set { keyCapture = value; } }
        public bool AutoSave { get { return autoSave; } set { autoSave = value; } }

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

            //AddKeyBindings();
            GetSettings();
        }

        #region XMLSettings

        public void ResetSettings()
        {
            string path = Application.StartupPath + "\\XML";
            if (Directory.Exists(path))
            {
                NewSettingsXMLFile(path);
                ReadXml(path + "\\Settings.xml");
            }
            else
            {
                Directory.CreateDirectory(path);
                NewSettingsXMLFile(path);
                ReadXml(path + "\\Settings.xml");
            }
        }

        private void GetSettings()
        {
            string path = Application.StartupPath + "\\XML";
            if (Directory.Exists(path))
            {
                if (File.Exists(path + "\\Settings.xml"))
                {
                    ReadXml(path + "\\Settings.xml");
                }
                else
                {
                    NewSettingsXMLFile(path);
                    ReadXml(path + "\\Settings.xml");
                }
            }
            else
            {
                Directory.CreateDirectory(Application.StartupPath + "\\XML");
                if (Directory.Exists(path))
                {
                    NewSettingsXMLFile(path);
                    ReadXml(path + "\\Settings.xml");
                }
            }
            //doc.Load(Application.StartupPath)
        }

        private void NewSettingsXMLFile(string path)
        {
            XDocument doc = new XDocument(new XElement("Settings",
                                            new XElement("ImageToClipBoard", true),
                                            new XElement("BringApplicationForward", true),
                                            new XElement("ResizeFormInstant", false),
                                            new XElement("AutoSave", false),
                                            new XElement("KeyBindings",
                                                new XElement("KeyBind",
                                                    new XElement("ID", 1),
                                                    new XElement("Keys",
                                                        new XElement("Key", (int)Keys.Control),
                                                        new XElement("Key", (int)Keys.Alt),
                                                        new XElement("Key", (int)Keys.D5))),
                                                new XElement("KeyBind",
                                                    new XElement("ID", 2),
                                                    new XElement("Keys",
                                                        new XElement("Key", (int)Keys.Control),
                                                        new XElement("Key", (int)Keys.Alt),
                                                        new XElement("Key", (int)Keys.D6))))));
            doc.Save(path + "\\Settings.xml");
        }

        public void SaveXML(string path)
        {
            XDocument doc = new XDocument(new XElement("Settings",
                                new XElement("ImageToClipBoard", imageToClipboard),
                                new XElement("BringApplicationForward", bringFormToFront),
                                new XElement("ResizeFormInstant", sc.resizeChecked),
                                new XElement("AutoSave", autoSave),
                                GetKeyBindingElements()));
            doc.Save(path + "\\Settings.xml");
        }

        private XElement GetKeyBindingElements()
        {
            XElement keyBinding = new XElement("KeyBindings");
            foreach (KeyBinding kb in keyBindings)
            {
                keyBinding.Add(new XElement("KeyBind",
                                   new XElement("ID", kb.ID),
                                   GetKeyBindingKeysElement(kb)));
            }
            return keyBinding;
        }

        private XElement GetKeyBindingKeysElement(KeyBinding kb)
        {
            XElement keys = new XElement("Keys");
            foreach (Key k in kb.BindingKeys)
            {
                keys.Add(new XElement("Key", (int)k.KeyToPress));
            }
            return keys;
        }

        private void ReadXml(string path)
        {
            XmlDocument doc = new XmlDocument();
            doc.Load(path);
            XmlNode n = doc.SelectSingleNode("Settings");
            XmlNodeList nodes = n.ChildNodes;
            foreach (XmlNode node in nodes)
            {
                if (node.Name == "ImageToClipBoard")
                    imageToClipboard = Convert.ToBoolean(node.InnerText);
                if (node.Name == "BringApplicationForward")
                    bringFormToFront = Convert.ToBoolean(node.InnerText);
                if (node.Name == "AutoSave")
                    autoSave = Convert.ToBoolean(node.InnerText);
                if (node.Name == "ResizeFormInstant")
                {
                    bool value = Convert.ToBoolean(node.InnerText);
                    if (sc.resizeChecked != value)
                        sc.resizeChecked = value;
                }
                if (node.Name == "KeyBindings")
                {
                    XmlNodeList keybindingsXML = node.ChildNodes;
                    keyBindings = new List<KeyBinding>();
                    foreach (XmlNode k in keybindingsXML)
                    {
                        XmlNode keyBindID = k.SelectSingleNode("ID");
                        int id = Convert.ToInt32(keyBindID.InnerText);

                        KeyBinding kb = new KeyBinding(id);

                        XmlNode keyBinds = k.SelectSingleNode("Keys");
                        XmlNodeList keys = keyBinds.SelectNodes("Key");
                        foreach (XmlNode key in keys)
                        {
                            kb.AddKey((Keys)Convert.ToInt32(key.InnerText));
                        }
                        keyBindings.Add(kb);
                    }
                }
            }
        }

        #endregion

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
            foreach (KeyBinding kb in keyBindings)
            {
                if (kb.CheckBinding(e.KeyCode))
                {
                    ExecuteCommands(kb.ID);
                }
            }
        }

        /// <summary>
        /// Executes a certain command/function
        /// </summary>
        /// <param name="id"></param>
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

/*
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
}*/
