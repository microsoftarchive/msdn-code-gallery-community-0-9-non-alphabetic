using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Net;
using System.Net.Sockets;
using System.Threading;
using System.IO;

namespace TCPClient
{
    public partial class frmSyncTCPClient : Form
    {
        #region 变量
        // 申明变量
        private TcpClient tcpClient = null;
        private NetworkStream networkStream = null;
        private BinaryReader reader;
        private BinaryWriter writer;
        
        // 申明委托
        // 显示消息
        private delegate void ShowMessage(string str);
        private ShowMessage showMessageCallback;

        // 显示状态
        private delegate void ShowStatus(string str);
        private ShowStatus showStatusCallBack;
        
        // 清空消息
        private delegate void ResetMessage();
        private ResetMessage resetMessageCallBack;

        #endregion 

        public frmSyncTCPClient()
        {
            InitializeComponent();

            #region 实例化委托
            // 显示消息
            showMessageCallback = new ShowMessage(showMessage);

            // 显示状态
            showStatusCallBack = new ShowStatus(showStatus);       

            // 重置消息
            resetMessageCallBack = new ResetMessage(resetMessage);
            #endregion               
        }

        #region 定义回调函数

        // 显示消息
        private void showMessage(string str)
        {
            lstbxMessageView.Items.Add(tcpClient.Client.RemoteEndPoint);
            lstbxMessageView.Items.Add(str);
            lstbxMessageView.TopIndex = lstbxMessageView.Items.Count - 1;
        }

        // 显示状态
        private void showStatus(string str)
        {
            toolStripStatusInfo.Text = str;
        }
         
        // 清空消息
        private void resetMessage()
        {
            tbxMessage.Text = "";
            tbxMessage.Focus();
        }

        #endregion 

        #region 点击事件方法
        private void btnConnect_Click(object sender, EventArgs e)
        {
            // 通过一个线程发起请求,多线程
            Thread connectThread = new Thread(ConnectToServer);
            connectThread.Start();
        }

        // 连接服务器方法,建立连接的过程
        private void ConnectToServer()
        {
            try
            {
                // 调用委托
                statusStripInfo.Invoke(showStatusCallBack, "正在连接...");
                if (tbxserverIp.Text == string.Empty || tbxPort.Text == string.Empty)
                {
                    MessageBox.Show("请先输入服务器的IP地址和端口号");
                }

                IPAddress ipaddress = IPAddress.Parse(tbxserverIp.Text);
                tcpClient = new TcpClient();             
                tcpClient.Connect(ipaddress, int.Parse(tbxPort.Text));               
                
                // 延时操作
                Thread.Sleep(1000);
                if (tcpClient != null)
                {
                    statusStripInfo.Invoke(showStatusCallBack, "连接成功");
                    networkStream = tcpClient.GetStream();
                    reader = new BinaryReader(networkStream);
                    writer =new BinaryWriter(networkStream);
                }
                 

            }
            catch
            {
                statusStripInfo.Invoke(showStatusCallBack,"连接失败");
                Thread.Sleep(1000);
                statusStripInfo.Invoke(showStatusCallBack,"就绪");
            }
        }

        // 接受消息
        private void btnReceive_Click(object sender, EventArgs e)
        {
            Thread receiveThread = new Thread(receiveMessage);
            receiveThread.Start();
        }
        // 接受消息
        private void receiveMessage()
        {
            statusStripInfo.Invoke(showStatusCallBack,"接受中");
            try
            {

                string receivemessage = reader.ReadString();
                lstbxMessageView.Invoke(showMessageCallback, receivemessage);
            }
            catch
            {
                if (reader != null)
                {
                    reader.Close();
                }
                if (writer != null)
                {
                    writer.Close();
                }
                if (tcpClient != null)
                {
                    tcpClient.Close();
                }

                statusStripInfo.Invoke(showStatusCallBack, "断开了连接");
            }
        }

        // 断开连接
        private void btnDisconnect_Click(object sender, EventArgs e)
        {
            if (reader != null)
            {
                reader.Close();
            }
            if (writer != null)
            {
                writer.Close();
            }
            if (tcpClient != null)
            {
                // 断开连接
                tcpClient.Close();
            }

            toolStripStatusInfo.Text = "断开连接";
        }

        // 关闭窗口
        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        // 发送消息
        private void btnSend_Click(object sender, EventArgs e)
        {
            Thread sendThread = new Thread(SendMessage);
            sendThread.Start(tbxMessage.Text);
        }

        private void SendMessage(object state)
        {
            statusStripInfo.Invoke(showStatusCallBack, "正在发送...");
            try
            {
                writer.Write(state.ToString());
                Thread.Sleep(5000);
                writer.Flush();
                statusStripInfo.Invoke(showStatusCallBack, "完毕");

                tbxMessage.Invoke(resetMessageCallBack, null);
                lstbxMessageView.Invoke(showMessageCallback, state.ToString());
            }
            catch
            {
                if (reader != null)
                {
                    reader.Close();
                }
                if (writer != null)
                {
                    writer.Close();
                }
                if (tcpClient != null)
                {
                    tcpClient.Close();
                }

                statusStripInfo.Invoke(showStatusCallBack, "断开了连接");
            }
        }
        
        // 清空消息
        private void btnClear_Click(object sender, EventArgs e)
        {
            lstbxMessageView.Items.Clear();
        }

        #endregion
    }
}
