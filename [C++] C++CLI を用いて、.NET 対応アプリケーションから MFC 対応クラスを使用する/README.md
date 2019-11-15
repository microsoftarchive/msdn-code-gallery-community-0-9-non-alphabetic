# [C++] C++/CLI を用いて、.NET 対応アプリケーションから MFC 対応クラスを使用する
## License
- Apache License, Version 2.0
## Technologies
- MFC
- Visual Studio 2010
- Visual C++ 2010
- C++/CLI
## Topics
- 逆引きサンプル コード
- Visual C++ プログラミング
- .NET からの MFC クラスの利用
## Updated
- 08/15/2011
## Description

<p>執筆者: <a href="http://msdn.microsoft.com/ja-jp/gg585574#yajima" target="_blank">
エディフィストラーニング株式会社 矢嶋 聡</a></p>
<p>動作確認環境: Visual Studio 2010 (MFC を利用できるエディション、Express よりも上位のエディション)、検&#35388;環境は Windows 7</p>
<hr>
<p>ここでは、以下の例 1 ～例 4 に示す MFC ベースのダイアログ ボックス クラス (ネイティブ コード) を題材にして、このクラスを .NET 対応プログラムから利用できるようするためのサンプル コードを示します (プログラム実行の様子は後述の図 8.2 を参照)。このサンプルでは、C&#43;&#43;/CLI を用いて、MFC の初期化、MFC で使用するリソースを持つモジュールの指定、および .NET 版向けマネージ コードのラッパー クラス作成を行います。ここでは、ダイアログ ボックス用の MFC クラスを用いていますが、このサンプルで使用する手法は、他の
 MFC クラスでも利用できるでしょう。</p>
<p><strong>例 1. ファイル: MyMFCDlg.h</strong></p>
<p><strong></p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>C&#43;&#43;</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">スクリプトの編集</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">cplusplus</span>

<div class="preview">
<pre class="cplusplus"><span class="cpp__preproc">#pragma&nbsp;once</span><span class="cpp__preproc">&nbsp;
#include&nbsp;&quot;MyMFCDlgRes.h&quot;</span>&nbsp;
&nbsp;
<span class="cpp__com">//&nbsp;CMyMFCDlg&nbsp;ダイアログボックス</span>&nbsp;
<span class="cpp__keyword">class</span>&nbsp;CMyMFCDlg&nbsp;:&nbsp;<span class="cpp__keyword">public</span>&nbsp;CDialog&nbsp;
{&nbsp;
<span class="cpp__com">//&nbsp;コンストラクション</span>&nbsp;
<span class="cpp__keyword">public</span>:&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;CMyMFCDlg(CWnd*&nbsp;pParent&nbsp;=&nbsp;NULL);&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cpp__com">//&nbsp;標準コンストラクター</span>&nbsp;
&nbsp;
<span class="cpp__com">//&nbsp;ダイアログ&nbsp;データ</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cpp__keyword">enum</span>&nbsp;{&nbsp;IDD&nbsp;=&nbsp;IDD_MYMFCDLG_DIALOG&nbsp;};&nbsp;&nbsp;<span class="cpp__com">//&nbsp;ダイアログのリソースID</span>&nbsp;
&nbsp;
<span class="cpp__keyword">protected</span>:&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cpp__keyword">virtual</span>&nbsp;<span class="cpp__keyword">void</span>&nbsp;DoDataExchange(CDataExchange*&nbsp;pDX);&nbsp;&nbsp;<span class="cpp__com">//&nbsp;DDX/DDV&nbsp;サポート</span>&nbsp;
&nbsp;
<span class="cpp__com">//&nbsp;実装</span>&nbsp;
<span class="cpp__keyword">public</span>:&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;CString&nbsp;m_strEdit1;&nbsp;
};</pre>
</div>
</div>
</div>
<div class="endscriptcode">&nbsp;</div>
</strong>
<p></p>
<p><strong>例 2. ファイル: MyMFCDlg.cpp</strong></p>
<p><strong></p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>C&#43;&#43;</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">スクリプトの編集</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">cplusplus</span>

