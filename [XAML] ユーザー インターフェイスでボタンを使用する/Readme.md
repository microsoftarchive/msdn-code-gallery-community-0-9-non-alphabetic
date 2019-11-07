# [XAML] ユーザー インターフェイスでボタンを使用する
## Requires
- 
## License
- Apache License, Version 2.0
## Technologies
- Silverlight
## Topics
- Silverlight アプリケーション
- 逆引きサンプル コード
## Updated
- 05/23/2011
## Description

<p>動作確認環境: Silverlight 4、Visual Studio 2010、Microsoft Silverlight 4 Tools for Visual Studio 2010、 Windows 7</p>
<p>Silverlight を使用したアプリケーションで、ユーザー インターフェイスとしてボタンを使用する場合は Button コントロールを使用します。</p>
<p>ここでは、XAML を使用した実装方法を紹介します。Visual Studio を使用した場合は、ツール ボックスにあるコントロールをドラッグ アンド ドロップすることにより、コントロールを使用できます。XAML のコード中に記述されている各プロパティは、Visual Studio のプロパティ ウィンドウからも変更できます。</p>
<p>以下の XAML のコードは、Button コントロールを Grid パネルの中で使用した例です。</p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>XAML</span></div>
<div class="pluginEditHolderLink">スクリプトの編集</div>
<span class="hidden">xaml</span>
<pre class="hidden">&lt;Grid x:Name=&quot;LayoutRoot&quot; Background=&quot;White&quot;&gt;
    &lt;Button Content=&quot;Button&quot; Height=&quot;23&quot; HorizontalAlignment=&quot;Left&quot; Margin=&quot;30,20,0,0&quot; Name=&quot;button1&quot; VerticalAlignment=&quot;Top&quot; Width=&quot;75&quot; /&gt;
