# [連載! とことん VC++] 第 7 回 MFC アプリケーションの基本構造の再確認 ～ドキュメント/ビューにおけるカスタマイズ～
## License
- Apache License, Version 2.0
## Technologies
- Visual Studio 2010
- Visual C++ 2010
## Topics
- Visual C++ プログラミング
- 連載! とことん VC++
## Updated
- 07/21/2011
## Description

<div id="top"></div>
<p>執筆者: <a href="http://msdn.microsoft.com/ja-jp/gg585574#yajima" target="_blank">
エディフィストラーニング株式会社 矢嶋 聡</a></p>
<hr>
<h2>目次</h2>
<ol>
<li><a href="#01">はじめに</a> </li><li><a href="#02">フレーム ウィンドウの基本的なカスタマイズ</a> </li><li><a href="#03">フレーム ウィンドウのスタイル設定</a> </li><li><a href="#04">子要素の作成 ～ステータス バーの追加～</a> </li><li><a href="#05">子ウィンドウ (ドキュメント/ビュー) の初期化</a> </li><li><a href="#06">ビューに子要素として EDIT コントロールを追加する</a> </li><li><a href="#07">ドキュメントの初期化、および表示前のビューの初期化</a> </li><li><a href="#08">基本的なビューの描画の流れ</a> </li><li><a href="#09">ビューの描画、およびドキュメントの変更に伴うビューの更新</a> </li><li><a href="#10">ドキュメントの保存と読み込み</a> </li><li><a href="#11">まとめ</a> </li></ol>
<hr>
<h2 id="01" style="font-size:120%; margin-top:20px">1. はじめに</h2>
<p>今回も前回に引き続き、MFC (Microsoft Foundation Class) ライブラリについて取り上げます。</p>
<p><a href="http://code.msdn.microsoft.com/ja-jp/VisualC-43c71460">前回</a>は、ドキュメント/ビュー アーキテクチャを利用したアプリケーションの基本的な構造を確認しました。今回は、そのアプリケーションに対して、ウィンドウをカスタマイズするコードや独自の実装コードを追加するなどの作業を通して、ドキュメント/ビュー アーキテクチャに対して、どのような作業が必要になるかという点を確認します。</p>
<p>一般に MFC アプリケーションに機能を追加する場合は、クラスのメンバー関数をオーバーライドしたり、イベント駆動型のハンドラーに当たる関数を実装したりします。これらの関数は、ある一定の順序で呼び出され、この仕組みをうまく生かすには、それぞれの関数で行うべき役割や位置付けを理解しておく必要があります。今回は、このような各関数の特徴もふまえ、独自のコードをいくつか追加していきます。</p>
<div style="padding:0pt 15px; margin:0pt 0pt 30px; background-color:#efefef; border:1px solid #333333">
<p><strong>Note:</strong></p>
<p>今回は、前回の続編となるため、予め、<a href="http://code.msdn.microsoft.com/ja-jp/VisualC-43c71460">前回 (第 6 回)</a> の記事を一通りお読みになることをお勧めします。</p>
<p>また、今回も、サンプル コードを机上で確認できるように、サンプル固有の実装部分を一通り掲載していますが、このサンプル コードを入力して動作を確認するのであれば、まずは、前回のサンプル プログラムである「SmallApp プロジェクト」を作成して、実行可能な状態にしておいてください。今回は、この SmallApp プロジェクトにコードを追加していきます。</p>
<p>なお、手っ取り早く前回のサンプルを作成する方法としては、<a href="http://code.msdn.microsoft.com/ja-jp/VisualC-43c71460">前回</a>巻末の「参考手順」に従い、「MFCア プリケーション ウィザード」を用いて SmallApp プロジェクトと同等のコードを生成させる方法もあります。このウィザードで生成した場合、SmallApp プロジェクトと完全には同じではありませんが、この後示すサンプル コードと同じになるように修正すれば、動作確認を行うことができます。</p>
</div>
<p><a href="#top" target="_self"><img src="http://www.microsoft.com/japan/msdn/nodehomes/graphics/top.gif" border="0" alt="">ページのトップへ</a></p>
<hr>
<h2 id="02" style="font-size:120%; margin-top:20px">2. フレーム ウィンドウの基本的なカスタマイズ</h2>
<p>前回の SmallApp プロジェクトでは、MDI アプリケーションとして、メインのフレーム ウィンドウは標準的な実装を使用していました。ここでは、このフレーム ウィンドウに対して、スタイルの一部を変更し、ウィンドウの子要素であるステータス バーを追加してみます。</p>
<p>まず、このようなカスタマイズ コードを実装すべき典型的な箇所を見極めるため、MFC ライブラリを含め、フレーム ウィンドウが構築される過程を確認してみましょう。次の図は、フレーム ウィンドウが構築される際の、基本的な実行の流れを表しています。</p>
<p><img src="http://i1.code.msdn.s-msft.com/visualc-23226768/image/file/25244/1/img07_01.gif" alt="図 7.1" width="600" height="346"></p>
<p><strong>図 7.1 フレーム ウィンドウの構築</strong></p>
<p>前回触れたように、メインのフレーム ウィンドウを作成する典型的な方法は、図 7.1 の (1) のように、アプリケーション クラスの InitInstance 関数の中から、フレーム ウィンドウの LoadFrame 関数を呼び出す方法です。</p>
<p>LoadFrame 関数が呼び出されると、フレーム ウィンドウが作成される過程の中で、(2) から (7) までが数字の順に実行されます。今回は MDI アプリケーションであるため、CFrameWnd クラスの派生クラスである CMDIFrameWnd の LoadFrame 関数を呼び出しています。</p>
<p>このうち 3 つの●印付きの関数は、プログラマーが独自の実装をする部分です。ただし、MFC アプリケーション ウィザードを使用すると、3 つの関数のひな形は自動的に生成されます。</p>
<div style="padding:0pt 15px; margin:0pt 0pt 30px; background-color:#efefef; border:1px solid #333333">
<p><strong>Note:</strong></p>
<p>今回のサンプル プログラムでは、MFC アプリケーション ウィザード、もしくは、クラス ウィザードを用いて、●印の関数のすべてのひな形を自動生成することができます。よって、プログラマーが実質的に記述するのは、その関数の内部実装だけです。</p>
<p>また、極論すれば、MFC のクラスを継承し、オーバーライドや隠ぺいを利用して、任意の実装に自由に変更できます。この図やこれ以降の図での●印は、あくまで典型的な実装の目安であり、●印が付いたものを必ずプログラマーが実装するという絶対的な基準でありません。同様に、以降の図で●印がないからと言って、常に MFC ライブラリの標準実装を使用するとは限りません。</p>
</div>
<p>(2) の LoadFrame 関数の中では、(3) と (5) のように、PreCreateWindow メンバー関数を呼び出したのち、ウィンドウの生成を行っています。</p>
<p>(4) の PreCreateWindow 関数は、ウィンドウが作成される前に呼び出されるので、ウィンドウの生成前に、ウィンドウのスタイルなどを設定する実装コードを記述する箇所です。</p>
<p>(5) では、Windows API を使用して、ウィンドウを作成します。このタイミングで (6) のように、WM_CREATE メッセージが発生します。そして、このメッセージに呼応するハンドラーである (7) が呼び出されます。(7) の OnCreate 関数が呼び出された時点は、ウィンドウ ハンドルは確定し、まだ表示されていない状態となり、このウィンドウに属する子ウィンドウなどの子要素を作る上で適切なタイミングになります。</p>
<p>まとめると、フレーム ウィンドウに関してカスタマイズする場合には、(4) の PreCreateWindow 関数と (7) の OnCreate 関数を使用します。これは、CWnd クラスから派生するすべてのウィンドウに当てはまります。後述する子フレームやビューも、同様のカスタマイズが可能です。</p>
<p>それでは、実際に SmallApp プロジェクトに、これら 2 つの関数を追加して、フレーム ウィンドウをカスタマイズしてみましょう。</p>
<p><a href="#top" target="_self"><img src="http://www.microsoft.com/japan/msdn/nodehomes/graphics/top.gif" border="0" alt="">ページのトップへ</a></p>
<hr>
<h2 id="03" style="font-size:120%; margin-top:20px">3. フレーム ウィンドウのスタイル設定</h2>
<p>ここではフレーム ウィンドウのスタイルを変更して、最大化ボタンを無効化し、ウィンドウ自体を常に前面に表示するように設定してみましょう。例 7.1 に示すコードを CFrameWnd クラスへ追加してください ([1] から [6])。</p>
<p><strong>例 7.1 フレーム ウィンドウのスタイル設定</strong></p>
<p><strong>ファイル名: MainFrm.h (既存修正)</strong></p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>C&#43;&#43;</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">スクリプトの編集</span>|<span class="pluginRemoveHolderLink">{#scriptcode_dlg.remove_script}</span></div>
<span class="hidden">cplusplus</span>

<div class="preview">
<pre id="codePreview" class="cplusplus"><span class="cpp__preproc">#pragma&nbsp;once</span>&nbsp;
&nbsp;
<span class="cpp__keyword">class</span>&nbsp;CMainFrame&nbsp;:&nbsp;<span class="cpp__keyword">public</span>&nbsp;CMDIFrameWnd&nbsp;
{&nbsp;
<span class="cpp__keyword">public</span>:&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cpp__com">//&nbsp;スタイル設定などの初期化</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cpp__keyword">virtual</span>&nbsp;<span class="cpp__datatype">BOOL</span>&nbsp;PreCreateWindow(CREATESTRUCT&amp;&nbsp;cs);&nbsp;&nbsp;<span class="cpp__com">//&larr;[1]</span>&nbsp;
};</pre>
</div>
</div>
</div>
<p><strong>ファイル名: MainFrm.cpp (既存修正)</strong></p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>C&#43;&#43;</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">スクリプトの編集</span>|<span class="pluginRemoveHolderLink">{#scriptcode_dlg.remove_script}</span></div>
<span class="hidden">cplusplus</span>

