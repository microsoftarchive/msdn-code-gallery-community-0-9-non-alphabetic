# [VB] ConfigurationManager クラスを使用して構成ファイルから接続文字列を取得する
## License
- Apache License, Version 2.0
## Technologies
- Visual Studio 2008
- Visual Studio 2010
- Visual Studio 2005
- .NET Framework 4
- .NET Framework 2.0
- .NET Framework 3.0
- .NET Framework 3.5
## Topics
- データ アクセス開発
- 逆引きサンプル コード
## Updated
- 02/22/2011
## Description

<p>執筆者: <a href="http://msdn.microsoft.com/ja-jp/gg585574#kodaka" target="_blank">
インフォシェア株式会社 小高 太郎</a></p>
<p>動作確認環境:&nbsp;.NET Framework 2.0 以上、Visual Studio 2005 以上</p>
<hr style="clear:both; margin-bottom:8px; margin-top:20px">
<p>データベース接続情報の多くは、アプリケーションの app.config 及び web.config などの構成ファイルに保存し、管理の集中化を図ります。今回はこうした構成ファイルから、接続文字列を取得する手法をご紹介します。</p>
<p>例として以下のような app.config ファイルが存在しているとします。</p>
<div style="margin:20px 0px; padding:10px; background-color:#cccccc">
<div>
<p>&lt;?xml version=&quot;1.0&quot;?&gt;</p>
<p>&lt;configuration&gt;</p>
<p>&nbsp;&nbsp;&nbsp; &lt;configSections&gt;</p>
<p>&nbsp;&nbsp;&nbsp; &lt;/configSections&gt;</p>
<p>&nbsp;&nbsp;&nbsp; &lt;connectionStrings&gt;</p>
<p>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &lt;add name=&quot;Sample.Properties.Settings.NorthwindConnectionString&quot;</p>
<p>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; connectionString=&quot;Data Source=.;Initial Catalog=Northwind;Integrated Security=True&quot;</p>
<p>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; providerName=&quot;System.Data.SqlClient&quot;/&gt;</p>
<p>&nbsp;&nbsp;&nbsp; &lt;/connectionStrings&gt;</p>
<p>&lt;/configuration&gt;</p>
</div>
</div>
<p>この connectionString の値を取得するには ConfigurationManager クラスを使用します。このクラスを使用するには、参照設定を行い、<a class="libraryLink" href="http://msdn.microsoft.com/ja-JP/library/System.Configuration.aspx" target="_blank" title="Auto generated link to System.Configuration">System.Configuration</a> を追加する必要があります。</p>
<p><img src="http://i2.code.msdn.microsoft.com/dataaccess-howto-e6f5fe59/image/file/18561/1/image001.gif" alt="図 1" width="580" height="335"></p>
<p>コードは以下になります。取得した接続文字より SQL Server に接続してクエリを行います。</p>
<div>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>Visual Basic</span></div>
<div class="pluginEditHolderLink">スクリプトの編集</div>
<span class="hidden">vb</span>

<div class="preview">
<pre class="vb"><span class="visualBasic__keyword">Imports</span>&nbsp;System.Data.SqlClient&nbsp;
<span class="visualBasic__keyword">Imports</span>&nbsp;System.Configuration&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">Sub</span>&nbsp;Main()&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">Dim</span>&nbsp;connectionString&nbsp;<span class="visualBasic__keyword">As</span>&nbsp;<span class="visualBasic__keyword">String</span>&nbsp;=&nbsp;ConfigurationManager.ConnectionStrings(<span class="visualBasic__string">&quot;Sample.Properties.Settings.NorthwindConnectionString&quot;</span>).ConnectionString&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">Using</span>&nbsp;cn&nbsp;<span class="visualBasic__keyword">As</span>&nbsp;SqlConnection&nbsp;=&nbsp;<span class="visualBasic__keyword">New</span>&nbsp;SqlConnection(connectionString)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">Dim</span>&nbsp;cm&nbsp;<span class="visualBasic__keyword">As</span>&nbsp;SqlCommand&nbsp;=&nbsp;<span class="visualBasic__keyword">New</span>&nbsp;SqlCommand(<span class="visualBasic__string">&quot;SELECT&nbsp;*&nbsp;FROM&nbsp;Products&quot;</span>,&nbsp;cn)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;cn.Open()&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">Dim</span>&nbsp;dr&nbsp;<span class="visualBasic__keyword">As</span>&nbsp;SqlDataReader&nbsp;=&nbsp;cm.ExecuteReader()&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">While</span>&nbsp;(dr.Read())&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Console.WriteLine(dr(<span class="visualBasic__string">&quot;ProductName&quot;</span>))&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">End</span>&nbsp;<span class="visualBasic__keyword">While</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">End</span>&nbsp;<span class="visualBasic__keyword">Using</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">End</span>&nbsp;<span class="visualBasic__keyword">Sub</span>&nbsp;
&nbsp;
</pre>
</div>
</div>
</div>
</div>
<p>接続文字列は、ConfigurationManager クラスの ConnectionStrings プロパティで取得します。</p>
<p>また、ConfigurationManager クラスには、他にも AppSetting と言うプロパティが存在し、接続文字列以外の一般的な設定値を取得することができます。</p>
<p>接続文字列を、下図のようにアプリケーションの設定機能で設定している場合は、この設定値が app.config (web.config) に保存され、My.Settings.[設定名] で接続文字列を取得することも可能です。下図の場合であれば、Dim connectonString As String = My.Setting.NorthwindConnectionString のようになります。</p>
<p><img src="http://i1.code.msdn.microsoft.com/dataaccess-howto-e6f5fe59/image/file/18563/1/image002.gif" alt="図 2" width="580" height="134"><br>
[<a href="http://msdn.microsoft.com/gg585574.DataAccess-howto-e6f5fe59(ja-jp,MSDN.10).jpg" target="_blank">拡大図</a>]</p>
<h2 style="margin-top:30px">参考リンク</h2>
<ul>
<li><a href="http://msdn.microsoft.com/ja-jp/library/system.configuration.configurationmanager(v=VS.80).aspx" target="_blank">ConfigurationManager クラス</a>
</li><li><a href="http://code.msdn.microsoft.com/DataAccess-howto-db9c7b0a">[VB] 接続文字列ビルダーを使用してユーザーの入力を元に接続文字列を構築する</a>
</li></ul>
<hr style="clear:both; margin-bottom:8px; margin-top:20px">
<table>
<tbody>
<tr>
<td><a href="http://msdn.microsoft.com/ja-jp/samplecode.recipe"><img src="http://i.msdn.microsoft.com/ff950935.coderecipe_180x70%28ja-jp,MSDN.10%29.jpg" border="0" alt="Code Recipe" width="180" height="70" style="margin-top:3px"></a></td>
<td>
<ul>
<li>もっと他のコンテンツを見る &gt;&gt; <a href="http://msdn.microsoft.com/ja-jp/ff363212" target="_blank">
逆引きサンプル コード一覧へ</a> </li><li>もっと他のレシピを見る &gt;&gt; <a href="http://msdn.microsoft.com/ja-jp/samplecode.recipe">
Code Recipe へ</a> </li></ul>
</td>
</tr>
</tbody>
</table>
<p style="margin-top:20px"><a href="#top"><img src="http://www.microsoft.com/japan/msdn/nodehomes/graphics/top.gif" border="0" alt="">ページのトップへ</a></p>
