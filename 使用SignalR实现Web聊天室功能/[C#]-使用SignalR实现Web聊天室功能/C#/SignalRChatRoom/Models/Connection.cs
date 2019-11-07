namespace SignalRChatRoom.Models
{
    public class Connection
    {
        //连接ID
        public string ConnectionId { get; set; }

        //用户代理
        public string UserAgent { get; set; }
        //是否连接
        public bool Connected { get; set; } 
    }
}