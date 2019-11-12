# 使用SignalR实现图片的发送功能
## Requires
- Visual Studio 2013
## License
- MIT
## Technologies
- SignalR
## Topics
- SignalR
## Updated
- 04/10/2016
## Description

<h1>介绍</h1>
<p><span>Asp.net SignalR是微软为实现实时通信的一个类库。一般情况下，SignalR会使用JavaScript的长轮询(long polling)的方式来实现客户端和服务器通信，随着Html5中WebSockets出现，SignalR也支持WebSockets通信。另外SignalR开发的程序不仅仅限制于宿主在IIS中，也可以宿主在任何应用程序，包括控制台，客户端程序和Windows服务等，另外还支持Mono，这意味着它可以实现跨平台部署在Linux环境下。</span></p>
<p><span>SignalR内部有两类对象：</span></p>
<ol>
<li><span>Http持久连接(Persisten Connection)对象：用来解决长时间连接的功能。还可以由客户端主动向服务器要求数据，而服务器端不需要实现太多细节，只需要处理PersistentConnection 内所提供的五个事件：OnConnected, OnReconnected, OnReceived, OnError 和 OnDisconnect 即可。</span>
</li><li><span>Hub（集线器）对象：用来解决实时(realtime)信息交换的功能，服务端可以利用URL来注册一个或多个Hub，只要连接到这个Hub，就能与所有的客户端共享发送到服务器上的信息，同时服务端可以调用客户端的脚本。</span>
</li></ol>
<p>由于SignalR传输都是基于文本形式的，那如何使用asp.net SignalR实现图片的发送呢？这个示例代码可以帮你解决图片传输的问题。</p>
<p><span style="font-size:20px"><strong>描述</strong></span></p>
<p><span>首先，让我们来理清下实现发送图片功能的思路。</span></p>
<p><span>图片的显示，除了直接指定图片的路径外（这种实现方式也称为：http URI schema)，还可以通过Data Uri Schema的方式来显示图片。这种方式允许在网页里以字符串形式直接内嵌图片。形式如下所示：<br>
</span></p>
<div class="cnblogs_code">
<pre><div class="scriptcode"><div class="pluginEditHolder" pluginCommand="mceScriptCode"><div class="title"><span>HTML</span></div><div class="pluginLinkHolder"><span class="pluginEditHolderLink">编辑脚本</span>|<span class="pluginRemoveHolderLink">Remove</span></div><span class="hidden">html</span>
<div class="preview">
<pre class="js">&lt;img&nbsp;src=&quot;data:image/png;base64,iVBORw0KGgoAAAANSUhEUgAAAAQAAAADCAIAAAA&nbsp;&nbsp;
7ljmRAAAAGElEQVQIW2P4DwcMDAxAfBvMAhEQMYgcACEHG8ELxtbPAAAAAElFTkSuQmCC&quot;&nbsp;/&gt;</pre>
</div>
</div>
</div>
</pre>
</div>
<p><span>上面代码的方式就是Data Url Schema方式来显示图片。关于Data Uri Schema的优缺点有：</span></p>
<ul>
<li><span>优点：</span> </li></ul>
<p><span>可以减少Http请求，因为如果你使用http Uri Schema去指定图片地址的话，这样客户端对每个图片都需要发出Http请求，通过使用Data Uri的方式可以节省带宽和Http请求</span></p>
<p><span>缺点：</span></p>
<ol>
<li><span>IE8以上的版本才支持，且限制大小不可超过32KB。</span> </li><li><span>另外Base64的内容会将图片的内容变大33%，但可以通过服务端启用GZIP压缩来减少增大内容。尽管这样，由于发送Http请求会附加很多额外的信息（如Http Header等），这样累计下来一般内容大小还是大于使用Base64编码所增加的内容。</span>
</li></ol>
<p><span>关于更多Data Uri的介绍可以参考百度百科：<a href="http://baike.baidu.com/link?url=nOIk91f0p3cYcBAA5qHNFqUjOTxgHwVkBZRjpr6eMZ0KCqZ26d3Dcn_H0Un74O4mjEevzYiAy81ZvNHkuwJBka" target="_blank">Data URI</a></span></p>
<p><span>因为SignalR是基于文本方式的传输，所以要实现图片的发送。</span></p>
<ol>
<li><span>只能通过发送图片的Base64编码的字符串到SignalR服务器，</span> </li><li><span>然后服务器再将该Base64字符串推送到需要接收图片的客户端，</span> </li><li><span>客户端再使用Data Uri的方式将图片显示在页面上，从而完成图片的传输。</span> </li></ol>
<p><span>当然你也可以像<a href="https://github.com/smoak/hubot-jabbr" target="_blank">Jabbr</a>（一个使用SignalR实现即时聊天的开源项目）那样将图片上传到Azure Bob Table中，然后再将Blob 的Uri 返回所有客户端来显示图片。其实这样的实现方式和我们这里实现类&#20284;，客户端可以通过blob的Uri来读取到图片来显示。总之实现思路就是将图片二进制文件的内容间接转换成文本的形式传输。</span></p>
<ul>
</ul>
<h1>更多信息参考</h1>
<p><a href="http://www.cnblogs.com/zhili/">http://www.cnblogs.com/zhili/</a></p>