<div class="preview">
<pre class="cplusplus"><span class="cpp__preproc">#include&nbsp;&quot;Stdafx.h&quot;</span><span class="cpp__preproc">&nbsp;
#include&nbsp;&quot;MyMFCDlg.h&quot;</span>&nbsp;
&nbsp;
CMyMFCDlg::CMyMFCDlg(CWnd*&nbsp;pParent&nbsp;<span class="cpp__mlcom">/*=NULL*/</span>)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;:&nbsp;CDialog(CMyMFCDlg::IDD,&nbsp;pParent)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;,&nbsp;m_strEdit1(_T(<span class="cpp__string">&quot;&quot;</span>))&nbsp;
{&nbsp;
}&nbsp;
&nbsp;
<span class="cpp__keyword">void</span>&nbsp;CMyMFCDlg::DoDataExchange(CDataExchange*&nbsp;pDX)&nbsp;
{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;CDialog::DoDataExchange(pDX);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;DDX_Text(pDX,&nbsp;IDC_EDIT1,&nbsp;m_strEdit1);&nbsp;
}</pre>
</div>
</div>
</div>
<div class="endscriptcode">&nbsp;</div>
</strong>
<p></p>
<p><strong>例 3. ファイル: MyMFCDlgRes.h</strong></p>
<p class="06">&nbsp;</p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>C&#43;&#43;</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">スクリプトの編集</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">cplusplus</span>

<div class="preview">
<pre class="cplusplus"><span class="cpp__preproc">#pragma&nbsp;once</span><span class="cpp__preproc">&nbsp;
&nbsp;
#define&nbsp;IDD_MYMFCDLG_DIALOG&nbsp;5001</span><span class="cpp__preproc">&nbsp;
#define&nbsp;IDC_EDIT1&nbsp;7001</span></pre>
</div>
</div>
</div>
<div class="endscriptcode">&nbsp;</div>
<p><strong>例 4. ファイル: MyMFCDlgRes.rc</strong></p>
<p><strong></p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>C&#43;&#43;</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">スクリプトの編集</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">cplusplus</span>

