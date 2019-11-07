# [C#] 非同期操作を用いて、一度に複数のクエリを処理する
## Requires
- 
## License
- Apache License, Version 2.0
## Technologies
- ADO.NET
## Topics
- データ アクセス開発
- 逆引きサンプル コード
- データ型
## Updated
- 06/14/2011
## Description

<p>執筆者: <a href="http://msdn.microsoft.com/ja-jp/gg585574#kodaka" target="_blank">
インフォシェア株式会社 小高 太郎</a></p>
<p>動作確認環境: Visual Studio 2005 以上、.NET Framework 2.0 以上</p>
<hr>
<p>ADO.NET 2.0 から追加された非同期操作を用いると、アプリケーションが長時間にわたるクエリの完了を待つことなく、次のクエリ コマンドを実行することが可能になります。</p>
<p>非同期操作には、同期メソッドに対応する非同期メソッドを用います。非同期メソッドには、処理を開始する Begin パートと、処理を終了する End パートの 2 つが存在しています。</p>
<table border="1" cellspacing="0" cellpadding="5" width="100%" style="border-collapse:collapse; margin-bottom:10px">
<tbody>
<tr>
<td rowspan="2" valign="top" style="background-color:#eff3f7">同期メソッド</td>
<td colspan="2" valign="top" style="background-color:#eff3f7">非同期メソッド</td>
</tr>
<tr>
<td valign="top"><strong>Begin</strong> パート</td>
<td valign="top"><strong>End</strong> パート</td>
</tr>
<tr>
<td valign="top"><strong>ExecuteNonQuery</strong></td>
<td valign="top"><strong>BeginExecuteNonQuery</strong></td>
<td valign="top"><strong>EndExecuteNonQuery</strong></td>
</tr>
<tr>
<td valign="top"><strong>ExecuteReader</strong></td>
<td valign="top"><strong>BeginExecuteReader</strong></td>
<td valign="top"><strong>EndExecuteReader</strong></td>
</tr>
<tr>
<td valign="top"><strong>ExecuteXmlReader</strong></td>
<td valign="top"><strong>BeginExecuteXmlReader</strong></td>
<td valign="top"><strong>EndExecuteXmlReader</strong></td>
</tr>
</tbody>
</table>
<p>非同期メソッドの終了を知るには、コールバック、待機ハンドル、ポーリングを用いた手法がありますが、ここでは、ExecuteReader と待機ハンドルを用いて複数のクエリを処理する方法を紹介します。</p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>C#</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">スクリプトの編集</span>|<span class="pluginRemoveHolderLink">{#scriptcode_dlg.remove_script}</span></div>
<span class="hidden">csharp</span>
<pre class="hidden">using System.Threading;
using System.Data.SqlClient;
	
