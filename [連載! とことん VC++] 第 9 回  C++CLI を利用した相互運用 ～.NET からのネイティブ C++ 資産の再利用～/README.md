# [連載! とことん VC++] 第 9 回  C++/CLI を利用した相互運用 ～.NET からのネイティブ C++ 資産の再利用～
## License
- Apache License, Version 2.0
## Technologies
- Visual Studio 2010
- Visual C++ 2010
## Topics
- Visual C++ プログラミング
- 連載! とことん VC++
## Updated
- 08/22/2011
## Description

<div id="top"></div>
<p>執筆者: <a href="http://msdn.microsoft.com/ja-jp/gg585574#yajima" target="_blank">
エディフィストラーニング株式会社 矢嶋 聡</a></p>
<hr>
<h2>目次</h2>
<ol>
<li><a href="#01">はじめに</a> </li><li><a href="#02">今回作成するサンプル アプリケーション</a> </li><li><a href="#03">.NET 向けの基本的な実装 ～単純なラッパーではない点に注意～</a> </li><li><a href="#04">ラッパーのためのハイブリッド型のプロジェクトの準備</a> </li><li><a href="#05">ラッパー クラスの作成</a> </li><li><a href="#06">ラッパー クラスの公開 ～アクセス修飾子の注意点～</a> </li><li><a href="#07">各メンバーの定義</a> </li><li><a href="#08">後処理の注意点 ～デストラクターとファイナライザー～</a> </li><li><a href="#09">デストラクターで実装すべきこと</a> </li><li><a href="#10">ファイナライザーで実装すべきこと</a> </li><li><a href="#11">サンプルの利用</a> </li><li><a href="#12">まとめ</a> </li></ol>
<hr>
<h2 id="01" style="font-size:120%; margin-top:20px">1. はじめに</h2>
<p>今回は前回に引き続き、C&#43;&#43;/CLI (Common Language Infrastructure) について取り上げます。前回では、次図の C&#43;&#43;/CLI を利用した実装パターンを挙げて、それぞれのメリットやデメリットについて説明したのち、主に (3) のパターンを説明しました。今回は (4) のパターンを取り上げます。</p>
<p><img src="http://i1.code.msdn.s-msft.com/visualc-a1dc1f1d/image/file/41268/1/img_0901.gif" alt="図 9.1" width="600" height="464"></p>
<p><strong>図 9.1 前回取り上げた Visual C&#43;&#43; における .NET Framework 関連の実装パターン</strong></p>
<p>この (4) のパターンは、C&#43;&#43; ネイティブ コードと C&#43;&#43;/CLI によるマネージ コードを 1 つのアプリケーションの中で併用する「ハイブリッド型」の 1 つであり、ネイティブな C&#43;&#43; で記述されたクラスなどの既存資産を、他の .NET 対応アプリケーションから利用するための形態です。</p>
<p>今回は、このような形態において、C&#43;&#43; 側での実装の特徴や注意点などを中心に、具体的なサンプルを用いながら確認していきます。</p>
<div style="margin:10px 0px; padding:10px 10px 0px 10px; border:double 1px #CCCCCC">
<p style="margin:0px"><strong>Note:</strong></p>
<p>C&#43;&#43;/CLI の言語構文の詳細は、以下を参照してください。</p>
<ul>
<li><a href="http://msdn.microsoft.com/ja-jp/library/xey702bw.aspx" target="_blank">Language Features for Targeting the CLR (英語)</a>
</li></ul>
</div>
<p><a href="#top" target="_self"><img src="http://www.microsoft.com/japan/msdn/nodehomes/graphics/top.gif" border="0" alt="">ページのトップへ</a></p>
<hr>
<h2 id="02" style="font-size:120%; margin-top:20px">2. 今回作成するサンプル アプリケーション</h2>
<p>今回のサンプルでは、既存のソフトウェア資産として、ネイティブ コード版の C&#43;&#43; のクラスが既にあることを前提にしており、このクラスを .NET 対応アプリケーションから再利用できるようにするため、C&#43;&#43;/CLI を用いて、必要な実装を追加します (プロジェクトの作り方や入力方法は後述します)。</p>
<p><strong>例 9.1 今回題材にする既存資産としてのネイティブ コード版の C&#43;&#43; クラス</strong></p>
<p><strong>ファイル名: FileCache.h</strong></p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>C&#43;&#43;</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">スクリプトの編集</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">cplusplus</span>

<div class="preview">
<pre id="codePreview" class="cplusplus"><span class="cpp__preproc">#pragma&nbsp;once</span><span class="cpp__preproc">&nbsp;
&nbsp;
#define&nbsp;FILECACHE_OUTOF_RANGE&nbsp;(-1)&nbsp;&nbsp;//インデックス範囲外のエラーコード</span>&nbsp;
&nbsp;
<span class="cpp__com">//&nbsp;ファイルをメモリにキャッシュ</span>&nbsp;
<span class="cpp__keyword">class</span>&nbsp;CFileCache&nbsp;
{&nbsp;
<span class="cpp__keyword">private</span>:&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cpp__datatype">char</span>*&nbsp;m_pData;&nbsp;&nbsp;<span class="cpp__com">//メモリ上のバッファポインター</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cpp__datatype">int</span>&nbsp;m_nLength;&nbsp;&nbsp;<span class="cpp__com">//メモリ上のデータサイズ(バイト数)</span>&nbsp;
<span class="cpp__keyword">public</span>:&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;CFileCache(<span class="cpp__keyword">void</span>);&nbsp;&nbsp;<span class="cpp__com">//コンストラクター</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;~CFileCache(<span class="cpp__keyword">void</span>);&nbsp;<span class="cpp__com">//デストラクター</span>&nbsp;
<span class="cpp__keyword">private</span>:&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cpp__datatype">BOOL</span>&nbsp;AllocData(<span class="cpp__datatype">int</span>&nbsp;size);&nbsp;<span class="cpp__com">//メモリ確保、メンバー変数設定</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cpp__keyword">void</span>&nbsp;ClearData();&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cpp__com">//メモリ解放、メンバー変数初期化</span>&nbsp;
<span class="cpp__keyword">public</span>:&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cpp__datatype">BOOL</span>&nbsp;Load(<span class="cpp__datatype">LPCWSTR</span>&nbsp;filePath);&nbsp;&nbsp;<span class="cpp__com">//ファイル読み込み</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cpp__datatype">char</span>&nbsp;operator[](<span class="cpp__datatype">int</span>&nbsp;ndx);&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cpp__com">//インデックスでのアクセス</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cpp__datatype">int</span>&nbsp;GetLength()&nbsp;{&nbsp;<span class="cpp__keyword">return</span>&nbsp;m_nLength;&nbsp;}&nbsp;<span class="cpp__com">//データサイズの取得(バイト数)</span>&nbsp;
};</pre>
</div>
</div>
</div>
<p><strong>ファイル名: FileCache.cpp</strong></p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>C&#43;&#43;</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">スクリプトの編集</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">cplusplus</span>

