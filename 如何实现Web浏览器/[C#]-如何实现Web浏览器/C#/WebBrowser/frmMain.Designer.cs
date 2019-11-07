namespace WebBrowser
{
    partial class FrmMain
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmMain));
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.文件ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.pageSave = new System.Windows.Forms.ToolStripMenuItem();
            this.browserExit = new System.Windows.Forms.ToolStripMenuItem();
            this.查看ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.转到ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.pageBack = new System.Windows.Forms.ToolStripMenuItem();
            this.pageForward = new System.Windows.Forms.ToolStripMenuItem();
            this.pageHome = new System.Windows.Forms.ToolStripMenuItem();
            this.pageRefresh = new System.Windows.Forms.ToolStripMenuItem();
            this.源文件ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.gb2312Encode = new System.Windows.Forms.ToolStripMenuItem();
            this.unicodeUTF8ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.帮助ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.browserHelp = new System.Windows.Forms.ToolStripMenuItem();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusView = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.toolStripSave = new System.Windows.Forms.ToolStripButton();
            this.toolStripBack = new System.Windows.Forms.ToolStripButton();
            this.toolStripForward = new System.Windows.Forms.ToolStripButton();
            this.toolStripRefresh = new System.Windows.Forms.ToolStripButton();
            this.toolStipHome = new System.Windows.Forms.ToolStripButton();
            this.urlAddress = new System.Windows.Forms.ToolStripComboBox();
            this.pagePlay = new System.Windows.Forms.ToolStripButton();
            this.tooltbxKeyword = new System.Windows.Forms.ToolStripTextBox();
            this.toolbtnbaiduSearch = new System.Windows.Forms.ToolStripButton();
            this.pageWebBrowser = new System.Windows.Forms.WebBrowser();
            this.menuStrip1.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            this.toolStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.文件ToolStripMenuItem,
            this.查看ToolStripMenuItem,
            this.帮助ToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(713, 24);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // 文件ToolStripMenuItem
            // 
            this.文件ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.pageSave,
            this.browserExit});
            this.文件ToolStripMenuItem.Name = "文件ToolStripMenuItem";
            this.文件ToolStripMenuItem.Size = new System.Drawing.Size(43, 20);
            this.文件ToolStripMenuItem.Text = "文件";
            // 
            // pageSave
            // 
            this.pageSave.Name = "pageSave";
            this.pageSave.Size = new System.Drawing.Size(160, 22);
            this.pageSave.Text = "保存[S]     Ctrl+S";
            this.pageSave.Click += new System.EventHandler(this.pageSave_Click);
            // 
            // browserExit
            // 
            this.browserExit.Name = "browserExit";
            this.browserExit.Size = new System.Drawing.Size(160, 22);
            this.browserExit.Text = "退出";
            this.browserExit.Click += new System.EventHandler(this.browserExit_Click);
            // 
            // 查看ToolStripMenuItem
            // 
            this.查看ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.转到ToolStripMenuItem,
            this.pageRefresh,
            this.源文件ToolStripMenuItem});
            this.查看ToolStripMenuItem.Name = "查看ToolStripMenuItem";
            this.查看ToolStripMenuItem.Size = new System.Drawing.Size(43, 20);
            this.查看ToolStripMenuItem.Text = "查看";
            // 
            // 转到ToolStripMenuItem
            // 
            this.转到ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.pageBack,
            this.pageForward,
            this.pageHome});
            this.转到ToolStripMenuItem.Name = "转到ToolStripMenuItem";
            this.转到ToolStripMenuItem.Size = new System.Drawing.Size(125, 22);
            this.转到ToolStripMenuItem.Text = "转到";
            // 
            // pageBack
            // 
            this.pageBack.Name = "pageBack";
            this.pageBack.Size = new System.Drawing.Size(98, 22);
            this.pageBack.Text = "后退";
            this.pageBack.Click += new System.EventHandler(this.pageBack_Click);
            // 
            // pageForward
            // 
            this.pageForward.Name = "pageForward";
            this.pageForward.Size = new System.Drawing.Size(98, 22);
            this.pageForward.Text = "前进";
            this.pageForward.Click += new System.EventHandler(this.pageForward_Click);
            // 
            // pageHome
            // 
            this.pageHome.Name = "pageHome";
            this.pageHome.Size = new System.Drawing.Size(98, 22);
            this.pageHome.Text = "主页";
            this.pageHome.Click += new System.EventHandler(this.pageHome_Click);
            // 
            // pageRefresh
            // 
            this.pageRefresh.Name = "pageRefresh";
            this.pageRefresh.Size = new System.Drawing.Size(125, 22);
            this.pageRefresh.Text = "刷新     F5";
            this.pageRefresh.Click += new System.EventHandler(this.pageRefresh_Click);
            // 
            // 源文件ToolStripMenuItem
            // 
            this.源文件ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.gb2312Encode,
            this.unicodeUTF8ToolStripMenuItem});
            this.源文件ToolStripMenuItem.Name = "源文件ToolStripMenuItem";
            this.源文件ToolStripMenuItem.Size = new System.Drawing.Size(125, 22);
            this.源文件ToolStripMenuItem.Text = "源文件";
            // 
            // gb2312Encode
            // 
            this.gb2312Encode.Name = "gb2312Encode";
            this.gb2312Encode.Size = new System.Drawing.Size(169, 22);
            this.gb2312Encode.Text = "简体中文(GB2312)";
            this.gb2312Encode.Click += new System.EventHandler(this.gb2312Encode_Click);
            // 
            // unicodeUTF8ToolStripMenuItem
            // 
            this.unicodeUTF8ToolStripMenuItem.Name = "unicodeUTF8ToolStripMenuItem";
            this.unicodeUTF8ToolStripMenuItem.Size = new System.Drawing.Size(169, 22);
            this.unicodeUTF8ToolStripMenuItem.Text = "Unicode(UTF-8)";
            this.unicodeUTF8ToolStripMenuItem.Click += new System.EventHandler(this.unicodeUTF8ToolStripMenuItem_Click);
            // 
            // 帮助ToolStripMenuItem
            // 
            this.帮助ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.browserHelp});
            this.帮助ToolStripMenuItem.Name = "帮助ToolStripMenuItem";
            this.帮助ToolStripMenuItem.Size = new System.Drawing.Size(43, 20);
            this.帮助ToolStripMenuItem.Text = "帮助";
            // 
            // browserHelp
            // 
            this.browserHelp.Name = "browserHelp";
            this.browserHelp.Size = new System.Drawing.Size(98, 22);
            this.browserHelp.Text = "关于";
            this.browserHelp.Click += new System.EventHandler(this.browserHelp_Click);
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusView});
            this.statusStrip1.Location = new System.Drawing.Point(0, 647);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(713, 22);
            this.statusStrip1.TabIndex = 1;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // toolStripStatusView
            // 
            this.toolStripStatusView.Name = "toolStripStatusView";
            this.toolStripStatusView.Size = new System.Drawing.Size(118, 17);
            this.toolStripStatusView.Text = "toolStripStatusLabel1";
            // 
            // toolStrip1
            // 
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripSave,
            this.toolStripBack,
            this.toolStripForward,
            this.toolStripRefresh,
            this.toolStipHome,
            this.urlAddress,
            this.pagePlay,
            this.tooltbxKeyword,
            this.toolbtnbaiduSearch});
            this.toolStrip1.Location = new System.Drawing.Point(0, 24);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(713, 28);
            this.toolStrip1.TabIndex = 2;
            this.toolStrip1.Text = "toolStrip1";
            this.toolStrip1.ItemClicked += new System.Windows.Forms.ToolStripItemClickedEventHandler(this.menuStrip1_ItemClicked);
            // 
            // toolStripSave
            // 
            this.toolStripSave.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripSave.Image = ((System.Drawing.Image)(resources.GetObject("toolStripSave.Image")));
            this.toolStripSave.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripSave.Name = "toolStripSave";
            this.toolStripSave.Size = new System.Drawing.Size(23, 25);
            this.toolStripSave.Text = "toolStripButton1";
            this.toolStripSave.Click += new System.EventHandler(this.pageSave_Click);
            // 
            // toolStripBack
            // 
            this.toolStripBack.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripBack.Image = ((System.Drawing.Image)(resources.GetObject("toolStripBack.Image")));
            this.toolStripBack.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripBack.Name = "toolStripBack";
            this.toolStripBack.Size = new System.Drawing.Size(23, 25);
            this.toolStripBack.Text = "toolStripButton2";
            this.toolStripBack.Click += new System.EventHandler(this.pageBack_Click);
            // 
            // toolStripForward
            // 
            this.toolStripForward.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripForward.Image = ((System.Drawing.Image)(resources.GetObject("toolStripForward.Image")));
            this.toolStripForward.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripForward.Name = "toolStripForward";
            this.toolStripForward.Size = new System.Drawing.Size(23, 25);
            this.toolStripForward.Text = "toolStripButton1";
            this.toolStripForward.Click += new System.EventHandler(this.pageForward_Click);
            // 
            // toolStripRefresh
            // 
            this.toolStripRefresh.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripRefresh.Image = ((System.Drawing.Image)(resources.GetObject("toolStripRefresh.Image")));
            this.toolStripRefresh.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripRefresh.Name = "toolStripRefresh";
            this.toolStripRefresh.Size = new System.Drawing.Size(23, 25);
            this.toolStripRefresh.Text = "toolStripButton1";
            this.toolStripRefresh.Click += new System.EventHandler(this.pageRefresh_Click);
            // 
            // toolStipHome
            // 
            this.toolStipHome.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStipHome.Image = ((System.Drawing.Image)(resources.GetObject("toolStipHome.Image")));
            this.toolStipHome.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStipHome.Name = "toolStipHome";
            this.toolStipHome.Size = new System.Drawing.Size(23, 25);
            this.toolStipHome.Text = "toolStripButton1";
            this.toolStipHome.Click += new System.EventHandler(this.pageHome_Click);
            // 
            // urlAddress
            // 
            this.urlAddress.Name = "urlAddress";
            this.urlAddress.Size = new System.Drawing.Size(300, 28);
            this.urlAddress.SelectedIndexChanged += new System.EventHandler(this.urlAddress_SelectedIndexChanged);
            this.urlAddress.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.urlAddress_KeyPress);
            // 
            // pagePlay
            // 
            this.pagePlay.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.pagePlay.Image = ((System.Drawing.Image)(resources.GetObject("pagePlay.Image")));
            this.pagePlay.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.pagePlay.Name = "pagePlay";
            this.pagePlay.Size = new System.Drawing.Size(23, 25);
            this.pagePlay.Text = "toolStripButton1";
            // 
            // tooltbxKeyword
            // 
            this.tooltbxKeyword.Name = "tooltbxKeyword";
            this.tooltbxKeyword.Size = new System.Drawing.Size(150, 28);
            this.tooltbxKeyword.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.tooltbxKeyword_KeyPress);
            // 
            // toolbtnbaiduSearch
            // 
            this.toolbtnbaiduSearch.AutoSize = false;
            this.toolbtnbaiduSearch.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolbtnbaiduSearch.Image = ((System.Drawing.Image)(resources.GetObject("toolbtnbaiduSearch.Image")));
            this.toolbtnbaiduSearch.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolbtnbaiduSearch.Name = "toolbtnbaiduSearch";
            this.toolbtnbaiduSearch.Size = new System.Drawing.Size(30, 25);
            this.toolbtnbaiduSearch.Text = "toolStripButton1";
            this.toolbtnbaiduSearch.Click += new System.EventHandler(this.toolbtnbaiduSearch_Click);
            // 
            // pageWebBrowser
            // 
            this.pageWebBrowser.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pageWebBrowser.Location = new System.Drawing.Point(0, 52);
            this.pageWebBrowser.MinimumSize = new System.Drawing.Size(20, 20);
            this.pageWebBrowser.Name = "pageWebBrowser";
            this.pageWebBrowser.Size = new System.Drawing.Size(713, 595);
            this.pageWebBrowser.TabIndex = 3;
            this.pageWebBrowser.DocumentCompleted += new System.Windows.Forms.WebBrowserDocumentCompletedEventHandler(this.pageWebBrowser_DocumentCompleted);
            this.pageWebBrowser.NewWindow += new System.ComponentModel.CancelEventHandler(this.pageWebBrowser_NewWindow);
            // 
            // FrmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(713, 669);
            this.Controls.Add(this.pageWebBrowser);
            this.Controls.Add(this.toolStrip1);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.menuStrip1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "FrmMain";
            this.Text = "自定义Web浏览器V1.1";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem 文件ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem pageSave;
        private System.Windows.Forms.ToolStripMenuItem browserExit;
        private System.Windows.Forms.ToolStripMenuItem 查看ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 转到ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem pageBack;
        private System.Windows.Forms.ToolStripMenuItem pageForward;
        private System.Windows.Forms.ToolStripMenuItem pageHome;
        private System.Windows.Forms.ToolStripMenuItem pageRefresh;
        private System.Windows.Forms.ToolStripMenuItem 源文件ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem gb2312Encode;
        private System.Windows.Forms.ToolStripMenuItem unicodeUTF8ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 帮助ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem browserHelp;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusView;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton toolStripSave;
        private System.Windows.Forms.ToolStripButton toolStripBack;
        private System.Windows.Forms.ToolStripButton toolStripForward;
        private System.Windows.Forms.ToolStripButton toolStripRefresh;
        private System.Windows.Forms.ToolStripButton toolStipHome;
        private System.Windows.Forms.ToolStripComboBox urlAddress;
        private System.Windows.Forms.ToolStripButton pagePlay;
        private System.Windows.Forms.ToolStripTextBox tooltbxKeyword;
        private System.Windows.Forms.ToolStripButton toolbtnbaiduSearch;
        private System.Windows.Forms.WebBrowser pageWebBrowser;
    }
}

