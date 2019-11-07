# [XAML] コントロールのまわりに枠を表示する
## Requires
- 
## License
- Apache License, Version 2.0
## Technologies
- Silverlight
## Topics
- Silverlight アプリケーション
- 逆引きサンプル コード
- Silverlight 大全 特集
## Updated
- 05/23/2011
## Description

<p>動作確認環境: Silverlight 4、Visual Studio 2010、Microsoft Silverlight 4 Tools for Visual Studio 2010、Windows 7</p>
<hr>
<p>Silverlight を使用したアプリケーションで、コントロールのまわりに枠を表示させるには、Border コントロールを使用します。</p>
<p>ここでは、XAML を使用した実装方法を紹介します。Visual Studio を使用した場合は、ツール ボックスにあるコントロールをドラッグ アンド ドロップすることにより、コントロールを使用できます。XAML のコード中に記述されている各プロパティは、Visual Studio のプロパティ ウィンドウからも変更できます。</p>
<p>以下の XAML のコードは、Grid パネルに貼り付けている Button コントロールのまわりに、Border コントロールによって枠を表示させている例です。</p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>XAML</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">スクリプトの編集</span>|<span class="pluginRemoveHolderLink">{#scriptcode_dlg.remove_script}</span></div>
<span class="hidden">xaml</span>
<pre class="hidden">&lt;Grid x:Name=&quot;LayoutRoot&quot; Background=&quot;White&quot;&gt;
    &lt;Border BorderBrush=&quot;Silver&quot; BorderThickness=&quot;5&quot; Height=&quot;33&quot; HorizontalAlignment=&quot;Left&quot; Margin=&quot;30,20,0,0&quot; Name=&quot;border1&quot; VerticalAlignment=&quot;Top&quot; Width=&quot;85&quot;&gt;
        &lt;Button Content=&quot;Button&quot; Height=&quot;23&quot; Name=&quot;button1&quot; Width=&quot;75&quot; /&gt;
    &lt;/Border&gt;
&lt;/Grid&gt;</pre>
<div class="preview">
<pre id="codePreview" class="xaml"><span class="xaml__tag_start">&lt;Grid</span>&nbsp;x:<span class="xaml__attr_name">Name</span>=<span class="xaml__attr_value">&quot;LayoutRoot&quot;</span>&nbsp;<span class="xaml__attr_name">Background</span>=<span class="xaml__attr_value">&quot;White&quot;</span><span class="xaml__tag_start">&gt;&nbsp;
</span>&nbsp;&nbsp;&nbsp;&nbsp;<span class="xaml__tag_start">&lt;Border</span>&nbsp;<span class="xaml__attr_name">BorderBrush</span>=<span class="xaml__attr_value">&quot;Silver&quot;</span>&nbsp;<span class="xaml__attr_name">BorderThickness</span>=<span class="xaml__attr_value">&quot;5&quot;</span>&nbsp;<span class="xaml__attr_name">Height</span>=<span class="xaml__attr_value">&quot;33&quot;</span>&nbsp;<span class="xaml__attr_name">HorizontalAlignment</span>=<span class="xaml__attr_value">&quot;Left&quot;</span>&nbsp;<span class="xaml__attr_name">Margin</span>=<span class="xaml__attr_value">&quot;30,20,0,0&quot;</span>&nbsp;<span class="xaml__attr_name">Name</span>=<span class="xaml__attr_value">&quot;border1&quot;</span>&nbsp;<span class="xaml__attr_name">VerticalAlignment</span>=<span class="xaml__attr_value">&quot;Top&quot;</span>&nbsp;<span class="xaml__attr_name">Width</span>=<span class="xaml__attr_value">&quot;85&quot;</span><span class="xaml__tag_start">&gt;&nbsp;
</span>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="xaml__tag_start">&lt;Button</span>&nbsp;<span class="xaml__attr_name">Content</span>=<span class="xaml__attr_value">&quot;Button&quot;</span>&nbsp;<span class="xaml__attr_name">Height</span>=<span class="xaml__attr_value">&quot;23&quot;</span>&nbsp;<span class="xaml__attr_name">Name</span>=<span class="xaml__attr_value">&quot;button1&quot;</span>&nbsp;<span class="xaml__attr_name">Width</span>=<span class="xaml__attr_value">&quot;75&quot;</span>&nbsp;<span class="xaml__tag_start">/&gt;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="xaml__tag_end">&lt;/Border&gt;</span>&nbsp;
<span class="xaml__tag_end">&lt;/Grid&gt;</span></pre>
</div>
</div>
</div>
<p>Visual Studio の XAML デザイナー上でみると、このようになっています。Button コントロールのまわりに見える灰色の部分が Border コントロールです。</p>
<p><img src="22423-image001.gif" alt="図 1" width="288" height="184"></p>
<p>Border コントロールは、別のコントロールやパネルとともに使用します。Border コントロールの中に入れることができるコントロールまたはパネルは、1 つのみです。</p>
<p>各コントロールのプロパティの説明です。</p>
<dl><dt><strong>BorderBrush:</strong> </dt><dd>枠の色です。 </dd><dt><strong>BorderThickness:</strong> </dt><dd>枠の線の幅です。 </dd><dt><strong>Height:</strong> </dt><dd>コントロールの見た目の高さです。 </dd><dt><strong>HorizontalAlignment:</strong> </dt><dd>パネル内のコントロールの水平方向の位置を、Left、Center、Right、Stretch で表します。ここでは Left が指定されているので、コントロールはパネル内で左寄せされて表示されます。ただし、Margin プロパティが設定されていたときは、その値の分のマージンが設定されます。
</dd><dt><strong>Margin:</strong> </dt><dd>4 つのパラメーターは、順に左側、上側、右側、下側のマージンを示します。マージンとは、その親となるパネルまたはグリッドの縁からの距離です。主に Grid パネルに貼り付けているときに使用します。
</dd><dt><strong>Name:</strong> </dt><dd>コントロールの名前です。Visual Basic や C# のコードから呼び出すときに、ここで設定した名前を使用します。 </dd><dt><strong>VerticalAlignment:</strong> </dt><dd>パネル内のコントロールの垂直方向の位置を、Top、Center、Bottom、Stretch で表します。ここでは Top が指定されているので、コントロールはパネル内で上寄せされて表示されます。ただし、Margin プロパティが設定されていたときは、その値の分のマージンが設定されます。
</dd><dt><strong>Width:</strong> </dt><dd>コントロールの見た目の幅です。 </dd></dl>
<p>これら以外にも、下記のプロパティを設定することにより、見た目を変更できます。ここでは、よく使用されるプロパティを紹介します。</p>
<dl><dt><strong>Background:</strong> </dt><dd>Border コントロールの内部の背景色です。グラデーションをかけたり、イメージを指定することで画像を背景として設定することもできます。 </dd><dt><strong>CornerRadius:</strong> </dt><dd>数値を指定すると、角を丸めることができます。 </dd><dt><strong>Visibility:</strong> </dt><dd>表示と非表示を切り替えることができます。Visible を指定すると表示し、Collapsed を指定すると表示しなくなります。 </dd></dl>
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
<p style="margin-top:20px"><a href="#top"><img src="16106-image.png" alt=""> ページのトップへ</a></p>
