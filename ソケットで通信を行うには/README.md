# ソケットで通信を行うには
## License
- Apache License, Version 2.0
## Technologies
- Windows Phone
## Topics
- Windows Phone アプリケーション
- "How to" ラーニング コース
## Updated
- 02/15/2012
## Description

<p style="border:solid 1px #666; padding:10px; width:140px; background-color:#dedede">
サンプル | <a href="http://download.microsoft.com/download/A/1/0/A10EBC63-2398-483C-9F65-5DDA7122B45C/SocketFeatures.zip">
Zip、118 KB</a></p>
<p>このサンプルは、手順に沿って、コードをコピーし、ソース コードへ貼り付けることでアプリケーションを作成できます。完成例は、サンプル ファイルの Finish フォルダーに&#26684;納されていますので参考にしてください。</p>
<hr>
<p>ここでは以下の手順で説明します。</p>
<ul>
<li>ソケット クライアントを作成する </li><li>データを送信する </li><li>データを受信する </li><li>ソケット クライアントを使用する </li></ul>
<h2 style="font-size:120%; margin:20px 0px; border-left:7px solid #666666; padding-left:12px">
ソケット クライアントを作成する</h2>
<ol>
<li>このコンテンツのサポート ファイルの Start フォルダーから &quot;UDPClient&quot; プロジェクトを開きます。 </li><li>クライアントを動作させるため、コンピューターで簡易 TCP/IP サービスを有効にする必要があります。以下の手順を実行します。
<ol>
<li style="list-style:lower-alpha">コントロール パネルで [プログラムと機能] を開きます。 </li><li style="list-style:lower-alpha">[Windows の機能の有効化または無効化] をクリックします。 </li><li style="list-style:lower-alpha">[Windows の機能] ダイアログで [簡易 TCP/IP サービス] チェック ボックスをオンにして機能を有効にし、[OK] をクリックします。
</li><li style="list-style:lower-alpha">この手順を実行するには、ローカル コンピューターの Administrators グループまたは Network Configuration Operators グループのメンバーとしてログオンする必要があります。
</li><li style="list-style:lower-alpha">コンピューターの [サービス] リストで、&quot;Simple TCP/IP Services&quot; サービスが開始されていることを確認します。開始されていない場合はサービスを手動で開始します。サービスの開始方法の詳細については、「<a href="http://technet.microsoft.com/ja-jp/library/cc755249.aspx" target="_blank">サービスの開始方法を構成する</a>」を参照してください。
</li></ol>
</li><li>メニューから [プロジェクト]　&rarr; [クラスの追加] を選択し、<span style="font-style:italic">SocketClient</span> という名前を付けます。
</li><li>SocketClient.cs で、<a class="libraryLink" href="http://msdn.microsoft.com/ja-JP/library/System.Net.Sockets.aspx" target="_blank" title="Auto generated link to System.Net.Sockets">System.Net.Sockets</a>、<a class="libraryLink" href="http://msdn.microsoft.com/ja-JP/library/System.Threading.aspx" target="_blank" title="Auto generated link to System.Threading">System.Threading</a>、<a class="libraryLink" href="http://msdn.microsoft.com/ja-JP/library/System.Text.aspx" target="_blank" title="Auto generated link to System.Text">System.Text</a> の名前空間を追加し、SocketClient クラスに以下のメンバー変数を定義します。
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>C#</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">スクリプトの編集</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">csharp</span>

