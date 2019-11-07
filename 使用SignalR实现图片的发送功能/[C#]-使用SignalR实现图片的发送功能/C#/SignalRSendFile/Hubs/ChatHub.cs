using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using System.Web.ModelBinding;
using Microsoft.AspNet.SignalR;

namespace SignalRSendFile.Hubs
{
    public class ChatHub : Hub
    {
        /// <summary>
        /// 供客户端调用的服务器端代码
        /// </summary>
        /// <param name="name"></param>
        /// <param name="message"></param>
        public void Send(string name,string message)
        {
            // 调用所有客户端的sendMessage方法
            Clients.All.sendMessage(name, message);
        }

        // 发送图片
        public void SendImage(string name,IEnumerable<ImageData> images)
        {
            foreach (var item in images ?? Enumerable.Empty<ImageData>())
            {
                if(String.IsNullOrEmpty(item.Image)) continue;
                Clients.All.receiveImage(name, item.Image); // 调用客户端receiveImage方法将图片进行显示
            }
        }

        /// <summary>
        /// 客户端连接的时候调用
        /// </summary>
        /// <returns></returns>
        public override Task OnConnected()
        {
            Trace.WriteLine("客户端连接成功");
            return base.OnConnected();
        }
    }

    public class ImageData
    {
        public string Description { get; set; }
        public string Filename { get; set; }
        public string Image { get; set; }
    }
}