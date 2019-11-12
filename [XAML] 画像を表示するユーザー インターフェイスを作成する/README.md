# [XAML] 画像を表示するユーザー インターフェイスを作成する
## License
- Apache License, Version 2.0
## Technologies
- Silverlight
## Topics
- Silverlight アプリケーション
- 逆引きサンプル コード
- Silverlight 大全 特集
## Updated
- 05/25/2011
## Description

<p>動作確認環境: Silverlight 4、Visual Studio 2010、Microsoft Silverlight 4 Tools for Visual Studio 2010、Windows 7</p>
<hr>
<p>Silverlight を使用したアプリケーションで、画像をユーザー インターフェイスに表示させる場合は Image コントロールを使用します。</p>
<p>以下の XAML のコードは、Image コントロールを Grid パネルの中で使用した例です。この例では、サンプル ピクチャーにあるペンギンの画像を表示させています。</p>
<p>表示させる画像の選択は、Visual Studio の XAML デザイナー上に貼り付けている Image コントロールを選択し、プロパティ ウィンドウの Source と表示されているプロパティの右端にある [...] ボタンをクリックします。[イメージの選択] ダイアログが表示されたら、[追加] ボタンをクリックし、表示させたい画像を選択します。</p>
<p>以下の XAML のコードは、画像を選択したときの例です。</p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>XAML</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">スクリプトの編集</span>|<span class="pluginRemoveHolderLink">{#scriptcode_dlg.remove_script}</span></div>
<span class="hidden">xaml</span>

<div class="preview">
<pre id="codePreview" class="xaml"><span class="xaml__tag_start">&lt;Grid</span>&nbsp;x:<span class="xaml__attr_name">Name</span>=<span class="xaml__attr_value">&quot;LayoutRoot&quot;</span>&nbsp;<span class="xaml__attr_name">Background</span>=<span class="xaml__attr_value">&quot;White&quot;</span><span class="xaml__tag_start">&gt;&nbsp;
</span>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="xaml__tag_start">&lt;Image</span>&nbsp;<span class="xaml__attr_name">Height</span>=<span class="xaml__attr_value">&quot;150&quot;</span>&nbsp;<span class="xaml__attr_name">HorizontalAlignment</span>=<span class="xaml__attr_value">&quot;Left&quot;</span>&nbsp;<span class="xaml__attr_name">Margin</span>=<span class="xaml__attr_value">&quot;30,20,0,0&quot;</span>&nbsp;<span class="xaml__attr_name">Name</span>=<span class="xaml__attr_value">&quot;image1&quot;</span>&nbsp;<span class="xaml__attr_name">Stretch</span>=<span class="xaml__attr_value">&quot;Fill&quot;</span>&nbsp;<span class="xaml__attr_name">VerticalAlignment</span>=<span class="xaml__attr_value">&quot;Top&quot;</span>&nbsp;<span class="xaml__attr_name">Width</span>=<span class="xaml__attr_value">&quot;200&quot;</span>&nbsp;<span class="xaml__attr_name">Source</span>=<span class="xaml__attr_value">&quot;/SLbook_Image;component/Images/Penguins.jpg&quot;</span>&nbsp;<span class="xaml__tag_start">/&gt;</span>&nbsp;
<span class="xaml__tag_end">&lt;/Grid&gt;</span></pre>
</div>
</div>
</div>
<p>Visual Studio の XAML デザイナー上でみると、このようになっています。</p>
<p><img src="22418-image001.jpg" alt="図 1" width="358" height="276"></p>
<p>各コントロールのプロパティの説明です。</p>
<dl><dt><strong>Height:</strong> </dt><dd>コントロールの見た目の高さです。 </dd><dt><strong>HorizontalAlignment:</strong> </dt><dd>パネル内のコントロールの水平方向の位置を、Left、Center、Right、Stretch で表します。ここでは Left が指定されているので、コントロールはパネル内で左寄せされて表示されます。ただし、Margin プロパティが設定されていたときは、その値の分のマージンが設定されます。
</dd><dt><strong>Margin:</strong> </dt><dd>4 つのパラメーターは、順に左側、上側、右側、下側のマージンを示します。マージンとは、その親となるパネルまたはグリッドの縁からの距離です。主に Grid パネルに貼り付けているときに使用します。
</dd><dt><strong>Name:</strong> </dt><dd>コントロールの名前です。Visual Basic や C# のコードから呼び出すときに、ここで設定した名前を使用します。 </dd><dt><strong>Source:</strong> </dt><dd>表示する画像を指定します。画像の選択はプロパティ ウィンドウで行います。プロパティ ウィンドウの Source と表示されているプロパティの右端にある [...] ボタンをクリックします。[イメージの選択] ダイアログが表示されたら、[追加] ボタンをクリックし、表示させたい画像を選択します。
</dd><dt><strong>VerticalAlignment:</strong> </dt><dd>パネル内のコントロールの垂直方向の位置を、Top、Center、Bottom、Stretch で表します。ここでは Top が指定されているので、コントロールはパネル内で上寄せされて表示されます。ただし、Margin プロパティが設定されていたときは、その値の分のマージンが設定されます。
</dd><dt><strong>Width :</strong> </dt><dd>コントロールの見た目の幅です。 </dd></dl>
<p>下記のプロパティを設定することにより、見た目を変更できます。ここでは、よく使用されるプロパティを紹介します。</p>
<dl><dt><strong>Stretch:</strong> </dt><dd>画像の表示方法を変更します。Fill を指定したときは、Image コントロール全体に画像が表示されるように、垂直方向及び水平方向を拡大/縮小します。Uniform を指定したときは、オリジナルの画像の縦横比を変更せずに、画像全体が表示されるように拡大/縮小します。UniformToFill を指定したときは、オリジナルの画像の縦横比を変更せずに、画像が最も大きく表示されるように拡大/縮小します。画像の一部がはみ出すことがあります。None を指定したときは、オリジナルの画像のまま表示します。画像の一部がはみ出すことがあります。
</dd></dl>
<p>Fill の場合</p>
<p><img src="22419-image002.jpg" alt="図 2" width="375" height="143"></p>
<p>Uniform の場合</p>
<p><img src="22420-image003.jpg" alt="図 3" width="373" height="144"></p>
<p>UniformToFill の場合</p>
<p><img src="22421-image004.jpg" alt="図 4" width="374" height="142"></p>
<p>None の場合</p>
<p><img src="22422-image005.jpg" alt="図 5" width="371" height="139"></p>
<dl><dt><strong>Visibility:</strong> </dt><dd>表示と非表示を切り替えることができます。Visible を指定すると表示し、Collapsed を指定すると表示しなくなります。 </dd></dl>
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
