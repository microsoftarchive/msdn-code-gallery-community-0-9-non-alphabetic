# パスワードをハッシュ化する方法（.NET4.5 & WinRT)
## Requires
- Visual Studio 2012
## License
- Apache License, Version 2.0
## Technologies
- Windows Runtime
- .NET Framework 4.5
## Topics
- Security
## Updated
- 08/28/2013
## Description

<h1>変更履歴</h1>
<p>2013/8/29 ストレッチングのロジックに不具合があり、ストレッチできていなかった点を修正しました。</p>
<h1>サンプルプログラムの概要</h1>
<p>このサンプルプログラムでは、パスワードをハッシュ化して保存する一般的な方法であるソルトとストレッチングを使ったコード例を示します。ソルトとストレッチングを使ったパスワードのハッシュについては、以下のサイトを参考にしました。</p>
<ul>
<li>ハッシュとソルト、ストレッチングを正しく理解する - 本当は怖いパスワードの話<br>
<ul>
<li>http://www.atmarkit.co.jp/fsecurity/special/165pswd/01.html </li></ul>
</li></ul>
<h1>サンプルプログラムのポイント</h1>
<p>このサンプルプログラムでは、.NET Framework 4.5とWindows ストア アプリのWindows Runtimeを対象にしています。両方のプラットフォームで共通の処理は、両方のプラットフォームをターゲットとしたPortable Class Libraryとして実装をして、プラットフォーム固有の機能のみを、各プラットフォーム用のクラスライブラリとして実装しています。</p>
<h1>サンプルプログラムのプロジェクト</h1>
<h2>ライブラリ部分</h2>
<ul>
<li>HashSample.Portable<br>
両方のプラットフォーム共通の処理をまとめたポータブルライブラリのプロジェクト&nbsp; </li><li>HashSample.NET45<br>
.NET Framework 4.5固有の処理をまとめたクラスライブラリ&nbsp; </li><li>HashSample.WinRT<br>
Windows Runtime固有の処理をまとめたクラスライブラリ </li></ul>
<h2>テストアプリケーション部分</h2>
<ul>
<li>HashSample.NET45.Client<br>
HashSample.Portableプロジェクトと、HashSample.NET45プロジェクトを参照しているWPFアプリケーションです。 </li><li>HashSample.WinRT.Client<br>
HashSample.Portableプロジェクトと、HashSample.WinRTプロジェクトを参照しているWindowsストアアプリです。 </li></ul>
<h1>サンプルプログラムの解説</h1>
<p>このサンプルプログラムではハッシュのアルゴリズムとしてSHA256を使用しています。このSHA256を求める処理は.NET Framework 4.5とWindows RuntimeではAPIが異なっています。そのためポータブルクラスライブラリでは、ハッシュを生成する部分のみを抽象メソッドとして定義した以下のようなクラスを作成しています。</p>
<p>&nbsp;</p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>C#</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">スクリプトの編集</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">csharp</span>

