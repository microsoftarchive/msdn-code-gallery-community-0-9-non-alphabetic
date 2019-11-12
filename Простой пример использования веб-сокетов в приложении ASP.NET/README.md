# Простой пример использования веб-сокетов в приложении ASP.NET
## Requires
- Visual Studio 2012
## License
- MIT
## Technologies
- C#
- ASP.NET
- .NET Framework
- ASP.NET 4.5
- WebSockets
- .NET 4.5
## Topics
- C#
- ASP.NET
- .NET Framework
- ASP.NET 4.5
- WebSockets
- .NET 4.5
## Updated
- 10/17/2017
## Description

<p><span style="font-size:20px; font-weight:bold">Описание</span></p>
<p style="text-align:justify">Проект предназначен для показа простейшего при&#1084;ера использования веб-сокетов в IIS 8 и ASP.NET. Он является практически&#1084; при&#1084;еро&#1084; &#1084;атериала, который был изложен в статье:
<a href="http://www.msdr.ru/34/">&laquo;Веб-приложения реального вре&#1084;ени. Веб-сокеты, IIS 8, библиотека SignalR и их использование в приложениях ASP.NET. Часть третья, простой при&#1084;ер использования веб-сокетов в приложении ASP.NET&raquo;</a>. Проект даёт воз&#1084;ожность
 получить представление об использовании веб-сокетов на платфор&#1084;е ASP.NET. В качестве при&#1084;ера у нас выступать веб-приложение, которое отправляет обычный текст на клиентский браузер при по&#1084;ощи веб-сокета. Данный проект де&#1084;онстрирует работу с веб-сокета&#1084;и на
 низко&#1084; уровне. Для работы подойдёт любой совре&#1084;енный браузер. Что касается браузеров от Microsoft, то тут нужен браузер IE 10 или выше. Для обеспечения работоспособности приложения на сервере понадобятся службы IIS 8 или выше, &#1084;ладшие версии не поддерживают
 протокол веб-сокетов. Напо&#1084;ню, что протокол WebSocket доступен только в операционных систе&#1084;ах начиная с Windows 8/Windows Server 2012, а также в более новых версиях (Windows 8.1/10 и Windows Server 2012 R2/Windows Server 2016), поскольку реализован в виде
 низкоуровневого неуправляе&#1084;ого &#1084;одуля IIS 8/8.5/10. То есть получается, что использовать данный проткол и воз&#1084;ожности в предыдущих версиях Windows не получится.</p>
<h1><span>Для построения приложения нужно</span></h1>
<p style="text-align:justify"><em>Для запуска и прос&#1084;отра при&#1084;ера нужна установленная Visual Studio 2012/<em>2013/2015/2017. Также, в качестве операционной систе&#1084;ы должна быть ОС не ниже Windows 8 или Windows Server 2012. Более &#1084;ладшие версии не поддерживают
 протокол веб-сокетов.<br>
</em></em></p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>C#</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Из&#1084;енение сценария</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">csharp</span>