<div class="preview">
<pre id="codePreview" class="csharp"><span class="cs__keyword">using</span>&nbsp;<a class="libraryLink" href="http://msdn.microsoft.com/ja-JP/library/System.Net.Sockets.aspx" target="_blank" title="Auto generated link to System.Net.Sockets">System.Net.Sockets</a>;&nbsp;
<span class="cs__keyword">using</span>&nbsp;<a class="libraryLink" href="http://msdn.microsoft.com/ja-JP/library/System.Threading.aspx" target="_blank" title="Auto generated link to System.Threading">System.Threading</a>;&nbsp;
<span class="cs__keyword">using</span>&nbsp;<a class="libraryLink" href="http://msdn.microsoft.com/ja-JP/library/System.Text.aspx" target="_blank" title="Auto generated link to System.Text">System.Text</a>;&nbsp;
&nbsp;
<span class="cs__com">//&nbsp;このクラスの有効期間中の各呼び出しに使用される、キャッシュされた&nbsp;Socket&nbsp;オブジェクト。</span>&nbsp;
Socket&nbsp;socket&nbsp;=&nbsp;<span class="cs__keyword">null</span>;&nbsp;
&nbsp;
<span class="cs__com">//&nbsp;非同期処理が完了したことを通知するために信号を送るオブジェクト。</span>&nbsp;
<span class="cs__keyword">static</span>&nbsp;ManualResetEvent&nbsp;clientDone&nbsp;=&nbsp;<span class="cs__keyword">new</span>&nbsp;ManualResetEvent(<span class="cs__keyword">false</span>);&nbsp;
&nbsp;
<span class="cs__com">//&nbsp;各非同期呼び出しのタイムアウトをミリ秒で定義する。このタイムアウト期間内に&nbsp;</span>&nbsp;
<span class="cs__com">//&nbsp;応答を受信しなかった場合、呼び出しが中止される。</span>&nbsp;
<span class="cs__keyword">const</span>&nbsp;<span class="cs__keyword">int</span>&nbsp;TIMEOUT_MILLISECONDS&nbsp;=&nbsp;<span class="cs__number">5000</span>;&nbsp;
&nbsp;
<span class="cs__com">//&nbsp;非同期ソケット&nbsp;メソッドで使用するデータ&nbsp;バッファーの最大サイズ。</span>&nbsp;
<span class="cs__keyword">const</span>&nbsp;<span class="cs__keyword">int</span>&nbsp;MAX_BUFFER_SIZE&nbsp;=&nbsp;<span class="cs__number">2048</span>;</pre>
</div>
</div>
</div>
<div class="endscriptcode">&nbsp;</div>
</li><li>以下のパラメーターを使って <span style="font-style:italic">socket</span> 変数を初期化するコンストラクターを追加します。
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>C#</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">スクリプトの編集</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">csharp</span>

<div class="preview">
<pre id="codePreview" class="csharp"><span class="cs__keyword">public</span>&nbsp;SocketClient()&nbsp;
{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__com">//&nbsp;AddressFamily.InterNetwork&nbsp;-&nbsp;ソケットは&nbsp;IP&nbsp;version&nbsp;4&nbsp;アドレス指定方式を</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__com">//&nbsp;使用してアドレスを解決する。</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__com">//&nbsp;SocketType.Dgram&nbsp;-&nbsp;データグラム&nbsp;(メッセージ)&nbsp;パケットをサポートするソケット</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__com">//&nbsp;PrototcolType.Udp&nbsp;-&nbsp;ユーザー&nbsp;データグラム&nbsp;プロトコル&nbsp;(UDP)</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;socket&nbsp;=&nbsp;<span class="cs__keyword">new</span>&nbsp;Socket(AddressFamily.InterNetwork,&nbsp;SocketType.Dgram,&nbsp;ProtocolType.Udp);&nbsp;
}</pre>
</div>
</div>
</div>
<div class="endscriptcode">&nbsp;</div>
</li><li><span style="font-style:italic">socket</span> を閉じる Close メソッドを追加します。
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>C#</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">スクリプトの編集</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">csharp</span>

<div class="preview">
<pre id="codePreview" class="csharp"><span class="cs__keyword">public</span>&nbsp;<span class="cs__keyword">void</span>&nbsp;Close()&nbsp;
{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;socket.Close();&nbsp;
}</pre>
</div>
</div>
</div>
<div class="endscriptcode">&nbsp;</div>
</li></ol>
<h2 style="font-size:120%; margin:20px 0px; border-left:7px solid #666666; padding-left:12px">
データを送信する</h2>
<ol>
<li>SocketClient.cs で、Send メソッドを追加します。文字列を返すようにし、パラメーターとして serverName、portNumber、data を受け入れます。
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>C#</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">スクリプトの編集</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">csharp</span>

<div class="preview">
<pre id="codePreview" class="csharp"><span class="cs__keyword">public</span>&nbsp;<span class="cs__keyword">string</span>&nbsp;Send(<span class="cs__keyword">string</span>&nbsp;serverName,&nbsp;<span class="cs__keyword">int</span>&nbsp;portNumber,&nbsp;<span class="cs__keyword">string</span>&nbsp;data)&nbsp;{&nbsp;}</pre>
</div>
</div>
</div>
<div class="endscriptcode">&nbsp;</div>
</li><li>Send メソッドで、string 型の変数 response を定義し、既定値として &quot;Operation Timeout&quot; を設定します。
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>C#</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">スクリプトの編集</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">csharp</span>

