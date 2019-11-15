# .Net Tips #1121 WPF／Windowsフォーム：時間のかかる処理をバックグラウンドで実行するには？（async／await編）［C#／VB］
## Requires
- Visual Studio 2012
## License
- MS-LPL
## Technologies
- Windows Forms
- WPF
## Topics
- 非同期処理
- Async Programming
- async-await
## Updated
- 12/13/2015
## Description

<h1>Introduction</h1>
<div>これは次の記事のサンプルコードです。</div>
<blockquote>
<div>@IT 2015/12/02 掲載<br>
<img id="68637" src="http://image.itmedia.co.jp/ait/articles/1507/08/top_news025.png" alt="" width="120" height="90"><br>
<strong><a href="http://www.atmarkit.co.jp/ait/subtop/features/dotnet/dotnettips_index.html" target="_blank">.NET TIPS：</a><br>
<a href="http://www.atmarkit.co.jp/ait/articles/1512/02/news019.html" target="_blank">WPF／Windowsフォーム：時間のかかる処理をバックグラウンドで実行するには？（async／await編）［C#／VB］</a></strong><br>
<br>
時間のかかる処理（以下、重い処理）はアプリケーションのメインのスレッドとは別のスレッド（以下、バックグラウンド）で行わなければならない。重い処理によってアプリケーションのユーザーインターフェース（UI）がフリーズすることがないようにするためである。その実現のために、.NET Framework 2.0からは<a href="https://msdn.microsoft.com/library/system.componentmodel.backgroundworker.aspx" target="_blank">BackgroundWorkerクラス</a>（System.ComponentModel名前空間）が利用されてきた（参照：「<a href="http://www.atmarkit.co.jp/fdotnet/dotnettips/436bgworker/bgworker.html" target="_blank">.NET
 TIPS：時間のかかる処理をバックグラウンドで実行するには？［2.0のみ、C#、VB］</a>」）。<br>
<br>
しかし、BackgroundWorkerクラスによる実装は、面倒で処理の流れが把握しにくいものだった。バックグラウンド処理が終わった後に実行される処理は別の場所に書かれるので、コードの流れが分断されていたのである。<br>
<br>
それが、<a href="https://msdn.microsoft.com/library/dd537609.aspx" target="_blank">タスク並列ライブラリ（TPL）</a>とVisual Studio 2012で導入されたasync／awaitキーワードを使うことで、簡潔に、しかも処理の流れを追いやすくコーディングできるようになったのだ。本稿では、その方法を解説する。<br>
<br>
なお、<strong>コードは Windows フォームのものを紹介するが、 WPF でも同様である</strong>。</div>
</blockquote>
<div><img id="145251" src="https://i1.code.msdn.s-msft.com/net-tips-1121-b9308cbc/image/file/145251/1/%e7%94%bb%e5%83%8f6a.png" alt="" width="286" height="181"><br>
&nbsp;<br>
&nbsp;<br>
&nbsp;<br>
以下の解説は記事の概要である。ぜひ記事のほうもお読みいただきたい。</div>
<div>&nbsp;</div>
<h1>Building the Sample</h1>
<div>本稿では無償の Visual Studio Express 2012 for Desktop を使っている。</div>
<div>&nbsp;</div>
<div>&nbsp;</div>
<h1>Description</h1>
<h2>● async／awaitを活用して重い処理をバックグラウンドで実行するには？</h2>
<p>端的にいうと「重い処理をTask.Runメソッドで包んでawait」するだけでよい。</p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>Visual Basic</span><span>C#</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">スクリプトの編集</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">vb</span><span class="hidden">csharp</span>


