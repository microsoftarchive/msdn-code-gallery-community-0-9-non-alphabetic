# [C#-ADO.NET] Entity Framework で IDENTITY 列を持ったテーブルに行を挿入した時の IDENTITY 列の値の取得
## Requires
- 
## License
- Apache License, Version 2.0
## Technologies
- Visual Studio 2010
## Topics
- データ アクセス開発
- 逆引きサンプル コード
## Updated
- 06/09/2011
## Description

<p>執筆者: <a href="http://msdn.microsoft.com/ja-jp/gg585574#kojima" target="_blank">
福井コンピュータ株式会社 小島 富治雄</a></p>
<p>動作確認環境: Visual Studio 2010、.NET Framework 4.0</p>
<hr>
<p>SQL Server の IDENTITY 列は、テーブルに新しい行が挿入されるときに自動的にその値がインクリメントされます。主キーとしてたいへん便利です。</p>
<p>行の挿入後に IDENTITY 列の値を取得したいことがあります。ADO.NET Entity Framework を使って行を挿入する場合の IDENTITY 列の値の取得方法をみてみましょう。</p>
<p style="margin-top:20px"><a href="#top"><img src="9536-image.png" border="0" alt=""> ページのトップへ</a></p>
<hr>
<h2>1. SQL Server 側のテーブルの準備</h2>
<p>先ず、IDENTITY 列を持ったテーブルを SQL Server 側に準備しましょう。</p>
<p style="padding-left:2em; text-indent:-1.5em">1. Visual Studio の「サーバー エクスプローラー」(Visual Studio Express Edition の場合は「データベース・エクスプローラー」) を開きます。</p>
<p style="padding-left:2em; text-indent:-1.5em">2. 「データ接続」を右クリックし、ポップアップ メニューから「接続の追加」または「新しい SQL Server データベースの作成」をします。</p>
<p style="padding-left:2em; text-indent:-1.5em">3. その接続の「テーブル」 - 「新しいテーブルの追加」でデータベースにテーブルを追加します。</p>
<p><img src="22878-cr393-01.jpg" alt="[サーバー エクスプローラー] → [データ接続] → [接続の追加] → [テーブル] → [新しいテーブルの追加]" width="413" height="257"></p>
<p style="padding-left:2em; text-indent:-1.5em">4. ここでは、試しに以下のような &quot;Item&quot; というテーブルを追加することにします。</p>
<table border="1" style="margin:.5em 2em">
<thead>
<tr>
<th colspan="5">Item</th>
</tr>
<tr>
<th>列名</th>
<th>主キー</th>
<th>データ型</th>
<th>Null を許容</th>
<th>IDENTITY の設定</th>
</tr>
</thead>
<tbody>
<tr>
<th>Id</th>
<td>○</td>
<td>int</td>
<td>&times;</td>
<td>はい</td>
</tr>
<tr>
<th>Name</th>
<td>&times;</td>
<td>nvarchar(100)</td>
<td>&times;</td>
<td>いいえ</td>
</tr>
</tbody>
</table>
<p style="padding-left:2em; text-indent:-1.5em">5. Id 列を主キーとし、IDENTITY の設定を「はい」にしておきます。</p>
<p><img src="22879-cr393-02.jpg" alt="Item テーブルを追加、Id 列を主キーとし、IDENTITY の設定を「はい」に" width="359" height="421"></p>
<p style="padding-left:2em; text-indent:-1.5em">6. または、SQL Server Management Studio などから以下の SQL を実行することでも上記 Item テーブルを作成することができます。</p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>SQL</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">スクリプトの編集</span>|<span class="pluginRemoveHolderLink">{#scriptcode_dlg.remove_script}</span></div>
<span class="hidden">mysql</span>
<pre class="hidden">CREATE TABLE [dbo].[Item](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](100) NOT NULL,
 CONSTRAINT [PK_Item] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]</pre>
