# [VB] LINQ to XML による、XML ドキュメント読み込み時の、3 つの方法の使い分け
## License
- Apache License, Version 2.0
## Technologies
- Visual Studio 2010
- XML DOM
- Windows 7
## Topics
- データ アクセス開発
- 逆引きサンプル コード
## Updated
- 03/10/2011
## Description

<p>執筆者: <a href="http://msdn.microsoft.com/ja-jp/gg585574#syakushiji" target="_blank">
セイザインデザイン、PROJECT KySS　薬師寺 聖</a></p>
<p>動作確認環境: Visual Studio 2010、Windows 7 Professional 32 bit</p>
<hr style="clear:both; margin-bottom:8px; margin-top:20px">
<p>LINQ to XML を用いて、XML ドキュメントを読み込むには、いろいろな方法があります。</p>
<p>基本的なものは、<a href="http://msdn.microsoft.com/ja-jp/library/system.xml.linq.xdocument" target="_blank">XDocument クラス</a>を用いる方法と、<a href="http://msdn.microsoft.com/ja-jp/library/system.xml.linq.xelement" target="_blank">XElement クラス</a>を用いる方法の 2 つです。どちらの場合も、Load
 メソッドを用います。引数には、読み込むファイルを参照する URI 文字列を指定します。</p>
<p>この 2 つのクラスの動作は、異なります。コンソール・アプリケーションを作成して、リスト 1 のような XML ドキュメント (LinqSample.xml) を読み込んで結果を確認してみましょう。ソリューション名は &quot;XmlLoad&quot; とし、data フォルダーを作成して、サンプル XML ドキュメントを置いています。</p>
<p>このサンプルでは、読み込んだ XML ドキュメントの子要素のコレクションを、<a href="http://msdn.microsoft.com/ja-jp/library/bb342765" target="_blank">Elements メソッド</a>によって、ドキュメント順に返しています。</p>
<p><strong>リスト 1 サンプル XML ドキュメント (LinqSample.xml)</strong></p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>XML</span></div>
<div class="pluginEditHolderLink">スクリプトの編集</div>
<span class="hidden">xml</span>

<div class="preview">
<pre id="codePreview" class="xml"><span class="xml__tag_start">&lt;?xml</span>&nbsp;<span class="xml__attr_name">version</span>=<span class="xml__attr_value">&quot;1.0&quot;</span>&nbsp;<span class="xml__attr_name">encoding</span>=<span class="xml__attr_value">&quot;UTF-8&quot;</span><span class="xml__tag_start">?&gt;</span>&nbsp;
<span class="xml__tag_start">&lt;CodeRecipe</span><span class="xml__tag_start">&gt;&nbsp;
</span>&nbsp;&nbsp;&nbsp;&nbsp;<span class="xml__tag_start">&lt;Category</span><span class="xml__tag_start">&gt;&nbsp;
</span>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;大分類1&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="xml__tag_start">&lt;SubCategory</span><span class="xml__tag_start">&gt;小</span>分類A<span class="xml__tag_end">&lt;/SubCategory&gt;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="xml__tag_end">&lt;/Category&gt;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="xml__tag_start">&lt;Category</span><span class="xml__tag_start">&gt;&nbsp;
</span>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;大分類2&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="xml__tag_start">&lt;SubCategory</span><span class="xml__tag_start">&gt;小</span>分類B<span class="xml__tag_end">&lt;/SubCategory&gt;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="xml__tag_start">&lt;SubCategory</span><span class="xml__tag_start">&gt;小</span>分類C<span class="xml__tag_end">&lt;/SubCategory&gt;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="xml__tag_end">&lt;/Category&gt;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="xml__tag_start">&lt;Category</span><span class="xml__tag_start">&gt;&nbsp;
</span>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;大分類3&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="xml__tag_start">&lt;SubCategory</span><span class="xml__tag_start">&gt;小</span>分類D<span class="xml__tag_end">&lt;/SubCategory&gt;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="xml__tag_start">&lt;SubCategory</span><span class="xml__tag_start">&gt;小</span>分類E<span class="xml__tag_end">&lt;/SubCategory&gt;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="xml__tag_start">&lt;SubCategory</span><span class="xml__tag_start">&gt;小</span>分類F<span class="xml__tag_end">&lt;/SubCategory&gt;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="xml__tag_end">&lt;/Category&gt;</span>&nbsp;
<span class="xml__tag_end">&lt;/CodeRecipe&gt;</span>&nbsp;
&nbsp;
</pre>
</div>
</div>
</div>
<p><strong>リスト 2 リスト 1 のサンプル XML ドキュメントを、XDocument クラスおよび XElement クラスを用いて読み込む</strong></p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>Visual Basic</span></div>
<div class="pluginEditHolderLink">スクリプトの編集</div>
<span class="hidden">vb</span>

