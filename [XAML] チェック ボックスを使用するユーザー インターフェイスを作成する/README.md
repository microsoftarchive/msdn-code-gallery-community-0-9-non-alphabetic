# [XAML] チェック ボックスを使用するユーザー インターフェイスを作成する
## License
- Apache License, Version 2.0
## Technologies
- Silverlight
## Topics
- Silverlight アプリケーション
- 逆引きサンプル コード
- Silverlight 大全 特集
## Updated
- 06/22/2011
## Description

<p>動作確認環境: Silverlight 4、Visual Studio 2010、Microsoft Silverlight 4 Tools for Visual Studio 2010、 Windows 7</p>
<div style="margin:0; background-color:#d9e8ec; border:2px #46689a solid; margin-bottom:20px">
<div style="background-color:#d9e8ec; border:1px #ffffff solid">
<div style="padding:5px; font-size:100%; border:1px #46689a solid">
<p style="margin:0; padding:0">本コンテンツは書籍<a href="http://msdn.microsoft.com/ja-jp/silverlight/hh201902" target="_blank">「Silverlight 大全」</a>と連動したサンプル コードです</p>
</div>
</div>
</div>
<p>Silverlight を使用したアプリケーションで、二者択一を行うときのチェック ボックスを使用するユーザー インターフェイスに作成する場合は CheckBox コントロールを使用します。</p>
<p>ここでは、XAML を使用した実装方法を紹介します。Visual Studio を使用した場合は、ツール ボックスにあるコントロールをドラッグ アンド ドロップすることにより、コントロールを使用できます。XAML のコード中に記述されている各プロパティは、Visual Studio のプロパティ ウィンドウからも変更できます。<br>
以下の XAML のコードは、CheckBox コントロールを Grid パネルの中で使用した例です。</p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>XAML</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">スクリプトの編集</span>|<span class="pluginRemoveHolderLink">{#scriptcode_dlg.remove_script}</span></div>
<span class="hidden">xaml</span>

<div class="preview">
<pre id="codePreview" class="xaml"><span class="xaml__tag_start">&lt;Grid</span>&nbsp;x:<span class="xaml__attr_name">Name</span>=<span class="xaml__attr_value">&quot;LayoutRoot&quot;</span>&nbsp;<span class="xaml__attr_name">Background</span>=<span class="xaml__attr_value">&quot;White&quot;</span><span class="xaml__tag_start">&gt;&nbsp;
</span>&nbsp;&nbsp;&nbsp;&nbsp;<span class="xaml__tag_start">&lt;CheckBox</span>&nbsp;<span class="xaml__attr_name">Content</span>=<span class="xaml__attr_value">&quot;CheckBox&quot;</span>&nbsp;<span class="xaml__attr_name">Height</span>=<span class="xaml__attr_value">&quot;16&quot;</span>&nbsp;<span class="xaml__attr_name">HorizontalAlignment</span>=<span class="xaml__attr_value">&quot;Left&quot;</span>&nbsp;<span class="xaml__attr_name">Margin</span>=<span class="xaml__attr_value">&quot;30,20,0,0&quot;</span>&nbsp;<span class="xaml__attr_name">Name</span>=<span class="xaml__attr_value">&quot;checkBox1&quot;</span>&nbsp;<span class="xaml__attr_name">VerticalAlignment</span>=<span class="xaml__attr_value">&quot;Top&quot;</span>&nbsp;<span class="xaml__tag_start">/&gt;</span>&nbsp;
<span class="xaml__tag_end">&lt;/Grid&gt;</span></pre>
</div>
</div>
</div>
<p>Visual Studio の XAML デザイナー上でみると、このようになっています。</p>
<p><img src="http://i1.code.msdn.s-msft.com/silverlight-howto-d45aefc9/image/file/22265/1/image001.gif" alt="図 1" width="274" height="178"></p>
<p>各コントロールのプロパティの説明です。</p>
<dl><dt><strong>Content:</strong> </dt><dd>表示される文字列です。 </dd><dt><strong>Height:</strong> </dt><dd>コントロールの見た目の高さです。 </dd><dt><strong>HorizontalAlignment:</strong> </dt><dd>パネル内のコントロールの水平方向の位置を、Left、Center、Right、Stretch で表します。ここでは Left が指定されているので、コントロールはパネル内で左寄せされて表示されます。ただし、Margin プロパティが設定されていたときは、その値の分のマージンが設定されます。
</dd><dt><strong>Margin:</strong> </dt><dd>4 つのパラメーターは、順に左側、上側、右側、下側のマージンを示します。マージンとは、その親となるパネルまたはグリッドの縁からの距離です。主に Grid パネルに貼り付けているときに使用します。
</dd><dt><strong>Name:</strong> </dt><dd>コントロールの名前です。Visual Basic や C# のコードから呼び出すときに、ここで設定した名前を使用します。 </dd><dt><strong>VerticalAlignment:</strong> </dt><dd>パネル内のコントロールの垂直方向の位置を、Top、Center、Bottom、Stretch で表します。ここでは Top が指定されているので、コントロールはパネル内で上寄せされて表示されます。ただし、Margin プロパティが設定されていたときは、その値の分のマージンが設定されます。
</dd></dl>
<p>入力された値は、以下のプロパティに反映されます。</p>
<dl><dt><strong>IsChecked:</strong> </dt><dd>チェックされていないときは False、チェックされているときは True の値が入ります。 </dd></dl>
<p>これら以外にも、下記のプロパティを設定することにより、見た目を変更できます。ここでは、よく使用されるプロパティを紹介します。</p>
<dl><dt><strong>Background:</strong> </dt><dd>背景色です。グラデーションをかけたり、イメージを指定することで画像を背景として設定することもできます。 </dd><dt><strong>BorderBrush:</strong> </dt><dd>枠の色です。 </dd><dt><strong>BorderThickness:</strong> </dt><dd>枠の線の幅です。 </dd><dt><strong>FontFamily:</strong> </dt><dd>表示するときに使用するフォント名です。 </dd><dt><strong>FontSize:</strong> </dt><dd>フォントの大きさです。 </dd><dt><strong>FontStyle:</strong> </dt><dd>このプロパティを Italic に変更すると、斜体で表示されます。 </dd><dt><strong>Foreground:</strong> </dt><dd>文字の色です。グラデーションをかけたり、イメージを指定することで画像を背景として設定することもできます。 </dd><dt><strong>IsThreeState:</strong> </dt><dd>このプロパティを True に変更すると、チェックのオン、オフだけでなく、中間状態という状態を設定できます。 </dd><dt><strong>Visibility:</strong> </dt><dd>表示と非表示を切り替えることができます。Visible を指定すると表示し、Collapsed を指定すると表示しなくなります。 </dd></dl>
<p>CheckBox コントロールは、チェックされたときに Checked というイベントを発生します。<br>
Visual Studio の XAML デザイナー上で、貼り付けている CheckBox コントロールをダブルクリックすると、イベント発生時に実行されるイベント ハンドラーが生成します。<br>
チェックが外れたときは、 UnChecked というイベントが発生します。UnChecked イベントに対するイベント ハンドラーを作成するときは、Visual Studio の XAML デザイナー上で貼り付けている CheckBox を選択し、プロパティ ウィンドウの [イベント] タブをクリックしてイベントの一覧を表示させます。一覧の中にある UnChecked をダブルクリックすると、イベント ハンドラーが生成されます。</p>
<p>以下の例は、チェックされたら &quot;チェックされました&quot; という文字列を表示し、文字色を赤に変更するプログラムの例です。チェックが外れたときは、&quot;チェックされていません&quot; という文字列に変更し、文字色を黒に戻します。</p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>Visual Basic</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">スクリプトの編集</span>|<span class="pluginRemoveHolderLink">{#scriptcode_dlg.remove_script}</span></div>
<span class="hidden">vb</span>