<div class="preview">
<pre class="cplusplus"><span class="cpp__preproc">#include&nbsp;&lt;afxres.h&gt;</span><span class="cpp__preproc">&nbsp;
#include&nbsp;&quot;MyMFCDlgRes.h&quot;</span>&nbsp;
&nbsp;
IDD_MYMFCDLG_DIALOG&nbsp;DIALOGEX&nbsp;<span class="cpp__number">0</span>,&nbsp;<span class="cpp__number">0</span>,&nbsp;<span class="cpp__number">192</span>,&nbsp;<span class="cpp__number">67</span>&nbsp;
STYLE&nbsp;DS_SETFONT&nbsp;|&nbsp;WS_POPUP&nbsp;|&nbsp;WS_VISIBLE&nbsp;|&nbsp;WS_CAPTION&nbsp;|&nbsp;WS_SYSMENU&nbsp;|&nbsp;WS_THICKFRAME&nbsp;
CAPTION&nbsp;<span class="cpp__string">&quot;My&nbsp;MFC&nbsp;Dialog&quot;</span>&nbsp;
FONT&nbsp;<span class="cpp__number">9</span>,&nbsp;<span class="cpp__string">&quot;MS&nbsp;UI&nbsp;Gothic&quot;</span>,&nbsp;<span class="cpp__number">0</span>,&nbsp;<span class="cpp__number">0</span>,&nbsp;0x1&nbsp;
BEGIN&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;EDITTEXT&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;IDC_EDIT1,<span class="cpp__number">8</span>,<span class="cpp__number">8</span>,<span class="cpp__number">164</span>,<span class="cpp__number">14</span>,ES_AUTOHSCROLL&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;DEFPUSHBUTTON&nbsp;&nbsp;&nbsp;<span class="cpp__string">&quot;OK&quot;</span>,IDOK,<span class="cpp__number">73</span>,<span class="cpp__number">45</span>,<span class="cpp__number">50</span>,<span class="cpp__number">14</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;PUSHBUTTON&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cpp__string">&quot;キャンセル&quot;</span>,IDCANCEL,<span class="cpp__number">134</span>,<span class="cpp__number">45</span>,<span class="cpp__number">50</span>,<span class="cpp__number">14</span>&nbsp;
END</pre>
</div>
</div>
</div>
<div class="endscriptcode">&nbsp;</div>
</strong>
<p></p>
<p>これから取り上げるマネージ コード版のラッパー クラスでは、その内部でネイティブ コード向けの C&#43;&#43; を用いて、MFC クラスにアクセスします。そのために、C&#43;&#43;/CLI のソース コードと従来の C&#43;&#43; のソース コードが混在するハイブリッド型のプロジェクトが必要となります。最初に、次の手順でプロジェクトを用意します。</p>
<ol>
<li>.NET 向け (CLR 向け) の「クラス ライブラリ」プロジェクト テンプレートを用いて、プロジェクトを新規に作成します。ここでは、プロジェクト名を「MyMFCInterop」とします。
</li><li>このプロジェクトを MFC 対応にするため、プロジェクトのプロパティ ページを表示させ (ソリューション エクスプローラー上で、MyMFCInterop プロジェクト ノードを右クリックして [プロパティ] をクリック)、左のツリーでは、[構成プロパティ] ノード配下の [全般] を選択します。このときの右ペインでは、「MFC の使用」欄を「共有 DLL で MFC を使う」を選択します (図 8.1)。なお、「共通言語ランタイム サポート」欄が、「共通言語ランタイム サポート (/clr)」になっていることを確認します。この設定によってハイブリッド型になります。
<p><img src="http://i1.code.msdn.s-msft.com/visualc-howto-76f9cd9e/image/file/41364/1/img08-01.gif" alt="" width="600" height="448"></p>
<p><strong>図 8.1 MFC 対応およびハイブリッド型の設定</strong></p>
<div style="padding:0pt 15px; margin:0pt 0pt 30px; background-color:#efefef; border:1px solid #333333">
<h4 style="margin:0.75em 0pt -0.5em">Note:</h4>
<p>ここでは簡単にするため、文字セットについては、既定の Unicode 文字セットを使用することを前提にしています。また、ターゲット プラットフォームも既定の x86 を使用しています。</p>
</div>
</li><li>MFC ライブラリを利用可能にするため、ヘッダー Stdafx.h を次のように修正します (_WIN32_WINNT マクロに定義されて数値は、ターゲット OS のバージョンに合わせて変更してください)。
<p><strong>例 5. ファイル: Stdafx.h</strong></p>
<strong>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>C&#43;&#43;</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">スクリプトの編集</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">cplusplus</span>

<div class="preview">
<pre class="cplusplus"><span class="cpp__preproc">#pragma&nbsp;once</span><span class="cpp__preproc">&nbsp;
&nbsp;
#define&nbsp;_WIN32_WINNT&nbsp;&nbsp;0x0601&nbsp;//&nbsp;Windows&nbsp;7&nbsp;を設定しています</span><span class="cpp__preproc">&nbsp;
#include&nbsp;&lt;afxwin.h&gt;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;//&nbsp;MFC&nbsp;のコアおよび標準コンポーネント</span><span class="cpp__preproc">&nbsp;
#include&nbsp;&lt;afxext.h&gt;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;//&nbsp;MFC&nbsp;の拡張部分</span></pre>
</div>
</div>
</div>
<div class="endscriptcode">&nbsp;</div>
</strong></li><li>前述の 4 つのファイル (MyMFCDlg.h、MyMFCDlg.cpp、MyMFCDlgRes.h、ならびに MyMFCDlgRes.rc) を MyMFCInterop プロジェクトに追加します（まだ不完全ですが、ここまででビルドすることができます)。
<p>これで、ハイブリッド型のプロジェクトに、再利用したい MFC ベースのクラスが追加されました。あとは、このクラスを使用するマネージ ラッパーを作成するほか、MFC を使用する上で必要な初期化のコードを追加します。</p>
<p>プロジェクトの既存のファイル「MyMFCInterop.h」に、次に示すように、2 種類のマネージ版のクラスを追加してください。</p>
<p><strong>例 6. ファイル: MyMFCInterop.h</strong></p>
<strong>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>C&#43;&#43;</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">スクリプトの編集</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">cplusplus</span>

