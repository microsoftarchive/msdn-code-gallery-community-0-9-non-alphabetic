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
using System.IO;
using System.Threading;

namespace TCPServer
{
    public partial class frmSyncTcpServer : Form
    {
        #region 变量
        // 申明变量
        private const int Port = 51388;
        private TcpListener tcpLister = null;
        private TcpClient tcpClient = null;
        IPAddress ipaddress;
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
        public frmSyncTcpServer()
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

            ipaddress = IPAddress.Loopback;
            tbxserverIp.Text = ipaddress.ToString();
            tbxPort.Text = Port.ToString();
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
            tbxMessage.Text = string.Empty;
            tbxMessage.Focus();
        }

        #endregion 
        #region Click事件
        // 开始监听
        private void btnStart_Click(object sender, EventArgs e)
        {
           
            tcpLister = new TcpListener(ipaddress,Port);
            tcpLister.Start();
            // 启动一个线程来接受请求
            Thread acceptThread =new Thread(acceptClientConnect);
            acceptThread.Start();
        }

        // 接受请求
        private void acceptClientConnect()
        {
            statusStripInfo.Invoke(showStatusCallBack,"正在监听");
            Thread.Sleep(1000);
            try
            {
                statusStripInfo.Invoke(showStatusCallBack,"等待连接");
                tcpClient = tcpLister.AcceptTcpClient();
                if (tcpLister != null)
                {
                    statusStripInfo.Invoke(showStatusCallBack,"接受到连接");
                    networkStream = tcpClient.GetStream();
                    reader = new BinaryReader(networkStream);
                    writer = new BinaryWriter(networkStream);
                }
            }
            catch
            {
                statusStripInfo.Invoke(showStatusCallBack, "停止监听");
                Thread.Sleep(1000);
                statusStripInfo.Invoke(showStatusCallBack, "就绪");
            }
        }

        // 关闭监听
        private void btnStop_Click(object sender, EventArgs e)
        {
            tcpLister.Stop();
        }

        // 清空消息
        private void btnClear_Click(object sender, EventArgs e)
        {
            lstbxMessageView.Items.Clear();
        }
         // 接受消息
        private void btnReceive_Click(object sender, EventArgs e)
        {
            statusStripInfo.Invoke(showStatusCallBack, "接受消息中");
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
                // 重新开启一个线程等待新的连接
                Thread acceptThread = new Thread(acceptClientConnect);
                acceptThread.Start();
            }
        }

       // 发送消息
        private void btnSend_Click(object sender, EventArgs e)
        {
            Thread sendThread = new Thread(SendMessage);
            sendThread.Start(tbxMessage.Text);        
        }

        // 发送消息
        private void SendMessage(object state)
        {
            statusStripInfo.Invoke(showStatusCallBack, "正在发送");
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
                // 重新开启一个线程等待新的连接
                Thread acceptThread = new Thread(acceptClientConnect);
                acceptThread.Start();
            }
        }

        private void button1_Click(object sender, EventArgs e)
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

            // 启动一个线程等待接受新的请求
            Thread acceptThread = new Thread(acceptClientConnect);
            acceptThread.Start();
        }
        #endregion 

      
    }
}
