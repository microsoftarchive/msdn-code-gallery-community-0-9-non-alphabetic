using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Management;

namespace HDControl
{
    public partial class HDControl : UserControl
    {
        private double MaxRead = 0;
        private double MaxWrite = 0;

        private bool enable;

        public bool Enable
        {
            get
            {
                return this.enable;
            }
            set
            {
                this.enable = value;
                Start();
            }
        }

        private string driveName;

        public string DriveName
        {
            get
            {
                return this.driveName;
            }
            set
            {
                this.driveName = value;
            }
        }




        public enum DiskStatusImage
        {
            InActive,
            Read,
            Write
        }; // this is the order of the ImageList we use



        public HDControl()
        {
            InitializeComponent();
        }

        // Start the Control monitoring the supplied Drive name
        public void Start(string drivename)
        {
            lbDriveName.Text = drivename; // This control monitors this drive
            rptTimer.Enabled = true;        // Start the update timer
            fastTimer.Enabled = true;   // For Drives
        }

        // Start the Control monitoring the supplied Drive name
        public void Start()
        {
            if (!string.IsNullOrEmpty(DriveName))
            {
                lbDriveName.Text = DriveName; // This control monitors this drive
                rptTimer.Enabled = true;        // Start the update timer
                fastTimer.Enabled = true;   // For Drives
            }
            else
            {
                enable = false;
            }
        }

        // Stop the control when no longer needed - like shutting down or rebooting or whatever
        public void Stop()
        {
            rptTimer.Enabled = false;
            fastTimer.Enabled = false;   // For Drives
            try
            {
                this.Dispose();
            }
            catch (Exception)
            {
                // We should manage this exception so we ensure the release of resources
                // Although the GC will catch up.
            }
        }

        // Ticks every second for an update
        private void RptTimerTick(object sender, EventArgs e)
        {
            progressFreeSpace.Value = 100 - GetFreeSpace(lbDriveName.Text.Trim('\\')); // Set the free space bar.
           
            this.Refresh();
        }


        /// <summary>
        /// Gets the free space for the specified drive as a percentage
        /// </summary>
        /// <param name="drivename">
        /// The drive to get free space of
        /// </param>
        /// <returns>
        /// int: The Free space of the drive if no error is found
        /// int: 100 if the drive is not used or there has been an error
        /// </returns>
        private int GetFreeSpace(string drivename)
        {
            try
            {
                ManagementObjectSearcher searcher =
                    new ManagementObjectSearcher("root\\CIMV2",
                    "SELECT * FROM Win32_PerfFormattedData_PerfDisk_LogicalDisk");

                foreach (ManagementObject queryObj in searcher.Get())
                {
                    if ((string)queryObj["Name"] == drivename)
                    {
                        return int.Parse(queryObj["PercentFreeSpace"].ToString());
                    }

                }
            }
            catch (ManagementException e)
            {
                // Ignore this error for now
            }
            return 100;
        }

        private string InQuotes(string p)
        {
            return "'" + p + "'";
        }

        private int GetDiskStatus(string drivename)
        {
            try
            {
                ManagementObjectSearcher searcher =
                    new ManagementObjectSearcher("root\\CIMV2",
                    "SELECT * FROM Win32_PerfFormattedData_PerfDisk_LogicalDisk");

                foreach (ManagementObject queryObj in searcher.Get())
                {
                    if ((string)queryObj["Name"] == drivename)
                    {
                        double reads = double.Parse(queryObj["DiskReadsPersec"].ToString());
                        double writes = double.Parse(queryObj["DiskWritesPersec"].ToString());

                        if (reads > MaxRead) MaxRead = reads;
                        if (writes > MaxWrite) MaxWrite = writes;

                        ProgressRead.Maximum = (int)MaxRead+1;
                        progressWrite.Maximum = (int)MaxWrite+1;

                        ProgressRead.Value =  (int)reads;
                        progressWrite.Value = (int)writes;


                        // decide which is happening most to decide what image to show
                        if (reads > writes)
                        {
                            return (int)DiskStatusImage.Read;
                        }
                        else if (writes > reads)
                        {
                            return (int)DiskStatusImage.Write;
                        }
                        else
                        {
                            return (int)DiskStatusImage.InActive;
                        }
                    }
                }
            }
            catch (ManagementException e)
            {
                return 0;
            }
            return 0;
        }

        private void FastTimerTick(object sender, EventArgs e)
        {
            pbDiskStatus.Image = imagesHDActivity.Images[GetDiskStatus(lbDriveName.Text.Trim('\\'))];
        }
    }
}