<div class="preview">
<pre class="vb"><span class="visualBasic__keyword">Private</span>&nbsp;Async&nbsp;<span class="visualBasic__keyword">Sub</span>&nbsp;Button1_Click(sender&nbsp;<span class="visualBasic__keyword">As</span>&nbsp;<span class="visualBasic__keyword">Object</span>,&nbsp;e&nbsp;<span class="visualBasic__keyword">As</span>&nbsp;EventArgs)&nbsp;_&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">Handles</span>&nbsp;Button1.Click&nbsp;
&nbsp;&nbsp;DisableAllButtons()&nbsp;
&nbsp;&nbsp;ToolStripStatusLabel1.Text&nbsp;=&nbsp;<span class="visualBasic__string">&quot;処理中&hellip;&quot;</span>&nbsp;
&nbsp;&nbsp;ToolStripProgressBar1.Value&nbsp;=&nbsp;<span class="visualBasic__number">0</span>&nbsp;
&nbsp;
&nbsp;&nbsp;<span class="visualBasic__com">'&nbsp;時間のかかる処理をUIスレッドで実行</span>&nbsp;
&nbsp;&nbsp;<span class="visualBasic__com">'&nbsp;Dim&nbsp;result&nbsp;As&nbsp;String&nbsp;=&nbsp;DoWork(100)</span>&nbsp;
&nbsp;&nbsp;<span class="visualBasic__com">'&nbsp;これではフォームがフリーズしてしまう</span>&nbsp;
&nbsp;
&nbsp;&nbsp;<span class="visualBasic__com">'&nbsp;時間のかかる処理を別スレッドで開始</span>&nbsp;
&nbsp;&nbsp;<span class="visualBasic__keyword">Dim</span>&nbsp;result&nbsp;<span class="visualBasic__keyword">As</span>&nbsp;<span class="visualBasic__keyword">String</span>&nbsp;=&nbsp;Await&nbsp;Task.Run(<span class="visualBasic__keyword">Function</span>()&nbsp;DoWork(<span class="visualBasic__number">100</span>))&nbsp;
&nbsp;
&nbsp;&nbsp;<span class="visualBasic__com">'&nbsp;&uarr;</span>&nbsp;
&nbsp;&nbsp;<span class="visualBasic__com">'&nbsp;この間10秒ほどかかるが、フォームの移動／リサイズなどは可能</span>&nbsp;
&nbsp;&nbsp;<span class="visualBasic__com">'&nbsp;&darr;</span>&nbsp;
&nbsp;
&nbsp;&nbsp;<span class="visualBasic__com">'&nbsp;処理結果の表示</span>&nbsp;
&nbsp;&nbsp;ToolStripStatusLabel1.Text&nbsp;=&nbsp;result&nbsp;
&nbsp;&nbsp;ToolStripProgressBar1.Value&nbsp;=&nbsp;<span class="visualBasic__number">100</span>&nbsp;
&nbsp;&nbsp;MessageBox.Show(<span class="visualBasic__string">&quot;正常に完了&quot;</span>)&nbsp;
&nbsp;
&nbsp;&nbsp;EableAllButtons()&nbsp;
<span class="visualBasic__keyword">End</span>&nbsp;<span class="visualBasic__keyword">Sub</span>&nbsp;
&nbsp;
<span class="visualBasic__com">'&nbsp;時間のかかる処理を行うメソッド</span>&nbsp;
<span class="visualBasic__keyword">Private</span>&nbsp;<span class="visualBasic__keyword">Function</span>&nbsp;DoWork(n&nbsp;<span class="visualBasic__keyword">As</span>&nbsp;<span class="visualBasic__keyword">Integer</span>)&nbsp;<span class="visualBasic__keyword">As</span>&nbsp;<span class="visualBasic__keyword">String</span>&nbsp;
&nbsp;&nbsp;<span class="visualBasic__com">'&nbsp;時間のかかる処理</span>&nbsp;
&nbsp;&nbsp;<span class="visualBasic__keyword">For</span>&nbsp;i&nbsp;<span class="visualBasic__keyword">As</span>&nbsp;<span class="visualBasic__keyword">Integer</span>&nbsp;=&nbsp;<span class="visualBasic__number">0</span>&nbsp;<span class="visualBasic__keyword">To</span>&nbsp;n&nbsp;-&nbsp;<span class="visualBasic__number">1</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<a class="libraryLink" href="https://msdn.microsoft.com/ja-JP/library/System.Threading.Thread.Sleep.aspx" target="_blank" title="Auto generated link to System.Threading.Thread.Sleep">System.Threading.Thread.Sleep</a>(<span class="visualBasic__number">100</span>)&nbsp;
&nbsp;&nbsp;<span class="visualBasic__keyword">Next</span>&nbsp;
&nbsp;
&nbsp;&nbsp;<span class="visualBasic__com">'&nbsp;このメソッドからの戻り値</span>&nbsp;
&nbsp;&nbsp;<span class="visualBasic__keyword">Return</span>&nbsp;<span class="visualBasic__string">&quot;全て完了&quot;</span>&nbsp;
<span class="visualBasic__keyword">End</span>&nbsp;<span class="visualBasic__keyword">Function</span>&nbsp;
&nbsp;
<span class="visualBasic__keyword">Private</span>&nbsp;<span class="visualBasic__keyword">Sub</span>&nbsp;DisableAllButtons()&nbsp;
&nbsp;&nbsp;Button1.Enabled&nbsp;=&nbsp;<span class="visualBasic__keyword">False</span>&nbsp;
&nbsp;&nbsp;Button2.Enabled&nbsp;=&nbsp;<span class="visualBasic__keyword">False</span>&nbsp;
<span class="visualBasic__keyword">End</span>&nbsp;<span class="visualBasic__keyword">Sub</span>&nbsp;
<span class="visualBasic__keyword">Private</span>&nbsp;<span class="visualBasic__keyword">Sub</span>&nbsp;EableAllButtons()&nbsp;
&nbsp;&nbsp;Button1.Enabled&nbsp;=&nbsp;<span class="visualBasic__keyword">True</span>&nbsp;
&nbsp;&nbsp;Button2.Enabled&nbsp;=&nbsp;<span class="visualBasic__keyword">True</span>&nbsp;
<span class="visualBasic__keyword">End</span>&nbsp;<span class="visualBasic__keyword">Sub</span>&nbsp;
</pre>
</div>
</div>
</div>
<div class="endscriptcode">&nbsp;</div>
<p>ボタンがクリックされたときのイベントハンドラー「button1_Click」の中で、重い処理「DoWork」メソッドを呼び出したい。しかし、普通に呼び出すとフォームがフリーズしてしまう。そこで上のコードのように、DoWorkメソッドをTask.Runメソッドで包み、awaitキーワードを付けることで、DoWorkメソッドがバックグラウンドで実行されるようになる。なお、awaitキーワードを使うときには、メソッドのシグネチャにasyncキーワードも必要だ。</p>
<p>&nbsp;</p>
<h2>● バックグラウンドの処理から進捗を表示するには？</h2>
<p>10秒もかかるような処理では進捗を表示すべきだろう。 このような場合に進捗を表示するには、Progressクラス（System名前空間）を使うとよい（次のコード）。</p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>Visual Basic</span><span>C#</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">スクリプトの編集</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">vb</span><span class="hidden">csharp</span>