<div class="preview">
<pre id="codePreview" class="cplusplus"><span class="cpp__preproc">#include&nbsp;&quot;StdAfx.h&quot;</span><span class="cpp__preproc">&nbsp;
#include&nbsp;&quot;FileCache.h&quot;</span>&nbsp;
&nbsp;
CFileCache::CFileCache(<span class="cpp__keyword">void</span>)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;:&nbsp;m_pData(NULL),&nbsp;m_nLength(<span class="cpp__number">0</span>)&nbsp;
{&nbsp;
}&nbsp;
&nbsp;
CFileCache::~CFileCache(<span class="cpp__keyword">void</span>)&nbsp;
{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;ClearData();&nbsp;
}&nbsp;
&nbsp;
<span class="cpp__datatype">BOOL</span>&nbsp;CFileCache::AllocData(<span class="cpp__datatype">int</span>&nbsp;size)&nbsp;
{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;m_pData&nbsp;=&nbsp;(<span class="cpp__datatype">char</span>*)&nbsp;::HeapAlloc(&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;::GetProcessHeap(),&nbsp;HEAP_ZERO_MEMORY,&nbsp;(<span class="cpp__datatype">SIZE_T</span>)size);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cpp__keyword">if</span>(m_pData&nbsp;==&nbsp;NULL)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;m_nLength&nbsp;=&nbsp;<span class="cpp__number">0</span>;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cpp__keyword">return</span>&nbsp;FALSE;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;m_nLength&nbsp;=&nbsp;size;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cpp__keyword">return</span>&nbsp;TRUE;&nbsp;
}&nbsp;
&nbsp;
<span class="cpp__keyword">void</span>&nbsp;CFileCache::ClearData()&nbsp;
{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cpp__keyword">if</span>(m_pData&nbsp;!=&nbsp;NULL)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;::HeapFree(::GetProcessHeap(),&nbsp;<span class="cpp__number">0</span>,&nbsp;m_pData);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;m_pData&nbsp;=&nbsp;NULL;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;m_nLength&nbsp;=&nbsp;<span class="cpp__number">0</span>;&nbsp;
}&nbsp;
&nbsp;
<span class="cpp__com">//&nbsp;ファイルの読み込み</span>&nbsp;
<span class="cpp__datatype">BOOL</span>&nbsp;CFileCache::Load(<span class="cpp__datatype">LPCWSTR</span>&nbsp;filePath)&nbsp;
{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cpp__com">//&nbsp;既存のメモリクリア</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;ClearData();&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cpp__com">//&nbsp;ファイルのオープン</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cpp__datatype">HANDLE</span>&nbsp;handle&nbsp;=&nbsp;::CreateFileW(&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;filePath,&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cpp__com">//ファイル名&nbsp;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;GENERIC_READ,&nbsp;&nbsp;<span class="cpp__com">//読み込み</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cpp__number">0</span>,&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cpp__com">//排他的アクセス(共有無し)</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;NULL,&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cpp__com">//セキュリティ情報</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;OPEN_EXISTING,&nbsp;<span class="cpp__com">//既存ファイルを開く</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;FILE_ATTRIBUTE_NORMAL,&nbsp;&nbsp;<span class="cpp__com">//ファイル属性&nbsp;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;NULL&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cpp__com">//読み込み時のテンプレートファイル</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cpp__keyword">if</span>(handle&nbsp;==&nbsp;INVALID_HANDLE_VALUE)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cpp__keyword">return</span>&nbsp;FALSE;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cpp__com">//ファイルサイズの範囲確認(int型の範囲か)</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;LARGE_INTEGER&nbsp;size;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cpp__datatype">BOOL</span>&nbsp;result&nbsp;=&nbsp;::GetFileSizeEx(handle,&nbsp;&amp;size);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cpp__keyword">if</span>(!result&nbsp;||&nbsp;size.HighPart&nbsp;!=&nbsp;<span class="cpp__number">0</span>&nbsp;||&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;size.LowPart&nbsp;&gt;&nbsp;(<span class="cpp__datatype">DWORD</span>)&nbsp;0x7fffffff)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;::CloseHandle(handle);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cpp__keyword">return</span>&nbsp;FALSE;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cpp__com">//メモリ確保</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cpp__keyword">if</span>(!AllocData((<span class="cpp__datatype">int</span>)size.LowPart)&nbsp;)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;::CloseHandle(handle);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cpp__keyword">return</span>&nbsp;FALSE;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cpp__com">//読み込み</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cpp__datatype">DWORD</span>&nbsp;resultLength;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;result&nbsp;=&nbsp;::ReadFile(&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;handle,&nbsp;(<span class="cpp__datatype">LPVOID</span>)m_pData,&nbsp;(<span class="cpp__datatype">DWORD</span>)m_nLength,&nbsp;&amp;resultLength,&nbsp;NULL);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;::CloseHandle(handle);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cpp__keyword">if</span>(!result)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;ClearData();&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cpp__keyword">return</span>&nbsp;FALSE;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cpp__com">//読み込みサイズに修正</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;m_nLength&nbsp;=&nbsp;(<span class="cpp__datatype">int</span>)resultLength;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cpp__com">//読み込み成功</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cpp__keyword">return</span>&nbsp;TRUE;&nbsp;
}&nbsp;
&nbsp;
<span class="cpp__com">//&nbsp;インデックスを用いたアクセス</span>&nbsp;
<span class="cpp__datatype">char</span>&nbsp;CFileCache::operator[](<span class="cpp__datatype">int</span>&nbsp;ndx)&nbsp;
{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cpp__keyword">if</span>(ndx&nbsp;&lt;=&nbsp;<span class="cpp__number">0</span>&nbsp;||&nbsp;ndx&nbsp;&gt;=&nbsp;m_nLength)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cpp__keyword">throw</span>&nbsp;(<span class="cpp__datatype">int</span>)FILECACHE_OUTOF_RANGE;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cpp__keyword">return</span>&nbsp;m_pData[ndx];&nbsp;
}</pre>
</div>
</div>
</div>
<p>ここで、このクラス (CFileCache クラス) の機能を簡単に確認しておきます。</p>
<p>このクラスでは、ファイル全体をメモリ上に読み込み、インデックスを使用して、バイト単位でランダムに参照できるように実装されています。C&#43;&#43; を用いて、このクラスのオブジェクトにアクセスする際には、次のようなコードを用います。</p>
<p><strong>例 9.2 (参考) CFileCache オブジェクトを利用する C&#43;&#43; のサンプル コード</strong></p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>C&#43;&#43;</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">スクリプトの編集</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">cplusplus</span>

<div class="preview">
<pre id="codePreview" class="cplusplus"><span class="cpp__preproc">#include&nbsp;&quot;stdafx.h&quot;</span><span class="cpp__preproc">&nbsp;
#include&nbsp;&quot;FileCache.h&quot;</span>&nbsp;
&nbsp;
<span class="cpp__datatype">int</span>&nbsp;_tmain(<span class="cpp__datatype">int</span>&nbsp;argc,&nbsp;_TCHAR*&nbsp;argv[])&nbsp;
{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;CFileCache*&nbsp;pFileCache&nbsp;=&nbsp;<span class="cpp__keyword">new</span>&nbsp;CFileCache();&nbsp;&nbsp;<span class="cpp__com">//&larr;[1]</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cpp__datatype">BOOL</span>&nbsp;b&nbsp;=&nbsp;pFileCache-&gt;Load(L<span class="cpp__string">&quot;Test.txt&quot;</span>);&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cpp__com">//&larr;[2]</span>&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cpp__keyword">try</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;::printf(<span class="cpp__string">&quot;Length=%d\n&quot;</span>,&nbsp;pFileCache-&gt;GetLength());&nbsp;&nbsp;<span class="cpp__com">//&larr;[3]</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;::printf(<span class="cpp__string">&quot;%c\n&quot;</span>,&nbsp;(*pFileCache)[<span class="cpp__number">2</span>]);&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cpp__com">//&larr;[4]</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;::printf(<span class="cpp__string">&quot;%c\n&quot;</span>,&nbsp;(*pFileCache)[<span class="cpp__number">5</span>]);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cpp__keyword">catch</span>(<span class="cpp__datatype">int</span>&nbsp;code)&nbsp;&nbsp;<span class="cpp__com">//&larr;[5]</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;::printf(<span class="cpp__string">&quot;error=%d\n&quot;</span>,&nbsp;code);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cpp__keyword">delete</span>&nbsp;pFileCache;&nbsp;&nbsp;<span class="cpp__com">//&larr;[6]</span>&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cpp__keyword">return</span>&nbsp;<span class="cpp__number">0</span>;&nbsp;
}</pre>
</div>
</div>
</div>
<p>[1] でオブジェクトを作成したのち、[2] のように Load メンバー関数を呼び出して、特定のファイルを読み込むと、オブジェクト内部ではファイル サイズ分のメモリが確保され、ファイル全体がメモリ内にキャッシュされます。</p>
<p>そして、[3] のように GetLength() 関数を呼び出すと、読み込んだファイルのバイト数が分かるほか、[4] のように &quot;オブジェクト [インデックス]&quot; という形式で、メモリ上にキャッシュされたデータに対して、バイト単位でランダムにアクセスできます (今回は簡単にするため読み取り専用)。このため、前述の CFileCache クラスでは、演算子 [ ] をオーバーロードしています。</p>
<p>また、インデックスでアクセスした際に、インデックスが範囲外の場合は例外が発生するので、[5] の catch ブロックで捕捉しています。</p>
<p>最後に、[6] でオブジェクトを削除することで、オブジェクト内部のキャッシュも削除されます。</p>
<p>今回作成するサンプルでは、例 9.2 と同様の方法で .NET 対応プログラムからもこの CFileCache クラスを利用できるようにするため、C&#43;&#43;/CLI を用いて実装を追加していきます。</p>
<p>まずは、基本的な実装方法のポイントから確認していきましょう。</p>
<p><a href="#top" target="_self"><img src="http://www.microsoft.com/japan/msdn/nodehomes/graphics/top.gif" border="0" alt="">ページのトップへ</a></p>
<hr>
<h2 id="03" style="font-size:120%; margin-top:20px">3. .NET 向けの基本的な実装 ～単純なラッパーではない点に注意～</h2>
<p>例 9.1 のネイティブ コード版の CFileCache クラスを .NET 環境から利用させるための、最も基本的な実装方法は、C&#43;&#43;/CLI を用いてマネージ コードのクラスを作成し、このマネージ クラスを介して、ネイティブ コードのクラスを利用させる方法です。つまり、ネイティブ コード版の CFileCache オブジェクトにアクセスするための、マネージ コード版のラッパー クラスを作ります。</p>
<p>この方法では、ネイティブ コードのクラスに Load というメンバー関数があるのなら、ラップするマネージ クラスにも、Load メンバー関数 (メソッド) を作成し、そのマネージ コード版の Load メンバー関数を経由して、ネイティブ コード版の Load メンバー関数を呼び出します。たとえば、前述の CFileCache クラスのラッパーを FileCacheWrapper クラスとして実装した場合、最終的には、C# から利用する場合、次のようなコードが考えられます。</p>
<p><strong>例 9.3 (参考) CFileCache クラスのラッパーを利用する C# のサンプル コード</strong></p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>C#</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">スクリプトの編集</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">csharp</span>

