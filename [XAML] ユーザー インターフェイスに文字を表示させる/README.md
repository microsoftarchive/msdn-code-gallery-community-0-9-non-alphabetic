# [XAML] ユーザー インターフェイスに文字を表示させる
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

<p>動作確認環境: Silverlight 4、Visual Studio 2010、Microsoft Silverlight 4 Tools for Visual Studio 2010、Windows 7</p>
<p>Silverlight を使用したアプリケーションで、ユーザー インターフェイスに文字を表示させる場合は Label コントロール または TextBlock コントロールを使用します。<br>
<br>
どちらも任意の文字列を任意のフォント及びフォント サイズで表示できます。Label コントロールは TextBlock コントロールを比較して機能が豊富です。TextBlock の利点は、軽量であることと改行ができることです。<br>
<br>
ここでは、XAML を使用した実装方法を紹介します。Visual Studio を使用した場合は、ツール ボックスにあるコントロールをドラッグ アンド ドロップすることにより、コントロールを使用できます。XAML のコード中に記述されている各プロパティは、Visual Studio のプロパティ ウィンドウからも変更できます。<br>
<br>
以下の XAML のコードは、Label コントロールと TextBlock コントロールを Grid パネルの中で使用した例です。</p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>XAML</span></div>
<div class="pluginEditHolderLink">スクリプトの編集</div>
<span class="hidden">xaml</span>