<div class="preview">
<pre id="codePreview" class="vb"><span class="visualBasic__keyword">Private</span>&nbsp;<span class="visualBasic__keyword">Sub</span>&nbsp;CheckBox1_Checked(<span class="visualBasic__keyword">ByVal</span>&nbsp;sender&nbsp;<span class="visualBasic__keyword">As</span>&nbsp;System.<span class="visualBasic__keyword">Object</span>,&nbsp;<span class="visualBasic__keyword">ByVal</span>&nbsp;e&nbsp;<span class="visualBasic__keyword">As</span>&nbsp;<a class="libraryLink" href="http://msdn.microsoft.com/ja-JP/library/System.Windows.RoutedEventArgs.aspx" target="_blank" title="Auto generated link to System.Windows.RoutedEventArgs">System.Windows.RoutedEventArgs</a>)&nbsp;<span class="visualBasic__keyword">Handles</span>&nbsp;CheckBox1.Checked&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__com">'&nbsp;チェックボックスに表示されている文字列の変更</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;CheckBox1.Content&nbsp;=&nbsp;<span class="visualBasic__string">&quot;チェックされました&quot;</span>&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__com">'&nbsp;文字色を赤に変更</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">Dim</span>&nbsp;mojishoku&nbsp;<span class="visualBasic__keyword">As</span>&nbsp;<span class="visualBasic__keyword">New</span>&nbsp;SolidColorBrush&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;mojishoku.Color&nbsp;=&nbsp;Colors.Red&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;CheckBox1.Foreground&nbsp;=&nbsp;mojishoku&nbsp;
<span class="visualBasic__keyword">End</span>&nbsp;<span class="visualBasic__keyword">Sub</span>&nbsp;
&nbsp;
<span class="visualBasic__keyword">Private</span>&nbsp;<span class="visualBasic__keyword">Sub</span>&nbsp;CheckBox1_Unchecked(<span class="visualBasic__keyword">ByVal</span>&nbsp;sender&nbsp;<span class="visualBasic__keyword">As</span>&nbsp;System.<span class="visualBasic__keyword">Object</span>,&nbsp;<span class="visualBasic__keyword">ByVal</span>&nbsp;e&nbsp;<span class="visualBasic__keyword">As</span>&nbsp;<a class="libraryLink" href="http://msdn.microsoft.com/ja-JP/library/System.Windows.RoutedEventArgs.aspx" target="_blank" title="Auto generated link to System.Windows.RoutedEventArgs">System.Windows.RoutedEventArgs</a>)&nbsp;<span class="visualBasic__keyword">Handles</span>&nbsp;CheckBox1.Unchecked&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__com">'&nbsp;チェックボックスに表示されている文字列の変更</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;CheckBox1.Content&nbsp;=&nbsp;<span class="visualBasic__string">&quot;チェックされていません&quot;</span>&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__com">'&nbsp;文字色を黒に変更</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">Dim</span>&nbsp;mojishoku&nbsp;<span class="visualBasic__keyword">As</span>&nbsp;<span class="visualBasic__keyword">New</span>&nbsp;SolidColorBrush&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;mojishoku.Color&nbsp;=&nbsp;Colors.Black&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;CheckBox1.Foreground&nbsp;=&nbsp;mojishoku&nbsp;
<span class="visualBasic__keyword">End</span>&nbsp;<span class="visualBasic__keyword">Sub</span></pre>
</div>
</div>
</div>
<div class="endscriptcode">&nbsp;</div>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>C#</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">スクリプトの編集</span>|<span class="pluginRemoveHolderLink">{#scriptcode_dlg.remove_script}</span></div>
<span class="hidden">csharp</span>

