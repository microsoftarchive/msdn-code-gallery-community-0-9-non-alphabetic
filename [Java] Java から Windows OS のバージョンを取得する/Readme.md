# [Java] Java から Windows OS のバージョンを取得する
## Requires
- 
## License
- Apache License, Version 2.0
## Technologies
- Windows 7
- Java SE 6
- jna3-2-7
## Topics
- 逆引きサンプル コード
- Windows プログラミング
- Windows 7 へのアプリ移行
- Java
- JNA
## Updated
- 02/21/2011
## Description

<p>執筆者: <a href="http://msdn.microsoft.com/ja-jp/gg585574#kawahara" target="_blank">
株式会社クリエ・イルミネート 川原 亮</a></p>
<p>動作確認環境：Windows 7 Ultimate、Java SE 6、jna3-2-7</p>
<p>Javaはプラットフォームに依存しない実行環境であるため、さまざまなシステムで使用されています。<br>
しかし、それ故に Java からプラットフォームに依存する情報を取得するとなると、どうするべきか悩む人は多いのではないでしょうか。<br>
本稿では、Windows OS のバージョンチェックを Java から行う方法について記述します。</p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title">Java</div>
<div class="pluginEditHolderLink">スクリプトの編集</div>
<span class="hidden">java</span>
<pre class="hidden">Windowsのバージョンをチェックする最も簡単な方法は、JavaのSystemクラスのgetProperty メソッドによって、現在使用しているシステムプロパティのセットを取得する方法です。