<div class="preview">
<pre id="codePreview" class="xaml"><span class="xaml__tag_start">&lt;Grid</span>&nbsp;x:<span class="xaml__attr_name">Name</span>=<span class="xaml__attr_value">&quot;LayoutRoot&quot;</span>&nbsp;<span class="xaml__attr_name">Background</span>=<span class="xaml__attr_value">&quot;White&quot;</span><span class="xaml__tag_start">&gt;&nbsp;
</span>&nbsp;&nbsp;&nbsp;&nbsp;<span class="xaml__tag_start">&lt;sdk</span>:Label&nbsp;<span class="xaml__attr_name">Content</span>=<span class="xaml__attr_value">&quot;Label&quot;</span>&nbsp;<span class="xaml__attr_name">Height</span>=<span class="xaml__attr_value">&quot;28&quot;</span>&nbsp;<span class="xaml__attr_name">HorizontalAlignment</span>=<span class="xaml__attr_value">&quot;Left&quot;</span>&nbsp;<span class="xaml__attr_name">Margin</span>=<span class="xaml__attr_value">&quot;60,40,0,0&quot;</span>&nbsp;<span class="xaml__attr_name">Name</span>=<span class="xaml__attr_value">&quot;label1&quot;</span>&nbsp;<span class="xaml__attr_name">VerticalAlignment</span>=<span class="xaml__attr_value">&quot;Top&quot;</span>&nbsp;<span class="xaml__attr_name">Width</span>=<span class="xaml__attr_value">&quot;120&quot;</span>&nbsp;<span class="xaml__tag_start">/&gt;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="xaml__tag_start">&lt;TextBlock</span>&nbsp;<span class="xaml__attr_name">Height</span>=<span class="xaml__attr_value">&quot;23&quot;</span>&nbsp;<span class="xaml__attr_name">HorizontalAlignment</span>=<span class="xaml__attr_value">&quot;Left&quot;</span>&nbsp;<span class="xaml__attr_name">Margin</span>=<span class="xaml__attr_value">&quot;60,90,0,0&quot;</span>&nbsp;<span class="xaml__attr_name">Name</span>=<span class="xaml__attr_value">&quot;textBlock1&quot;</span>&nbsp;<span class="xaml__attr_name">Text</span>=<span class="xaml__attr_value">&quot;TextBlock&quot;</span>&nbsp;<span class="xaml__attr_name">VerticalAlignment</span>=<span class="xaml__attr_value">&quot;Top&quot;</span>&nbsp;<span class="xaml__tag_start">/&gt;</span>&nbsp;
<span class="xaml__tag_end">&lt;/Grid&gt;</span>&nbsp;
&nbsp;
</pre>
</div>
</div>
</div>
<p>Visual Studio の XAML デザイナー上でみると、このようになっています。</p>
<p><img src="http://i1.code.msdn.microsoft.com/silverlight-howto-b11afc27/image/file/21370/1/image001.gif" alt="図 1" width="300" height="210" style="margin-bottom:20px"></p>
<p>各コントロールのプロパティの説明です。</p>
<dl><dt><strong>Content:</strong></dt><dt></dt><dd>表示させる文字列です。Label コントロールのときに使用します。 </dd><dt><strong>Text:</strong></dt><dt></dt><dd>表示させる文字列です。TextBlock コントロールのときに使用します。 </dd><dt><strong>Height:</strong></dt><dt></dt><dd>コントロールの見た目の高さです。 </dd><dt><strong>HorizontalAlignment:</strong></dt><dt></dt><dd>パネル内のコントロールの水平方向の位置を、Left、Center、Right、Stretch で表します。ここでは Left が指定されているので、コントロールはパネル内で左寄せされて表示されます。ただし、Margin プロパティが設定されていたときは、その値の分のマージンが設定されます。
</dd><dt><strong>Margin:</strong></dt><dt></dt><dd>4 つのパラメーターは、順に左側、上側、右側、下側のマージンを示します。マージンとは、その親となるパネルまたはグリッドの縁からの距離です。主に Grid パネルに貼り付けているときに使用します。
</dd><dt><strong>Name:</strong></dt><dt></dt><dd>コントロールの名前です。Visual Basic や C# のコードから呼び出すときに、ここで設定した名前を使用します。 </dd><dt><strong>VerticalAlignment:</strong></dt><dt></dt><dd>パネル内のコントロールの垂直方向の位置を、Top、Center、Bottom、Stretch で表します。ここでは Top が指定されているので、コントロールはパネル内で上寄せされて表示されます。ただし、Margin プロパティが設定されていたときは、その値の分のマージンが設定されます。
</dd><dt><strong>Width:</strong></dt><dt></dt><dd>コントロールの見た目の幅です。 </dd></dl>
<p>これら以外にも、下記のプロパティを設定することにより、見た目を変更できます。ここでは、よく使用されるプロパティを紹介します。</p>
<p style="margin-top:20px"><strong>[Label、TextBlock の両方で使用できるプロパティ]</strong></p>
<dl><dt><strong>FontFamily:</strong></dt><dd>表示するときに使用するフォント名です。 </dd></dl>
<dl><dt><strong>FontSize:</strong></dt><dd>フォントの大きさです。 </dd><dt><strong>FontStyle:</strong></dt><dd>このプロパティを Italic に変更すると、斜体で表示されます。 </dd><dt><strong>Foreground:</strong></dt><dd>文字の色です。グラデーションをかけたり、イメージを指定することで画像を背景として設定することもできます。 </dd><dt><strong>Visibility:</strong></dt><dd>表示と非表示を切り替えることができます。Visible を指定すると表示し、Collapsed を指定すると表示しなくなります。 </dd></dl>
<p style="margin-top:20px"><strong>[Label で使用できるプロパティ]</strong></p>
<dl><dt><strong>Background:</strong></dt><dd>背景色です。グラデーションをかけたり、イメージを指定することで画像を背景として設定することもできます。 </dd></dl>
<p style="margin-top:20px"><strong>[TextBlock で使用できるプロパティ]</strong></p>
<dl><dt><strong>TextAlignment:</strong></dt><dd>表示させるテキストを、左揃え、中央揃え、右揃えに設定できます。 </dd><dt><strong>TextWrapping:</strong></dt><dd>複数行の表示を可能にします。Wrap に変更することにより、表示する文字列が横幅を超えたときに改行します。 </dd></dl>
<p>以下は、FontSize と Foreground を変更した例です。</p>
<p>&nbsp;</p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>XAML</span></div>
<div class="pluginEditHolderLink">スクリプトの編集</div>
<span class="hidden">xaml</span>

