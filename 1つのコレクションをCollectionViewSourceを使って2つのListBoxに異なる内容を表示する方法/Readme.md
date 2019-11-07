# 1つのコレクションをCollectionViewSourceを使って2つのListBoxに異なる内容を表示する方法
## Requires
- Visual Studio 2010
## License
- Apache License, Version 2.0
## Technologies
- WPF
## Topics
- WPF アプリケーション
## Updated
- 10/22/2011
## Description

<h1>概要</h1>
<p>CollectionViewSourceを使って同じデータ(ObservableCollection&lt;T&gt;)を異なる条件でフィルタリングして表示する方法を示します。</p>
<p>このサンプルプログラムは下記の要件を満たすように作成しています。</p>
<ol>
<li>画面の左半分にCheckBoxが表示されたListBoxがある </li><li>画面の右半分に、左半分でチェックされた項目のみ表示するListBoxがある </li><li>画面の右半分のListBoxに表示する要素が無いときにはListBox自体を表示しない </li><li>画面の左半分と右半分にそれぞれ存在するListBoxに表示するデータは、同一のコレクションを元にしている </li></ol>
<h2>サンプルプログラムの実行例</h2>
<p>実行直後<br>
画面右半分にListBoxは表示されていません。<br>
<img src="45311-ws000010.jpg" alt="" width="325" height="205">&nbsp;</p>
<p>チェックボックスにチェックを入れた後<br>
画面右半分にListBoxが表示され、チェックされた項目が表示されます。<br>
<img src="45312-ws000011.jpg" alt="" width="323" height="203">&nbsp;</p>
<p><span style="font-size:20px; font-weight:bold">CollectionViewSourceの概要</span></p>
<p>CollectionViewSourceは、もとになるコレクションを操作することなく、フィルタリングやグルーピング機能を提供するクラスです。CollectionViewSourceクラスのSourceプロパティに設定されたコレクションを元に、CollectionViewSourceに指定された並び替え条件やフィルタリングの条件を適用した結果をICollectionView型のViewプロパティが表しています。</p>
<p>また、Sourceに指定されたコレクションがINotifyCollectionChangedインターフェースを実装している場合はSourceのコレクションの変更に対してViewプロパティのICollectionViewも同期して内容が更新されます。</p>
<p>このCollectionViewSourceから取得できるICollectionViewをListBoxなどのItemsControl系のコントロールにバインドすることで同一のコレクションにたいして異なる条件でのフィルタリングやグルーピングを実現できます。</p>
<h1>サンプルプログラムの内容</h1>
<p>このサンプルプログラムで使われてる主なクラスを以下に示します。</p>
<ol>
<li>Itemクラス<br>
ListBoxに表示するクラス。表示用の文字列を持つLabelプロパティとチェック状態を持つCheckedプロパティを定義しています。 </li><li>MainPageViewModelクラス<br>
Itemクラスのコレクションと、コレクション内の全ての項目を持つICollectionView型のAllItemsプロパティとチェック済みの項目のみを持つICollectionView型のCheckedItemsプロパティを定義しています。また、チェックされた項目が１つ以上あるかどうかを表すHaveCheckedItemプロパティも定義しています。
</li></ol>
<p>このサンプルプログラムの主な処理を行っている箇所のコードを抜粋します。</p>
<p>&nbsp;</p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>C#</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">スクリプトの編集</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">csharp</span>
<pre class="hidden">// テスト用のデータ作成
this.Items = new ObservableCollection&lt;Item&gt;
{
    new Item { Label = &quot;Item1&quot; },
    new Item { Label = &quot;Item2&quot; },
    new Item { Label = &quot;Item3&quot; }
};

foreach (var item in this.Items)
{
    // Checkedの状態が変更したタイミングでCheckedItemの表示の更新と
    // HaveCheckedItemの状態を更新する。
    item.PropertyChanged &#43;= (s, e) =&gt;
    {
        if (e.PropertyName != &quot;Checked&quot;)
        {
            return;
        }

        this.CheckedItems.Refresh();
        this.HaveCheckedItem = !this.CheckedItems.IsEmpty;
    };
}

