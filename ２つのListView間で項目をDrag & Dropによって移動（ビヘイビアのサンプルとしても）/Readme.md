# ２つのListView間で項目をDrag & Dropによって移動（ビヘイビアのサンプルとしても）
## Requires
- Visual Studio 2013
## License
- MIT
## Technologies
- C#
- WPF
- XAML
## Topics
- C#
- WPF
- XAML
- WPF アプリケーション
- Drag and Drop
- behavior
## Updated
- 04/15/2015
## Description

<h1>はじめに</h1>
<p>Drag &amp; Dropで移動を行うためには、移動元から移動したデータを削除する必要があります。単純な方法は移動元の参照を移動先に通知することです。このサンプルでは移動先に渡されるDataObjectオブジェクトにその情報を持たせることによって解決しています。また、本サンプルはビヘイビアを使っており、それについても動作原理の概要を説明しています。本サンプルの主旨から外れるのでビヘイビアについての詳しい説明はしていませんが、本サンプルで使用しているビヘイビアは単純であり、その概要説明と相まって、ビヘイビアの理解が深まるサンプルにもなっていると思います。</p>
<p><strong><span style="font-size:2em">動作環境</span></strong></p>
<p>このサンプルはVisual Studio 2013 Ultimateで作成していますが、コード自体はそれ以前のVisual Studioでも動作すると思います。また、このサンプルには別途 System.Windows.Interactivity.dll が必要です。このdllはBlendと共にインストールされますが、以下からもダウンロードしてインストールすることができます。</p>
<p>Microsoft Expression Blend 4 Software Development Kit (SDK) for .NET4<br>
<a href="http://www.microsoft.com/ja-jp/download/details.aspx?id=10801" target="_blank">http://www.microsoft.com/ja-jp/download/details.aspx?id=10801</a></p>
<p><strong><span style="font-size:2em">操作の説明</span></strong></p>
<p>特に難しいことはありません。２つのListView間で項目をDrag &amp; Dropして下さい。項目が移動します。起動直後の画面を以下に示します。</p>
<p><img id="119564" src="119564-%e8%b5%b7%e5%8b%95%e7%9b%b4%e5%be%8c.jpg" alt="" width="525" height="350"></p>
<p>次に、Drag &amp; Dropにて項目を移動させた状態の画面を以下に示します。</p>
<p><img id="119565" src="119565-%e5%85%a5%e3%82%8c%e6%9b%bf%e3%81%88%e5%be%8c.jpg" alt="" width="525" height="350"></p>
<p><strong><span style="font-size:2em">コードの説明</span></strong></p>
<p>このサンプルの最大の目的は、Drag &amp; Dropによる項目の移動です。移動ということは、Drag元のデータを削除しなければなりません。ネット上にある多くのサンプルはコピーなので、Drag先に渡るのは項目だけです。これではどこからDragされてきたのかがわかりません。<br>
ではどうすればいいのでしょうか？<br>
実は簡単なことで、項目と一緒にどこからDragされてきたのかという情報を付加すれば良いのです。それを行っているのが以下のコードです。<br>
DataObjectクラスのSetDataメソッドは型毎に複数のデータを保持することができます。わかってしまえば簡単なことなのですが、これについて触れている記事をあまり見たことがありませんので、気付きにくいポイントだと思います。&nbsp;</p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>C#</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">スクリプトの編集</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">csharp</span>
<pre class="hidden">//BeginDrag.cs

var data = new DataObject();

data.SetData(typeof(Person), lv.SelectedItem);
data.SetData(typeof(ListView), this.AssociatedObject);

DragDrop.DoDragDrop(lv, data, this.AllowedEffects);</pre>
<div class="preview">
<pre class="csharp"><span class="cs__com">//BeginDrag.cs</span>&nbsp;
&nbsp;
var&nbsp;data&nbsp;=&nbsp;<span class="cs__keyword">new</span>&nbsp;DataObject();&nbsp;
&nbsp;
data.SetData(<span class="cs__keyword">typeof</span>(Person),&nbsp;lv.SelectedItem);&nbsp;
data.SetData(<span class="cs__keyword">typeof</span>(ListView),&nbsp;<span class="cs__keyword">this</span>.AssociatedObject);&nbsp;
&nbsp;
DragDrop.DoDragDrop(lv,&nbsp;data,&nbsp;<span class="cs__keyword">this</span>.AllowedEffects);</pre>
</div>
</div>
</div>
<div class="endscriptcode">&nbsp;DropされたListViewでは、以下の様にして荷解きします。特に難しいところは無いと思います。DropされてきたPersonオブジェクトをDrag先に追加し、Drag元から削除しています。</div>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>C#</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">スクリプトの編集</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">csharp</span>
<pre class="hidden">//MainWindowViewModel.cs

