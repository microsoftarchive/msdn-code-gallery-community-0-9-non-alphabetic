using System.Collections.Generic;
using SignalRChatRoom.Models;

namespace SignalRChatRoom
{
    /// <summary>
    /// 上下文类，用来模拟EF中的DbContext
    /// </summary>
    public class ChatContext
    {
        public List<User> Users { get; set; }

        public List<Connection> Connections { get; set; }

        public List<ChatRoom> Rooms { get; set; }

        public ChatContext()
        {
            Users = new List<User>();
            Connections = new List<Connection>();
            Rooms = new List<ChatRoom>();
        }
    }
}