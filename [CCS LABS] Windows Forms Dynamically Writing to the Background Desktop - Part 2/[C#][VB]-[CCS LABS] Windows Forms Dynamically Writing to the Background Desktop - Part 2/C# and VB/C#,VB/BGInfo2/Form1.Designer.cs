namespace BGInfo2
{
    partial class Form1
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.timerGUI = new System.Windows.Forms.Timer(this.components);
            this.mouseKeyEvents = new MouseKeyboardActivityMonitor.Controls.MouseKeyEventProvider();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.lblFreeMemory = new System.Windows.Forms.Label();
            this.lblTotalMemory = new System.Windows.Forms.Label();
            this.lblDefaultGateway = new System.Windows.Forms.Label();
            this.lblIdleTime = new System.Windows.Forms.Label();
            this.lblExternalIPAddress = new System.Windows.Forms.Label();
            this.lblInternalIPAddress = new System.Windows.Forms.Label();
            this.lblUpTime = new System.Windows.Forms.Label();
            this.lblMouseXY = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.shapeContainer1 = new Microsoft.VisualBasic.PowerPacks.ShapeContainer();
            this.lineShape4 = new Microsoft.VisualBasic.PowerPacks.LineShape();
            this.lineShape3 = new Microsoft.VisualBasic.PowerPacks.LineShape();
            this.lineShape2 = new Microsoft.VisualBasic.PowerPacks.LineShape();
            this.lineShape1 = new Microsoft.VisualBasic.PowerPacks.LineShape();
            this.timerFiveSeconds = new System.Windows.Forms.Timer(this.components);
            this.rtbConOut = new System.Windows.Forms.RichTextBox();
            this.flpDiskStatus = new System.Windows.Forms.FlowLayoutPanel();
            this.SuspendLayout();
            // 
            // timerGUI
            // 
            this.timerGUI.Interval = 1000;
            // 
            // mouseKeyEvents
            // 
            this.mouseKeyEvents.Enabled = true;
            this.mouseKeyEvents.HookType = MouseKeyboardActivityMonitor.Controls.HookType.Global;
            this.mouseKeyEvents.MouseClick += new System.Windows.Forms.MouseEventHandler(this.MouseKeyEventsMouseClick);
            this.mouseKeyEvents.MouseMoveExt += new System.EventHandler<MouseKeyboardActivityMonitor.MouseEventExtArgs>(this.MouseKeyEventsMouseMoveExt);
            this.mouseKeyEvents.MouseWheel += new System.EventHandler<System.Windows.Forms.MouseEventArgs>(this.MouseKeyEventsMouseWheel);
            this.mouseKeyEvents.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.MouseKeyEventsKeyPress);
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(451, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(98, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Computer Up Time:";
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(450, 47);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(99, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Internal IP Address:";
            // 
            // label3
            // 
            this.label3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(447, 60);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(102, 13);
            this.label3.TabIndex = 3;
            this.label3.Text = "External IP Address:";
            // 
            // label4
            // 
            this.label4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(448, 22);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(101, 13);
            this.label4.TabIndex = 4;
            this.label4.Text = "Computer Idle Time:";
            // 
            // label5
            // 
            this.label5.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(460, 73);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(89, 13);
            this.label5.TabIndex = 5;
            this.label5.Text = "Default Gateway:";
            // 
            // label6
            // 
            this.label6.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(475, 101);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(74, 13);
            this.label6.TabIndex = 6;
            this.label6.Text = "Total Memory:";
            // 
            // label7
            // 
            this.label7.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(478, 114);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(71, 13);
            this.label7.TabIndex = 7;
            this.label7.Text = "Free Memory:";
            // 
            // lblFreeMemory
            // 
            this.lblFreeMemory.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblFreeMemory.AutoSize = true;
            this.lblFreeMemory.Location = new System.Drawing.Point(576, 114);
            this.lblFreeMemory.Name = "lblFreeMemory";
            this.lblFreeMemory.Size = new System.Drawing.Size(32, 13);
            this.lblFreeMemory.TabIndex = 14;
            this.lblFreeMemory.Text = "0 MB";
            // 
            // lblTotalMemory
            // 
            this.lblTotalMemory.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblTotalMemory.AutoSize = true;
            this.lblTotalMemory.Location = new System.Drawing.Point(576, 101);
            this.lblTotalMemory.Name = "lblTotalMemory";
            this.lblTotalMemory.Size = new System.Drawing.Size(32, 13);
            this.lblTotalMemory.TabIndex = 13;
            this.lblTotalMemory.Text = "0 MB";
            // 
            // lblDefaultGateway
            // 
            this.lblDefaultGateway.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblDefaultGateway.AutoSize = true;
            this.lblDefaultGateway.Location = new System.Drawing.Point(576, 73);
            this.lblDefaultGateway.Name = "lblDefaultGateway";
            this.lblDefaultGateway.Size = new System.Drawing.Size(76, 13);
            this.lblDefaultGateway.TabIndex = 12;
            this.lblDefaultGateway.Text = "xxx:xxx:xxx:xxx";
            // 
            // lblIdleTime
            // 
            this.lblIdleTime.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblIdleTime.AutoSize = true;
            this.lblIdleTime.Location = new System.Drawing.Point(576, 22);
            this.lblIdleTime.Name = "lblIdleTime";
            this.lblIdleTime.Size = new System.Drawing.Size(22, 13);
            this.lblIdleTime.TabIndex = 11;
            this.lblIdleTime.Text = "NA";
            // 
            // lblExternalIPAddress
            // 
            this.lblExternalIPAddress.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblExternalIPAddress.AutoSize = true;
            this.lblExternalIPAddress.Location = new System.Drawing.Point(576, 60);
            this.lblExternalIPAddress.Name = "lblExternalIPAddress";
            this.lblExternalIPAddress.Size = new System.Drawing.Size(76, 13);
            this.lblExternalIPAddress.TabIndex = 10;
            this.lblExternalIPAddress.Text = "xxx:xxx:xxx:xxx";
            // 
            // lblInternalIPAddress
            // 
            this.lblInternalIPAddress.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblInternalIPAddress.AutoSize = true;
            this.lblInternalIPAddress.Location = new System.Drawing.Point(576, 47);
            this.lblInternalIPAddress.Name = "lblInternalIPAddress";
            this.lblInternalIPAddress.Size = new System.Drawing.Size(76, 13);
            this.lblInternalIPAddress.TabIndex = 9;
            this.lblInternalIPAddress.Text = "xxx:xxx:xxx:xxx";
            // 
            // lblUpTime
            // 
            this.lblUpTime.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblUpTime.AutoSize = true;
            this.lblUpTime.Location = new System.Drawing.Point(576, 9);
            this.lblUpTime.Name = "lblUpTime";
            this.lblUpTime.Size = new System.Drawing.Size(22, 13);
            this.lblUpTime.TabIndex = 8;
            this.lblUpTime.Text = "NA";
            // 
            // lblMouseXY
            // 
            this.lblMouseXY.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.lblMouseXY.AutoSize = true;
            this.lblMouseXY.Location = new System.Drawing.Point(576, 435);
            this.lblMouseXY.Name = "lblMouseXY";
            this.lblMouseXY.Size = new System.Drawing.Size(24, 13);
            this.lblMouseXY.TabIndex = 16;
            this.lblMouseXY.Text = "X:Y";
            // 
            // label9
            // 
            this.label9.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(448, 435);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(101, 13);
            this.label9.TabIndex = 15;
            this.label9.Text = "Mouse Coordinates:";
            // 
            // shapeContainer1
            // 
            this.shapeContainer1.Location = new System.Drawing.Point(0, 0);
            this.shapeContainer1.Margin = new System.Windows.Forms.Padding(0);
            this.shapeContainer1.Name = "shapeContainer1";
            this.shapeContainer1.Shapes.AddRange(new Microsoft.VisualBasic.PowerPacks.Shape[] {
            this.lineShape4,
            this.lineShape3,
            this.lineShape2,
            this.lineShape1});
            this.shapeContainer1.Size = new System.Drawing.Size(700, 479);
            this.shapeContainer1.TabIndex = 17;
            this.shapeContainer1.TabStop = false;
            // 
            // lineShape4
            // 
            this.lineShape4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.lineShape4.BorderColor = System.Drawing.Color.Khaki;
            this.lineShape4.Name = "lineShape4";
            this.lineShape4.X1 = 448;
            this.lineShape4.X2 = 650;
            this.lineShape4.Y1 = 428;
            this.lineShape4.Y2 = 428;
            // 
            // lineShape3
            // 
            this.lineShape3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lineShape3.BorderColor = System.Drawing.Color.Khaki;
            this.lineShape3.Name = "lineShape3";
            this.lineShape3.X1 = 448;
            this.lineShape3.X2 = 650;
            this.lineShape3.Y1 = 135;
            this.lineShape3.Y2 = 135;
            // 
            // lineShape2
            // 
            this.lineShape2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lineShape2.BorderColor = System.Drawing.Color.Khaki;
            this.lineShape2.Name = "lineShape2";
            this.lineShape2.X1 = 448;
            this.lineShape2.X2 = 650;
            this.lineShape2.Y1 = 92;
            this.lineShape2.Y2 = 92;
            // 
            // lineShape1
            // 
            this.lineShape1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lineShape1.BorderColor = System.Drawing.Color.Khaki;
            this.lineShape1.Name = "lineShape1";
            this.lineShape1.X1 = 448;
            this.lineShape1.X2 = 650;
            this.lineShape1.Y1 = 43;
            this.lineShape1.Y2 = 43;
            // 
            // timerFiveSeconds
            // 
            this.timerFiveSeconds.Enabled = true;
            this.timerFiveSeconds.Interval = 60000;
            this.timerFiveSeconds.Tick += new System.EventHandler(this.TimerFiveSecondsTick);
            // 
            // rtbConOut
            // 
            this.rtbConOut.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.rtbConOut.BackColor = System.Drawing.SystemColors.Desktop;
            this.rtbConOut.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.rtbConOut.ForeColor = System.Drawing.Color.DarkSalmon;
            this.rtbConOut.Location = new System.Drawing.Point(448, 395);
            this.rtbConOut.Name = "rtbConOut";
            this.rtbConOut.ReadOnly = true;
            this.rtbConOut.Size = new System.Drawing.Size(203, 24);
            this.rtbConOut.TabIndex = 21;
            this.rtbConOut.Text = "";
            // 
            // flpDiskStatus
            // 
            this.flpDiskStatus.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.flpDiskStatus.AutoSize = true;
            this.flpDiskStatus.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.flpDiskStatus.BackColor = System.Drawing.Color.Black;
            this.flpDiskStatus.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.flpDiskStatus.Location = new System.Drawing.Point(652, 144);
            this.flpDiskStatus.Name = "flpDiskStatus";
            this.flpDiskStatus.Size = new System.Drawing.Size(0, 0);
            this.flpDiskStatus.TabIndex = 22;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Black;
            this.ClientSize = new System.Drawing.Size(700, 479);
            this.Controls.Add(this.flpDiskStatus);
            this.Controls.Add(this.rtbConOut);
            this.Controls.Add(this.lblMouseXY);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.lblFreeMemory);
            this.Controls.Add(this.lblTotalMemory);
            this.Controls.Add(this.lblDefaultGateway);
            this.Controls.Add(this.lblIdleTime);
            this.Controls.Add(this.lblExternalIPAddress);
            this.Controls.Add(this.lblInternalIPAddress);
            this.Controls.Add(this.lblUpTime);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.shapeContainer1);
            this.ForeColor = System.Drawing.Color.Yellow;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Form1";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "BGInfo 2";
            this.TransparencyKey = System.Drawing.Color.Black;
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Timer timerGUI;
        private MouseKeyboardActivityMonitor.Controls.MouseKeyEventProvider mouseKeyEvents;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label lblFreeMemory;
        private System.Windows.Forms.Label lblTotalMemory;
        private System.Windows.Forms.Label lblDefaultGateway;
        private System.Windows.Forms.Label lblIdleTime;
        private System.Windows.Forms.Label lblExternalIPAddress;
        private System.Windows.Forms.Label lblInternalIPAddress;
        private System.Windows.Forms.Label lblUpTime;
        private System.Windows.Forms.Label lblMouseXY;
        private System.Windows.Forms.Label label9;
        private Microsoft.VisualBasic.PowerPacks.ShapeContainer shapeContainer1;
        private Microsoft.VisualBasic.PowerPacks.LineShape lineShape4;
        private Microsoft.VisualBasic.PowerPacks.LineShape lineShape3;
        private Microsoft.VisualBasic.PowerPacks.LineShape lineShape2;
        private Microsoft.VisualBasic.PowerPacks.LineShape lineShape1;
        private System.Windows.Forms.Timer timerFiveSeconds;
        private System.Windows.Forms.RichTextBox rtbConOut;
        private System.Windows.Forms.FlowLayoutPanel flpDiskStatus;
    }
}

