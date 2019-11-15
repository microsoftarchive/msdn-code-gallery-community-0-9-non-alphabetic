# [連載! とことん VC++] 第 10 回 ネイティブ VC++ におけるグラフィックス オーバービュー、および Direct2D の基本的な利用方法
## License
- Apache License, Version 2.0
## Technologies
- Visual Studio 2010
- Visual C++ 2010
## Topics
- Visual C++ プログラミング
- 連載! とことん VC++
## Updated
- 09/07/2011
## Description

<div id="top"></div>
<p>執筆者: <a href="http://msdn.microsoft.com/ja-jp/gg585574#yajima" target="_blank">
エディフィストラーニング株式会社 矢嶋 聡</a></p>
<hr>
<h2>目次</h2>
<ol>
<li><a href="#01">はじめに</a> </li><li><a href="#02">今回作成するサンプル アプリケーション</a> </li><li><a href="#03">Windows におけるグラフィック オーバービュー</a> </li><li><a href="#04">Direct2D 対応の開発環境の準備</a> </li><li><a href="#05">主なオブジェクトなどの基本構成</a> </li><li><a href="#06">デバイス非依存の初期化と後処理 ～COM、および Direct2D として～</a> </li><li><a href="#07">デバイス依存の初期化と後処理</a> </li><li><a href="#08">具体的な描画方法</a> </li><li><a href="#09">GDI との相互運用の準備</a> </li><li><a href="#10">HDC を介した相互運用</a> </li><li><a href="#11">まとめ</a> </li></ol>
<hr>
<h2 id="01" style="font-size:120%; margin-top:20px">1. はじめに</h2>
<p>この一連の連載の最終回である今回は、今までの連載のサンプル コードの中で何回か使用してきたグラフィックスに関する実装方法について、改めて取り上げます。</p>
<p>現在、Visual C&#43;&#43; などを用いてネイティブ コードのアプリケーションを開発する際に、グラフィックスを使用する場合、GDI や GDI&#43;、DirectX など、様々な実装テクノロジが選択肢として用意されています。今回は、それぞれのテクノロジの位置付けや特徴などを概観したのち、特に、Windows 7 から新たに標準装備された Direct2D に関して、API を用いた具体的なプログラミング方法について確認します。また、既存のソフトウェア資産を有効活用するためにも、従来の GDI と Direct2D
 を併用する相互運用の方法についても取り上げます。ただし、紙面の都合もあるので、API で使用するオブジェクトの個々のメンバー関数や引数の詳細について掘り下げるよりも、今後、Direct2D を利用する上で基礎となるように、主要なオブジェクトの特徴や手順のポイントなどに焦点を当てます。</p>
<p><a href="#top" target="_self"><img src="http://www.microsoft.com/japan/msdn/nodehomes/graphics/top.gif" border="0" alt="">ページのトップへ</a></p>
<hr>
<h2 id="02" style="font-size:120%; margin-top:20px">2. 今回作成するサンプル アプリケーション</h2>
<p>今回のサンプルでは、次の図 10.1 のように、一般的なネイティブ コードの Windows アプリケーションのウィンドウ上に、Direct2D を用いて図形を描画する方法を確認します。</p>
<p><img src="http://i1.code.msdn.s-msft.com/visualc-7e652493/image/file/42258/1/image001.jpg" alt="図 10.1" width="580" height="357"></p>
<p><strong>図 10.1 Direct2D による基本的な描画</strong></p>
<p>この例では、円の右上部に重ねた四角形は、半透明の状態で下の円が透けて見えるように合成した「アルファ ブレンディング」が使用されています。また、円の右下部に重ねた四角形も下の円が透けているほか、四角形自体の色が徐々に変化する「グラデーション」が用いられ、このグラデーションでは、上部のほうへ行くほど透明度が無くなり、円の輪郭が見えづらくなっています。このほか、円の枠線は、「ベクター グラフィック」が使用されており、しかも、「アンチエイリアス」と呼ばれる機能によって、輪郭が滑らかになるように補正されています。この図形の描画を題材に、Direct2D
 の基本的な手順を確認します。</p>
<p>また、記事の後半では次の図 10.2 のように、1 つのウィンドウの中で、従来の GDI を用いた描画と併せて、Direct2D による描画を行う方法についても確認します。このウィンドウの左上の文字列と左側の円は、従来の GDI を用いて描画したものであり、右半分は Direct2D で描画した図形です。既存の GDI ベースのソフトウェア資産に、部分的に Direct2D を併用する場合などは、このような手法を用いることになるでしょう。</p>
<p><img src="http://i1.code.msdn.s-msft.com/visualc-7e652493/image/file/42259/1/image002.jpg" alt="図 10.2" width="580" height="357"></p>
<p><strong>図 10.2 従来の GDI による描画との併用</strong></p>
<div style="margin:10px 0px; padding:10px 10px 0px 10px; border:double 1px #CCCCCC">
<p style="margin:0"><strong>Note:</strong></p>
<p>今回のサンプル プログラムの実行環境には Direct2D が必要です。Windows 7 および Windows Server 2008 R2 では Direct2D が標準装備されているので、そのまま実行できます。また、Windows Vista SP2 や Windows Server 2008 SP2 では、プラットフォーム更新プログラムをインストールすることで、Direct2D もインストールされます。</p>
<p>開発環境としては、Visual C&#43;&#43; 2010 Express (または上位エディション) をインストールすれば、Direct2D 関連のヘッダー ファイルやインポート ライブラリもインストールされるので、このサンプルを作成することができます。このあとのサンプルの作成手順の説明では、Visual C&#43;&#43; 2010 Express を前提にしています。今回も、サンプルを机上でも理解できるように、サンプル固有の実装部分を一通り掲載していますが、環境があれば試しに作成してみてください。</p>
<p>なお、Direct2D 対応の開発環境自体は、Visual C&#43;&#43; 2008 と Windows SDK 7.0 を併用する方法でも実現できます。</p>
</div>
<p><a href="#top" target="_self"><img src="http://www.microsoft.com/japan/msdn/nodehomes/graphics/top.gif" border="0" alt="">ページのトップへ</a></p>
<hr>
<h2 id="03" style="font-size:120%; margin-top:20px">3. Windows におけるグラフィック オーバービュー</h2>
<p>まずは、サンプルを確認する前に、Windows におけるグラフィック関連の主な API を整理してみましょう。</p>
<p>一般にグラフィックス関連の API においては、プログラマーからの様々な図形の描画指示に基づき、内部ではドットの集まりのグラフィック データが構築されます (ラスタライズされます)。このようなグラフィックス API を大きく分類するとしたら、グラフィック データを構築する際に、ソフトウェア レベルで構築する API と、GPU (Graphics Processing Unit) を用いてハードウェア レベルで構築する API の 2 種類に分類できるでしょう。</p>
<p>このうち、前者としては、従来からある GDI (Graphic Device Interface) や、その後継である GDI&#43; が該当します。また、後者としては DirectX 関連 API の Direct3D のほか、Direct3D の上に構築された Direct2D や DirectWrite などが挙げられます。</p>
<p>ここに挙げた API の中から、アプリケーション開発に使用する API を選択する場合、3 次元座標を用いた本&#26684;的な3 次元グラフィックを構築するのであれば、それが実現できるのは Direct3D だけなので、おのずと選択肢は絞られます。おそらく選択に迷うことがあるとすれば、一般的な2 次元のユーザー インターフェイスで使用する API の場合でしょう。GDI や GDI&#43;、Direct2D、および DirectWrite は、どれも2 次元の描画で使用することができます。</p>
<p>そこで、これらの2 次元グラフィックで利用できる API の特徴を改めてまとめてみます。次表は、特徴的な面に焦点を当てて、その違いをまとめたものです。どの API も、線の描画や塗りつぶし、テキストやイメージの表示などの基本的な機能を備えているので、その点については記載していません。ここでは、パフォーマンスやグラフィックスの品質に関わるものを挙げてみました。</p>
<p><strong>表 10.1 2 次元グラフィックス関連の API の比較</strong></p>
<table class="grid" border="1" cellspacing="0" cellpadding="5" style="border-collapse:collapse; margin-bottom:10px">
<tbody>
<tr style="background-color:#eff3f7">
<td>&nbsp;
<p>&nbsp;</p>
</td>
<td><strong>GDI</strong>
<p>&nbsp;</p>
</td>
<td><strong>GDI&#43;</strong>
<p>&nbsp;</p>
</td>
<td><strong>Direct2D </strong><strong>および</strong><strong> DirectWrite</strong>
<p>&nbsp;</p>
</td>
</tr>
<tr>
<td valign="top">基本的な特徴</td>
<td valign="top">初期から広く利用<br>
デバイス非依存<br>
C 言語関数</td>
<td valign="top">GDI の後継<br>
デバイス非依存<br>
C&#43;&#43; のクラス</td>
<td valign="top">GDI/GDI&#43; の後継<br>
GPU の有効活用<br>
COM ベース</td>
</tr>
<tr>
<td valign="top">ハードウェア<br>
アクセラレーション全般</td>
<td align="center">&times;<br>
(ごく一部可能)</td>
<td align="center">&times;<br>
(ごく一部可能)</td>
<td align="center">○</td>
</tr>
<tr>
<td valign="top">アルファ ブレンディング、<br>
アンチエイリアス</td>
<td align="center">&times;<br>
(ごく一部可能)</td>
<td align="center">○<br>
(ソフト レベル)</td>
<td align="center">○<br>
(ハード レベル)</td>
</tr>
<tr>
<td valign="top">ベクター グラフィック<br>
(ハード レベルでの)</td>
<td align="center">&times;</td>
<td align="center">&times;</td>
<td align="center">○</td>
</tr>
</tbody>
</table>
<p>この表のうち、まず、GDI の列を確認しましょう。GDI は 16 ビット時代の Windows から導入されているもので、C 言語の関数形式の API として提供されています。この API を用いることで、特定のデバイスに依存しないグラフィックスやテキストの描画を実現できます。しかし、特定のハードウェアに依存しないということは、ハードウェア固有の機能を使用しないことでもあります。GDI でも、GPU のアクセラレーションを一部の操作で使用される場合もありますが、ほとんどの操作は、GPU ではなく CPU
 を使用したソフトウェア レベルの処理です。GPU を有効に利用しないことから、複雑な処理ではパフォーマンスが低下することもあります。</p>
