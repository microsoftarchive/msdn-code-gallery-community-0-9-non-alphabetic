# 使用SignalR实现消息提醒
## Requires
- Visual Studio 2013
## License
- MIT
## Technologies
- HTML5
- SignalR
## Topics
- HTML5
- SignalR
## Updated
- 04/10/2016
## Description

<h1>介绍</h1>
<p>使用SignalR实现消息提醒。</p>
<p><span style="font-size:20px"><strong>描述</strong></span></p>
<p><span><span style="white-space:pre"></span>Asp.net SignalR是微软为实现实时通信的一个类库。一般情况下，SignalR会使用JavaScript的长轮询(long polling)的方式来实现客户端和服务器通信，随着Html5中WebSockets出现，SignalR也支持WebSockets通信。另外SignalR开发的程序不仅仅限制于宿主在IIS中，也可以宿主在任何应用程序，包括控制台，客户端程序和Windows服务等，另外还支持Mono，这意味着它可以实现跨平台部署在Linux环境下。</span></p>
<p><span>SignalR内部有两类对象：</span></p>
<ol>
<li><span>Http持久连接(Persisten Connection)对象：用来解决长时间连接的功能。还可以由客户端主动向服务器要求数据，而服务器端不需要实现太多细节，只需要处理PersistentConnection 内所提供的五个事件：OnConnected, OnReconnected, OnReceived, OnError 和 OnDisconnect 即可。</span>
</li><li><span>Hub（集线器）对象：用来解决实时(realtime)信息交换的功能，服务端可以利用URL来注册一个或多个Hub，只要连接到这个Hub，就能与所有的客户端共享发送到服务器上的信息，同时服务端可以调用客户端的脚本。</span>
</li></ol>
<p><span>SignalR将整个信息的交换封装起来，客户端和服务器都是使用JSON来沟通的，在服务端声明的所有Hub信息，都会生成JavaScript输出到客户端，.NET则依赖Proxy来生成代理对象，而Proxy的内部则是将JSON转换成对象。</span></p>
<p><span>消息提醒也就是当客户有新消息来时，在客户端的右下角进行弹框提醒。要实现这个功能的思路是：</span></p>
<ol>
<li><span>SignalR服务端推送消息到客户端的实现方式为调用客户端的receiveMessage方法来将消息附加到聊天记录内，所以我们可以在客户端的receiveMessage方法中实现弹框的逻辑。</span>
</li><li><span>找好了方法定义的位置后，自然是去找一个比较好的弹框效果JS类库了，这里使用的是iNotify库来实现的。该库的github地址为：<a href="https://github.com/jaywcjlove/iNotify" target="_blank">https://github.com/jaywcjlove/iNotify</a>，在线测试地址为：<a href="http://jslite.io/iNotify/" target="_blank">http://jslite.io/iNotify/</a></span>
</li><li><span>你看QQ或者微信的消息提醒，消息提醒一般是在你不在聊天的当前Tab页面才会弹出，我们可以利用Html5&nbsp;visibilitychange事件来实现，不过我这里是通过失焦点的方式，也就是focus事件。</span>
</li></ol>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>JavaScript</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">编辑脚本</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">js</span>

<div class="preview">
<pre class="js">&nbsp;<span class="js__sl_comment">//&nbsp;接收消息</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;systemHub.client.receivePrivateMessage&nbsp;=&nbsp;<span class="js__operator">function</span>(fromUserId,&nbsp;userName,&nbsp;message)&nbsp;<span class="js__brace">{</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__sl_comment">//&nbsp;专题二中的代码</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__sl_comment">//&nbsp;消息提醒的代码</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__statement">if</span>&nbsp;(active&nbsp;==&nbsp;false)&nbsp;<span class="js__brace">{</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__statement">var</span>&nbsp;iN&nbsp;=&nbsp;<span class="js__operator">new</span>&nbsp;iNotify(<span class="js__brace">{</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;effect:&nbsp;<span class="js__string">'flash'</span>,&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;interval:&nbsp;<span class="js__num">500</span>,&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;audio:&nbsp;<span class="js__brace">{</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;file:&nbsp;[<span class="js__string">'/Music/msg.mp3'</span>]&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">}</span>,&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;notification:&nbsp;<span class="js__brace">{</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;title:&nbsp;<span class="js__string">&quot;通知！&quot;</span>,&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;body:&nbsp;<span class="js__string">'您有一条新消息'</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">}</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">}</span>);&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;iN.setTitle(true).player();&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;iN.setFavicon(true).setTitle(true).notify();&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">}</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">}</span>;&nbsp;
<span class="js__brace">}</span>&nbsp;&nbsp;&nbsp;&nbsp;</pre>
</div>
</div>
</div>