<div class="preview">
<pre id="codePreview" class="csharp"><span class="cs__keyword">using</span>&nbsp;System;&nbsp;
<span class="cs__keyword">using</span>&nbsp;MyInteropLib;&nbsp;
&nbsp;
<span class="cs__keyword">namespace</span>&nbsp;CSConApp&nbsp;
{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">class</span>&nbsp;Program&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">static</span>&nbsp;<span class="cs__keyword">void</span>&nbsp;Main()&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;FileCacheWrapper&nbsp;fileCache&nbsp;=&nbsp;<span class="cs__keyword">new</span>&nbsp;FileCacheWrapper();&nbsp;<span class="cs__com">//&larr;[1]</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">bool</span>&nbsp;result&nbsp;=&nbsp;fileCache.Load(<span class="cs__string">&quot;Test.txt&quot;</span>);&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__com">//&larr;[2]</span>&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">try</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Console.WriteLine(<span class="cs__string">&quot;Length={0}&quot;</span>,&nbsp;fileCache.Length);&nbsp;&nbsp;<span class="cs__com">//&larr;[3]</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Console.WriteLine(<span class="cs__string">&quot;{0}&quot;</span>,&nbsp;(<span class="cs__keyword">char</span>)&nbsp;fileCache[<span class="cs__number">2</span>]);&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__com">//&larr;[4]</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Console.WriteLine(<span class="cs__string">&quot;{0}&quot;</span>,&nbsp;(<span class="cs__keyword">char</span>)&nbsp;fileCache[<span class="cs__number">5</span>]);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">catch</span>&nbsp;(Exception&nbsp;ex)&nbsp;&nbsp;<span class="cs__com">//&larr;[5]</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Console.WriteLine(ex.GetType());&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;fileCache.Dispose();&nbsp;&nbsp;<span class="cs__com">//&larr;[6]</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
}</pre>
</div>
</div>
</div>
<p>この例 9.3 の C#のサンプル コードに付けられた番号は、例 9.2 の C&#43;&#43; のサンプル コードに付けられた各番号に対応しています。C# の構文についての説明は割愛しますが、C&#43;&#43; をご存じの方であれば、このサンプルが行っていることは想像が付くと思います。</p>
<p>C# の場合も、基本的にはラッパー クラスを介して、例 9.2 の C&#43;&#43; の場合と同様の操作を行えます。</p>
<p>しかし、単にラップするだけなら簡単なのですが、ネイティブ コードのオブジェクトと、.NET 対応のマネージ オブジェクトとでは、後処理などの振る舞いに違いがあるため、注意すべき点があります。</p>
<p>たとえば .NET の管理下にあるマネージ ヒープに確保されたオブジェクトであれば、明示的に削除するなどの後処理を行わなくとも、ガベージ コレクションなどによって、自動的に削除されます。これに対して、ネイティブ コードのオブジェクトでは、ヒープに確保したオブジェクトに対して、プログラマーが責任を持って削除する必要があります。つまり、オブジェクトの作成から削除に至るオブジェクトの管理方法やライフタイムに若干の違いがあり、この差異を考慮した実装が必要になるのです。</p>
<p>このあとは、この差異を考慮した実装も含め、このようなラッパー クラスを実装し、その特徴をいくつか確認していきます。</p>
<div style="margin:10px 0px; padding:10px 10px 0px 10px; border:double 1px #CCCCCC">
<p style="margin:0px"><strong>Note:</strong></p>
<p>この後のサンプルでは、Visual C&#43;&#43; 2010 Express を用いながら、順に作成していきます。また、作成したサンプルの動作を確認するには、Visual C# 2010 Express などの他の言語製品も必要になりますが、机上でも確認ができるように、C# での実行結果なども示しています。</p>
</div>
<p><a href="#top" target="_self"><img src="http://www.microsoft.com/japan/msdn/nodehomes/graphics/top.gif" border="0" alt="">ページのトップへ</a></p>
<hr>
<h2 id="04" style="font-size:120%; margin-top:20px">4. ラッパーのためのハイブリッド型のプロジェクトの準備</h2>
<p>前述のようなラッパークラスを実装するには、C&#43;&#43;/CLI を用いてマネージ コード対応のクラス本体を実装するほか、このラッパー クラスの内部ではネイティブ コードのクラスにアクセスするために、ネイティブ コードのプログラムも併記することになります。この理由から、最初にマネージ コードとネイティブ コードを併用する「ハイブリッド型」に対応したプロジェクトを用意する必要があります。</p>
<p>ネイティブ コードのクラス本体の実装とラッパー クラスの実装とを、必ずしも 1 つのプロジェクトにまとめる必要はありませんが、ここでは簡単にするため、ネイティブ コードのクラス本体のソース コードと、ラッパー クラスのソース コードを 1 つのプロジェクトにまとめることにします。</p>
<p>まずは、次の手順でプロジェクトを作成し、プロジェクト内にネイティブ コードの CFileCache クラス (例 9.1) を追加します。</p>
<ol>
<li>「クラス ライブラリ」という名前のプロジェクト テンプレートを使用して、プロジェクトを新規作成します。プロジェクト名は「MyInteropLib」と指定し、ソリューション名は「MyInteropLibSol」と指定します。プロジェクトの作成場所は任意です。
</li><li>MyInteropLib プロジェクトが作成されたら、プロジェクト内の以下の 2 つのファイル (Class1 クラスの定義) は不要なので削除します。
<ul>
<li>MyInteropLib.h (削除) </li><li>MyInteropLib.cpp (削除) </li></ul>
</li><li>例 9.1 のネイティブ コード版 CFileCache クラスを記述した 2 つのファイルを、以下に挙げる名前のまま、この MyInteropLib プロジェクトに追加します。
<ul>
<li>CFileCache.h (追加) </li><li>CFileCache.cpp (追加) </li></ul>
</li><li>追加した CFileCache クラスは Windows API を使用しているため、Stdafx.h ヘッダー ファイルに、以下のように #include ディレクティブを追加します。
<p><strong>例 9.4 Windows API を利用可能なようにヘッダーを修正</strong></p>
<p><strong>ファイル名: Stdafx.h</strong></p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>C&#43;&#43;</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">スクリプトの編集</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">cplusplus</span>

