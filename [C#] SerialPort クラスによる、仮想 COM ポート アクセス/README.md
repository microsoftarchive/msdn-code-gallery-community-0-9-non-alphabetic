# [C#] SerialPort クラスによる、仮想 COM ポート アクセス
## License
- Apache License, Version 2.0
## Technologies
- Visual Studio 2008
- Visual Studio 2010
- Windows 7
## Topics
- 逆引きサンプル コード
- 周辺デバイス アクセス
## Updated
- 05/09/2011
## Description

<p>動作確認環境： Visual Studio 2010、Visual Studio 2008、Visual Studio 2005</p>
<hr>
<p>周辺機器を Windows PC につなぐ最も一般的な方法として採用されているのが、USB で接続、仮想 COM ポートにマップするという方法です。GPS の USB ドングルや、過去 RS232C インターフェイスで接続されていた周辺機器で、現在 USB で接続できるものは、ほぼこの方法を採用しています。Bluetooth による携帯電話と PC の接続も、仮想 COM ポートによる接続です。</p>
<p>この逆引きでは、.NET Framework に用意されている Serial Port クラスを使って、仮想 COM ポートにマップされた、周辺機器とのデータ通信を行うコードを紹介します。</p>
<p>COM ポートへのアクセスは、<a class="libraryLink" href="http://msdn.microsoft.com/ja-JP/library/System.IO.Ports.aspx" target="_blank" title="Auto generated link to System.IO.Ports">System.IO.Ports</a> という名前空間の SerialPort クラスを使います。コーディングの際は、この名前空間の using 宣言を行ってください。</p>
<p>COM ポートでデータの送受信は以下の手順で行います。</p>
<ol>
<li>COM ポートをオープンする </li><li>必要に応じて、COM ポートからデータ読出/書込を行う </li><li>使い終わったら COM ポートをクローズする </li></ol>
<p>COM ポートのオープンは、以下のコードで行います。</p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>C#</span></div>
<div class="pluginEditHolderLink">スクリプトの編集</div>
<span class="hidden">csharp</span>

<div class="preview">
<pre class="csharp">&nbsp;&nbsp;&nbsp;<span class="cs__keyword">string</span>&nbsp;PortName&nbsp;=&nbsp;<span class="cs__string">&quot;COM1&quot;</span>;&nbsp;
&nbsp;&nbsp;&nbsp;<span class="cs__keyword">int</span>&nbsp;BaudRate&nbsp;=&nbsp;<span class="cs__number">38400</span>;&nbsp;
&nbsp;&nbsp;&nbsp;Parity&nbsp;Parity&nbsp;=&nbsp;Parity.None;&nbsp;
&nbsp;&nbsp;&nbsp;<span class="cs__keyword">int</span>&nbsp;DataBits&nbsp;=&nbsp;<span class="cs__number">8</span>;&nbsp;
&nbsp;&nbsp;&nbsp;StopBits&nbsp;StopBits&nbsp;=&nbsp;StopBits.One;&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;SerialPort&nbsp;&nbsp;myPort&nbsp;=&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;<span class="cs__keyword">new</span>&nbsp;SerialPort(PortName,&nbsp;BaudRate,&nbsp;Parity,&nbsp;DataBits,&nbsp;StopBits);&nbsp;
&nbsp;&nbsp;&nbsp;myPort.Open();&nbsp;
&nbsp;
&nbsp;
</pre>
</div>
</div>
</div>
<div class="endscriptcode">&nbsp;</div>
<p>PortName は、使いたい COM ポートの名前です。ポート名は、アクセスしたい周辺機器を PC に接続し、コントロール パネルの &quot;ハードウェアとサウンド&quot; &rarr; &quot;デバイス マネージャ&quot; を選択し、&quot;ポート (COM と LPT)&quot;で確認してください。例を挙げると、</p>
<p><img src="http://i2.code.msdn.microsoft.com/com-howto-6c7ff269/image/file/22147/1/01.jpg" alt="図 1" width="337" height="72"></p>
<p>この例では、ポート名は &quot;COM8&quot; です。ポート名は PC に接続された周辺機器の種類や、その他様々な要因で変化するので、都度確認してください。</p>
<p>※手順は Windows 7 を前提に説明しています。</p>
<p>他の変数、BaudRate (ボーレート)、Parity (パリティ)、DataBits (データ ビッツ)、StopBits (ストップ ビッツ) は、PC に接続する周辺機器毎に異なります。大抵の場合、周辺機器のマニュアルや Web で公開された情報に記載されているので、それを参考にしてください。</p>
<p>参考までに、PC にマップされている仮想 COM ポートのポート名は、以下のコードで列挙可能です。</p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>C#</span></div>
<div class="pluginEditHolderLink">スクリプトの編集</div>
<span class="hidden">csharp</span>

<div class="preview">
<pre class="csharp">&nbsp;&nbsp;<span class="cs__keyword">foreach</span>&nbsp;(var&nbsp;p&nbsp;<span class="cs__keyword">in</span>&nbsp;SerialPort.GetPortNames())&nbsp;
&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;<span class="cs__keyword">string</span>&nbsp;portName&nbsp;=&nbsp;p;&nbsp;
&nbsp;&nbsp;&hellip;&nbsp;
&nbsp;&nbsp;}&nbsp;
&nbsp;
&nbsp;
</pre>
</div>
</div>
</div>
<div class="endscriptcode">&nbsp;</div>
<p>実際のアプリケーションではリスト ボックスやコンボ ボックスで選択可能にすると良いでしょう。</p>
<p>次に COM ポートからの読出しです。</p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>C#</span></div>
<div class="pluginEditHolderLink">スクリプトの編集</div>
<span class="hidden">csharp</span>

