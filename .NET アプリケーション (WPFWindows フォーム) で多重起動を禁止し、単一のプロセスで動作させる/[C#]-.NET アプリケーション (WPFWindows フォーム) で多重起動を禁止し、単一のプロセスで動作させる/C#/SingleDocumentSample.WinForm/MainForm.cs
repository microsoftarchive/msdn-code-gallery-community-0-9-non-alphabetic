using System;
using System.Drawing;
using System.Windows.Forms;

namespace SingleDocumentSample.WinForm
{
    class MainForm : Form
    {
        readonly WebBrowser browser;

        public string DocumentPath
        {
            set {
                browser.Navigate(new Uri(value, UriKind.RelativeOrAbsolute));
                Text = value;
                ToTop();
            }
        }

        public MainForm()
        {
            SuspendLayout();
            ClientSize = new Size(500, 500);
            Text       = "SingleDocumentSampleWinForm";
            browser    = new WebBrowser { Dock = DockStyle.Fill };
            Controls.Add(browser);
            ResumeLayout(false);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
                browser.Dispose();
            base.Dispose(disposing);
        }

        // ウィンドウを最前面に表示
        void ToTop()
        {
            if (WindowState == FormWindowState.Minimized)
                WindowState = FormWindowState.Normal;
            Activate();
        }
    }
}
