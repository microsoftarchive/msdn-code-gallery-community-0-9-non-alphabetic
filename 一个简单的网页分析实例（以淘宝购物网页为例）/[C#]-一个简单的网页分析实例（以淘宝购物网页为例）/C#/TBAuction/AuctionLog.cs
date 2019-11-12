using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace TBAuction
{
    class AuctionLog
    {
        StringBuilder logText;
        LogForm logForm;
        bool isShow;

        public AuctionLog(bool isShow)
        {
            this.logText = new StringBuilder();
            this.logForm = new LogForm();
            this.isShow = isShow;
        }
        
        public void Log(string content)
        {
            logText.Append(content + "\r\n");
            logForm.logBox.Text += content + "\r\n";
            //logForm.Refresh();
        }

        public void WriteToFile()
        {
            FileStream outfile = File.Create("d:\\log.txt");
            StreamWriter sw = new StreamWriter(outfile, Encoding.Default);
            sw.Write(logText.ToString());
            sw.Close();
        }

        public void SetShow(bool isShow)
        {
            this.isShow = isShow;
        }

        public void ShowForm()
        {
            if (isShow)
            {
                logForm.Show();
            }
        }

        public void ShowFormForce()
        {
            logForm.Show();
        }

        public void ShowTextInForm(string address, string content)
        {
            if (isShow)
            {
                LogForm lf = new LogForm();
                lf.Text = address;
                lf.logBox.Text = content;
                lf.Show();
            }
        }
    }
}