<div class="preview">
<pre id="codePreview" class="cplusplus"><span class="cpp__preproc">#include&nbsp;&quot;stdafx.h&quot;</span><span class="cpp__preproc">&nbsp;
#include&nbsp;&quot;MainFrm.h&quot;</span>&nbsp;
&nbsp;
<span class="cpp__com">//&nbsp;スタイル設定などの初期化</span>&nbsp;
<span class="cpp__datatype">BOOL</span>&nbsp;CMainFrame::PreCreateWindow(CREATESTRUCT&amp;&nbsp;cs)&nbsp;&nbsp;<span class="cpp__com">//&larr;[2]</span>&nbsp;
{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cpp__keyword">if</span>(&nbsp;!CMDIFrameWnd::PreCreateWindow(cs)&nbsp;)&nbsp;&nbsp;<span class="cpp__com">//&larr;[3]</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cpp__keyword">return</span>&nbsp;FALSE;&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;cs.style&nbsp;&amp;=&nbsp;~(WS_MAXIMIZEBOX);&nbsp;&nbsp;&nbsp;<span class="cpp__com">//スタイル&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&larr;[4]</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;cs.dwExStyle&nbsp;|=&nbsp;WS_EX_TOPMOST;&nbsp;&nbsp;&nbsp;<span class="cpp__com">//拡張スタイル&nbsp;&nbsp;&larr;[5]</span>&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cpp__keyword">return</span>&nbsp;TRUE;&nbsp;&nbsp;<span class="cpp__com">//&larr;[6]</span>&nbsp;
}</pre>
</div>
</div>
</div>
<p>[1] と [2] のように、PreCreateWindow 関数をオーバーライドします。この関数の正確な役割は、引数として受け取る CREATESTRUCT 構造体に対して、ウィンドウの作成に必要となる情報を設定することです。この構造体には、ウィンドウのスタイル以外に、ウィンドウ クラスや位置、幅、高さなどの情報も指定できます。基本クラスで定義された同名のメンバー関数で標準的な設定を行っているので、通常は [3] のように、まず基本クラスの同名関数を呼び出します。そして、[4] や [5] のように、この構造体のメンバーに必要な情報を追加します。</p>
<div style="padding:0pt 15px; margin:0pt 0pt 30px; background-color:#efefef; border:1px solid #333333">
<p><strong>Note:</strong></p>
<p>CREATESTRUCT 構造体については、以下を参照してください。</p>
<ul>
<li><a href="http://msdn.microsoft.com/ja-jp/library/9930zz74.aspx" target="_blank">CREATESTRUCT 構造体</a>
</li></ul>
</div>
<p>ウィンドウのスタイルは、[4] のスタイルと [5] の拡張スタイルの 2 種類を指定でき、必要なスタイルを表すビットを設定します。[4] では、最大化ボタンのビット (WS_MAXIMIZEBOX) をオフに設定し、[5] では、常に前面に表示させるビット (WS_EX_TOPMOST) をオンに設定しています。</p>
<p>そして、この関数での処理が問題なく終了すれば、[6] のように TRUE を返します。</p>
<p>この時点で実行すると、次図のように最大化ボタンは表示されますが無効化されており (グレー色)、ウィンドウも常に前面に表示されるようになります。</p>
<p><img src="http://i1.code.msdn.s-msft.com/visualc-23226768/image/file/25245/1/img07_02.jpg" alt="図 7.2" width="600" height="332"></p>
<p><strong>図 7.2 最大化ボタンの無効化と常に前面表示 (メモ帳がアクティブだが SmallApp が前面)</strong></p>
<div style="padding:0pt 15px; margin:0pt 0pt 30px; background-color:#efefef; border:1px solid #333333">
<p><strong>Note:</strong></p>
<p>この後の操作を行いやすくするため、[5] の常に前面に表示はコメントアウトして、解除しておくほうがよいでしょう。</p>
</div>
<p><a href="#top" target="_self"><img src="http://www.microsoft.com/japan/msdn/nodehomes/graphics/top.gif" border="0" alt="">ページのトップへ</a></p>
<hr>
<h2 id="04" style="font-size:120%; margin-top:20px">4. 子要素の作成 ～ステータス バーの追加～</h2>
<p>次に、フレーム ウィンドウの WM_CREATE メッセージ ハンドラーの中で、このフレーム ウィンドウの子ウィンドウに当たるステータス バーを追加してみます。次のように CFrameWnd クラスにコードを追加してください。ステータス バーで使用するリソース文字列も追加します。</p>
<p><strong>例 7.2 ステータス バーの追加</strong></p>
<p><strong>ファイル名: MainFrm.h (既存修正) - 完成版</strong></p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>C&#43;&#43;</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">スクリプトの編集</span>|<span class="pluginRemoveHolderLink">{#scriptcode_dlg.remove_script}</span></div>
<span class="hidden">cplusplus</span>

<div class="preview">
<pre id="codePreview" class="cplusplus"><span class="cpp__preproc">#pragma&nbsp;once</span>&nbsp;
&nbsp;
<span class="cpp__keyword">class</span>&nbsp;CMainFrame&nbsp;:&nbsp;<span class="cpp__keyword">public</span>&nbsp;CMDIFrameWnd&nbsp;
{&nbsp;
<span class="cpp__keyword">public</span>:&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cpp__com">//&nbsp;スタイル設定などの初期化のための関数</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cpp__keyword">virtual</span>&nbsp;<span class="cpp__datatype">BOOL</span>&nbsp;PreCreateWindow(CREATESTRUCT&amp;&nbsp;cs);&nbsp;
&nbsp;
<span class="cpp__keyword">protected</span>:&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cpp__com">//ステータスバー</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;CStatusBar&nbsp;m_wndStatusBar;&nbsp;&nbsp;<span class="cpp__com">//&nbsp;&larr;[7]</span>&nbsp;
&nbsp;
<span class="cpp__keyword">protected</span>:&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cpp__com">//&nbsp;WM_CREATEのメッセージ&nbsp;ハンドラー関数</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;afx_msg&nbsp;<span class="cpp__datatype">int</span>&nbsp;OnCreate(LPCREATESTRUCT&nbsp;lpCreateStruct);&nbsp;&nbsp;<span class="cpp__com">//&larr;[8]</span>&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;DECLARE_MESSAGE_MAP()&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cpp__com">//&larr;[9]</span>&nbsp;
};</pre>
</div>
</div>
</div>
<p><strong>ファイル名: MainFrm.cpp (既存修正) - 完成版</strong></p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>C&#43;&#43;</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">スクリプトの編集</span>|<span class="pluginRemoveHolderLink">{#scriptcode_dlg.remove_script}</span></div>
<span class="hidden">cplusplus</span>

<div class="preview">
<pre id="codePreview" class="cplusplus"><span class="cpp__preproc">#include&nbsp;&quot;stdafx.h&quot;</span><span class="cpp__preproc">&nbsp;
#include&nbsp;&quot;MainFrm.h&quot;</span>&nbsp;
&nbsp;
<span class="cpp__com">//&nbsp;スタイル設定などの初期化</span>&nbsp;
<span class="cpp__datatype">BOOL</span>&nbsp;CMainFrame::PreCreateWindow(CREATESTRUCT&amp;&nbsp;cs)&nbsp;
{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cpp__keyword">if</span>(&nbsp;!CMDIFrameWnd::PreCreateWindow(cs)&nbsp;)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cpp__keyword">return</span>&nbsp;FALSE;&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;cs.style&nbsp;&amp;=&nbsp;~(WS_MAXIMIZEBOX);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;cs.dwExStyle&nbsp;|=&nbsp;WS_EX_TOPMOST;&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cpp__keyword">return</span>&nbsp;TRUE;&nbsp;
}&nbsp;
&nbsp;
<span class="cpp__com">//&nbsp;メッセージ&nbsp;マップ</span>&nbsp;
BEGIN_MESSAGE_MAP(CMainFrame,&nbsp;CMDIFrameWnd)&nbsp;&nbsp;<span class="cpp__com">//&larr;[10]</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;ON_WM_CREATE()&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cpp__com">//&larr;[11]</span>&nbsp;
END_MESSAGE_MAP()&nbsp;
&nbsp;
<span class="cpp__keyword">static</span>&nbsp;<span class="cpp__datatype">UINT</span>&nbsp;indicators[]&nbsp;=&nbsp;<span class="cpp__com">//&larr;[12]</span>&nbsp;
{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;ID_SEPARATOR,&nbsp;ID_INDICATOR_CAPS,&nbsp;
};&nbsp;
&nbsp;
<span class="cpp__com">//&nbsp;WM_CREATEのメッセージ&nbsp;ハンドラー関数</span>&nbsp;
<span class="cpp__datatype">int</span>&nbsp;CMainFrame::OnCreate(LPCREATESTRUCT&nbsp;lpCreateStruct)&nbsp;&nbsp;<span class="cpp__com">//&larr;[13]</span>&nbsp;
{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cpp__keyword">if</span>&nbsp;(CMDIFrameWnd::OnCreate(lpCreateStruct)&nbsp;==&nbsp;-<span class="cpp__number">1</span>)&nbsp;&nbsp;&nbsp;&nbsp;<span class="cpp__com">//&larr;[14]</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cpp__keyword">return</span>&nbsp;-<span class="cpp__number">1</span>;&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cpp__com">//&nbsp;ステータスバーの作成</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cpp__keyword">if</span>&nbsp;(!m_wndStatusBar.Create(<span class="cpp__keyword">this</span>))&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cpp__com">//&larr;[15]</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cpp__keyword">return</span>&nbsp;-<span class="cpp__number">1</span>;&nbsp;&nbsp;<span class="cpp__com">//&nbsp;作成できない場合</span>&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;m_wndStatusBar.SetIndicators(&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cpp__com">//&larr;[16]</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;indicators,&nbsp;<span class="cpp__keyword">sizeof</span>(indicators)/<span class="cpp__keyword">sizeof</span>(<span class="cpp__datatype">UINT</span>));&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cpp__keyword">return</span>&nbsp;<span class="cpp__number">0</span>;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cpp__com">//&nbsp;作成できた場合&nbsp;&larr;[17]</span>&nbsp;
}</pre>
</div>
</div>
</div>
<p><strong>ファイル名: SmallApp.rc (既存修正)</strong></p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>C&#43;&#43;</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">スクリプトの編集</span>|<span class="pluginRemoveHolderLink">{#scriptcode_dlg.remove_script}</span></div>
<span class="hidden">cplusplus</span>

<div class="preview">
<pre id="codePreview" class="cplusplus">&nbsp;&nbsp;(略)&nbsp;
&nbsp;
STRINGTABLE&nbsp;&nbsp;&nbsp;<span class="cpp__com">//&larr;[18]&nbsp;ここから</span>&nbsp;
BEGIN&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;AFX_IDS_IDLEMESSAGE&nbsp;<span class="cpp__string">&quot;レディ(SmallApp)&quot;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;ID_VIEW_ITEM1&nbsp;<span class="cpp__string">&quot;項目1を実行します。&quot;</span>&nbsp;
END&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cpp__com">//&larr;[18]&nbsp;ここまで</span></pre>
</div>
</div>
</div>
<p>WM_CREATE メッセージのハンドラーを作成するには、メッセージとハンドラーを関連付けるための「メッセージ マップ マクロ」を記述する必要があります。このマクロを記述することで、MFC ライブラリにとって必要となる、メッセージと関数とを対応付けるテーブルが作成されます。ここでは、[9] と [10] にメッセージ マップ マクロが記述されています。[11] の ON_WM_CREATE マクロが、WM_CREATE メッセージに対してハンドラーを対応付けるためのものです。このマクロを使用すると、[8]
 および [13] に記述された、特定のシグニチャを持つ OnCreate 関数とマップさせることができます。(実際は、これらのメッセージ マップ マクロの記述も、クラス ウィザードを使用して自動生成することができます。)</p>