// 全てのアイテムを表示するViewSourceを作成
this.allItemsSource = new CollectionViewSource
{
    Source = this.Items
};

// Checkedがtrueの項目だけ表示するViewSourceを作成
this.checkedItemsSource = new CollectionViewSource
{
    Source = this.Items
};
this.checkedItemsSource.Filter &#43;= (s, e) =&gt;
{
    var item = e.Item as Item;
    e.Accepted = item.Checked;
};
</pre>
<div class="preview">
<pre class="js"><span class="js__sl_comment">//&nbsp;テスト用のデータ作成</span>&nbsp;
<span class="js__operator">this</span>.Items&nbsp;=&nbsp;<span class="js__operator">new</span>&nbsp;ObservableCollection&lt;Item&gt;&nbsp;
<span class="js__brace">{</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__operator">new</span>&nbsp;Item&nbsp;<span class="js__brace">{</span>&nbsp;Label&nbsp;=&nbsp;<span class="js__string">&quot;Item1&quot;</span>&nbsp;<span class="js__brace">}</span>,&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__operator">new</span>&nbsp;Item&nbsp;<span class="js__brace">{</span>&nbsp;Label&nbsp;=&nbsp;<span class="js__string">&quot;Item2&quot;</span>&nbsp;<span class="js__brace">}</span>,&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__operator">new</span>&nbsp;Item&nbsp;<span class="js__brace">{</span>&nbsp;Label&nbsp;=&nbsp;<span class="js__string">&quot;Item3&quot;</span>&nbsp;<span class="js__brace">}</span>&nbsp;
<span class="js__brace">}</span>;&nbsp;
&nbsp;
foreach&nbsp;(<span class="js__statement">var</span>&nbsp;item&nbsp;<span class="js__operator">in</span>&nbsp;<span class="js__operator">this</span>.Items)&nbsp;
<span class="js__brace">{</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__sl_comment">//&nbsp;Checkedの状態が変更したタイミングでCheckedItemの表示の更新と</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__sl_comment">//&nbsp;HaveCheckedItemの状態を更新する。</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;item.PropertyChanged&nbsp;&#43;=&nbsp;(s,&nbsp;e)&nbsp;=&gt;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">{</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__statement">if</span>&nbsp;(e.PropertyName&nbsp;!=&nbsp;<span class="js__string">&quot;Checked&quot;</span>)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">{</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__statement">return</span>;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">}</span>&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__operator">this</span>.CheckedItems.Refresh();&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__operator">this</span>.HaveCheckedItem&nbsp;=&nbsp;!<span class="js__operator">this</span>.CheckedItems.IsEmpty;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">}</span>;&nbsp;
<span class="js__brace">}</span>&nbsp;
&nbsp;
<span class="js__sl_comment">//&nbsp;全てのアイテムを表示するViewSourceを作成</span>&nbsp;
<span class="js__operator">this</span>.allItemsSource&nbsp;=&nbsp;<span class="js__operator">new</span>&nbsp;CollectionViewSource&nbsp;
<span class="js__brace">{</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;Source&nbsp;=&nbsp;<span class="js__operator">this</span>.Items&nbsp;
<span class="js__brace">}</span>;&nbsp;
&nbsp;
<span class="js__sl_comment">//&nbsp;Checkedがtrueの項目だけ表示するViewSourceを作成</span>&nbsp;
<span class="js__operator">this</span>.checkedItemsSource&nbsp;=&nbsp;<span class="js__operator">new</span>&nbsp;CollectionViewSource&nbsp;
<span class="js__brace">{</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;Source&nbsp;=&nbsp;<span class="js__operator">this</span>.Items&nbsp;
<span class="js__brace">}</span>;&nbsp;
<span class="js__operator">this</span>.checkedItemsSource.Filter&nbsp;&#43;=&nbsp;(s,&nbsp;e)&nbsp;=&gt;&nbsp;
<span class="js__brace">{</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__statement">var</span>&nbsp;item&nbsp;=&nbsp;e.Item&nbsp;as&nbsp;Item;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;e.Accepted&nbsp;=&nbsp;item.Checked;&nbsp;
<span class="js__brace">}</span>;&nbsp;
</pre>
</div>
</div>
</div>
<div class="endscriptcode">ItemのCheckedプロパティが変更されたタイミングでCheckedItemsのリフレッシュとチェックされた項目が存在するか確認をしています。そして、XAMLでHaveCheckedItemの値を画面右半分に表示されているListBoxのVisibilityプロパティとバインドしています。バインドの際にbool型からVisibility型に変換するConverterをはさむことで型のミスマッチを解決しています。</div>
<div class="endscriptcode"></div>
<div class="endscriptcode">
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>XAML</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">スクリプトの編集</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">xaml</span>
<pre class="hidden">&lt;ListBox  
    Grid.Row=&quot;1&quot; 
    Grid.Column=&quot;2&quot; 
    ItemsSource=&quot;{Binding Path=CheckedItems}&quot; 
    Visibility=&quot;{Binding Path=HaveCheckedItem, Converter={StaticResource BooleanToVisibilityConverter}}&quot;&gt;
    &lt;ListBox.ItemTemplate&gt;
        &lt;DataTemplate DataType=&quot;l:Item&quot;&gt;
            &lt;TextBlock Text=&quot;{Binding Label}&quot;/&gt;
        &lt;/DataTemplate&gt;
    &lt;/ListBox.ItemTemplate&gt;