&lt;/Grid&gt;</pre>
<div class="preview">
<pre id="codePreview" class="xaml"><span class="xaml__tag_start">&lt;Grid</span>&nbsp;x:<span class="xaml__attr_name">Name</span>=<span class="xaml__attr_value">&quot;LayoutRoot&quot;</span>&nbsp;<span class="xaml__attr_name">Background</span>=<span class="xaml__attr_value">&quot;White&quot;</span><span class="xaml__tag_start">&gt;&nbsp;
</span>&nbsp;&nbsp;&nbsp;&nbsp;<span class="xaml__tag_start">&lt;Button</span>&nbsp;<span class="xaml__attr_name">Content</span>=<span class="xaml__attr_value">&quot;Button&quot;</span>&nbsp;<span class="xaml__attr_name">Height</span>=<span class="xaml__attr_value">&quot;23&quot;</span>&nbsp;<span class="xaml__attr_name">HorizontalAlignment</span>=<span class="xaml__attr_value">&quot;Left&quot;</span>&nbsp;<span class="xaml__attr_name">Margin</span>=<span class="xaml__attr_value">&quot;30,20,0,0&quot;</span>&nbsp;<span class="xaml__attr_name">Name</span>=<span class="xaml__attr_value">&quot;button1&quot;</span>&nbsp;<span class="xaml__attr_name">VerticalAlignment</span>=<span class="xaml__attr_value">&quot;Top&quot;</span>&nbsp;<span class="xaml__attr_name">Width</span>=<span class="xaml__attr_value">&quot;75&quot;</span>&nbsp;<span class="xaml__tag_start">/&gt;</span>&nbsp;
<span class="xaml__tag_end">&lt;/Grid&gt;</span>&nbsp;
/pre&gt;
</pre>
</div>
</div>
</div>
<p>Visual Studio の XAML デザイナー上でみると、このようになっています。</p>
<p><img src="21463-image001.gif" alt="図 1" width="265" height="176"></p>
<p>各コントロールのプロパティの説明です。</p>
<dl><dt><strong>Content: </strong></dt><dd>ボタンの上に表示される文字列です。 </dd><dt><strong>Height: </strong></dt><dd>コントロールの見た目の高さです。 </dd><dt><strong>HorizontalAlignment: </strong></dt><dd>パネル内のコントロールの水平方向の位置を、Left、Center、Right、Stretch で表します。ここでは Left が指定されているので、コントロールはパネル内で左寄せされて表示されます。ただし、Margin プロパティが設定されていたときは、その値の分のマージンが設定されます。
</dd><dt><strong>Margin: </strong></dt><dd>4 つのパラメーターは、順に左側、上側、右側、下側のマージンを示します。マージンとは、その親となるパネルまたはグリッドの縁からの距離です。主に Grid パネルに貼り付けているときに使用します。
</dd><dt><strong>Name: </strong></dt><dd>コントロールの名前です。Visual Basic や C# のコードから呼び出すときに、ここで設定した名前を使用します。 </dd><dt><strong>VerticalAlignment: </strong></dt><dd>パネル内のコントロールの垂直方向の位置を、Top、Center、Bottom、Stretch で表します。ここでは Top が指定されているので、コントロールはパネル内で上寄せされて表示されます。ただし、Margin プロパティが設定されていたときは、その値の分のマージンが設定されます。
</dd><dt><strong>Width: </strong></dt><dd>コントロールの見た目の幅です。
<dl></dl>
</dd></dl>
<p>これら以外にも、下記のプロパティを設定することにより、見た目を変更できます。ここでは、よく使用されるプロパティを紹介します。</p>
<dl><dt><strong>Background: </strong></dt><dd>背景色です。グラデーションをかけたり、イメージを指定することで画像を背景として設定することもできます。 </dd><dt><strong>BorderBrush: </strong></dt><dd>枠の色です。 </dd><dt><strong>BorderThickness: </strong></dt><dd>枠の線の幅です。 </dd><dt><strong>FontFamily: </strong></dt><dd>表示するときに使用するフォント名です。 </dd><dt><strong>FontSize: </strong></dt><dd>フォントの大きさです。 </dd><dt><strong>FontStyle: </strong></dt><dd>このプロパティを Italic に変更すると、斜体で表示されます。 </dd><dt><strong>Foreground: </strong></dt><dd>文字の色です。グラデーションをかけたり、イメージを指定することで画像を背景として設定することもできます。 </dd><dt><strong>Visibility: </strong></dt><dd>表示と非表示を切り替えることができます。Visible を指定すると表示し、Collapsed を指定すると表示しなくなります。 </dd></dl>
<p>以下は、Content プロパティに &quot;ここに入力&quot; と表示させ、コントロールの大きさや、FontSize、Foreground を変更した例です。</p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>XAML</span></div>
<div class="pluginEditHolderLink">スクリプトの編集</div>
<span class="hidden">xaml</span>
<pre class="hidden">    &lt;Button Content=&quot;ここをクリック&quot; Height=&quot;36&quot; HorizontalAlignment=&quot;Left&quot; Margin=&quot;30,20,0,0&quot; Name=&quot;button1&quot; VerticalAlignment=&quot;Top&quot; Width=&quot;175&quot; FontSize=&quot;20&quot; Foreground=&quot;Red&quot;&gt;&lt;/Button&gt;</pre>
<div class="preview">
<pre id="codePreview" class="xaml">&nbsp;&nbsp;&nbsp;&nbsp;<span class="xaml__tag_start">&lt;Button</span>&nbsp;<span class="xaml__attr_name">Content</span>=<span class="xaml__attr_value">&quot;ここをクリック&quot;</span>&nbsp;<span class="xaml__attr_name">Height</span>=<span class="xaml__attr_value">&quot;36&quot;</span>&nbsp;<span class="xaml__attr_name">HorizontalAlignment</span>=<span class="xaml__attr_value">&quot;Left&quot;</span>&nbsp;<span class="xaml__attr_name">Margin</span>=<span class="xaml__attr_value">&quot;30,20,0,0&quot;</span>&nbsp;<span class="xaml__attr_name">Name</span>=<span class="xaml__attr_value">&quot;button1&quot;</span>&nbsp;<span class="xaml__attr_name">VerticalAlignment</span>=<span class="xaml__attr_value">&quot;Top&quot;</span>&nbsp;<span class="xaml__attr_name">Width</span>=<span class="xaml__attr_value">&quot;175&quot;</span>&nbsp;<span class="xaml__attr_name">FontSize</span>=<span class="xaml__attr_value">&quot;20&quot;</span>&nbsp;<span class="xaml__attr_name">Foreground</span>=<span class="xaml__attr_value">&quot;Red&quot;</span><span class="xaml__tag_start">&gt;</span><span class="xaml__tag_end">&lt;/Button&gt;</span>&nbsp;
&nbsp;
</pre>
</div>
</div>
</div>
<p><img src="21464-image002.gif" alt="図 2" width="345" height="178"></p>
<p>Button コントロールは、クリックされると Clicked というイベントを発生します。</p>
<p>Visual Studio の XAML デザイナー上で、貼り付けている Button コントロールをダブルクリックすると、イベント発生時に実行されるイベント ハンドラーが生成します。</p>
<p>以下の例は、ボタンがクリックされたらボタンに表示されている文字を &quot;OK!&quot; に変更し、文字色を青に変更するプログラムの例です。</p>
<p>&nbsp;</p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>Visual Basic</span></div>
<div class="pluginEditHolderLink">スクリプトの編集</div>
<span class="hidden">vb</span>
<pre class="hidden">Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.Windows.RoutedEventArgs) Handles Button1.Click
    ' ボタンの表示する文字列を OK! に変更
    ' Button1 は、Name プロパティで設定した名前
    Button1.Content = &quot;OK!&quot;

    ' ボタンの表示する文字列の色を青に変更
    Dim mojishoku As New SolidColorBrush
    mojishoku.Color = Colors.Blue
    Button1.Foreground = mojishoku
