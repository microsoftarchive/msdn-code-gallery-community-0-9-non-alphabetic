# 10行でズバリ!! [HTML5 と IE9] HTML5 で Canvas を利用する
## License
- Apache License, Version 2.0
## Technologies
- Visual Studio 2010
- Javascript
- HTML5
- Expression Web 4
## Topics
- 10 行でズバリ!!
- Web アプリケーション
## Updated
- 06/22/2011
## Description

<h2 style="padding:10px"><img src="http://www.microsoft.com/japan/msdn/nodehomes/graphics/Learn_sm.png" alt=""> このコンテンツのポイント</h2>
<p><img src="23089-ie0601.jpg" alt="" width="280" height="176" align="right" style="margin:-1em 0 0 1em">Internet Explorer 9 で新たに導入された、新しい HTML5 機能の 1 つが、Canvas 要素です。これは、Canvas 2D API と一緒に使用します。Canvas 要素は、「HTML5 仕様」で定義されているように、解像度依存のビットマップ
 キャンバス上へのグラフィックのレンダリングを可能にします。キャンバスに描画するには、Canvas 2D コンテキストなどの &quot;コンテキスト&quot; を使用します。これは、W3C Canvas 2D API 仕様に指定されています。<br>
Internet Explorer 9 では、Canvas 要素のサポートが導入されます。2D Canvas 描画 API が、サポートされる唯一のコンテキストとなります。Internet Explorer 9 のすべてのグラフィックスと同様、Canvas は、Windows と GPU によるハードウェア アクセラレーションに対応しています。<br>
今回はこの Canvas の特長と、実装方法について、確認していきましょう。</p>
<p>IE9 の Canvas サポートの詳細については、<a href="http://msdn.microsoft.com/ja-jp/ie/ff468705#_HTML5_canvas" target="_blank">MSDN オンライン</a>を参照してください。</p>
<h2 style="padding:10px"><img src="http://www.microsoft.com/japan/msdn/nodehomes/graphics/Code_sm.png" alt=""> 今回紹介するコード</h2>
<h4>(1) Canvas の API を使って四角形を描画する</h4>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>JavaScript</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">スクリプトの編集</span>|<span class="pluginRemoveHolderLink">{#scriptcode_dlg.remove_script}</span></div>
<span class="hidden">js</span>