<div class="preview">
<pre id="codePreview" class="csharp"><span class="cs__keyword">string</span>&nbsp;response&nbsp;=&nbsp;<span class="cs__string">&quot;Operation&nbsp;Timeout&quot;</span>;</pre>
</div>
</div>
</div>
<div class="endscriptcode">&nbsp;</div>
</li><li>ソケットが null でないかどうか確認し、以下のようにデータを送信します。
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>C#</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">スクリプトの編集</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">csharp</span>

<div class="preview">
<pre id="codePreview" class="csharp"><span class="cs__keyword">if</span>&nbsp;(socket&nbsp;!=&nbsp;<span class="cs__keyword">null</span>)&nbsp;
{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__com">//&nbsp;SocketAsyncEventArgs&nbsp;コンテキスト&nbsp;オブジェクトを作成する。</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;SocketAsyncEventArgs&nbsp;socketEventArg&nbsp;=&nbsp;<span class="cs__keyword">new</span>&nbsp;SocketAsyncEventArgs();&nbsp;
&nbsp;
<span class="cs__com">//&nbsp;コンテキスト&nbsp;オブジェクトのプロパティを設定する。</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;socketEventArg.RemoteEndPoint&nbsp;=&nbsp;<span class="cs__keyword">new</span>&nbsp;DnsEndPoint(serverName,&nbsp;portNumber);&nbsp;
&nbsp;
<span class="cs__com">//&nbsp;Completed&nbsp;イベントのインライン&nbsp;イベント&nbsp;ハンドラー。</span>&nbsp;
<span class="cs__com">//&nbsp;注:&nbsp;メソッドを自己完結させるため、このイベント&nbsp;ハンドラーはインラインで実装される。</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;socketEventArg.Completed&nbsp;&#43;=&nbsp;<span class="cs__keyword">new</span>&nbsp;EventHandler&lt;SocketAsyncEventArgs&gt;(<span class="cs__keyword">delegate</span>(<span class="cs__keyword">object</span>&nbsp;s,&nbsp;SocketAsyncEventArgs&nbsp;e)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;response&nbsp;=&nbsp;e.SocketError.ToString();&nbsp;
&nbsp;
<span class="cs__com">//&nbsp;UI&nbsp;スレッドのブロックを解除する。</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;clientDone.Set();&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;});&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__com">//&nbsp;送信するデータをバッファーに追加する。</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">byte</span>[]&nbsp;payload&nbsp;=&nbsp;Encoding.UTF8.GetBytes(data);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;socketEventArg.SetBuffer(payload,&nbsp;<span class="cs__number">0</span>,&nbsp;payload.Length);&nbsp;
&nbsp;
<span class="cs__com">//&nbsp;イベントの状態をシグナルなしに設定し、スレッドのブロックを発生させる。</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;clientDone.Reset();&nbsp;
&nbsp;
<span class="cs__com">//&nbsp;ソケットを使用して非同期の送信要求を行う。</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;socket.SendToAsync(socketEventArg);&nbsp;
&nbsp;
<span class="cs__com">//&nbsp;TIMEOUT_MILLISECONDS&nbsp;の最大秒数まで&nbsp;UI&nbsp;スレッドをブロックする。</span>&nbsp;
<span class="cs__com">//&nbsp;この時間内に応答がなければ、処理を先に進める。</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;clientDone.WaitOne(TIMEOUT_MILLISECONDS);&nbsp;
}&nbsp;
<span class="cs__keyword">else</span>&nbsp;
{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;response&nbsp;=&nbsp;<span class="cs__string">&quot;Socket&nbsp;is&nbsp;not&nbsp;initialized&quot;</span>;&nbsp;
}</pre>
</div>
</div>
</div>
<div class="endscriptcode">&nbsp;</div>
</li><li>応答を返します。
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>C#</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">スクリプトの編集</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">csharp</span>

<div class="preview">
<pre id="codePreview" class="csharp"><span class="cs__keyword">return</span>&nbsp;response;</pre>
</div>
</div>
</div>
<div class="endscriptcode">&nbsp;</div>
</li></ol>
<h2 style="font-size:120%; margin:20px 0px; border-left:7px solid #666666; padding-left:12px">
データを受信する</h2>
<ol>
<li>SocketClient.cs で、Receive メソッドを追加します。文字列を返すようにし、パラメーターとして portNumber を受け入れます。
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>C#</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">スクリプトの編集</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">csharp</span>