<div class="preview">
<pre id="codePreview" class="cplusplus"><span class="cpp__preproc">#pragma&nbsp;once</span><span class="cpp__preproc">&nbsp;
&nbsp;
#include&nbsp;&lt;Windows.h&gt;</span></pre>
</div>
</div>
</div>
</li><li>ビルドを行い、正常終了することを確認します。 </li></ol>
<p>これで、このあと必要となる「ハイブリッド型」のプロジェクトの準備ができました。このクラス ライブラリ プロジェクトの主な目的は、.NET 対応のクラス ライブラリ (DLL) を作成することですが、プロジェクトのプロパティ ページで、「共通言語ランタイム サポート」の設定を確認すると、次図のように「共通言語ランタイム サポート (/clr)」となっています。前回触れたように、これは「ハイブリッド型」のアプリケーションを構築するための設定です。</p>
<p><img src="http://i1.code.msdn.s-msft.com/visualc-a1dc1f1d/image/file/41269/1/img_0902.gif" alt="図 9.2" width="600" height="450"></p>
<p><strong>図 9.2 マネージコードとネイティブコードを併用可能な設定</strong></p>
<p><a href="#top" target="_self"><img src="http://www.microsoft.com/japan/msdn/nodehomes/graphics/top.gif" border="0" alt="">ページのトップへ</a></p>
<hr>
<h2 id="05" style="font-size:120%; margin-top:20px">5. ラッパー クラスの作成</h2>
<p>それでは、ネイティブ コード版の CFileCache クラスをラッブした、マネージ コード版のクラスを作成してみましょう。ここでは、FileCacheWrapper という名前のクラスを作成します。</p>
<p>まずは、次の手順でクラスを追加しましょう。</p>
<ol>
<li>ソリューション エスクプローラーのツリー上で、MyInteropLib プロジェクト ノードを右クリックし、ショートカット メニューが表示されたら、[追加]、[クラス] の順にクリックします。
</li><li>[クラスの追加] ダイアログ ボックスが表示されたら、一覧から「C&#43;&#43; クラス」を選択して、追加をクリックします。 </li><li>次図のように、「汎用 C&#43;&#43; クラス ウィザード」が起動するので、右側中央の［マネージ］チェック ボックスがチェックされていることを確認します。クラス名欄には「FileCacheWrapper」と入力し、ファイル名は既定のままにして、[完了] ボタンをクリックします。
</li></ol>
<p><img src="http://i1.code.msdn.s-msft.com/visualc-a1dc1f1d/image/file/41270/1/img_0903.gif" alt="図 9.3" width="600" height="388"></p>
<p><strong>図 9.3 マネージ クラスの追加</strong></p>
<p>[マネージ] チェック ボックスをチェックすることで、マネージ コード対応クラス (マネージ クラス) のソース コードのひな形が生成されます。</p>
<p>FileCacheWrapper クラスのひな形が生成されたら、CFileCache クラスのラッパー クラスとするため、次のように修正してください。(個々の意味については、順に説明します。)</p>
<p><strong>例 9.5 FileCacheWrapper クラス</strong></p>
<p><strong>ファイル名: FileCacheWrapper.h</strong></p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>C&#43;&#43;</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">スクリプトの編集</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">cplusplus</span>

<div class="preview">
<pre id="codePreview" class="cplusplus"><span class="cpp__preproc">#pragma&nbsp;once</span><span class="cpp__preproc">&nbsp;
&nbsp;
#include&nbsp;&quot;FileCache.h&quot;</span>&nbsp;
&nbsp;
<span class="cpp__keyword">using</span>&nbsp;<span class="cpp__keyword">namespace</span>&nbsp;System;&nbsp;
&nbsp;
<span class="cpp__keyword">namespace</span>&nbsp;MyInteropLib&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cpp__com">//&larr;[1]</span>&nbsp;
{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;ref&nbsp;<span class="cpp__keyword">class</span>&nbsp;ManagedData;&nbsp;&nbsp;<span class="cpp__com">//&larr;[2]</span>&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cpp__keyword">public</span>&nbsp;ref&nbsp;<span class="cpp__keyword">class</span>&nbsp;FileCacheWrapper&nbsp;&nbsp;<span class="cpp__com">//&larr;[3]</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cpp__keyword">private</span>:&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;CFileCache*&nbsp;m_pCache;&nbsp;&nbsp;&nbsp;<span class="cpp__com">//&larr;[4]</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;ManagedData^&nbsp;m_MData;&nbsp;&nbsp;&nbsp;<span class="cpp__com">//&larr;[5]</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cpp__keyword">public</span>:&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;FileCacheWrapper();&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cpp__com">//&larr;[6]</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;~FileCacheWrapper();&nbsp;&nbsp;&nbsp;&nbsp;<span class="cpp__com">//&larr;[7]</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;!FileCacheWrapper();&nbsp;&nbsp;&nbsp;&nbsp;<span class="cpp__com">//&larr;[8]</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cpp__keyword">public</span>:&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cpp__datatype">bool</span>&nbsp;Load(String&nbsp;^filePath);&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cpp__com">//&larr;[9]</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;property&nbsp;unsigned&nbsp;<span class="cpp__datatype">char</span>&nbsp;<span class="cpp__keyword">default</span>[<span class="cpp__datatype">int</span>]&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cpp__com">//&larr;[10]</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;unsigned&nbsp;<span class="cpp__datatype">char</span>&nbsp;get(<span class="cpp__datatype">int</span>&nbsp;ndx)&nbsp;&nbsp;<span class="cpp__com">//&larr;[11]</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cpp__keyword">if</span>(ndx&nbsp;&lt;&nbsp;<span class="cpp__number">0</span>&nbsp;||&nbsp;ndx&nbsp;&gt;=&nbsp;m_pCache-&gt;GetLength())&nbsp;&nbsp;<span class="cpp__com">//&larr;[12]</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cpp__keyword">throw</span>&nbsp;gcnew&nbsp;IndexOutOfRangeException();&nbsp;&nbsp;<span class="cpp__com">//&larr;[13]</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cpp__keyword">return</span>&nbsp;(*m_pCache)[ndx];&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cpp__com">//&larr;[14]</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;property&nbsp;<span class="cpp__datatype">int</span>&nbsp;Length&nbsp;&nbsp;<span class="cpp__com">//&larr;[15]</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cpp__datatype">int</span>&nbsp;get()&nbsp;{&nbsp;<span class="cpp__keyword">return</span>&nbsp;m_pCache-&gt;GetLength();&nbsp;}&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;};&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;ref&nbsp;<span class="cpp__keyword">class</span>&nbsp;ManagedData&nbsp;&nbsp;<span class="cpp__com">//&larr;[16]</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cpp__keyword">public</span>:&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;ManagedData()&nbsp;{}&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cpp__keyword">public</span>:&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;~ManagedData()&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cpp__keyword">this</span>-&gt;!ManagedData();&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;!ManagedData()&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;};&nbsp;
}</pre>
</div>
</div>
</div>
<p><strong>ファイル名: FileCacheWrapper.cpp</strong></p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>C&#43;&#43;</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">スクリプトの編集</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">cplusplus</span>