<div class="preview">
<pre class="js">&lt;!DOCTYPE&nbsp;html&gt;&nbsp;
&lt;html&gt;&nbsp;
&nbsp;
&lt;head&gt;&nbsp;
&lt;meta&nbsp;content=<span class="js__string">&quot;text/html;&nbsp;charset=utf-8&quot;</span>&nbsp;http-equiv=<span class="js__string">&quot;Content-Type&quot;</span>&gt;&nbsp;
&lt;title&gt;Canvas&nbsp;Sample1&lt;/title&gt;&nbsp;
&lt;script&nbsp;type=<span class="js__string">&quot;text/javascript&quot;</span>&gt;&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;onload&nbsp;=&nbsp;<span class="js__operator">function</span>&nbsp;()&nbsp;<span class="js__brace">{</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;draw();&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">}</span>;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__operator">function</span>&nbsp;draw()&nbsp;<span class="js__brace">{</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__ml_comment">/*&nbsp;canvas要素のDOMオブジェクト取得*/</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__statement">var</span>&nbsp;canvas&nbsp;=&nbsp;document.getElementById(<span class="js__string">&quot;canvas1&quot;</span>);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__ml_comment">/*&nbsp;canvas要素の存在チェックとCanvas未対応ブラウザの対処&nbsp;*/</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__statement">if</span>&nbsp;(!canvas&nbsp;||&nbsp;!canvas.getContext)&nbsp;<span class="js__brace">{</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__statement">return</span>&nbsp;false&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">}</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__ml_comment">/*&nbsp;2D描画コンテキストの取得&nbsp;*/</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__statement">var</span>&nbsp;ctx&nbsp;=&nbsp;canvas.getContext(<span class="js__string">&quot;2d&quot;</span>);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__ml_comment">/*&nbsp;四角を描く&nbsp;*/</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;ctx.beginPath();&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;ctx.moveTo(<span class="js__num">20</span>,&nbsp;<span class="js__num">20</span>);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;ctx.lineTo(<span class="js__num">120</span>,&nbsp;<span class="js__num">20</span>);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;ctx.lineTo(<span class="js__num">120</span>,&nbsp;<span class="js__num">120</span>);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;ctx.lineTo(<span class="js__num">20</span>,&nbsp;<span class="js__num">120</span>);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;ctx.closePath();&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;ctx.stroke();&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">}</span>&nbsp;
&nbsp;
&lt;/script&gt;&nbsp;
&nbsp;
&lt;/head&gt;&nbsp;
&lt;body&gt;&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&lt;h1&gt;Canvas&nbsp;サンプル&nbsp;<span class="js__num">2</span>&lt;/h1&gt;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&lt;canvas&nbsp;id=<span class="js__string">&quot;canvas1&quot;</span>&nbsp;width=<span class="js__string">&quot;300&quot;</span>&nbsp;height=<span class="js__string">&quot;400&quot;</span>&gt;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&lt;/canvas&gt;&nbsp;
&nbsp;
&lt;/body&gt;&nbsp;
&lt;/html&gt;</pre>
</div>
</div>
</div>
<div class="endscriptcode">&nbsp;</div>
<h4>(2) Canvas の API を使って画像をロードする</h4>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>JavaScript</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">スクリプトの編集</span>|<span class="pluginRemoveHolderLink">{#scriptcode_dlg.remove_script}</span></div>
<span class="hidden">js</span>

<div class="preview">
<pre class="js">&lt;!DOCTYPE&nbsp;html&gt;&nbsp;
&lt;html&gt;&nbsp;
&lt;head&gt;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&lt;title&gt;Canvas&nbsp;Demo&nbsp;<span class="js__num">2</span>&lt;/title&gt;&nbsp;
&lt;/head&gt;&nbsp;
&lt;body&gt;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&lt;h1&gt;Canvas&nbsp;サンプル<span class="js__num">2</span>&lt;/h1&gt;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&lt;canvas&nbsp;id=<span class="js__string">&quot;canvas1&quot;</span>&nbsp;width=<span class="js__string">&quot;760&quot;</span>&nbsp;height=<span class="js__string">&quot;480&quot;</span>&gt;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&lt;/canvas&gt;&nbsp;
&lt;/body&gt;&nbsp;
&lt;/html&gt;&nbsp;
&nbsp;
&lt;script&nbsp;type=<span class="js__string">&quot;text/javascript&quot;</span>&gt;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__sl_comment">//Canvas要素のDOMオブジェクトを取得</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__statement">var</span>&nbsp;canvas&nbsp;=&nbsp;document.getElementById(<span class="js__string">&quot;canvas1&quot;</span>);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__sl_comment">//描画コンテキストを取得</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__statement">var</span>&nbsp;ctx&nbsp;=&nbsp;canvas.getContext(<span class="js__string">&quot;2d&quot;</span>);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__sl_comment">//イメージ要素を生成</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__statement">var</span>&nbsp;image&nbsp;=&nbsp;<span class="js__operator">new</span>&nbsp;Image();&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__sl_comment">//画像の読み込みが終わり次第、Canvasに書き出す</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;image.onload&nbsp;=&nbsp;<span class="js__operator">function</span>&nbsp;()&nbsp;<span class="js__brace">{</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;ctx.drawImage(image,&nbsp;<span class="js__num">0</span>,&nbsp;<span class="js__num">0</span>,&nbsp;canvas.width,&nbsp;canvas.height);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">}</span>;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__sl_comment">//画像のロードを開始する</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;image.src&nbsp;=&nbsp;<span class="js__string">&quot;IE9_wallpaper_ryo01_1680_1050.jpg&quot;</span>;&nbsp;
&lt;/script&gt;</pre>
</div>
</div>
</div>
<div class="endscriptcode">&nbsp;</div>
<h2>目次</h2>
<ol>
<li><a href="#01">はじめに</a>
<ul>
<li><a href="#0101">Web アプリケーション プラットフォームとしての HTML5</a> </li><li><a href="#0102">Canvas の特長と実装方法</a> </li><li><a href="#0103">Canvas のサンプル コード</a> </li><li><a href="#0104">HTML5 オーサリングのためのツール</a> </li></ul>
</li><li><a href="#02">解説</a>
<ol type="1">
<li><a href="#0201">HTML ページの作成</a> </li><li><a href="#0202">HTML ページの編集</a> </li><li><a href="#0203">実行結果の確認</a> </li><li><a href="#0204">Canvas のシナリオと SVG との使い分け</a> </li><li><a href="#0205">おわりに</a> </li></ol>
</li></ol>
<hr>
<h2 id="01">1. はじめに</h2>
<p>HTML5 は、W3C が HTML4 に代わる 次世代の HTML として策定を進めている HTML 仕様です。現状普及している HTML4.01 の現状の問題点としては、次の 2 点があります。</p>
<ul>
<li>HTML タグで構造付けされた HTML 文書の作成と公開が目的である </li><li>したがって (プラグインなしで) Web アプリケーションを作成するには機能不足である </li></ul>
<p>そこで、HTML5 の特長としては、</p>
<ul>
<li>HTML 文書を作成する機能自体の改良を実施する </li><li>Web アプリケーションを開発するための様々な仕様を追加する </li></ul>
<p>ということになります。</p>
<p><img src="http://i2.code.msdn.s-msft.com/internetexplorer-10line-b49a0af1/image/file/22744/1/ie0102.gif" alt="文章構造" width="181" height="173" align="left" style="margin-right:1em">前者は、セマンティックス要素の追加のことで、文章構造をロジカルにし、可読性を高め、SEO 対策等にも利用可能なようにするということです。HTML5 が提供するこれらの新しい
 Semantics タグにより、DIV や SPAN その他の ID 属性を持った class 要素をリプレースすることができます。具体的には、Header, Footer, Article, Section, Nav, Aside, Hgroup, Figure, Figcaption, Address 等々があります。</p>