<div class="preview">
<pre class="cplusplus"><span class="cpp__preproc">#pragma&nbsp;once</span><span class="cpp__preproc">&nbsp;
#include&nbsp;&quot;MyMFCDlg.h&quot;</span>&nbsp;
&nbsp;
<span class="cpp__keyword">using</span>&nbsp;<span class="cpp__keyword">namespace</span>&nbsp;System;&nbsp;
<span class="cpp__keyword">using</span>&nbsp;<span class="cpp__keyword">namespace</span>&nbsp;System::Runtime::InteropServices;&nbsp;&nbsp;
&nbsp;
<span class="cpp__keyword">namespace</span>&nbsp;MyMFCInterop&nbsp;{&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cpp__com">//&nbsp;MFC環境で必要なグローバルオブジェクト</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;CWinApp&nbsp;app;&nbsp;&nbsp;<span class="cpp__com">//&larr;[1]</span>&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cpp__keyword">public</span>&nbsp;ref&nbsp;<span class="cpp__keyword">class</span>&nbsp;CMFCUtil&nbsp;abstract&nbsp;sealed&nbsp;&nbsp;<span class="cpp__com">//&larr;[2]</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cpp__keyword">private</span>:&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cpp__keyword">static</span>&nbsp;<span class="cpp__datatype">bool</span>&nbsp;isInitialized&nbsp;=&nbsp;<span class="cpp__keyword">false</span>;&nbsp;<span class="cpp__com">//初期化済みの判定フラグ　&larr;[3]</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;internal:&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cpp__com">//&nbsp;MFCライブラリの初期化</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cpp__keyword">static</span>&nbsp;<span class="cpp__datatype">bool</span>&nbsp;Initialize()&nbsp;&nbsp;<span class="cpp__com">//&larr;[4]</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cpp__keyword">if</span>(isInitialized)&nbsp;<span class="cpp__keyword">return</span>&nbsp;<span class="cpp__keyword">true</span>;&nbsp;<span class="cpp__com">//既に初期化済みの場合は何もしない&nbsp;&larr;[5]</span>&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cpp__datatype">HMODULE</span>&nbsp;hAppModule&nbsp;=&nbsp;::GetModuleHandle(NULL);&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cpp__com">//&larr;[6]</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cpp__datatype">HMODULE</span>&nbsp;hDllModule&nbsp;=&nbsp;::GetModuleHandle(_T(<span class="cpp__string">&quot;MyMFCInterop.dll&quot;</span>));&nbsp;&nbsp;<span class="cpp__com">//&larr;[7]</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cpp__keyword">if</span>&nbsp;(hAppModule&nbsp;==&nbsp;NULL&nbsp;||&nbsp;hDllModule&nbsp;==&nbsp;NULL)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cpp__keyword">return</span>&nbsp;<span class="cpp__keyword">false</span>;&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cpp__com">//&nbsp;MFCライブラリの初期化</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cpp__keyword">if</span>(&nbsp;!&nbsp;::AfxWinInit(hAppModule,&nbsp;NULL,&nbsp;::GetCommandLine(),&nbsp;<span class="cpp__number">0</span>)&nbsp;)&nbsp;&nbsp;&nbsp;&nbsp;<span class="cpp__com">//&larr;[8]</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cpp__keyword">return</span>&nbsp;<span class="cpp__keyword">false</span>;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cpp__com">//&nbsp;リソースを含むモジュールのハンドルを指定</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;::AfxSetResourceHandle(hDllModule);&nbsp;&nbsp;&nbsp;&nbsp;<span class="cpp__com">//&larr;[9]</span>&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;isInitialized&nbsp;=&nbsp;<span class="cpp__keyword">true</span>;&nbsp;<span class="cpp__com">//&larr;[10]</span>&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cpp__keyword">return</span>&nbsp;<span class="cpp__keyword">true</span>;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;};&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cpp__com">//&nbsp;MFC版ダイアログのマネージラッパー</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cpp__keyword">public</span>&nbsp;ref&nbsp;<span class="cpp__keyword">class</span>&nbsp;CMyWrapperDlg&nbsp;&nbsp;&nbsp;&nbsp;<span class="cpp__com">//&larr;[11]</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cpp__keyword">private</span>:&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cpp__com">//&nbsp;MFC版のネイティブダイアログ</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;CMyMFCDlg*&nbsp;m_pNativeDlg;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cpp__com">//&larr;[12]</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cpp__keyword">public</span>:&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cpp__com">//&nbsp;コンストラクター</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;CMyWrapperDlg()&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cpp__keyword">if</span>(&nbsp;!&nbsp;CMFCUtil::Initialize()&nbsp;)&nbsp;<span class="cpp__com">//念のため、MFCライブラリの初期化&nbsp;//&larr;[13]</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;System::GC::SuppressFinalize(<span class="cpp__keyword">this</span>);&nbsp;&nbsp;<span class="cpp__com">//ファィナライザー呼び出しの抑止</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cpp__keyword">throw</span>&nbsp;gcnew&nbsp;Exception(<span class="cpp__string">&quot;MFCライブラリの初期化に失敗ました。&quot;</span>);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;m_pNativeDlg&nbsp;=&nbsp;<span class="cpp__keyword">new</span>&nbsp;CMyMFCDlg();&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cpp__keyword">public</span>:&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cpp__com">//&nbsp;データのやり取り</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;property&nbsp;String^&nbsp;EDIT1&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cpp__com">//&larr;[14]</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;String^&nbsp;get()&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cpp__com">//&larr;[15]</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cpp__datatype">LPCWSTR</span>&nbsp;pStrEdit1&nbsp;=&nbsp;(<span class="cpp__datatype">LPCWSTR</span>)&nbsp;m_pNativeDlg-&gt;m_strEdit1;&nbsp;&nbsp;<span class="cpp__com">//&larr;[16]</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;String&nbsp;^str1&nbsp;=&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Marshal::PtrToStringUni(IntPtr((Int32)pStrEdit1));&nbsp;<span class="cpp__com">//32ビット環境が前提</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cpp__keyword">return</span>&nbsp;str1;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cpp__keyword">void</span>&nbsp;set(String^&nbsp;value)&nbsp;&nbsp;<span class="cpp__com">//&larr;[17]</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;IntPtr&nbsp;p1;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;p1&nbsp;=&nbsp;Marshal::StringToHGlobalUni(&nbsp;value&nbsp;);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;m_pNativeDlg-&gt;m_strEdit1&nbsp;=&nbsp;(<span class="cpp__datatype">LPCWSTR</span>)&nbsp;p1.ToPointer();&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Marshal::FreeHGlobal(p1);&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cpp__keyword">public</span>:&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cpp__com">//&nbsp;モーダル表示</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cpp__datatype">bool</span>&nbsp;ShowDialog()&nbsp;&nbsp;&nbsp;&nbsp;<span class="cpp__com">//&larr;[18]</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cpp__datatype">INT_PTR</span>&nbsp;result;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;result&nbsp;=&nbsp;m_pNativeDlg-&gt;DoModal();&nbsp;&nbsp;&nbsp;<span class="cpp__com">//&larr;[19]</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cpp__keyword">switch</span>(result)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cpp__keyword">case</span>&nbsp;IDOK:&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cpp__keyword">return</span>&nbsp;<span class="cpp__keyword">true</span>;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cpp__keyword">case</span>&nbsp;IDCANCEL:&nbsp;<span class="cpp__keyword">return</span>&nbsp;<span class="cpp__keyword">false</span>;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cpp__keyword">default</span>:&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;ASSERT(FALSE);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cpp__keyword">return</span>&nbsp;<span class="cpp__keyword">false</span>;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cpp__keyword">public</span>:&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cpp__com">//デストラクター</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;~CMyWrapperDlg()&nbsp;&nbsp;&nbsp;&nbsp;<span class="cpp__com">//&larr;[20]</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cpp__keyword">this</span>-&gt;!CMyWrapperDlg();&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cpp__com">//ファイナライザー</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;!CMyWrapperDlg()&nbsp;&nbsp;&nbsp;&nbsp;<span class="cpp__com">//&larr;[21]</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cpp__keyword">delete</span>&nbsp;m_pNativeDlg;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;};&nbsp;
}</pre>
</div>
</div>
</div>
<div class="endscriptcode">&nbsp;</div>
</strong>
<p>この MyMFCInterop プロジェクトのソース コードはこれで全部です。これをビルドすると、.NET 対応の DLL ファイル (アセンブリ ファイル) MyMFCInterop.dll が出力されます。</p>
<p>この例では、MFC を使用する上で必要な初期化などを行う [2] の CMFCUtil クラスと、MFC ベースのダイアログ ボックスをラップした [11] の CMyWrapperDlg クラスが定義されています。なお、[2] のCMFCUtil クラスは、[4] の静的メンバー関数 (メソッド) を持つユーティリティ クラス (インスタンスを作成しないクラス) なので、[4] のクラス定義には、abstract 修飾子と sealed 修飾子が付いています。</p>
<p>MFC を使用する際に必要となる初期化は [4] の Initialize メンバー関数の中に記述されています。特に重要な点は、[8] の AfxWinInit 関数呼び出しと、[9] の AfxSetResourceHandle 関数呼び出しです。ここで、この 2 つの関数の役割について確認しましょう。</p>
<p>なお、ここでは Initialize メソッドが 2 度呼びだれても問題ないように、[3] のフラグで初期化済みか否かの判定をして、初期化済みの場合は、[5] のように初期化をスキップするようにしました。この実装を外して簡単にするのであれば、このフラグに係る部分、つまり、[3]、[5]、および、[10] は削除してもかまいません。</p>
<div style="padding:0pt 15px; margin:0pt 0pt 30px; background-color:#efefef; border:1px solid #333333">
<h4 style="margin:0.75em 0pt -0.5em">Note:</h4>
<p>このサンプルのフラグの実装は、シングル スレッドを前提にしており、スレッド セーフではありません。</p>
</div>
<p>まず、AfxWinInit 関数です。通常の MFC アプリケーションでは、MFC ライブラリが提供する WinMain 関数 (メイン関数) の中から、AfxWinInit 関数を呼び出して初期化を行っています。そのため、純粋な MFC アプリケーションでは、プログラマーが明示的に AfxWinInit 関数を呼び出す必要はありません。しかし、今回のクラス ライブラリ プロジェクト (MyMFCInterop.dll) は .NET から利用されることを想定しており、.NET 側の Main 関数 (メイン
 メソッド) が使用されるので、[8] のようにプログラマーが明示的に AfxWinInit 関数を呼び出す必要があります。</p>
