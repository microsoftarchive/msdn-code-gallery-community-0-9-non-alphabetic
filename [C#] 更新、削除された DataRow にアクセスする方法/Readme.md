# [C#] 更新、削除された DataRow にアクセスする方法
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
- 06/20/2011
## Description

<p id="top">執筆者: <a href="http://msdn.microsoft.com/ja-jp/gg585574#kodaka" target="_blank">
インフォシェア株式会社 小高 太郎</a></p>
<p>動作確認環境: .NET Framework 1.1 以上</p>
<hr>
<p>ADO.NET には、従来の ADO などのデータ アクセス技術と同様に、データベースとの接続を開き、必要なクエリーやカーソル処理をおこなう接続型と、必要なタイミングでのみデータベースに接続を行い、クライアントのメモリー (DataSet オブジェクト) にデータをキャッシュする非接続型の、2 種類の接続方式が存在します。</p>
<p>後者の DetaSet を用いてデータの操作を行う場合、ユーザーの操作結果は、クライアントのメモリにある DataSet 内の DataTable 及び DataRow に対して変更を加えることとなります。その際、該当する DataRow の RowState プロパティは以下の表のように変化します。</p>
<table cellpadding="5" width="100%" style="border-collapse:collapse; margin-bottom:10px">
<tbody>
<tr>
<td valign="top" style="border:1px solid #666666; background-color:#eff3f7"><strong>RowState</strong></td>
<td valign="top" style="border:1px solid #666666; background-color:#eff3f7"><strong>説明</strong></td>
</tr>
<tr>
<td valign="top" style="border:1px solid #666666">Unchanged</td>
<td valign="top" style="border:1px solid #666666">AcceptChanges が最後に呼び出されてから、または DataAdapter.Fill によって行が作成されてから変更は行われていません。</td>
</tr>
<tr>
<td valign="top" style="border:1px solid #666666">Added</td>
<td valign="top" style="border:1px solid #666666">行がテーブルに追加されましたが、AcceptChanges が呼び出されていません。</td>
</tr>
<tr>
<td valign="top" style="border:1px solid #666666">Modified</td>
<td valign="top" style="border:1px solid #666666">行のいくつかの要素が変更されました。</td>
</tr>
<tr>
<td valign="top" style="border:1px solid #666666">Deleted</td>
<td valign="top" style="border:1px solid #666666">行がテーブルから削除されましたが、AcceptChanges が呼び出されていません。</td>
</tr>
<tr>
<td valign="top" style="border:1px solid #666666">Detached</td>
<td valign="top" style="border:1px solid #666666">行が、DataRowCollection にも属していません。(新しく作成された行の RowState は Detached に設定されます。Add メソッドを呼び出して新しい DataRow を DataRowCollection に追加すると、RowState プロパティの値は Added に設定されます。)
<br>
また、Detached は、Remove メソッドを使用するか、または Delete メソッドに続いて AcceptChanges メソッドを使用して DataRowCollection から削除された行に対しても設定されます。</td>
</tr>
</tbody>
</table>
<p>以下サンプル コードは、この RowState を用いて更新行を特定し、更新や削除を行った場合の更新元データにアクセスする方法をご紹介します。</p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>C#</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">スクリプトの編集</span>|<span class="pluginRemoveHolderLink">{#scriptcode_dlg.remove_script}</span></div>
<span class="hidden">csharp</span>
<pre class="hidden">using System.Data.SqlClient;
using System.Data;

static void Main(string[] args)
{
    SqlDataAdapter da = new SqlDataAdapter (&quot;SELECT * FROM Products&quot;, &quot;Data Source=.;Initial Catalog=Northwind;Integrated Security=True&quot;);
    DataSet ds = new DataSet();
    da.Fill(ds, &quot;Products&quot;);

    // データセット内の 1 行目のデータを変更
    ds.Tables[&quot;Products&quot;].Rows[0][&quot;ProductName&quot;] = &quot;更新！&quot;;

    // データセット内の3 行目のデータを削除
    ds.Tables[&quot;Products&quot;].Rows[2].Delete();

    foreach (DataRow dr in ds.Tables[&quot;Products&quot;].Rows)
    {
        switch (dr.RowState)
        {
            case DataRowState.Deleted:
                Console.WriteLine(dr[&quot;ProductName&quot;, DataRowVersion.Original].ToString() &#43; &quot; - 削除行&quot;);
                break;
            case DataRowState.Modified:
                Console.WriteLine(dr[&quot;ProductName&quot;, DataRowVersion.Original].ToString() &#43; &quot; - 更新元データ&quot;);
                Console.WriteLine(dr[&quot;ProductName&quot;, DataRowVersion.Current].ToString() &#43; &quot; - 更新データ&quot;);
                break;
            default:
                Console.WriteLine(dr[&quot;ProductName&quot;].ToString());
                break;
        }
    }
}
</pre>
<div class="preview">
<pre id="codePreview" class="vb">using&nbsp;System.Data.SqlClient;&nbsp;
using&nbsp;System.Data;&nbsp;
&nbsp;
static&nbsp;void&nbsp;Main(string[]&nbsp;args)&nbsp;
{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;SqlDataAdapter&nbsp;da&nbsp;=&nbsp;new&nbsp;SqlDataAdapter&nbsp;(<span class="visualBasic__string">&quot;SELECT&nbsp;*&nbsp;FROM&nbsp;Products&quot;</span>,&nbsp;<span class="visualBasic__string">&quot;Data&nbsp;Source=.;Initial&nbsp;Catalog=Northwind;Integrated&nbsp;Security=True&quot;</span>);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;DataSet&nbsp;ds&nbsp;=&nbsp;new&nbsp;DataSet();&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;da.Fill(ds,&nbsp;<span class="visualBasic__string">&quot;Products&quot;</span>);&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;//&nbsp;データセット内の&nbsp;<span class="visualBasic__number">1</span>&nbsp;行目のデータを変更&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;ds.Tables[<span class="visualBasic__string">&quot;Products&quot;</span>].Rows[<span class="visualBasic__number">0</span>][<span class="visualBasic__string">&quot;ProductName&quot;</span>]&nbsp;=&nbsp;<span class="visualBasic__string">&quot;更新！&quot;</span>;&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;//&nbsp;データセット内の<span class="visualBasic__number">3</span>&nbsp;行目のデータを削除&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;ds.Tables[<span class="visualBasic__string">&quot;Products&quot;</span>].Rows[<span class="visualBasic__number">2</span>].Delete();&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;foreach&nbsp;(DataRow&nbsp;dr&nbsp;in&nbsp;ds.Tables[<span class="visualBasic__string">&quot;Products&quot;</span>].Rows)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;switch&nbsp;(dr.RowState)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;case&nbsp;DataRowState.Deleted:&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Console.WriteLine(dr[<span class="visualBasic__string">&quot;ProductName&quot;</span>,&nbsp;DataRowVersion.Original].ToString()&nbsp;&#43;&nbsp;<span class="visualBasic__string">&quot;&nbsp;-&nbsp;削除行&quot;</span>);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;break;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;case&nbsp;DataRowState.Modified:&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Console.WriteLine(dr[<span class="visualBasic__string">&quot;ProductName&quot;</span>,&nbsp;DataRowVersion.Original].ToString()&nbsp;&#43;&nbsp;<span class="visualBasic__string">&quot;&nbsp;-&nbsp;更新元データ&quot;</span>);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Console.WriteLine(dr[<span class="visualBasic__string">&quot;ProductName&quot;</span>,&nbsp;DataRowVersion.Current].ToString()&nbsp;&#43;&nbsp;<span class="visualBasic__string">&quot;&nbsp;-&nbsp;更新データ&quot;</span>);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;break;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;default:&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Console.WriteLine(dr[<span class="visualBasic__string">&quot;ProductName&quot;</span>].ToString());&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;break;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
}&nbsp;
</pre>
</div>
</div>
</div>
<p>上記のコードを実行すると以下のような結果が表示されます。</p>
<p><img src="23487-407_1.jpg" alt="画像 1" width="252" height="111"></p>
<p>1 行目は、ProductName 列を Chai から更新！と更新しました。更新行の元データは <span style="color:#339966"><strong>DataRowVersion</strong></span>.Original に存在します。<br>
また、3 行目は削除しましたが、削除された元データも同じく <span style="color:#339966"><strong>DataRowVersion</strong></span>.Original に存在します。</p>
<p>DataRowVersion は以下のような値を取ります。</p>
<table cellspacing="0" cellpadding="5" width="100%" style="border-collapse:collapse; margin-bottom:10px">
<tbody>
<tr>
<td valign="top" style="border:1px solid #666666; background-color:#eff3f7"><strong>DataRowVersion</strong></td>
<td valign="top" style="border:1px solid #666666; background-color:#eff3f7"><strong>説明</strong></td>
</tr>
<tr>
<td valign="top" style="border:1px solid #666666">Current</td>
<td valign="top" style="border:1px solid #666666">行の現在の値。この行バージョンは、Deleted の RowState を持つ行については存在しません。</td>
</tr>
<tr>
<td valign="top" style="border:1px solid #666666">Default</td>
<td valign="top" style="border:1px solid #666666">特定の行の既定の行バージョン。Added、Modified、または Unchanged 行の既定の行バージョンは、Current です。Deleted 行の既定の行バージョンは、Original です。Detached 行の既定の行バージョンは、Proposed です。</td>
</tr>
<tr>
<td valign="top" style="border:1px solid #666666">Original</td>
<td valign="top" style="border:1px solid #666666">行の元の値。この行バージョンは、Added の RowState を持つ行については存在しません。</td>
</tr>
<tr>
<td valign="top" style="border:1px solid #666666">Proposed</td>
<td valign="top" style="border:1px solid #666666">行に対して提示された値。この行バージョンは、行、つまり DataRowCollection の一部ではない行に対する編集操作の間存在します。</td>
</tr>
</tbody>
</table>
<h2 style="margin-top:30px; font-size:120%">参考リンク</h2>
<ul>
<li><a href="http://msdn.microsoft.com/ja-jp/library/ww3k31w0.aspx" target="_blank">行の状態とバージョン</a>
</li></ul>
<hr>
<table>
<tbody>
<tr>
<td><a href="http://code.msdn.microsoft.com/ja-jp"><img src="-ff950935.coderecipe_180x70(ja-jp,msdn.10).jpg" border="0" alt="Code Recipe" width="180" height="70" style="margin-top:3px"></a></td>
<td><a href="http://msdn.microsoft.com/ja-jp/data" target="_blank"><img src="-ff950935.data_180x70(ja-jp,msdn.10).gif" border="0" alt="データ アクセス デベロッパー センター" width="180" height="70" style="margin-top:3px"></a></td>
<td>
<ul>
<li>もっと他のコンテンツを見る &gt;&gt; <a href="http://msdn.microsoft.com/ja-jp/ff363212" target="_blank">
逆引きサンプル コード一覧へ</a> </li><li>もっと他のレシピを見る &gt;&gt; <a href="/ja-jp">Code Recipe へ</a> </li><li>もっと データ アクセス の情報を見る &gt;&gt; <a href="http://msdn.microsoft.com/ja-jp/data" target="_blank">
データ アクセス デベロッパー センターへ</a> </li></ul>
</td>
</tr>
</tbody>
</table>
<p style="margin-top:20px"><a href="#top"><img src="-top.gif" border="0" alt=""> ページのトップへ</a></p>