<p>また、GDI ではアルファ ブレンディングやアンチエイリアスなどの、高度な画像の加工処理をほとんどサポートしていません (一部の限られた BitBlt と呼ばれるイメージ データの操作では、半透明の状態で図形を重なるなど出来るものもあります)。</p>
<p>このほか GDI では、ハードウェア レベルでのベクター グラフィックもサポートされていません。たしかに、従来の GDI でも Windows メタファイルなどを使用したベクター情報を扱うことはできます。しかし、実際にメタファイルに基づき描画する際には、ソフトウェア レベルでラスタライズされます。そのため、デバイスの解像度に応じた最適な描画になるとは限らず、逆に言えば、デバイスの解像度に左右されない、常に高品質の滑らかな図形の輪郭を提供できるとは限りません。</p>
<p>表の次列にある GDI&#43; は、Windows XP に導入されました。これは、GDI の後継にあたるもので、GDI&#43; の API は、GDI&#43; 固有の C 言語関数をラップした C&#43;&#43; のクラス ライブラリとして提供されています。ハードウェア アクセラレーションをフルに活用できない点や、ハードウェア レベルでのベクター グラフィックではない点については GDI と同様ですが、アルファ ブレンドやアンチエイリアスなどのきめ細かいグラフィックの加工もサポートするようになりました。しかし、この加工処理は、やはりソフトウェア
 レベルのものであり、特にパフォーマンスの面で、GPU を利用する場合よりもオーバーヘッドがあります。</p>
<p>そして Windows 7 では、Direct2D や DirectWrite が導入されました。Direct2D は Direct3D の上に構築されたものであり、図形の描画などのグラフィック全般を扱い、DirectWrite はテキストに特化した描画を担当し、Direct2D を利用したときハードウェア アクセラレーションされます。この 2 つは、相互排他的に利用するのではなく、必要に応じて併用することができます。たとえば、DirectWrite で文字列を描画する際に、その文字列の形状で写真などのイメージ
 データをグラデーション付きで表示する際に、Direct2D を併用するなどです。</p>
<p>この表にあるように Direct2D や DirectWrite では、ハードウェア アクセラレーションを使用し、アルファ ブレンディングやアンチエイリアス、また、ベクター グラフィックもハードウェア レベルでサポートしています。よって、GPU が備えている豊富な機能をフル活用でき、GDI や GDI&#43; に比べてパフォーマンスも向上します。また、ベクター グラフィックもハードウェアによって適切にラスタライズされるので、その結果、デバイスの解像度に左右されずに、滑らかな輪郭のグラフィックスを提供することもできます。</p>
<p>Direct2D や DirectWrite を使用するトレードオフを、あえて挙げるとすれば、比較的新しい OS の環境が必要となる点とまだ直接プリンターへの印刷ができないことです。また、Direct2D や DirectWrite でも、ソフトウェア レベルでのラスタライズも可能ですが、本来の高度な機能を有効活用するには、相応の GPU も必要となります。しかし、現在では Windows 7 が標準搭載されたマシンであれば、ほとんどの場合、DirectX9 以上に対応した GPU が搭載されており、実行環境面では大きな問題はないでしょう。</p>
<p>特に、今後においてネイティブ コードのプログラムを新規に開発するのであれば、2 次元グラフィックを実装する際に、Direct2D や DirectWrite を使用することが奨励されています。</p>
<p>一方、Windows 7 でも GDI や GDI&#43; がサポートされていることもあり、しばらくは、これらに対応したアプリケーションも利用され、Direct2D などの新機能を使用する場合には、1 つのアプリケーションの中で、従来の GDI などと併用する形態になることもあるでしょう。</p>
<p>このあとは、この Direct2D の基本的な使用方法と、GDI と Direct2D を併用する方法について確認していきましょう。</p>
<p><a href="#top" target="_self"><img src="http://www.microsoft.com/japan/msdn/nodehomes/graphics/top.gif" border="0" alt="">ページのトップへ</a></p>
<hr>
<h2 id="04" style="font-size:120%; margin-top:20px">4. Direct2D 対応の開発環境の準備</h2>
<p>Direct2D を用いた描画の実装は、従来の GDI と同様に、Windows プロシージャを伴う一般的な構造の Windows アプリケーションの中に作り込むことができます。ここでは、Visual C&#43;&#43; 2010 Express の「Win32 プロジェクト」を使用して、標準的な Windows アプリケーションに、Direct2D に関わる実装を追加していきます。</p>
<p>まず、「Win32 プロジェクト」を新規作成します。本来、プロジェクト名は任意ですが、このあとのソース ファイルと名前を合わせるため、プロジェクト名は「App10」としてください。(ソリューション名は「App10Sol」など任意です。)</p>
<p>「Win32 アプリケーション ウィザード」が起動したら、既定のオプションのまま手順を進め、プロジェクトを作成してください。これで、WinMain 関数 (_tWinMain 関数) や Windows プロシージャを伴う、一般的な Windows アプリケーションのソース コードが生成されました。</p>
<p>Direct2D のライブラリを利用できるようにするために必要な点は、他のライブラリを利用する場合と同様に、リンク時のインポート ライブラリの指定と、ヘッダー ファイルのインクルードです。</p>
<p>まず、インポート ライブラリを追加するために、プロジェクト プロパティ ページを開きます (ソリューション エクスプローラー上で「App10」プロジェクトを右クリックして、[プロパティ] をクリック)。</p>
<p>そして、プロジェクト プロパティ ページの左側のツリーで、[構成プロパティ]、[リンカー]、[入力] の順にクリックして展開した後、右側の「追加の依存ファイル」の欄に、次図と同じになるように「D2d1.lib」を追加します (この「追加の依存ファイル」の行の右端のドロップダウン リストから「&lt;編集...&gt;」をクリックすれば、対話形式でこのライブラリ名を入力できます)。</p>
<p><img src="http://i1.code.msdn.s-msft.com/visualc-7e652493/image/file/42260/1/image003.jpg" alt="図 10.3" width="580" height="197"></p>
<p><strong>図 10.3 インポート ライブラリ D2d1.lib の指定</strong></p>
<p>また、インクルードすべきヘッダー ファイルは「D2d1.h」です。次のように、既存のファイル stdafx.h の末尾に、インクルード ディレクティブを追加します。</p>
<p><strong>例 10.1 Direct2D 関連のヘッダーのインクルード</strong><br>
<strong>ファイル名: stdafx.h</strong></p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>C&#43;&#43;</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">スクリプトの編集</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">cplusplus</span>

<div class="preview">
<pre id="codePreview" class="cplusplus"><span class="cpp__com">//&nbsp;[省略]</span>&nbsp;
&nbsp;
<span class="cpp__com">//&nbsp;TODO:&nbsp;プログラムに必要な追加ヘッダーをここで参照してください。</span><strong><span class="cpp__preproc">&nbsp;
&nbsp;
#include&nbsp;&lt;D2d1.h&gt;</span></strong></pre>
</div>
</div>
</div>
<p>これで準備ができました。続いて、図 10.1 の実行結果となるように、順に実装していきましょう。</p>
<p><a href="#top" target="_self"><img src="http://www.microsoft.com/japan/msdn/nodehomes/graphics/top.gif" border="0" alt="">ページのトップへ</a></p>
<hr>
<h2 id="05" style="font-size:120%; margin-top:20px">5. 主なオブジェクトなどの基本構成</h2>
<p>まずは、Direct2D で使用する主なオブジェクトなどのプログラムの全体的な構成を理解するために、次に示すように、ファイル App10.cpp の冒頭のディレクティブの直後あたりに、グローバル変数と関数のプロトタイプ宣言を追加してください。</p>
<p><strong>例 10.2 Direct2D の主なオブジェクトとプロトタイプ宣言</strong><br>
<strong>ファイル名: App10.cpp</strong></p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>C&#43;&#43;</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">スクリプトの編集</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">cplusplus</span>

