namespace WebImageCrawler
{
    partial class FrmDesktopView
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

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.lblImages = new System.Windows.Forms.Label();
            this.lblDomains = new System.Windows.Forms.Label();
            this.lblImagesQueue = new System.Windows.Forms.Label();
            this.lblDomainQueue = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.lblStop = new System.Windows.Forms.Label();
            this.timerGUI = new System.Windows.Forms.Timer(this.components);
            this.label3 = new System.Windows.Forms.Label();
            this.lblPRocessing = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(243, 460);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(51, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Domains:";
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(250, 473);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(44, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Images:";
            // 
            // lblImages
            // 
            this.lblImages.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblImages.AutoSize = true;
            this.lblImages.Location = new System.Drawing.Point(300, 473);
            this.lblImages.Name = "lblImages";
            this.lblImages.Size = new System.Drawing.Size(13, 13);
            this.lblImages.TabIndex = 3;
            this.lblImages.Text = "0";
            // 
            // lblDomains
            // 
            this.lblDomains.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblDomains.AutoSize = true;
            this.lblDomains.Location = new System.Drawing.Point(300, 460);
            this.lblDomains.Name = "lblDomains";
            this.lblDomains.Size = new System.Drawing.Size(13, 13);
            this.lblDomains.TabIndex = 2;
            this.lblDomains.Text = "0";
            // 
            // lblImagesQueue
            // 
            this.lblImagesQueue.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblImagesQueue.AutoSize = true;
            this.lblImagesQueue.Location = new System.Drawing.Point(459, 473);
            this.lblImagesQueue.Name = "lblImagesQueue";
            this.lblImagesQueue.Size = new System.Drawing.Size(13, 13);
            this.lblImagesQueue.TabIndex = 7;
            this.lblImagesQueue.Text = "0";
            // 
            // lblDomainQueue
            // 
            this.lblDomainQueue.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblDomainQueue.AutoSize = true;
            this.lblDomainQueue.Location = new System.Drawing.Point(459, 460);
            this.lblDomainQueue.Name = "lblDomainQueue";
            this.lblDomainQueue.Size = new System.Drawing.Size(13, 13);
            this.lblDomainQueue.TabIndex = 6;
            this.lblDomainQueue.Text = "0";
            // 
            // label5
            // 
            this.label5.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(409, 473);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(42, 13);
            this.label5.TabIndex = 5;
            this.label5.Text = "Queue:";
            // 
            // label6
            // 
            this.label6.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(409, 460);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(42, 13);
            this.label6.TabIndex = 4;
            this.label6.Text = "Queue:";
            // 
            // lblStop
            // 
            this.lblStop.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblStop.AutoSize = true;
            this.lblStop.BackColor = System.Drawing.Color.Transparent;
            this.lblStop.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblStop.Location = new System.Drawing.Point(550, 471);
            this.lblStop.Name = "lblStop";
            this.lblStop.Size = new System.Drawing.Size(31, 15);
            this.lblStop.TabIndex = 8;
            this.lblStop.Text = "Stop";
            this.lblStop.Click += new System.EventHandler(this.LblStopClick);
            // 
            // timerGUI
            // 
            this.timerGUI.Enabled = true;
            this.timerGUI.Tick += new System.EventHandler(this.TimerGuiTick);
            // 
            // label3
            // 
            this.label3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(232, 486);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(62, 13);
            this.label3.TabIndex = 9;
            this.label3.Text = "Processing:";
            // 
            // lblPRocessing
            // 
            this.lblPRocessing.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.lblPRocessing.AutoEllipsis = true;
            this.lblPRocessing.ForeColor = System.Drawing.Color.Aquamarine;
            this.lblPRocessing.Location = new System.Drawing.Point(300, 486);
            this.lblPRocessing.Name = "lblPRocessing";
            this.lblPRocessing.Size = new System.Drawing.Size(356, 13);
            this.lblPRocessing.TabIndex = 10;
            // 
            // FrmDesktopView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Black;
            this.ClientSize = new System.Drawing.Size(766, 533);
            this.ControlBox = false;
            this.Controls.Add(this.lblPRocessing);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.lblStop);
            this.Controls.Add(this.lblImagesQueue);
            this.Controls.Add(this.lblDomainQueue);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.lblImages);
            this.Controls.Add(this.lblDomains);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.ForeColor = System.Drawing.Color.Gold;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmDesktopView";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.Text = "frmDesktopView";
            this.TransparencyKey = System.Drawing.Color.Black;
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lblImages;
        private System.Windows.Forms.Label lblDomains;
        private System.Windows.Forms.Label lblImagesQueue;
        private System.Windows.Forms.Label lblDomainQueue;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label lblStop;
        private System.Windows.Forms.Timer timerGUI;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label lblPRocessing;
    }
}