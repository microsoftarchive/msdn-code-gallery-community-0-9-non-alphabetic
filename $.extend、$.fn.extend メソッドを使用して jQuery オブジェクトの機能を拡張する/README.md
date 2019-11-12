# $.extend、$.fn.extend メソッドを使用して jQuery オブジェクトの機能を拡張する
## License
- Apache License, Version 2.0
## Technologies
- Visual Studio 2010
- jQuery 1.4.4
## Topics
- 逆引きサンプル コード
- jQuery
## Updated
- 02/22/2011
## Description

<p>執筆者: <a href="http://msdn.microsoft.com/ja-jp/gg585574#yamada" target="_blank">
有限会社 WINGS プロジェクト 山田 祥寛</a></p>
<p>動作確認環境: Visual Studio 2010、jQuery 1.4.4</p>
<hr>
<p>$.extend メソッドを利用することで、jQuery に対して静的メソッドを追加できます。たとえば、以下は三角形の面積を求める triangle メソッドと、ひし形の面積を求める diamond メソッドを追加する例です。</p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>JavaScript</span></div>
<div class="pluginEditHolderLink">スクリプトの編集</div>
<span class="hidden">js</span>

<div class="preview">
<pre id="codePreview" class="js">&lt;script&nbsp;src=<span class="js__string">&quot;../Scripts/jquery-1.4.4.min.js&quot;</span>&nbsp;type=<span class="js__string">&quot;text/javascript&quot;</span>&gt;&lt;/script&gt;&nbsp;
&lt;script&nbsp;type=<span class="js__string">&quot;text/javascript&quot;</span>&gt;&nbsp;
&nbsp;&nbsp;<span class="js__sl_comment">//&nbsp;静的メソッド&nbsp;triangle、diamond&nbsp;を追加</span>&nbsp;
$.extend(<span class="js__brace">{</span>&nbsp;
&nbsp;&nbsp;triangle&nbsp;:&nbsp;<span class="js__operator">function</span>(base,&nbsp;height)&nbsp;<span class="js__brace">{</span>&nbsp;<span class="js__statement">return</span>&nbsp;base&nbsp;*&nbsp;height&nbsp;/&nbsp;<span class="js__num">2</span>;&nbsp;<span class="js__brace">}</span>,&nbsp;
&nbsp;&nbsp;diamond&nbsp;:&nbsp;<span class="js__operator">function</span>(height,&nbsp;width)&nbsp;<span class="js__brace">{</span>&nbsp;<span class="js__statement">return</span>&nbsp;height&nbsp;*&nbsp;width&nbsp;/&nbsp;<span class="js__num">2</span>&nbsp;<span class="js__brace">}</span>&nbsp;
<span class="js__brace">}</span>)&nbsp;
&nbsp;
&nbsp;&nbsp;<span class="js__sl_comment">//&nbsp;triangle、diamond&nbsp;メソッドを呼び出し＆結果をダイアログ表示</span>&nbsp;
window.alert(&nbsp;
&nbsp;&nbsp;<span class="js__string">'三角形の面積：'</span>&nbsp;&#43;&nbsp;$.triangle(<span class="js__num">5</span>,&nbsp;<span class="js__num">2</span>)&nbsp;&#43;&nbsp;<span class="js__string">'\n'</span>&nbsp;&#43;&nbsp;
&nbsp;&nbsp;<span class="js__string">'ひし形の面積：'</span>&nbsp;&#43;&nbsp;$.diamond(<span class="js__num">10</span>,&nbsp;<span class="js__num">5</span>)&nbsp;
);&nbsp;
&lt;/script&gt;&nbsp;
&nbsp;
</pre>
</div>
</div>
</div>
<p><img src="18632-arrow.gif" alt="" width="35" height="42"></p>
<p><img src="18634-image001.jpg" alt="図 1" width="209" height="186"></p>
<p>$.extend メソッドには、「メソッド名: 匿名関数」のハッシュとして追加したいメソッドをいくつでも指定できます。$.extend メソッドで定義された静的メソッドには、「$.メソッド名(...)」、または「jQuery.メソッド名(...)」でアクセスできます。</p>
<p>もうひとつ、よく&#20284;たメソッドとして、$.fn.extend メソッドがあります。こちらは jQuery に対してインスタンス メソッドを追加するためのメソッドです。たとえば以下は、現在の要素セットに対して一律、指定された色で枠線を付与する border メソッドを追加しています。</p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>HTML</span></div>
<div class="pluginEditHolderLink">スクリプトの編集</div>
<span class="hidden">html</span>

