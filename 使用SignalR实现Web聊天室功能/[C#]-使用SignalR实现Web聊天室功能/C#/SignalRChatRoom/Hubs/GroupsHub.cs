using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using Microsoft.AspNet.SignalR;
using Microsoft.AspNet.SignalR.Hubs;
using SignalRChatRoom.Models;
using SignalRChatRoom.Serialization.Json;

namespace SignalRChatRoom.Hubs
{
    [HubName("chatRoomHub")]
    public class GroupsHub : Hub
    {
        public static ChatContext DbContext = new ChatContext();

        #region IHub Members
        // 重写Hub连接事件
        public override Task OnConnected()
        {
            // 查询用户
            var user = DbContext.Users.FirstOrDefault(u => u.UserId == Context.ConnectionId);

            if (user == null)
            {
                user = new User
                {
                    UserId = Context.ConnectionId
                };

                DbContext.Users.Add(user);
            }

            // 发送房间列表
            var items = DbContext.Rooms.Select(p => new {p.RoomName});
            Clients.Client(this.Context.ConnectionId).getRoomList(JsonHelper.ToJsonString(items.ToList()));
            return base.OnConnected();
        }

        // 重写Hub连接断开的事件
        public override Task OnDisconnected(bool stopCalled)
        {
            // 查询用户
            var user = DbContext.Users.FirstOrDefault(u => u.UserId == Context.ConnectionId);

            if (user != null)
            {
               // 删除用户
                DbContext.Users.Remove(user);

                // 从房间中移除用户
                foreach (var item in user.Rooms)
                {
                    RemoveUserFromRoom(item.RoomName);
                }
            }
            return base.OnDisconnected(stopCalled);
        }

        #endregion 

        #region Public Methods

        // 为所有用户更新房间列表
        public void UpdateRoomList()
        {
            var itme = DbContext.Rooms.Select(p => new {p.RoomName});
            var jsondata = JsonHelper.ToJsonString(itme.ToList());
            Clients.All.getRoomlist(jsondata);
        }

        /// <summary>
        /// 加入聊天室
        /// </summary>
        public void JoinRoom(string roomName)
        {
            // 查询聊天室
            var room = DbContext.Rooms.Find(p => p.RoomName == roomName);

            // 存在则加入
            if (room == null) return;

            // 查找房间中是否存在此用户
            var isExistUser = room.Users.FirstOrDefault(u => u.UserId == Context.ConnectionId);

            // 不存在则加入
            if (isExistUser == null)
            {
                var user = DbContext.Users.Find(u => u.UserId == Context.ConnectionId);
                user.Rooms.Add(room);
                room.Users.Add(user);
               
                // 将客户端的连接ID加入到组里面
                Groups.Add(Context.ConnectionId, roomName);

                //调用此连接用户的本地JS(显示房间)
                Clients.Client(Context.ConnectionId).joinRoom(roomName);
            }
            else
            {
                Clients.Client(Context.ConnectionId).showMessage("请勿重复加入房间!");
            }
        }

        /// <summary>
        /// 创建聊天室
        /// </summary>
        /// <param name="roomName"></param>
        public void CreateRoom(string roomName)
        {
            var room = DbContext.Rooms.Find(a => a.RoomName == roomName);
            if (room == null)
            {
                var cr = new ChatRoom
                {
                    RoomName = roomName
                };

                //将房间加入列表
                DbContext.Rooms.Add(cr);

                // 本人加入聊天室
                JoinRoom(roomName);
                UpdateRoomList();
            }
            else
            {
                Clients.Client(Context.ConnectionId).showMessage("房间名重复!");
            }
        }

        public void RemoveUserFromRoom(string roomName)
        {
            //查找房间是否存在
            var room = DbContext.Rooms.Find(a => a.RoomName == roomName);

            //存在则进入删除
            if (room == null)
            {
                Clients.Client(Context.ConnectionId).showMessage("房间名不存在!");
                return;
            }

            // 查找要删除的用户
            var user = room.Users.FirstOrDefault(a => a.UserId == Context.ConnectionId);
            // 移除此用户
            room.Users.Remove(user);
            //如果房间人数为0,则删除房间
            if (room.Users.Count <= 0)
            {
                DbContext.Rooms.Remove(room);
            }

            Groups.Remove(Context.ConnectionId, roomName);

            //提示客户端
            Clients.Client(Context.ConnectionId).removeRoom("退出成功!");
        }

        /// <summary>
        /// 给房间内所有的用户发送消息
        /// </summary>
        /// <param name="room">房间名</param>
        /// <param name="message">信息</param>
        public void SendMessage(string room, string message)
        {
            // 调用房间内所有客户端的sendMessage方法
            // 因为在加入房间的时候，已经将客户端的ConnectionId添加到Groups对象中了，所有可以根据房间名找到房间内的所有连接Id
            // 其实我们也可以自己实现Group方法，我们只需要用List记录所有加入房间的ConnectionId
            // 然后调用Clients.Clients(connectionIdList),参数为我们记录的连接Id数组。
            Clients.Group(room, new string[0]).sendMessage(room, message + " " + DateTime.Now);
        }
        #endregion 
    }
}