<div style="padding:0pt 15px; margin:0pt 0pt 30px; background-color:#efefef; border:1px solid #333333">
<p><strong>Note:</strong></p>
<p>メッセージ マップ マクロに関する詳細は、以下を参照してください。</p>
<ul>
<li><a href="http://msdn.microsoft.com/ja-jp/library/0x0cx6b1.aspx" target="_blank">メッセージ マップ (MFC)</a>
</li></ul>
</div>
<p>ステータス バーは CStatusBar クラスのオブジェクト インスタンスとして表現できます。ここでは、[7] に定義されています。この CStatusBar オブジェクトを CMainFrame クラスのメンバー変数にする必要はありませんが、このようにすると、親ウィンドウであるフレーム ウィンドウ (CMainFrame) とその子要素であるステータス バー (CStatusBar) との生成および削除のタイミングが一致するので、CStatusBar オブジェクトのライフタイムの管理が簡単になります。</p>
<p>次に、WM_CREATE メッセージ ハンドラーの内部を見てみましょう。</p>
<p>まず、[14] のように基本クラスの OnCreate メンバー関数を呼び出して、標準実装を実行した後、[15] でステータス バーを作成しています。Create メンバー関数を呼び出して、その引数に親となるオブジェクトを渡します。これで、ステータス バーがフレーム ウィンドウに貼り付きます。</p>
<p>ステータス バーに限らす、一般的に子ウィンドウとなる UI 要素を作成する場合、Create メンバー関数を呼び出し、その引数に親ウィンドウ自体を渡します (Create 関数のシグニチャは、オブジェクトによって異なります)。のちほど、ビュー クラスに EDIT コントロール (CEdit) を貼り付けますが、同様の方法を用います。</p>
<p>また、[15] では作成に失敗したか否かを評価し、失敗した場合は、OnCreate 関数の戻り値として -1 を返します。成功した場合は、[17] のように 0 を返します。この OnCreate 関数の戻り値の成否によって、図 7.1 の (1) の LoadFrame 関数の戻り値 (BOOL 型) が異なります。OnCreate 関数の戻り値が、失敗を意味する -1 であると、LoadFrame 関数の戻り値が FALSE になります。本来ならば、LoadFrame 関数の戻り値が FALSE ならば、処理を中止するなど実装が必要ですが、簡単にするため、このサンプルでは省略しています。</p>
<p>[16] の SetIndicators 関数は、ステータス バーの領域をいくつかの領域に細分化するためのものです。その際、細分化された領域の用途は、1 番目の引数である indicators 配列で決まります。この配列は、[12] に定義されており、ここでは定義済みのインジケーター ID (afxres.h で定義済み) を使用しています。この配列の 1 つ目の要素である ID_SEPARATOR を指定した領域は、MFC ライブラリによって、特定のリソース ID を持つ文字列が表示されます。既定では、前述の
 SmallApp.rc に記述された AFX_IDS_IDLEMESSAGE という ID を持つ文字列が表示されます (ここでは、&quot;レディ (SmallApp)&quot;)。また、実行時にメニュー項目の上をマウスでホバリングすると、そのメニュー項目のコマンド ID と同じリソース ID を持つ文字列が表示されます。このサンプルの [項目 1] メニューのコマンド ID (ID_VIEW_ITEM1) と同じ ID を持つ文字列リソース (&quot;項目 1 を実行します。&quot;) は、そのために用意しました。</p>
<p>また、ID_INDICATOR_CAPS を指定した領域は、Caps Lock がオンの場合、「CAP」と表示されるようになります (のちほど、サンプルを実行して確認します)。</p>
<div style="padding:0pt 15px; margin:0pt 0pt 30px; background-color:#efefef; border:1px solid #333333">
<p><strong>Note:</strong></p>
<p>ここでは、簡単にするため基本機能を提供する CStatusBar クラスを使用しましたが、MFC アプリケーション ウィザードの既定で生成されるコードでは、より高度な機能を持つステータス バーである CMFCStatusBar クラスが使用されます。ただし、基本的な使い方は同じです。</p>
</div>
<p>それでは、この SmallApp プロジェクトのアプリケーションを実行してみましょう。</p>
<p>実行すると、次図のように「レディ (SmallApp)」という表示を伴うステータス バーが表示され、Caps Lock がオンの場合には、「CAP」という表示が右下部に表示されます。</p>
<p><img src="http://i1.code.msdn.s-msft.com/visualc-23226768/image/file/25246/1/img07_03.gif" alt="図 7.3" width="580" height="334"></p>
<p><strong>図 7.3 ステータスバーが追加される</strong></p>
<p>また、子ウィンドウを閉じたのち、メニュー バーの [表示] メニュー配下にある [項目 1] メニュー上にマウス ポインターを移動すると、ステータス バーには、メニュー項目のコマンド ID と同じリソース ID の文字列「項目 1 を実行します。」が表示されます。</p>
<p><img src="http://i1.code.msdn.s-msft.com/visualc-23226768/image/file/25247/1/img07_04.jpg" alt="図 7.4" width="580" height="169"></p>
<p><strong>図 7.4 メニューと連動したステータス バーの動的変化 ([項目 1] メニュー)</strong></p>
<p>また、[ファイル] メニュー配下の [アプリケーションの終了] メニューの上にマウス ポインターを移動すると、次図のように、そのメニュー項目の説明文が表示されます。というのは、もともとこのメニュー項目については、MFC の定義済みコマンド ID である ID_APP_EXIT を使用しており、MFC では、この ID_APP_EXIT をリソース ID とする文字列が既に定義されているからです。</p>
<p><img src="http://i1.code.msdn.s-msft.com/visualc-23226768/image/file/25248/1/img07_05.jpg" alt="図 7.5" width="580" height="169"></p>
<p><strong>図 7.5 メニューと連動したステータス バーの動的変化 ([アプリケーションの終了] メニュー)</strong></p>
<p>確認が済んだら、アプリケーションを終了しておきましょう。</p>
<p><a href="#top" target="_self"><img src="http://www.microsoft.com/japan/msdn/nodehomes/graphics/top.gif" border="0" alt="">ページのトップへ</a></p>
<hr>
<h2 id="05" style="font-size:120%; margin-top:20px">5. 子ウィンドウ (ドキュメント/ビュー) の初期化</h2>
<p>次に、1 つの子ウィンドウの実装として必要となる 3 種類のクラス、すなわち、子フレーム、ドキュメント、ビューに関してのカスタマイズ方法を確認しましょう。ただし、子フレームのカスタマイズ方法については、前述のフレーム ウィンドウとほぼ同じなので、ここでは、特にドキュメントとビューのカスタマイズに着目します。</p>
<p>次図は、前回に説明した新規作成において、OnFileNew 関数呼び出しからドキュメント テンプレートが利用するメンバー関数の呼ばれる順番を中心に、実行制御を表したものです。</p>
<p><img src="http://i1.code.msdn.s-msft.com/visualc-23226768/image/file/25249/1/img07_06.gif" alt="図 7.6" width="600" height="489"></p>
<p><strong>図 7.6 ドキュメント テンプレートを用いた子ウィンドウ作成の流れ</strong></p>
<p>実際には、もう少し複雑な流れをしていますが、ここでは、各オブジェクトのカスタマイズのポイントが分かるように、いくつか要点を示しています。</p>
<p>この図の上部の OnFileNew 関数と OpenDocumentFile 関数については、前回説明しましたので、ここでは、右上の OpenDocumentFile 関数の中で 3 種類のオブジェクトが、どのように作成されるかという点に着目します。</p>
<p>この図でも、●印を付けたメンバー関数は、プログラマーが固有の実装を書くべき場所ですが、特に必要なければ、書かなくとも構いません。(ただし、ドキュメント テンプレートが、この 3 種類のオブジェクトを自動生成するには、それぞれのクラスに引数無しのコントラクターが必要となります。ただし、コンストラクターを全く書かなければ、引数無しのコントラクターがあると見なされるので、コンストラクターを書かないことも可能です。)</p>
<p>実際のところ、MFC アプリケーション ウィザードによって、OnCreate 関数と OnInitialUpdate 関数以外は、ひな形が生成されます。OnCreate 関数と OnInitialUpdate 関数は、クラス ウィザードによって生成させることができますから、プログラマーが記述するのは、各関数の実装コードだけです。</p>
<p>それでは、各関数の特徴や役割を確認しましょう。</p>
<p>この図でも、(1) から (9) までの番号は、実行の順番を表しています。</p>
<p>このうち、(1)、(2)、および (5) の各コンストラクターの扱いは、一般的な使用方法と同じであり、オブジェクト インスタンスにとって、1 回だけ必要な初期化を記述することになります。ただし、MFC ライブラリでは、初期化の内容によって、このあと説明するような専用のメンバー関数が用意してあるので、該当する初期化はそれらの専用の関数に記述するのが適当です。</p>
<p>子フレーム ウィンドウやビューは、ウィンドウの一種であり、カスタマイズの方法は前述のメインのフレーム ウィンドウと同様です。つまり、子フレーム ウィンドウの場合は、(3) の PreCreateWindow 関数でスタイルを調整し、(4) の OnCreate 関数で必要な子要素を作成することになります。同様にビューの場合も、(6) の PreCreateWindow 関数でスタイルを設定し、(7) の OnCreate 関数の中でビューにとっての子要素を作成します。</p>
<p>1 つ留意すべき点は、ビューは子フレーム ウィンドウのクライアント領域に埋め込まれた子ウィンドウであるという点です。よって、MFC ライブラリに用意された標準実装では、子フレーム ウィンドウの (4) の OnCreate 関数の中で、子要素としてビューを作成しています。よって、(4) の関数の中で、(5) から (7) までが実行されます。</p>
<p>このため、子フレーム ウィンドウのクラスから派生して、独自の子フレーム ウィンドウを定義して、派生クラスに独自の OnCreate 関数を実装する場合は注意が必要です。それは、派生クラスの OnCreate 関数の中から、標準実装である基本クラスの OnCreate 関数を呼び出す必要があることです。さもないと、(5) から (7) までの処理に進むことができず、ビューを作成できなくなります (結果として、子フレーム ウィンドウだけが表示されてしまいます)。</p>
<p>そして、子フレームとビューが作成されたのち、ドキュメントの初期化のため (8) の OnNewDocument 関数が、ドキュメント テンプレートによって呼び出されます。プログラマーは、OnNewDocument 関数の中に、初期状態のドキュメントを構築するコードを記述します。</p>
<p>この OnNewDocument 関数で重要なことは、その戻り値です。FALSE を返すと、ドキュメントの初期化に失敗したとみなされ、ここまで行った初期処理はすべてキャンセルされることになり、ビューや子フレームは破棄され、3 種類のオブジェクトが破棄されます。</p>
<p>OnNewDocument 関数の中でドキュメントの初期化に成功した場合は、TRUE を返す必要があります。初期化に成功すると次の (9) の OnInitialUpdate 関数が呼び出されます。</p>
<p>(9) にあるビューの OnInitialUpdate 関数が呼び出される時点では、ドキュメントの初期化は終わっており、ビューのコンテンツの描画コードが実行される直前の初期処理に利用できます。標準実装では、OnInitialUpdate 関数の中から、ビューの更新を行う OnUpdate を呼び出しており、最終的に、OnDraw 関数が呼び出され、ビューのクライアント領域に対する描画コードが実行されます (具体的な流れは後述)。</p>
<p>また、ビューに EDIT コントロール (テキスト ボックス) などの子要素が埋め込んである場合、ドキュメントの内容を基づいて初期化を行うのなら、OnInitialUpdate 関数の中で行うのが、タイミングとしては適当でしょう。</p>
<p>以上、基本的な初期処理の流れを確認しました。ここでは、紙面の都合もあり、この一連の初期処理の中で、ビューに子要素を追加するコードと、ドキュメントの基本的な実装を行うコードを追加します。</p>
<p><a href="#top" target="_self"><img src="http://www.microsoft.com/japan/msdn/nodehomes/graphics/top.gif" border="0" alt="">ページのトップへ</a></p>
<hr>
<h2 id="06" style="font-size:120%; margin-top:20px">6. ビューに子要素として EDIT コントロールを追加する</h2>
<p>ウィンドウに EDIT コントロールを貼り付ける実装方法としては、ビューを使わずに、CDialog クラスを利用して、ダイアログ ボックスとして実装する方法もあります。しかし、ここではビューに対するきめ細かいカスタマイズ方法を確認するために、プログラム コードを使用して、ビュー内部に子ウィンドウにあたる EDIT コントロールを貼り付けてみます。そのためには、図 7.6 の (7) に挙げたビューの OnCreate 関数の中で、子要素である EDIT コントロールを作成するようにします。次のように、コントロール
 ID を定義するほか、ビュー クラスにコードを追加してください (ソース コード中の番号は、クラス毎の連番になっています。ただし、リソース ファイルは、リソース内での連番です)。</p>
<p><strong>例 7.3 ビューへの EDIT コントロールの追加</strong></p>
<p><strong>ファイル名: resource.h (既存修正) - 完成版</strong></p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>C&#43;&#43;</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">スクリプトの編集</span>|<span class="pluginRemoveHolderLink">{#scriptcode_dlg.remove_script}</span></div>
<span class="hidden">cplusplus</span>