<p>なお、後者は、本稿以下で順次ご紹介する、HTML5 で初めて登場した新タグや新しく追加された API のことです。</p>
<p>以上 2 つの特長により、Flash や Silverlight 等のブラウザー プラグインで実現できる Web アプリケーションとして必要な機能のうちの一部を、標準の HTML5 及び JavaScript でシンプルに実現できる、ということになります。</p>
<div style="clear:both"></div>
<h3 id="0101">Web アプリケーション プラットフォームとしての HTML5</h3>
<p>この図では、広義の HTML5 という部分と、狭義の HTML5 という部分について、提示しています。広義の HTML5 の中には、Web Sockets や Web Storage 等々色々あります。このシリーズでは、主に W3C HTML5 と書いてある箇所をメインに、IE9 や IE10 PP1、そして HTML Labs にある実装を元に、構文要素、Video/Audio、Canvas、フォーム要素、リッチテキスト API、ドラッグ アンド ドロップ API 等々順次ご紹介して行きます。</p>
<p class="Recipe"><img src="http://i1.code.msdn.s-msft.com/internetexplorer-10line-b49a0af1/image/file/22745/1/ie0103.jpg" alt="一般的に HTML5 に含められる API 類" width="504" height="366" align="middle"></p>
<h3 id="0102">Canvas の特長と実装方法</h3>
<p>Canvas とは、Javascript で 2D の図形を描くことができるブロック要素のことです。Canvas 要素は、図などのフォーマットではなく、グラフィックスを描画する領域を示す指定した範囲内で、図形などの線画、画像などの 2D Graphics を自由に描画できます。すなわちグラフィックスの描画が可能な領域を示します。<br>
実装方法としては、下記の通りです。まずは Canvas を定義します。</p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>HTML</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">スクリプトの編集</span>|<span class="pluginRemoveHolderLink">{#scriptcode_dlg.remove_script}</span></div>
<span class="hidden">html</span>

<div class="preview">
<pre class="js">&lt;canvas&nbsp;id=&ldquo;mycanvas&rdquo;&nbsp;width=&ldquo;<span class="js__num">100</span>&rdquo;&nbsp;height=&ldquo;<span class="js__num">200</span>&rdquo;&gt;&nbsp;&lt;/canvas&gt;&nbsp;</pre>
</div>
</div>
</div>
<div class="endscriptcode">&nbsp;</div>
<p>次に、JavaScript を用いてキャンバスに描画するため、2d 描画コンテキストを取得します。</p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>JavaScript</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">スクリプトの編集</span>|<span class="pluginRemoveHolderLink">{#scriptcode_dlg.remove_script}</span></div>
<span class="hidden">js</span>