<div class="preview">
<pre class="csharp"><span class="cs__keyword">using</span>&nbsp;System;&nbsp;
<span class="cs__keyword">using</span>&nbsp;<a class="libraryLink" href="http://msdn.microsoft.com/ja-JP/library/System.Collections.Generic.aspx" target="_blank" title="Auto generated link to System.Collections.Generic">System.Collections.Generic</a>;&nbsp;
<span class="cs__keyword">using</span>&nbsp;<a class="libraryLink" href="http://msdn.microsoft.com/ja-JP/library/System.Linq.aspx" target="_blank" title="Auto generated link to System.Linq">System.Linq</a>;&nbsp;
<span class="cs__keyword">using</span>&nbsp;<a class="libraryLink" href="http://msdn.microsoft.com/ja-JP/library/System.Text.aspx" target="_blank" title="Auto generated link to System.Text">System.Text</a>;&nbsp;
<span class="cs__keyword">using</span>&nbsp;<a class="libraryLink" href="http://msdn.microsoft.com/ja-JP/library/System.Threading.Tasks.aspx" target="_blank" title="Auto generated link to System.Threading.Tasks">System.Threading.Tasks</a>;&nbsp;
&nbsp;
<span class="cs__keyword">namespace</span>&nbsp;HashSample.Portable&nbsp;
{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">public</span>&nbsp;<span class="cs__keyword">abstract</span>&nbsp;<span class="cs__keyword">class</span>&nbsp;PasswordHashBase&nbsp;:&nbsp;IPasswordHash&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">public</span>&nbsp;<span class="cs__keyword">string</span>&nbsp;GetHashData(<span class="cs__keyword">string</span>&nbsp;salt,&nbsp;<span class="cs__keyword">int</span>&nbsp;stretchCount,&nbsp;<span class="cs__keyword">string</span>&nbsp;password)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;var&nbsp;hashedSalt&nbsp;=&nbsp;<span class="cs__keyword">this</span>.ComputeHash(salt);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;var&nbsp;result&nbsp;=&nbsp;password;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">foreach</span>&nbsp;(var&nbsp;_&nbsp;<span class="cs__keyword">in</span>&nbsp;Enumerable.Repeat(<span class="cs__number">0</span>,&nbsp;stretchCount))&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;result&nbsp;=&nbsp;<span class="cs__keyword">this</span>.ComputeHash(hashedSalt&nbsp;&#43;&nbsp;result);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">return</span>&nbsp;result;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">protected</span>&nbsp;<span class="cs__keyword">abstract</span>&nbsp;<span class="cs__keyword">string</span>&nbsp;ComputeHash(<span class="cs__keyword">string</span>&nbsp;input);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
}&nbsp;
</pre>
</div>
</div>
</div>
<div class="endscriptcode">&nbsp;</div>
<p>&nbsp;</p>
<p>.NET Framework 4.5ではこのクラスを継承してSHA256クラスを使ってハッシュを求めています。</p>
<p>&nbsp;</p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>C#</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">スクリプトの編集</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">csharp</span>

<div class="preview">
<pre class="csharp"><span class="cs__keyword">using</span>&nbsp;HashSample.Portable;&nbsp;
<span class="cs__keyword">using</span>&nbsp;<a class="libraryLink" href="http://msdn.microsoft.com/ja-JP/library/System.Security.Cryptography.aspx" target="_blank" title="Auto generated link to System.Security.Cryptography">System.Security.Cryptography</a>;&nbsp;
<span class="cs__keyword">using</span>&nbsp;<a class="libraryLink" href="http://msdn.microsoft.com/ja-JP/library/System.Text.aspx" target="_blank" title="Auto generated link to System.Text">System.Text</a>;&nbsp;
&nbsp;
<span class="cs__keyword">namespace</span>&nbsp;HashSample&nbsp;
{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">public</span>&nbsp;<span class="cs__keyword">class</span>&nbsp;PasswordHash&nbsp;:&nbsp;PasswordHashBase&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">protected</span>&nbsp;<span class="cs__keyword">override</span>&nbsp;<span class="cs__keyword">string</span>&nbsp;ComputeHash(<span class="cs__keyword">string</span>&nbsp;input)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">return</span>&nbsp;<a class="libraryLink" href="http://msdn.microsoft.com/ja-JP/library/System.Convert.ToBase64String.aspx" target="_blank" title="Auto generated link to System.Convert.ToBase64String">System.Convert.ToBase64String</a>(&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;SHA256Managed.Create().ComputeHash(Encoding.UTF8.GetBytes(input)));&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
}&nbsp;
</pre>
</div>
</div>
</div>
<div class="endscriptcode">&nbsp;</div>
<p>Windows Runtimeでは、HashAlgorithmProviderからSha256のハッシュアルゴリズムを取得してハッシュを求めています。</p>
<p>&nbsp;</p>
<p>&nbsp;</p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>C#</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">スクリプトの編集</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">csharp</span>

