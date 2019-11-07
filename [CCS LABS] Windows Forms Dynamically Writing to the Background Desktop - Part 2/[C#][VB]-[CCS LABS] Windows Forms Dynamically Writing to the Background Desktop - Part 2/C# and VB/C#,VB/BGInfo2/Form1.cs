using System;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.ComponentModel;
using System.Runtime.InteropServices;
using System.Drawing;
using System.Diagnostics;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Net.NetworkInformation;
using System.Collections.Generic;
using System.IO;
using HDControl;

namespace BGInfo2
{
    public partial class Form1 : Form
    {
        SortedDictionary<int, float> dictionaryProcess = new SortedDictionary<int, float>();
        List<DriveInfo> listDriveInfo = new List<DriveInfo>();
        private double idleSeconds = 0;
        private bool iAmIdle = true;
        Process proc = new Process();
        private Task taskA = null;

        #region BottomMost
        [DllImport("user32.dll")]
        static extern bool SetWindowPos(IntPtr hWnd, IntPtr hWndInsertAfter, int X, int Y, int cx, int cy, uint uFlags);

        static readonly IntPtr HWND_BOTTOM = new IntPtr(1);
        const UInt32 SWP_NOSIZE = 0x0001;
        const UInt32 SWP_NOMOVE = 0x0002;
        const UInt32 SWP_NOACTIVATE = 0x0010;
        #endregion

        #region Times

        private TimeSpan UpTime
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

        // How long has the computer been running?
        private string GetUpTime()
        {
            string days = UpTime.Days.ToString("N0"); // formatted like this 100,000 with no decimal places
            string hours = UpTime.Hours.ToString("00"); // Padded with 2 zeros so 2 hours will look like this 02
            string minutes = UpTime.Minutes.ToString("00");
            string secs = UpTime.Seconds.ToString("00");

            string res = "";
            if (UpTime.Days == 0)
                res = hours + ":" + minutes + ":" + secs; // If there are no days show this
            if (UpTime.Days == 1)
                res = days + " Day " + hours + ":" + minutes + ":" + secs; // If there is only 1 day show this
            if (String.IsNullOrEmpty(res))
                res = days + " Days " + hours + ":" + minutes + ":" + secs; // In all other cases show this
            return res;
        }

        private TimeSpan IdleTime()
        {
            return TimeSpan.FromSeconds(idleSeconds);
        }

        private string GetIdleTime()
        {
            string days = IdleTime().Days.ToString("N0"); // formatted like this 100,000 with no decimal places
            string hours = IdleTime().Hours.ToString("00"); // Padded with 2 zeros so 2 hours will look like this 02
            string minutes = IdleTime().Minutes.ToString("00");
            string secs = IdleTime().Seconds.ToString("00");

            string res = "";
            if (IdleTime().Days == 0)
                res = hours + ":" + minutes + ":" + secs; // If there are no days show this
            if (IdleTime().Days == 1)
                res = days + " Day " + hours + ":" + minutes + ":" + secs; // If there is only 1 day show this
            if (String.IsNullOrEmpty(res))
                res = days + " Days " + hours + ":" + minutes + ":" + secs; // In all other cases show this
            return res;
        }

        #endregion

        #region Networking

        private string GetLocalIPAddress()
        {
            IPHostEntry host;
            string localIP = "";
            host = Dns.GetHostEntry(Dns.GetHostName());
            foreach (IPAddress ip in host.AddressList)
            {
                if (ip.AddressFamily == AddressFamily.InterNetwork)
                {
                    localIP = ip.ToString();
                }
            }
            return localIP;
        }

        private string GetExternalIPAddress()
        {
            UTF8Encoding utf8 = new UTF8Encoding();
            WebClient webClient = new WebClient();
            String externalIp = utf8.GetString(webClient.DownloadData("http://checkip.dyndns.org"));
            // <html><head><title>Current IP Check</title></head><body>Current IP Address: 92.19.223.72</body></html>
            externalIp = externalIp.Replace("<html><head><title>Current IP Check</title></head><body>Current IP Address:", "");
            externalIp = externalIp.Replace("</body></html>", "");
            return externalIp.ToString().Trim();
        }

        private string GetDefaultGatewayIP()
        {
            var card = NetworkInterface.GetAllNetworkInterfaces().FirstOrDefault();
            if (card == null)
                return "Not Known";
            var address = card.GetIPProperties().GatewayAddresses.FirstOrDefault();
            return address.Address.ToString();
        }

        #endregion

        #region Memory

        // Shows how much memory the computer has installed.
        private ulong GetTotalMemory()
        {
            return new Microsoft.VisualBasic.Devices.ComputerInfo().TotalPhysicalMemory;

        }

        // Shows How much memory the computer currently has available
        private ulong GetCurrentMemory()
        {
            return new Microsoft.VisualBasic.Devices.ComputerInfo().AvailablePhysicalMemory;
        }

        #endregion

        #region Drives

        // Get a list of logical drives and their associated Info
        private void GetDrives()
        {
            int driveCounter = 0;
            foreach (string drive in Environment.GetLogicalDrives())
            {
                DriveInfo dinfo = new DriveInfo(drive);
                if (dinfo.IsReady == true)
                {
                   HDControl.HDControl hdc = new HDControl.HDControl();
                    hdc.Name = driveCounter.ToString(); // ensures a simple but unique name for each drive
                    flpDiskStatus.Controls.Add(hdc);
                    hdc.Start(dinfo.Name);
                    driveCounter++;
                }
            }

        }

        #endregion

        #region MouseXY

        private void MouseKeyEventsMouseMoveExt(object sender, MouseKeyboardActivityMonitor.MouseEventExtArgs e)
        {
            Active();

            int mouseX = e.X;
            int mouseY = e.Y;

            lblMouseXY.Text = mouseX.ToString("0000") + ":" + mouseY.ToString("0000");
            Inactive();
        }



        #endregion

        #region Activity

        private void Active()
        {
            iAmIdle = false;
        }


        private void Inactive()
        {
            iAmIdle = true;
            idleSeconds = -1;
        }

        private void MouseKeyEventsKeyPress(object sender, KeyPressEventArgs e)
        {
            Active();

            Inactive();
        }

        private void MouseKeyEventsMouseClick(object sender, MouseEventArgs e)
        {
            Active();
            Inactive();
        }

        private void MouseKeyEventsMouseWheel(object sender, MouseEventArgs e)
        {
            Active();
            Inactive();
        }


        #endregion

        #region TopProcesses

        private void TopProcesses()
        {
            OrganiseProcesses(GetAllProcesses());
        }

        private void OrganiseProcesses(List<Process> procList)
        {
            // Use Process ID (PID) as Unique IDX and CPU Usage Percent as Value
            // Recreate the Dictionary each time
            dictionaryProcess.Clear();

            foreach (Process p in procList)
            {
                try
                {
                    var counter = new PerformanceCounter("Process", "% Processor Time", p.ProcessName, true);
                    counter.NextValue();

                    System.Threading.Thread.Sleep(1000);
                    float cpu = counter.NextValue();

                    if (cpu > 0)
                    {
                        dictionaryProcess.Add(p.Id, cpu); // Only add processes that are actually using CPU resources
                        if (dictionaryProcess.Count > 0)
                        {

                        }
                    }
                }
                catch (Exception ex)
                {
                    // Ignore - process has been removed from the list
                    //    Despatcher.Invoke      rtbConOut.Text = ex.Message + Environment.NewLine;
                    //           rtbConOut.Refresh();
                }
            }
        }

        private List<Process> GetAllProcesses()
        {
            List<Process> procList = new List<Process>();
            Process[] procs = Process.GetProcesses(); // GC will clean this up later.
            foreach (Process p in procs)
            {
                procList.Add(p);
            }
            return procList;
        }

        #endregion


        public Form1()
        {
            this.InitializeComponent();


            SetWindowPos(Handle, HWND_BOTTOM, 0, 0, 0, 0, SWP_NOMOVE | SWP_NOSIZE | SWP_NOACTIVATE); // Set Form1 as BottomMost

            this.Visible = false;
            timerGUI.Enabled = true;
            timerGUI.Tick += TimerGuiTick;
            lblDefaultGateway.Text = GetDefaultGatewayIP();
            lblExternalIPAddress.Text = GetExternalIPAddress();
            lblInternalIPAddress.Text = GetLocalIPAddress();
            lblTotalMemory.Text = ConvertBytesToMegabytes(GetTotalMemory());
            GetDrives();
        }

        void TimerGuiTick(object sender, EventArgs e)
        {
            SetWindowPos(Handle, HWND_BOTTOM, 0, 0, 0, 0, SWP_NOMOVE | SWP_NOSIZE | SWP_NOACTIVATE); // Set Form1 as BottomMost
            if (iAmIdle)
            {
                idleSeconds++;
            }

            lblUpTime.Text = GetUpTime();
            lblIdleTime.Text = GetIdleTime();
            lblFreeMemory.Text = ConvertBytesToMegabytes(GetCurrentMemory());

            lblInternalIPAddress.Text = GetLocalIPAddress();

        }

        #region Formatting Helpers

        private string ConvertBytesToMegabytes(ulong bytes)
        {
            return ((bytes / 1024f) / 1024f).ToString("N") + " MB";
        }


        #endregion

        private void TimerFiveSecondsTick(object sender, EventArgs e)
        {

        }


    }
}