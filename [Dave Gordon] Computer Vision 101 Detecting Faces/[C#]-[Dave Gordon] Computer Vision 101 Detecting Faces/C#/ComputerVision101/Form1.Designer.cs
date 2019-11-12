namespace ComputerVision101
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
            this.btnStartStop = new System.Windows.Forms.Button();
            this.FBD = new System.Windows.Forms.FolderBrowserDialog();
            this.label3 = new System.Windows.Forms.Label();
            this.btnNext = new System.Windows.Forms.Button();
            this.btnPrevious = new System.Windows.Forms.Button();
            this.pbResult = new System.Windows.Forms.PictureBox();
            this.progressThisPicture = new System.Windows.Forms.ProgressBar();
            this.label1 = new System.Windows.Forms.Label();
            this.tbAutoscaleFactor = new System.Windows.Forms.TextBox();
            this.tbMinNeighbours = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.tbMinFaceSize = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.tbMaxFaceSize = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.lblMaxFaceSize = new System.Windows.Forms.Label();
            this.lblMinFaceSize = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.shapeContainer1 = new Microsoft.VisualBasic.PowerPacks.ShapeContainer();
            this.rectangleShape1 = new Microsoft.VisualBasic.PowerPacks.RectangleShape();
            this.rectangleShape2 = new Microsoft.VisualBasic.PowerPacks.RectangleShape();
            this.rectangleShape3 = new Microsoft.VisualBasic.PowerPacks.RectangleShape();
            ((System.ComponentModel.ISupportInitialize)(this.pbResult)).BeginInit();
            this.SuspendLayout();
            // 
            // btnStartStop
            // 
            this.btnStartStop.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnStartStop.Location = new System.Drawing.Point(828, 469);
            this.btnStartStop.Name = "btnStartStop";
            this.btnStartStop.Size = new System.Drawing.Size(75, 23);
            this.btnStartStop.TabIndex = 1;
            this.btnStartStop.Text = "Start";
            this.btnStartStop.UseVisualStyleBackColor = true;
            this.btnStartStop.Click += new System.EventHandler(this.btnStartStop_Click);
            // 
            // FBD
            // 
            this.FBD.Description = "Folder to collect Images From";
            this.FBD.RootFolder = System.Environment.SpecialFolder.MyPictures;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Monotype Corsiva", 15.75F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(13, 15);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(61, 25);
            this.label3.TabIndex = 13;
            this.label3.Text = "Result";
            // 
            // btnNext
            // 
            this.btnNext.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnNext.Location = new System.Drawing.Point(828, 508);
            this.btnNext.Name = "btnNext";
            this.btnNext.Size = new System.Drawing.Size(75, 23);
            this.btnNext.TabIndex = 16;
            this.btnNext.Text = "Next >>";
            this.btnNext.UseVisualStyleBackColor = true;
            // 
            // btnPrevious
            // 
            this.btnPrevious.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnPrevious.Location = new System.Drawing.Point(747, 508);
            this.btnPrevious.Name = "btnPrevious";
            this.btnPrevious.Size = new System.Drawing.Size(75, 23);
            this.btnPrevious.TabIndex = 17;
            this.btnPrevious.Text = "<< Previous ";
            this.btnPrevious.UseVisualStyleBackColor = true;
            // 
            // pbResult
            // 
            this.pbResult.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pbResult.Location = new System.Drawing.Point(19, 43);
            this.pbResult.Name = "pbResult";
            this.pbResult.Size = new System.Drawing.Size(723, 459);
            this.pbResult.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pbResult.TabIndex = 18;
            this.pbResult.TabStop = false;
            // 
            // progressThisPicture
            // 
            this.progressThisPicture.Location = new System.Drawing.Point(18, 508);
            this.progressThisPicture.Name = "progressThisPicture";
            this.progressThisPicture.Size = new System.Drawing.Size(723, 10);
            this.progressThisPicture.Step = 1;
            this.progressThisPicture.Style = System.Windows.Forms.ProgressBarStyle.Continuous;
            this.progressThisPicture.TabIndex = 19;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(748, 43);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(87, 13);
            this.label1.TabIndex = 20;
            this.label1.Text = "Autoscale Factor";
            // 
            // tbAutoscaleFactor
            // 
            this.tbAutoscaleFactor.BackColor = System.Drawing.SystemColors.Control;
            this.tbAutoscaleFactor.Location = new System.Drawing.Point(852, 41);
            this.tbAutoscaleFactor.Name = "tbAutoscaleFactor";
            this.tbAutoscaleFactor.Size = new System.Drawing.Size(35, 20);
            this.tbAutoscaleFactor.TabIndex = 21;
            this.tbAutoscaleFactor.Text = "0.0";
            this.tbAutoscaleFactor.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // tbMinNeighbours
            // 
            this.tbMinNeighbours.BackColor = System.Drawing.SystemColors.Control;
            this.tbMinNeighbours.Location = new System.Drawing.Point(852, 62);
            this.tbMinNeighbours.Name = "tbMinNeighbours";
            this.tbMinNeighbours.Size = new System.Drawing.Size(35, 20);
            this.tbMinNeighbours.TabIndex = 23;
            this.tbMinNeighbours.Text = "0";
            this.tbMinNeighbours.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(748, 64);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(105, 13);
            this.label2.TabIndex = 22;
            this.label2.Text = "Minimum Neighbours";
            // 
            // tbMinFaceSize
            // 
            this.tbMinFaceSize.BackColor = System.Drawing.SystemColors.Control;
            this.tbMinFaceSize.Location = new System.Drawing.Point(852, 83);
            this.tbMinFaceSize.Name = "tbMinFaceSize";
            this.tbMinFaceSize.Size = new System.Drawing.Size(35, 20);
            this.tbMinFaceSize.TabIndex = 25;
            this.tbMinFaceSize.Text = "0";
            this.tbMinFaceSize.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(748, 85);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(98, 13);
            this.label4.TabIndex = 24;
            this.label4.Text = "Minimum Face Size";
            // 
            // tbMaxFaceSize
            // 
            this.tbMaxFaceSize.BackColor = System.Drawing.SystemColors.Control;
            this.tbMaxFaceSize.Location = new System.Drawing.Point(852, 104);
            this.tbMaxFaceSize.Name = "tbMaxFaceSize";
            this.tbMaxFaceSize.Size = new System.Drawing.Size(35, 20);
            this.tbMaxFaceSize.TabIndex = 27;
            this.tbMaxFaceSize.Text = "0";
            this.tbMaxFaceSize.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(748, 106);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(101, 13);
            this.label5.TabIndex = 26;
            this.label5.Text = "Maximum Face Size";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(748, 144);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(72, 13);
            this.label6.TabIndex = 28;
            this.label6.Text = "Min face size:";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(745, 157);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(75, 13);
            this.label7.TabIndex = 29;
            this.label7.Text = "Max face size:";
            // 
            // lblMaxFaceSize
            // 
            this.lblMaxFaceSize.AutoSize = true;
            this.lblMaxFaceSize.Location = new System.Drawing.Point(823, 157);
            this.lblMaxFaceSize.Name = "lblMaxFaceSize";
            this.lblMaxFaceSize.Size = new System.Drawing.Size(13, 13);
            this.lblMaxFaceSize.TabIndex = 31;
            this.lblMaxFaceSize.Text = "0";
            // 
            // lblMinFaceSize
            // 
            this.lblMinFaceSize.AutoSize = true;
            this.lblMinFaceSize.Location = new System.Drawing.Point(823, 144);
            this.lblMinFaceSize.Name = "lblMinFaceSize";
            this.lblMinFaceSize.Size = new System.Drawing.Size(13, 13);
            this.lblMinFaceSize.TabIndex = 30;
            this.lblMinFaceSize.Text = "0";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(747, 197);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(30, 13);
            this.label8.TabIndex = 32;
            this.label8.Text = "Eyes";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(748, 210);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(66, 13);
            this.label9.TabIndex = 33;
            this.label9.Text = "Frontal Face";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(748, 223);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(36, 13);
            this.label10.TabIndex = 34;
            this.label10.Text = "Profile";
            // 
            // shapeContainer1
            // 
            this.shapeContainer1.Location = new System.Drawing.Point(0, 0);
            this.shapeContainer1.Margin = new System.Windows.Forms.Padding(0);
            this.shapeContainer1.Name = "shapeContainer1";
            this.shapeContainer1.Shapes.AddRange(new Microsoft.VisualBasic.PowerPacks.Shape[] {
            this.rectangleShape3,
            this.rectangleShape2,
            this.rectangleShape1});
            this.shapeContainer1.Size = new System.Drawing.Size(915, 543);
            this.shapeContainer1.TabIndex = 35;
            this.shapeContainer1.TabStop = false;
            // 
            // rectangleShape1
            // 
            this.rectangleShape1.BackColor = System.Drawing.Color.White;
            this.rectangleShape1.FillColor = System.Drawing.Color.White;
            this.rectangleShape1.FillGradientColor = System.Drawing.Color.White;
            this.rectangleShape1.FillStyle = Microsoft.VisualBasic.PowerPacks.FillStyle.Solid;
            this.rectangleShape1.Location = new System.Drawing.Point(814, 201);
            this.rectangleShape1.Name = "rectangleShape1";
            this.rectangleShape1.Size = new System.Drawing.Size(89, 9);
            // 
            // rectangleShape2
            // 
            this.rectangleShape2.BackColor = System.Drawing.Color.White;
            this.rectangleShape2.FillColor = System.Drawing.Color.DarkRed;
            this.rectangleShape2.FillGradientColor = System.Drawing.Color.DarkRed;
            this.rectangleShape2.FillStyle = Microsoft.VisualBasic.PowerPacks.FillStyle.Solid;
            this.rectangleShape2.Location = new System.Drawing.Point(814, 213);
            this.rectangleShape2.Name = "rectangleShape2";
            this.rectangleShape2.Size = new System.Drawing.Size(89, 9);
            // 
            // rectangleShape3
            // 
            this.rectangleShape3.BackColor = System.Drawing.Color.White;
            this.rectangleShape3.FillColor = System.Drawing.Color.Gold;
            this.rectangleShape3.FillGradientColor = System.Drawing.Color.Gold;
            this.rectangleShape3.FillStyle = Microsoft.VisualBasic.PowerPacks.FillStyle.Solid;
            this.rectangleShape3.Location = new System.Drawing.Point(814, 225);
            this.rectangleShape3.Name = "rectangleShape3";
            this.rectangleShape3.Size = new System.Drawing.Size(89, 9);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(915, 543);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.lblMaxFaceSize);
            this.Controls.Add(this.lblMinFaceSize);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.tbMaxFaceSize);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.tbMinFaceSize);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.tbMinNeighbours);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.tbAutoscaleFactor);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.progressThisPicture);
            this.Controls.Add(this.btnPrevious);
            this.Controls.Add(this.btnNext);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.btnStartStop);
            this.Controls.Add(this.pbResult);
            this.Controls.Add(this.shapeContainer1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "Form1";
            this.Text = "Computer Vision 101";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.Load += new System.EventHandler(this.Form1_Load);
            this.SizeChanged += new System.EventHandler(this.Form1_SizeChanged);
            ((System.ComponentModel.ISupportInitialize)(this.pbResult)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnStartStop;
        private System.Windows.Forms.FolderBrowserDialog FBD;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btnNext;
        private System.Windows.Forms.Button btnPrevious;
        private System.Windows.Forms.PictureBox pbResult;
        private System.Windows.Forms.ProgressBar progressThisPicture;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox tbAutoscaleFactor;
        private System.Windows.Forms.TextBox tbMinNeighbours;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox tbMinFaceSize;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox tbMaxFaceSize;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label lblMaxFaceSize;
        private System.Windows.Forms.Label lblMinFaceSize;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label10;
        private Microsoft.VisualBasic.PowerPacks.ShapeContainer shapeContainer1;
        private Microsoft.VisualBasic.PowerPacks.RectangleShape rectangleShape3;
        private Microsoft.VisualBasic.PowerPacks.RectangleShape rectangleShape2;
        private Microsoft.VisualBasic.PowerPacks.RectangleShape rectangleShape1;
    }
}

