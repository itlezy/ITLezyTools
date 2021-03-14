using System;
using System.Collections.Generic;
using System.Configuration;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using System.Threading;

namespace ScreenLocker
{
    public partial class LockScreenForm : Form
    {
        /// <summary>
        /// Type chars buffer, to be compared with the password
        /// </summary>
        private String typedChars = "//////";

        /// <summary>
        /// The password to unlock the screen
        /// </summary>
        private readonly String unlockPassword = ConfigurationManager.AppSettings["unlockPassword"];

        /// <summary>
        /// Should turn the monitor off?
        /// </summary>
        private readonly bool turnOffMonitor = true;

        private readonly KeysConverter kc = new KeysConverter();

        /// <summary>
        /// Keyboard input count
        /// </summary>
        private int typedCount;

        /// <summary>
        /// Mouse movements count
        /// </summary>
        private long mouseMovementCount;

        /// <summary>
        /// Last mouse coords
        /// </summary>
        private int lastMouseX;
        private int lastMouseY;

        /// <summary>
        /// User input flag
        /// </summary>
        private bool userInput;

        /// <summary>
        /// Form's screen reference
        /// </summary>
        private Screen screen;

        private const int WM_SYSCOMMAND = 0x112;

        /// <seealso cref="http://msdn.microsoft.com/en-us/library/windows/desktop/ms646360%28v=vs.85%29.aspx"/>
        private const int SC_MONITORPOWER = 0xF170;

        [DllImport("user32.dll", CharSet = CharSet.Auto)]
        private static extern int SendMessage(IntPtr hWnd, int wMsg, IntPtr wParam, IntPtr lParam);

        [DllImport("user32.dll")]
        private static extern bool SetForegroundWindow(IntPtr hWnd);

        public LockScreenForm(Screen s)
        {
            InitializeComponent();

            this.screen = s;

            if (ConfigurationManager.AppSettings["turnOffMonitor"] != null)
            {
                bool _turnOffMonitor = true;
                if (Boolean.TryParse(ConfigurationManager.AppSettings["turnOffMonitor"], out _turnOffMonitor))
                {
                    turnOffMonitor = _turnOffMonitor;
                }
            }
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);

            this.Bounds = screen.Bounds;

            if (screen.Primary)
            {
                Cursor.Position = new Point(10, 10);
                Cursor.Hide();

                if (turnOffMonitor)
                {
                    TurnOffMonitor();
                }
            }
            else
            {
                timOnTop.Interval = timOnTop.Interval * 5;
            }

            lblInput.Text = 0.ToString("X4");
            lblMouseMove.Text = 0.ToString("X4");
        }

        /// <summary>
        /// Turn off the display(s)
        /// </summary>
        private void TurnOffMonitor()
        {
            SendMessage(
                this.Handle,
                WM_SYSCOMMAND,
                (IntPtr)SC_MONITORPOWER,
                /*
                -1 (the display is powering on)
                 1 (the display is going to low power)
                 2 (the display is being shut off)
                */
                (IntPtr)0x2);
        }

        protected override void OnClosing(System.ComponentModel.CancelEventArgs e)
        {
            e.Cancel = true;
        }

        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            // this.lblInput.Visible = this.lblMouseMove.Visible = true;

            if (Keys.Enter == keyData)
            {
                return true;
            }
            else
            {
                userInput = true;

                lblInput.Text = (++typedCount % 4096).ToString("X4");

                if (unlockPassword.Equals(typedChars, StringComparison.OrdinalIgnoreCase))
                {
                    Application.Exit();
                }
                else if (Keys.Escape == keyData)
                {
                    typedChars = String.Empty;

                    timOnTop.Stop();
                    timDelay.Stop();
                    timDelay.Start();
                }
                else
                {
                    typedChars += kc.ConvertToString(keyData);
                }

                return false;
            }
        }

        private void TimOnTopTick(object sender, EventArgs e)
        {
            if (userInput && screen.Primary && turnOffMonitor)
            {
                TurnOffMonitor();
            }

            StayOnTop();

            userInput = false;
            this.lblInput.Visible = this.lblMouseMove.Visible = false;
        }

        private void MainFormMouseMove(object sender, MouseEventArgs e)
        {
            // this.lblInput.Visible = this.lblMouseMove.Visible = true;

            // this.BackColor = Color.FromArgb((int)Math.Sin(e.X * e.Y) * 255, e.X % 255, e.Y % 255);

            if (lastMouseX != e.X || lastMouseY != e.Y)
            {
                userInput = true;
                lblMouseMove.Text = (mouseMovementCount++ % 4096).ToString("X4");
                lastMouseX = e.X;
                lastMouseY = e.Y;
            }
        }

        private void StayOnTop()
        {
            this.Activate();
            this.Focus();

            SetForegroundWindow(this.Handle);
            SendKeys.SendWait("{ENTER}");

            this.TopMost = false;
            this.TopMost = true;

            this.Activate();
            this.Focus();
        }

        private void timDelay_Tick(object sender, EventArgs e)
        {
            timOnTop.Start();
            timDelay.Stop();
        }


        private static Random random = new Random();

        int r = random.Next(0, 255);
        int g = random.Next(0, 255);
        int b = random.Next(0, 255);

        //class ColorIncr
        //{
        //    private static Random random = new Random();

        //    public ushort c = (ushort)random.Next(0, 255);
        //    private bool ShouldIncrease = true;

        //    public void Increase()
        //    {
        //        if (this.ShouldIncrease && c > 0 && c < 255)
        //        {
        //            this.ShouldIncrease = true;
        //        }

        //        else if (c > 0 && c >= 255)
        //        {
        //            this.ShouldIncrease = false;
        //        }

        //        else
        //        {
        //            c = 0;
        //            this.ShouldIncrease = true;
        //        }

        //        if (this.ShouldIncrease) { c++; } else { c--; }
        //    }
        //}

        private Color GetRandomColor()
        {
            return Color.FromArgb(random.Next(0, 255), random.Next(0, 255), random.Next(0, 255));

            // incr(ref r); incr(ref g); incr(ref b);

            // return Color.FromArgb(r, g, b);

            //return Color.FromArgb(
            //    (int)Math.Round((double)r++ / 256.0),
            //    (int)Math.Round((double)g++ / 256.0),
            //    (int)Math.Round((double)b++ / 256.0)
            //    );
        }

        private void incr(ref int c){
            c = (c + 1) % 255;
        }





        private void incr2(ref int c)
        {
            if (c > 0 && c < 255)
            {
                c++;
            }

            else if (c > 0 && c >= 255)
            {
                c--;
            }

            else
            {
                c = 0;
            }

            //c++;

            //if (!(c > 0 && c <= 255))
            //{
            //    c = 0;
            //}
        }


        private void timChangeColor_Tick(object sender, EventArgs e)
        {
            this.BackColor = GetRandomColor();
        }
    }
}