<div class="preview">
<pre id="codePreview" class="vb"><span class="visualBasic__keyword">Option</span>&nbsp;Strict&nbsp;<span class="visualBasic__keyword">On</span>&nbsp;
<span class="visualBasic__keyword">Imports</span>&nbsp;System.Xml.Linq&nbsp;
<span class="visualBasic__keyword">Imports</span>&nbsp;System.IO&nbsp;<span class="visualBasic__com">'後述のStreamReaderのサンプルで使用</span>&nbsp;
&nbsp;
<span class="visualBasic__keyword">Module</span>&nbsp;Module1&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">Sub</span>&nbsp;Main()&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__com">'■XDocument.LoadでXMLとして読み込み、XMLとして処理する。</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">Dim</span>&nbsp;myXmlDoc&nbsp;<span class="visualBasic__keyword">As</span>&nbsp;XDocument&nbsp;=&nbsp;XDocument.Load(<span class="visualBasic__string">&quot;data\LinqSample.xml&quot;</span>)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">Dim</span>&nbsp;myQuery&nbsp;=&nbsp;From&nbsp;c&nbsp;<span class="visualBasic__keyword">In</span>&nbsp;myXmlDoc.Elements&nbsp;<span class="visualBasic__keyword">Select</span>&nbsp;c&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">For</span>&nbsp;<span class="visualBasic__keyword">Each</span>&nbsp;myResult&nbsp;<span class="visualBasic__keyword">In</span>&nbsp;myQuery&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Console.WriteLine(myResult.ToString)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">Next</span>&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__com">''■XElement.LoadでXMLとして読み込み、XMLとして処理する。</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__com">'Dim&nbsp;myXmlDoc&nbsp;As&nbsp;XElement&nbsp;=&nbsp;XElement.Load(&quot;data\LinqSample.xml&quot;)</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__com">'Dim&nbsp;myQuery&nbsp;=&nbsp;From&nbsp;c&nbsp;In&nbsp;myXmlDoc.Elements&nbsp;Select&nbsp;c</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__com">'For&nbsp;Each&nbsp;myResult&nbsp;In&nbsp;myQuery</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__com">'&nbsp;&nbsp;&nbsp;&nbsp;Console.WriteLine(myResult.ToString)</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__com">'Next</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">End</span>&nbsp;<span class="visualBasic__keyword">Sub</span>&nbsp;
<span class="visualBasic__keyword">End</span>&nbsp;<span class="visualBasic__keyword">Module</span>&nbsp;
&nbsp;
</pre>
</div>
</div>
</div>
<p>「デバッグなしで開始」すると、XDocument クラスを用いた場合の結果は図 1 上、XElement クラスを用いた場合の結果は図 1 下のようになります。</p>
<p><img src="18835-image001.gif" alt="図 1" width="570" height="534"></p>
<p>図 1 XDocument クラスを用いた場合 (上)、XElement クラスを用いた場合 (下)</p>
<p>XDocument クラスを用いた場合は、読み込んだ XML ドキュメントのルート要素ノード &lt;CodeRecipe&gt; は、ルート ノードの子扱いになります。一方、XElement クラスを用いると，読み込んだ XML ドキュメントのルート要素ノードはルート ノード扱いになります。<br>
そのため、XElement クラスを用いると、XDocument クラスを用いた場合より一階層下のコレクションが返されるようになります。</p>
<p>なお、テキストのみ取得したい場合は、<a href="http://msdn.microsoft.com/ja-jp/library/bb341005" target="_blank">ToString</a> ではなく、Value を使って、Console.WriteLine(MyResult.Value) のように記述します。</p>
<p>既存 XML データを再利用するケースでは、この 2 つの方法以外に、<a href="http://msdn.microsoft.com/ja-jp/library/system.io.streamreader.aspx" target="_blank">StreamReader クラス</a>によって、XML ドキュメントを読み込んで処理した後、XDocument クラスを用いて再読み込みする方法が用いられることもあります。</p>
<p>前掲のリスト 1 は混合内容の XML ドキュメントで、「大分類1」「大分類2」「大分類3」は、タグで挟まれていません。<br>
リスト 3 では、まず、この XML ドキュメントを StreamReader クラスでテキストとして読み込み、改行とタブを取り除いた後、単純な文字置換によって、&lt;Category&gt; 要素のテキストが &lt;Name&gt; 要素の内容となるよう、構造を変更しています。</p>
<p>このようにして処理しやすい構造となった XML ドキュメントを、<a href="http://msdn.microsoft.com/ja-jp/library/system.xml.linq.xdocument.parse.aspx" target="_blank">XDocument クラスの Parse メソッド</a>を用いて、再読み込みしています。<br>
出力結果は、図 2 のようになります。</p>
<p><strong>リスト 3 テキストとして XML ドキュメントを操作した後、Parse メソッドで再処理する</strong></p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>Visual Basic</span></div>
<div class="pluginEditHolderLink">スクリプトの編集</div>
<span class="hidden">vb</span>

