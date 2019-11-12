# フォントをコードから設定するときの注意点
## Requires
- Visual Studio 2012
## License
- MS-LPL
## Technologies
- Windows 8
- Windows RT
- Windows Store app
## Topics
- TextBox
- FontFamily
- メイリオ
- シンボル
- フォント名
## Updated
- 06/18/2013
## Description

<h1>Introduction</h1>
<p>コードから FontFamily を設定するときは、 英語のフォント名を使いましょう。<br>
ユーザーに提示するフォント名と、 FontFamily の生成に使うフォント名は、 面倒ですが別々に管理しましょう。</p>
<p><img id="84950" src="84950-20130616_fontfamilytest01.png" alt="" width="455" height="256"></p>
<p>&nbsp;</p>
<h1>Building the Sample</h1>
<p>Visual Studio 2012 Express for Windows 8 でビルドできます。</p>
<p>&nbsp;</p>
<h1>Description</h1>
<h2>何が問題なのか?</h2>
<p>日本語フォントとWingdingsのようなシンボル系フォントを切り替えて使うときに問題になります。<br>
TextBox では問題が出ます。 TextBlock は問題ありません。 その他のコントロールは調査していません。</p>
<p>現象としては、 TextBox のフォント指定を、 日本語で始まるフォント名(例:「メイリオ」)にした後で、 シンボル系フォントを指定しても正しく表示されません。<br>
対処としては、 英語のフォント名(例:「Meiryo」)で指定することです。</p>
<p>&nbsp;</p>
<h2>日本語フォント名 &rarr; シンボル系フォント</h2>
<p>日本語フォント名、 正確にはフォント名の先頭が日本語の場合です(先頭が半角英数字なら、後に日本語があってもOK)。<br>
一度おかしくなると、 別のフォントを指定してもダメです。 例えば、<br>
<strong>メイリオ &rarr; Wide Latin &rarr; Wingdings</strong><br>
とコードからフォントを変えてみましょう。</p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>C#</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">スクリプトの編集</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">csharp</span>

<div class="preview">
<pre class="csharp">textbox1.FontFamily&nbsp;=&nbsp;<span class="cs__keyword">new</span>&nbsp;FontFamily(<span class="cs__string">&quot;メイリオ&quot;</span>);&nbsp;
await&nbsp;Task.Yield();&nbsp;
textbox1.FontFamily&nbsp;=&nbsp;<span class="cs__keyword">new</span>&nbsp;FontFamily(<span class="cs__string">&quot;Wide&nbsp;Latin&quot;</span>);&nbsp;<span class="cs__com">//&nbsp;英字フォントの指定はOK</span>&nbsp;
await&nbsp;Task.Yield();&nbsp;
textbox1.FontFamily&nbsp;=&nbsp;<span class="cs__keyword">new</span>&nbsp;FontFamily(<span class="cs__string">&quot;Wingdings&quot;</span>);&nbsp;<span class="cs__com">//&nbsp;シンボル系フォントの指定はNG&nbsp;(追加入力分には反映される)</span>&nbsp;
await&nbsp;Task.Yield();&nbsp;
&nbsp;
<span class="cs__com">//textbox1.Text&nbsp;&#43;=&nbsp;&quot;&nbsp;&quot;;&nbsp;//コードから文字列を変更してやると、正しいフォントで表示される!</span>&nbsp;
</pre>
</div>
</div>
</div>
<div class="endscriptcode">&nbsp;</div>
<p>実行してみると、TextBox (上段) では、一見まったく Wingdings の指定が無視されたように見えます。<br>
なお、 下段は TextBlock で、 これは想定通りに英数字が Wingdings で表示されています。&nbsp;<br>
<img id="84951" src="84951-20130616_fontfamilytest02a.png" alt="" width="480" height="128"></p>
<p>ところが、文字列の後ろに半角英数字を入力してみると、Wingdings で表示されます。 ところがところが、 Wide Latin で表示されている部分(例えば「ABC」の部分)をコピーして文字列の後ろに張り付けてみると、&nbsp;Wide Latin で表示されてしまいます。 なかなか不思議な挙動をしてくれます。</p>
<p>&nbsp;</p>
<h2>英語フォント名 &rarr; シンボル系フォント</h2>
<p>「メイリオ」には英語名「Meiryo」もあるので、そっちで試してみましょう。<br>
<strong>Meiryo &rarr; Wide Latin &rarr; Wingdings</strong><br>
とコードからフォントを変えてみます。</p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>C#</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">スクリプトの編集</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">csharp</span>

