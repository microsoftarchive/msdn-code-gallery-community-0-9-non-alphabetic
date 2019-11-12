# 使用SignalR实现Web聊天室功能
## Requires
- Visual Studio 2013
## License
- MIT
## Technologies
- SignalR
## Topics
- SignalR
## Updated
- 04/09/2016
## Description

<h1>介绍</h1>
<p>使用Asp.net SignalR实现Web聊天室功能</p>
<p><span style="font-size:20px"><strong>描述</strong></span></p>
<p><span><span style="white-space:pre"></span>Asp.net SignalR是微软为实现实时通信的一个类库。一般情况下，SignalR会使用JavaScript的长轮询(long polling)的方式来实现客户端和服务器通信，随着Html5中WebSockets出现，SignalR也支持WebSockets通信。另外SignalR开发的程序不仅仅限制于宿主在IIS中，也可以宿主在任何应用程序，包括控制台，客户端程序和Windows服务等，另外还支持Mono，这意味着它可以实现跨平台部署在Linux环境下。</span></p>
<p><span>SignalR内部有两类对象：</span></p>
<ol>
<li><span>Http持久连接(Persisten Connection)对象：用来解决长时间连接的功能。还可以由客户端主动向服务器要求数据，而服务器端不需要实现太多细节，只需要处理PersistentConnection 内所提供的五个事件：OnConnected, OnReconnected, OnReceived, OnError 和 OnDisconnect 即可。</span>
</li><li><span>Hub（集线器）对象：用来解决实时(realtime)信息交换的功能，服务端可以利用URL来注册一个或多个Hub，只要连接到这个Hub，就能与所有的客户端共享发送到服务器上的信息，同时服务端可以调用客户端的脚本。</span>
</li></ol>
<p><span>SignalR将整个信息的交换封装起来，客户端和服务器都是使用JSON来沟通的，在服务端声明的所有Hub信息，都会生成JavaScript输出到客户端，.NET则依赖Proxy来生成代理对象，而Proxy的内部则是将JSON转换成对象。</span></p>
<p><span><span style="white-space:pre"></span>要想实现群聊的功能，首先我们需要创建一个房间，然后每个在线用户可以加入这个房间里面进行群聊，我们可以为房间设置一个唯一的名字来作为标识。那SignalR类库里面是否有这样现有的方法呢？答案是肯定的。</span></p>
<p><span></p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>C#</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">编辑脚本</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">csharp</span>

<div class="preview">
<pre class="csharp"><span class="cs__com">//&nbsp;IGroupManager接口提供如下方法</span>&nbsp;
<span class="cs__com">//&nbsp;作用:将连接ID加入某个组</span>&nbsp;
<span class="cs__com">//&nbsp;Context.ConnectionId&nbsp;连接ID,每个页面连接集线器即会产生唯一ID</span>&nbsp;
<span class="cs__com">//&nbsp;roomName分组的名称</span>&nbsp;
Groups.Add(Context.ConnectionId,&nbsp;roomName);&nbsp;
&nbsp;
<span class="cs__com">//&nbsp;作用:将连接ID从某个分组移除</span>&nbsp;
Groups.Remove(Context.ConnectionId,&nbsp;roomName);&nbsp;
&nbsp;
<span class="cs__com">//&nbsp;IHubConnectionContext接口提供了如下方法</span>&nbsp;
<span class="cs__com">//&nbsp;调用客户端方法向房间内所有用户群发消息&nbsp;</span>&nbsp;
<span class="cs__com">//&nbsp;Room:分组名称</span>&nbsp;
<span class="cs__com">//&nbsp;new&nbsp;string[0]:过滤(不发送)的连接ID数组</span>&nbsp;
&nbsp;Clients.Group(Room,&nbsp;<span class="cs__keyword">new</span>&nbsp;<span class="cs__keyword">string</span>[<span class="cs__number">0</span>]).clientMethod</pre>
</div>
</div>
</div>
</span>
<p></p>
<p><span><span style="white-space:pre"></span>上面的代码也就是实现群聊的核心方法。Groups对象说白了也就是SignalR类库维护的一个列表对象而已，其实我们完全可以自己来维护一个Dictionary&lt;string, List&lt;string&gt;&gt;这个对象，创建一个房间的时候，我们将房间名称和进入房间的客户端的ConnectionId加入到这个字典里面，然后在聊天室里面点发送消息的时候，我们根据房间名查找到所有加入群聊的ConnectionId，然后调用Clients.Clients(IList&lt;string&gt;
 connectionIds)方法来将消息群发到每个客户端。以上也就是实现聊天室的原理。</span></p>