<p>なお、第 1 引数 (hAppModule) のモジュール ハンドルは、[6] の GetModuleHandle 関数を呼び出して取得しています。[6] の GetModuleHandle 関数の引数は NULL になっているので、ここで返されるハンドルは、プロセスを作成した EXE ファイルのモジュール ハンドル (アプリケーションのインスタンス ハンドル) です。</p>
<p>また、AfxWinInit 関数を呼び出すためには、[1] のように CWinApp (または、その派生クラス) のインスタンスを、グローバル オブジェクトとして宣言しておく必要があります。</p>
<p>一方、[9] の AfxSetResourceHandle 関数では、MFC ライブラリなどが使用するリソースを含むモジュールのハンドルを指定します。このハンドルは、[7] の GetModuleHandle 関数呼び出しによって取得しており、[7] の引数が示すように、このクラス ライブラリ自身の MyMFCInterop.dll のハンドルを取得しています。この DLL のハンドルを [9] の AfxSetResourceHandle 関数呼び出しに指定することで、MFC ライブラリは必要なリソースをこの
 DLL からロードできるようになります。たとえば、この MyMFCInterop.dll に含まれる、例 1 の CMyMFCDlg ダイアログ ボックス クラスも、この DLL に含まれる例 4 のダイアログ リソースを読み込むことができます。逆に言えば、[9] で適切なハンドルを指定しないと、正しくリソースを読み込むことができません。</p>
