# [C#/XAML] ウィンドウ ハンドルを使う (Windows フォームから WPF へ)
## License
- Apache License, Version 2.0
## Technologies
- Visual Studio 2008
- WPF
- Visual Studio 2010
## Topics
- WPF アプリケーション
- 逆引きサンプル コード
## Updated
- 06/16/2011
## Description

<p>執筆者: <a href="http://msdn.microsoft.com/ja-jp/gg585574#ohno" target="_blank">大野 元久</a></p>
<p>動作確認環境: Visual Studio 2008、Visual Studio 2010</p>
<p>更新日: 2010 年 12 月&nbsp;3 日</p>
<p>Windows フォームで使われるコントロールの大半は、Windows 自身が提供している機能であり、それぞれがウィンドウ ハンドルを持ちます。コントロールを拡張する場合は、このウィンドウ ハンドルを使って Windows メッセージを処理する必要があります。これに対し、WPF ではコントロールの描画や管理は (DirectX を使って) WPF が行い、ウィンドウだけがウィンドウ ハンドルを持ちます。コントロールを拡張する場合も、ウィンドウ ハンドルが必要になることはありません。</p>
<p>しかし、Windows API を直接呼び出す場合など、ウィンドウ ハンドルが必要なこともあります。ここではウィンドウ ハンドルを使うプログラミングを解説します。</p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>C#</span></div>
<div class="pluginEditHolderLink">{#scriptcode_dlg.edit_script}</div>
<span class="hidden">csharp</span>

<div class="preview">
<pre class="csharp"><span class="cs__keyword">using</span>&nbsp;<a class="libraryLink" href="http://msdn.microsoft.com/ja-JP/library/System.Windows.Interop.aspx" target="_blank" title="Auto generated link to System.Windows.Interop">System.Windows.Interop</a>;&nbsp;
<span class="cs__keyword">using</span>&nbsp;<a class="libraryLink" href="http://msdn.microsoft.com/ja-JP/library/System.Runtime.InteropServices.aspx" target="_blank" title="Auto generated link to System.Runtime.InteropServices">System.Runtime.InteropServices</a>;&nbsp;
&nbsp;&nbsp;&nbsp;&hellip;&hellip;&nbsp;
<span class="cs__keyword">public</span>&nbsp;partial&nbsp;<span class="cs__keyword">class</span>&nbsp;MainWindow&nbsp;:&nbsp;Window&nbsp;
{&nbsp;
&nbsp;&nbsp;&nbsp;&hellip;&hellip;&nbsp;
&nbsp;&nbsp;&nbsp;<span class="cs__keyword">private</span>&nbsp;<span class="cs__keyword">void</span>&nbsp;Window_Loaded(<span class="cs__keyword">object</span>&nbsp;sender,&nbsp;RoutedEventArgs&nbsp;e)&nbsp;
&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;HwndSource&nbsp;source&nbsp;=&nbsp;HwndSource.FromVisual(<span class="cs__keyword">this</span>)&nbsp;<span class="cs__keyword">as</span>&nbsp;HwndSource;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;IntPtr&nbsp;handle&nbsp;=&nbsp;source.Handle;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;source.CompositionTarget.BackgroundColor&nbsp;=&nbsp;Color.FromArgb(<span class="cs__number">0</span>,&nbsp;<span class="cs__number">0</span>,&nbsp;<span class="cs__number">0</span>,&nbsp;<span class="cs__number">0</span>);&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;MARGINS&nbsp;margins&nbsp;=&nbsp;<span class="cs__keyword">new</span>&nbsp;MARGINS&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;cxLeftWidth&nbsp;=&nbsp;-<span class="cs__number">1</span>,&nbsp;cxRightWidth&nbsp;=&nbsp;<span class="cs__number">0</span>,&nbsp;cyTopHeight&nbsp;=&nbsp;<span class="cs__number">0</span>,&nbsp;cyBottomHeight&nbsp;=&nbsp;<span class="cs__number">0</span>&nbsp;};&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;DwmExtendFrameIntoClientArea(handle,&nbsp;margins);&nbsp;
&nbsp;&nbsp;&nbsp;}&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;[StructLayout(LayoutKind.Sequential)]&nbsp;
&nbsp;&nbsp;&nbsp;<span class="cs__keyword">public</span>&nbsp;<span class="cs__keyword">class</span>&nbsp;MARGINS&nbsp;
&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">public</span>&nbsp;<span class="cs__keyword">int</span>&nbsp;cxLeftWidth;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">public</span>&nbsp;<span class="cs__keyword">int</span>&nbsp;cxRightWidth;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">public</span>&nbsp;<span class="cs__keyword">int</span>&nbsp;cyTopHeight;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">public</span>&nbsp;<span class="cs__keyword">int</span>&nbsp;cyBottomHeight;&nbsp;
&nbsp;&nbsp;&nbsp;}&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;[DllImport(<span class="cs__string">&quot;dwmapi.dll&quot;</span>,&nbsp;PreserveSig&nbsp;=&nbsp;<span class="cs__keyword">false</span>)]&nbsp;
&nbsp;&nbsp;&nbsp;<span class="cs__keyword">public</span>&nbsp;<span class="cs__keyword">static</span>&nbsp;<span class="cs__keyword">extern</span>&nbsp;<span class="cs__keyword">void</span>&nbsp;DwmExtendFrameIntoClientArea(&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;IntPtr&nbsp;hWnd,&nbsp;MARGINS&nbsp;pMargins);&nbsp;
}&nbsp;
&nbsp;
</pre>
</div>
</div>
</div>
<div class="endscriptcode">&nbsp;</div>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>XAML</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">スクリプトの編集</span>|<span class="pluginRemoveHolderLink">{#scriptcode_dlg.remove_script}</span></div>
<span class="hidden">xaml</span>