<div class="preview">
<pre class="csharp"><span class="cs__keyword">using</span>&nbsp;System;&nbsp;
<span class="cs__keyword">using</span>&nbsp;<a class="libraryLink" href="https://msdn.microsoft.com/ru-RU/library/System.Web.aspx" target="_blank" title="Auto generated link to System.Web">System.Web</a>;&nbsp;
<span class="cs__keyword">using</span>&nbsp;<a class="libraryLink" href="https://msdn.microsoft.com/ru-RU/library/System.Linq.aspx" target="_blank" title="Auto generated link to System.Linq">System.Linq</a>;&nbsp;
<span class="cs__keyword">using</span>&nbsp;<a class="libraryLink" href="https://msdn.microsoft.com/ru-RU/library/System.Threading.aspx" target="_blank" title="Auto generated link to System.Threading">System.Threading</a>;&nbsp;
<span class="cs__keyword">using</span>&nbsp;<a class="libraryLink" href="https://msdn.microsoft.com/ru-RU/library/System.Threading.Tasks.aspx" target="_blank" title="Auto generated link to System.Threading.Tasks">System.Threading.Tasks</a>;&nbsp;
&nbsp;
<span class="cs__keyword">using</span>&nbsp;<a class="libraryLink" href="https://msdn.microsoft.com/ru-RU/library/System.Net.WebSockets.aspx" target="_blank" title="Auto generated link to System.Net.WebSockets">System.Net.WebSockets</a>;&nbsp;
<span class="cs__keyword">using</span>&nbsp;<a class="libraryLink" href="https://msdn.microsoft.com/ru-RU/library/System.Web.WebSockets.aspx" target="_blank" title="Auto generated link to System.Web.WebSockets">System.Web.WebSockets</a>;&nbsp;
&nbsp;
<span class="cs__keyword">namespace</span>&nbsp;SimpleWeSocketbApplication&nbsp;
{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">public</span>&nbsp;<span class="cs__keyword">class</span>&nbsp;WebSocketHandler&nbsp;:&nbsp;IHttpHandler&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">public</span>&nbsp;<span class="cs__keyword">void</span>&nbsp;ProcessRequest(HttpContext&nbsp;context)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__com">//Проверяе&#1084;,&nbsp;является&nbsp;ли&nbsp;запрос,&nbsp;запросо&#1084;&nbsp;по&nbsp;протоколу&nbsp;WebSocket.</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">if</span>&nbsp;(context.IsWebSocketRequest)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__com">//Если&nbsp;да,&nbsp;назначае&#1084;&nbsp;асинхронный&nbsp;обработчик.</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;context.AcceptWebSocketRequest(WebSocketRequestHandler);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">public</span>&nbsp;<span class="cs__keyword">bool</span>&nbsp;IsReusable&nbsp;{&nbsp;<span class="cs__keyword">get</span>&nbsp;{&nbsp;<span class="cs__keyword">return</span>&nbsp;<span class="cs__keyword">false</span>;&nbsp;}&nbsp;}&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__com">//Асинхронный&nbsp;обработчик&nbsp;запроса.</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">public</span>&nbsp;async&nbsp;Task&nbsp;WebSocketRequestHandler(AspNetWebSocketContext&nbsp;webSocketContext)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__com">//Получае&#1084;&nbsp;текущий&nbsp;объект&nbsp;веб-сокета.</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;WebSocket&nbsp;webSocket&nbsp;=&nbsp;webSocketContext.WebSocket;&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__mlcom">/*Определяе&#1084;&nbsp;некую&nbsp;константу,&nbsp;которая&nbsp;будет&nbsp;представлять&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&#1084;акси&#1084;льный&nbsp;раз&#1084;ер&nbsp;входных&nbsp;данных.&nbsp;Её&nbsp;устанавливае&#1084;&nbsp;&#1084;ы&nbsp;и&nbsp;значение&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&#1084;оже&#1084;&nbsp;задать&nbsp;любы&#1084;.&nbsp;Мы&nbsp;знае&#1084;,&nbsp;что&nbsp;в&nbsp;данно&#1084;&nbsp;случае&nbsp;раз&#1084;ер&nbsp;пересылае&#1084;ых&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;данных&nbsp;очень&nbsp;&#1084;ал.&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;*/</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">const</span>&nbsp;<span class="cs__keyword">int</span>&nbsp;maxMessageSize&nbsp;=&nbsp;<span class="cs__number">1024</span>;&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__com">//Буфер&nbsp;битов,&nbsp;в&nbsp;который&nbsp;будут&nbsp;записываться&nbsp;полученные&nbsp;данные.</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;ArraySegment&lt;Byte&gt;&nbsp;receivedDataBuffer&nbsp;=&nbsp;<span class="cs__keyword">new</span>&nbsp;ArraySegment&lt;Byte&gt;(<span class="cs__keyword">new</span>&nbsp;Byte[maxMessageSize]);&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__com">//Токен&nbsp;от&#1084;ены,&nbsp;в&nbsp;данно&#1084;&nbsp;при&#1084;ере&nbsp;не&nbsp;используется.</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;var&nbsp;cancellationToken&nbsp;=&nbsp;<span class="cs__keyword">new</span>&nbsp;CancellationToken();&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__com">//Проверяе&#1084;&nbsp;состояние&nbsp;веб-сокета.</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">while</span>&nbsp;(webSocket.State&nbsp;==&nbsp;WebSocketState.Open)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__com">//Читае&#1084;&nbsp;данные.</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;WebSocketReceiveResult&nbsp;webSocketReceiveResult&nbsp;=&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;await&nbsp;webSocket.ReceiveAsync(receivedDataBuffer,&nbsp;cancellationToken);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__com">//С&#1084;отри&#1084;,&nbsp;если&nbsp;входной&nbsp;фрей&#1084;&nbsp;закрывающий,&nbsp;посылае&#1084;&nbsp;ответ&nbsp;на&nbsp;закрытие.</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">if</span>&nbsp;(webSocketReceiveResult.MessageType&nbsp;==&nbsp;WebSocketMessageType.Close)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;await&nbsp;webSocket.CloseAsync(WebSocketCloseStatus.NormalClosure,&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;String.Empty,&nbsp;cancellationToken);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">else</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__com">//Читае&#1084;&nbsp;только&nbsp;те&nbsp;байты,&nbsp;которые&nbsp;пришли.</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">byte</span>[]&nbsp;payloadData&nbsp;=&nbsp;receivedDataBuffer.Array.Where(b&nbsp;=&gt;&nbsp;b&nbsp;!=&nbsp;<span class="cs__number">0</span>).ToArray();&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__com">//Поскольку&nbsp;&#1084;ы&nbsp;знае&#1084;,&nbsp;что&nbsp;это&nbsp;строка,&nbsp;то&nbsp;конвертируе&#1084;.</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">string</span>&nbsp;receiveString&nbsp;=&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;System.Text.UTF8Encoding.UTF8.GetString(payloadData,&nbsp;<span class="cs__number">0</span>,&nbsp;payloadData.Length);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__com">//Собирае&#1084;&nbsp;новую&nbsp;строку&nbsp;и&nbsp;преобразовывае&#1084;&nbsp;в&nbsp;&#1084;ассив&nbsp;байт.</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;var&nbsp;newString&nbsp;=&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;String.Format(<span class="cs__string">&quot;Hello,&nbsp;&quot;</span>&nbsp;&#43;&nbsp;receiveString&nbsp;&#43;&nbsp;<span class="cs__string">&quot;&nbsp;!&nbsp;Time&nbsp;{0}&quot;</span>,&nbsp;DateTime.Now.ToString());&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Byte[]&nbsp;bytes&nbsp;=&nbsp;System.Text.UTF8Encoding.UTF8.GetBytes(newString);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__com">//Отсылае&#1084;&nbsp;данные&nbsp;обратно&nbsp;браузеру.</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;await&nbsp;webSocket.SendAsync(<span class="cs__keyword">new</span>&nbsp;ArraySegment&lt;<span class="cs__keyword">byte</span>&gt;(bytes),&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;WebSocketMessageType.Text,&nbsp;<span class="cs__keyword">true</span>,&nbsp;cancellationToken);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
}</pre>
</div>
</div>
</div>
<h1>Дополнительная инфор&#1084;ация</h1>
<p><em><em>Больше инфор&#1084;ации о приложении &#1084;ожно получить в <a href="http://www.msdr.ru/34/">
&#1084;оё&#1084; блоге</a>.</em></em></p>