static void Main(string[] args)
{
    string ConnectionString = @&quot;Data Source=.;Integrated Security=SSPI;&quot; &#43;
                                &quot;Initial Catalog=Northwind;&quot; &#43;
                                &quot;Asynchronous Processing=true&quot;;
    using(SqlConnection cn1 = new SqlConnection(ConnectionString))
    using(SqlConnection cn2 = new SqlConnection(ConnectionString))
    using(SqlConnection cn3 = new SqlConnection(ConnectionString))
    {
        string commandText1 = &quot;WAITFOR DELAY '0:0:10';&quot; &#43;
                                &quot;SELECT * FROM Products WHERE ProductID = 10&quot;;
        string commandText2 = &quot;WAITFOR DELAY '0:0:00';&quot; &#43;
                                &quot;SELECT * FROM Products WHERE ProductID = 20&quot;;
        string commandText3 = &quot;WAITFOR DELAY '0:0:05';&quot; &#43;
                                &quot;SELECT * FROM Products WHERE ProductID = 30&quot;;
        cn1.Open();
        SqlCommand cmd1 = new SqlCommand(commandText1, cn1);
        IAsyncResult rst1 = cmd1.BeginExecuteReader();
        WaitHandle wH1 = rst1.AsyncWaitHandle;

        cn2.Open();
        SqlCommand cmd2 = new SqlCommand(commandText2, cn2);
        IAsyncResult rst2 = cmd2.BeginExecuteReader();
        WaitHandle wH2 = rst2.AsyncWaitHandle;

        cn3.Open();
        SqlCommand cmd3 = new SqlCommand(commandText3, cn3);
        IAsyncResult rst3 = cmd3.BeginExecuteReader();
        WaitHandle wH3 = rst3.AsyncWaitHandle;

        WaitHandle[] waitHandles = { wH1, wH2, wH3 };

        int index;
        for (int countWaits = 0; countWaits &lt;= 2; countWaits&#43;&#43;)
        {
            index = WaitHandle.WaitAny(waitHandles, 10000, false);

            switch (index)
            {
                case 0:
                    SqlDataReader dr1 = cmd1.EndExecuteReader(rst1);
                    DisplayReader(dr1);
                    break;
                case 1:
                    SqlDataReader dr2 = cmd2.EndExecuteReader(rst2);
                    DisplayReader(dr2);
                    break;
                case 2:
                    SqlDataReader dr3 = cmd3.EndExecuteReader(rst3);
                    DisplayReader(dr3);
                    break;
                case WaitHandle.WaitTimeout:
                    throw new Exception(&quot;タイムアウト&quot;);
            }
        }
    }
}

static void DisplayReader(SqlDataReader dr)
{
    if (dr.Read())
    {
        Console.WriteLine(dr[1].ToString() &#43; &quot;\t&quot; &#43; DateTime.Now.ToLongTimeString());
    }
    dr.Close();
}</pre>
<div class="preview">
<pre id="codePreview" class="csharp"><span class="cs__keyword">using</span>&nbsp;System.Threading;&nbsp;
<span class="cs__keyword">using</span>&nbsp;System.Data.SqlClient;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
<span class="cs__keyword">static</span>&nbsp;<span class="cs__keyword">void</span>&nbsp;Main(<span class="cs__keyword">string</span>[]&nbsp;args)&nbsp;
{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">string</span>&nbsp;ConnectionString&nbsp;=&nbsp;@<span class="cs__string">&quot;Data&nbsp;Source=.;Integrated&nbsp;Security=SSPI;&quot;</span>&nbsp;&#43;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__string">&quot;Initial&nbsp;Catalog=Northwind;&quot;</span>&nbsp;&#43;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__string">&quot;Asynchronous&nbsp;Processing=true&quot;</span>;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">using</span>(SqlConnection&nbsp;cn1&nbsp;=&nbsp;<span class="cs__keyword">new</span>&nbsp;SqlConnection(ConnectionString))&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">using</span>(SqlConnection&nbsp;cn2&nbsp;=&nbsp;<span class="cs__keyword">new</span>&nbsp;SqlConnection(ConnectionString))&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">using</span>(SqlConnection&nbsp;cn3&nbsp;=&nbsp;<span class="cs__keyword">new</span>&nbsp;SqlConnection(ConnectionString))&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">string</span>&nbsp;commandText1&nbsp;=&nbsp;<span class="cs__string">&quot;WAITFOR&nbsp;DELAY&nbsp;'0:0:10';&quot;</span>&nbsp;&#43;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__string">&quot;SELECT&nbsp;*&nbsp;FROM&nbsp;Products&nbsp;WHERE&nbsp;ProductID&nbsp;=&nbsp;10&quot;</span>;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">string</span>&nbsp;commandText2&nbsp;=&nbsp;<span class="cs__string">&quot;WAITFOR&nbsp;DELAY&nbsp;'0:0:00';&quot;</span>&nbsp;&#43;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__string">&quot;SELECT&nbsp;*&nbsp;FROM&nbsp;Products&nbsp;WHERE&nbsp;ProductID&nbsp;=&nbsp;20&quot;</span>;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">string</span>&nbsp;commandText3&nbsp;=&nbsp;<span class="cs__string">&quot;WAITFOR&nbsp;DELAY&nbsp;'0:0:05';&quot;</span>&nbsp;&#43;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__string">&quot;SELECT&nbsp;*&nbsp;FROM&nbsp;Products&nbsp;WHERE&nbsp;ProductID&nbsp;=&nbsp;30&quot;</span>;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;cn1.Open();&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;SqlCommand&nbsp;cmd1&nbsp;=&nbsp;<span class="cs__keyword">new</span>&nbsp;SqlCommand(commandText1,&nbsp;cn1);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;IAsyncResult&nbsp;rst1&nbsp;=&nbsp;cmd1.BeginExecuteReader();&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;WaitHandle&nbsp;wH1&nbsp;=&nbsp;rst1.AsyncWaitHandle;&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;cn2.Open();&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;SqlCommand&nbsp;cmd2&nbsp;=&nbsp;<span class="cs__keyword">new</span>&nbsp;SqlCommand(commandText2,&nbsp;cn2);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;IAsyncResult&nbsp;rst2&nbsp;=&nbsp;cmd2.BeginExecuteReader();&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;WaitHandle&nbsp;wH2&nbsp;=&nbsp;rst2.AsyncWaitHandle;&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;cn3.Open();&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;SqlCommand&nbsp;cmd3&nbsp;=&nbsp;<span class="cs__keyword">new</span>&nbsp;SqlCommand(commandText3,&nbsp;cn3);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;IAsyncResult&nbsp;rst3&nbsp;=&nbsp;cmd3.BeginExecuteReader();&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;WaitHandle&nbsp;wH3&nbsp;=&nbsp;rst3.AsyncWaitHandle;&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;WaitHandle[]&nbsp;waitHandles&nbsp;=&nbsp;{&nbsp;wH1,&nbsp;wH2,&nbsp;wH3&nbsp;};&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">int</span>&nbsp;index;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">for</span>&nbsp;(<span class="cs__keyword">int</span>&nbsp;countWaits&nbsp;=&nbsp;<span class="cs__number">0</span>;&nbsp;countWaits&nbsp;&lt;=&nbsp;<span class="cs__number">2</span>;&nbsp;countWaits&#43;&#43;)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;index&nbsp;=&nbsp;WaitHandle.WaitAny(waitHandles,&nbsp;<span class="cs__number">10000</span>,&nbsp;<span class="cs__keyword">false</span>);&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">switch</span>&nbsp;(index)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">case</span>&nbsp;<span class="cs__number">0</span>:&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;SqlDataReader&nbsp;dr1&nbsp;=&nbsp;cmd1.EndExecuteReader(rst1);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;DisplayReader(dr1);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">break</span>;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">case</span>&nbsp;<span class="cs__number">1</span>:&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;SqlDataReader&nbsp;dr2&nbsp;=&nbsp;cmd2.EndExecuteReader(rst2);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;DisplayReader(dr2);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">break</span>;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">case</span>&nbsp;<span class="cs__number">2</span>:&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;SqlDataReader&nbsp;dr3&nbsp;=&nbsp;cmd3.EndExecuteReader(rst3);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;DisplayReader(dr3);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">break</span>;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">case</span>&nbsp;WaitHandle.WaitTimeout:&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">throw</span>&nbsp;<span class="cs__keyword">new</span>&nbsp;Exception(<span class="cs__string">&quot;タイムアウト&quot;</span>);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
}&nbsp;
&nbsp;
<span class="cs__keyword">static</span>&nbsp;<span class="cs__keyword">void</span>&nbsp;DisplayReader(SqlDataReader&nbsp;dr)&nbsp;
{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">if</span>&nbsp;(dr.Read())&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Console.WriteLine(dr[<span class="cs__number">1</span>].ToString()&nbsp;&#43;&nbsp;<span class="cs__string">&quot;\t&quot;</span>&nbsp;&#43;&nbsp;DateTime.Now.ToLongTimeString());&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;dr.Close();&nbsp;
}</pre>
</div>
</div>
</div>
<p>上記の手法は、Wait (Any) モデルと呼ばれ、3 つの異なる接続を用いて、それぞれ別のクエリを行い、いずれかが終了したタイミングで EndExecuteReader メソッドを実行する形になります。(これとは別に、Wait (ALL) と呼ばれる、全ての終了を待つモデルも存在します。)</p>
<p>実行すると、commandText2、commandText3、commandText1 の順番に処理されるのが分かります。これは、SQL の中に WAITFOR DELAY が指定してあるためです。</p>
<p><img src="23433-img01.gif" alt="図 1" width="500" height="140"></p>
<h2 style="margin-top:30px; font-size:120%">参考リンク</h2>
<ul>
<li><a href="http://msdn.microsoft.com/ja-jp/library/zw97wx20.aspx" target="_blank">非同期操作 (ADO.NET)</a>
</li></ul>
<hr>
<table>
<tbody>
<tr>
<td><a href="http://code.msdn.microsoft.com/ja-jp"><img src="-ff950935.coderecipe_180x70%28ja-jp,msdn.10%29.jpg" border="0" alt="Code Recipe" width="180" height="70" style="margin-top:3px"></a></td>
<td><a href="http://msdn.microsoft.com/ja-jp/data" target="_blank"><img src="-ff950935.data_180x70(ja-jp,msdn.10).gif" border="0" alt="データ アクセス デベロッパー センター" width="180" height="70" style="margin-top:3px"></a></td>
<td>
<ul>
<li>もっと他のコンテンツを見る &gt;&gt; <a href="/ja-jp/ff363212" target="_blank">逆引きサンプル コード一覧へ</a>
</li><li>もっと他のレシピを見る &gt;&gt; <a href="/ja-jp">Code Recipe へ</a> </li><li>もっと データ アクセス の情報を見る &gt;&gt; <a href="/ja-jp/data" target="_blank">データ アクセス デベロッパー センターへ</a>
</li></ul>
</td>
</tr>
</tbody>
</table>
<p style="margin-top:20px"><a href="#top"><img src="9536-image.png" border="0" alt=""> ページのトップへ</a></p>
<div style="color:#ffffff">
<p>-------------------------------------------------------------------------------------------------------------</p>
<p>-------------------------------------------------------------------------------------------------------</p>
</div>