<div class="preview">
<pre id="codePreview" class="cplusplus"><span class="cpp__com">//&nbsp;App10.cpp&nbsp;:&nbsp;アプリケーションのエントリ&nbsp;ポイントを定義します。</span>&nbsp;
<span class="cpp__com">//</span><span class="cpp__preproc">&nbsp;
&nbsp;
#include&nbsp;&quot;stdafx.h&quot;</span><span class="cpp__preproc">&nbsp;
#include&nbsp;&quot;App10.h&quot;</span><span class="cpp__preproc">&nbsp;
&nbsp;
#define&nbsp;MAX_LOADSTRING&nbsp;100</span>&nbsp;
&nbsp;
<span class="cpp__com">//◆◆◆&nbsp;グローバル変数、および関数のプロトタイプ</span>&nbsp;
<strong>ID2D1Factory*&nbsp;pD2DFactory&nbsp;=&nbsp;NULL;</strong>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cpp__com">//&nbsp;ファクトリオブジェクト&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&larr;[1]</span>&nbsp;
<strong>ID2D1HwndRenderTarget*&nbsp;pHwndRenderTarget&nbsp;=&nbsp;NULL;</strong>&nbsp;&nbsp;<span class="cpp__com">//&nbsp;HWND向け&nbsp;レンダーターゲット&nbsp;&larr;[2]</span>&nbsp;
<strong>ID2D1DCRenderTarget*&nbsp;pDCRenderTarget&nbsp;=&nbsp;NULL;</strong>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cpp__com">//&nbsp;HDC向け&nbsp;レンダーターゲット&nbsp;&nbsp;&larr;[3]</span>&nbsp;
<strong>ID2D1SolidColorBrush*&nbsp;pGreenBrush&nbsp;=&nbsp;NULL;</strong>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cpp__com">//&nbsp;緑の単色ブラシ&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&larr;[4]</span>&nbsp;
<strong>ID2D1SolidColorBrush*&nbsp;pBlueBrush&nbsp;=&nbsp;NULL;</strong>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cpp__com">//&nbsp;青の単色ブラシ</span>&nbsp;
<strong>ID2D1LinearGradientBrush*&nbsp;pGradientBrush&nbsp;=&nbsp;NULL;</strong>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cpp__com">//&nbsp;グラデーションブラシ</span>&nbsp;
<strong>ID2D1GradientStopCollection*&nbsp;pGradientStops&nbsp;=&nbsp;NULL;</strong>&nbsp;&nbsp;<span class="cpp__com">//&nbsp;グラデーション情報</span>&nbsp;
&nbsp;
<strong><span class="cpp__datatype">HRESULT</span>&nbsp;CreateDeviceIndependentResources();</strong>&nbsp;&nbsp;<span class="cpp__com">//&nbsp;デバイス非依存の初期化&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&larr;[5]</span>&nbsp;
<strong><span class="cpp__datatype">HRESULT</span>&nbsp;CreateDeviceResources(<span class="cpp__datatype">HWND</span>&nbsp;hWnd);</strong>&nbsp;&nbsp;&nbsp;&nbsp;<span class="cpp__com">//&nbsp;デバイス依存の初期化&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&larr;[6]</span>&nbsp;
<strong><span class="cpp__datatype">HRESULT</span>&nbsp;CreateDeviceResourcesAlt();</strong>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cpp__com">//&nbsp;デバイス依存の初期化(別例)</span>&nbsp;
<strong><span class="cpp__keyword">void</span>&nbsp;Render(<span class="cpp__datatype">HWND</span>&nbsp;hWnd);</strong>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cpp__com">//&nbsp;描画&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&larr;[7]</span>&nbsp;
<strong><span class="cpp__keyword">void</span>&nbsp;RenderAlt(<span class="cpp__datatype">HDC</span>&nbsp;hDC,&nbsp;LPRECT&nbsp;pRect);</strong>&nbsp;&nbsp;&nbsp;<span class="cpp__com">//&nbsp;描画(別例)</span>&nbsp;
<strong><span class="cpp__keyword">void</span>&nbsp;DeleteDeviceResources();&nbsp;</strong>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cpp__com">//&nbsp;デバイス依存の後処理&nbsp;&nbsp;&nbsp;&larr;[8]</span>&nbsp;
<strong><span class="cpp__keyword">void</span>&nbsp;DeleteDeviceIndependentResources();</strong>&nbsp;<span class="cpp__com">//&nbsp;デバイス非依存の後処理&nbsp;&larr;[9]</span>&nbsp;
<span class="cpp__com">//◆◆◆</span></pre>
</div>
</div>
</div>
<p>Direct2D は COM ベースの API であるため、Direct2D で使用するオブジェクトを操作するには、COM のインターフェイス ポインターを使用します。ここで宣言したグローバル変数は、いずれも、Direct2D のオブジェクトを操作するためのインターフェイス ポインターです。</p>
<p>Direct2D を使用する上で、コアとなるオブジェクトは、[1] の ID2D1Factory インターフェイスでアクセスする Direct2D の「ファクトリ オブジェクト」です。Direct2D を利用する手順では、このオブジェクトのインスタンス作成から開始し、インスタンスを解放することで終了します。</p>
<p>[2] の ID2D1HwndRenderTarget と [3] の ID2D1DCRenderTarget は、「レンダー ターゲット」と呼ばれるオブジェクトへのインターフェイス ポインターです。レンダー ターゲットとは、様々な描画命令を受け取るオブジェクトであり、プログラマーが [2] や [3] のインターフェイスのメンバー関数を介して、描画命令を送ることで描画されます。よって、レンダー ターゲットは、描画対象となる論理的なデバイス (描画先) と考えよいでしょう。</p>
<p>レンダー ターゲットのオブジェクトは最低 1 つあれば十分ですが、ここでは異なる 2 種類のパターンを示すため、[2] と [3] の 2 つを用意しました。</p>
<p>[2] の ID2D1HwndRenderTarget インターフェイスを使用するレンダー ターゲットは、ウィンドウ ハンドル (HWND) に対応付けて使用するもです。このレンダー ターゲットのオブジェクトは、1 つのウィンドウ (のクライアント領域) とみなすことができます。</p>
<p>一方、[3] の ID2D1DCRenderTarget インターフェイスを使用するレンダー ターゲットは、GDI のデバイス コンテキスト (HDC) に対応付けて使用するものです。このレンダー ターゲットを使用すれば、GDI が使用する描画領域に対して、Direct2D の描画を行うことができます。つまり、従来の GDI による描画に Direct2D の描画を追加するなどの相互運用を行うことができます。</p>
<p>[4] 以降の 4 つのインターフェイス ポインターは、ブラシなど、実際の描画に使用する補助的なオブジェクトです。具体的な使用例はのちほど示します。</p>
<p>[5] 以降の関数のプロトタイプ宣言は必須ではありませんが、Direct2D の利用手順を理解しやすくするため、手順の用途ごとに関数にまとめることにしました。留意すべき点は、Direct2D のオブジェクトの初期化や後処理には、特定のデバイス (つまり、特定のレンダー ターゲット) に対して非依存のものと、依存するものがあることです。一般に、デバイスに依存しない初期化と後処理は、アプリケーションのライフタイムに一致しますが、デバイスに依存するものは、デバイスのライフタイムに一致します。</p>
<p>デバイスに非依存の初期化と後処理は、それぞれ、[5] の CreateDeviceIndependentResources 関数と [9] の DeleteDeviceIndependentResources 関数に実装し、デバイス依存の初期化と後処理は、それぞれ [6] の CreateDeviceResources 関数と [8] の DeleteDeviceResources 関数に実装することにします。このように、デバイス非依存とデバイス依存の処理を分ける実装は、Direct2D のサンプル コードでよく見かけるパターンなので、慣れておくとよいでしょう。</p>
<p>また、ここでは具体的な描画手順については、[7] の Render 関数に実装します。</p>
<p>なお、[6] と [7] のそれぞれ次行にあるように、デバイス依存の初期化と描画処理については、この記事の後半で、別の例も紹介します。</p>
<p>次に、プロトタイプ宣言を行ったそれぞれの関数の実装も含め、具体的な手順を確認しましょう。まずは、図 10.1 の実行結果になる完成コードを以下に掲載します (ソース コード内の連番は、前述のソース コードからの続きです)。入力する場合は、その後の説明を参考にして、順に入力してみてください。</p>
<p><strong>例 10.3 Direct2D を使用した基本的な描画</strong><br>
<strong>ファイル名: App10.cpp</strong></p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>C&#43;&#43;</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">スクリプトの編集</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">cplusplus</span>