void OnDragDrop(object sender, DragEventArgs args)
{
    var fromLv = args.Data.GetData(typeof(ListView)) as ListView;
    var toLv = args.Source as ListView;
    var item = args.Data.GetData(typeof(Person)) as Person;

    if (item != null)
    {
       ((ObservableCollection&lt;Person&gt;)toLv.ItemsSource).Add(item);
       ((ObservableCollection&lt;Person&gt;)fromLv.ItemsSource).Remove(item);
    }
}</pre>
<div class="preview">
<pre class="csharp"><span class="cs__com">//MainWindowViewModel.cs</span>&nbsp;
&nbsp;
<span class="cs__keyword">void</span>&nbsp;OnDragDrop(<span class="cs__keyword">object</span>&nbsp;sender,&nbsp;DragEventArgs&nbsp;args)&nbsp;
{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;var&nbsp;fromLv&nbsp;=&nbsp;args.Data.GetData(<span class="cs__keyword">typeof</span>(ListView))&nbsp;<span class="cs__keyword">as</span>&nbsp;ListView;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;var&nbsp;toLv&nbsp;=&nbsp;args.Source&nbsp;<span class="cs__keyword">as</span>&nbsp;ListView;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;var&nbsp;item&nbsp;=&nbsp;args.Data.GetData(<span class="cs__keyword">typeof</span>(Person))&nbsp;<span class="cs__keyword">as</span>&nbsp;Person;&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">if</span>&nbsp;(item&nbsp;!=&nbsp;<span class="cs__keyword">null</span>)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;((ObservableCollection&lt;Person&gt;)toLv.ItemsSource).Add(item);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;((ObservableCollection&lt;Person&gt;)fromLv.ItemsSource).Remove(item);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
}</pre>
</div>
</div>
</div>
<div class="endscriptcode">さて、今回はビヘイビアを使用しています。ビヘイビアを説明するのは本サンプルの主旨からは外れますので詳しく説明しませんが、動作の概要だけ説明しておきます。</div>
<div class="endscriptcode"></div>
<div class="endscriptcode">BeginDragビヘイビアは、Dragの開始を行います。Drag開始するためにマウスをクリックすると、BeginDragビヘイビア内でListViewのPreviewMouseDownイベントを拾い、PreviewMouseDownイベントハンドラが起動されます。このイベントハンドラで、BeginDragSpecificationsオブジェクトを中継して、MainWindowViewModelクラスのOnMouseDownメソッドが起動され、ここでDrag動作が始まります。</div>
<p>ただ、Drag開始の動作は大抵同じであることが考えられますので、BeginDragSpecificationsオブジェクトを指定しなかった場合は、BeginDragビヘイビアでデフォルトのDrag動作が始まるようになっています。以下がその部分です。</p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>C#</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">スクリプトの編集</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">csharp</span>
<pre class="hidden">void PreviewMouseDown(object sender, MouseButtonEventArgs e)
{
    var sc = Specifications;

    if (sc != null)
    {
        sc.OnMouseDown(sender, e);
        e.Handled = true;
    }
    else
    {
        //BeginDragSpecificationsが指定されなかった場合のデフォルト動作を定義する。
        switch (sender.GetType().Name)
        {
            case &quot;ListView&quot;:

                var lv = this.AssociatedObject as ListView;

                int index = lv.GetItemIndexAtPoint&lt;ListViewItem&gt;(e.GetPosition(lv));

                if (index != -1)
                {
                    lv.SelectedIndex = index;

                    var data = new DataObject();

                    data.SetData(typeof(Person), lv.SelectedItem);
                    data.SetData(typeof(ListView), this.AssociatedObject);

                    DragDrop.DoDragDrop(lv, data, this.AllowedEffects);
                }

                break;
        }
    }
}</pre>
<div class="preview">
<pre class="csharp"><span class="cs__keyword">void</span>&nbsp;PreviewMouseDown(<span class="cs__keyword">object</span>&nbsp;sender,&nbsp;MouseButtonEventArgs&nbsp;e)&nbsp;
{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;var&nbsp;sc&nbsp;=&nbsp;Specifications;&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">if</span>&nbsp;(sc&nbsp;!=&nbsp;<span class="cs__keyword">null</span>)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;sc.OnMouseDown(sender,&nbsp;e);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;e.Handled&nbsp;=&nbsp;<span class="cs__keyword">true</span>;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">else</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__com">//BeginDragSpecificationsが指定されなかった場合のデフォルト動作を定義する。</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">switch</span>&nbsp;(sender.GetType().Name)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">case</span>&nbsp;<span class="cs__string">&quot;ListView&quot;</span>:&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;var&nbsp;lv&nbsp;=&nbsp;<span class="cs__keyword">this</span>.AssociatedObject&nbsp;<span class="cs__keyword">as</span>&nbsp;ListView;&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">int</span>&nbsp;index&nbsp;=&nbsp;lv.GetItemIndexAtPoint&lt;ListViewItem&gt;(e.GetPosition(lv));&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">if</span>&nbsp;(index&nbsp;!=&nbsp;-<span class="cs__number">1</span>)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;lv.SelectedIndex&nbsp;=&nbsp;index;&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;var&nbsp;data&nbsp;=&nbsp;<span class="cs__keyword">new</span>&nbsp;DataObject();&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;data.SetData(<span class="cs__keyword">typeof</span>(Person),&nbsp;lv.SelectedItem);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;data.SetData(<span class="cs__keyword">typeof</span>(ListView),&nbsp;<span class="cs__keyword">this</span>.AssociatedObject);&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;DragDrop.DoDragDrop(lv,&nbsp;data,&nbsp;<span class="cs__keyword">this</span>.AllowedEffects);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">break</span>;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
}</pre>
</div>
</div>
</div>
<div class="endscriptcode">同様に、Drop時、およびDragOver時の動作を定義するために、AcceptDropビヘイビアとAcceptDropSpecificationsクラスが存在します。<br>
<strong>ビヘイビアとは、XAMLにC#などの言語でロジックを追加するものと言うこともできるでしょう。</strong>&nbsp;</div>