<div class="preview">
<pre class="js"><span class="js__statement">var</span>&nbsp;canvas&nbsp;=&nbsp;document.getElementById(&ldquo;mycanvas&rdquo;);&nbsp;
<span class="js__statement">var</span>&nbsp;context&nbsp;=&nbsp;canvas.getContext(&ldquo;2d&rdquo;);</pre>
</div>
</div>
</div>
<div class="endscriptcode">&nbsp;</div>
<p>Canvas は、Web 上にグラフィックをプログラムするための方法です。Canvas タグは &quot;即時モード&quot; (描画コマンドがグラフィック ハードウェアに直接送信される) の 2 次元描画用サーフェイスです。別のプラグインをダウンロードする必要なしにリアルタイムのグラフ、アニメーション、インタラクティブなゲームを提供できます。CanvasRenderingContext2D オブジェクトで定義されている API により、Canvas では以下に挙げる描画シナリオが可能となります:</p>
<ul>
<li>長方形 </li><li>直線 </li><li>フィル </li><li>円弧 </li><li>シャドウ </li><li>ベジエ曲線 </li><li>2 次曲線 </li><li>画像 </li><li>映像 </li></ul>
<p>Canvas のサンプルは Web 上に数えきれないほど存在していますが、IE9 で可能な Canvas の実装に関しては、<a href="http://ie.microsoft.com/testdrive/Default.html" target="_blank">TestDrive (英語)</a> (特に上記のシナリオ全て網羅しているものとして
<a href="http://ie.microsoft.com/testdrive/Graphics/CanvasPad/Default.html" target="_blank">
CanvasPad (英語)</a>) や <a href="http://www.beautyoftheweb.jp/" target="_blank">Beauty of the Web</a> には、多くのサンプルがあります。ぜひご覧ください。</p>
<h3 id="0103">Canvas のサンプル コード</h3>
<p>Canvas の API を使って赤い四角形を描画するものです。</p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>JavaScript</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">スクリプトの編集</span>|<span class="pluginRemoveHolderLink">{#scriptcode_dlg.remove_script}</span></div>
<span class="hidden">js</span>