public class sample1{
 public static void main(String args[]) {
  System.out.println(&quot;OS名          ：&quot; &#43; System.getProperty(&quot;os.name&quot;));
  System.out.println(&quot;OSバージョン  ：&quot; &#43; System.getProperty(&quot;os.version&quot;));
 }
}</pre>
<pre id="codePreview" class="java">Windowsのバージョンをチェックする最も簡単な方法は、JavaのSystemクラスのgetProperty&nbsp;メソッドによって、現在使用しているシステムプロパティのセットを取得する方法です。&nbsp;
&nbsp;
<span class="java__keyword">public</span>&nbsp;<span class="java__keyword">class</span>&nbsp;sample1{&nbsp;
&nbsp;<span class="java__keyword">public</span>&nbsp;<span class="java__keyword">static</span>&nbsp;<span class="java__keyword">void</span>&nbsp;main(String&nbsp;args[])&nbsp;{&nbsp;
&nbsp;&nbsp;System.out.println(<span class="java__string">&quot;OS名&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;：&quot;</span>&nbsp;&#43;&nbsp;System.getProperty(<span class="java__string">&quot;os.name&quot;</span>));&nbsp;
&nbsp;&nbsp;System.out.println(<span class="java__string">&quot;OSバージョン&nbsp;&nbsp;：&quot;</span>&nbsp;&#43;&nbsp;System.getProperty(<span class="java__string">&quot;os.version&quot;</span>));&nbsp;
&nbsp;}&nbsp;
}&nbsp;
&nbsp;
</pre>
</div>
</div>
<div class="endscriptcode">&nbsp;</div>
<p><img src="17506-sample1_1.png" alt="" width="491" height="218"></p>
<p>システムプロパティには、JVM 及び実行される OS の基本的な情報が&#26684;納されています。<br>
OSのバージョンの他にも JRE のバージョンやクラスパスの他、OS 名やユーザアカウント名などを取得することが可能です。<br>
参照できる値は、<a href="http://java.sun.com/javase/ja/6/docs/ja/api/java/lang/System.html#getProperties()" target="_blank">Javadoc</a>から一覧できます。<br>
ですが、システムプロパティ値は Java が保持している値にアクセスしているのみであり&nbsp;OS 自体が保持する値にアクセスするわけではありませんし、 setProperty メソッドを使用することで変更することも可能です。</p>
<p>したがって、確実な情報を得るのであれば、Windows API を呼び出す手法が最も適切でしょう。<br>
ここでは、 Java からネイティブの共有ライブラリにアクセスする JNA ライブラリを使用して、Windows API の結果を取得する方法をご紹介します。<br>
以下のコードでは、 JNA (Java Native Access) を使って kernel32.dll 内の GetVersionEx 関数を利用し、OS のバージョン情報を呼び出しています。<br>
JNA のダウンロードは<a href="https://jna.dev.java.net/servlets/ProjectDocumentList?folderID=7408&expandFolder=7408&folderID=0" target="_blank">こちら</a>から。<br>
ライブラリや API のマッピング、プリミティブデータ型のマーシャリング等については、 JNA が指定する方法に依っています。ドキュメントは<a href="https://jna.dev.java.net/javadoc/overview-summary.html" target="_blank">こちら (英語)</a>から。</p>
<h2>今回紹介するコード</h2>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title">Java</div>
<div class="pluginEditHolderLink">スクリプトの編集</div>
<span class="hidden">java</span>
<pre class="hidden">import com.sun.jna.Library;
import com.sun.jna.Native;
import com.sun.jna.Platform;
import com.sun.jna.Pointer;
import com.sun.jna.Structure;

public class sample1_1{
 public static void main(String args[]) {
  sample1_1 win = new sample1_1();
  getVersionEx();
 }

 public interface Kernel32 extends Library {
  Kernel32 INSTANCE = (Kernel32) Native.loadLibrary(&quot;kernel32&quot;, Kernel32.class);
  boolean GetVersionExW(Pointer pInfo);
 }
 
 public static class OSVERSIONINFOEX extends Structure {
  public int dwOSVersionInfoSize; 
  public int dwMajorVersion; 
  public int dwMinorVersion; 
  public int dwBuildNumber; 
  public int dwPlatformId; 
  public char[] szCSDVersion;
  public short wServicePackMajor;
  public short wServicePackMinor;
  public short wSuiteMask;
  public byte wProductType;
  public byte wReserved;
  
  public OSVERSIONINFOEX(){
   szCSDVersion = new char [128];
   dwOSVersionInfoSize = this.size();
  }
 }

 public static void getVersionEx() {
  if (Platform.isWindows()) {
   OSVERSIONINFOEX osver = new OSVERSIONINFOEX();
   osver.write();
   boolean flag = Kernel32.INSTANCE.GetVersionExW(osver.getPointer());
   osver.read();
   if (flag) {
    System.out.println(osver.dwMajorVersion &#43; &quot;.&quot; &#43; osver.dwMinorVersion &#43; &quot; &quot; &#43; osver.dwBuildNumber);
   }
  }
 }
}</pre>
<pre id="codePreview" class="java"><span class="java__keyword">import</span>&nbsp;com.sun.jna.Library;&nbsp;
<span class="java__keyword">import</span>&nbsp;com.sun.jna.Native;&nbsp;
<span class="java__keyword">import</span>&nbsp;com.sun.jna.Platform;&nbsp;
<span class="java__keyword">import</span>&nbsp;com.sun.jna.Pointer;&nbsp;
<span class="java__keyword">import</span>&nbsp;com.sun.jna.Structure;&nbsp;
&nbsp;
<span class="java__keyword">public</span>&nbsp;<span class="java__keyword">class</span>&nbsp;sample1_1{&nbsp;
&nbsp;<span class="java__keyword">public</span>&nbsp;<span class="java__keyword">static</span>&nbsp;<span class="java__keyword">void</span>&nbsp;main(String&nbsp;args[])&nbsp;{&nbsp;
&nbsp;&nbsp;sample1_1&nbsp;win&nbsp;=&nbsp;<span class="java__keyword">new</span>&nbsp;sample1_1();&nbsp;
&nbsp;&nbsp;getVersionEx();&nbsp;
&nbsp;}&nbsp;
&nbsp;
&nbsp;<span class="java__keyword">public</span>&nbsp;<span class="java__keyword">interface</span>&nbsp;Kernel32&nbsp;<span class="java__keyword">extends</span>&nbsp;Library&nbsp;{&nbsp;
&nbsp;&nbsp;Kernel32&nbsp;INSTANCE&nbsp;=&nbsp;(Kernel32)&nbsp;Native.loadLibrary(<span class="java__string">&quot;kernel32&quot;</span>,&nbsp;Kernel32.<span class="java__keyword">class</span>);&nbsp;
&nbsp;&nbsp;<span class="java__keyword">boolean</span>&nbsp;GetVersionExW(Pointer&nbsp;pInfo);&nbsp;
&nbsp;}&nbsp;
&nbsp;&nbsp;
&nbsp;<span class="java__keyword">public</span>&nbsp;<span class="java__keyword">static</span>&nbsp;<span class="java__keyword">class</span>&nbsp;OSVERSIONINFOEX&nbsp;<span class="java__keyword">extends</span>&nbsp;Structure&nbsp;{&nbsp;
&nbsp;&nbsp;<span class="java__keyword">public</span>&nbsp;<span class="java__keyword">int</span>&nbsp;dwOSVersionInfoSize;&nbsp;&nbsp;
&nbsp;&nbsp;<span class="java__keyword">public</span>&nbsp;<span class="java__keyword">int</span>&nbsp;dwMajorVersion;&nbsp;&nbsp;
&nbsp;&nbsp;<span class="java__keyword">public</span>&nbsp;<span class="java__keyword">int</span>&nbsp;dwMinorVersion;&nbsp;&nbsp;
&nbsp;&nbsp;<span class="java__keyword">public</span>&nbsp;<span class="java__keyword">int</span>&nbsp;dwBuildNumber;&nbsp;&nbsp;
&nbsp;&nbsp;<span class="java__keyword">public</span>&nbsp;<span class="java__keyword">int</span>&nbsp;dwPlatformId;&nbsp;&nbsp;
&nbsp;&nbsp;<span class="java__keyword">public</span>&nbsp;<span class="java__keyword">char</span>[]&nbsp;szCSDVersion;&nbsp;
&nbsp;&nbsp;<span class="java__keyword">public</span>&nbsp;<span class="java__keyword">short</span>&nbsp;wServicePackMajor;&nbsp;
&nbsp;&nbsp;<span class="java__keyword">public</span>&nbsp;<span class="java__keyword">short</span>&nbsp;wServicePackMinor;&nbsp;
&nbsp;&nbsp;<span class="java__keyword">public</span>&nbsp;<span class="java__keyword">short</span>&nbsp;wSuiteMask;&nbsp;
&nbsp;&nbsp;<span class="java__keyword">public</span>&nbsp;<span class="java__keyword">byte</span>&nbsp;wProductType;&nbsp;
&nbsp;&nbsp;<span class="java__keyword">public</span>&nbsp;<span class="java__keyword">byte</span>&nbsp;wReserved;&nbsp;
&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;<span class="java__keyword">public</span>&nbsp;OSVERSIONINFOEX(){&nbsp;
&nbsp;&nbsp;&nbsp;szCSDVersion&nbsp;=&nbsp;<span class="java__keyword">new</span>&nbsp;<span class="java__keyword">char</span>&nbsp;[<span class="java__number">128</span>];&nbsp;
&nbsp;&nbsp;&nbsp;dwOSVersionInfoSize&nbsp;=&nbsp;<span class="java__keyword">this</span>.size();&nbsp;
&nbsp;&nbsp;}&nbsp;
&nbsp;}&nbsp;
&nbsp;
&nbsp;<span class="java__keyword">public</span>&nbsp;<span class="java__keyword">static</span>&nbsp;<span class="java__keyword">void</span>&nbsp;getVersionEx()&nbsp;{&nbsp;
&nbsp;&nbsp;<span class="java__keyword">if</span>&nbsp;(Platform.isWindows())&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;OSVERSIONINFOEX&nbsp;osver&nbsp;=&nbsp;<span class="java__keyword">new</span>&nbsp;OSVERSIONINFOEX();&nbsp;
&nbsp;&nbsp;&nbsp;osver.write();&nbsp;
&nbsp;&nbsp;&nbsp;<span class="java__keyword">boolean</span>&nbsp;flag&nbsp;=&nbsp;Kernel32.INSTANCE.GetVersionExW(osver.getPointer());&nbsp;
&nbsp;&nbsp;&nbsp;osver.read();&nbsp;
&nbsp;&nbsp;&nbsp;<span class="java__keyword">if</span>&nbsp;(flag)&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;System.out.println(osver.dwMajorVersion&nbsp;&#43;&nbsp;<span class="java__string">&quot;.&quot;</span>&nbsp;&#43;&nbsp;osver.dwMinorVersion&nbsp;&#43;&nbsp;<span class="java__string">&quot;&nbsp;&quot;</span>&nbsp;&#43;&nbsp;osver.dwBuildNumber);&nbsp;
&nbsp;&nbsp;&nbsp;}&nbsp;
&nbsp;&nbsp;}&nbsp;
&nbsp;}&nbsp;
}&nbsp;
&nbsp;
</pre>
</div>
</div>
<div class="endscriptcode">&nbsp;</div>
<h2>Windows API を呼び出すための準備</h2>
<p>JNA では、Native.loadLibrary 関数を使用して、目的の dll をロードします。<br>
また、使用したいWindows API の関数名と同名のメソッドを定義しておく必要があります。</p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title">Java</div>
<div class="pluginEditHolderLink">スクリプトの編集</div>
<span class="hidden">java</span>
<pre class="hidden">public interface Kernel32 extends Library {
 Kernel32 INSTANCE = (Kernel32) Native.loadLibrary(&quot;kernel32&quot;, Kernel32.class);
 boolean GetVersionExW(Pointer pInfo);
}</pre>
<pre id="codePreview" class="js">public&nbsp;interface&nbsp;Kernel32&nbsp;extends&nbsp;Library&nbsp;<span class="js__brace">{</span>&nbsp;
&nbsp;Kernel32&nbsp;INSTANCE&nbsp;=&nbsp;(Kernel32)&nbsp;Native.loadLibrary(<span class="js__string">&quot;kernel32&quot;</span>,&nbsp;Kernel32.class);&nbsp;
&nbsp;boolean&nbsp;GetVersionExW(Pointer&nbsp;pInfo);&nbsp;
<span class="js__brace">}</span>&nbsp;
&nbsp;
</pre>
</div>
</div>
<h2>構造体の定義</h2>
<p><a href="http://msdn.microsoft.com/ja-jp/library/cc429835.aspx" target="_blank">GetVersionEx 関数</a>は、パラメータに構造体のポインタを指定することで、バージョン情報を構造体に&#26684;納します。<br>
したがって、Java において構造体に相当するクラスを定義する必要があります。<br>
JNA には構造体に相当する <a href="https://jna.dev.java.net/javadoc/com/sun/jna/Structure.html" target="_blank">
Structure クラス</a>が用意されているので、 <a href="http://msdn.microsoft.com/en-us/library/ms724833(v=vs.85).aspx" target="_blank">
OSVERSIONINFOEX&nbsp;クラス</a>を定義する際に Structure クラスを拡張し、メンバを定義します。<br>
メンバの型は正確に Java の型に置き換えなければ、構造体に情報が&#26684;納されません。<br>
型のマッピングについては、<a href="https://jna.dev.java.net/javadoc/overview-summary.html#marshalling" target="_blank">こちら (英語)</a>を参照してください。<br>
また、dwOSVersionInfoSize メンバについては事前に指定しておく必要があるため、コンストラクタ内で定義を行っています。</p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title">Java</div>
<div class="pluginEditHolderLink">スクリプトの編集</div>
<span class="hidden">java</span>
<pre class="hidden">public static class OSVERSIONINFOEX extends Structure {
 public int dwOSVersionInfoSize; 
 public int dwMajorVersion; 
 public int dwMinorVersion; 
 public int dwBuildNumber; 
 public int dwPlatformId; 
 public char[] szCSDVersion;
 public short wServicePackMajor;
 public short wServicePackMinor;
 public short wSuiteMask;
 public byte wProductType;
 public byte wReserved;

 
 public OSVERSIONINFOEX(){
  szCSDVersion = new char [128];
  dwOSVersionInfoSize = this.size();
 }
}</pre>
<pre id="codePreview" class="java"><span class="java__keyword">public</span>&nbsp;<span class="java__keyword">static</span>&nbsp;<span class="java__keyword">class</span>&nbsp;OSVERSIONINFOEX&nbsp;<span class="java__keyword">extends</span>&nbsp;Structure&nbsp;{&nbsp;
&nbsp;<span class="java__keyword">public</span>&nbsp;<span class="java__keyword">int</span>&nbsp;dwOSVersionInfoSize;&nbsp;&nbsp;
&nbsp;<span class="java__keyword">public</span>&nbsp;<span class="java__keyword">int</span>&nbsp;dwMajorVersion;&nbsp;&nbsp;
&nbsp;<span class="java__keyword">public</span>&nbsp;<span class="java__keyword">int</span>&nbsp;dwMinorVersion;&nbsp;&nbsp;
&nbsp;<span class="java__keyword">public</span>&nbsp;<span class="java__keyword">int</span>&nbsp;dwBuildNumber;&nbsp;&nbsp;
&nbsp;<span class="java__keyword">public</span>&nbsp;<span class="java__keyword">int</span>&nbsp;dwPlatformId;&nbsp;&nbsp;
&nbsp;<span class="java__keyword">public</span>&nbsp;<span class="java__keyword">char</span>[]&nbsp;szCSDVersion;&nbsp;
&nbsp;<span class="java__keyword">public</span>&nbsp;<span class="java__keyword">short</span>&nbsp;wServicePackMajor;&nbsp;
&nbsp;<span class="java__keyword">public</span>&nbsp;<span class="java__keyword">short</span>&nbsp;wServicePackMinor;&nbsp;
&nbsp;<span class="java__keyword">public</span>&nbsp;<span class="java__keyword">short</span>&nbsp;wSuiteMask;&nbsp;
&nbsp;<span class="java__keyword">public</span>&nbsp;<span class="java__keyword">byte</span>&nbsp;wProductType;&nbsp;
&nbsp;<span class="java__keyword">public</span>&nbsp;<span class="java__keyword">byte</span>&nbsp;wReserved;&nbsp;
&nbsp;
&nbsp;&nbsp;
&nbsp;<span class="java__keyword">public</span>&nbsp;OSVERSIONINFOEX(){&nbsp;
&nbsp;&nbsp;szCSDVersion&nbsp;=&nbsp;<span class="java__keyword">new</span>&nbsp;<span class="java__keyword">char</span>&nbsp;[<span class="java__number">128</span>];&nbsp;
&nbsp;&nbsp;dwOSVersionInfoSize&nbsp;=&nbsp;<span class="java__keyword">this</span>.size();&nbsp;
&nbsp;}&nbsp;
}&nbsp;
&nbsp;
</pre>
</div>
</div>
<div class="endscriptcode">&nbsp;</div>
<h2>GetVersionEx 関数の呼び出し</h2>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title">Java</div>
<div class="pluginEditHolderLink">スクリプトの編集</div>
<span class="hidden">java</span>
<pre class="hidden">OSVERSIONINFOEX osver = new OSVERSIONINFOEX();
osver.write();
boolean flag = Kernel32.INSTANCE.GetVersionExW(osver.getPointer());
osver.read();
if (flag) {
 System.out.println(osver.dwMajorVersion &#43; &quot;.&quot; &#43; osver.dwMinorVersion &#43; &quot; &quot; &#43; osver.dwBuildNumber);
}</pre>
<pre id="codePreview" class="js">OSVERSIONINFOEX&nbsp;osver&nbsp;=&nbsp;<span class="js__operator">new</span>&nbsp;OSVERSIONINFOEX();&nbsp;
osver.write();&nbsp;
boolean&nbsp;flag&nbsp;=&nbsp;Kernel32.INSTANCE.GetVersionExW(osver.getPointer());&nbsp;
osver.read();&nbsp;
<span class="js__statement">if</span>&nbsp;(flag)&nbsp;<span class="js__brace">{</span>&nbsp;
&nbsp;System.out.println(osver.dwMajorVersion&nbsp;&#43;&nbsp;<span class="js__string">&quot;.&quot;</span>&nbsp;&#43;&nbsp;osver.dwMinorVersion&nbsp;&#43;&nbsp;<span class="js__string">&quot;&nbsp;&quot;</span>&nbsp;&#43;&nbsp;osver.dwBuildNumber);&nbsp;
<span class="js__brace">}</span>&nbsp;
&nbsp;
</pre>
</div>
</div>
<div class="endscriptcode">&nbsp;</div>
<p>構造体を初期化し、書き込み可能な状態にしてから、エイリアスである GetVersionExW 関数を呼んでいます。<br>
パラメータは構造体のポインタです。<br>
GetVersionEx 関数の呼び出しに失敗すると、戻り値として 0 が返ってきます (dwOSVersionInfoSize を設定せずに呼び出した場合など)。<br>
正しく処理された場合、メジャー バージョン、マイナー バージョン、ビルド番号を表示します。<br>
Windows 7 上で実行すると以下のように表示されます。</p>
<h2>実行結果</h2>
<p><img src="17508-sample1_2.png" alt="" width="491" height="218"></p>
<p>メジャー バージョンとマイナー バージョンの組み合わせは下図の通りです。<br>
上記コードで構造体のメンバにも加えている通り、サービスパックの情報など、&#26684;納できる情報は他にもあります。<br>
詳しくは <a href="http://msdn.microsoft.com/en-us/library/ms724833(v=vs.85).aspx" target="_blank">
OSVERSIONINFOEX&nbsp; Structure</a>&nbsp;をご参照ください。</p>
<p>&nbsp;<img src="17509-sample1_3.png" alt="" width="380" height="331"></p>
<h2>関連リンク</h2>
<ul>
<li><span lang="EN-US"><a href="http://java.sun.com/javase/ja/6/docs/ja/api/java/lang/System.html#getProperties()" target="_blank">System (Java Platform SE 6)&nbsp;</a>&nbsp;</span>
</li><li><span lang="EN-US"><span lang="EN-US"><a href="https://jna.dev.java.net/servlets/ProjectDocumentList?folderID=7408&expandFolder=7408&folderID=0" target="_blank">jna:latest (SVN head)&nbsp;</a>&nbsp;</span></span>
</li><li><span lang="EN-US"><a href="https://jna.dev.java.net/javadoc/overview-summary.html" target="_blank">jna:OveriView (JNA API) (英語)</a></span>
</li><li><span lang="EN-US"><a href="http://msdn.microsoft.com/ja-jp/library/cc429835.aspx" target="_blank">GetVersionEx&nbsp;関数
</a></span><span lang="EN-US"><a href="http://msdn.microsoft.com/en-us/library/ms724833(v=VS.85).aspx%20GetVersionEx" target="_blank">OSVERSIONINFOEX&nbsp; Structure (英語)</a>
<div><span lang="EN-US"><a href="https://jna.dev.java.net/javadoc/com/sun/jna/Structure.html" target="_blank">Structure クラス (英語)&nbsp;</a></span></div>
</span></li></ul>
<div>
<div><span lang="EN-US">&nbsp;</span></div>
<hr>
<div style="width:914px; margin:0px; padding:0 5px">
<table>
<tbody>
<tr>
<td valign="top"><a href="http://msdn.microsoft.com/ja-jp/samplecode.recipe" target="_blank"><img src="-ff950935.coderecipe_180x70%28ja-jp,msdn.10%29.jpg" border="0" alt="Code Recipe" width="180" height="70" style="margin-top:3px"></a></td>
<td valign="top"><a href="http://msdn.microsoft.com/ja-jp/windows/" target="_blank"><img src="-ff950935.windows_180x70%28ja-jp,msdn.10%29.jpg" border="0" alt="Windows デベロッパー センター" width="180" height="70" style="margin-top:3px"></a></td>
<td valign="top">
<ul>
<li>もっと他の Windows 7 対応を見る &gt;&gt;<a href="http://msdn.microsoft.com/ja-jp/windows/gg581817" target="_blank">Windows XP から Windows 7 アプリ移行 実践ガイド へ</a>
</li><li>もっと他のコンテンツを見る &gt;&gt; <a href="http://msdn.microsoft.com/ja-jp/ff363212" target="_blank">
逆引きサンプル コード一覧へ</a> </li><li>もっと他のレシピを見る &gt;&gt; <a href="http://msdn.microsoft.com/ja-jp/samplecode.recipe" target="_blank">
Code Recipe へ</a> </li><li>もっと Windows の情報を見る &gt;&gt; <a href="http://msdn.microsoft.com/ja-jp/windows/" target="_blank">
Windows デベロッパー センターへ</a> </li></ul>
</td>
</tr>
</tbody>
</table>
<div>
<p style="margin-top:20px"><a href="#top"><img src="-top.gif" border="0" alt="">ページのトップへ</a></p>
</div>
<div class="mcePaste" id="_mcePaste" style="width:1px; height:1px; overflow:hidden; top:0px; left:-10000px">
&#65279;</div>
</div>
</div>