<div class="preview">
<pre id="codePreview" class="vb">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">Dim</span>&nbsp;myStr&nbsp;<span class="visualBasic__keyword">As</span>&nbsp;StreamReader&nbsp;=&nbsp;<span class="visualBasic__keyword">New</span>&nbsp;StreamReader(<span class="visualBasic__string">&quot;data\LinqSample.xml&quot;</span>)&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">Dim</span>&nbsp;myReplaceText&nbsp;<span class="visualBasic__keyword">As</span>&nbsp;<span class="visualBasic__keyword">String</span>&nbsp;=&nbsp;myStr.ReadToEnd&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;myStr.Close()&nbsp;&nbsp;
&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">Dim</span>&nbsp;myXmlText&nbsp;<span class="visualBasic__keyword">As</span>&nbsp;<span class="visualBasic__keyword">String</span>&nbsp;=&nbsp;myReplaceText.Replace(vbCrLf,&nbsp;<span class="visualBasic__keyword">String</span>.Empty).Replace(Chr(<span class="visualBasic__number">9</span>),&nbsp;<span class="visualBasic__keyword">String</span>.Empty)&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;myXmlText&nbsp;=&nbsp;Replace(myXmlText,&nbsp;<span class="visualBasic__string">&quot;&lt;Category&gt;&quot;</span>,&nbsp;<span class="visualBasic__string">&quot;&lt;Category&gt;&lt;Name&gt;&quot;</span>)&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;myXmlText&nbsp;=&nbsp;Replace(myXmlText,&nbsp;<span class="visualBasic__string">&quot;&lt;SubCategory&gt;&quot;</span>,&nbsp;<span class="visualBasic__string">&quot;&lt;/Name&gt;&lt;SubCategory&gt;&quot;</span>)&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;myXmlText&nbsp;=&nbsp;Replace(myXmlText,&nbsp;<span class="visualBasic__string">&quot;&lt;/SubCategory&gt;&lt;/Name&gt;&quot;</span>,&nbsp;<span class="visualBasic__string">&quot;&lt;/SubCategory&gt;&quot;</span>)&nbsp;&nbsp;
&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">Dim</span>&nbsp;myXmlDoc&nbsp;<span class="visualBasic__keyword">As</span>&nbsp;XDocument&nbsp;=&nbsp;XDocument.Parse(myXmlText)&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">Dim</span>&nbsp;myQuery&nbsp;=&nbsp;From&nbsp;c&nbsp;<span class="visualBasic__keyword">In</span>&nbsp;myXmlDoc.Elements&nbsp;<span class="visualBasic__keyword">Select</span>&nbsp;c&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">For</span>&nbsp;<span class="visualBasic__keyword">Each</span>&nbsp;myResult&nbsp;<span class="visualBasic__keyword">In</span>&nbsp;myQuery.Elements.&lt;Name&gt;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Console.WriteLine(myResult.Value)&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">Next</span>&nbsp;
&nbsp;
</pre>
</div>
</div>
</div>
<p><img src="18836-image002.gif" alt="図 2" width="443" height="184"></p>
<p>図 2 2 段階の処理で混合内容のテキストを取得した結果</p>
<h2 style="font-size:120%; margin-top:20px">関連リンク</h2>
<ul>
<li><a href="http://msdn.microsoft.com/ja-jp/library/system.xml.linq.xdocument" target="_blank">XDocument クラス</a>
</li><li><a href="http://msdn.microsoft.com/ja-jp/library/bb350413" target="_blank">XElement.Load メソッド (String)</a>
</li><li><a href="http://msdn.microsoft.com/ja-jp/library/bb387087" target="_blank">プログラミング ガイド (LINQ to XML)</a>
</li></ul>
<hr>
<table>
<tbody>
<tr>
<td><a href="http://code.msdn.microsoft.com/ja-jp"><img title="Code Recipe" src="-ff950935.coderecipe_180x70%28ja-jp,msdn.10%29.jpg" border="0" alt="Code Recipe" width="180" height="70" style="margin-top:3px"></a></td>
<td>
<ul>
<li>もっと他のコンテンツを見る &gt;&gt; <a href="http://msdn.microsoft.com/ja-jp/ff363212" target="_blank">
逆引きサンプル コード一覧へ</a> </li><li>もっと他のレシピを見る &gt;&gt; <a href="http://code.msdn.microsoft.com/ja-jp">Code Recipe へ</a>
</li></ul>
</td>
</tr>
</tbody>
</table>
<p style="margin-top:20px"><a href="#top"><img src="-top.gif" border="0" alt="">ページのトップへ</a></p>