<div class="preview">
<pre class="js">&lt;canvas&nbsp;id=<span class="js__string">&quot;myCanvas&quot;</span>&nbsp;width=&ldquo;<span class="js__num">600</span><span class="js__string">&quot;&nbsp;height=&ldquo;600&quot;</span>&gt;&nbsp;
&nbsp;&nbsp;Your&nbsp;browser&nbsp;doesn&rsquo;t&nbsp;support&nbsp;Canvas,&nbsp;sorry.&nbsp;
&lt;/canvas&gt;&nbsp;
&nbsp;
&lt;script&nbsp;type=<span class="js__string">&quot;text/javascript&quot;</span>&gt;&nbsp;
&nbsp;&nbsp;<span class="js__statement">var</span>&nbsp;example&nbsp;=&nbsp;document.getElementById(<span class="js__string">&quot;myCanvas&quot;</span>);&nbsp;&nbsp;
&nbsp;&nbsp;<span class="js__statement">var</span>&nbsp;context&nbsp;=&nbsp;example.getContext(<span class="js__string">&quot;2d&quot;</span>);&nbsp;&nbsp;
&nbsp;&nbsp;context.fillStyle&nbsp;=&nbsp;<span class="js__string">&quot;rgb(255,0,0)&quot;</span>;&nbsp;&nbsp;
&nbsp;&nbsp;context.fillRect(<span class="js__num">300</span>,&nbsp;<span class="js__num">300</span>,&nbsp;<span class="js__num">500</span>,&nbsp;<span class="js__num">500</span>);&nbsp;&nbsp;
&lt;/script&gt;</pre>
</div>
</div>
</div>
<div class="endscriptcode">&nbsp;</div>
<p>これを実行するとこのようなイメージになります。</p>
<p><img src="23090-ie0602.jpg" alt="サンプル コード実行イメージ" width="480" height="251"></p>
<h3 id="0104">HTML5 オーサリングのためのツール</h3>
<p>マイクロソフトでは、HTML5 対応のツールとして、下記 2 製品があります。</p>
<ul>
<li style="margin-bottom:1.5em"><img src="http://i4.code.msdn.s-msft.com/internetexplorer-10line-b49a0af1/image/file/22746/1/ie0104.gif" alt="Microsoft Visual Studio 2010 Service Pack 1" width="360" height="44"><br>
Visual Studio 2010 Service Pack 1 には、HTML5 インテリセンスと検&#35388; (バリデーション) が含まれています。また、豊富な CSS3 対応のための改良がされています。
</li><li style="margin-bottom:1.5em"><img src="http://i2.code.msdn.s-msft.com/internetexplorer-10line-b49a0af1/image/file/22747/1/ie0105.gif" alt="Microsoft Expression Web 4 Service Pack 1" width="360" height="44"><br>
Expression Web 4 Service Pack 1 には、HTML5 コード エディター サポートと、HTML5 のデザイン ビューのサポートがあります。CSS3 の新仕様からの多くの新プロパティが含まれています。
</li></ul>
<p style="margin-top:20px"><a href="#top"><img src="9536-image.png" border="0" alt=""> ページのトップへ</a></p>
<hr>
<h2 id="02">2. 解説</h2>
<h3 id="0201">2.1. HTML ページの作成</h3>
<p>ここでは Expression Web から Web アプリケーションを利用する方法をご紹介します。Expression Web 4 SP1 を起動し、[ファイル] &rarr; [新規作成] &rarr; [HTML ページ] を作成します。</p>
<div style="margin:10px 0; padding:0 10px; background-color:#efefef; border:solid 1px #333">
<p><strong>Note:</strong><br>
Expression Web 4 SP1 では、[ツール] &rarr; [ページ編集オプション] &rarr; [作成] タブで下記の通り設定しておけば、新規作成スキーマは全て HTML5 と CSS3 となります。</p>
</div>
<p><img src="23086-ie0503.jpg" alt="ダイアログ: [ツール] → [ページ編集オプション] / 新規作成" width="600" height="257"></p>
<p style="margin-top:20px"><a href="#top"><img src="9536-image.png" border="0" alt=""> ページのトップへ</a></p>
<hr>
<h3 id="0202">2.2. HTML ページの編集</h3>
<h4>(1) Canvas の API を使って四角形を描画する</h4>
<p>HTMLPage が開かれた状態で、下記のように入力します。</p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>JavaScript</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">スクリプトの編集</span>|<span class="pluginRemoveHolderLink">{#scriptcode_dlg.remove_script}</span></div>
<span class="hidden">js</span>

