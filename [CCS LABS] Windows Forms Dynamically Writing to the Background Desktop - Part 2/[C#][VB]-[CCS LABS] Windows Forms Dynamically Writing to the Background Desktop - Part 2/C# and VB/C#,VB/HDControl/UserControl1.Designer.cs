namespace HDControl
{
    partial class HDControl
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(HDControl));
            this.pbDiskStatus = new System.Windows.Forms.PictureBox();
            this.progressFreeSpace = new System.Windows.Forms.ProgressBar();
            this.lbDriveName = new System.Windows.Forms.Label();
            this.imagesHDActivity = new System.Windows.Forms.ImageList(this.components);
            this.rptTimer = new System.Windows.Forms.Timer(this.components);
            this.ProgressRead = new System.Windows.Forms.ProgressBar();
            this.progressWrite = new System.Windows.Forms.ProgressBar();
            this.fastTimer = new System.Windows.Forms.Timer(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.pbDiskStatus)).BeginInit();
            this.SuspendLayout();
            // 
            // pbDiskStatus
            // 
            this.pbDiskStatus.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.pbDiskStatus.Image = ((System.Drawing.Image)(resources.GetObject("pbDiskStatus.Image")));
            this.pbDiskStatus.Location = new System.Drawing.Point(159, 0);
            this.pbDiskStatus.Name = "pbDiskStatus";
            this.pbDiskStatus.Size = new System.Drawing.Size(44, 54);
            this.pbDiskStatus.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pbDiskStatus.TabIndex = 5;
            this.pbDiskStatus.TabStop = false;
            // 
            // progressFreeSpace
            // 
            this.progressFreeSpace.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.progressFreeSpace.Location = new System.Drawing.Point(6, 17);
            this.progressFreeSpace.Name = "progressFreeSpace";
            this.progressFreeSpace.Size = new System.Drawing.Size(136, 10);
            this.progressFreeSpace.TabIndex = 4;
            // 
            // lbDriveName
            // 
            this.lbDriveName.AutoSize = true;
            this.lbDriveName.ForeColor = System.Drawing.Color.Yellow;
            this.lbDriveName.Location = new System.Drawing.Point(3, 0);
            this.lbDriveName.Name = "lbDriveName";
            this.lbDriveName.Size = new System.Drawing.Size(35, 13);
            this.lbDriveName.TabIndex = 3;
            this.lbDriveName.Text = "label1";
            // 
            // imagesHDActivity
            // 
            this.imagesHDActivity.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imagesHDActivity.ImageStream")));
            this.imagesHDActivity.TransparentColor = System.Drawing.Color.Transparent;
            this.imagesHDActivity.Images.SetKeyName(0, "drive_3_cb_clean.png");
            this.imagesHDActivity.Images.SetKeyName(1, "drive_3_sg_clean.png");
            this.imagesHDActivity.Images.SetKeyName(2, "drive_3_br_clean.png");
            // 
            // rptTimer
            // 
            this.rptTimer.Interval = 1000;
            this.rptTimer.Tick += new System.EventHandler(this.RptTimerTick);
            // 
            // ProgressRead
            // 
            this.ProgressRead.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.ProgressRead.ForeColor = System.Drawing.Color.PaleGreen;
            this.ProgressRead.Location = new System.Drawing.Point(6, 28);
            this.ProgressRead.Name = "ProgressRead";
            this.ProgressRead.Size = new System.Drawing.Size(136, 10);
            this.ProgressRead.Step = 1;
            this.ProgressRead.Style = System.Windows.Forms.ProgressBarStyle.Continuous;
            this.ProgressRead.TabIndex = 6;
            // 
            // progressWrite
            // 
            this.progressWrite.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.progressWrite.ForeColor = System.Drawing.Color.Red;
            this.progressWrite.Location = new System.Drawing.Point(6, 39);
            this.progressWrite.Name = "progressWrite";
            this.progressWrite.Size = new System.Drawing.Size(136, 10);
            this.progressWrite.Step = 1;
            this.progressWrite.Style = System.Windows.Forms.ProgressBarStyle.Continuous;
            this.progressWrite.TabIndex = 7;
            // 
            // fastTimer
            // 
            this.fastTimer.Interval = 500;
            this.fastTimer.Tick += new System.EventHandler(this.FastTimerTick);
            // 
            // HDControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Transparent;
            this.Controls.Add(this.progressWrite);
            this.Controls.Add(this.ProgressRead);
            this.Controls.Add(this.pbDiskStatus);
            this.Controls.Add(this.progressFreeSpace);
            this.Controls.Add(this.lbDriveName);
            this.Name = "HDControl";
            this.Size = new System.Drawing.Size(206, 54);
            ((System.ComponentModel.ISupportInitialize)(this.pbDiskStatus)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pbDiskStatus;
        private System.Windows.Forms.ProgressBar progressFreeSpace;
        private System.Windows.Forms.Label lbDriveName;
        private System.Windows.Forms.ImageList imagesHDActivity;
        private System.Windows.Forms.Timer rptTimer;
        private System.Windows.Forms.ProgressBar ProgressRead;
        private System.Windows.Forms.ProgressBar progressWrite;
        private System.Windows.Forms.Timer fastTimer;
    }
}