<div class="preview">
<pre id="codePreview" class="vb">&lt;Window&nbsp;x:<span class="visualBasic__keyword">Class</span>=<span class="visualBasic__string">&quot;WpfWindowHandleApplication.MainWindow&quot;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;xmlns=<span class="visualBasic__string">&quot;http://schemas.microsoft.com/winfx/2006/xaml/presentation&quot;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;xmlns:x=<span class="visualBasic__string">&quot;http://schemas.microsoft.com/winfx/2006/xaml&quot;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Title=<span class="visualBasic__string">&quot;MainWindow&quot;</span>&nbsp;Height=<span class="visualBasic__string">&quot;350&quot;</span>&nbsp;Width=<span class="visualBasic__string">&quot;525&quot;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Loaded=<span class="visualBasic__string">&quot;Window_Loaded&quot;</span>&nbsp;Background=<span class="visualBasic__string">&quot;Transparent&quot;</span>&gt;&nbsp;
&nbsp;&nbsp;&nbsp;&lt;Grid&gt;&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&lt;/Grid&gt;&nbsp;
&lt;/Window&gt;</pre>
</div>
</div>
</div>
<div class="endscriptcode">&nbsp;</div>
<p>&nbsp;</p>
<h2 style="margin-top:30px">実行結果</h2>
<p><br>
<img src="18797-image001.png" border="0" alt="" width="589" height="383"></p>
<h2 style="margin-top:30px">ポイント</h2>
<p>ここでは、Windows Vista や Windows 7 の Aero Glass を使って WPF アプリケーションの背景を半透明化しています。WPF はウィンドウのクライアント領域を描画しますが、Aero Glass は WPF の機能ではなく、タイトル バーや枠の描画は Windows 自身に任されています。ここでは、四辺の枠の太さのうち左側を最大値にすることで、ウィンドウ全体を枠として半透明で描画します。このとき、WPF のウィンドウの背景 (Background プロパティ) は Transparent
 (透明) に設定しておかなければなりません。</p>