<div class="preview">
<pre id="codePreview" class="cplusplus"><span class="cpp__preproc">#define&nbsp;IDR_MAINFRAME&nbsp;128&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;//タイトル文字列、アイコン、メニューバー共通のID</span><span class="cpp__preproc">&nbsp;
#define&nbsp;ID_VIEW_ITEM1&nbsp;500&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;//メニュー項目の任意コマンドID</span><span class="cpp__preproc">&nbsp;
&nbsp;
#define&nbsp;IDR_SMALLTEXTTYPE&nbsp;800&nbsp;&nbsp;//子ウィンドウ、ドキュメントテンプレートのリソースID</span><span class="cpp__preproc">&nbsp;
&nbsp;
#define&nbsp;IDC_EDIT1&nbsp;1000&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;//EDITコントロールのID&nbsp;&larr;[1]</span></pre>
</div>
</div>
</div>
<p><strong>ファイル名: SmallView.h (既存修正)</strong></p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>C&#43;&#43;</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">スクリプトの編集</span>|<span class="pluginRemoveHolderLink">{#scriptcode_dlg.remove_script}</span></div>
<span class="hidden">cplusplus</span>

<div class="preview">
<pre id="codePreview" class="cplusplus"><span class="cpp__preproc">#pragma&nbsp;once</span><span class="cpp__preproc">&nbsp;
&nbsp;
#include&nbsp;&quot;resource.h&quot;&nbsp;&nbsp;&nbsp;&nbsp;//&larr;[1]</span>&nbsp;
&nbsp;
<span class="cpp__keyword">class</span>&nbsp;CSmallView&nbsp;:&nbsp;<span class="cpp__keyword">public</span>&nbsp;CView&nbsp;
{&nbsp;
<span class="cpp__keyword">protected</span>:&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;CSmallView();&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;DECLARE_DYNCREATE(CSmallView)&nbsp;
<span class="cpp__keyword">public</span>:&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;CSmallDoc*&nbsp;GetDocument();&nbsp;
<span class="cpp__keyword">public</span>:&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cpp__keyword">virtual</span>&nbsp;<span class="cpp__keyword">void</span>&nbsp;OnDraw(CDC*&nbsp;pDC);&nbsp;
<span class="cpp__keyword">protected</span>:&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cpp__com">//&nbsp;EDITコントロール&nbsp;&nbsp;&nbsp;&nbsp;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;CEdit&nbsp;m_ctlEdit1;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cpp__com">//&larr;[2]</span>&nbsp;
<span class="cpp__keyword">protected</span>:&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cpp__com">//&nbsp;WM_CREATEのメッセージ&nbsp;ハンドラー関数</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;afx_msg&nbsp;<span class="cpp__datatype">int</span>&nbsp;OnCreate(LPCREATESTRUCT&nbsp;lpCreateStruct);&nbsp;&nbsp;<span class="cpp__com">//&larr;[3]</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;DECLARE_MESSAGE_MAP()&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cpp__com">//&larr;[4]</span>&nbsp;
};</pre>
</div>
</div>
</div>
<p><strong>ファイル名: SmallView.cpp (既存修正)</strong></p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>C&#43;&#43;</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">スクリプトの編集</span>|<span class="pluginRemoveHolderLink">{#scriptcode_dlg.remove_script}</span></div>
<span class="hidden">cplusplus</span>