<div class="preview">
<pre class="vb"><span class="visualBasic__keyword">Private</span>&nbsp;Async&nbsp;<span class="visualBasic__keyword">Sub</span>&nbsp;Button2_Click(sender&nbsp;<span class="visualBasic__keyword">As</span>&nbsp;<span class="visualBasic__keyword">Object</span>,&nbsp;e&nbsp;<span class="visualBasic__keyword">As</span>&nbsp;EventArgs)&nbsp;_&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">Handles</span>&nbsp;Button2.Click&nbsp;
&nbsp;&nbsp;DisableAllButtons()&nbsp;
&nbsp;&nbsp;ToolStripStatusLabel1.Text&nbsp;=&nbsp;<span class="visualBasic__string">&quot;処理中&hellip;&quot;</span>&nbsp;
&nbsp;&nbsp;ToolStripProgressBar1.Value&nbsp;=&nbsp;<span class="visualBasic__number">0</span>&nbsp;
&nbsp;
&nbsp;&nbsp;<span class="visualBasic__com">'&nbsp;Progressクラスのインスタンスを生成</span>&nbsp;
&nbsp;&nbsp;<span class="visualBasic__keyword">Dim</span>&nbsp;p&nbsp;=&nbsp;<span class="visualBasic__keyword">New</span>&nbsp;Progress(<span class="visualBasic__keyword">Of</span>&nbsp;<span class="visualBasic__keyword">Integer</span>)(<span class="visualBasic__keyword">AddressOf</span>&nbsp;ShowProgress)&nbsp;
&nbsp;
&nbsp;&nbsp;<span class="visualBasic__com">'&nbsp;時間のかかる処理を別スレッドで開始</span>&nbsp;
&nbsp;&nbsp;<span class="visualBasic__keyword">Dim</span>&nbsp;result&nbsp;<span class="visualBasic__keyword">As</span>&nbsp;<span class="visualBasic__keyword">String</span>&nbsp;=&nbsp;Await&nbsp;Task.Run(<span class="visualBasic__keyword">Function</span>()&nbsp;DoWork(p,&nbsp;<span class="visualBasic__number">100</span>))&nbsp;
&nbsp;
&nbsp;&nbsp;<span class="visualBasic__com">'&nbsp;処理結果の表示</span>&nbsp;
&nbsp;&nbsp;ToolStripStatusLabel1.Text&nbsp;=&nbsp;result&nbsp;
&nbsp;&nbsp;ToolStripProgressBar1.Value&nbsp;=&nbsp;<span class="visualBasic__number">100</span>&nbsp;
&nbsp;&nbsp;MessageBox.Show(<span class="visualBasic__string">&quot;正常に完了&quot;</span>)&nbsp;
&nbsp;
&nbsp;&nbsp;EableAllButtons()&nbsp;
<span class="visualBasic__keyword">End</span>&nbsp;<span class="visualBasic__keyword">Sub</span>&nbsp;
&nbsp;
<span class="visualBasic__com">'&nbsp;進捗を表示するメソッド（これはUIスレッドで呼び出される）</span>&nbsp;
<span class="visualBasic__keyword">Private</span>&nbsp;<span class="visualBasic__keyword">Sub</span>&nbsp;ShowProgress(percent&nbsp;<span class="visualBasic__keyword">As</span>&nbsp;<span class="visualBasic__keyword">Integer</span>)&nbsp;
&nbsp;&nbsp;ToolStripStatusLabel1.Text&nbsp;=&nbsp;percent&nbsp;&amp;&nbsp;<span class="visualBasic__string">&quot;％完了&quot;</span>&nbsp;
&nbsp;&nbsp;ToolStripProgressBar1.Value&nbsp;=&nbsp;percent&nbsp;
<span class="visualBasic__keyword">End</span>&nbsp;<span class="visualBasic__keyword">Sub</span>&nbsp;
&nbsp;
<span class="visualBasic__com">'&nbsp;時間のかかる処理を行うメソッド（進捗付き）</span>&nbsp;
<span class="visualBasic__keyword">Private</span>&nbsp;<span class="visualBasic__keyword">Function</span>&nbsp;DoWork(progress&nbsp;<span class="visualBasic__keyword">As</span>&nbsp;IProgress(<span class="visualBasic__keyword">Of</span>&nbsp;<span class="visualBasic__keyword">Integer</span>),&nbsp;n&nbsp;<span class="visualBasic__keyword">As</span>&nbsp;<span class="visualBasic__keyword">Integer</span>)&nbsp;<span class="visualBasic__keyword">As</span>&nbsp;<span class="visualBasic__keyword">String</span>&nbsp;
&nbsp;&nbsp;<span class="visualBasic__com">'&nbsp;別スレッドで実行されるため、このメソッドでは</span>&nbsp;
&nbsp;&nbsp;<span class="visualBasic__com">'&nbsp;UI（コントロール）を操作してはいけない</span>&nbsp;
&nbsp;
&nbsp;&nbsp;<span class="visualBasic__com">'&nbsp;時間のかかる処理</span>&nbsp;
&nbsp;&nbsp;<span class="visualBasic__keyword">For</span>&nbsp;i&nbsp;<span class="visualBasic__keyword">As</span>&nbsp;<span class="visualBasic__keyword">Integer</span>&nbsp;=&nbsp;<span class="visualBasic__number">0</span>&nbsp;<span class="visualBasic__keyword">To</span>&nbsp;n&nbsp;-&nbsp;<span class="visualBasic__number">1</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<a class="libraryLink" href="https://msdn.microsoft.com/ja-JP/library/System.Threading.Thread.Sleep.aspx" target="_blank" title="Auto generated link to System.Threading.Thread.Sleep">System.Threading.Thread.Sleep</a>(<span class="visualBasic__number">100</span>)&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">Dim</span>&nbsp;percentage&nbsp;<span class="visualBasic__keyword">As</span>&nbsp;<span class="visualBasic__keyword">Integer</span>&nbsp;=&nbsp;i&nbsp;*&nbsp;<span class="visualBasic__number">100</span>&nbsp;\&nbsp;n&nbsp;<span class="visualBasic__com">'&nbsp;進捗率</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;progress.Report(percentage)&nbsp;
&nbsp;&nbsp;<span class="visualBasic__keyword">Next</span>&nbsp;
&nbsp;
&nbsp;&nbsp;<span class="visualBasic__com">'&nbsp;このメソッドからの戻り値</span>&nbsp;
&nbsp;&nbsp;<span class="visualBasic__keyword">Return</span>&nbsp;<span class="visualBasic__string">&quot;全て完了&quot;</span>&nbsp;
<span class="visualBasic__keyword">End</span>&nbsp;<span class="visualBasic__keyword">Function</span>&nbsp;
</pre>
</div>
</div>
</div>
<div class="endscriptcode">&nbsp;</div>
<p>&nbsp;</p>
<h2>● 非同期処理を学ぶには？</h2>
<div style="float:left; margin-right:8px"><a href="http://amzn.to/1XA8tVF" target="_blank"><img id="145252" src="https://i1.code.msdn.s-msft.com/net-tips-1121-b9308cbc/image/file/145252/1/51mmclqpjzl%5b1%5d.jpg" alt="" width="117" height="150" border="none"></a></div>
<p>以上のように、 async／await で簡単に非同期処理の記述ができる。 しかしながら、 記述が簡潔で分かりやすくなったとはいっても、 非同期処理の動作まで簡単になったわけではないのだ。 非同期処理（マルチスレッド プログラミング）の本質的な困難さは変わらない。 基本からしっかり理解しておくことをお勧めする。</p>
<p>筆者は「<strong><a href="http://amzn.to/1XA8tVF" target="_blank">C#によるマルチコアのための非同期/並列処理プログラミング</a></strong>」という本を出している（<a href="https://gihyo.jp/dp/ebook/2013/978-4-7741-5907-2" target="_blank">電子書籍版</a>もあり）。 C# でマルチスレッド プログラミングを解説した本は、 ちょっと珍しいのではないかと思う。 参考にしていただければ幸いである。</p>
<p style="clear:both">&nbsp;</p>
<h1>More Information</h1>
<h2>著作権について</h2>
<div>このソースコードは MS-LPL ライセンスで提供しておりますので、 ご自由に利用いただけます。<br>
ただし、@ITの記事(ここへ転載・引用した部分も含む)そのものの著作権は、筆者とデジタルアドバンテージが保有しており、サンプルコード部分を除く記事の無断使用は固くお断りいたします。</div>
