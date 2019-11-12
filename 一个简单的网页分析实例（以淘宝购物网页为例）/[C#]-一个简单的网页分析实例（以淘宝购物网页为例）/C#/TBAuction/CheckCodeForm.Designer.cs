namespace TBAuction
{
    partial class CheckCodeForm
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
            this.checkCodePic = new System.Windows.Forms.PictureBox();
            this.btnOK = new System.Windows.Forms.Button();
            this.txtCheckCode = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.checkCodePic)).BeginInit();
            this.SuspendLayout();
            // 
            // checkCodePic
            // 
            this.checkCodePic.Location = new System.Drawing.Point(33, 12);
            this.checkCodePic.Name = "checkCodePic";
            this.checkCodePic.Size = new System.Drawing.Size(142, 49);
            this.checkCodePic.TabIndex = 0;
            this.checkCodePic.TabStop = false;
            // 
            // btnOK
            // 
            this.btnOK.Location = new System.Drawing.Point(64, 119);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(81, 23);
            this.btnOK.TabIndex = 2;
            this.btnOK.Text = "确定";
            this.btnOK.UseVisualStyleBackColor = true;
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // txtCheckCode
            // 
            this.txtCheckCode.Location = new System.Drawing.Point(53, 80);
            this.txtCheckCode.Name = "txtCheckCode";
            this.txtCheckCode.Size = new System.Drawing.Size(102, 21);
            this.txtCheckCode.TabIndex = 1;
            // 
            // CheckCodeForm
            // 
            this.AcceptButton = this.btnOK;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(213, 149);
            this.Controls.Add(this.txtCheckCode);
            this.Controls.Add(this.btnOK);
            this.Controls.Add(this.checkCodePic);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "CheckCodeForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "输入验证码";
            this.TopMost = true;
            ((System.ComponentModel.ISupportInitialize)(this.checkCodePic)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        public System.Windows.Forms.PictureBox checkCodePic;
        private System.Windows.Forms.Button btnOK;
        public System.Windows.Forms.TextBox txtCheckCode;
    }
}