<div class="preview">
<pre id="codePreview" class="cplusplus"><span class="cpp__preproc">#include&nbsp;&quot;StdAfx.h&quot;</span><span class="cpp__preproc">&nbsp;
#include&nbsp;&quot;FileCacheWrapper.h&quot;</span>&nbsp;
&nbsp;
<span class="cpp__keyword">using</span>&nbsp;<span class="cpp__keyword">namespace</span>&nbsp;System;&nbsp;
<span class="cpp__keyword">using</span>&nbsp;<span class="cpp__keyword">namespace</span>&nbsp;System::Runtime::InteropServices;&nbsp;&nbsp;
&nbsp;
<span class="cpp__keyword">using</span>&nbsp;<span class="cpp__keyword">namespace</span>&nbsp;MyInteropLib;&nbsp;
&nbsp;
FileCacheWrapper::FileCacheWrapper()&nbsp;&nbsp;<span class="cpp__com">//&larr;[17]</span>&nbsp;
{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;m_pCache&nbsp;=&nbsp;<span class="cpp__keyword">new</span>&nbsp;CFileCache();&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cpp__com">//&larr;[18]</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;m_MData&nbsp;&nbsp;=&nbsp;gcnew&nbsp;ManagedData();&nbsp;&nbsp;&nbsp;<span class="cpp__com">//&larr;[19]</span>&nbsp;
}&nbsp;
&nbsp;
<span class="cpp__datatype">bool</span>&nbsp;FileCacheWrapper::Load(String^&nbsp;filePath)&nbsp;&nbsp;<span class="cpp__com">//&larr;[20]</span>&nbsp;
{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;IntPtr&nbsp;p1;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;p1&nbsp;=&nbsp;Marshal::StringToHGlobalUni(filePath);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cpp__datatype">BOOL</span>&nbsp;b&nbsp;=&nbsp;m_pCache-&gt;Load((<span class="cpp__datatype">LPCWSTR</span>)p1.ToPointer());&nbsp;&nbsp;<span class="cpp__com">//&larr;[21]</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;Marshal::FreeHGlobal(p1);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cpp__keyword">return</span>&nbsp;(b)&nbsp;?&nbsp;<span class="cpp__keyword">true</span>&nbsp;:&nbsp;<span class="cpp__keyword">false</span>;&nbsp;
}&nbsp;
&nbsp;
FileCacheWrapper::~FileCacheWrapper()&nbsp;&nbsp;<span class="cpp__com">//&larr;[21]</span>&nbsp;
{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cpp__keyword">delete</span>&nbsp;m_MData;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cpp__com">//&larr;[22]</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cpp__keyword">this</span>-&gt;!FileCacheWrapper();&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cpp__com">//&larr;[23]</span>&nbsp;
}&nbsp;
&nbsp;
FileCacheWrapper::!FileCacheWrapper()&nbsp;&nbsp;<span class="cpp__com">//&larr;[24]</span>&nbsp;
{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cpp__keyword">delete</span>&nbsp;m_pCache;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cpp__com">//&larr;[25]</span>&nbsp;
}</pre>
</div>
</div>
</div>
<p>まず、全般的な構成について確認します。</p>
<p>ラッパー クラス FileCacheWrapper は、[3] に定義されており、前回触れたように「ref class」と記述されているので、これは参照型のクラスです。</p>
<p>このクラス内部では、[4] に CFileCache オブジェクトのポインター変数 m_pFileCache を用意しており、必要に応じて、このポインターを使用して、CFileCache オブジェクトにアクセスします。たとえば、[20] の Load メソッドが呼び出されると、[21] のようにポインター変数 m_pFileCache を介して、同名の Load メンバー関数を呼び出しています。ラッパー クラスの他のメンバーも、基本的には同様の方法で、ネイティブ版のオブジェクトにアクセスします。</p>
<p>また、この FileCacheWrapper クラスでは、[5] のように、マネージ クラス ManagedData のオブジェクトもメンバーとして追加しました。この ManagedData の定義は、[16] にあります。</p>
<p>結局のところ、ラッパー クラスである FileCacheWrapper は、そのメンバーとして (いわば子オブジェクトとして)、[4] の CFileCache 型のネイティブ オブジェクトと、[5] の ManagedData 型のマネージ オブジェクトという 2 種類のオブジェクトを持っていることになります。このうち、後者の ManagedData オブジェクト自体は特別な機能を実装していませんが、特に後処理において、これら 2 種類のオブジェクトの扱いに注意すべき点があるので、このような構成にしました。</p>
<p>このあとは、このサンプル コードの中で、いくつか特徴と注意点を確認してみましょう。</p>
<p><a href="#top" target="_self"><img src="http://www.microsoft.com/japan/msdn/nodehomes/graphics/top.gif" border="0" alt="">ページのトップへ</a></p>
<hr>
<h2 id="06" style="font-size:120%; margin-top:20px">6. ラッパー クラスの公開 ～アクセス修飾子の注意点～</h2>
<p>この例 9.5 の C&#43;&#43;/CLI を用いたサンプル コードでも、private や public などのアクセス修飾子が登場し、その使い方は従来の C&#43;&#43; とほぼ同様です。ただし、従来の C&#43;&#43; におけるアクセス修飾子と若干の違いがあります。</p>
<p>ネイティブ コードにおいる C&#43;&#43; のアクセス修飾子は、ソース コードにおいて、型 (クラス) の外からアクセスできるか否かなどの制御は可能ですが、プログラム ファイルの外部からアクセスできるか否かを制御する効力はありません。たとえば、DLL ファイルに C&#43;&#43; のクラスを実装し、そのクラスを DLL ファイルの外部から利用できるように公開するには、クラスをエクスポートするための専用の記述が必要になります。</p>
<p>一方、.NET のマネージ コードでは、public であることは、型 (クラス) の外部からアクセスできるだけでなく、DLL ファイル (正確にはアセンブリ ファイルという) の外部からアクセス可能であることを意味しています。エクスポートなどの特殊な記述は必要ありません。</p>
<p>ここでは、[3] の FileCacheWrapper クラスは、外部のプログラムから利用されるので public 修飾子が付いています。一方、[16] の ManagedData クラスは DLL ファイル (アセンブリ ファイル) の外部に公開する必要はないので、public が付いていません。その結果的、アセンブリの内部だけで利用できるようになります。</p>
<p>なお、名前空間の使用方法も従来と同様であり、今回は [1] の MyInteropLib 名前空間の中に、各クラスが定義されています。名前空間には public などのアクセス修飾子を付けることはできませんが、複数のクラスの論理的なグループとして、DLL ファイルの外部からも認識できます。</p>
<p><a href="#top" target="_self"><img src="http://www.microsoft.com/japan/msdn/nodehomes/graphics/top.gif" border="0" alt="">ページのトップへ</a></p>
<hr>
<h2 id="07" style="font-size:120%; margin-top:20px">7. 各メンバーの定義</h2>
<p>次に、この FileCacheWrapper クラスの機能を確認しながら、クラス内の各メンバーの特徴について確認します。</p>
<p>既に触れたように、この FileCacheWrapper クラスは、CFileCache オブジェクト (インスタンス) のラッパー クラスです。そのため、FileCacheWrapper クラスのインスタンスが存在している間は、内部的に CFileCache インスタンスが存在している必要があります。よって、FileCacheWrapper クラスのコンストラクターが実行される中で、CFileCache クラスのインスタンスも作成しています。</p>
<p>マネージ クラスのコンストラクターの定義も、従来の C&#43;&#43; と同様であり、この例では [6] および [17] にコンストラクターが定義されています。このコンストラクターでは、[18] でネイティブ オブジェクトの CFileCache インスタンスを作成し、[19] でマネージ オブジェクトの ManagedData インスタンスを作成しています。</p>
<p>これに対し、オブジェクトを破棄する際に行う後処理、つまりデストラクターでは、従来のそれとは少し異なります。C&#43;&#43;/CLI の後処理を実装するメソッドには、「デストラクター」と「ファイナライザー」の 2 種類があります。デストラクターのメソッド名は従来と同様であり、[7] および [21] のとおり、クラス名の頭に「~」(チルダ) を付けます。一方、ファイナライザーは [8] および [24] にあるように、クラス名の頭に「!」(感嘆符) を付けます。この 2 つの後処理には使い分けがあり、のちほど改めて取り上げます。</p>
<p>メソッドの定義も、修飾子の使い方にいくつか違いがありますが、従来のメンバー関数と基本的な記述方法は同様です。ただし、今回のようなラッパー クラスでは、メソッドが受け取る引数はマネージ コードのデータ型ですが、さらに内部でネイティブ コードのメンバー関数を呼び出すので、引数をマネージ型からネイティブ型への変換 (またはその逆) を行う必要があります。[20] の Load メソッドでも、前回説明した Marshall クラスを用いて、マネージ対応の String 型の文字列と、LPCWSTR 型のポインターで表されるネイティブ対応との文字列で相互に変換を行っています。</p>
<p>また、[15] には Length プロパティが定義されています。プロパティは利用者側からすると、変数のように見えて、その実態は値の設定や参照を行うメソッドです。この例の Length プロパティの場合、例 9.3 の [3] の「fileCache.Length」とあるように、変数 Length のように参照できます。この参照を行うと、実際には、例 9.5 の [15] のブロック内にある get のブロック (get アクセサー) が実行され、その戻り値が返ります。</p>
<p>この例には記述してありませんが、値を設定するには set アクセサーを使用します。仮に、FileCacheWrapper クラスに Position というプロパティがあり、参照と設定が可能であるなら、get アクセサーset アクセサーは次のように定義できます。</p>
<p><strong>例 9.6&nbsp; (参考) Position プロパティの定義</strong></p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>C&#43;&#43;</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">スクリプトの編集</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">cplusplus</span>