End Sub</pre>
<div class="preview">
<pre id="codePreview" class="vb"><span class="visualBasic__keyword">Private</span>&nbsp;<span class="visualBasic__keyword">Sub</span>&nbsp;Button1_Click(<span class="visualBasic__keyword">ByVal</span>&nbsp;sender&nbsp;<span class="visualBasic__keyword">As</span>&nbsp;System.<span class="visualBasic__keyword">Object</span>,&nbsp;<span class="visualBasic__keyword">ByVal</span>&nbsp;e&nbsp;<span class="visualBasic__keyword">As</span>&nbsp;System.Windows.RoutedEventArgs)&nbsp;<span class="visualBasic__keyword">Handles</span>&nbsp;Button1.Click&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__com">'&nbsp;ボタンの表示する文字列を&nbsp;OK!&nbsp;に変更</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__com">'&nbsp;Button1&nbsp;は、Name&nbsp;プロパティで設定した名前</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;Button1.Content&nbsp;=&nbsp;<span class="visualBasic__string">&quot;OK!&quot;</span>&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__com">'&nbsp;ボタンの表示する文字列の色を青に変更</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">Dim</span>&nbsp;mojishoku&nbsp;<span class="visualBasic__keyword">As</span>&nbsp;<span class="visualBasic__keyword">New</span>&nbsp;SolidColorBrush&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;mojishoku.Color&nbsp;=&nbsp;Colors.Blue&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;Button1.Foreground&nbsp;=&nbsp;mojishoku&nbsp;
<span class="visualBasic__keyword">End</span>&nbsp;<span class="visualBasic__keyword">Sub</span>&nbsp;
&nbsp;
</pre>
</div>
</div>
</div>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>C#</span></div>
<div class="pluginEditHolderLink">スクリプトの編集</div>
<span class="hidden">csharp</span>
<pre class="hidden">private void button1_Click(object sender, RoutedEventArgs e)
{
    // ボタンの表示する文字列を OK! に変更
    // button1 は、Name プロパティで設定した名前
    button1.Content = &quot;OK!&quot;;

    // ボタンの表示する文字列の色を青に変更
    SolidColorBrush mojishoku = new SolidColorBrush();
    mojishoku.Color = Colors.Blue;
    button1.Foreground = mojishoku;
}</pre>
<div class="preview">
<pre id="codePreview" class="csharp"><span class="cs__keyword">private</span>&nbsp;<span class="cs__keyword">void</span>&nbsp;button1_Click(<span class="cs__keyword">object</span>&nbsp;sender,&nbsp;RoutedEventArgs&nbsp;e)&nbsp;
{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__com">//&nbsp;ボタンの表示する文字列を&nbsp;OK!&nbsp;に変更</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__com">//&nbsp;button1&nbsp;は、Name&nbsp;プロパティで設定した名前</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;button1.Content&nbsp;=&nbsp;<span class="cs__string">&quot;OK!&quot;</span>;&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__com">//&nbsp;ボタンの表示する文字列の色を青に変更</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;SolidColorBrush&nbsp;mojishoku&nbsp;=&nbsp;<span class="cs__keyword">new</span>&nbsp;SolidColorBrush();&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;mojishoku.Color&nbsp;=&nbsp;Colors.Blue;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;button1.Foreground&nbsp;=&nbsp;mojishoku;&nbsp;
}&nbsp;
&nbsp;
</pre>
</div>
</div>
</div>
<hr>
<div>
<table>
<tbody>
<tr>
<td><a href="http://msdn.microsoft.com/ja-jp/samplecode.recipe" target="_blank"><img title="Code Recipe" src="-ff950935.coderecipe_180x70%28ja-jp,msdn.10%29.jpg" border="0" alt="Code Recipe" width="180" height="70" style="margin-top:3px"></a></td>
<td><a href="http://msdn.microsoft.com/ja-jp/silverlight/" target="_blank"><img title="Silverlight デベロッパー センター" src="-ff950935.silverlight_180x70%28ja-jp,msdn.10%29.jpg" border="0" alt="Code Recipe" width="180" height="70" style="margin-top:3px"></a></td>
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
