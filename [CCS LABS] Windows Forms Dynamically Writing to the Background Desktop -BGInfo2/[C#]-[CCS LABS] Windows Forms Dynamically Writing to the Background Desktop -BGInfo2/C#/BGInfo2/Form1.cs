using System;
using System.Linq;
using System.Windows.Forms;
using System.ComponentModel;
using System.Runtime.InteropServices;
using System.Drawing;
using System.Diagnostics;

namespace BGInfo2
{
    public partial class Form1 : Form
    {
        delegate void SetTextCallback(string text, Control ctrl);

        BackgroundWorker bgw = new BackgroundWorker();
        Label lblUpTime;
        Label lblUsername;
        int rightMargin = 500;

        #region BottomMost
         [DllImport("user32.dll")]
        static extern bool SetWindowPos(IntPtr hWnd, IntPtr hWndInsertAfter, int X, int Y, int cx, int cy, uint uFlags);

        static readonly IntPtr HWND_BOTTOM = new IntPtr(1);
        const UInt32 SWP_NOSIZE = 0x0001;
        const UInt32 SWP_NOMOVE = 0x0002;
        const UInt32 SWP_NOACTIVATE = 0x0010;
        #endregion
       


        public TimeSpan UpTime
        {
            get
            {
                using (var uptime = new PerformanceCounter("System", "System Up Time"))
                {
                    uptime.NextValue();       //Call this an extra time before reading its value
                    return TimeSpan.FromSeconds(uptime.NextValue());
                }
            }
        }


        public Form1()
        {
            this.InitializeComponent();
            this.Visible = false;
            SetWindowPos(Handle, HWND_BOTTOM, 0, 0, 0, 0, SWP_NOMOVE | SWP_NOSIZE | SWP_NOACTIVATE); // Set Form1 as BottomMost
            AssignLabels();

            bgw.DoWork += new DoWorkEventHandler(BgwDoWork);
            bgw.RunWorkerAsync();

        }

        // What does the person want shown on the desktop?
        private void AssignLabels()
        {
           // Hard coded for demo
            lblUpTime = new Label();
            lblUpTime.Name = "Up Time";
            lblUpTime.ForeColor = Color.Yellow;
            lblUpTime.AutoSize = true;
            lblUpTime.Top = this.Top + 10;
            this.Controls.Add(lblUpTime);

            lblUsername = new Label();
            lblUsername.Name = "Username";
            lblUsername.ForeColor = Color.Yellow;
            lblUsername.AutoSize = true;
            lblUsername.Top = this.Top + 25;
            this.Controls.Add(lblUsername);
        
           
        }

        // How long has the computer been running?
        private string GetUpTime()
        {
            string days = UpTime.Days.ToString("N0"); // formatted like this 100,000 with no decimal places
            string hours = UpTime.Hours.ToString("00"); // Padded with 2 zeros so 2 hours will look like this 02
            string minutes = UpTime.Minutes.ToString("00");
            string secs = UpTime.Seconds.ToString("00");
           
            string res = "";
            if (UpTime.Days == 0) res = hours + ":" + minutes + ":" + secs; // If there are no days show this
            if (UpTime.Days == 1) res = days + " Day " + hours + ":" + minutes + ":" + secs; // If there is only 1 day show this
            if (String.IsNullOrEmpty(res)) res = days + " Days " + hours + ":" + minutes + ":" + secs; // In all other cases show this
            return res;
        }

        // Run the backgroundworker that updates the background information display
        void BgwDoWork(object sender, DoWorkEventArgs e)
        {
           
                
           
        }

        // Only required for cross-thread operations
        private void SetText(string text, Control ctrl)
        {
            // InvokeRequired required compares the thread ID of the 
            // calling thread to the thread ID of the creating thread. 
            // If these threads are different, it returns true. 
            if (ctrl.InvokeRequired)
            {
                SetTextCallback d = new SetTextCallback(SetText);
                this.Invoke(d, new object[] { text, ctrl });
            }
            else
            {
                ctrl.Text = text;
            }
        }

        private void TimerGuiTick(object sender, EventArgs e)
        {
            SetWindowPos(Handle, HWND_BOTTOM, 0, 0, 0, 0, SWP_NOMOVE | SWP_NOSIZE | SWP_NOACTIVATE); // Set Form1 as BottomMost
            lblUpTime.Left = this.Right - rightMargin;
            lblUpTime.Text = "Up Time: " + GetUpTime();

            lblUsername.Left = this.Right - rightMargin;
            lblUsername.Text = "Username: " + Environment.UserName;
            
            Application.DoEvents();
           
        }

    }
}