<div class="preview">
<pre id="codePreview" class="cplusplus"><span class="cpp__keyword">public</span>:&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;property&nbsp;<span class="cpp__datatype">int</span>&nbsp;Position&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cpp__datatype">int</span>&nbsp;get()&nbsp;{&nbsp;<span class="cpp__keyword">return</span>&nbsp;m_nPos;&nbsp;}&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cpp__com">//&larr;[1]</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cpp__keyword">void</span>&nbsp;set(<span class="cpp__datatype">int</span>&nbsp;value)&nbsp;{&nbsp;m_nPos&nbsp;=&nbsp;value;&nbsp;}&nbsp;&nbsp;&nbsp;<span class="cpp__com">//&larr;[2]</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;}</pre>
</div>
</div>
</div>
<p>このとき利用する側では、次のようにアクセスできます。</p>
<p><strong>例 9.7 (参考) Position プロパティの利用</strong></p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>C&#43;&#43;</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">スクリプトの編集</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">cplusplus</span>

<div class="preview">
<pre id="codePreview" class="cplusplus">&nbsp;&nbsp;&nbsp;&nbsp;fileCache-&gt;Position&nbsp;=&nbsp;<span class="cpp__number">100</span>;&nbsp;&nbsp;<span class="cpp__com">//&larr;[3]&nbsp;setアクセサーの呼び出し</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;fileCache-&gt;Position&#43;&#43;;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cpp__com">//&larr;[4]&nbsp;getアクセサーとsetアクセサーの呼び出し</span></pre>
</div>
</div>
</div>
<p>例 9.7 の [3] のようにプロパティに値 100 を設定すれば、例 9.6 の [2] の set アクセサーが呼び出され、その引数 value には、100 が渡ります。通常は、この値の有効性を検&#35388;したのち、プライベート変数などに退避します。</p>
<p>少し注意すべき点は、例 9.7 の [4] のインクリメント演算子を使用した場合です。C&#43;&#43; をご存じの方は、かえって誤解される場合があり、[4] のように記述すると、「Position プロパティの get アクセサーが返す戻り値に対して単にインクリメントするだけなので、オブジェクト自身の Length プロパティ (内部的なプライベート変数の値) が増加しないのではないか」と疑問に思われることがあります。</p>
<p>しかし、C&#43;&#43;/CLI のコンパイラーは [4] のような記述を見つけると、Position プロパティの get アクセサーを呼び出して値を取得して加算したのち、今度は set アクセサーを呼び出して加算結果を設定するようにプログラム コードを生成します。つまり、論理的な Length という名前のデータに対して、直接インクリメントするかのような振る舞いになるのです。(これは、C# でも同様です。)</p>
<p>また、プロパティにはインデックスを付けることができます。たとえば、Lines という名前のプロパティがあり (オブジェクトの変数名を obj とした場合) 、このプロパティに対して、obj.Lines[0]、obj.Lines[1]、...、obj.Lines[2]というように、インデックスを付けてアクセスできます。このときのプロパティの定義は次のようになります。</p>
<p><strong>例 9.8 (参考) インデックス付きの Lines プロパティ</strong></p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>C&#43;&#43;</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">スクリプトの編集</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">cplusplus</span>

<div class="preview">
<pre id="codePreview" class="cplusplus"><span class="cpp__keyword">public</span>:&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;property&nbsp;<span class="cpp__datatype">int</span>&nbsp;Lines[<span class="cpp__datatype">int</span>]&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cpp__datatype">int</span>&nbsp;get(<span class="cpp__datatype">int</span>&nbsp;ndx)&nbsp;{&nbsp;<span class="cpp__mlcom">/*&nbsp;getアクセサーの実装&nbsp;*/</span>&nbsp;}&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cpp__keyword">void</span>&nbsp;set(<span class="cpp__datatype">int</span>&nbsp;ndx,&nbsp;<span class="cpp__datatype">int</span>&nbsp;value)&nbsp;{&nbsp;<span class="cpp__mlcom">/*&nbsp;setアクセサーの実装&nbsp;*/</span>&nbsp;}&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;}</pre>
</div>
</div>
</div>
<p>この例のように、get アクセサーや set アクセサーの引数が 1 つ増えました。引数 ndx には、呼び出し元が指定したインデックの値が渡ってきます。</p>
<p>さらに、このインデックス付きプロパティでは、プロパティ名自体を省略して、オブジェクト変数の後ろに、直接インデックスを付けるように定義できます。たとえば、obj[0]、obj[1]、...、obj[2] のように記述できます。このように記述すると、1 つのオブジェクトをあたかも配列やコレクションのように利用できます。このためには、例 9.8 の Lines プロパティを定義する際に、「Lines」という名前の箇所に対して、名前の代わりに「default」キーワードを記述します。</p>
<p>このような名前を省略できるインデックス付きプロパティは、例 9.5 の FileCacheWrapper クラスの [10] に定義してあります。このプロパティを利用した例が、例 9.3 の [4] にある「fileCache[2]」という記述です。</p>
<p>また、例 9.5 の [10] のインデックス付きプロパティは、例 9.1 のネイティブ版の CFileCache クラスに定義された演算子 [ ] のオーバーロード (例 9.1 の末尾の CFileCache::operator[](int ndx)) に相当するものであり、ここでは、これをラップしたものが例 9.5 の [10] のプロパティに当たります。</p>
<p>なお、このプロパティの中の [11] の get アクセサーでは、指定されたインデックスが有効範囲であるか、あらかじめ確認するために利用できます。ここでは [12] のように、有効な範囲であるかチェックし、有効でない場合は、[13] のように例外をスローしています。従来の C&#43;&#43; とは異なり、スローできるデータは、マネージ クラスである Exception クラスか、または、その派生クラスだけです。ここでは、インデックスの範囲外を意味する「IndexOutOfRangeException」をスローしています。このクラスも、Exception
 クラスの派生クラスです。</p>