<div class="preview">
<pre id="codePreview" class="csharp"><span class="cs__keyword">private</span>&nbsp;<span class="cs__keyword">void</span>&nbsp;checkBox1_Checked(<span class="cs__keyword">object</span>&nbsp;sender,&nbsp;RoutedEventArgs&nbsp;e)&nbsp;
{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__com">//&nbsp;チェックボックスに表示されている文字列の変更</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;checkBox1.Content&nbsp;=&nbsp;<span class="cs__string">&quot;チェックされました&quot;</span>;&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__com">//&nbsp;文字色を赤に変更</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;SolidColorBrush&nbsp;mojishoku&nbsp;=&nbsp;<span class="cs__keyword">new</span>&nbsp;SolidColorBrush();&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;mojishoku.Color&nbsp;=&nbsp;Colors.Red;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;checkBox1.Foreground&nbsp;=&nbsp;mojishoku;&nbsp;
}&nbsp;
&nbsp;
<span class="cs__keyword">private</span>&nbsp;<span class="cs__keyword">void</span>&nbsp;checkBox1_Unchecked(<span class="cs__keyword">object</span>&nbsp;sender,&nbsp;RoutedEventArgs&nbsp;e)&nbsp;
{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__com">//&nbsp;チェックボックスに表示されている文字列の変更</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;checkBox1.Content&nbsp;=&nbsp;<span class="cs__string">&quot;チェックされていません&quot;</span>;&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__com">//&nbsp;文字色を黒に変更</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;SolidColorBrush&nbsp;mojishoku&nbsp;=&nbsp;<span class="cs__keyword">new</span>&nbsp;SolidColorBrush();&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;mojishoku.Color&nbsp;=&nbsp;Colors.Black;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;checkBox1.Foreground&nbsp;=&nbsp;mojishoku;&nbsp;
}</pre>
</div>
</div>
</div>
<hr>
<div>
<table>
<tbody>
<tr>
<td><a href="http://msdn.microsoft.com/ja-jp/samplecode.recipe" target="_blank"><img title="Code Recipe" src="http://msdn.microsoft.com/ff950935.coderecipe_180x70%28ja-jp,MSDN.10%29.jpg" border="0" alt="Code Recipe" width="180" height="70" style="margin-top:3px"></a></td>
<td><a href="http://msdn.microsoft.com/ja-jp/silverlight/" target="_blank"><img title="Silverlight デベロッパー センター" src="http://msdn.microsoft.com/ff950935.silverlight_180x70%28ja-jp,MSDN.10%29.jpg" border="0" alt="Code Recipe" width="180" height="70" style="margin-top:3px"></a></td>
<td>
<ul>
<li>もっと他のコンテンツを見る &gt;&gt; <a href="http://msdn.microsoft.com/ja-jp/ff363212" target="_blank">
逆引きサンプル コード一覧へ</a> </li><li>もっと他のレシピを見る &gt;&gt; <a href="http://msdn.microsoft.com/ja-jp/samplecode.recipe" target="_blank">
Code Recipe へ</a> </li><li>もっと&nbsp;Silverlight の情報を見る &gt;&gt; <a href="http://msdn.microsoft.com/ja-jp/silverlight/" target="_blank">
Silverlight デベロッパー センターへ</a> </li><li>もっと他のコンテンツを見る &gt;&gt; <a href="http://msdn.microsoft.com/ja-jp/silverlight/hh201902" target="_blank">
Silverlight 大全 特集ページ</a> </li></ul>
</td>
</tr>
</tbody>
</table>
</div>
<p style="margin-top:20px"><a href="#top"><img src="16106-image.png" alt=""> ページのトップへ</a></p>