<div class="preview">
<pre id="codePreview" class="csharp"><span class="cs__keyword">public</span>&nbsp;<span class="cs__keyword">string</span>&nbsp;Receive(<span class="cs__keyword">int</span>&nbsp;portNumber)&nbsp;{&nbsp;&nbsp;}</pre>
</div>
</div>
</div>
<div class="endscriptcode">&nbsp;</div>
</li><li>Receive メソッドで、string 型の変数 <span style="font-style:italic">response</span> を定義し、既定値として &quot;Operation Timeout&quot; を設定します。
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>C#</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">スクリプトの編集</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">csharp</span>

<div class="preview">
<pre id="codePreview" class="js">string&nbsp;response&nbsp;=&nbsp;<span class="js__string">&quot;Operation&nbsp;Timeout&quot;</span>;</pre>
</div>
</div>
</div>
<div class="endscriptcode">&nbsp;</div>
</li><li>ソケットが null でないかどうか確認し、以下のようにデータを受信します。
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>C#</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">スクリプトの編集</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">csharp</span>

<div class="preview">
<pre id="codePreview" class="csharp"><span class="cs__keyword">if</span>&nbsp;(socket&nbsp;!=&nbsp;<span class="cs__keyword">null</span>)&nbsp;
{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__com">//&nbsp;SocketAsyncEventArgs&nbsp;コンテキスト&nbsp;オブジェクトを作成する。</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;SocketAsyncEventArgs&nbsp;socketEventArg&nbsp;=&nbsp;<span class="cs__keyword">new</span>&nbsp;SocketAsyncEventArgs();&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;socketEventArg.RemoteEndPoint&nbsp;=&nbsp;<span class="cs__keyword">new</span>&nbsp;IPEndPoint(IPAddress.Any,&nbsp;portNumber);&nbsp;
&nbsp;
<span class="cs__com">//&nbsp;データを受信するためのバッファーを設定する。</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;socketEventArg.SetBuffer(<span class="cs__keyword">new</span>&nbsp;Byte[MAX_BUFFER_SIZE],&nbsp;<span class="cs__number">0</span>,&nbsp;MAX_BUFFER_SIZE);&nbsp;
&nbsp;
<span class="cs__com">//&nbsp;Completed&nbsp;イベントのインライン&nbsp;イベント&nbsp;ハンドラー。</span>&nbsp;
<span class="cs__com">//&nbsp;注:&nbsp;メソッドを自己完結させるため、このイベント&nbsp;ハンドラーはインラインで実装される。</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;socketEventArg.Completed&nbsp;&#43;=&nbsp;<span class="cs__keyword">new</span>&nbsp;EventHandler&lt;SocketAsyncEventArgs&gt;(<span class="cs__keyword">delegate</span>(<span class="cs__keyword">object</span>&nbsp;s,&nbsp;SocketAsyncEventArgs&nbsp;e)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">if</span>&nbsp;(e.SocketError&nbsp;==&nbsp;SocketError.Success)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__com">//&nbsp;バッファーからデータを取得する。</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;response&nbsp;=&nbsp;Encoding.UTF8.GetString(e.Buffer,&nbsp;e.Offset,&nbsp;e.BytesTransferred);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;response&nbsp;=&nbsp;response.Trim(<span class="cs__string">'\0'</span>);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">else</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;response&nbsp;=&nbsp;e.SocketError.ToString();&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;clientDone.Set();&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;});&nbsp;
&nbsp;
<span class="cs__com">//&nbsp;イベントの状態をシグナルなしに設定し、スレッドのブロックを発生させる。</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;clientDone.Reset();&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__com">//&nbsp;ソケットを使用して非同期の受信要求を行う。</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;socket.ReceiveFromAsync(socketEventArg);&nbsp;
&nbsp;
<span class="cs__com">//&nbsp;TIMEOUT_MILLISECONDS&nbsp;の最大秒数まで&nbsp;UI&nbsp;スレッドをブロックする。</span>&nbsp;
<span class="cs__com">//&nbsp;この時間内に応答がなければ、処理を先に進める。</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;clientDone.WaitOne(TIMEOUT_MILLISECONDS);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
<span class="cs__keyword">else</span>&nbsp;
{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;response&nbsp;=&nbsp;<span class="cs__string">&quot;Socket&nbsp;is&nbsp;not&nbsp;initialized&quot;</span>;&nbsp;
}</pre>
</div>
</div>
</div>
<div class="endscriptcode">&nbsp;</div>
</li><li>応答を返します。
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>C#</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">スクリプトの編集</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">csharp</span>

<div class="preview">
<pre id="codePreview" class="csharp"><span class="cs__keyword">return</span>&nbsp;response;</pre>
</div>
</div>
</div>
<div class="endscriptcode">&nbsp;</div>
</li></ol>
<h2 style="font-size:120%; margin:20px 0px; border-left:7px solid #666666; padding-left:12px">
ソケット クライアントを使用する</h2>
<ol>
<li>MainPage.xaml.cs の、btnEcho の Click イベント ハンドラーで、ClearLog の後に、<em>client</em> という名前の新しい SocketClient 変数を作成します。
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>C#</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">スクリプトの編集</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">csharp</span>

<div class="preview">
<pre id="codePreview" class="csharp">SocketClient&nbsp;client&nbsp;=&nbsp;<span class="cs__keyword">new</span>&nbsp;SocketClient();</pre>
</div>
</div>
</div>
<div class="endscriptcode">&nbsp;</div>
</li><li>以下のように、エコーされるメッセージを送信します。
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>C#</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">スクリプトの編集</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">csharp</span>

<div class="preview">
<pre id="codePreview" class="csharp">Log(String.Format(<span class="cs__string">&quot;&gt;&gt;&nbsp;Sending&nbsp;'{0}'&nbsp;to&nbsp;server&nbsp;...&quot;</span>,&nbsp;txtInput.Text));&nbsp;
<span class="cs__keyword">string</span>&nbsp;result&nbsp;=&nbsp;client.Send(txtRemoteHost.Text,&nbsp;ECHO_PORT,&nbsp;txtInput.Text);&nbsp;
Log(<span class="cs__string">&quot;&lt;&lt;&nbsp;&quot;</span>&nbsp;&#43;&nbsp;result);</pre>
</div>
</div>
</div>
<div class="endscriptcode">&nbsp;</div>
</li><li>以下のように、応答を受信してクライアントを閉じます。
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>C#</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">スクリプトの編集</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">csharp</span>

<div class="preview">
<pre id="codePreview" class="csharp">Log(<span class="cs__string">&quot;&gt;&gt;&nbsp;Requesting&nbsp;receive...&quot;</span>);&nbsp;
result&nbsp;=&nbsp;client.Receive(ECHO_PORT);&nbsp;
Log(<span class="cs__string">&quot;&lt;&lt;&nbsp;&quot;</span>&nbsp;&#43;&nbsp;result);&nbsp;
&nbsp;
client.Close();</pre>
</div>
</div>
</div>
<div class="endscriptcode">&nbsp;</div>
</li><li>MainPage.xaml.cs の、btnGetQuote の Click イベント ハンドラーで、client という名前の新しい SocketClient 変数を ClearLog の後に作成します。
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>C#</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">スクリプトの編集</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">csharp</span>

<div class="preview">
<pre id="codePreview" class="csharp">SocketClient&nbsp;client&nbsp;=&nbsp;<span class="cs__keyword">new</span>&nbsp;SocketClient();</pre>
</div>
</div>
</div>
<div class="endscriptcode">&nbsp;</div>
</li><li>以下のように、今日の名言 (quote of the day) の要求を送信します。
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>C#</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">スクリプトの編集</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">csharp</span>

<div class="preview">
<pre id="codePreview" class="csharp"><span class="cs__com">//&nbsp;UDP&nbsp;では、着信する&nbsp;UDP&nbsp;メッセージごとにメッセージが送信されるため、&quot;ダミー&quot;&nbsp;メッセージを送信して&nbsp;</span>&nbsp;
<span class="cs__com">//&nbsp;応答を求める。メッセージは空にできないので、以下のメッセージは空白文字&nbsp;1&nbsp;つで構成されている。</span>&nbsp;
Log(<span class="cs__string">&quot;&gt;&gt;&nbsp;Requesting&nbsp;quote&quot;</span>);&nbsp;
<span class="cs__keyword">string</span>&nbsp;result&nbsp;=&nbsp;client.Send(txtRemoteHost.Text,&nbsp;QOTD_PORT,&nbsp;<span class="cs__string">&quot;&nbsp;&quot;</span>);&nbsp;
Log(<span class="cs__string">&quot;&lt;&lt;&nbsp;&quot;</span>&nbsp;&#43;&nbsp;result);</pre>
</div>
</div>
</div>
<div class="endscriptcode">&nbsp;</div>
</li><li>以下のように、応答を受信してクライアントを閉じます。
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>C#</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">スクリプトの編集</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">csharp</span>

<div class="preview">
<pre id="codePreview" class="csharp"><span class="cs__com">//&nbsp;&quot;今日の名言&quot;&nbsp;(QOTD)&nbsp;を返すサーバーからの応答を受信する。</span>&nbsp;
Log(<span class="cs__string">&quot;&gt;&gt;&nbsp;Requesting&nbsp;receive...&quot;</span>);&nbsp;
result&nbsp;=&nbsp;client.Receive(QOTD_PORT);&nbsp;
Log(<span class="cs__string">&quot;&lt;&lt;&nbsp;&quot;</span>&nbsp;&#43;&nbsp;result);&nbsp;
&nbsp;
client.Close();</pre>
</div>
</div>
</div>
<div class="endscriptcode">&nbsp;</div>
</li><li>プロジェクトを実行します。 </li><li>[Host Name] に利用しているコンピューター名または現在割り当てられている IP アドレスを入力します。
<p><img src="49523-612_01.jpg" alt="「Host Name] にコンピューター名又は IP アドレスを入力" width="210" height="350"></p>
</li><li>エコーするテキストを追加して [Echo] ボタンをタップします。応答が出力テキスト ボックスに返されることを確認します。
<p><img src="49524-612_02-03.jpg" alt="エコーするテキストを追加" width="425" height="350"></p>
</li><li>[Get Quote of the Day] ボタンをタップします。応答が出力テキスト ボックスに返されることを確認します。
<p><img src="49525-612_04.jpg" alt="応答が出力テキスト ボックスに返される" width="210" height="350"></p>
</li></ol>
<p>インターネットおよびその他のサービスとのほぼリアルタイムな通信を可能にする、新しいソケット機能を紹介しました。</p>
<h2 style="font-size:120%; margin:20px 0px; border-left:7px solid #666666; padding-left:12px">
関連ドキュメント</h2>
<ul>
<li><a href="http://msdn.microsoft.com/ja-jp/library/system.net.sockets.socket(v=vs.95)" target="_blank">Socket クラス</a>
</li></ul>
<h2 style="font-size:120%; margin:20px 0px; border-left:7px solid #666666; padding-left:12px">
参考ビデオ</h2>
<ul>
<li><a href="http://msdn.microsoft.com/en-us/hh329472" target="_blank">How Do I: Communicate with Sockets in Windows Phone &lsquo;Mango&rsquo;? (英語)</a>
</li></ul>
<hr style="clear:both; margin-bottom:8px; margin-top:20px">
<table>
<tbody>
<tr>
<td><a href="http://code.msdn.microsoft.com/ja-jp"><img src="-ff950935.coderecipe_180x70%28ja-jp,msdn.10%29.jpg" border="0" alt="Code Recipe" width="180" height="70" style="margin-top:3px"></a></td>
<td><a href="http://msdn.microsoft.com/ja-jp/windowsphone" target="_blank"><img src="-ff950935.winphone_180x70(ja-jp,msdn.10).gif" border="0" alt="Windows Phone デベロッパー センター" width="180" height="70" style="margin-top:3px"></a></td>
<td>
<ul>
<li>もっと他のコンテンツを見る &gt;&gt; <a href="http://msdn.microsoft.com/ja-jp/windowsphone/hh744643" target="_blank">
Windows Phone アプリケーション開発 &quot;How to&quot; ラーニング コースへ</a> </li><li>もっと&nbsp;Windows Phone の情報を見る &gt;&gt; <a href="http://msdn.microsoft.com/ja-jp/windowsphone" target="_blank">
Windows Phone デベロッパー センターへ</a> </li></ul>
</td>
</tr>
</tbody>
</table>
<p style="margin-top:20px"><a href="#top"><img src="-top.gif" border="0" alt="">ページのトップへ</a></p>