<div class="preview">
<pre class="vb">&nbsp;int&nbsp;rbyte&nbsp;=&nbsp;myPort.BytesToRead;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;byte[]&nbsp;buffer&nbsp;=&nbsp;new&nbsp;byte[rbyte];&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;int&nbsp;read&nbsp;=&nbsp;<span class="visualBasic__number">0</span>;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;while&nbsp;(read&nbsp;&lt;&nbsp;rbyte)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;int&nbsp;length&nbsp;=&nbsp;myPort.Read(buffer,&nbsp;read,&nbsp;rbyte&nbsp;-&nbsp;read);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;read&nbsp;&#43;=&nbsp;length;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
&nbsp;
&nbsp;
</pre>
</div>
</div>
</div>
<div class="endscriptcode">&nbsp;</div>
<p>myPort の BytesToRead プロパティに、周辺機器から送られてきたデータのバイト数が&#26684;納されています。その大きさの byte 配列を用意し、Read() メソッドを使ってデータを読み込みます。周辺機器の種類や通信状況、デバイス ドライバーのつくりによっては、一度の Read() コールでは全てのデータを読み込めない場合があるので、while 文を使って BytesToRead バイト全てを読み込みます。</p>
<p>次に、COM ポートへの書き込みです。</p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>C#</span></div>
<div class="pluginEditHolderLink">スクリプトの編集</div>
<span class="hidden">csharp</span>

<div class="preview">
<pre class="csharp"><span class="cs__keyword">byte</span>[]&nbsp;buffer&nbsp;=&nbsp;&hellip;&nbsp;
&hellip;&nbsp;
myPort.Write(buffer,&nbsp;<span class="cs__number">0</span>,&nbsp;buffer.Length);&nbsp;
&nbsp;
&nbsp;
</pre>
</div>
</div>
</div>
<div class="endscriptcode">&nbsp;</div>
<p>Write() メソッドの第 1 引数は、書き込むデータを&#26684;納した byte 配列です。2 番目の引数は、byte 配列の何バイト目から書き込むか、そして 3 番目の引数は、書き込むデータ長を指定しています。本コードの場合は、 buffer の先頭から、buffer の内容を丸ごと書き込むことを意味しています。Write には、他に string を書き込むシグネチャも用意されています。必要に応じて使い分けてください。</p>
<p>※string を使う場合は、その文字列のエンコードに注意を払う必要があります。周辺機器が想定しているのと同じものでないと、データが化けてしまい、正しくデータを周辺機器に送信することは出来ません。</p>
<p>以上、見てきたように、データの読込/書込は非常に簡単です。</p>
<p>そして、ポートのクローズです。あるアプリケーションがオープンしている COM ポートは別のアプリからはオープンできないので、使い終わったらきちんとクローズしておきましょう。</p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>C#</span></div>
<div class="pluginEditHolderLink">スクリプトの編集</div>
<span class="hidden">csharp</span>

