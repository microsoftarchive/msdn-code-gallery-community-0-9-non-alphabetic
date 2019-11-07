using System;
using System.Windows.Forms;

namespace WebBrowser
{
    partial class frmAboutbox : Form
    {
        public frmAboutbox()
        {
            InitializeComponent();
            this.Text = "关于自定义浏览器";
            this.labelProductName.Text = "自定义Web浏览器 demo版";
            this.labelVersion.Text = String.Format("版本 {0}", "V1.0");
            this.labelCopyright.Text = "Copyright(C) 2012 SelfDefineWare Corp";
            this.labelCompanyName.Text = "自定义工作室";
            this.textBoxDescription.Text = "基于.NET平台下的自定义Web浏览器，提供了网页浏览、保存网页、搜索、查看源码等功能";
        }

        // 点击OK按钮
        private void okButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