<div class="preview">
<pre class="js">&lt;!DOCTYPE&nbsp;html&gt;&nbsp;
&lt;html&gt;&nbsp;
&nbsp;
&lt;head&gt;&nbsp;
&lt;meta&nbsp;content=<span class="js__string">&quot;text/html;&nbsp;charset=utf-8&quot;</span>&nbsp;http-equiv=<span class="js__string">&quot;Content-Type&quot;</span>&gt;&nbsp;
&lt;title&gt;Canvas&nbsp;Sample1&lt;/title&gt;&nbsp;
&lt;script&nbsp;type=<span class="js__string">&quot;text/javascript&quot;</span>&gt;&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;onload&nbsp;=&nbsp;<span class="js__operator">function</span>&nbsp;()&nbsp;<span class="js__brace">{</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;draw();&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">}</span>;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__operator">function</span>&nbsp;draw()&nbsp;<span class="js__brace">{</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__ml_comment">/*&nbsp;canvas要素のDOMオブジェクト取得*/</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__statement">var</span>&nbsp;canvas&nbsp;=&nbsp;document.getElementById(<span class="js__string">&quot;canvas1&quot;</span>);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__ml_comment">/*&nbsp;canvas要素の存在チェックとCanvas未対応ブラウザの対処&nbsp;*/</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__statement">if</span>&nbsp;(!canvas&nbsp;||&nbsp;!canvas.getContext)&nbsp;<span class="js__brace">{</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__statement">return</span>&nbsp;false&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">}</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__ml_comment">/*&nbsp;2D描画コンテキストの取得&nbsp;*/</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__statement">var</span>&nbsp;ctx&nbsp;=&nbsp;canvas.getContext(<span class="js__string">&quot;2d&quot;</span>);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__ml_comment">/*&nbsp;四角を描く&nbsp;*/</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;ctx.beginPath();&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;ctx.moveTo(<span class="js__num">20</span>,&nbsp;<span class="js__num">20</span>);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;ctx.lineTo(<span class="js__num">120</span>,&nbsp;<span class="js__num">20</span>);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;ctx.lineTo(<span class="js__num">120</span>,&nbsp;<span class="js__num">120</span>);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;ctx.lineTo(<span class="js__num">20</span>,&nbsp;<span class="js__num">120</span>);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;ctx.closePath();&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;ctx.stroke();&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">}</span>&nbsp;
&nbsp;
&lt;/script&gt;&nbsp;
&nbsp;
&lt;/head&gt;&nbsp;
&lt;body&gt;&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&lt;h1&gt;Canvas&nbsp;サンプル&nbsp;<span class="js__num">1</span>&lt;/h1&gt;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&lt;canvas&nbsp;id=<span class="js__string">&quot;canvas1&quot;</span>&nbsp;width=<span class="js__string">&quot;300&quot;</span>&nbsp;height=<span class="js__string">&quot;400&quot;</span>&gt;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&lt;/canvas&gt;&nbsp;
&nbsp;
&lt;/body&gt;&nbsp;
&lt;/html&gt;</pre>
</div>
</div>
</div>
<div class="endscriptcode">&nbsp;</div>
<h4>(2) Canvas の API を使って画像をロードする</h4>
<p><strong>1.</strong> のステップに従い新たに HTMLPage を作成し、当該 HTMLPage が開かれた状態で、下記のように入力します。</p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>JavaScript</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">スクリプトの編集</span>|<span class="pluginRemoveHolderLink">{#scriptcode_dlg.remove_script}</span></div>
<span class="hidden">js</span>

<div class="preview">
<pre class="js">&lt;!DOCTYPE&nbsp;html&gt;&nbsp;
&lt;html&gt;&nbsp;
&lt;head&gt;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&lt;title&gt;Canvas&nbsp;Demo&nbsp;<span class="js__num">2</span>&lt;/title&gt;&nbsp;
&lt;/head&gt;&nbsp;
&lt;body&gt;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&lt;h1&gt;Canvas&nbsp;サンプル<span class="js__num">2</span>&lt;/h1&gt;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&lt;canvas&nbsp;id=<span class="js__string">&quot;canvas1&quot;</span>&nbsp;width=<span class="js__string">&quot;760&quot;</span>&nbsp;height=<span class="js__string">&quot;480&quot;</span>&gt;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&lt;/canvas&gt;&nbsp;
&lt;/body&gt;&nbsp;
&lt;/html&gt;&nbsp;
&nbsp;
&lt;script&nbsp;type=<span class="js__string">&quot;text/javascript&quot;</span>&gt;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__sl_comment">//Canvas要素のDOMオブジェクトを取得</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__statement">var</span>&nbsp;canvas&nbsp;=&nbsp;document.getElementById(<span class="js__string">&quot;canvas1&quot;</span>);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__sl_comment">//描画コンテキストを取得</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__statement">var</span>&nbsp;ctx&nbsp;=&nbsp;canvas.getContext(<span class="js__string">&quot;2d&quot;</span>);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__sl_comment">//イメージ要素を生成</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__statement">var</span>&nbsp;image&nbsp;=&nbsp;<span class="js__operator">new</span>&nbsp;Image();&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__sl_comment">//画像の読み込みが終わり次第、Canvasに書き出す</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;image.onload&nbsp;=&nbsp;<span class="js__operator">function</span>&nbsp;()&nbsp;<span class="js__brace">{</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;ctx.drawImage(image,&nbsp;<span class="js__num">0</span>,&nbsp;<span class="js__num">0</span>,&nbsp;canvas.width,&nbsp;canvas.height);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">}</span>;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__sl_comment">//画像のロードを開始する</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;image.src&nbsp;=&nbsp;<span class="js__string">&quot;IE9_wallpaper_ryo01_1680_1050.jpg&quot;</span>;&nbsp;
&lt;/script&gt;</pre>
</div>
</div>
</div>
<div class="endscriptcode">&nbsp;</div>
<p>これを実行するとこのようなイメージになります。</p>
<h3 id="0203">2.3. 実行結果の確認</h3>
<p>[ファイル] &rarr; [ブラウザーでプレビュー] で、デバッグ実行します。</p>
<p>(1) の実行結果</p>
<p><img src="23091-ie0603.jpg" alt="(1) の実行結果" width="480" height="309"></p>
<p>(2) の実行結果</p>
<p><img src="23092-ie0604.jpg" alt="(2) の実行結果" width="480" height="309"></p>
<p>このように、Canvas を利用することで、高画質なグラフィックスを Web アプリケーションの中で利用することができます。</p>
<h3 id="0204">2.4. Canvas のシナリオと SVG との使い分け</h3>
<h4>(1) Canvas の使われるシナリオ</h4>
<p>下記があげられるでしょう。</p>
<ul>
<li style="margin-bottom:.75em"><strong>Pixel 操作</strong><br>
RayTracing、イメージ効果 </li><li style="margin-bottom:.75em"><strong>リアルタイムデータ提供</strong><br>
複雑なシーン、リアルタイムの数学的アニメーション </li><li style="margin-bottom:.75em"><strong>Pixel 置換</strong><br>
スターウォーズに出てくるような green/blue スクリーン効果も可能 </li><li style="margin-bottom:.75em"><strong>ゲーム</strong> </li></ul>
<h4>(2) SVG と Canvas との簡単な選択方法</h4>
<p>使い分けに関しては、シナリオ次第ではありますが、一般的には下記の通りですので、ご参考までにご覧ください。</p>
<p><img src="23087-ie0504.jpg" alt="SVG と Canvas との簡単な選択方法" width="580" height="272"></p>
<h4>組み合わせシナリオとパフォーマンスの違い</h4>
<ul>
<li style="margin-bottom:.75em"><strong>チャートとグラフ</strong><br>
SVG の方が、ユーザーとのインタラクションや、XML データのロード、そして印刷に向いています。<br>
Canvas は一般的に SVG よりもレンダリング速度が速くなります。 </li><li style="margin-bottom:.75em"><strong>二次元のゲーム</strong><br>
Canvas を使えば、ゲーム開発者は、より多くの API を利用することができます。(ネイティブ API、XNA、etc.)<br>
SVG は、DOM の利用により多くの操作が必要で、より多くのメモリーを消費します。 </li></ul>
<p>それぞれの特性を生かすには、下記の図のようなパフォーマンスの違いも、重要になります。</p>
<p><img src="23088-ie0505.jpg" alt="SVG と Canvas のパフォーマンス" width="580" height="218"></p>
<h3 id="0205">2.5. おわりに</h3>
<p>HTML5 の Canvas サポートについて解説しました。Canvas の利用方法がご理解いただけたかと思います。<br>
さらに詳しいデモやソースについては、<a href="http://ie.microsoft.com/testdrive/Default.html" target="_blank">IE Test Drive (英語)</a> および
<a href="http://msdn.microsoft.com/ja-jp/ie/ff468705" target="_blank">IE9 デベロッパー センター</a>をご覧ください。</p>
<hr style="clear:both; margin-bottom:8px; margin-top:20px">
<table>
<tbody>
<tr>
<td><a href="http://code.msdn.microsoft.com/ja-jp"><img src="http://i.msdn.microsoft.com/ff950935.coderecipe_180x70%28ja-jp,MSDN.10%29.jpg" border="0" alt="Code Recipe" width="180" height="70" style="margin-top:3px"></a></td>
<td><a href="http://msdn.microsoft.com/ja-jp/ie" target="_blank"><img src="http://i.msdn.microsoft.com/ff950935.ie_180x70(ja-jp,MSDN.10).jpg" border="0" alt="Internet Explorer デベロッパー センター" width="180" height="70" style="margin-top:3px"></a></td>
<td>
<ul>
<li>もっと他のコンテンツを見る &gt;&gt; <a href="http://msdn.microsoft.com/ja-jp/ie/hh226882" target="_blank">
サンプル コード集</a> </li><li>もっと他のレシピを見る &gt;&gt; <a href="http://code.msdn.microsoft.com/ja-jp">Code Recipe へ</a>
</li><li>もっと Internet Explorer の情報を見る &gt;&gt;&nbsp;<a href="http://msdn.microsoft.com/ja-jp/ie" target="_blank">Internet Explorer デベロッパー センターへ</a>
</li></ul>
</td>
</tr>
</tbody>
</table>
<p style="margin-top:20px"><a href="#top"><img src="http://www.microsoft.com/japan/msdn/nodehomes/graphics/top.gif" border="0" alt="">ページのトップへ</a></p>