<p>次に、[11] のラッパー クラス CMyWrapperDlg を確認します。このクラスの内部では、[12] の m_pNativeDlg メンバー変数 (ポインター) を使用して、ネイティブ コード版のCMyMFGDlg ダイアログ ボックス クラスのオブジェクトを管理しています。</p>
<p>また、この例では、この CMyWrapperDlg クラスを使用する利用者が、MFC ライブラリの初期化を意識せずに済むように、コンストラクターの中では [13] のように、MFC ライブラリの初期化を行っています。万が一、MFC ライブラリの初期化に失敗し、[13] の Initialize メンバー関数呼び出しの戻り値が false の場合は、if ブロックの中に示したように、ファィナライザーの呼び出しが不要なので抑止したのち、例外を発生することにしています。(本来であれば、MFC 初期化失敗を意味する独自の
 Exception 派生クラスをスローすべきですが、ここでは簡単にするため、Exception クラスをスローしています。)</p>
<p>なお、このコンストラクターの実装を簡単にする方法としては、[13] の if ブロックを削除して、代わりに、CMFCUtil::Initialize メンバー関数をパブリックとして公開し、利用者が明示的に呼び出す方法もあります。</p>
<p>[14] の EDIT1 プロパティは、CMyMFGDlg ダイアログ ボックスの m_strEdit1 メンバー変数 (EDIT コントロールのデータに相当) にアクセスするためのラッパーです。[15] の get アクセサーの中では、[16] のように m_strEdit1 メンバー変数から、ネイティブ文字列のポインターを取得したのち、String 型マネージ オブジェクトに変換して返しています。[17] の set アクセサーでは、この逆の変換を行っています。</p>
<div style="padding:0pt 15px 15px; margin:0pt 0pt 30px; background-color:#efefef; border:1px solid #333333">
<h4 style="margin:0.75em 0pt -0.5em">Note:</h4>
<p>ネイティブ文字列と String 型マネージ オブジェクトとの変換については、以下の記事にも記載があります。</p>
<ul>
<li><a href="http://code.msdn.microsoft.com/VisualC-ee06b200/">[連載! とことん VC&#43;&#43;] 第 8 回 C&#43;&#43;/CLI を利用した相互運用 ～ネイティブ C&#43;&#43; から .NET の利用～</a><br>
9. ネイティブ コード用の文字列と .NET 版の文字列との相互変換 </li></ul>
</div>
<p>モーダル ダイアログを表示しているのは、[18] の ShowDialog メンバー関数であり、[19] にあるようにネイティブ版のダイアログ ボックスの DoModal メンバー関数を呼び出しています。</p>
<p>また、後処理としては、プログラマーが .NET 側から明示的に呼び出す [20] のデストラクター (IDisposable インターフェイスの Dispose メソッド) と、ガベージ コレクションによって呼び出される [21] のファイナライザー (Finalize メソッド) という 2 種類があります。ファイナライザーが呼び出される際には、マネージ関連の後処理はガベージ コレクションによって全て自動的に行われるので、プログラマーが行うべき後処理は、ネイティブ オブジェクトの後処理だけです。よって、[21]
 のファイナライザーの内部でも、「delete m_pNativeDlg;」のように、ネイティブ版のダイアログ ボックスのオブジェクトのみ削除しています。また、いずれにしても、この例ではマネージ オブジェクトに関して後処理は必要ないので、[20] のデストラクターの内部でも、「this-&gt;!CMyWrapperDlg();」というように、ファイナライザーを呼び出して、同様にネイティブ オブジェクトを削除しています。</p>
<div style="padding:0pt 15px 15px; margin:0pt 0pt 30px; background-color:#efefef; border:1px solid #333333">
<h4 style="margin:0.75em 0pt -0.5em">Note:</h4>
<p>デストラクターとファイナライザーで行うべき実装については、以下の記事にも記載があります。</p>
<ul>
<li><a href="http://code.msdn.microsoft.com/VisualC-a1dc1f1d">[連載! とことん VC&#43;&#43;] 第 9 回 C&#43;&#43;/CLI を利用した相互運用 ～.NET からのネイティブ C&#43;&#43; 資産の再利用～</a>
</li></ul>
</div>
<p>この MyMFCInterop.dll を C# のコンソール アプリケーションから使用する場合、次のようなコードが考えられます。</p>
<p><strong>例 7. (参考) C# からの利用</strong></p>
<strong>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>C&#43;&#43;</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">スクリプトの編集</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">cplusplus</span>

<div class="preview">
<pre class="cplusplus"><span class="cpp__keyword">using</span>&nbsp;System;&nbsp;
<span class="cpp__keyword">using</span>&nbsp;<a class="libraryLink" href="http://msdn.microsoft.com/ja-JP/library/System.Windows.Forms.aspx" target="_blank" title="Auto generated link to System.Windows.Forms">System.Windows.Forms</a>;&nbsp;
<span class="cpp__keyword">using</span>&nbsp;MyMFCInterop;&nbsp;
&nbsp;
<span class="cpp__keyword">namespace</span>&nbsp;CSConApp&nbsp;
{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cpp__keyword">class</span>&nbsp;Program&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cpp__keyword">static</span>&nbsp;<span class="cpp__keyword">void</span>&nbsp;Main(<span class="cpp__datatype">string</span>[]&nbsp;args)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;CMyWrapperDlg&nbsp;dlg&nbsp;=&nbsp;null;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cpp__datatype">string</span>&nbsp;msg;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cpp__keyword">try</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;dlg&nbsp;=&nbsp;<span class="cpp__keyword">new</span>&nbsp;CMyWrapperDlg();&nbsp;&nbsp;<span class="cpp__com">//CMyWrapperDlgインスタンス作成</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cpp__keyword">catch</span>(Exception&nbsp;ex)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;MessageBox.Show(ex.Message);&nbsp;&nbsp;<span class="cpp__com">//C#側でのメッセージボックス</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cpp__keyword">return</span>;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;dlg.EDIT1&nbsp;=&nbsp;<span class="cpp__string">&quot;テストデータ&quot;</span>;&nbsp;&nbsp;<span class="cpp__com">//CMyWrapperDlg::EDIT1プロパティに設定</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cpp__keyword">if</span>&nbsp;(dlg.ShowDialog())&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cpp__com">//CMyWrapperDlg::ShowModalメンバー関数呼び出し</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;msg&nbsp;=&nbsp;dlg.EDIT1;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cpp__com">//CMyWrapperDlg::EDIT1プロパティを参照</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cpp__keyword">else</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;msg&nbsp;=&nbsp;<span class="cpp__string">&quot;キャンセルしました。&quot;</span>;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;MessageBox.Show(msg,&nbsp;<span class="cpp__string">&quot;Managed&nbsp;MessageBox&quot;</span>);&nbsp;&nbsp;<span class="cpp__com">//C#側でのメッセージボックス</span>&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;dlg.Dispose();&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cpp__com">//CMyWrapperDlg::~CMyWrapperDlg呼び出し</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
}</pre>
</div>
</div>
</div>
<div class="endscriptcode">&nbsp;</div>
</strong>
<p>これを実行すると、Main メソッド内の最後の ShowDialog メンバー関数を呼び出した際に、次図のように MFC 版のダイアログ ボックスが表示されます。</p>
<p><img src="http://i1.code.msdn.s-msft.com/visualc-howto-76f9cd9e/image/file/41365/1/img08-02.gif" alt="" width="352" height="139"></p>
<p><strong>図 8.2 C# のプログラム コードから呼び出された MFC 版のダイアログ ボックス</strong></p>
</li></ol>
<hr style="clear:both; margin-bottom:8px; margin-top:20px">
<div></div>
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
<p>&nbsp;</p>
<p style="margin-top:20px"><a href="#top"><img src="http://www.microsoft.com/japan/msdn/nodehomes/graphics/top.gif" border="0" alt="">ページのトップへ</a></p>