<div class="preview">
<pre class="csharp"><span class="cs__keyword">using</span>&nbsp;HashSample.Portable;&nbsp;
<span class="cs__keyword">using</span>&nbsp;Windows.Security.Cryptography;&nbsp;
<span class="cs__keyword">using</span>&nbsp;Windows.Security.Cryptography.Core;&nbsp;
&nbsp;
<span class="cs__keyword">namespace</span>&nbsp;HashSample&nbsp;
{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">public</span>&nbsp;<span class="cs__keyword">class</span>&nbsp;PasswordHash&nbsp;:&nbsp;PasswordHashBase&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">protected</span>&nbsp;<span class="cs__keyword">override</span>&nbsp;<span class="cs__keyword">string</span>&nbsp;ComputeHash(<span class="cs__keyword">string</span>&nbsp;input)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;var&nbsp;provider&nbsp;=&nbsp;HashAlgorithmProvider.OpenAlgorithm(HashAlgorithmNames.Sha256);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;var&nbsp;buffer&nbsp;=&nbsp;CryptographicBuffer.ConvertStringToBinary(input,&nbsp;BinaryStringEncoding.Utf8);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;var&nbsp;hashedBuffer&nbsp;=&nbsp;provider.HashData(buffer);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">return</span>&nbsp;CryptographicBuffer.EncodeToBase64String(hashedBuffer);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
}&nbsp;
</pre>
</div>
</div>
</div>
<div class="endscriptcode">&nbsp;</div>
<p>&nbsp;</p>
<h3>プラットフォームごとの処理の呼び分け</h3>
<p>このサンプルの本題ではありませんが、以下のような処理をPortable Class Libraryに記載して、参照されているアセンブリからプラットフォーム固有の処理が書いてある型を探してインスタンス化しています。</p>
<p>&nbsp;</p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>C#</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">スクリプトの編集</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">csharp</span>

<div class="preview">
<pre class="js">using&nbsp;System;&nbsp;
using&nbsp;<a class="libraryLink" href="http://msdn.microsoft.com/ja-JP/library/System.Reflection.aspx" target="_blank" title="Auto generated link to System.Reflection">System.Reflection</a>;&nbsp;
&nbsp;
namespace&nbsp;HashSample.Portable&nbsp;
<span class="js__brace">{</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;public&nbsp;static&nbsp;class&nbsp;PasswordHashProvider&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">{</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;static&nbsp;PasswordHashProvider()&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">{</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__statement">var</span>&nbsp;type&nbsp;=&nbsp;<span class="js__operator">typeof</span>(PasswordHashProvider).GetTypeInfo();&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__statement">var</span>&nbsp;fullName&nbsp;=&nbsp;<span class="js__string">&quot;HashSample.PasswordHash,&nbsp;&quot;</span>&nbsp;&#43;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__operator">new</span>&nbsp;AssemblyName(type.Assembly.FullName)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">{</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Name&nbsp;=&nbsp;<span class="js__string">&quot;HashSample.Platform&quot;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">}</span>;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__statement">var</span>&nbsp;passwordHashType&nbsp;=&nbsp;Type.GetType(fullName);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__statement">if</span>&nbsp;(passwordHashType&nbsp;==&nbsp;null)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">{</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__statement">throw</span>&nbsp;<span class="js__operator">new</span>&nbsp;NotSupportedException(<span class="js__string">&quot;HashSample.Platform.dllが見つかりません&quot;</span>);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">}</span>&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;PasswordHash&nbsp;=&nbsp;(IPasswordHash)Activator.CreateInstance(passwordHashType);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">}</span>&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;public&nbsp;static&nbsp;IPasswordHash&nbsp;PasswordHash&nbsp;<span class="js__brace">{</span>&nbsp;get;&nbsp;private&nbsp;set;&nbsp;<span class="js__brace">}</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">}</span>&nbsp;
<span class="js__brace">}</span>&nbsp;
</pre>
</div>
</div>
</div>
<div class="endscriptcode">&nbsp;</div>
<p>&nbsp;</p>
<p>こうすることで、.NET Framework 4.5用のライブラリとポータブルクラスライブラリを参照することで.NET用の具象クラスがインスタンス化され、Windows Runtime用のライブラリとポータブルクラスライブラリを参照することでWinRT用の具象クラスをインスタンス化しています。</p>
<h1>サンプルプログラムの実行例</h1>
<p>このサンプルプログラムを実行すると、WPFとストアアプリの両方が起動します。TextBoxにパスワードの元の文字を入力してボタンを押すと、TextBlockにハッシュが表示されます。</p>
<p><img id="95064" src="95064-wpf.png" alt="" width="367" height="181"></p>
<p><img id="95065" src="95065-winrt.png" alt="" width="616" height="336"></p>