<div class="preview">
<pre id="codePreview" class="cplusplus">&nbsp;&nbsp;&nbsp;&nbsp;(略)&nbsp;
&nbsp;
BEGIN_MESSAGE_MAP(CSmallView,&nbsp;CView)&nbsp;&nbsp;<span class="cpp__com">//&larr;[5]</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;ON_WM_CREATE()&nbsp;
END_MESSAGE_MAP()&nbsp;
&nbsp;
<span class="cpp__datatype">int</span>&nbsp;CSmallView::OnCreate(LPCREATESTRUCT&nbsp;lpCreateStruct)&nbsp;&nbsp;<span class="cpp__com">//&larr;[6]</span>&nbsp;
{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cpp__keyword">if</span>&nbsp;(CView::OnCreate(lpCreateStruct)&nbsp;==&nbsp;-<span class="cpp__number">1</span>)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cpp__keyword">return</span>&nbsp;-<span class="cpp__number">1</span>;&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;m_ctlEdit1.Create(&nbsp;&nbsp;&nbsp;<span class="cpp__com">//&larr;[7]</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;ES_NUMBER&nbsp;|&nbsp;ES_RIGHT&nbsp;|&nbsp;WS_CHILD&nbsp;|&nbsp;WS_VISIBLE&nbsp;|&nbsp;WS_BORDER,&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;CRect(<span class="cpp__number">10</span>,<span class="cpp__number">10</span>,<span class="cpp__number">110</span>,<span class="cpp__number">36</span>),&nbsp;<span class="cpp__keyword">this</span>,&nbsp;IDC_EDIT1);&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cpp__keyword">return</span>&nbsp;<span class="cpp__number">0</span>;&nbsp;&nbsp;<span class="cpp__com">//&larr;[8]</span>&nbsp;
}</pre>
</div>
</div>
</div>
<p>まずは前述のとおり、ファイル resource.h に EDIT コントロールの ID のシンボルを定義します。(今回の resource.h はこれで完成です。) このコントロール ID を使用するため、ビュー クラスのヘッダーの [1] で、resource.h をインクルードします。</p>
<p>ビュー内部に、子要素として EDIT コントロールを貼り付ける手順は、メインのフレーム ウィンドウ (CFrameWnd) にステータス バー (CStatusBar) を追加したのと同じ要領です。</p>
<p>[2] の CEdit クラスは、Edit コントロールに相当するオブジェクトであり、ビュー クラスとライフタイムを同じにするため、メンバー変数として定義します。また、OnCreate メンバー関数を WM_CREATE メッセージのハンドラーとして定義するために、[3] の関数宣言のほか、[4] および [5] のメッセージ マップ マクロを記述します。</p>
<p>[6] の OnCreate 関数も、メインのフレーム ウィンドウと同様です。[6] の内部では、まず、基本クラスの OnCreate 関数を呼び出します。そして、[7] がポイントとなるコードであり、EDIT コントロールをビューに貼り付けています。EDIT コントロール (CEdit オブジェクト) の Create 関数を呼び出し、3 番目の引数には、親ウィンドウにあたるビュー オブジェクト (this) を指定しています。</p>
<p>1 番目の引数は、EDIT コントロールのスタイルを指定するビットを指定するためのものです。ここでは、数字入力 (ES_NUMBER)、右寄せ (ES_RIGHT)、子ウィンドウ (WS_CHILD)、表示 (WS_VISIBLE)、枠付き (WS_BORDER) という各種スタイルを指定しています。</p>
<p>2 番目の引数の CRect オブジェクトは、表示すべき位置と大きさを表し、4 番目の引数 IDC_EDIT1 がこの EDIT コントロールに割り振るコントロール ID です。</p>
<p>通常は、EDIT コントロールの作成に失敗することはありませんが、万が一失敗した場合は、ここでも -1 を返し、成功した場合は、[8] のように 0 を返します。既定の実装では、-1 が返ると新規作成の処理は中止され、「空のドキュメントの作成に失敗しました。」というメッセージが、メッセージ ボックスに表示されます。</p>
<p>ここで実行してみましょう。</p>
<p>すると、ビューには EDIT コントロールが表示され、このコントロールには数字のみが入力でき、右寄せで数字が表示されるはずです。</p>
<p><img src="http://i1.code.msdn.s-msft.com/visualc-23226768/image/file/25250/1/img07_07.gif" alt="図 7.7" width="556" height="396"></p>
<p><strong>図 7.7 ビューに表示された EDIT コントロール</strong></p>
<p><a href="#top" target="_self"><img src="http://www.microsoft.com/japan/msdn/nodehomes/graphics/top.gif" border="0" alt="">ページのトップへ</a></p>
<hr>
<h2 id="07" style="font-size:120%; margin-top:20px">7. ドキュメントの初期化、および表示前のビューの初期化</h2>
<p>それでは、前述の EDIT コントロールの内容をドキュメント内のデータとして保持できるように、ドキュメントにメンバー変数を確保し、その値を初期化して、EDIT コントロールに反映できるようにしましょう。次のコードをドキュメント クラスとビュー クラスに追加してください。(ソース コード中の番号は、クラスごとの連番になっています。)</p>
<p><strong>例 7.4 ドキュメントとビューの初期化</strong></p>
<p><strong>ファイル名: SmallDoc.h (既存修正)</strong></p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>C&#43;&#43;</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">スクリプトの編集</span>|<span class="pluginRemoveHolderLink">{#scriptcode_dlg.remove_script}</span></div>
<span class="hidden">cplusplus</span>

<div class="preview">
<pre id="codePreview" class="cplusplus"><span class="cpp__preproc">#pragma&nbsp;once</span>&nbsp;
<span class="cpp__keyword">class</span>&nbsp;CSmallDoc&nbsp;:&nbsp;<span class="cpp__keyword">public</span>&nbsp;CDocument&nbsp;
{&nbsp;
<span class="cpp__keyword">protected</span>:&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;CSmallDoc();&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;DECLARE_DYNCREATE(CSmallDoc)&nbsp;
<span class="cpp__keyword">public</span>:&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cpp__datatype">int</span>&nbsp;m_nData;&nbsp;&nbsp;<span class="cpp__com">//&larr;[1]</span>&nbsp;
<span class="cpp__keyword">public</span>:&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cpp__keyword">virtual</span>&nbsp;<span class="cpp__datatype">BOOL</span>&nbsp;OnNewDocument();&nbsp;&nbsp;<span class="cpp__com">//&larr;[2]</span>&nbsp;
};</pre>
</div>
</div>
</div>
<p><strong>ファイル名: SmallDoc.cpp (既存修正)</strong></p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>C&#43;&#43;</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">スクリプトの編集</span>|<span class="pluginRemoveHolderLink">{#scriptcode_dlg.remove_script}</span></div>
<span class="hidden">cplusplus</span>

<div class="preview">
<pre id="codePreview" class="cplusplus">&nbsp;&nbsp;(略)&nbsp;
&nbsp;
<span class="cpp__datatype">BOOL</span>&nbsp;CSmallDoc::OnNewDocument()&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cpp__com">//&larr;[3]</span>&nbsp;
{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cpp__keyword">if</span>&nbsp;(!CDocument::OnNewDocument())&nbsp;&nbsp;<span class="cpp__com">//&larr;[4]</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cpp__keyword">return</span>&nbsp;FALSE;&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;m_nData&nbsp;=&nbsp;<span class="cpp__number">100</span>;&nbsp;&nbsp;<span class="cpp__com">//&larr;[5]</span>&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cpp__keyword">return</span>&nbsp;TRUE;&nbsp;&nbsp;<span class="cpp__com">//&larr;[6]</span>&nbsp;
}</pre>
</div>
</div>
</div>
<p><strong>ファイル名: SmallView.h (既存修正)</strong></p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>C&#43;&#43;</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">スクリプトの編集</span>|<span class="pluginRemoveHolderLink">{#scriptcode_dlg.remove_script}</span></div>
<span class="hidden">cplusplus</span>

<div class="preview">
<pre id="codePreview" class="cplusplus"><span class="cpp__preproc">#pragma&nbsp;once</span><span class="cpp__preproc">&nbsp;
&nbsp;
#include&nbsp;&quot;resource.h&quot;</span>&nbsp;
&nbsp;
<span class="cpp__keyword">class</span>&nbsp;CSmallView&nbsp;:&nbsp;<span class="cpp__keyword">public</span>&nbsp;CView&nbsp;
{&nbsp;
<span class="cpp__keyword">protected</span>:&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;CSmallView();&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;DECLARE_DYNCREATE(CSmallView)&nbsp;
<span class="cpp__keyword">public</span>:&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;CSmallDoc*&nbsp;GetDocument();&nbsp;
<span class="cpp__keyword">public</span>:&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cpp__keyword">virtual</span>&nbsp;<span class="cpp__keyword">void</span>&nbsp;OnInitialUpdate();&nbsp;&nbsp;<span class="cpp__com">//&larr;[9]</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cpp__keyword">virtual</span>&nbsp;<span class="cpp__keyword">void</span>&nbsp;OnDraw(CDC*&nbsp;pDC);&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;(略)</pre>
</div>
</div>
</div>
<p><strong>ファイル名: SmallView.cpp (既存修正)</strong></p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>C&#43;&#43;</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">スクリプトの編集</span>|<span class="pluginRemoveHolderLink">{#scriptcode_dlg.remove_script}</span></div>
<span class="hidden">cplusplus</span>

<div class="preview">
<pre id="codePreview" class="cplusplus">&nbsp;&nbsp;&nbsp;&nbsp;(略)&nbsp;
&nbsp;
<span class="cpp__keyword">void</span>&nbsp;CSmallView::OnInitialUpdate()&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cpp__com">//&larr;[10]</span>&nbsp;
{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;CSmallDoc*&nbsp;pDoc&nbsp;=&nbsp;GetDocument();&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cpp__com">//&larr;[11]</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;CString&nbsp;str;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;str.Format(&nbsp;_T(<span class="cpp__string">&quot;%d&quot;</span>),&nbsp;pDoc-&gt;m_nData);&nbsp;&nbsp;<span class="cpp__com">//&larr;[12]</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;m_ctlEdit1.SetWindowTextW(str);&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cpp__com">//&larr;[13]</span>&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;CView::OnInitialUpdate();&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cpp__com">//&larr;[14]</span>&nbsp;
}</pre>
</div>
</div>
</div>
<p>EDIT コントロールに入力された数値を記憶するために、[1] のように、ドキュメント クラスにメンバー変数 m_nData を用意しました。ここでは簡単にするため、パブリック変数にして、ビュー クラスからアクセスできるようにします。</p>
<p>新規作成時にドキュメントの初期化を行うために、[2] と [3] のように、OnNewDocument 関数をオーバーライドします。</p>
<p>[3] の関数内部では、[4] のように基本クラスの OnNewDocument 関数を呼び出します。基本クラスの OnNewDocument 関数では、ドキュメントが変更された否かの判別に利用できるダーティ フラグの初期化など、ドキュメントの標準的な初期化を行うので、この呼び出しが必要です。また、ここでは [5] のように、初期値として 100 を設定しました。最後に [6] のように、初期化が正常終了したとして、戻り値に TRUE を返します。これで、ビュー クラスの OnInitialUpdate
 関数が呼び出されます。</p>
<p>ビュー クラスでは、[9] や [10] のように、OnInitialUpdate 関数をオーバーライドします。</p>
<p>[10] の OnInitialUpdate 関数の中では、ドキュメントの内容を EDIT コントロールに反映する必要があるので、[11] のように GetDocument 関数を呼び出して、ドキュメントのポインターを取得します。</p>
<p>先に触れたように、OnInitialUpdate 関数の時点ではドキュメントの初期化は完了しているので、ドキュメントには適切な初期値が既に&#26684;納されています。なお、GetDocument 関数は、前回作成したメンバー関数です。</p>
<p>そして、[12] ではドキュメントの m_nData メンバー変数 (pDoc-&gt;m_nData) を参照し、文字列に変換しています。[13] では、変換結果の文字列を EDIT コントロールに表示すべく設定しています。</p>
<p>また、既に説明したように、[14] の基本クラスの OnInitialUpdate 関数の内部では、最終的に OnDraw 関数が呼び出され、クライアント領域に対する描画コードが実行されます (のちほど、この仕組みを利用します)。</p>
<p>なお、[10] の OnInitialUpdate 関数の中で、[14] の基本クラスの同名関数を呼び出す処理と、その他の初期処理 (ここでは [11] から [13]) とでは、どちらを先に実行すべきでしょうか。この点は初期化の内容に依存します。ここでは、[11] から [13] までの処理と [14] の処理とは、お互いに依存してないので、どちらが先でも問題ありません。</p>
<p>ここで実行してみましょう。ドキュメントの初期値が反映され、起動直後の EDIT コントロールには、「100」と表示されます。</p>
<p><img src="http://i1.code.msdn.s-msft.com/visualc-23226768/image/file/25251/1/img07_08.gif" alt="図 7.8" width="560" height="393"></p>
<p><strong>図 7.8 初期化されたドキュメントを反映する</strong></p>
<p><a href="#top" target="_self"><img src="http://www.microsoft.com/japan/msdn/nodehomes/graphics/top.gif" border="0" alt="">ページのトップへ</a></p>
<hr>
<h2 id="08" style="font-size:120%; margin-top:20px">8. 基本的なビューの描画の流れ</h2>
<p>次に、ビューに描画を行うコードを追加しましょう。既に触れたように、ビューのクライアント領域への描画は、OnDraw メンバー関数の中で実装します。この関数が呼び出される主な実行の流れは、次図のようになります。</p>
<p><img src="http://i1.code.msdn.s-msft.com/visualc-23226768/image/file/25252/1/img07_09.gif" alt="図 7.9" width="600" height="418"></p>
<p><strong>図 7.9 基本的なビューの描画の流れ</strong></p>
<p>ビューの描画内容を更新するには、ビュー クラスのメンバー関数である (2) の OnUpdate 関数を呼び出す必要があります。この関数を呼び出す典型的なタイミングのとしては、(1) に挙げた 2 つの関数からの呼び出しです。この 2 つの関数は、それぞれ基本クラス CView、および CDocument に実装されています。前述の例 7.4 でも、CSmallView::OnInitialUpdate 関数の中から、CView::OnInitialUpdate 関数を呼び出すことで、ビューを更新できるように実装しました。</p>
<p>この一連の更新の中で、プログラマーがオーバーライドして独自に実装する可能性があるのは●印の関数であり、必ず実装する関数は (8) の OnDraw 関数です (前回触れたように、OnDraw 関数は純粋仮想関数なのでプログラマーが実装する必要があります)。</p>
<p>ここで、描画の流れを順番に確認しましょう。OnUpdate 関数は、クライアント領域を無効化する役割を持ち、無効化によって、Windows OS は (3) のように WM_PAINT メッセージを送り、 (4) の OnPaint メッセージ ハンドラーが呼び出されます。</p>
<p>(2) の OnUpdate 関数の既定実装では、ビューのクライアント領域全体を無効化し、背景全体も描画するよう Windows OS へ通知するようになっています。この OnUpdate 関数をオーバーライドすれば、特定領域を無効化して再描画させるなど、描画すべき領域を最適化する機会がプログラマーに与えられています。</p>
<p>(4) の OnPaint メッセージ ハンドラーについては、標準実装をそのまま使うことが多いでしょう。OnPaint 関数の中では (5) や (7) のように、OnPrepareDC 関数と OnDraw 関数を順に呼び出します。</p>
<p>(6) の OnPrepareDC 関数では、これから描画に使用するデバイス コンテキストについて、修正を行うことができます。たとえば、原点座標の移動などです。</p>
<p>そして、デバイス コンテキストの修正ののち、(8) の OnDraw 関数が呼び出され、クライアント領域にコンテンツが描画されます。</p>
<p>なお、実行中に、何らかの理由でドキュメント オブジェクトの内容が変更になった場合、それに連動してビューも更新する必要があります。そのために利用するのが、図 7.9 の (1) に挙げたもう 1 つの関数である CDocument::UpdateAllViews 関数です。ドキュメントが更新された際に、ドキュメントのメンバー関数である UpdateAllViews 関数を呼び出すと、そのドキュメントに関連付いたすべてのビューに対して、図 7.9 の (2) にある OnUpdate 関数が呼び出されます。よって、ドキュメントに関連付いたすべてのビューを更新できます。</p>
<p>それでは、実際のサンプル コードで確認しましょう。</p>
<p><a href="#top" target="_self"><img src="http://www.microsoft.com/japan/msdn/nodehomes/graphics/top.gif" border="0" alt="">ページのトップへ</a></p>
<hr>
<h2 id="09" style="font-size:120%; margin-top:20px">9. ビューの描画、およびドキュメントの変更に伴うビューの更新</h2>
<p>ここでは、ドキュメントのデータ (m_nData メンバー変数) の値に基づいて、ビューに簡単なグラフを表示するように OnDraw 関数に実装します。また、ビュー上の EDIT コントロールの数値をユーザーが変更した場合、そのもとになったドキュメントのデータ (m_nData メンバー変数) も連動して変更し、この変更に呼応して、ビューのグラフも新しい値で表示するようにします。</p>
<p>ここでは、EDIT コントロールの値の変更に応じて、ドキュメントも更新する必要があるので、EDIT コントロールの値が変更したことに呼応して起動するイベント ハンドラーも実装します。</p>
<p><strong>例 7.5 ビューの描画、およびドキュメントの変更に伴うビューの更新</strong></p>
<p><strong>ファイル名: SmallView.h (既存修正) - 完成版</strong></p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>C&#43;&#43;</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">スクリプトの編集</span>|<span class="pluginRemoveHolderLink">{#scriptcode_dlg.remove_script}</span></div>
<span class="hidden">cplusplus</span>

<div class="preview">
<pre id="codePreview" class="cplusplus"><span class="cpp__com">//&nbsp;SmallView.h</span><span class="cpp__preproc">&nbsp;
#pragma&nbsp;once</span><span class="cpp__preproc">&nbsp;
&nbsp;
#include&nbsp;&quot;resource.h&quot;</span>&nbsp;
&nbsp;
<span class="cpp__keyword">class</span>&nbsp;CSmallView&nbsp;:&nbsp;<span class="cpp__keyword">public</span>&nbsp;CView&nbsp;
{&nbsp;
<span class="cpp__keyword">protected</span>:&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;CSmallView();&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;DECLARE_DYNCREATE(CSmallView)&nbsp;
<span class="cpp__keyword">public</span>:&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;CSmallDoc*&nbsp;GetDocument();&nbsp;
<span class="cpp__keyword">public</span>:&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cpp__keyword">virtual</span>&nbsp;<span class="cpp__keyword">void</span>&nbsp;OnInitialUpdate();&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cpp__keyword">virtual</span>&nbsp;<span class="cpp__keyword">void</span>&nbsp;OnDraw(CDC*&nbsp;pDC);&nbsp;
<span class="cpp__keyword">protected</span>:&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cpp__com">//&nbsp;EDITコントロール</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;CEdit&nbsp;m_ctlEdit1;&nbsp;
<span class="cpp__keyword">protected</span>:&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cpp__com">//&nbsp;WM_CREATEのメッセージ&nbsp;ハンドラー関数</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;afx_msg&nbsp;<span class="cpp__datatype">int</span>&nbsp;OnCreate(LPCREATESTRUCT&nbsp;lpCreateStruct);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cpp__com">//&nbsp;EN_CHANGEのメッセージ&nbsp;ハンドラー関数</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;afx_msg&nbsp;<span class="cpp__keyword">void</span>&nbsp;OnChangeEdit1();&nbsp;&nbsp;&nbsp;<span class="cpp__com">//&larr;[15]</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;DECLARE_MESSAGE_MAP()&nbsp;
};</pre>
</div>
</div>
</div>
<p><strong>ファイル名: SmallView.cpp (既存修正) - 完成版</strong></p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>C&#43;&#43;</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">スクリプトの編集</span>|<span class="pluginRemoveHolderLink">{#scriptcode_dlg.remove_script}</span></div>
<span class="hidden">cplusplus</span>

<div class="preview">
<pre id="codePreview" class="cplusplus"><span class="cpp__com">//&nbsp;SmallView.cpp</span><span class="cpp__preproc">&nbsp;
#include&nbsp;&quot;stdafx.h&quot;</span><span class="cpp__preproc">&nbsp;
#include&nbsp;&quot;SmallDoc.h&quot;</span><span class="cpp__preproc">&nbsp;
#include&nbsp;&quot;SmallView.h&quot;</span>&nbsp;
&nbsp;
IMPLEMENT_DYNCREATE(&nbsp;CSmallView,&nbsp;CView&nbsp;)&nbsp;
&nbsp;
CSmallView::CSmallView()&nbsp;
{&nbsp;
}&nbsp;
&nbsp;
CSmallDoc*&nbsp;CSmallView::GetDocument()&nbsp;
{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cpp__keyword">return</span>&nbsp;(CSmallDoc*)&nbsp;m_pDocument;&nbsp;
}&nbsp;
&nbsp;
<span class="cpp__keyword">void</span>&nbsp;CSmallView::OnDraw(CDC*&nbsp;pDC)&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cpp__com">//&larr;[16]</span>&nbsp;
{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;CSmallDoc*&nbsp;pDoc&nbsp;=&nbsp;GetDocument();&nbsp;&nbsp;<span class="cpp__com">//&larr;[17]</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cpp__datatype">int</span>&nbsp;value&nbsp;=&nbsp;pDoc-&gt;m_nData;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cpp__com">//&larr;[18]</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;CBrush&nbsp;brush(RGB(<span class="cpp__number">0</span>,<span class="cpp__number">0</span>,<span class="cpp__number">255</span>));&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cpp__com">//&larr;[19]</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;pDC-&gt;FillRect(CRect(<span class="cpp__number">10</span>,<span class="cpp__number">50</span>,<span class="cpp__number">10</span>&#43;value,<span class="cpp__number">80</span>),&nbsp;&amp;brush);&nbsp;&nbsp;<span class="cpp__com">//&larr;[20]</span>&nbsp;
}&nbsp;
&nbsp;
BEGIN_MESSAGE_MAP(CSmallView,&nbsp;CView)&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;ON_WM_CREATE()&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;ON_EN_CHANGE(IDC_EDIT1,&nbsp;&amp;CSmallView::OnChangeEdit1)&nbsp;&nbsp;<span class="cpp__com">//&larr;[21]</span>&nbsp;
END_MESSAGE_MAP()&nbsp;
&nbsp;
<span class="cpp__datatype">int</span>&nbsp;CSmallView::OnCreate(LPCREATESTRUCT&nbsp;lpCreateStruct)&nbsp;
{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cpp__keyword">if</span>&nbsp;(CView::OnCreate(lpCreateStruct)&nbsp;==&nbsp;-<span class="cpp__number">1</span>)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cpp__keyword">return</span>&nbsp;-<span class="cpp__number">1</span>;&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;m_ctlEdit1.Create(&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;ES_NUMBER&nbsp;|&nbsp;ES_RIGHT&nbsp;|&nbsp;WS_CHILD&nbsp;|&nbsp;WS_VISIBLE&nbsp;|&nbsp;WS_BORDER,&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;CRect(<span class="cpp__number">10</span>,<span class="cpp__number">10</span>,<span class="cpp__number">110</span>,<span class="cpp__number">36</span>),&nbsp;<span class="cpp__keyword">this</span>,&nbsp;IDC_EDIT1);&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cpp__keyword">return</span>&nbsp;<span class="cpp__number">0</span>;&nbsp;
}&nbsp;
&nbsp;
<span class="cpp__keyword">void</span>&nbsp;CSmallView::OnInitialUpdate()&nbsp;
{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;CSmallDoc*&nbsp;pDoc&nbsp;=&nbsp;GetDocument();&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;CString&nbsp;str;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;str.Format(&nbsp;_T(<span class="cpp__string">&quot;%d&quot;</span>),&nbsp;pDoc-&gt;m_nData);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;m_ctlEdit1.SetWindowTextW(str);&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;CView::OnInitialUpdate();&nbsp;
}&nbsp;
&nbsp;
<span class="cpp__keyword">void</span>&nbsp;CSmallView::OnChangeEdit1()&nbsp;&nbsp;<span class="cpp__com">//&larr;[22]</span>&nbsp;
{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;CSmallDoc*&nbsp;pDoc&nbsp;=&nbsp;GetDocument();&nbsp;&nbsp;<span class="cpp__com">//&larr;[23]</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;CString&nbsp;text;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;m_ctlEdit1.GetWindowTextW(text);&nbsp;&nbsp;<span class="cpp__com">//&larr;[24]</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cpp__datatype">int</span>&nbsp;value&nbsp;=&nbsp;::_wtoi(text);&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cpp__com">//&larr;[25]</span>&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;pDoc-&gt;m_nData&nbsp;=&nbsp;value;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cpp__com">//&larr;[26]</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;pDoc-&gt;UpdateAllViews(NULL);&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cpp__com">//&larr;[27]</span>&nbsp;
}</pre>
</div>
</div>
</div>
<p>例 7.5 のビュー クラスの修正を図 7.9 に当てはめてみた場合、OnDraw 関数は固有の実装を記述しましたが、それ以外の関数 (OnUpdate、OnPaint、および OnPrepareDC) は既存の実装をそのまま使用しています。</p>
<p>OnDraw 関数は、[16] にあります (前回に定義したものです)。この関数の引数 pDC はビューのクライアント領域に対するデバイス コンテキストであり、これを利用すれば、クライアント領域に描画することができます。</p>
<p>典型的な OnDraw 関数の実装としては、この時点のドキュメントに基づいて描画することです。[17] のように GetDocument 関数を呼び出して、ドキュメントのポインターを取得します。さらに、[18] でドキュメントのデータ (m_nData メンバー変数) を参照して、変数 value に退避し、この情報をもとに、[19] と [20] で横長の青色の帯グラフを表示します。ここでは、変数 value の値だけ、横に帯が長くなります (ピクセル単位)。</p>
<p>この OnDraw 関数は、ビューの初回表示の際にも呼び出されます。つまり、図 7.9 の流れに当てはめると、例 7.4 末尾のビュー クラスの OnInitialUpdate 関数の中から、[14] のように基本クラスの CView::OnInitialUpdate を呼び出すと、最終的には OnDraw 関数が呼び出され、ビューのクライアント領域に描画することになります。</p>
<p>このほか、EDIT コントロールの内容がユーザーによって変更された場合に、連動してドキュメントを変更するため、[15] および [22] のとおり、EN_CHANGE メッセージ用のハンドラーを用意しました。また、ハンドラーとして定義するために、[21] のようにメッセージ マップ マクロを 1 つ追加しました。</p>
<p>メッセージ ハンドラーである [22] の OnChangeEdit1 関数の内部では、[23] のようにドキュメントのポインターを取得したのち、[24] で EDIT コントロール内の最新のデータ (文字列) を取得し、[25] で整数に変換します。そして、最新のデータをドキュメントに反映すべく、[26] では、ドキュメントの m_nData メンバー変数に退避しています。そして、最後に [27] のように UpDateAllViews 関数を呼び出すことで、図 7.9 の流れに従って、ドキュメントに紐づいたすべてのビューの
 OnUpdate 関数が呼び出され、最終的には、OnDraw 関数が呼び出されて、最新のデータをもとにグラフが再描画されます。</p>
<p>それでは、実行してみましょう。</p>
<p>起動すると、EDIT コントロールには「100」が表示され、相応の幅のグラフが表示されます。</p>
<p><img src="http://i1.code.msdn.s-msft.com/visualc-23226768/image/file/25253/1/img07_10.gif" alt="図 7.10" width="580" height="275"></p>
<p><strong>図 7.10 初期値 100 に相当するグラフを表示</strong></p>
<p>先述のとおり、この時点では、CSmallView ビュー クラスの OnInitialUpdate 関数内部から、基本クラスの CView::OnInitialUpdate 関数を呼び出すことで、間接的に OnDraw 関数が呼び出されて、グラフを描画しています。</p>
<p>次に、EDIT コントロールの値を「200」に変更すると、次図のように、それに連動してグラフも変化します。(正確に言えば、EDIT コントロールの値を 1 文字修正するごとに、グラフは変動します。) EDIT コントロールの値の変更に伴って、例 7.5 の [22] のハンドラーが呼び出され、さらにハンドラーの中から、UpdateAllViews 関数呼び出しによって更新されたからです。</p>
<p><img src="http://i1.code.msdn.s-msft.com/visualc-23226768/image/file/25254/1/img07_11.gif" alt="図 7.11" width="580" height="172"></p>
<p><strong>図 7.11 値 200 に連動してグラフが変換</strong></p>
<p><a href="#top" target="_self"><img src="http://www.microsoft.com/japan/msdn/nodehomes/graphics/top.gif" border="0" alt="">ページのトップへ</a></p>
<hr>
<h2 id="10" style="font-size:120%; margin-top:20px">10. ドキュメントの保存と読み込み</h2>
<p>最後に、ドキュメントをディスクにファイルとして保存する方法 (シリアル化) と、ファイルからドキュメントへ読み込む方法 (逆シリアル化) について確認しておきましょう。</p>
<p>MFC ライブラリでは、ユーザーがファイルの保存操作や開く操作を行うと、必要に応じて、ドキュメント クラスの Serialize 関数が呼び出されるようになっています。たとえば、[名前を付けて保存] コマンドや [開く] コマンドの典型的な流れは、次のようになります。</p>
<p><img src="http://i1.code.msdn.s-msft.com/visualc-23226768/image/file/25255/1/img07_12.gif" alt="図 7.12" width="600" height="399"></p>
<p><strong>図 7.12 保存操作 (名前を付けて保存)</strong></p>
<p><img src="http://i1.code.msdn.s-msft.com/visualc-23226768/image/file/25256/1/img07_13.gif" alt="図 7.13" width="600" height="455"></p>
<p><strong>図 7.13 読み込み操作 (開く)</strong></p>
<p>図 7.12 の中では、ドキュメント クラスのデータを保存する上で、プログラマーが最低限実装する必要があるのは (4) の Serialize 関数だけです。</p>
<p>図 7.12 の (1) の [名前を付けて保存] コマンド ハンドラーである OnFileSaveAs 関数は既に実装されています。また、保存ダイアログを表示する (2) の DoSave 関数も実装されています。そして、DoSave 関数で取得したファイル名は、実装済みの (3) の OnSaveDocument 関数に渡されます。この OnSaveDocument 関数の内部では、ファイルがオープンされ、そのファイルに保存するための CArchive オブジェクトが作られます。そして、プログラマーは、(4)
 の Serialize 関数の引数として CArchive オブジェクトを受け取り、シリアル化に必要なコードを記述します。</p>
<p>また、ファイルを開いて、ファイルからドキュメントに読み込む流れが図 7.13 です。この流れは、新規作成時の図 7.6 に&#20284;ており、特に 3 種類のクラス (ドキュメント、ビュー、子フレーム) に関する違いは、ドキュメント クラスの OnNewDocument 関数の代わりに、図 7.13 の (10) の OnOpenDocument 関数が使用されている点です。</p>
<p>データを読み込む流れだけをとらえると、(1) で [開く] コマンド ハンドラーが起動したのち、(2)、(10)、(11) と処理が進みます。この流れの中で、プログラマーが最低限実装する必要があるのは、やはり (11) の Serialize 関数だけです。</p>
<p>(10) の OnOpenDocument 関数内部で、ファイルがオープンされて CArchive オブジェクトが作成されると、(11) の Serialize 関数では、CArchive オブジェクトを受け取るので、プログラマーは CArchive オブジェクトから必要なデータを取り出すコードを記述します。そして、Serialize 関数の処理が終わると、この時点でドキュメントの構築が完了するので、(12) の OnInitialUpdate 関数が呼び出され、ビューへの描画が開始します。</p>
<p>それでは、ここで Serialize 関数をドキュメント クラスに追加してみましょう。</p>
<p><strong>例 7.6 ドキュメントのシリアル化と逆シリアル化</strong></p>
<p><strong>ファイル名: SmallDoc.h (既存修正) - 完成版</strong></p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>C&#43;&#43;</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">スクリプトの編集</span>|<span class="pluginRemoveHolderLink">{#scriptcode_dlg.remove_script}</span></div>
<span class="hidden">cplusplus</span>

<div class="preview">
<pre id="codePreview" class="cplusplus"><span class="cpp__preproc">#pragma&nbsp;once</span>&nbsp;
<span class="cpp__keyword">class</span>&nbsp;CSmallDoc&nbsp;:&nbsp;<span class="cpp__keyword">public</span>&nbsp;CDocument&nbsp;
{&nbsp;
<span class="cpp__keyword">protected</span>:&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;CSmallDoc();&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;DECLARE_DYNCREATE(CSmallDoc)&nbsp;
<span class="cpp__keyword">public</span>:&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cpp__datatype">int</span>&nbsp;m_nData;&nbsp;
<span class="cpp__keyword">public</span>:&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cpp__keyword">virtual</span>&nbsp;<span class="cpp__datatype">BOOL</span>&nbsp;OnNewDocument();&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cpp__keyword">virtual</span>&nbsp;<span class="cpp__keyword">void</span>&nbsp;Serialize(CArchive&amp;&nbsp;ar);&nbsp;&nbsp;&nbsp;<span class="cpp__com">//&larr;[7]</span>&nbsp;
};</pre>
</div>
</div>
</div>
<p><strong>ファイル名: SmallDoc.cpp (既存修正) - 完成版</strong></p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>C&#43;&#43;</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">スクリプトの編集</span>|<span class="pluginRemoveHolderLink">{#scriptcode_dlg.remove_script}</span></div>
<span class="hidden">cplusplus</span>

<div class="preview">
<pre id="codePreview" class="cplusplus"><span class="cpp__com">//&nbsp;SmallDoc.cpp</span><span class="cpp__preproc">&nbsp;
#include&nbsp;&quot;stdafx.h&quot;</span><span class="cpp__preproc">&nbsp;
#include&nbsp;&quot;SmallDoc.h&quot;</span>&nbsp;
&nbsp;
IMPLEMENT_DYNCREATE(&nbsp;CSmallDoc,&nbsp;CDocument&nbsp;)&nbsp;
&nbsp;
CSmallDoc::CSmallDoc()&nbsp;
{&nbsp;
}&nbsp;
&nbsp;
<span class="cpp__datatype">BOOL</span>&nbsp;CSmallDoc::OnNewDocument()&nbsp;
{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cpp__keyword">if</span>&nbsp;(!CDocument::OnNewDocument())&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cpp__keyword">return</span>&nbsp;FALSE;&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;m_nData&nbsp;=&nbsp;<span class="cpp__number">100</span>;&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cpp__keyword">return</span>&nbsp;TRUE;&nbsp;
}&nbsp;
&nbsp;
<span class="cpp__keyword">void</span>&nbsp;CSmallDoc::Serialize(CArchive&amp;&nbsp;ar)&nbsp;&nbsp;<span class="cpp__com">//&larr;[8]</span>&nbsp;
{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cpp__keyword">if</span>&nbsp;(ar.IsStoring())&nbsp;&nbsp;<span class="cpp__com">//&larr;[9]</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;ar&nbsp;&lt;&lt;&nbsp;m_nData;&nbsp;&nbsp;&nbsp;<span class="cpp__com">//&larr;[10]</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cpp__keyword">else</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;ar&nbsp;&gt;&gt;&nbsp;m_nData;&nbsp;&nbsp;&nbsp;<span class="cpp__com">//&larr;[11]</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
}</pre>
</div>
</div>
</div>
<p>[7] および [8] のように、Serialize 関数をオーバーライドします。ここでは、ドキュメント クラスのメンバー変数である m_nData の保存と読み込みを行うことにします。</p>
<p>この Serialize 関数は、保存時と読み込み時の両方に呼び出されるので、[9] のように CArchive オブジェクトの IsStoring 関数の値を調べて、TRUE ならば保存なので、[10] のように演算子「&lt;&lt;」を使用して、CArchive オブジェクトに保存します。FALSE ならば、[11] のように演算子「&gt;&gt;」を使用して、データを取り出します。</p>
<p>次に、この Serialize 関数が呼び出されるように、メニュー コマンドも追加しましょう。</p>
<p><strong>例 7.7 メニューリソースの追加</strong></p>
<p><strong>ファイル名: SmallApp.rc (既存修正) - 完成版</strong></p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>C&#43;&#43;</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">スクリプトの編集</span>|<span class="pluginRemoveHolderLink">{#scriptcode_dlg.remove_script}</span></div>
<span class="hidden">cplusplus</span>

<div class="preview">
<pre id="codePreview" class="cplusplus"><span class="cpp__preproc">#include&nbsp;&quot;resource.h&quot;</span><span class="cpp__preproc">&nbsp;
#include&nbsp;&lt;afxres.h&gt;</span>&nbsp;
&nbsp;
<span class="cpp__com">//IDR_MAINFRAME&nbsp;ICON&nbsp;&quot;SmallApp.ico&quot;</span>&nbsp;
&nbsp;
STRINGTABLE&nbsp;
BEGIN&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;IDR_MAINFRAME&nbsp;<span class="cpp__string">&quot;Small&nbsp;Application&quot;</span>&nbsp;
END&nbsp;
&nbsp;
IDR_MAINFRAME&nbsp;MENU&nbsp;&nbsp;<span class="cpp__com">//&larr;[1]</span>&nbsp;
BEGIN&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;POPUP&nbsp;<span class="cpp__string">&quot;ファイル(&amp;F)&quot;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;BEGIN&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;MENUITEM&nbsp;<span class="cpp__string">&quot;新規作成(&amp;N)&quot;</span>,&nbsp;ID_FILE_NEW&nbsp;&nbsp;&nbsp;<span class="cpp__com">//&larr;[3]</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;MENUITEM&nbsp;<span class="cpp__string">&quot;開く(&amp;O)&quot;</span>,&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;ID_FILE_OPEN&nbsp;&nbsp;<span class="cpp__com">//&larr;[4]</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;MENUITEM&nbsp;SEPARATOR&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cpp__com">//&larr;[5]</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;MENUITEM&nbsp;<span class="cpp__string">&quot;アプリケーションの終了(&amp;X)&quot;</span>,&nbsp;&nbsp;ID_APP_EXIT&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;END&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;POPUP&nbsp;<span class="cpp__string">&quot;表示(&amp;W)&quot;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;BEGIN&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;MENUITEM&nbsp;<span class="cpp__string">&quot;項目&amp;1&quot;</span>,&nbsp;ID_VIEW_ITEM1&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;END&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;POPUP&nbsp;<span class="cpp__string">&quot;ヘルプ(&amp;H)&quot;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;BEGIN&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;MENUITEM&nbsp;<span class="cpp__string">&quot;バージョン情報(&amp;A)...&quot;</span>,&nbsp;ID_APP_ABOUT&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;END&nbsp;
END&nbsp;
&nbsp;
IDR_SMALLTEXTTYPE&nbsp;ICON&nbsp;<span class="cpp__string">&quot;SmallText.ico&quot;</span>&nbsp;
&nbsp;
STRINGTABLE&nbsp;
BEGIN&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cpp__com">//&nbsp;以下は1行で記述してください。</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;IDR_SMALLTEXTTYPE&nbsp;<span class="cpp__string">&quot;(dummy)\nSmallText\nSmall&nbsp;Text\nSmall&nbsp;Text&nbsp;(*.txt-sample)\n.txt-sample\nSmall.TextDoc.1\nSmallTextDoc\n&quot;</span>&nbsp;
END&nbsp;
&nbsp;
IDR_SMALLTEXTTYPE&nbsp;MENU&nbsp;&nbsp;<span class="cpp__com">//&larr;[2]</span>&nbsp;
BEGIN&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;POPUP&nbsp;<span class="cpp__string">&quot;ファイル(&amp;F)&quot;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;BEGIN&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;MENUITEM&nbsp;<span class="cpp__string">&quot;新規作成(&amp;N)&quot;</span>,&nbsp;ID_FILE_NEW&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cpp__com">//&larr;[6]</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;MENUITEM&nbsp;<span class="cpp__string">&quot;開く(&amp;O)&quot;</span>,&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;ID_FILE_OPEN&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cpp__com">//&larr;[7]</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;MENUITEM&nbsp;<span class="cpp__string">&quot;閉じる(&amp;C)&quot;</span>,&nbsp;&nbsp;&nbsp;ID_FILE_CLOSE&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cpp__com">//&larr;[8]</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;MENUITEM&nbsp;<span class="cpp__string">&quot;名前を付けて保存(&amp;A)...&quot;</span>,&nbsp;ID_FILE_SAVE_AS&nbsp;<span class="cpp__com">//&larr;[9]</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;MENUITEM&nbsp;SEPARATOR&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cpp__com">//&larr;[10]</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;MENUITEM&nbsp;<span class="cpp__string">&quot;アプリケーションの終了(&amp;X)&quot;</span>,&nbsp;&nbsp;ID_APP_EXIT&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;END&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;POPUP&nbsp;<span class="cpp__string">&quot;ヘルプ(&amp;H)&quot;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;BEGIN&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;MENUITEM&nbsp;<span class="cpp__string">&quot;バージョン情報(&amp;A)...&quot;</span>,&nbsp;ID_APP_ABOUT&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;END&nbsp;
END&nbsp;
&nbsp;
STRINGTABLE&nbsp;
BEGIN&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;AFX_IDS_IDLEMESSAGE&nbsp;<span class="cpp__string">&quot;レディ(SmallApp)&quot;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;ID_VIEW_ITEM1&nbsp;<span class="cpp__string">&quot;項目1を実行します。&quot;</span>&nbsp;
END</pre>
</div>
</div>
</div>
<p>子ウィンドウが閉じているときに使用される [1] のメニューと、子ウィンドウが開いているときに使用される [2] のメニューに、それぞれ、[3] と [4]、[7] と [9] の対応するメニュー項目を追加します。ついでに、新規作成コマンドの ID_FILE_NEW ([6]) と、閉じるコマンドの ID_FILE_CLOSE ([8]) も追加しました。</p>
<p>これらの標準的なメニュー コマンドは、既定でハンドラーがマップされているものもありますが、新規作成コマンドと開くコマンドについては、既定ではハンドラーがマッピングされていないので、アプリケーション クラスに次のメッセージ マップ ([1] から [4]) を追加します。</p>
<p><strong>例 7.8 メニュー コマンドのマップ</strong></p>
<p><strong>ファイル名: SmallApp.h (既存修正) - 完成版</strong></p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>C&#43;&#43;</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">スクリプトの編集</span>|<span class="pluginRemoveHolderLink">{#scriptcode_dlg.remove_script}</span></div>
<span class="hidden">cplusplus</span>

<div class="preview">
<pre id="codePreview" class="cplusplus"><span class="cpp__preproc">#pragma&nbsp;once</span><span class="cpp__preproc">&nbsp;
&nbsp;
#include&nbsp;&quot;resource.h&quot;</span>&nbsp;
&nbsp;
<span class="cpp__keyword">class</span>&nbsp;CSmallApp&nbsp;:&nbsp;<span class="cpp__keyword">public</span>&nbsp;CWinApp&nbsp;
{&nbsp;
<span class="cpp__keyword">public</span>:&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cpp__keyword">virtual</span>&nbsp;<span class="cpp__datatype">BOOL</span>&nbsp;InitInstance();&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;DECLARE_MESSAGE_MAP()&nbsp;&nbsp;<span class="cpp__com">//&larr;[1]</span>&nbsp;
};</pre>
</div>
</div>
</div>
<p><strong>ファイル名: SmallApp.cpp (既存修正) - 完成版</strong></p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>C&#43;&#43;</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">スクリプトの編集</span>|<span class="pluginRemoveHolderLink">{#scriptcode_dlg.remove_script}</span></div>
<span class="hidden">cplusplus</span>

<div class="preview">
<pre id="codePreview" class="cplusplus"><span class="cpp__com">//&nbsp;CSmallApp.cpp</span><span class="cpp__preproc">&nbsp;
#include&nbsp;&quot;stdafx.h&quot;</span><span class="cpp__preproc">&nbsp;
#include&nbsp;&quot;SmallApp.h&quot;</span><span class="cpp__preproc">&nbsp;
&nbsp;
#include&nbsp;&quot;MainFrm.h&quot;</span><span class="cpp__preproc">&nbsp;
&nbsp;
#include&nbsp;&quot;SmallDoc.h&quot;</span><span class="cpp__preproc">&nbsp;
#include&nbsp;&quot;SmallView.h&quot;</span><span class="cpp__preproc">&nbsp;
#include&nbsp;&quot;ChildFrm.h&quot;</span>&nbsp;
&nbsp;
BEGIN_MESSAGE_MAP(CSmallApp,&nbsp;CWinApp)&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cpp__com">//&larr;[2]</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;ON_COMMAND(ID_FILE_NEW,&nbsp;&amp;CWinApp::OnFileNew)&nbsp;&nbsp;&nbsp;&nbsp;<span class="cpp__com">//&larr;[3]</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;ON_COMMAND(ID_FILE_OPEN,&nbsp;&amp;CWinApp::OnFileOpen)&nbsp;&nbsp;<span class="cpp__com">//&larr;[4]</span>&nbsp;
END_MESSAGE_MAP()&nbsp;
&nbsp;
CSmallApp&nbsp;theApp;&nbsp;
&nbsp;
<span class="cpp__datatype">BOOL</span>&nbsp;CSmallApp::InitInstance()&nbsp;
{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;CWinApp::InitInstance();&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;CMultiDocTemplate*&nbsp;pTemplate;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;pTemplate&nbsp;=&nbsp;<span class="cpp__keyword">new</span>&nbsp;CMultiDocTemplate(&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;IDR_SMALLTEXTTYPE,&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;RUNTIME_CLASS(CSmallDoc),&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;RUNTIME_CLASS(CChildFrame),&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;RUNTIME_CLASS(CSmallView)&nbsp;);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cpp__keyword">if</span>(&nbsp;!pTemplate&nbsp;)&nbsp;<span class="cpp__keyword">return</span>&nbsp;FALSE;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;AddDocTemplate(pTemplate);&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cpp__com">//ここでメインのフレームウィンドウを作成する</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;CMainFrame*&nbsp;pMainFrame&nbsp;=&nbsp;<span class="cpp__keyword">new</span>&nbsp;CMainFrame();&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;pMainFrame-&gt;LoadFrame(&nbsp;IDR_MAINFRAME&nbsp;);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;pMainFrame-&gt;ShowWindow(&nbsp;m_nCmdShow&nbsp;);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;pMainFrame-&gt;UpdateWindow();&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;m_pMainWnd&nbsp;=&nbsp;pMainFrame;&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;OnFileNew();&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cpp__keyword">return</span>&nbsp;TRUE;&nbsp;
}</pre>
</div>
</div>
</div>
<p>これで完成です。この時点で、サンプル コードが次のようになっているか確認しておきましょう。</p>
<ul>
<li>汎用的なヘッダー ---- (前回のまま、例 6.1) stdafx.h </li><li>アプリケーション クラス ---- 例 7.8 完成版 SmallApp.h、および SmallApp.cpp </li><li>フレーム ウィンドウ ---- 例 7.2 完成版 MainFrm.h および MainFrm.cpp </li><li>リソース ---- 例 7.3 完成版 resource.h、例 7.7 完成版 SmallApp.rc </li><li>アイコン ファイル ---- SmallApp.ico、SmallText.ico (いずれもオプション) </li><li>ドキュメント ---- 例 7.6 完成版 SmallDoc.h、SmallDoc.cpp </li><li>ビュー ---- 例 7.5 完成版 SmallView.h、SmallView.cpp </li><li>子フレーム ---- (前回のまま、例 6.6) ChildFrm.h、および ChildFrm.cpp </li></ul>
<p>念のため、前回から変更がなかった分を以下に掲載しておきます。</p>
<p><strong>例 7.9 前回から変更がない分</strong></p>
<p><strong>ファイル名: stdafx.h (変更なし)</strong></p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>C&#43;&#43;</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">スクリプトの編集</span>|<span class="pluginRemoveHolderLink">{#scriptcode_dlg.remove_script}</span></div>
<span class="hidden">cplusplus</span>

<div class="preview">
<pre id="codePreview" class="cplusplus"><span class="cpp__preproc">#pragma&nbsp;once</span><span class="cpp__preproc">&nbsp;
&nbsp;
#define&nbsp;_WIN32_WINNT&nbsp;0x0601</span><span class="cpp__preproc">&nbsp;
&nbsp;
#include&nbsp;&lt;afxwin.h&gt;</span><span class="cpp__preproc">&nbsp;
#include&nbsp;&lt;afxext.h&gt;</span></pre>
</div>
</div>
</div>
<p><strong>ファイル名: ChildFrm.h (変更なし)</strong></p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>C&#43;&#43;</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">スクリプトの編集</span>|<span class="pluginRemoveHolderLink">{#scriptcode_dlg.remove_script}</span></div>
<span class="hidden">cplusplus</span>

<div class="preview">
<pre id="codePreview" class="cplusplus"><span class="cpp__preproc">#pragma&nbsp;once</span>&nbsp;
<span class="cpp__keyword">class</span>&nbsp;CChildFrame&nbsp;:&nbsp;<span class="cpp__keyword">public</span>&nbsp;CMDIChildWnd&nbsp;
{&nbsp;
<span class="cpp__keyword">protected</span>:&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;CChildFrame();&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;DECLARE_DYNCREATE(CChildFrame)&nbsp;
};</pre>
</div>
</div>
</div>
<p><strong>ファイル名: ChildFrm.cpp (変更なし)</strong></p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>C&#43;&#43;</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">スクリプトの編集</span>|<span class="pluginRemoveHolderLink">{#scriptcode_dlg.remove_script}</span></div>
<span class="hidden">cplusplus</span>

<div class="preview">
<pre id="codePreview" class="cplusplus"><span class="cpp__preproc">#include&nbsp;&quot;stdafx.h&quot;</span><span class="cpp__preproc">&nbsp;
#include&nbsp;&quot;ChildFrm.h&quot;</span>&nbsp;
&nbsp;
IMPLEMENT_DYNCREATE(&nbsp;CChildFrame,&nbsp;CMDIChildWnd&nbsp;)&nbsp;
&nbsp;
CChildFrame::CChildFrame()&nbsp;
{&nbsp;
}</pre>
</div>
</div>
</div>
<p>それでは実行してみましょう。</p>
<p>起動すると、今までと同様、図 7.10 のように初期値 100 の状態で、子ウィンドウが開きます。次に、EDIT コントロールの値を 200 に変更して、図 7.11 の状態にします。</p>
<p>ここで、[ファイル] メニューの [名前を付けて保存] をクリックします。すると、次図のように保存ダイアログ ボックスが表示されます。</p>
<p><img src="http://i1.code.msdn.s-msft.com/visualc-23226768/image/file/25257/1/img07_14.jpg" alt="図 7.14" width="600" height="432"></p>
<p><strong>図 7.14 保存ダイアログ ボックス</strong></p>
<p>ファイル名の既定値や [ファイルの種類] ドロップダウン リストには、ドキュメント テンプレートに使用した文字列リソースが反映されています。ここで、適当な名前を付けて保存します。</p>
<p>一旦、アプリケーションを終了し、再び起動します。</p>
<p>今度は、[ファイル] メニューの [開く] をクリックして、開くダイアログ ボックスが表示されたら、直前に保存したファイルを指定して開きます。すると、EDIT コントロールの値が 200 の状態で開き、保存時の状態が復元されることが分かります。</p>
<p><img src="http://i1.code.msdn.s-msft.com/visualc-23226768/image/file/25258/1/img07_15.gif" alt="図 7.15" width="580" height="302"></p>
<p><strong>図 7.15 保存時の状態のドキュメントが復元される</strong></p>
<p>このほか、新規作成や閉じるなど、他のメニュー操作も確認してみてください。</p>
<p><a href="#top" target="_self"><img src="http://www.microsoft.com/japan/msdn/nodehomes/graphics/top.gif" border="0" alt="">ページのトップへ</a></p>
<hr>
<h2 id="11" style="font-size:120%; margin-top:20px">11. まとめ</h2>
<p>今回は 2 回に渡って、MFC のドキュメント/ビュー アーキテクチャに基づく、基本的な実装方法について確認しました。CWinApp 派生クラスや CFrameWnd 派生クラスを用いたウィンドウ 1 つの基本的なアプリケーションの実装方法のほか、ドキュメント/ビュー アーキテクチャの基本的な要素であるドキュメント テンプレートや、ドキュメント テンプレートによって管理されるドキュメント、ビュー、および子フレームの基本的な扱い方や、実行時の制御フローについて確認しました。</p>
<p>今回のサンプル プログラムで取り上げた事項は、MFC アプリケーション ウィザードによって生成できるコードのオプションの種類からすると、その一部にすぎませんが、様々なバリエーションの共通部分となる基本事項でもあるので、今後どんな実装について学ばれる場合も、その基礎として役立てて頂ければ幸いです。</p>
<hr style="clear:both; margin-bottom:8px; margin-top:20px">
<table>
<tbody>
<tr>
<td><a href="http://code.msdn.microsoft.com/ja-jp"><img src="http://i.msdn.microsoft.com/ff950935.coderecipe_180x70%28ja-jp,MSDN.10%29.jpg" border="0" alt="Code Recipe" width="180" height="70" style="margin-top:3px"></a></td>
<td><a href="http://msdn.microsoft.com/ja-jp/visualc/" target="_blank"><img src="http://i.msdn.microsoft.com/ff950935.VisualC_180x70(ja-jp,MSDN.10).gif" border="0" alt="Visual C&#43;&#43; デベロッパー センター" width="180" height="70" style="margin-top:3px"></a></td>
<td>
<ul>
<li>もっと他のコンテンツを見る &gt;&gt; <a href="http://msdn.microsoft.com/ja-jp/visualc/hh146885" target="_blank">
連載! とことん Visual C&#43;&#43; 一覧へ</a> </li><li>もっと他のレシピを見る &gt;&gt; <a href="http://code.msdn.microsoft.com/ja-jp">Code Recipe へ</a>
</li><li>もっと Visual C&#43;&#43; の情報を見る &gt;&gt; <a href="http://msdn.microsoft.com/ja-jp/visualc/" target="_blank">
Visual C&#43;&#43; デベロッパー センターへ</a> </li></ul>
</td>
</tr>
</tbody>
</table>
<p style="margin-top:20px"><a href="#top"><img src="http://www.microsoft.com/japan/msdn/nodehomes/graphics/top.gif" border="0" alt="">ページのトップへ</a></p>