<div class="preview">
<pre class="csharp"><span class="cs__com">//&nbsp;英語の名称(例:Meiryo)を使えば大丈夫</span>&nbsp;
textbox2.FontFamily&nbsp;=&nbsp;<span class="cs__keyword">new</span>&nbsp;FontFamily(<span class="cs__string">&quot;Meiryo&quot;</span>);&nbsp;
await&nbsp;Task.Yield();&nbsp;
textbox2.FontFamily&nbsp;=&nbsp;<span class="cs__keyword">new</span>&nbsp;FontFamily(<span class="cs__string">&quot;Wide&nbsp;Latin&quot;</span>);&nbsp;&nbsp;
await&nbsp;Task.Yield();&nbsp;
textbox2.FontFamily&nbsp;=&nbsp;<span class="cs__keyword">new</span>&nbsp;FontFamily(<span class="cs__string">&quot;Wingdings&quot;</span>);&nbsp;&nbsp;
await&nbsp;Task.Yield();&nbsp;
</pre>
</div>
</div>
</div>
<div class="endscriptcode">&nbsp;</div>
<p>実行してみると、こんどはちゃんと想定通りに英数字が Wingdings で表示されます。<br>
<img id="84952" src="84952-20130616_fontfamilytest02b.png" alt="" width="480" height="128"></p>
<p>&nbsp;</p>
<h2>まとめ</h2>
<p>コードから FontFamily を設定するときは、英語のフォント名を使うのが無難です。 シンボル系フォントを指定する場合には、上記のような不具合が発生します。</p>
<p>フォントを決め打ちで設定している場合や、 コードから設定するにしてもハードコードしている場合は問題になりませんが、 ユーザーにフォントを設定させるようなときには問題になります。 かといって、ユーザーに提示するフォント名として例えば「HGSSoeiKakupoptai」などとしてはダメで、ユーザーに対しては「HGS創英角ポップ体」と日本語名を提示すべきでしょう。すなわち、ユーザーにフォント名の選択肢を提示するアプリでは、フォント名として日本語名と英語名の両方を管理する必要があります。</p>
<p>なお、Windows 8 に標準で搭載されているフォントの一覧(英語名)は、こちらにあります。 &rArr; <a href="http://www.microsoft.com/typography/fonts/product.aspx?PID=164" target="_blank">
Fonts supplied with Windows 8</a></p>
<p>&nbsp;</p>
<h2>余談</h2>
<p>ユーザーにフォント名の選択肢を提示するアプリでは、次のようなクラスを用意しておいて、起動時にでもそのコレクションを作っておくとよいでしょう。</p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>C#</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">スクリプトの編集</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">csharp</span>

<div class="preview">
<pre class="csharp"><span class="cs__keyword">public</span>&nbsp;<span class="cs__keyword">class</span>&nbsp;FontName&nbsp;
{&nbsp;
&nbsp;&nbsp;<span class="cs__keyword">public</span>&nbsp;<span class="cs__keyword">string</span>&nbsp;Japanese&nbsp;{&nbsp;<span class="cs__keyword">get</span>;&nbsp;<span class="cs__keyword">internal</span>&nbsp;<span class="cs__keyword">set</span>;&nbsp;}&nbsp;
&nbsp;
&nbsp;&nbsp;<span class="cs__keyword">private</span>&nbsp;<span class="cs__keyword">string</span>&nbsp;_english;&nbsp;
&nbsp;&nbsp;<span class="cs__keyword">public</span>&nbsp;<span class="cs__keyword">string</span>&nbsp;English&nbsp;&nbsp;
&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">get</span>&nbsp;{&nbsp;<span class="cs__keyword">return</span>&nbsp;_english;&nbsp;}&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">internal</span>&nbsp;<span class="cs__keyword">set</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">if</span>&nbsp;(<span class="cs__keyword">string</span>.Equals(_english,&nbsp;<span class="cs__keyword">value</span>))&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">return</span>;&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;_english&nbsp;=&nbsp;<span class="cs__keyword">value</span>;&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">if</span>&nbsp;(<span class="cs__keyword">string</span>.IsNullOrWhiteSpace(_english))&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;_fontFamily&nbsp;=&nbsp;<span class="cs__keyword">null</span>;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">else</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;_fontFamily&nbsp;=&nbsp;<span class="cs__keyword">new</span>&nbsp;FontFamily(_english);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
&nbsp;&nbsp;}&nbsp;
&nbsp;
&nbsp;&nbsp;<span class="cs__keyword">private</span>&nbsp;FontFamily&nbsp;_fontFamily;&nbsp;
&nbsp;&nbsp;<span class="cs__keyword">public</span>&nbsp;FontFamily&nbsp;FontFamily&nbsp;&nbsp;
&nbsp;&nbsp;{&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">get</span>&nbsp;{&nbsp;<span class="cs__keyword">return</span>&nbsp;_fontFamily;&nbsp;&nbsp;}&nbsp;&nbsp;
&nbsp;&nbsp;}&nbsp;
}</pre>
</div>
</div>
</div>
<div class="endscriptcode">&nbsp;</div>
<p>なお、完全に余談ですが、冒頭に載せた画像ではタイトルの「ミリ」が「㍉」に合字されています。 TextBlock の標準的なスタイルと、メイリオやIPA明朝など幾つかのフォントの組み合わせでこのような合字が発生してしまうので、注意してください。
<br>
合字問題については以前ブログに書いたので、興味のある方はこちらを。 &rArr; 「<a href="http://bluewatersoft.cocolog-nifty.com/blog/2013/02/winrtmetro-aab0.html" target="_blank">[WinRT/Metro] 勝手に「ファミリー」が「ファ㍉ー」に変えられちゃうよぉ! (@@;</a>」</p>
<p>&nbsp;</p>
<h1>Source Code Files</h1>
<ul>
<li><em>MainPage.xaml/.xaml.cs&nbsp;- この画面とコード ビハインドだけです。</em> </li></ul>
<h1>More Information</h1>
<p>( 特に無し )</p>
<p>&nbsp;</p>
