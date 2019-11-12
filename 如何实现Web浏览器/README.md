# 如何实现Web浏览器
## Requires
- Visual Studio 2010
## License
- Apache License, Version 2.0
## Technologies
- WinForms
## Topics
- WebBrowser
- WinForms
## Updated
- 04/17/2013
## Description

<h1>简介</h1>
<p><span style="font-size:small">微软.NET平台封装了IE浏览器内核并以COM组件的形式提供用户，这个COM组件就是<strong>WebBrowser</strong>控件，该控件实现了浏览器中几乎全部的基本功能。</span></p>
<p><span style="font-size:small">WebBrowser就是一个以IE(Trident)为内核，实现了基本功能的Web浏览器。使用WebBrowser控件可以在Windows窗体应用程序中浏览网页，WebBrowser控件位于工具箱中，使用时只需要将它直接拖拉到程序窗口中。</span></p>
<p><span style="font-size:small">该示例演示了一个基于WebBrowser控件实现的一个简单的Web浏览器。该示例包括浏览器的基本功能&mdash;&mdash;浏览网页，后退，前进和主页的功能，并且在地址栏也实现了对用户输入地址的保存，让用户可以看到之前输入的网址，并且实现了一个搜索的功能。</span></p>
<h1>运行示例</h1>
<p><span style="font-size:small">第一步、打开&quot;WebBrowser.sln&quot;文件来打开项目解决方案, 按F5或Ctrl&#43;F5 来运行该示例，这时候你将看到下面的窗体：</span></p>
<p><img id="79981" src="79981-1.png" alt="" width="1259" height="519"></p>
<p><span style="font-size:small">第二步、你还可以通过查看菜单-&gt;源代码来查看网页的源码. 此时你将看到源代码窗体,你也可以保存源代码到本地.</span></p>
<p><img id="79982" src="79982-2.png" alt="" width="481" height="395"></p>
<p><span style="font-size:small">第三步、你同样可以像使用其他浏览器一样在地址栏输入地址然后按下Enter键或者点击旁边的运行按钮，此时你输入地址的网页将显示在自定义的浏览器窗口中。</span></p>
<p><span style="font-size:small">第四步、你可以在搜索输入框中输入你想搜索的关键字,此时页面将会显示搜索出来的结果.</span></p>
<p><img id="79984" src="79984-7.png" alt="" width="1259" height="514"></p>
<p><span style="font-size:small">第五步、你也可以点击帮助-&gt;关于按钮来查看本示例的介绍。</span></p>
<p><span style="font-size:20px"><strong>使用代码</strong></span></p>
<p><span style="font-size:small">第一步、创建一个WinForm 应用程序。</span></p>
<p><span style="font-size:small">第二步、从工具箱中拖WebBrowser控件到主界面中。</span></p>
<p><span style="font-size:small">第三步、实现浏览器的基本功能，如后退，前进，刷新,主页等功能。</span></p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>C#</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">编辑脚本</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">csharp</span>

<div class="preview">
<pre class="csharp">&nbsp;<span class="cs__com">//&nbsp;后退</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">private</span>&nbsp;<span class="cs__keyword">void</span>&nbsp;pageBack_Click(<span class="cs__keyword">object</span>&nbsp;sender,&nbsp;EventArgs&nbsp;e)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">this</span>.pageWebBrowser.GoBack();&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__com">//&nbsp;前进</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">private</span>&nbsp;<span class="cs__keyword">void</span>&nbsp;pageForward_Click(<span class="cs__keyword">object</span>&nbsp;sender,&nbsp;EventArgs&nbsp;e)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">this</span>.pageWebBrowser.GoForward();&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__com">//&nbsp;刷新</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">private</span>&nbsp;<span class="cs__keyword">void</span>&nbsp;pageRefresh_Click(<span class="cs__keyword">object</span>&nbsp;sender,&nbsp;EventArgs&nbsp;e)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">this</span>.pageWebBrowser.Refresh();&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__com">//&nbsp;主页</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">private</span>&nbsp;<span class="cs__keyword">void</span>&nbsp;pageHome_Click(<span class="cs__keyword">object</span>&nbsp;sender,&nbsp;EventArgs&nbsp;e)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">this</span>.pageWebBrowser.GoHome();&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;</pre>
</div>
</div>
</div>
<p><span style="font-size:small">第四步、为了用自定义的浏览器来对网页的显示，需要实现WebBrowser的NewWindow事件。</span></p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>C#</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">编辑脚本</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">csharp</span>