<p><a href="#top" target="_self"><img src="http://www.microsoft.com/japan/msdn/nodehomes/graphics/top.gif" border="0" alt="">ページのトップへ</a></p>
<hr>
<h2 id="08" style="font-size:120%; margin-top:20px">8. 後処理の注意点 ～デストラクターとファイナライザー～</h2>
<p>ここで、マネージ オブジェクトの後処理を担当する 2 つのメソッド「デストラクター」と「ファイナライザー」の使用方法について改めて確認します。</p>
<p>.NET では、gcnew キーワードを用いてマネージ ヒープに確保したオブジェクトについては、プログラム内のどこからも参照されなくなると、ガベージ コレクションによって自動的に削除されます。このガベージ コレクションによってオブジェクトが削除される際に、後処理として自動的に呼び出されるのが「ファイナライザー」です (例 9.5 の [8]、および [24])。</p>
<p>このファイナライザーは、リソースの解放などの後処理を行うべき場所ですが、ガベージ コレクションがいつ起こるかは特定できないので、不必要にリソースの解放が遅れる場合があります。リソースによっては、必要なくなったタイミングで、速やかにプログラマーが明示的に解放したほうがよい場合もあります。そのような明示的な後処理を行うのが「デストラクター」です (例 9.5 の [7]、および、[21])。</p>
<p>このマネージ クラスのデストラクターを呼び出すには、C&#43;&#43;/CLI の場合は、従来どおり、delete キーワードを用いて、次のように記述できます。</p>
<p><strong>例 9.9 C&#43;&#43;/CLI における明示的なデストラクターの呼び出し</strong></p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>C&#43;&#43;</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">スクリプトの編集</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">cplusplus</span>

<div class="preview">
<pre id="codePreview" class="cplusplus"><span class="cpp__keyword">delete</span>&nbsp;pFileCache;</pre>
</div>
</div>
</div>
<p>ただし、この記述はデストラクターを呼び出して、オブジェクトが持つリソースの解放など、あくまで後処理を行うためのものです。オブジェクト自身の削除は行いません。オブジェクト自身は、ガベージ コレクションによって削除されるので、この delete キーワードによる記述によって、オブジェクト自体が削除されるわけではないのです。</p>
<p>また、デストラクターとファイナライザーにおける後処理には、それぞれ行うべき処理に作法があり、まとめると次のようになります。</p>
<ul>
<li><strong>デストラクター </strong>
<ol type="a">
<li style="list-style:none none">a. そのオブジェクトに含まれる子オブジェクトなどの、マネージオブジェクトの後処理 </li><li style="list-style:none none">b. そのオブジェクトに含まれる子オブジェクトなどの、ネイティブオブジェクトの後処理 </li><li style="list-style:none none">c. ファイナライザーの呼び出しの抑止 </li></ol>
</li><li><strong>ファイナライザー </strong>
<ol type="a">
<li style="list-style:none none">d. そのオブジェクトに含まれる子オブジェクトなどの、ネイティブオブジェクトの後処理 </li></ol>
</li></ul>
<p>このあとは、これらを行う理由や記述方法について、それぞれ個別に確認しましょう。</p>
<p><a href="#top" target="_self"><img src="http://www.microsoft.com/japan/msdn/nodehomes/graphics/top.gif" border="0" alt="">ページのトップへ</a></p>
<hr>
<h2 id="09" style="font-size:120%; margin-top:20px">9. デストラクターで実装すべきこと</h2>
<p>前述のおとり、デストラクターの作法として (a) から (c) までの 3 つの行うべきことがあります。<br>
これを例 9.5 の [21] のデストラクターに当てはめてみましょう。</p>
<p>この [21] のデストラクターは、基本的にはコンストラクターの中で作成した子オブジェクトに関して、後処理を行う必要があります。この例のコンストラクター [17] では、子オブジェクトとしてマネージ オブジェクト (m_MData) とネイティブ オブジェクト (m_pCache) を作成しいるので、[21] のデストラクターでは、この 2 つのオブジェクトに関して後処理を行う必要があります。</p>
<p>それが、作法の (a) と (b) に当たる部分であり、それぞれ [22] と [23] になります。[22] では、マネージ オブジェクトである m_MData に対して delete キーワードを用いて、明示的に後処理を行っています。また、[23] はネイティブ オブジェクトの後処理を行うもので、「delete m_pCache」となるべき箇所ですが、この記述がちょうど [24] のファイナライザーに実装されているので、[23] からファイナライザーを呼び出して、ネイティブ オブジェクトの後処理を行っています
 (もちろん、ネイティブ オブジェクトは、delete キーワードを使用することによって、オブジェクト自身も削除されます)。</p>