<div class="preview">
<pre id="codePreview" class="html"><span class="html__tag_start">&lt;ul</span><span class="html__tag_start">&gt;&nbsp;
</span>&nbsp;&nbsp;<span class="html__tag_start">&lt;li</span><span class="html__tag_start">&gt;</span>Windows&nbsp;Azure&nbsp;実践クラウド・プログラミング<span class="html__tag_end">&lt;/li&gt;</span>&nbsp;
&nbsp;&nbsp;<span class="html__tag_start">&lt;li</span>&nbsp;<span class="html__attr_name">class</span>=<span class="html__attr_value">&quot;new&quot;</span><span class="html__tag_start">&gt;</span>Microsoft&nbsp;ASP.NET&nbsp;4&nbsp;入門&nbsp;<span class="html__tag_end">&lt;/li&gt;</span>&nbsp;
&nbsp;&nbsp;<span class="html__tag_start">&lt;li</span><span class="html__tag_start">&gt;</span>ASP.NET&nbsp;NVC&nbsp;実践プログラミング<span class="html__tag_end">&lt;/li&gt;</span>&nbsp;
&nbsp;&nbsp;<span class="html__tag_start">&lt;li</span><span class="html__tag_start">&gt;</span>Microsoft&nbsp;Visual&nbsp;C&#43;&#43;&nbsp;2010&nbsp;入門&nbsp;<span class="html__tag_end">&lt;/li&gt;</span>&nbsp;
&nbsp;&nbsp;<span class="html__tag_start">&lt;li</span>&nbsp;<span class="html__attr_name">class</span>=<span class="html__attr_value">&quot;new&quot;</span><span class="html__tag_start">&gt;</span>Visual&nbsp;Studio&nbsp;2010スタートアップガイド<span class="html__tag_end">&lt;/li&gt;</span>&nbsp;
<span class="html__tag_end">&lt;/ul&gt;</span>&nbsp;
&nbsp;
<span class="html__tag_start">&lt;script</span>&nbsp;<span class="html__attr_name">src</span>=<span class="html__attr_value">&quot;../Scripts/jquery-1.4.4.min.js&quot;</span>&nbsp;<span class="html__attr_name">type</span>=<span class="html__attr_value">&quot;text/javascript&quot;</span><span class="html__tag_start">&gt;</span><span class="html__tag_end">&lt;/script&gt;</span>&nbsp;
<span class="html__tag_start">&lt;script</span>&nbsp;<span class="html__attr_name">type</span>=<span class="html__attr_value">&quot;text/javascript&quot;</span><span class="html__tag_start">&gt;</span>&nbsp;
&nbsp;<span class="js__sl_comment">//&nbsp;インスタンス&nbsp;メソッド&nbsp;border&nbsp;を追加</span>&nbsp;
$.fn.extend(<span class="js__brace">{</span>&nbsp;
&nbsp;&nbsp;border:&nbsp;<span class="js__operator">function</span>(color)&nbsp;<span class="js__brace">{</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__sl_comment">//&nbsp;現在の要素セットに対して、スタイルを適用</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__statement">return</span>&nbsp;$(<span class="js__operator">this</span>).css(<span class="js__string">'border'</span>,&nbsp;<span class="js__string">'solid&nbsp;5px&nbsp;'</span>&nbsp;&#43;&nbsp;color);&nbsp;
&nbsp;&nbsp;<span class="js__brace">}</span>&nbsp;
<span class="js__brace">}</span>)&nbsp;
&nbsp;<span class="js__sl_comment">//&nbsp;&lt;li&nbsp;class=&quot;new&quot;&gt;&nbsp;要素に青の枠線を付与</span>&nbsp;
$(<span class="js__string">'li.new'</span>).border(<span class="js__string">'Blue'</span>);&nbsp;
<span class="html__tag_end">&lt;/script&gt;</span>&nbsp;
&nbsp;
</pre>
</div>
</div>
</div>
<p><img src="18633-arrow.gif" alt="" width="35" height="42"></p>
<p><img src="18635-image002.jpg" alt="図 2" width="337" height="272"></p>
<p>「メソッド名: 匿名関数」のハッシュとして記述する点は、$.extend メソッドと共通です。ただし、インスタンス メソッドを定義する場合、(メソッド チェーンを切らないように) 戻り値はできるだけ jQuery オブジェクトとするのが望ましいでしょう。</p>
<p>$.extend メソッドで定義された静的メソッドには、「$(セレクター式).メソッド名(...)」でアクセスできます。</p>
<hr style="clear:both; margin-bottom:8px; margin-top:20px">
<table>
<tbody>
<tr>
<td><a href="http://msdn.microsoft.com/ja-jp/samplecode.recipe"><img src="-ff950935.coderecipe_180x70%28ja-jp,msdn.10%29.jpg" border="0" alt="Code Recipe" width="180" height="70" style="margin-top:3px"></a></td>
<td><a href="http://msdn.microsoft.com/ja-jp/asp.net/" target="_blank"><img src="-ff950935.asp_net_180x70%28ja-jp,msdn.10%29.jpg" border="0" alt="ASP.NET デベロッパーセンター" width="180" height="70" style="margin-top:3px"></a></td>
<td>
<ul>
<li>もっと他のコンテンツを見る &gt;&gt; <a href="http://msdn.microsoft.com/ja-jp/ff363212" target="_blank">
逆引きサンプル コード一覧へ</a> </li><li>もっと他のレシピを見る &gt;&gt; <a href="http://msdn.microsoft.com/ja-jp/samplecode.recipe">
Code Recipe へ</a> </li><li>もっと ASP.NET の情報を見る &gt;&gt; <a href="http://msdn.microsoft.com/ja-jp/asp.net" target="_blank">
ASP.NET デベロッパーセンターへ</a> </li></ul>
</td>
</tr>
</tbody>
</table>
<p style="margin-top:20px"><a href="#top"><img src="-top.gif" border="0" alt="">ページのトップへ</a></p>