<div class="preview">
<pre id="codePreview" class="xaml"><span class="xaml__tag_start">&lt;sdk</span>:Label&nbsp;<span class="xaml__attr_name">Content</span>=<span class="xaml__attr_value">&quot;Label&quot;</span>&nbsp;<span class="xaml__attr_name">Height</span>=<span class="xaml__attr_value">&quot;28&quot;</span>&nbsp;<span class="xaml__attr_name">HorizontalAlignment</span>=<span class="xaml__attr_value">&quot;Left&quot;</span>&nbsp;<span class="xaml__attr_name">Margin</span>=<span class="xaml__attr_value">&quot;60,40,0,0&quot;</span>&nbsp;<span class="xaml__attr_name">Name</span>=<span class="xaml__attr_value">&quot;label1&quot;</span>&nbsp;<span class="xaml__attr_name">VerticalAlignment</span>=<span class="xaml__attr_value">&quot;Top&quot;</span>&nbsp;<span class="xaml__attr_name">Width</span>=<span class="xaml__attr_value">&quot;120&quot;</span>&nbsp;<span class="xaml__attr_name">Visibility</span>=<span class="xaml__attr_value">&quot;Collapsed&quot;</span>&nbsp;<span class="xaml__attr_name">FontSize</span>=<span class="xaml__attr_value">&quot;24&quot;</span>&nbsp;<span class="xaml__attr_name">Foreground</span>=<span class="xaml__attr_value">&quot;Red&quot;</span><span class="xaml__tag_start">&gt;</span><span class="xaml__tag_end">&lt;/sdk:Label&gt;</span>&nbsp;
<span class="xaml__tag_start">&lt;TextBlock</span>&nbsp;<span class="xaml__attr_name">Height</span>=<span class="xaml__attr_value">&quot;31&quot;</span>&nbsp;<span class="xaml__attr_name">HorizontalAlignment</span>=<span class="xaml__attr_value">&quot;Left&quot;</span>&nbsp;<span class="xaml__attr_name">Margin</span>=<span class="xaml__attr_value">&quot;60,90,0,0&quot;</span>&nbsp;<span class="xaml__attr_name">Name</span>=<span class="xaml__attr_value">&quot;textBlock1&quot;</span>&nbsp;<span class="xaml__attr_name">Text</span>=<span class="xaml__attr_value">&quot;TextBlock&quot;</span>&nbsp;<span class="xaml__attr_name">VerticalAlignment</span>=<span class="xaml__attr_value">&quot;Top&quot;</span>&nbsp;<span class="xaml__attr_name">FontSize</span>=<span class="xaml__attr_value">&quot;24&quot;</span>&nbsp;<span class="xaml__attr_name">Foreground</span>=<span class="xaml__attr_value">&quot;Red&quot;</span><span class="xaml__tag_start">&gt;</span><span class="xaml__tag_end">&lt;/TextBlock&gt;</span>&nbsp;
&nbsp;
</pre>
</div>
</div>
</div>
<div class="endscriptcode"><img src="http://i1.code.msdn.microsoft.com/silverlight-howto-b11afc27/image/file/21371/1/image002.gif" alt="図 2" width="332" height="233"></div>
<p>&nbsp;</p>
<p>各プロパティは、プログラムの実行時に変更することができます。<br>
<br>
以下のコードは、表示する文字列を変える例です。</p>
<p>&nbsp;</p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>Visual Basic</span></div>
<div class="pluginEditHolderLink">スクリプトの編集</div>
<span class="hidden">vb</span>

<div class="preview">
<pre id="codePreview" class="vb"><span class="visualBasic__com">'&nbsp;Label&nbsp;コントロールの文字を変更。Label1&nbsp;は、Name&nbsp;プロパティで設定した名前</span>&nbsp;
Label1.Content&nbsp;=&nbsp;<span class="visualBasic__string">&quot;ラベルの文字を変更&quot;</span>&nbsp;
<span class="visualBasic__com">'&nbsp;TextBlock&nbsp;コントロールの文字を変更。TextBlock1&nbsp;は、Name&nbsp;プロパティで設定した名前</span>&nbsp;
TextBlock1.Text&nbsp;=&nbsp;<span class="visualBasic__string">&quot;テキストブロックの文字を変更&quot;</span>&nbsp;
&nbsp;
</pre>
</div>
</div>
</div>
<div class="endscriptcode">&nbsp;</div>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>C#</span></div>
<div class="pluginEditHolderLink">スクリプトの編集</div>
<span class="hidden">csharp</span>

<div class="preview">
<pre id="codePreview" class="csharp"><span class="cs__com">//&nbsp;Label&nbsp;コントロールの文字を変更。label1&nbsp;は、Name&nbsp;プロパティで設定した名前</span>&nbsp;
label1.Content&nbsp;=&nbsp;<span class="cs__string">&quot;ラベルの文字を変更&quot;</span>;&nbsp;
<span class="cs__com">//&nbsp;TextBlock&nbsp;コントロールの文字を変更。textBlock1&nbsp;は、Name&nbsp;プロパティで設定した名前</span>&nbsp;
textBlock1.Text&nbsp;=&nbsp;<span class="cs__string">&quot;テキストブロックの文字を変更&quot;</span>;&nbsp;
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
