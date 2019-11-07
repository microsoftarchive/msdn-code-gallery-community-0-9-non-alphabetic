using System;
using System.IO;
using System.Text;
using System.Windows.Forms;

namespace WebBrowser
{
    public partial class FrmCodeView : Form
    {
        public FrmCodeView()
        {
            InitializeComponent();
        }

        // 存储器
        public string setCode    
        {
            set
            {
                this.rtbxcodeView.Text = value;
            }
        }

        // 保存源码
        private void btnSaveCode_Click(object sender, EventArgs e)
        {
            // 初始化保存对话框
            SaveFileDialog saveDialog = new SaveFileDialog();
            saveDialog.Filter = "文本文件(*.txt)|*.txt";
            if (saveDialog.ShowDialog() == DialogResult.OK)
            {
                StreamWriter writer = new StreamWriter(saveDialog.FileName, false, Encoding.UTF8);
                writer.Write(this.rtbxcodeView.Text);
                writer.Close();
            }
        }

        // 关闭窗口
        private void btnCloseCodeView_Click(object sender, EventArgs e)
        {
            this.Close();
        }


    }
}