<div class="preview">
<pre class="csharp">&nbsp;<span class="cs__com">//&nbsp;单击程序中某个链接后会打开新窗口，此时就会执行NewWinow事件中的代码</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__com">//&nbsp;通过此事件中的代码将打开新窗口中内容添加到本软件的webBrowser控件中显示</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__com">//&nbsp;实现网页用我们自定义的浏览器显示</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">private</span>&nbsp;<span class="cs__keyword">void</span>&nbsp;pageWebBrowser_NewWindow(<span class="cs__keyword">object</span>&nbsp;sender,&nbsp;CancelEventArgs&nbsp;e)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">string</span>&nbsp;newURL&nbsp;=&nbsp;pageWebBrowser.StatusText;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;FrmMain&nbsp;newform&nbsp;=&nbsp;<span class="cs__keyword">new</span>&nbsp;FrmMain(newURL);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;newform.toolStripStatusView.Text&nbsp;=&nbsp;<span class="cs__string">&quot;正在打开网页&nbsp;&quot;</span>&nbsp;&#43;&nbsp;newURL&nbsp;&#43;&nbsp;<span class="cs__string">&quot;...&quot;</span>;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;newform.Show();&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__com">//&nbsp;使其他浏览器无法捕获此事件</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__com">//&nbsp;阻止了其他浏览器显示网页，而是采用我们自定义的浏览器来显示</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;e.Cancel&nbsp;=&nbsp;<span class="cs__keyword">true</span>;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}</pre>
</div>
</div>
</div>
<div class="endscriptcode">&nbsp;<span style="font-size:small">第五步、实现搜索功能</span></div>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>C#</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">编辑脚本</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">csharp</span>

<div class="preview">
<pre class="csharp">&nbsp;<span class="cs__com">//&nbsp;点击搜索按钮</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__com">//&nbsp;这里调用了百度的搜索引擎</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">private</span>&nbsp;<span class="cs__keyword">void</span>&nbsp;toolbtnbaiduSearch_Click(<span class="cs__keyword">object</span>&nbsp;sender,&nbsp;EventArgs&nbsp;e)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Encoding&nbsp;utf8encoding&nbsp;=&nbsp;Encoding.UTF8;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">string</span>&nbsp;uri&nbsp;=&nbsp;<span class="cs__string">&quot;http://www.baidu.com/s?wd=&quot;</span>&nbsp;&#43;&nbsp;<a class="libraryLink" href="http://msdn.microsoft.com/zh-CN/library/System.Web.HttpUtility.UrlEncode.aspx" target="_blank" title="Auto generated link to System.Web.HttpUtility.UrlEncode">System.Web.HttpUtility.UrlEncode</a>(tooltbxKeyword.Text,&nbsp;utf8encoding);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;HttpWebRequest&nbsp;request&nbsp;=&nbsp;(HttpWebRequest)HttpWebRequest.Create(uri);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;HttpWebResponse&nbsp;response&nbsp;=&nbsp;(HttpWebResponse)request.GetResponse();&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Stream&nbsp;stream&nbsp;=&nbsp;response.GetResponseStream();&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;StreamReader&nbsp;readerstream&nbsp;=&nbsp;<span class="cs__keyword">new</span>&nbsp;StreamReader(stream,&nbsp;utf8encoding);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;pageWebBrowser.DocumentText&nbsp;=&nbsp;readerstream.ReadToEnd();&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;readerstream.Close();&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;stream.Close();&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;urlAddress.Text&nbsp;=&nbsp;uri;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;AddItem_urlAddress();&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}</pre>
</div>
</div>
</div>
<h1>更多信息</h1>
<p>WebBrowser 类</p>
<p><a href="http://msdn.microsoft.com/zh-cn/library/system.windows.forms.webbrowser(v=vs.100).aspx" target="_blank">http://msdn.microsoft.com/zh-cn/library/system.windows.forms.webbrowser(v=vs.100).aspx</a></p>
<p>HttpWebRequest 类</p>
<p><a href="http://msdn.microsoft.com/zh-cn/library/system.net.httpwebrequest(v=vs.100).aspx" target="_blank">http://msdn.microsoft.com/zh-cn/library/system.net.httpwebrequest(v=vs.100).aspx</a></p>
<p>WebBrowser 事件</p>
<p><a href="http://msdn.microsoft.com/zh-cn/library/system.windows.forms.webbrowser_events(v=vs.80).aspx" target="_blank">http://msdn.microsoft.com/zh-cn/library/system.windows.forms.webbrowser_events(v=vs.80).aspx</a></p>