<div class="preview">
<pre id="codePreview" class="cplusplus"><span class="cpp__com">//&nbsp;[省略]</span>&nbsp;
&nbsp;
<span class="cpp__datatype">int</span>&nbsp;APIENTRY&nbsp;_tWinMain(<span class="cpp__datatype">HINSTANCE</span>&nbsp;hInstance,&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cpp__datatype">HINSTANCE</span>&nbsp;hPrevInstance,&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cpp__datatype">LPTSTR</span>&nbsp;&nbsp;&nbsp;&nbsp;lpCmdLine,&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cpp__datatype">int</span>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;nCmdShow)&nbsp;
{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;UNREFERENCED_PARAMETER(hPrevInstance);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;UNREFERENCED_PARAMETER(lpCmdLine);&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cpp__com">//◆◆◆COMの初期化</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<strong><span class="cpp__datatype">HRESULT</span>&nbsp;hr;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;hr&nbsp;=&nbsp;::CoInitializeEx(NULL,&nbsp;COINIT_APARTMENTTHREADED);</strong>&nbsp;<span class="cpp__com">//&larr;[10]</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<strong><span class="cpp__keyword">if</span>(!SUCCEEDED(hr))&nbsp;<span class="cpp__keyword">return</span>&nbsp;hr;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cpp__com">//◆◆◆Direct2D&nbsp;デバイス非依存の初期化</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;hr&nbsp;=&nbsp;::CreateDeviceIndependentResources();</strong>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cpp__com">//&larr;[11]</span>&nbsp;
&nbsp;&nbsp;&nbsp;<strong>&nbsp;<span class="cpp__keyword">if</span>(!SUCCEEDED(hr))&nbsp;<span class="cpp__keyword">return</span>&nbsp;hr;</strong>&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cpp__com">//&nbsp;[省略]</span>&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cpp__com">//◆◆◆Direct2D&nbsp;デバイス非依存の後処理</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<strong>::DeleteDeviceIndependentResources();</strong>&nbsp;&nbsp;<span class="cpp__com">//&larr;[12]</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cpp__com">//◆◆◆COMの後処理</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<strong>::CoUninitialize();</strong>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cpp__com">//&larr;[13]</span>&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cpp__keyword">return</span>&nbsp;(<span class="cpp__datatype">int</span>)&nbsp;msg.wParam;&nbsp;
}&nbsp;
&nbsp;
<span class="cpp__com">//&nbsp;[省略]</span>&nbsp;
&nbsp;
<span class="cpp__datatype">LRESULT</span>&nbsp;CALLBACK&nbsp;WndProc(<span class="cpp__datatype">HWND</span>&nbsp;hWnd,&nbsp;<span class="cpp__datatype">UINT</span>&nbsp;message,&nbsp;<span class="cpp__datatype">WPARAM</span>&nbsp;wParam,&nbsp;<span class="cpp__datatype">LPARAM</span>&nbsp;lParam)&nbsp;
{&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cpp__com">//&nbsp;[省略]</span>&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cpp__keyword">case</span>&nbsp;WM_PAINT:&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cpp__com">//◆◆◆Direct2Dを使用して描画</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<strong>Render(hWnd);</strong>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cpp__com">//&larr;[14]</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cpp__keyword">break</span>;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cpp__keyword">case</span>&nbsp;WM_DESTROY:&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;PostQuitMessage(<span class="cpp__number">0</span>);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cpp__keyword">break</span>;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cpp__com">//&nbsp;[省略]</span>&nbsp;
&nbsp;
}&nbsp;
&nbsp;
<span class="cpp__com">//◆◆◆以降はすべて追加</span>&nbsp;
&nbsp;
<span class="cpp__com">//&nbsp;デバイス非依存の初期化</span>&nbsp;
<span class="cpp__datatype">HRESULT</span>&nbsp;CreateDeviceIndependentResources()&nbsp;&nbsp;<span class="cpp__com">//&larr;[15]</span>&nbsp;
{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cpp__datatype">HRESULT</span>&nbsp;hr;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cpp__com">//&nbsp;Direct2D&nbsp;ファクトリの作成</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;hr&nbsp;=&nbsp;::D2D1CreateFactory(&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cpp__com">//&larr;[16]</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;D2D1_FACTORY_TYPE_SINGLE_THREADED,&nbsp;&nbsp;<span class="cpp__com">//&larr;[17]</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;IID_ID2D1Factory,&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;(<span class="cpp__keyword">void</span>**)&nbsp;&amp;pD2DFactory);&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cpp__com">//&larr;[18]</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cpp__keyword">return</span>&nbsp;hr;&nbsp;
}&nbsp;
&nbsp;
<span class="cpp__com">//&nbsp;デバイス依存の初期化</span>&nbsp;
<span class="cpp__datatype">HRESULT</span>&nbsp;CreateDeviceResources(<span class="cpp__datatype">HWND</span>&nbsp;hWnd)&nbsp;&nbsp;<span class="cpp__com">//&larr;[19]</span>&nbsp;
{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cpp__datatype">HRESULT</span>&nbsp;hr&nbsp;=&nbsp;S_OK;&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cpp__com">//&nbsp;ファクトリが無ければ何もしない</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cpp__keyword">if</span>(&nbsp;pD2DFactory&nbsp;==&nbsp;NULL)&nbsp;<span class="cpp__keyword">return</span>&nbsp;E_FAIL;&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cpp__com">//&nbsp;レンダーターゲットの作成</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cpp__keyword">if</span>(&nbsp;pHwndRenderTarget&nbsp;==&nbsp;NULL)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;RECT&nbsp;rect;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;::GetClientRect(hWnd,&nbsp;&amp;rect);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;D2D1_SIZE_U&nbsp;size&nbsp;=&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;D2D1::Size&lt;<span class="cpp__datatype">UINT</span>&gt;(rect.right,&nbsp;rect.bottom);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;hr&nbsp;=&nbsp;pD2DFactory-&gt;CreateHwndRenderTarget(&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cpp__com">//&larr;[20]</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;D2D1::RenderTargetProperties(),&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cpp__com">//&larr;[21]</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;D2D1::HwndRenderTargetProperties(hWnd,&nbsp;size),&nbsp;<span class="cpp__com">//&larr;[22]</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&amp;pHwndRenderTarget);&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cpp__com">//&larr;[23]</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cpp__keyword">if</span>(!SUCCEEDED(hr))&nbsp;<span class="cpp__keyword">return</span>&nbsp;hr;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cpp__com">//&nbsp;ブラシの作成</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cpp__keyword">if</span>(pGreenBrush&nbsp;==&nbsp;NULL)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;hr&nbsp;=&nbsp;pHwndRenderTarget-&gt;CreateSolidColorBrush(&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cpp__com">//&larr;[23]</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;D2D1::ColorF(<span class="cpp__number">0</span>.0F,&nbsp;<span class="cpp__number">1</span>.0F,&nbsp;<span class="cpp__number">0</span>.0F),&nbsp;&amp;pGreenBrush);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cpp__keyword">if</span>(!SUCCEEDED(hr))&nbsp;<span class="cpp__keyword">return</span>&nbsp;hr;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cpp__keyword">if</span>(pBlueBrush&nbsp;==&nbsp;NULL)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;hr&nbsp;=&nbsp;pHwndRenderTarget-&gt;CreateSolidColorBrush(&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cpp__com">//&larr;[24]</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;D2D1::ColorF(<span class="cpp__number">0</span>.0F,&nbsp;<span class="cpp__number">0</span>.0F,&nbsp;<span class="cpp__number">1</span>.0F,&nbsp;<span class="cpp__number">0</span>.5F),&nbsp;&amp;pBlueBrush);&nbsp;&nbsp;<span class="cpp__com">//&larr;[25]</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cpp__keyword">if</span>(!SUCCEEDED(hr))&nbsp;<span class="cpp__keyword">return</span>&nbsp;hr;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cpp__keyword">if</span>(pGradientBrush&nbsp;==&nbsp;NULL)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cpp__keyword">static</span>&nbsp;<span class="cpp__keyword">const</span>&nbsp;D2D1_GRADIENT_STOP&nbsp;stops[]&nbsp;=&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cpp__com">//&larr;[26]</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;&nbsp;&nbsp;<span class="cpp__number">0</span>.0f,&nbsp;&nbsp;{&nbsp;<span class="cpp__number">0</span>.0f,&nbsp;<span class="cpp__number">1</span>.0f,&nbsp;<span class="cpp__number">1</span>.0f,&nbsp;<span class="cpp__number">1</span>.0f&nbsp;}&nbsp;&nbsp;},&nbsp;<span class="cpp__com">//&larr;[27]</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;&nbsp;&nbsp;<span class="cpp__number">1</span>.0f,&nbsp;&nbsp;{&nbsp;<span class="cpp__number">0</span>.0f,&nbsp;<span class="cpp__number">0</span>.0f,&nbsp;<span class="cpp__number">1</span>.0f,&nbsp;<span class="cpp__number">0</span>.5f&nbsp;}&nbsp;&nbsp;},&nbsp;<span class="cpp__com">//&larr;[28]</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;};&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;hr&nbsp;=&nbsp;pHwndRenderTarget-&gt;CreateGradientStopCollection(&nbsp;<span class="cpp__com">//&larr;[29]</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;stops,&nbsp;<span class="cpp__keyword">sizeof</span>(stops)/<span class="cpp__keyword">sizeof</span>(D2D1_GRADIENT_STOP),&nbsp;&amp;pGradientStops);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cpp__keyword">if</span>(!SUCCEEDED(hr))&nbsp;<span class="cpp__keyword">return</span>&nbsp;hr;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;hr&nbsp;=&nbsp;pHwndRenderTarget-&gt;CreateLinearGradientBrush(&nbsp;&nbsp;&nbsp;&nbsp;<span class="cpp__com">//&larr;[30]</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;D2D1::LinearGradientBrushProperties(&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;D2D1::Point2F(<span class="cpp__number">100</span>.0F,&nbsp;<span class="cpp__number">120</span>.0F),&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;D2D1::Point2F(<span class="cpp__number">100</span>.0F,&nbsp;<span class="cpp__number">270</span>.0F)),&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;D2D1::BrushProperties(),&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;pGradientStops,&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&amp;pGradientBrush);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cpp__keyword">if</span>(!SUCCEEDED(hr))&nbsp;<span class="cpp__keyword">return</span>&nbsp;hr;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cpp__keyword">return</span>&nbsp;hr;&nbsp;
}&nbsp;
&nbsp;
<span class="cpp__com">//&nbsp;HWNDへの描画</span>&nbsp;
<span class="cpp__keyword">void</span>&nbsp;Render(<span class="cpp__datatype">HWND</span>&nbsp;hWnd)&nbsp;&nbsp;<span class="cpp__com">//&larr;[31]</span>&nbsp;
{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cpp__datatype">HRESULT</span>&nbsp;hr;&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;hr&nbsp;=&nbsp;CreateDeviceResources(hWnd);&nbsp;&nbsp;<span class="cpp__com">//&larr;[32]</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cpp__keyword">if</span>(!SUCCEEDED(hr))&nbsp;<span class="cpp__keyword">return</span>;&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cpp__keyword">if</span>(pHwndRenderTarget-&gt;CheckWindowState()&nbsp;&amp;&nbsp;D2D1_WINDOW_STATE_OCCLUDED)&nbsp;&nbsp;<span class="cpp__com">//&larr;[33]</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cpp__keyword">return</span>;&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cpp__com">//レンダーターゲットの論理サイズの再設定&nbsp;&larr;[34]</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cpp__com">//RECT&nbsp;rect;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cpp__com">//::GetClientRect(hWnd,&nbsp;&amp;rect);</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cpp__com">//pHwndRenderTarget-&gt;Resize(&nbsp;D2D1::SizeU(rect.right,&nbsp;rect.bottom)&nbsp;);</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cpp__com">//</span>&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;pHwndRenderTarget-&gt;BeginDraw();&nbsp;&nbsp;<span class="cpp__com">//&larr;[35]</span>&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cpp__com">//背景クリア</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;pHwndRenderTarget-&gt;Clear(D2D1::ColorF(<span class="cpp__number">1</span>.0F,&nbsp;<span class="cpp__number">1</span>.0F,&nbsp;<span class="cpp__number">1</span>.0F));&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cpp__com">//&larr;[36]</span>&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cpp__com">//円の描画</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;D2D1_ELLIPSE&nbsp;ellipse1&nbsp;=&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;D2D1::Ellipse(D2D1::Point2F(<span class="cpp__number">120</span>.0F,&nbsp;<span class="cpp__number">120</span>.0F),&nbsp;<span class="cpp__number">100</span>.0F,&nbsp;<span class="cpp__number">100</span>.0F);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;pHwndRenderTarget-&gt;DrawEllipse(ellipse1,&nbsp;pGreenBrush,&nbsp;<span class="cpp__number">10</span>.0F);&nbsp;&nbsp;<span class="cpp__com">//&larr;[37]</span>&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cpp__com">//1つ目の四角形の描画</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;D2D1_RECT_F&nbsp;rect1&nbsp;=&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;D2D1::RectF(<span class="cpp__number">100</span>.0F,&nbsp;<span class="cpp__number">50</span>.0F,&nbsp;<span class="cpp__number">300</span>.0F,&nbsp;<span class="cpp__number">100</span>.F);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;pHwndRenderTarget-&gt;FillRectangle(&amp;rect1,&nbsp;pBlueBrush);&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cpp__com">//&larr;[38]</span>&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cpp__com">//2つ目の四角形の描画</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;D2D1_RECT_F&nbsp;rect2&nbsp;=&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;D2D1::RectF(<span class="cpp__number">100</span>.0F,&nbsp;<span class="cpp__number">120</span>.0F,&nbsp;<span class="cpp__number">250</span>.0F,&nbsp;<span class="cpp__number">270</span>.F);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;pHwndRenderTarget-&gt;FillRectangle(&amp;rect2,&nbsp;pGradientBrush);&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cpp__com">//&larr;[39]</span>&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;pHwndRenderTarget-&gt;EndDraw();&nbsp;&nbsp;&nbsp;<span class="cpp__com">//&larr;[40]</span>&nbsp;
}&nbsp;
&nbsp;
<span class="cpp__com">//&nbsp;デバイス依存のリソースの後処理</span>&nbsp;
<span class="cpp__keyword">void</span>&nbsp;DeleteDeviceResources()&nbsp;&nbsp;<span class="cpp__com">//&larr;[41]</span>&nbsp;
{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cpp__keyword">if</span>(pGradientBrush&nbsp;!=&nbsp;NULL)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;pGradientBrush-&gt;Release();&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;pGradientBrush&nbsp;=&nbsp;NULL;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cpp__keyword">if</span>(pGradientStops&nbsp;!=&nbsp;NULL)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;pGradientStops-&gt;Release();&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;pGradientStops&nbsp;=&nbsp;NULL;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cpp__keyword">if</span>(pBlueBrush&nbsp;!=&nbsp;NULL)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;pBlueBrush-&gt;Release();&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;pBlueBrush&nbsp;=&nbsp;NULL;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cpp__keyword">if</span>(pGreenBrush&nbsp;!=&nbsp;NULL)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;pGreenBrush-&gt;Release();&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;pGreenBrush&nbsp;=&nbsp;NULL;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cpp__keyword">if</span>(pHwndRenderTarget&nbsp;!=&nbsp;NULL)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;pHwndRenderTarget-&gt;Release();&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;pHwndRenderTarget&nbsp;=&nbsp;NULL;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cpp__keyword">if</span>(pDCRenderTarget&nbsp;!=&nbsp;NULL)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;pDCRenderTarget-&gt;Release();&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;pDCRenderTarget&nbsp;=&nbsp;NULL;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
}&nbsp;
&nbsp;
<span class="cpp__com">//&nbsp;デバイス非依存の後処理</span>&nbsp;
<span class="cpp__keyword">void</span>&nbsp;DeleteDeviceIndependentResources()&nbsp;<span class="cpp__com">//&larr;[42]</span>&nbsp;
{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cpp__keyword">if</span>(pD2DFactory&nbsp;!=&nbsp;NULL)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;pD2DFactory-&gt;Release();&nbsp;&nbsp;<span class="cpp__com">//&larr;[43]</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;pD2DFactory&nbsp;=&nbsp;NULL;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
}</pre>
</div>
</div>
</div>
<p><a href="#top" target="_self"><img src="http://www.microsoft.com/japan/msdn/nodehomes/graphics/top.gif" border="0" alt="">ページのトップへ</a></p>
<hr>
<h2 id="06" style="font-size:120%; margin-top:20px">6. デバイス非依存の初期化と後処理 ～COM、および Direct2D として～</h2>
<p>まず、Direct2D は COM ベースの API であることから、COM としての初期化と後処理が必要です。この例では、COM の初期化と後処理について、それぞれ、[10] と [13] で行っています。[10] のように、初期化の CoInitializeEx 関数の 2 番目の引数には、ここでは STA (Single Thread Apartment) を指定しています。Direct2D では、STA も MTA も指定することができますが、単純に描画するだけなら、STA で十分でしょう。</p>
<div style="margin:10px 0px; padding:10px 10px 0px 10px; border:double 1px #CCCCCC">
<p style="margin:0"><strong>Note:</strong></p>
<p>STA や MTA など COM 関連の基本事項については、<a href="http://code.msdn.microsoft.com/ja-jp/VisualC-7c6bc862">第 1 回</a>の記事を参照してください。</p>
</div>
<p>また、Direct2D としてのデバイスに依存しない初期化と後処理については、[11] と [12] で呼び出しています。それぞれの具体的な実装は、[15] と [42] に記述してあります。主な行うべき手順は、それぞれ、Direct2D のファクトリ オブジェクトの作成と削除です。</p>
<p>[15] の CreateDeviceIndependentResources 関数では、ファクトリ オブジェクトを作成するために、[16] の Direct2D 専用の D2D1CreateFactory 関数というヘルパーを使用します。この呼び出しによって、実質的に COM オブジェクトであるファクトリのインスタンスを作成し、そのインスタンスのインターフェイス ポインターは、[18] の出力引数に指定された変数 pD2DFactory に取得できます。これで、変数 pD2DFactory ([1]
 のグローバル変数) を介して、ファクトリ オブジェクトにアクセスできるようになります。</p>
<p>なお、ここでは STA の COM の環境を使用しているので、[17] の引数には、このシングルスレッド対応であることを指定しています。</p>
<p>一方、[42] の DeleteDeviceIndependentResources 関数の内部では、後処理として、COM の作法に従って、[43] のように Release メソッドを呼び出して、ファクトリ オブジェクトを解放しています。</p>
<p><a href="#top" target="_self"><img src="http://www.microsoft.com/japan/msdn/nodehomes/graphics/top.gif" border="0" alt="">ページのトップへ</a></p>
<hr>
<h2 id="07" style="font-size:120%; margin-top:20px">7. デバイス依存の初期化と後処理</h2>
<p>デバイス非依存の初期化として、Direct2D のファクトリ オブジェクトの作成が済んだら、次に行うべきことは、レンダー ターゲットごとの初期化です。つまり、特定の描画先であるデバイスに依存した初期化を行います。この例では、[19] の CreateDeviceResources に実装しています (どのタイミングで呼び出すかは後述)。</p>
<p>[19] の内部では、まず、レンダー ターゲットのインスタンスを作成しています。レンダー ターゲットを作成するには、[20] のように、ファクトリ オブジェクト (pD2DFactory) を使用して、そのメンバー関数を呼び出します。この例では、ウィンドウに対して描画するので、HWND に対応付けたレンダー ターゲットを作成するため、CreateHwndRenderTarget 関数を呼び出しています。</p>
<p>この関数の 1 番目と 2 番目の引数には、複数のプロパティを構造体として渡す必要がありますが、[21] の D2D1::RenderTargetProperties ヘルパー関数や [22] の D2D1::HwndRenderTargetProperties ヘルパー関数を使用することで、引数に必要な構造体を作成することができるので便利です。この構造体を作成する際に、[22] では、このレンダー ターゲットに対応付けるウィンドウ ハンドル (hWnd) と、レンダー ターゲットの論理的なサイズ (size)
 を指定しています。</p>
<p>ここで指定する論理的なサイズは、意外と重要な情報です。このサンプルでは、レンダー ターゲットのサイズには、ウィンドウ (のクライアント領域) のサイズをそのまま渡しています。つまり、物理的なウィンドウのサイズが 400&times;300 (ピクセル) であるなら、レンダー ターゲットの論理的サイズも 400&times;300 となります。この設定によって、レンダー ターゲットに描画された図形は、1 : 1 の倍率で物理的なウィンドウにマップされます。</p>
<p>そして、実行中にエンドユーザーが物理的なウィンドウのサイズを変更した場合、レンダー ターゲットの論理的なサイズは変化しないので、レンダー ターゲットの領域がウィンドウに納まるようにスケーリングされます。たとえば、レンダー ターゲットの論理的なサイズが 400&times;300 であるとき、物理的なウィンドウのサイズを 200&times;150 に変更すると、論理的なサイズ 100 が物理的な 50 ピクセルにマップされ、もともとの大きさの 2 分の 1 に縮小されます。</p>
<p>次の図 10.4 は、このサンプルのウィンドウの縦幅を小さくして、図形が縦方向に縮小した様子を表しています。なお、このような物理ウィンドウのサイズに応じたスケーリングは、すべての種類のレンダー ターゲットで起こるわけではなく、HWND に対応付いたレンダー ターゲット (ID2D1HwndRenderTarget インターフェイスのオブジェクト) における固有の振る舞いです。</p>
<p><img src="http://i1.code.msdn.s-msft.com/visualc-7e652493/image/file/42261/1/image004.jpg" alt="図 10.4" width="580" height="177"></p>
<p><strong>図 10.4 ウィンドウの高さを小さくすると、縦方向に図形が縮小</strong></p>
<div style="margin:10px 0px; padding:10px 10px 0px 10px; border:double 1px #CCCCCC">
<p style="margin:0"><strong>Note:</strong></p>
<p>物理的なウィンドウの大きさを変更しても、描画図形の大きさを一定に保つ方法としては、ウィンドウの大きさが変更された都度、それと同期するように、レンダー ターゲットの論理的なサイズも同じになるよう変更する方法があります。この例の [34] 以下の 4 行のコメントには、参考として、このようなサイズの同期を行うために、ID2D1HwndRenderTarget インターフェイスの Resize メンバー関数を呼び出して、レンダー ターゲットの論理サイズを変更するコードが記述されています (簡単にするため、WM_PAINT
 メッセージが送られる都度、同期を取っています)。余力があれば、サンプル コードが完成したのち、コメントをはずして、実際に図形の大きさが変化しないことを確認してみてください。</p>
</div>
<p>レンダー ターゲットを作成したのち、デバイス依存の初期化としては、このレンダー ターゲットでの描画で使用するブラシなどの補助的なオブジェクトを作ることです。[23] や [24]、[29]、[30] のように、レンダー ターゲットのインターフェイス (変数 pHwndRenderTarget) のメンバー関数を呼び出して、ブラシなどの必要なオブジェクトを作成しています。このことから、ブラシなどのオブジェクトは、特定のレンダー ターゲット (特定のデバイス) ごとに用意する必要があることが読み取れるでしょう。</p>
<p>また、メンバー関数の名前から、どのようなオブジェクトを作るかは想像付くと思います。[23] と [24] の CreateSolidColorBrush 関数では、単色の塗りつぶしのブラシを作成しています。</p>
<p>このとき [25] では、1 番目の引数に ColorF 構造体としてブラシの色の情報を渡します。[25] で使用されている D2D1::ColorF 関数はヘルパーであり、ColorF 構造体の色情報を作成します。このヘルパー関数の 4 つの引数では、RGB の色の 3 要素のほか、4 番目の引数には、図形が透けて見える、透明度を指定しています。つまり、アルファ ブレンディングを行うことができます。ここでは、0.5F なので半透明となります。</p>
<p>[30] の CreateLinearGradientBrush 関数では、グラデーションを実現するためのブラシを作成しています。グラデーションの色の変化に必要な情報 (コレクション) は、[29] の関数呼び出しで作成しており、そのもとになるデータ配列は [26] に定義してあります。配列の要素である [27] と [28] は、次の構造になっています。</p>
<div style="margin:20px 0px; padding:10px 10px 3px 10px; background-color:#dedede">
<p>{ その色の位置, { R, G, B, 透明度 } }</p>
</div>
<p>ここでは、[27] でグラデーションの開始点 (0.0f) の色を指定し、[28] で終了点 (1.0f) の色を指定しています。入れ子の内側の 4 つの要素の並びでは、色の 3 要素と透明度も指定できるので、このグラデーションでは、色の変化と同時に、透明度の変化を表すこともできます。</p>
<p>このように、描画の素材となるブラシには、グラデーションやアルファ ブレンドなどの図形に対するきめ細かい制御も指定できます。</p>
<p>なお、これらの後処理については、特に難しいことないでしょう。[41] の DeleteDeviceResources 関数にあるように、それぞれのオブジェクトのインターフェイス ポインターを介して、Release メンバー関数を呼び出して、オブジェクトを解放すればよいのです。</p>
<p><a href="#top" target="_self"><img src="http://www.microsoft.com/japan/msdn/nodehomes/graphics/top.gif" border="0" alt="">ページのトップへ</a></p>
<hr>
<h2 id="08" style="font-size:120%; margin-top:20px">8. 具体的な描画方法</h2>
<p>必要な初期化に関して一通り済んだら、いよいよ描画です。</p>
<p>描画処理は、[31] の Render 関数の中に実装されています。基本的には、描画のタイミングとしては、従来の GDI と同様で、[14] にあるように WM_PAINT メッセージに呼応して行います。</p>
<div style="margin:10px 0px; padding:10px 10px 0px 10px; border:double 1px #CCCCCC">
<p style="margin:0"><strong>Note:</strong></p>
<p>ここでは描画のための最低限の手順を示しています。この例では、既定の GDI による背景描画が行われるなど、冗長な部分があります。</p>
</div>
<p>それでは、[31] の Render 関数の中身を確認しましょう。</p>
<p>この例では、ウィンドウが確実に用意されたあとに、デバイス依存の初期化を行うようにしているため、この Render 関数の中から [32] のように、CreateDeviceResources 関数を呼び出しています (ウィンドウ、つまり、HWND が用意されていれば、呼び出すタイミングは、この限りではありません)。</p>
<p>また、[33] では、このウィンドウの状態を調べ、このウィンドウが他のウィンドウに覆われていたいるか確認しています。覆われていた場合は描画することは無駄なので、条件式が true となり、return 文で処理を終了しています。</p>
<p>一連の描画操作には、[35] の BeginDraw 関数呼び出しから始まり、[40] の EndDraw 関数呼び出しで終わります。この [35] から [40] までの間に、描画を行うメンバー関数を呼び出します。具体的な描画操作である、[36]、[37]、[38]、および [39] につていは、記載さたれコメントやメンバー関数の名前から、行うことは想像が付くと思いますので、詳細は割愛し、いくつか特徴を確認します。</p>
<p>実際の描画はレンダー ターゲットに対して行うので、[35] 以降にあるように、レンダー ターゲットを指し示す ID2D1HwndRenderTarget 型のインターフェイス ポインター (pHwndRenderTarget) を使用して、必要な各種メンバー関数を呼び出します。もし、何か特定の描画方法を調べたい場合には、このインターフェイスのメンバー関数を調べることになります。正確にいうと、このインターフェイスは、ID2D1RenderTarget 基本インターフェイスから継承しており、ID2D1RenderTarget
 インターフェイスに描画関連のメンバー関数が定義されています。</p>
<p>また、[37] や [38]、[39] の呼び出しの引数には、デバイス依存の初期化で作成した各ブラシが使用されています (pGreenBrush、pBlueBrush、および、pGradientBrush)。このブラシに基づいて、特定の色での塗りつぶしや、グラデーション、アルファ ブレンディングなどが実現できます。</p>
<p>これで、一通りの確認ができました。</p>
<p>この時点で実際に実行すると、図 10.1 のようになるので、余力があれば、実行結果の表示内容と、前述の Render 関数における [37]、[38]、および [39] などの具体的な描画手順とを照らし合わせてみてください。</p>
<div style="margin:10px 0px; padding:10px 10px 0px 10px; border:double 1px #CCCCCC">
<p style="margin:0"><strong>Note:</strong></p>
<p>Direct2D の描画には、他にも様々なバリエーションがあります。多角形や任意の形状の幾何学図形、画像データも描画できます。</p>
<p>このうち、幾何学図形を含む描画のバリエーションに関する演習が、次のアドレスに公開されています。</p>
<ul>
<li><a href="http://msdn.microsoft.com/ja-jp/windows/ee427969" target="_blank">ハンズオン ラボ: グラフィックス ～ Direct2D ～</a>
</li></ul>
<p>図形の縮小や拡大、回転などの変換 (transformation) を行う例が、次の逆引きに記載されています。</p>
<ul>
<li><a href="http://code.msdn.microsoft.com/ja-jp/VisualC-howto-96795643/">逆引き (9) - Direct2D において拡大/縮小、回転などの変換を行う</a>
</li></ul>
<p>このほか、多角形、幾何学図形、ビットマップの表示などの各種コード サンプルの一覧が以下のアドレスに記載されています。</p>
<ul>
<li><a href="http://msdn.microsoft.com/ja-jp/library/dd370906%28VS.85%29.aspx" target="_blank">(Direct2D の) コード例</a>
</li></ul>
<p>また、テキストの描画を行う DirectWrite に関する演習が、次のアドレスに公開されています。</p>
<ul>
<li><a href="http://msdn.microsoft.com/ja-jp/windows/ee426939" target="_blank">ハンズオン ラボ: グラフィックス ～ DirectWrite ～</a>
</li></ul>
<p>この DirectWrite のハンズオンでは、様々な修飾を加えたテキストの表示例のほか、Direct2D を併用して、文字の形状に画像データを表示する例も掲載されています。</p>
</div>
<p><a href="#top" target="_self"><img src="http://www.microsoft.com/japan/msdn/nodehomes/graphics/top.gif" border="0" alt="">ページのトップへ</a></p>
<hr>
<h2 id="09" style="font-size:120%; margin-top:20px">9. GDI との相互運用の準備</h2>
<p>次に、GDI のデバイス コンテキスト (HDC) に対応付けたレンダー ターゲットを使用して、GDI と Direct2D を併用する方法を確認してみましょう。次に、図 10.2 に示す実行結果となるように修正と追加を行った完成コードを示します。以下の説明を参考にして、修正してみてください。</p>
<p><strong>例 10.4 HDC を介した GDI との相互運用</strong><br>
<strong>ファイル名: App10.cpp</strong></p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>C&#43;&#43;</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">スクリプトの編集</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">cplusplus</span>

<div class="preview">
<pre id="codePreview" class="cplusplus"><span class="cpp__com">//&nbsp;[省略]</span>&nbsp;
&nbsp;
<span class="cpp__datatype">LRESULT</span>&nbsp;CALLBACK&nbsp;WndProc(<span class="cpp__datatype">HWND</span>&nbsp;hWnd,&nbsp;<span class="cpp__datatype">UINT</span>&nbsp;message,&nbsp;<span class="cpp__datatype">WPARAM</span>&nbsp;wParam,&nbsp;<span class="cpp__datatype">LPARAM</span>&nbsp;lParam)&nbsp;
{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cpp__datatype">int</span>&nbsp;wmId,&nbsp;wmEvent;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;PAINTSTRUCT&nbsp;ps;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cpp__datatype">HDC</span>&nbsp;hdc;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cpp__datatype">HPEN</span>&nbsp;pen1;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cpp__com">//GDIのため追加&nbsp;&larr;[44]</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cpp__datatype">HGDIOBJ</span>&nbsp;prevObj;&nbsp;&nbsp;<span class="cpp__com">//GDIのため追加&nbsp;&larr;[45]</span>&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cpp__com">//&nbsp;[省略]</span>&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cpp__keyword">case</span>&nbsp;WM_PAINT:&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cpp__com">//◆◆◆Direct2Dを使用して描画</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cpp__com">//Render(hWnd);&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;//&larr;[14]</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cpp__com">//◆◆◆Direct2Dを使用して描画(HDCを相互運用)</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;hdc&nbsp;=&nbsp;BeginPaint(hWnd,&nbsp;&amp;ps);&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cpp__com">//&larr;[46]</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cpp__com">//HDCを用いた通常の描画</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;RECT&nbsp;rect;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cpp__com">//&larr;[47]</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;::GetClientRect(hWnd,&nbsp;&amp;rect);&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cpp__com">//&larr;[48]</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;::DrawText(&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;hdc,&nbsp;_T(<span class="cpp__string">&quot;Direct&nbsp;2D&nbsp;Sample&nbsp;with&nbsp;DC&quot;</span>),&nbsp;<span class="cpp__number">24</span>,&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&amp;rect,&nbsp;DT_LEFT&nbsp;|&nbsp;DT_TOP);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;pen1&nbsp;=&nbsp;::CreatePen(PS_SOLID,&nbsp;<span class="cpp__number">10</span>,&nbsp;RGB(<span class="cpp__number">0</span>,<span class="cpp__number">255</span>,<span class="cpp__number">0</span>));&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;prevObj&nbsp;=&nbsp;::SelectObject(hdc,&nbsp;pen1);&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;::Ellipse(hdc,&nbsp;<span class="cpp__number">30</span>,&nbsp;<span class="cpp__number">50</span>,&nbsp;<span class="cpp__number">230</span>,&nbsp;<span class="cpp__number">250</span>);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;::SelectObject(hdc,&nbsp;prevObj);&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cpp__com">//&larr;[49]</span>&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cpp__com">//Direct2Dを用いて同じHDCに描画</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;rect.top&nbsp;&nbsp;&#43;=&nbsp;<span class="cpp__number">30</span>;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cpp__com">//&larr;[50]</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;rect.left&nbsp;&#43;=&nbsp;<span class="cpp__number">300</span>;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cpp__com">//&larr;[51]</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;RenderAlt(hdc,&nbsp;&amp;rect);&nbsp;&nbsp;&nbsp;<span class="cpp__com">//&larr;[52]</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;EndPaint(hWnd,&nbsp;&amp;ps);&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cpp__com">//&larr;[53]</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cpp__keyword">break</span>;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cpp__keyword">case</span>&nbsp;WM_DESTROY:&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;PostQuitMessage(<span class="cpp__number">0</span>);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cpp__keyword">break</span>;&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cpp__com">//&nbsp;[省略]</span>&nbsp;
}&nbsp;
&nbsp;
<span class="cpp__com">//&nbsp;[省略]&nbsp;</span>&nbsp;
&nbsp;
<span class="cpp__com">//◆◆◆以下の関数を新たに追加</span>&nbsp;
&nbsp;
<span class="cpp__com">//&nbsp;デバイス依存の初期化(別例)</span>&nbsp;
<span class="cpp__com">//&nbsp;デバイスコンテキストとの相互運用版</span>&nbsp;
<span class="cpp__datatype">HRESULT</span>&nbsp;CreateDeviceResourcesAlt()&nbsp;&nbsp;<span class="cpp__com">//&larr;[54]</span>&nbsp;
{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cpp__datatype">HRESULT</span>&nbsp;hr&nbsp;=&nbsp;S_OK;&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cpp__com">//&nbsp;ファクトリが無ければ何もしない</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cpp__keyword">if</span>(&nbsp;pD2DFactory&nbsp;==&nbsp;NULL)&nbsp;<span class="cpp__keyword">return</span>&nbsp;E_FAIL;&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cpp__com">//&nbsp;DC互換のレンダーターゲットの作成(このブロックを変更)</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cpp__keyword">if</span>(&nbsp;pDCRenderTarget&nbsp;==&nbsp;NULL)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;D2D1_RENDER_TARGET_PROPERTIES&nbsp;props&nbsp;=&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cpp__com">//&larr;[55]</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;D2D1::RenderTargetProperties(&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cpp__com">//&larr;[56]</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;D2D1_RENDER_TARGET_TYPE_DEFAULT,&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;D2D1::PixelFormat(&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;DXGI_FORMAT_B8G8R8A8_UNORM,&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;D2D1_ALPHA_MODE_IGNORE&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;)&nbsp;,&nbsp;<span class="cpp__number">0</span>.0F,&nbsp;<span class="cpp__number">0</span>.0F,&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;D2D1_RENDER_TARGET_USAGE_GDI_COMPATIBLE&nbsp;&nbsp;<span class="cpp__com">//&larr;[57]</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;hr&nbsp;=&nbsp;pD2DFactory-&gt;CreateDCRenderTarget(&nbsp;&nbsp;&nbsp;<span class="cpp__com">//&larr;[58]</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&amp;props,&nbsp;&amp;pDCRenderTarget);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cpp__keyword">if</span>(!SUCCEEDED(hr))&nbsp;<span class="cpp__keyword">return</span>&nbsp;hr;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cpp__com">//&nbsp;ブラシの作成</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cpp__keyword">if</span>(pGreenBrush&nbsp;==&nbsp;NULL)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;hr&nbsp;=&nbsp;pDCRenderTarget-&gt;CreateSolidColorBrush(&nbsp;&nbsp;<span class="cpp__com">//&larr;[59]</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;D2D1::ColorF(<span class="cpp__number">0</span>.0F,&nbsp;<span class="cpp__number">1</span>.0F,&nbsp;<span class="cpp__number">0</span>.0F),&nbsp;&amp;pGreenBrush);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cpp__keyword">if</span>(!SUCCEEDED(hr))&nbsp;<span class="cpp__keyword">return</span>&nbsp;hr;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cpp__keyword">if</span>(pBlueBrush&nbsp;==&nbsp;NULL)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;hr&nbsp;=&nbsp;pDCRenderTarget-&gt;CreateSolidColorBrush(&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;D2D1::ColorF(<span class="cpp__number">0</span>.0F,&nbsp;<span class="cpp__number">0</span>.0F,&nbsp;<span class="cpp__number">1</span>.0F,&nbsp;<span class="cpp__number">0</span>.5F),&nbsp;&amp;pBlueBrush);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cpp__keyword">if</span>(!SUCCEEDED(hr))&nbsp;<span class="cpp__keyword">return</span>&nbsp;hr;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cpp__keyword">if</span>(pGradientBrush&nbsp;==&nbsp;NULL)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cpp__keyword">static</span>&nbsp;<span class="cpp__keyword">const</span>&nbsp;D2D1_GRADIENT_STOP&nbsp;stops[]&nbsp;=&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;&nbsp;&nbsp;<span class="cpp__number">0</span>.0f,&nbsp;&nbsp;{&nbsp;<span class="cpp__number">0</span>.0f,&nbsp;<span class="cpp__number">1</span>.0f,&nbsp;<span class="cpp__number">1</span>.0f,&nbsp;<span class="cpp__number">1</span>.0f&nbsp;}&nbsp;&nbsp;},&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;&nbsp;&nbsp;<span class="cpp__number">1</span>.0f,&nbsp;&nbsp;{&nbsp;<span class="cpp__number">0</span>.0f,&nbsp;<span class="cpp__number">0</span>.0f,&nbsp;<span class="cpp__number">1</span>.0f,&nbsp;<span class="cpp__number">0</span>.5f&nbsp;}&nbsp;&nbsp;},&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;};&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;hr&nbsp;=&nbsp;pDCRenderTarget-&gt;CreateGradientStopCollection(&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;stops,&nbsp;<span class="cpp__keyword">sizeof</span>(stops)/<span class="cpp__keyword">sizeof</span>(D2D1_GRADIENT_STOP),&nbsp;&amp;pGradientStops);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cpp__keyword">if</span>(!SUCCEEDED(hr))&nbsp;<span class="cpp__keyword">return</span>&nbsp;hr;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;hr&nbsp;=&nbsp;pDCRenderTarget-&gt;CreateLinearGradientBrush(&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;D2D1::LinearGradientBrushProperties(&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;D2D1::Point2F(<span class="cpp__number">100</span>.0F,&nbsp;<span class="cpp__number">120</span>.0F),&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;D2D1::Point2F(<span class="cpp__number">100</span>.0F,&nbsp;<span class="cpp__number">270</span>.0F)),&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;D2D1::BrushProperties(),&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;pGradientStops,&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&amp;pGradientBrush);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cpp__keyword">if</span>(!SUCCEEDED(hr))&nbsp;<span class="cpp__keyword">return</span>&nbsp;hr;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cpp__keyword">return</span>&nbsp;hr;&nbsp;
}&nbsp;
&nbsp;
<span class="cpp__com">//&nbsp;描画(別例)</span>&nbsp;
<span class="cpp__keyword">void</span>&nbsp;RenderAlt(<span class="cpp__datatype">HDC</span>&nbsp;hDC,&nbsp;LPRECT&nbsp;pRect)&nbsp;&nbsp;<span class="cpp__com">//&larr;[60]</span>&nbsp;
{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cpp__datatype">HRESULT</span>&nbsp;hr;&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;hr&nbsp;=&nbsp;CreateDeviceResourcesAlt();&nbsp;&nbsp;&nbsp;<span class="cpp__com">//&larr;[61]</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cpp__keyword">if</span>(!SUCCEEDED(hr))&nbsp;<span class="cpp__keyword">return</span>;&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;hr&nbsp;=&nbsp;pDCRenderTarget-&gt;BindDC(hDC,&nbsp;pRect);&nbsp;&nbsp;<span class="cpp__com">//&larr;[62]</span>&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;pDCRenderTarget-&gt;BeginDraw();&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cpp__com">//背景クリア</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;pDCRenderTarget-&gt;Clear(D2D1::ColorF(<span class="cpp__number">1</span>.0F,&nbsp;<span class="cpp__number">1</span>.0F,&nbsp;<span class="cpp__number">1</span>.0F));&nbsp;&nbsp;<span class="cpp__com">//&larr;[63]</span>&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cpp__com">//円の描画</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;D2D1_ELLIPSE&nbsp;ellipse1&nbsp;=&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;D2D1::Ellipse(D2D1::Point2F(<span class="cpp__number">120</span>.0F,&nbsp;<span class="cpp__number">120</span>.0F),&nbsp;<span class="cpp__number">100</span>.0F,&nbsp;<span class="cpp__number">100</span>.0F);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;pDCRenderTarget-&gt;DrawEllipse(ellipse1,&nbsp;pGreenBrush,&nbsp;<span class="cpp__number">10</span>.0F);&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cpp__com">//1つ目の四角形の描画</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;D2D1_RECT_F&nbsp;rect1&nbsp;=&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;D2D1::RectF(<span class="cpp__number">100</span>.0F,&nbsp;<span class="cpp__number">50</span>.0F,&nbsp;<span class="cpp__number">300</span>.0F,&nbsp;<span class="cpp__number">100</span>.F);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;pDCRenderTarget-&gt;FillRectangle(&amp;rect1,&nbsp;pBlueBrush);&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cpp__com">//2つ目の四角形の描画</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;D2D1_RECT_F&nbsp;rect2&nbsp;=&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;D2D1::RectF(<span class="cpp__number">100</span>.0F,&nbsp;<span class="cpp__number">120</span>.0F,&nbsp;<span class="cpp__number">250</span>.0F,&nbsp;<span class="cpp__number">270</span>.F);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;pDCRenderTarget-&gt;FillRectangle(&amp;rect2,&nbsp;pGradientBrush);&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;pDCRenderTarget-&gt;EndDraw();&nbsp;
}</pre>
</div>
</div>
</div>
<p>HDC に対応付けたレンダー ターゲットを使用するために、ここでは、デバイスに依存する初期化と描画処理に関して、それぞれ別の例として、[54] の CreateDeviceResourcesAlt 関数と、[60] の RenderAlt 関数を作成しました。</p>
<p>今までとの大きな違いは、デバイス コンテキスト (HDC) に対応付けたレンダー ターゲットを使用することです。今回のデバイス依存の初期化を行う CreateDeviceResourcesAlt 関数では、[58] のように、ファクトリ オブジェクトのインターフェイス (pD2DFactory) を使用して、CreateDCRenderTarget メンバー関数を呼び出し、デバイス コンテキスト向けのレンダー ターゲットを作成しています。レンダー ターゲットにアクセスするインターフェイス ポインターは、2
 番目の出力引数 (pcDCRenderTarget) に取得されます。このポインター変数はグローバル変数であり、例 10.2 の [3] に ID2D1DCRenderTarget* 型として宣言してあります。</p>
<p>この [58] の呼び出しで、1 番目の引数として渡すプロパティの構造体 props は、[55] に定義されています。ここでも [56] のように、D2D1::RenderTargetProperties ヘルパー関数を使用して、構造体を構築しています。この構造体を構築する際は、[57] に記述されたように、これから作成するレンダー ターゲットが GDI 互換である点が指定されています。</p>
<p>[59] 以降のブラシの作成に関しては、この新しいレンダー ターゲット (pDCRenderTarget) に関して行う点を除けば、今までと同様です。</p>
<p><a href="#top" target="_self"><img src="http://www.microsoft.com/japan/msdn/nodehomes/graphics/top.gif" border="0" alt="">ページのトップへ</a></p>
<hr>
<h2 id="10" style="font-size:120%; margin-top:20px">10. HDC を介した相互運用</h2>
<p>レンダー ターゲットやブラシなど必要なオブジェクトの準備ができたので、実際の描画手順を確認しましょう。</p>
<p>今回の描画処理も、WM_PAINT メッセージが発生した際に行います。まず、今までの描画処理である部分をコメントアウトしたのち、[46] 以降を追加します。</p>
<p>ここでは、従来の GDI の描画も行うので、一般的な GDI の描画手順である [46] の BeginPaint 関数呼び出しから、[53] の EndPaint 関数呼び出しまでを追加します。[46] の時点で、GDI の描画に必要なデバイス コンテキスト (変数 hdc) を取得し、[47] 以降では、このデバイス コンテキストを利用して、従来の GDI の手順でテキストと円を描画しています。ここでは、関連して [44] と [45] に GDI に必要なオブジェクトの変数も定義しています。</p>
<p>なお、[47] で定義した RECT 構造体 (変数 rect) は、このウィンドウのクライアント領域のサイズを退避するため、[48] のように GetClientRect 関数を呼び出しています。この変数 rect が表す領域は、[48] 以降で、テキストや円を描画する際の位置を特定するために使用されています。</p>
<p>さらに、このデバイス コンテキストを用いた GDI による描画の過程で、[52] のように、RenderAlt 関数を呼び出して、Direct2D による描画も追加しています。この関数呼び出しで引数として必要となる情報は、デバイス コンテキスト (変数 hdc) と領域指定 (変数 rect) です。</p>
<p>ここでは、[50] および [51] に示すとおり、もともとクライアント領域全体を表していた変数 rect に関して、上部の高さ 30、左辺の幅 300 の部分を排除するように補正しています。この情報を、RenderAlt 関数に渡すことによって、Direct2D の描画は、図 10.2 のように右半分へずれて表示されるようになります。</p>
<p>次に、実際の Direct2D の描画を行う [60] の RenderAlt 関数の内部を確認しましょう。</p>
<p>まず、[61] では新たに作成したデバイス依存の初期化である CreateDeviceResourcesAlt 関数を呼び出しています。</p>
<p>そして重要なのは、[62] に示したとおり、今回使用しているレンダー ターゲット オブジェクト (変数 pDCRenderTarger) の BindDC メンバー関数呼び出しです。この関数の引数には、レンダー ターゲットに対応付けるデバイス コンテキスト (hDC) と描画領域 (pRect) を渡し、具体的な描画先を指定しています。この 2 つの引数は、もともとは、[52] の RenderAlt 関数呼び出しによって渡されたものです。</p>
<p>[63] 以降の描画手順については、描画対象がデバイス コンテキスト向けのレンダー ターゲット (pDCRenderTarget) である点を除けば、今までと同様です。</p>
<p>これで一通り確認が済みました。これを実行すると、図 10.2 のように表示されます。ここでは、手順を示すのが目的なので、まったく同じ円を異なる 2 つの方法で 1 つのウィンドウに描画しましたが、この手順を使用すれば、既存の GDI ベースのグラフィックに、Direct2D ベースの任意の新しい描画表現を追加できるようになります。</p>
<p>なお、先述のとおり GDI ではアンチエイリアスが行われていないので、GDI を用いた左側の円のほうは輪郭が粗く、右側の Direct2D を用いた円のほうは滑らかになっています。</p>
<p><img src="http://i1.code.msdn.s-msft.com/visualc-7e652493/image/file/42262/1/image005.jpg" alt="図 10.5" width="521" height="144"></p>
<p><strong>図 10.5 GDI (左) と Direct2D (右) の比較</strong></p>
<p><a href="#top" target="_self"><img src="http://www.microsoft.com/japan/msdn/nodehomes/graphics/top.gif" border="0" alt="">ページのトップへ</a></p>
<hr>
<h2 id="11" style="font-size:120%; margin-top:20px">11. まとめ</h2>
<p>今回は、グラフィック関連のテクノロジについて概観したのち、Direct2D の基本的な使い方について確認しました。図形描画のほか、グラデーションやアルファ ブレンディングなど、見栄えを良くするいくつかの実装方法について確認しました。</p>
<p>GDI と異なり、Direct2D は COM ベースの API ですが、従来の Windows アプリケーションの WM_PAINT などの描画の仕組みの中で利用できるので、プログラム全体が大きく変わることはありません。また、GDI のデバイスコンテキストに対して描画できるので、既存のソフトウェア資産を有効活用しつつ、Direct2D の新機能をアプリケーションの中に組み込むこともできます。</p>
<div style="margin:10px 0px; padding:10px 10px 0px 10px; border:double 1px #CCCCCC">
<p style="margin:0"><strong>Note:</strong></p>
<p>ここでは、一般的な Windows アプリケーションに対して、Direct2D を利用しましたが、MFC アプリケーションでも Direct2D を利用するこはできます。以下の逆引きでは、MFC のビュー (CView) に対して Direct2D で描画する手順が紹介されています。</p>
<ul>
<li><a href="http://code.msdn.microsoft.com/ja-jp/VisualC-howto-d2f1efe1/">逆引き (10) - MFC アプリケーションのビューの中で、Direct2D を使用する
</a></li></ul>
</div>
<p><a href="#top" target="_self"><img src="http://www.microsoft.com/japan/msdn/nodehomes/graphics/top.gif" border="0" alt="">ページのトップへ</a></p>
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