<p>ここまでは、コンストラクターの逆を行えばよいので、特に問題はないでしょう。留意すべき点は、 (c) のファイライザー呼び出しの抑止です。</p>
<p>デストラクターもファイライザーも、当該オブジェクトの後処理を実行するためのものなので、デストラクターを明示的に呼び出したのであれば、ガベージ コレクションの際に、ファイナライザーをわざわざ呼び出す必要はありません。</p>
<p>.NET Framework の観点からすると、ファイナライザーとは Object クラスの Finalize メソッド (および、派生クラスでオーバーライドした同名メソッド) のことであり、このファイナライザーの呼び出しを抑止するために、.NET Framework のクラス ライブラリの GC クラスには、SuppressFinalize メソッドが用意されています。このメソッドの引数に、当該オブジェクトを渡して呼び出すと、ガベージ コレクションの際にファイナライザーを呼び出さないように、抑止することができます。</p>
<p>このようなファイナライザーの呼び出しを抑止することで、ガベージ コレクションでのオーバーヘッドも軽減することができます。実は、ファイナライザーを呼び出す場合と、呼び出さない場合とでは、ガベージ コレクションにおける後処理の工程が異なるのです。</p>
<p>ファイナライザーを呼び出す必要がないオブジェクトの場合、定期的に行われるガベージ コレクションの過程で、不要なオブジェクトであると認識されると、その 1 回のガベージ コレクションによって、オブジェクトは削除されます。</p>
<p>ところが、ファイナライザーの呼び出しを必要とするオブジェクトの場合は、1 回のガベージ コレクションでは削除されません。まず、1 回目のガベージ コレクションの際に、不要なオブジェクトであることが認識されると、この場では削除せずに、ファイナライザーを呼び出すための終了キューに登録します。この後、終了キューのオブジェクトは、まとめてファイナライザーが呼び出されます。そして、2 回目のガベージ コレクションの際に、ファイナライザーの呼び出し済みオブジェクトを削除します。</p>
<p>つまり、ファイナライザーを呼び出さない場合には、1 回のガベージ コレクションで削除されますが、ファイナライザーを呼び出す場合には、2 回のガベージコレクションが必要になります。このため、呼び出す必要がなければ抑止するのが望ましく、また、なまじっか空のファイナライザー (Finalize メソッド) を記述するくらいなら、何も書かないほうがオーバーヘッドを少なくできるのです。</p>
<p>しかし、C&#43;&#43;/CLI の場合は、このような GC.SuppressFinalize メソッドの明示的な呼び出しは不要です。実は、デストラクターを記述すると、コンパイラーによってデストラクターの末尾に、SuppressFinalize メソッド呼び出しが追加されるのです。そのため、.NET の後処理の作法としては、前述の (a) から (c) までの 3 つの実装が必要ですが、プログラマーが C&#43;&#43;/CLI でデストラクターを記述する際には、(a) と (b) の後処理を記述します。</p>
<p>なお、C&#43;&#43;/CLI のデストラクターは、コンパイラーによって、.NET の IDisposable インターフェイスの Dispose メソッドとして出力されます。つまり、Visual Basic や C# において、C&#43;&#43;/CLI のデストラクターを呼び出す場合には、この Dispose メソッドを呼び出すことになります。このため、今回の FileCacheWrapper クラスのオブジェクトを C# から利用する場合は、例 9.3 の [6] でも後処理の際に、Dispose メソッドを呼び出しています。</p>
<div style="margin:10px 0px; padding:10px 10px 0px 10px; border:double 1px #CCCCCC">
<p style="margin:0px"><strong>Note:</strong></p>
<p>正確にいうと、C&#43;&#43;/CLI で記述したデストラクターのメソッド本体は、プライベートなメソッドになり、このプライベート メソッドを間接的に呼び出すパブリック メソッドとして、IDisposalbe インターフェイスの Dispose メソッドが、コンパイラによって生成されます (実際は、もうワンクッション別のメソッド呼び出しが中間に介在します) 。なお、この Dispose メソッドに関しては、ソース コード上のデストラクターのアクセス修飾子に関係なく、パブリック メソッドになります。</p>
</div>
<p><a href="#top" target="_self"><img src="http://www.microsoft.com/japan/msdn/nodehomes/graphics/top.gif" border="0" alt="">ページのトップへ</a></p>
<hr>
<h2 id="10" style="font-size:120%; margin-top:20px">10. ファイナライザーで実装すべきこと</h2>
<p>ファイナライザーに後処理を実装しておけば、万が一、プログラマーがデストラクターの呼び出しを忘れても、ガベージ コレクションの際には、確実に後処理を行うことができます。ただし、行うべき後処理に注意してください。前述の作法 (d) に挙げたとおり、ネイティブ オブジェクトの後処理だけです。</p>
<p>作法の (a) に挙げたような、子オブジェクトとして含むマネージ オブジェクトの後処理は必要ありません。子オブジェクトの後処理としては、やはり、ガベージ コレクションによって自動的にファイナライザーが呼び出されるので、プログラマーが呼び出す必要はないのです。</p>
<p>それに呼び出すことが不適切の場合もあります。というのは、親オブジェクトのファイナライザーと子オブジェクトのファイナライザーとの呼び出し順は不定であり、親オブジェクトのファイナライザーが呼び出される前に、子オブジェクトのファイナライザーが先に呼び出され、子オブジェクトの後処理が既に完了している場合もあるからです。</p>
<p>例 9.5 の [24] のファイナライザーでも、[25] の「delete m_pCache;」のようにネイティブ オブジェクトの後処理しか行っていません。</p>
<p>なお、[24] のファイナライザーが実行される時点では、メンバー変数 m_MData が子オブジェクトである ManagedData を参照してするため、「親オブジェクトよりも先に子オブジェクトが削除されることがないのでは」と疑問に思うかもしれません。しかし、親オブジェクトが参照していたとしても、この時点では、子オブジェクトの後処理が完了している可能性があるのです。</p>
<p>この理由は、ガベージ コレクションの工程において、オブジェクトが参照されているか否かの判断を行う際に、単純に変数がオブジェクトを参照しているか否かをチェックするのではなく、現在実行しているプログラム内で有効な変数から参照できるかを確認するからです。</p>
<p>たとえば、現在使用できるローカル変数やメンバー変数、そのほかの有効な共有変数などから、参照可能なオブジェクトを突き止め、さらに、このような参照可能なオブジェクトの変数から、参照できるオブジェクトを追跡し、芋づる式に、参照可能なオブジェクトであるかを確認します。このため、この参照の連鎖をたどって到達できない親オブジェクトがある場合、その親が排他的に参照する子オブジェクトにもたどりつけません。よって、そのような親オブジェクトが、参照している子オブジェクトも、結局のところ、参照できないオブジェクトとして扱われます。こうして、親オブジェクトと子オブジェクトは、同時に参照できないオブジェクトとして認識できるのです。</p>
<p>ここで、後処理の実装方法をまとめておきましょう。</p>
<p>結局のところ、C&#43;&#43;/CLI における後処理の作法としてコードに明記するのは、(a) 、 (b)、および (d) です。この基本パターンを表したのが、例 9.5 の [21] のデストラクターと [24] のファイナライザーです。特に、デストラクター内の作法 (b) のネイティブ オブジェクトの後処理に関しては、例 9.5 の [23] のように、ファイナライザーを呼び出すことで実現できます。</p>
<p>まずは、この例の基本パターンを覚えておくとよいでしょう。</p>
<p>なお、今回の例ではマネージ クラスの構造を単純にして分かりやすくするため、マネージ クラスから継承した派生マネージ クラスでの、デストラクターやファイナライザーの例は取り上げませんでした。基本的には、派生クラスのデストラクターやファイナライザーでは、自身のメンバーの後処理に関して実装すれば十分です。C&#43;&#43;/CLI のコンパイラーは、派生クラスの後処理の工程において、基本クラスのデストラクターやファイナライザーに実装された後処理を呼び出すように、コードを自動生成してくれます。</p>
<div style="margin:10px 0px; padding:10px 10px 0px 10px; border:double 1px #CCCCCC">
<p style="margin:0px"><strong>Note:</strong></p>
<p>言語によっては、デストラクターやファイナライザーの名称などが異なりますが、デストラクター (Dispose メソッド) やファイナライザー (Finalize メソッド) に関する前述の (a) から (d) の作法は、Visual Basic や C# でも当てはまります。Visual Basic や C# の後処理の実装例は、以下でも紹介されています。</p>
<ul>
<li><a href="http://msdn.microsoft.com/ja-jp/library/b1yfkh5e.aspx" target="_blank">アンマネージ リソースをクリーンアップするための Finalize および Dispose の実装</a>
</li></ul>
</div>
<p><a href="#top" target="_self"><img src="http://www.microsoft.com/japan/msdn/nodehomes/graphics/top.gif" border="0" alt="">ページのトップへ</a></p>
<hr>
<h2 id="11" style="font-size:120%; margin-top:20px">11. サンプルの利用</h2>
<p>最後に参考までに、このラッパー クラスを C# から利用した実行の様子を示しておきます。</p>
<p>前述のサンプルをビルドすると、正常終了すれば、以下の DLL ファイル (アセンブリ ファイル) が出力されます。</p>
<div style="margin:10px 0; padding:0 10px; background-color:#efefef; border:solid 1px #333333">
<p>MyInteropLib.dll</p>
</div>
<p>この DLL ファイルへの参照の追加を行った C# のコンソール プロジェクトにおいて、例 9.3 のサンプル コードを入力して実行すると、次のようにコンソールには表示されます。(次図の実行結果では、プログラム ファイルと同一のフォルダーに「Test.txt」というファイルがあることが前提です。このファイルには「Test」という半角 4 バイトが、ANSI 文字列として含まれています。)</p>
<p><img src="http://i1.code.msdn.s-msft.com/visualc-a1dc1f1d/image/file/41271/1/img_0904.jpg" alt="図 9.4" width="550" height="210"></p>
<p><strong>図 9.4 FileCacheWrapper を利用した実行結果</strong></p>
<p>例 9.3 の [3] では、Length プロパティを参照した結果を表示するためのもので、実際には、図 9.4 のコンソールの 1 行目のように「Length=4」と表示されます。</p>
<p>また、例 9.3 の [4] では「fileCache[2]」とインデックスを使用して、3 バイト目を参照しています (先頭のインデックス値はゼロ)。ここでは、ファイルのデータは「Test」という 4 バイトになっており、図 9.4 のコンソールの 2 行目には「s」と表示されます。また、例 9.3 の [4] の次行では、「fileCache[5]」と参照しており、添え字が範囲外なので、例外が発生します。そのため、例 9.3 の [5] の catch ブロックに制御が移り、図 9.4 のコンソール画面には例外オブジェクトの型
 (IndexOutOfRangeException) が表示されます。</p>
<p><a href="#top" target="_self"><img src="http://www.microsoft.com/japan/msdn/nodehomes/graphics/top.gif" border="0" alt="">ページのトップへ</a></p>
<hr>
<h2 id="12" style="font-size:120%; margin-top:20px">12. まとめ</h2>
<p>今回は、C&#43;&#43;/CLI を使用して、既存のネイティブ コード版の C&#43;&#43; のクラスを、.NET 側から再利用できるようにするため、マネージ版ラッパー クラスの実装方法について確認しました。いくつか、主な C&#43;&#43;/CLI の構文の特徴を確認したほか、マネージ クラスの中に、ネイティブ オブジェクトをラップするという実装形態において、留意すべき点を取り上げました。特に、.NET 管理下のマネージ オブジェクトと、ネイティブ環境下のオブジェクトでは、その削除方法が異なります。この違いを意識しながら、デストラクターやファイナライザーなどの後処理で実装すべき点などを確認しました。</p>
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
