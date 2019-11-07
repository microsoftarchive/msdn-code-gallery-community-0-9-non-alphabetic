namespace WebBrowser
{
    partial class FrmCodeView
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
            this.btnSaveCode = new System.Windows.Forms.Button();
            this.btnCloseCodeView = new System.Windows.Forms.Button();
            this.rtbxcodeView = new System.Windows.Forms.RichTextBox();
            this.SuspendLayout();
            // 
            // btnSaveCode
            // 
            this.btnSaveCode.Location = new System.Drawing.Point(87, 353);
            this.btnSaveCode.Name = "btnSaveCode";
            this.btnSaveCode.Size = new System.Drawing.Size(75, 23);
            this.btnSaveCode.TabIndex = 0;
            this.btnSaveCode.Text = "保存(&S)";
            this.btnSaveCode.UseVisualStyleBackColor = true;
            this.btnSaveCode.Click += new System.EventHandler(this.btnSaveCode_Click);
            // 
            // btnCloseCodeView
            // 
            this.btnCloseCodeView.Location = new System.Drawing.Point(218, 353);
            this.btnCloseCodeView.Name = "btnCloseCodeView";
            this.btnCloseCodeView.Size = new System.Drawing.Size(75, 23);
            this.btnCloseCodeView.TabIndex = 1;
            this.btnCloseCodeView.Text = "关闭";
            this.btnCloseCodeView.UseVisualStyleBackColor = true;
            this.btnCloseCodeView.Click += new System.EventHandler(this.btnCloseCodeView_Click);
            // 
            // rtbxcodeView
            // 
            this.rtbxcodeView.Location = new System.Drawing.Point(-3, -3);
            this.rtbxcodeView.Name = "rtbxcodeView";
            this.rtbxcodeView.Size = new System.Drawing.Size(468, 350);
            this.rtbxcodeView.TabIndex = 2;
            this.rtbxcodeView.Text = "";
            // 
            // FrmCodeView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(464, 388);
            this.Controls.Add(this.rtbxcodeView);
            this.Controls.Add(this.btnCloseCodeView);
            this.Controls.Add(this.btnSaveCode);
            this.Name = "FrmCodeView";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnSaveCode;
        private System.Windows.Forms.Button btnCloseCodeView;
        private System.Windows.Forms.RichTextBox rtbxcodeView;
    }
}