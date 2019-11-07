using System;
using System.ComponentModel;
using System.Drawing;
using System.IO;
using System.Net;
using System.Text;
using System.Windows.Forms;

namespace WebBrowser
{
    /// <summary>
    /// 浏览器主页面
    /// 本浏览器主要实现了网页浏览，百度搜索，保存网页和查看网页Html源码的功能
    /// </summary>
    public partial class FrmMain : Form
    {
        public FrmMain(string url)
        {
            InitializeComponent();
            if (url == string.Empty)
            {
                // 指定一个主页
                this.pageWebBrowser.Navigate("http://www.cnblogs.com");
                urlAddress.Text = "http://www.cnblogs.com";
                this.AddItem_urlAddress();
            }
            else
            {
                this.pageWebBrowser.Navigate(url);
            }
            
            Rectangle rect = SystemInformation.WorkingArea;
            this.Size = new Size(rect.Width, rect.Height);
            this.Left = rect.X;
            this.Top = rect.Y;

            //根据屏幕大小设置窗体最大化大小 
            this.MaximizedBounds = new Rectangle(rect.X + 30, rect.Y + 40, rect.Width - 100, rect.Height - 200);
        }

        #region 基本功能
        // 后退
        private void pageBack_Click(object sender, EventArgs e)
        {
            this.pageWebBrowser.GoBack();
        }

        // 前进
        private void pageForward_Click(object sender, EventArgs e)
        {
            this.pageWebBrowser.GoForward();
        }

        // 刷新
        private void pageRefresh_Click(object sender, EventArgs e)
        {
            this.pageWebBrowser.Refresh();
        }

        // 主页
        private void pageHome_Click(object sender, EventArgs e)
        {
            this.pageWebBrowser.GoHome();
        }

        // 主菜单的功能与工具栏上的对应按钮关联
         private void menuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            switch (toolStrip1.Items.IndexOf(e.ClickedItem))
            {
                case 0:
                    pageSave.PerformClick();
                    break;
                case 1:
                    pageBack.PerformClick();
                    break;
                case 2:
                    pageForward.PerformClick();
                    break;
                case 3:
                    pageRefresh.PerformClick();
                    break;
                case 4:
                    pageHome.PerformClick();
                    break;
                default:
                    toolStripStatusView.Text ="正在打开网页 "+urlAddress.Text+"...";
                    pageWebBrowser.Navigate(urlAddress.Text);
                    AddItem_urlAddress();
                    break;
            }
        }

        // 保存
        private void pageSave_Click(object sender, EventArgs e)
        {
            this.pageWebBrowser.ShowSaveAsDialog();
        }

        // 退出
        private void browserExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        // 单击简体中文按钮
        private void gb2312Encode_Click(object sender, EventArgs e)
        {
            // 显示网页源码的对话框显示出来
            FrmCodeView dialogCodeView = new FrmCodeView();
            dialogCodeView.Text = "网页源码（采用GB2312编码)";
            dialogCodeView.Show();

            // 把网页源码显示在弹出的窗口中
            // 首先解码
            StreamReader reader = new StreamReader(pageWebBrowser.DocumentStream, Encoding.GetEncoding("GB2312"));
            dialogCodeView.setCode = reader.ReadToEnd();
            reader.Close();
        }

        // 
        private void unicodeUTF8ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmCodeView dialogCodeView = new FrmCodeView();
            dialogCodeView.Text = "网页源码(采用UTF-8编码)";
            dialogCodeView.Show();

            StreamReader reader = new StreamReader(pageWebBrowser.DocumentStream, Encoding.UTF8);
            dialogCodeView.setCode = reader.ReadToEnd();
            reader.Close();
        }

        // 点击搜索按钮
        // 这里调用了百度的搜索引擎
        private void toolbtnbaiduSearch_Click(object sender, EventArgs e)
        {
            Encoding utf8encoding = Encoding.UTF8;
            string uri = "http://www.baidu.com/s?wd=" + System.Web.HttpUtility.UrlEncode(tooltbxKeyword.Text, utf8encoding);
          
            HttpWebRequest request = (HttpWebRequest)HttpWebRequest.Create(uri);
            HttpWebResponse response = (HttpWebResponse)request.GetResponse();
            Stream stream = response.GetResponseStream();
            StreamReader readerstream = new StreamReader(stream, utf8encoding);
            pageWebBrowser.DocumentText = readerstream.ReadToEnd();
            readerstream.Close();
            stream.Close();
            urlAddress.Text = uri;
            AddItem_urlAddress();
        }

        // 点击关于按钮后显示关于窗口
        private void browserHelp_Click(object sender, EventArgs e)
        {
            frmAboutbox aboutBox = new frmAboutbox();
            aboutBox.Show();
        }

        #endregion 

        #region WebBrowser事件
        // 单击程序中某个链接后会打开新窗口，此时就会执行NewWinow事件中的代码
        // 通过此事件中的代码将打开新窗口中内容添加到本软件的webBrowser控件中显示
        // 实现网页用我们自定义的浏览器显示
        private void pageWebBrowser_NewWindow(object sender, CancelEventArgs e)
        {
            string newURL = pageWebBrowser.StatusText;
            FrmMain newform = new FrmMain(newURL);
            newform.toolStripStatusView.Text = "正在打开网页 " + newURL + "...";
            newform.Show();
            // 使其他浏览器无法捕获此事件
            // 阻止了其他浏览器显示网页，而是采用我们自定义的浏览器来显示
            e.Cancel = true;
        }

        private void pageWebBrowser_DocumentCompleted(object sender, WebBrowserDocumentCompletedEventArgs e)
        {
            urlAddress.Text = pageWebBrowser.Url.ToString();
            this.Text = pageWebBrowser.DocumentTitle;
            toolStripStatusView.Text = "完毕";
        }

        #endregion

        #region 附加功能

        // 自定义添加地址，记录历史URL的gongn
        private void AddItem_urlAddress()
        {
            int AddressIndex = urlAddress.FindStringExact(urlAddress.Text);
            // 没有找到存在这样的Url时
            // 就把该URL添加到地址栏下面
            if (AddressIndex < 0)
            {
                urlAddress.Items.Add(urlAddress.Text);
            }
        }

        // 实现回车操作
        // 输入URL回车
        private void urlAddress_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                toolStripStatusView.Text = "正在打开网页 " + urlAddress.Text + "...";
                pageWebBrowser.Navigate(urlAddress.Text);
                AddItem_urlAddress();
            }
        }

        private void tooltbxKeyword_KeyPress(object sender, KeyPressEventArgs e)
        {
            // 输入关键字后回车触发搜索按钮事件执行
            if (e.KeyChar == (char)Keys.Enter)
            {
                toolbtnbaiduSearch.PerformClick();
            }
        }

        // 使浏览器显示的页面随用户选择网址栏中的地址而更新
        private void urlAddress_SelectedIndexChanged(object sender, EventArgs e)
        {
            pageWebBrowser.Navigate(urlAddress.Text);
        }
        #endregion
    }
}