<p>※Aero Glass が有効でない環境では試すことができません。</p>
<p>ウィンドウ ハンドルのような WPF 以外と連携するための機能は、<a class="libraryLink" href="http://msdn.microsoft.com/ja-JP/library/System.Windows.Interop.aspx" target="_blank" title="Auto generated link to System.Windows.Interop">System.Windows.Interop</a> 名前空間で定義されています。HwndSource は、WPF コンテンツを&#26684;納する Win32 のウィンドウを実装します。このオブジェクトの Handle プロパティがウィンドウ ハンドルです。ここでは、Aero Glass を使って枠をクライアント領域に延長する API、DwmExtendFrameIntoClientArea に、このウィンドウ ハンドルを渡しています。</p>
<p>WPF で、デスクトップのドット密度 (DPI) を取得したい場合にもウィンドウ ハンドルが使えます。あらかじめ、Windows フォームで使われる <a class="libraryLink" href="http://msdn.microsoft.com/ja-JP/library/System.Drawing.aspx" target="_blank" title="Auto generated link to System.Drawing">System.Drawing</a> アセンブリを参照として追加しておき、次のようにプログラムします。</p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>C#</span></div>
<div class="pluginEditHolderLink">{#scriptcode_dlg.edit_script}</div>
<span class="hidden">csharp</span>

<div class="preview">
<pre class="js">private&nbsp;<span class="js__operator">void</span>&nbsp;button1_Click(object&nbsp;sender,&nbsp;RoutedEventArgs&nbsp;e)&nbsp;
<span class="js__brace">{</span>&nbsp;
&nbsp;&nbsp;&nbsp;HwndSource&nbsp;source&nbsp;=&nbsp;HwndSource.FromVisual(<span class="js__operator">this</span>)&nbsp;as&nbsp;HwndSource;&nbsp;
&nbsp;&nbsp;&nbsp;System.Drawing.Graphics&nbsp;desktop&nbsp;=&nbsp;<a class="libraryLink" href="http://msdn.microsoft.com/ja-JP/library/System.Drawing.Graphics.FromHwnd.aspx" target="_blank" title="Auto generated link to System.Drawing.Graphics.FromHwnd">System.Drawing.Graphics.FromHwnd</a>(source.Handle);&nbsp;
&nbsp;&nbsp;&nbsp;MessageBox.Show(string.Format(<span class="js__string">&quot;DpiX:&nbsp;{0},&nbsp;DpiY:&nbsp;{1}&quot;</span>,&nbsp;desktop.DpiX,&nbsp;desktop.DpiY));&nbsp;
<span class="js__brace">}</span>&nbsp;
&nbsp;
</pre>
</div>
</div>
</div>
<div class="endscriptcode">&nbsp;</div>
<p>なお、ウィンドウ ハンドルに送られるメッセージを処理したい場合は、HwndSource オブジェクトの AddHook メソッドを使って、メッセージを横取りできるようにします (解除する場合は、RemoveHook メソッドを使います)。次に簡単な例を示します。</p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>C#</span></div>
<div class="pluginEditHolderLink">{#scriptcode_dlg.edit_script}</div>
<span class="hidden">csharp</span>

<div class="preview">
<pre class="csharp"><span class="cs__keyword">protected</span>&nbsp;<span class="cs__keyword">override</span>&nbsp;<span class="cs__keyword">void</span>&nbsp;OnSourceInitialized(EventArgs&nbsp;e)&nbsp;
{&nbsp;
&nbsp;&nbsp;&nbsp;HwndSource&nbsp;source&nbsp;=&nbsp;HwndSource.FromVisual(<span class="cs__keyword">this</span>)&nbsp;<span class="cs__keyword">as</span>&nbsp;HwndSource;&nbsp;
&nbsp;&nbsp;&nbsp;source.AddHook(WndHookProc);&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;<span class="cs__keyword">base</span>.OnSourceInitialized(e);&nbsp;
}&nbsp;
&nbsp;
<span class="cs__keyword">private</span>&nbsp;IntPtr&nbsp;WndHookProc(IntPtr&nbsp;hwnd,&nbsp;<span class="cs__keyword">int</span>&nbsp;msg,&nbsp;IntPtr&nbsp;wParam,&nbsp;IntPtr&nbsp;lParam,&nbsp;<span class="cs__keyword">ref</span>&nbsp;<span class="cs__keyword">bool</span>&nbsp;handled)&nbsp;
{&nbsp;
&nbsp;&nbsp;&nbsp;<span class="cs__com">//&nbsp;メッセージ処理</span>&nbsp;
&nbsp;&nbsp;&nbsp;<span class="cs__keyword">return</span>&nbsp;IntPtr.Zero;&nbsp;
}&nbsp;
&nbsp;
</pre>
</div>
</div>
</div>
<div class="endscriptcode">&nbsp;</div>
<p>WPF は、Windows 自身とのやりとりを WPF 自身の中に隠ぺいすることで、ウィンドウ ハンドルやメッセージを考えずにプログラミングできます。特に必要がなければ、できるだけウィンドウ ハンドルを使わないようにプログラミングすることが望ましいでしょう。&nbsp;</p>
<hr>
<table>
<tbody>
<tr>
<td><a href="http://code.msdn.microsoft.com/ja-jp"><img title="Code Recipe" src="-ff950935.coderecipe_180x70%28ja-jp,msdn.10%29.jpg" border="0" alt="Code Recipe" width="180" height="70" style="margin-top:3px"></a></td>
<td><a href="http://msdn.microsoft.com/ja-jp/netframework/" target="_blank"><img title=".NET Framework デベロッパー センター" src="-ff950935.netframework_180x70%28ja-jp,msdn.10%29.jpg" border="0" alt="Code Recipe" width="180" height="70" style="margin-top:3px"></a></td>
<td>
<ul>
<li>もっと他のコンテンツを見る &gt;&gt; <a href="http://msdn.microsoft.com/ja-jp/ff363212" target="_blank">
逆引きサンプル コード一覧へ</a> </li><li>もっと他のレシピを見る &gt;&gt; <a href="http://code.msdn.microsoft.com/ja-jp">Code Recipe へ</a>
</li><li>もっと .NET Framework の情報を見る &gt;&gt; <a href="http://msdn.microsoft.com/ja-jp/netframework/" target="_blank">
.NET Framework デベロッパー センターへ</a> </li></ul>
</td>
</tr>
</tbody>
</table>
<p style="margin-top:20px"><a href="#top"><img src="-top.gif" border="0" alt="">ページのトップへ</a></p>