<div class="preview">
<pre class="vb">myPort.Close();&nbsp;
&nbsp;
</pre>
</div>
</div>
</div>
<div class="endscriptcode">&nbsp;</div>
<p>以上で、基本的な説明はおしまいです。</p>
<p>選択肢として、VC&#43;&#43; Native による COM ポート アクセスもありますが、C# によるプログラミングの方が非常にシンプルで簡単なので、アプリケーションの性能要件で問題なければ、なるべくこちらを使うことをおすすめします。</p>
<p>※周辺機器の予期しない電源 OFF や電波状況の悪さなどで、Read() や Write() が失敗する場合もあります。そういう場合には、IOException 等の例外が発生するので、実際のアプリケーションでは、try～catch 文で捕捉してください。</p>
<p>さて、Read() メソッドをコールした時、周辺機器がデータを送ってきていなければ、データが読出し可能になるまで、制御スレッドはそこでブロックされてしまい、他のロジックを実行できなくなってしまいます。これを解決するには、Read() メソッドをコールするスレッドを作るのが一番簡単です。</p>
<p>以上の事を考慮したクラスの実装例を以下に紹介します。</p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>C#</span></div>
<div class="pluginEditHolderLink">スクリプトの編集</div>
<span class="hidden">csharp</span>

<div class="preview">
<pre class="csharp"><span class="cs__keyword">using</span>&nbsp;<a class="libraryLink" href="http://msdn.microsoft.com/ja-JP/library/System.IO.Ports.aspx" target="_blank" title="Auto generated link to System.IO.Ports">System.IO.Ports</a>;&nbsp;
<span class="cs__keyword">using</span>&nbsp;<a class="libraryLink" href="http://msdn.microsoft.com/ja-JP/library/System.Threading.aspx" target="_blank" title="Auto generated link to System.Threading">System.Threading</a>;&nbsp;
<span class="cs__keyword">class</span>&nbsp;SerialPortProcessor&nbsp;
{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">private</span>&nbsp;SerialPort&nbsp;myPort&nbsp;=&nbsp;<span class="cs__keyword">null</span>;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">private</span>&nbsp;Thread&nbsp;receiveThread&nbsp;=&nbsp;<span class="cs__keyword">null</span>;&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">public</span>&nbsp;String&nbsp;PortName&nbsp;{&nbsp;<span class="cs__keyword">get</span>;&nbsp;<span class="cs__keyword">set</span>;&nbsp;}&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">public</span>&nbsp;<span class="cs__keyword">int</span>&nbsp;BaudRate&nbsp;{&nbsp;<span class="cs__keyword">get</span>;&nbsp;<span class="cs__keyword">set</span>;&nbsp;}&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">public</span>&nbsp;Parity&nbsp;Parity&nbsp;{&nbsp;<span class="cs__keyword">get</span>;&nbsp;<span class="cs__keyword">set</span>;&nbsp;}&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">public</span>&nbsp;<span class="cs__keyword">int</span>&nbsp;DataBits&nbsp;{&nbsp;<span class="cs__keyword">get</span>;&nbsp;<span class="cs__keyword">set</span>;&nbsp;}&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">public</span>&nbsp;StopBits&nbsp;StopBits&nbsp;{&nbsp;<span class="cs__keyword">get</span>;&nbsp;<span class="cs__keyword">set</span>;&nbsp;}&nbsp;
&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">public</span>&nbsp;SerialPortProcessor()&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">public</span>&nbsp;<span class="cs__keyword">void</span>&nbsp;Start()&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;myPort&nbsp;=&nbsp;<span class="cs__keyword">new</span>&nbsp;SerialPort(&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;PortName,&nbsp;BaudRate,&nbsp;Parity,&nbsp;DataBits,&nbsp;StopBits);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;myPort.Open();&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;receiveThread&nbsp;=&nbsp;<span class="cs__keyword">new</span>&nbsp;Thread(SerialPortProcessor.ReceiveWork);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;receiveThread.Start(<span class="cs__keyword">this</span>);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">public</span>&nbsp;<span class="cs__keyword">static</span>&nbsp;<span class="cs__keyword">void</span>&nbsp;ReceiveWork(<span class="cs__keyword">object</span>&nbsp;target)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;SerialPortProcessor&nbsp;my&nbsp;=&nbsp;target&nbsp;<span class="cs__keyword">as</span>&nbsp;SerialPortProcessor;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;my.ReceiveData();&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">public</span>&nbsp;<span class="cs__keyword">void</span>&nbsp;WriteData(<span class="cs__keyword">byte</span>[]&nbsp;buffer)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;myPort.Write(buffer,&nbsp;<span class="cs__number">0</span>,&nbsp;buffer.Length);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">public</span>&nbsp;<span class="cs__keyword">delegate</span>&nbsp;<span class="cs__keyword">void</span>&nbsp;DataReceivedHandler(<span class="cs__keyword">byte</span>[]&nbsp;data);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">public</span>&nbsp;<span class="cs__keyword">event</span>&nbsp;DataReceivedHandler&nbsp;DataReceived;&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">public</span>&nbsp;<span class="cs__keyword">void</span>&nbsp;ReceiveData()&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">if</span>&nbsp;(myPort&nbsp;==&nbsp;<span class="cs__keyword">null</span>)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">return</span>;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">do</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">try</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">int</span>&nbsp;rbyte&nbsp;=&nbsp;myPort.BytesToRead;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">byte</span>[]&nbsp;buffer&nbsp;=&nbsp;<span class="cs__keyword">new</span>&nbsp;<span class="cs__keyword">byte</span>[rbyte];&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">int</span>&nbsp;read&nbsp;=&nbsp;<span class="cs__number">0</span>;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">while</span>&nbsp;(read&nbsp;&lt;&nbsp;rbyte)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">int</span>&nbsp;length&nbsp;=&nbsp;myPort.Read(buffer,&nbsp;read,&nbsp;rbyte&nbsp;-&nbsp;read);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;read&nbsp;&#43;=&nbsp;length;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">if</span>&nbsp;(rbyte&nbsp;&gt;&nbsp;<span class="cs__number">0</span>)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;DataReceived(buffer);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">catch</span>&nbsp;(IOException&nbsp;ex)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;...&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">catch</span>&nbsp;(InvalidOperationException&nbsp;ex)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;...&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;<span class="cs__keyword">while</span>&nbsp;(myPort.IsOpen);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">public</span>&nbsp;<span class="cs__keyword">void</span>&nbsp;Close()&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">if</span>&nbsp;(receiveThread&nbsp;!=&nbsp;<span class="cs__keyword">null</span>&nbsp;&amp;&amp;&nbsp;myPort&nbsp;!=&nbsp;<span class="cs__keyword">null</span>)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;myPort.Close();&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;receiveThread.Join();&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
}&nbsp;
&nbsp;
&nbsp;
</pre>
</div>
</div>
</div>
<div class="endscriptcode">&nbsp;</div>
<p>このクラスの使い方は、</p>
<ol>
<li>SerialPortProcessor オブジェクトを作成 </li><li>DataReceived イベントにハンドラ登録 </li><li>必要に応じて WriteData() で書込んで周辺機器にデータ送信 </li><li>周辺機器からデータを受信したら、ハンドラがコールされる </li><li>使い終わったら、Close() をコール </li></ol>
<p>です。Close() メソッド内で SerialPort の Close() メソッドをコールすることにより、COM ポートが閉じられ、Read() メソッドのコール ロックが解除され、受信スレッド処理が終わり、受信スレッド終了と待ち合わせて処理が完了します。</p>
<p>以上で解説は終わりです。周辺機器と PC の間に書込み/読込みの順番 (プロトコル) がある場合など、色々と拡張してみてください。</p>
<hr style="clear:both; margin-bottom:8px; margin-top:20px">
<table>
<tbody>
<tr>
<td><a href="http://code.msdn.microsoft.com/ja-jp"><img src="http://i.msdn.microsoft.com/ff950935.coderecipe_180x70%28ja-jp,MSDN.10%29.jpg" border="0" alt="Code Recipe" width="180" height="70" style="margin-top:3px"></a></td>
<td><a href="http://msdn.microsoft.com/ja-jp/windows/" target="_blank"><img src="http://i.msdn.microsoft.com/ff950935.windows_180x70%28ja-jp,MSDN.10%29.jpg" border="0" alt="Windows デベロッパー センター" width="180" height="70" style="margin-top:3px"></a></td>
<td>
<ul>
<li>もっと他の Windows 7 対応を見る &gt;&gt; <a href="http://msdn.microsoft.com/ja-jp/windows/gg581817" target="_blank">
Windows XP から Windows 7 アプリ移行 実践ガイド へ</a> </li><li>もっと他のコンテンツを見る &gt;&gt; <a href="http://msdn.microsoft.com/ja-jp/ff363212" target="_blank">
逆引きサンプル コード一覧へ</a> </li><li>もっと他のレシピを見る &gt;&gt; <a href="http://code.msdn.microsoft.com/ja-jp">Code Recipe へ</a>
</li><li>もっと Windows の情報を見る &gt;&gt; <a href="http://msdn.microsoft.com/ja-jp/windows/" target="_blank">
Windows デベロッパー センターへ</a> </li></ul>
</td>
</tr>
</tbody>
</table>
<p style="margin-top:20px"><a href="#top"><img src="http://www.microsoft.com/japan/msdn/nodehomes/graphics/top.gif" border="0" alt="">ページのトップへ</a></p>