&lt;/ListBox&gt;
</pre>
<div class="preview">
<pre class="xaml"><span class="xaml__tag_start">&lt;ListBox</span>&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;Grid.<span class="xaml__attr_name">Row</span>=<span class="xaml__attr_value">&quot;1&quot;</span>&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;Grid.<span class="xaml__attr_name">Column</span>=<span class="xaml__attr_value">&quot;2&quot;</span>&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="xaml__attr_name">ItemsSource</span>=<span class="xaml__attr_value">&quot;{Binding&nbsp;Path=CheckedItems}&quot;</span>&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="xaml__attr_name">Visibility</span>=<span class="xaml__attr_value">&quot;{Binding&nbsp;Path=HaveCheckedItem,&nbsp;Converter={StaticResource&nbsp;BooleanToVisibilityConverter}}&quot;</span><span class="xaml__tag_start">&gt;&nbsp;
</span>&nbsp;&nbsp;&nbsp;&nbsp;<span class="xaml__tag_start">&lt;ListBox</span>.ItemTemplate<span class="xaml__tag_start">&gt;&nbsp;
</span>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="xaml__tag_start">&lt;DataTemplate</span>&nbsp;<span class="xaml__attr_name">DataType</span>=<span class="xaml__attr_value">&quot;l:Item&quot;</span><span class="xaml__tag_start">&gt;&nbsp;
</span>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="xaml__tag_start">&lt;TextBlock</span>&nbsp;<span class="xaml__attr_name">Text</span>=<span class="xaml__attr_value">&quot;{Binding&nbsp;Label}&quot;</span><span class="xaml__tag_start">/&gt;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="xaml__tag_end">&lt;/DataTemplate&gt;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&lt;/ListBox.ItemTemplate&gt;&nbsp;
<span class="xaml__tag_end">&lt;/ListBox&gt;</span>&nbsp;
</pre>
</div>
</div>
</div>
<div class="endscriptcode">以上でコードの主要部分の解説は終了です。実際にコードサンプルをダウンロードして動作を確認してみてください。</div>
</div>
<div class="endscriptcode"></div>
<h1 class="endscriptcode">注意事項</h1>
<p>この方法は、1項目がチェックされる度に全ての項目をリフレッシュしなおしたり、全項目を走査してチェック済みの項目の存在確認をしています。この方法は実装が簡単ですが、件数が増えるとパフォーマンスが劣化すると考えられます。要素数が多い場合は、CollectionViewSourceを使用するのではなく、自前で同様のフィルタリング処理を行うカスタムクラスを作成したり、チェックの状態が変更されるタイミングで全走査しなくても良いようにチェック項目数を管理するなどの工夫が必要になります。</p>