<div class="preview">
<pre class="mysql"><span class="sql__keyword">CREATE</span>&nbsp;<span class="sql__keyword">TABLE</span>&nbsp;[<span class="sql__id">dbo</span>].[<span class="sql__id">Item</span>](&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;[<span class="sql__id">Id</span>]&nbsp;[<span class="sql__keyword">int</span>]&nbsp;<span class="sql__id">IDENTITY</span>(<span class="sql__number">1</span>,<span class="sql__number">1</span>)&nbsp;<span class="sql__keyword">NOT</span>&nbsp;<span class="sql__value">NULL</span>,&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;[<span class="sql__keyword">Name</span>]&nbsp;[<span class="sql__keyword">nvarchar</span>](<span class="sql__number">100</span>)&nbsp;<span class="sql__keyword">NOT</span>&nbsp;<span class="sql__value">NULL</span>,&nbsp;
&nbsp;<span class="sql__keyword">CONSTRAINT</span>&nbsp;[<span class="sql__id">PK_Item</span>]&nbsp;<span class="sql__keyword">PRIMARY</span>&nbsp;<span class="sql__keyword">KEY</span>&nbsp;<span class="sql__id">CLUSTERED</span>&nbsp;&nbsp;
(&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;[<span class="sql__id">Id</span>]&nbsp;<span class="sql__keyword">ASC</span>&nbsp;
)<span class="sql__keyword">WITH</span>&nbsp;(<span class="sql__id">PAD_INDEX</span>&nbsp;&nbsp;=&nbsp;<span class="sql__id">OFF</span>,&nbsp;<span class="sql__id">STATISTICS_NORECOMPUTE</span>&nbsp;&nbsp;=&nbsp;<span class="sql__id">OFF</span>,&nbsp;<span class="sql__id">IGNORE_DUP_KEY</span>&nbsp;=&nbsp;<span class="sql__id">OFF</span>,&nbsp;<span class="sql__id">ALLOW_ROW_LOCKS</span>&nbsp;&nbsp;=&nbsp;<span class="sql__keyword">ON</span>,&nbsp;<span class="sql__id">ALLOW_PAGE_LOCKS</span>&nbsp;&nbsp;=&nbsp;<span class="sql__keyword">ON</span>)&nbsp;<span class="sql__keyword">ON</span>&nbsp;[<span class="sql__keyword">PRIMARY</span>]&nbsp;
)&nbsp;<span class="sql__keyword">ON</span>&nbsp;[<span class="sql__keyword">PRIMARY</span>]</pre>
</div>
</div>
</div>
<div class="endscriptcode">&nbsp;</div>
<p>データベース側の準備ができましたので、これから新規行の IDENTITY 列の値の取得方法を見ていきましょう。</p>
<p style="margin-top:20px"><a href="#top"><img src="9536-image.png" border="0" alt=""> ページのトップへ</a></p>
<hr>
<h2>2. Entity Framework で行の挿入時の IDENTITY 列を取得する</h2>
<p style="padding-left:2em; text-indent:-1.5em">1. Visual Studio で、新しい「コンソール アプリケーション」を作成し、「ソリューション エクスプローラー」でプロジェクト名を右クリックします。</p>
<p style="padding-left:2em; text-indent:-1.5em">2. ポップアップ メニューから、「追加」 - 「新しい項目」を選択します。</p>
<p style="padding-left:2em; text-indent:-1.5em">3. 「新しい項目の追加」ダイアログ ボックスが開きます。「Visual C# アイテム」 - 「ADO.NET Entity Data Model」を選択します。</p>
<p style="padding-left:2em; text-indent:-1.5em">4. ここでは「名前」を &quot;ItemModel.edmx&quot; と、し「追加」ボタンを押します。</p>
<p><img src="22888-cr395-03.jpg" alt="[新しい項目の追加] ダイアログ ボックス → [Visual C# アイテム] → [ADO.NET Entity Data Model]" width="580" height="401"></p>
<p style="padding-left:2em; text-indent:-1.5em">5. 「Entity Data Model ウィザード」が開きます。</p>
<p style="padding-left:2em; text-indent:-1.5em">6. ここでは、「データベースから生成」を選択し、「次へ」ボタンを押します。</p>
<p><img src="22889-cr395-04.jpg" alt="[Entity Data Model ウィザード] → [データベースから生成] → [次へ]" width="460" height="482"></p>
<p style="padding-left:2em; text-indent:-1.5em">7. 次の画面では、既存のデータ接続を選択し、「エンティティ接続設定に名前を付けて App.Config に保存」では &quot;ItemEntities&quot; と入力して「次へ」ボタンを押します。</p>
<p><img src="22890-cr395-05.jpg" alt="[既存のデータ接続] → [エンティティ接続設定に名前を付けて App.Config に保存]" width="460" height="482"></p>
<p style="padding-left:2em; text-indent:-1.5em">8. 次の「データベース オブジェクトの選択」の画面では、「テーブル」の中の &quot;Item&quot; をチェックします。</p>
<p style="padding-left:2em; text-indent:-1.5em">9. 「生成されたオブジェクトの名前を複数化または単数化する」にもチェックを入れ、「モデル名前空間」をここでは &quot;ItemModel&quot; として、「完了」ボタンを押します。</p>
<p><img src="22891-cr395-06.jpg" alt="[データベース オブジェクトの選択] → [生成されたオブジェクトの名前を複数化または単数化する]" width="460" height="482"></p>
<p style="padding-left:2em; text-indent:-1.5em">10. 暫く待つと、&quot;ItemModel.edmx&quot; というファイルが開きます。中に以下のようなアイテムが追加されているのが分かります。</p>
<p><img src="22892-cr395-07.jpg" alt="ItemModel.edmx" width="160" height="161"></p>
<p style="padding-left:2em; text-indent:-1.5em">11. 今度は、以下のサンプル コードで試してみましょう。</p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>C#</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">スクリプトの編集</span>|<span class="pluginRemoveHolderLink">{#scriptcode_dlg.remove_script}</span></div>
<span class="hidden">csharp</span>
<pre class="hidden">namespace TypedDataSetUpdateWithIdentityColumn
{
    class Program
    {
        static void Main()
        {
            using (var itemData = new ItemEntities()) {
                // 新規 Item の INSERT
                var newItem = new Item { Name = &quot;Hoge&quot; };
                itemData.AddToItems(newItem);
                itemData.SaveChanges();
            }
        }
    }
}</pre>
<div class="preview">
<pre class="js">namespace&nbsp;TypedDataSetUpdateWithIdentityColumn&nbsp;
<span class="js__brace">{</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;class&nbsp;Program&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">{</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;static&nbsp;<span class="js__operator">void</span>&nbsp;Main()&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">{</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;using&nbsp;(<span class="js__statement">var</span>&nbsp;itemData&nbsp;=&nbsp;<span class="js__operator">new</span>&nbsp;ItemEntities())&nbsp;<span class="js__brace">{</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__sl_comment">//&nbsp;新規&nbsp;Item&nbsp;の&nbsp;INSERT</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__statement">var</span>&nbsp;newItem&nbsp;=&nbsp;<span class="js__operator">new</span>&nbsp;Item&nbsp;<span class="js__brace">{</span>&nbsp;Name&nbsp;=&nbsp;<span class="js__string">&quot;Hoge&quot;</span>&nbsp;<span class="js__brace">}</span>;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;itemData.AddToItems(newItem);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;itemData.SaveChanges();&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">}</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">}</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">}</span>&nbsp;
<span class="js__brace">}</span></pre>
</div>
</div>
</div>
<div class="endscriptcode">&nbsp;</div>
<p>12. 実行結果は、以下のようになります。</p>
<p><img src="22893-cr395-08.jpg" alt="実行結果" width="500" height="277"></p>
<p style="padding-left:2em">挿入直後の、&quot;newItem&quot; の Id に新たな値が入っているのが確認できます。</p>
<p style="margin-top:20px"><a href="#top"><img src="9536-image.png" border="0" alt=""> ページのトップへ</a></p>
<hr>
<h2>関連リンク</h2>
<ul>
<li><a href="/ja-jp/DataAccess-howto-b5a084df">SqlCommand で IDENTITY 列を持ったテーブルに行を挿入した時の IDENTITY 列の値の取得</a>
</li><li><a href="/ja-jp/DataAccess-howto-55fab6e5">DataSet で IDENTITY 列を持ったテーブルに行を挿入した時の IDENTITY 列の値の取得</a>
</li><li><a href="/ja-jp/DataAccess-howto-eecfa511">LINQ to SQL で IDENTITY 列を持ったテーブルに行を挿入した時の IDENTITY 列の値の取得</a>
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
