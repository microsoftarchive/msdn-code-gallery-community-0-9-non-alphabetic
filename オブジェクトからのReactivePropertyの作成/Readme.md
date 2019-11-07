# オブジェクトからのReactivePropertyの作成
## Requires
- Visual Studio 2013
## License
- Apache License, Version 2.0
## Technologies
- Reactive Extensions
- ReactiveProperty
## Topics
- ReactiveProperty
## Updated
- 10/09/2014
## Description

<h1>サンプルプログラムの概要</h1>
<p>このサンプルプログラムは、ReactiveProperty&lt;T&gt;をINotifyPropertyChangedを実装したクラスから作成する方法を示しています。</p>
<h1>サンプルプログラムの動かし方</h1>
<p>サンプルプログラムを動かすには、NuGetパッケージの復元を有効化してリビルドして実行をしてください。</p>
<h1>サンプルプログラムの解説</h1>
<p>ReactivePropertyでは、INotifyPropertyChangedを実装したクラスからReactiveProperty&lt;T&gt;クラスのインスタンスを作る方法を提供しています。この一連の方法を使うことで、PlaneなC#のオブジェクトからReactivePropertyに対応したViewModelクラスを簡単に作ることができるようになります。</p>
<p>このサンプルプログラムの前提として、以下のようなINotifyPropertyChangedを実装したクラスがあるものとします。</p>
<p></p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>C#</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">スクリプトの編集</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">csharp</span>
<pre class="hidden">using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace FromObjectSample
{
    public class Person : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        private void SetProperty&lt;T&gt;(ref T field, T value, [CallerMemberName]string propertyName = null)
        {
            field = value;
            var h = this.PropertyChanged;
            if (h != null) { h(this, new PropertyChangedEventArgs(propertyName)); }
        }

        private string name;

        public string Name
        {
            get { return this.name; }
            set { this.SetProperty(ref this.name, value); }
        }

    }
}
</pre>
<div class="preview">
<pre class="csharp"><span class="cs__keyword">using</span>&nbsp;System.ComponentModel;&nbsp;
<span class="cs__keyword">using</span>&nbsp;System.Runtime.CompilerServices;&nbsp;
&nbsp;
<span class="cs__keyword">namespace</span>&nbsp;FromObjectSample&nbsp;
{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">public</span>&nbsp;<span class="cs__keyword">class</span>&nbsp;Person&nbsp;:&nbsp;INotifyPropertyChanged&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">public</span>&nbsp;<span class="cs__keyword">event</span>&nbsp;PropertyChangedEventHandler&nbsp;PropertyChanged;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">private</span>&nbsp;<span class="cs__keyword">void</span>&nbsp;SetProperty&lt;T&gt;(<span class="cs__keyword">ref</span>&nbsp;T&nbsp;field,&nbsp;T&nbsp;<span class="cs__keyword">value</span>,&nbsp;[CallerMemberName]<span class="cs__keyword">string</span>&nbsp;propertyName&nbsp;=&nbsp;<span class="cs__keyword">null</span>)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;field&nbsp;=&nbsp;<span class="cs__keyword">value</span>;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;var&nbsp;h&nbsp;=&nbsp;<span class="cs__keyword">this</span>.PropertyChanged;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">if</span>&nbsp;(h&nbsp;!=&nbsp;<span class="cs__keyword">null</span>)&nbsp;{&nbsp;h(<span class="cs__keyword">this</span>,&nbsp;<span class="cs__keyword">new</span>&nbsp;PropertyChangedEventArgs(propertyName));&nbsp;}&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">private</span>&nbsp;<span class="cs__keyword">string</span>&nbsp;name;&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">public</span>&nbsp;<span class="cs__keyword">string</span>&nbsp;Name&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">get</span>&nbsp;{&nbsp;<span class="cs__keyword">return</span>&nbsp;<span class="cs__keyword">this</span>.name;&nbsp;}&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">set</span>&nbsp;{&nbsp;<span class="cs__keyword">this</span>.SetProperty(<span class="cs__keyword">ref</span>&nbsp;<span class="cs__keyword">this</span>.name,&nbsp;<span class="cs__keyword">value</span>);&nbsp;}&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
}&nbsp;
</pre>
</div>
</div>
</div>
<div class="endscriptcode">&nbsp;</div>
<p></p>
<h2>INotifyPropertyChangedからReactivePropertyへの一方通行の変換</h2>
<p>INotifyPropetyChangedを実装したクラスからReactiveProperty&lt;T&gt;への一方通行の値の変換は以下のように行います。</p>
<p></p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>C#</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">スクリプトの編集</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">csharp</span>
<pre class="hidden">// ソースからターゲットへの一方通行の値の伝搬
this.OneWay = this.p.ObserveProperty(x =&gt; x.Name).ToReactiveProperty();</pre>
<div class="preview">
<pre class="csharp"><span class="cs__com">//&nbsp;ソースからターゲットへの一方通行の値の伝搬</span>&nbsp;
<span class="cs__keyword">this</span>.OneWay&nbsp;=&nbsp;<span class="cs__keyword">this</span>.p.ObserveProperty(x&nbsp;=&gt;&nbsp;x.Name).ToReactiveProperty();</pre>
</div>
</div>
</div>
<div class="endscriptcode">&nbsp;</div>
<p></p>
<p>Codeplex.Reactive.Extensions名前空間に定義されているObserveProperty拡張メソッドで、INotifyPropertyChangedを実装したクラスのプロパティをIObservable&lt;T&gt;に変換します。この例では直接ToReactivePropertyでReactivePropertyに変換していますが、間にSelectやWhereを挟むことで、より複雑な値の変換などを行うことができます。</p>
<h2>INotifyPropetyChangedとReactivePropertyの双方向の変換</h2>
<p>ObservePropertyは一方通行の変換ですが、ToReactivePropertyAsSynchronized拡張メソッドを使うことで、双方向の値の受け渡しができます。コード例を以下に示します。</p>
<p></p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>C#</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">スクリプトの編集</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">csharp</span>
<pre class="hidden">// 単純な双方向の値の伝搬
this.TwoWay = this.p.ToReactivePropertyAsSynchronized(x =&gt; x.Name);</pre>
<div class="preview">
<pre class="js"><span class="js__sl_comment">//&nbsp;単純な双方向の値の伝搬</span>&nbsp;
<span class="js__operator">this</span>.TwoWay&nbsp;=&nbsp;<span class="js__operator">this</span>.p.ToReactivePropertyAsSynchronized(x&nbsp;=&gt;&nbsp;x.Name);</pre>
</div>
</div>
</div>
<div class="endscriptcode">&nbsp;</div>
<p></p>
<h2>INotifyPropetyChangedとReactivePropertyで値の変換を伴った双方向の変換</h2>
<p>ToReactivePropertyAsSynchronizedメソッドは、単純な双方向の変換の他に、INotifyPropertyChangedからReactiveProperty、ReactivePropertyからINotifyPropertyChangedへ値を渡すときに値の変換処理を入れることができるオーバーライドを持っています。コード例を以下に示します。</p>
<h2>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>C#</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">スクリプトの編集</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">csharp</span>
<pre class="hidden">// 値の変換を伴った双方向の値の伝搬
this.TwoWayConvert = this.p.ToReactivePropertyAsSynchronized(x =&gt; x.Name,
    // ソースからターゲットにわたるときの値の変換
    x =&gt; x &#43; &quot;さん&quot;,
    // ターゲットからソースにわたるときの値の変換
    x =&gt; x.Replace(&quot;さん&quot;, &quot;&quot;));</pre>
<div class="preview">
<pre class="csharp"><span class="cs__com">//&nbsp;値の変換を伴った双方向の値の伝搬</span>&nbsp;
<span class="cs__keyword">this</span>.TwoWayConvert&nbsp;=&nbsp;<span class="cs__keyword">this</span>.p.ToReactivePropertyAsSynchronized(x&nbsp;=&gt;&nbsp;x.Name,&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__com">//&nbsp;ソースからターゲットにわたるときの値の変換</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;x&nbsp;=&gt;&nbsp;x&nbsp;&#43;&nbsp;<span class="cs__string">&quot;さん&quot;</span>,&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__com">//&nbsp;ターゲットからソースにわたるときの値の変換</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;x&nbsp;=&gt;&nbsp;x.Replace(<span class="cs__string">&quot;さん&quot;</span>,&nbsp;<span class="cs__string">&quot;&quot;</span>));</pre>
</div>
</div>
</div>
<div class="endscriptcode">&nbsp;</div>
</h2>
<h2>もっとも柔軟な双方向の変換</h2>
<p>ToReactivePropertyAsSynchronizedメソッドは便利ですが、変換方法などが限定的です。ObservePropertyメソッドとSubscribeメソッドを使って手動で双方向の値の受け渡しを行う方法をとると、バリデーションの追加や、SelectやWhereなどのLINQのメソッドを使って柔軟に値の変換を行うことができます。コード例を以下に示します。</p>
<h1>
<h1 class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>C#</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">スクリプトの編集</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">csharp</span>
<pre class="hidden">// 一方通行とSubscribeを組み合わせて双方向の値の伝搬
this.ManualTwoWay = this.p.ObserveProperty(x =&gt; x.Name).ToReactiveProperty();
this.ManualTwoWay.Subscribe(x =&gt; this.p.Name = x);</pre>
<div class="preview">
<pre class="csharp"><span class="cs__com">//&nbsp;一方通行とSubscribeを組み合わせて双方向の値の伝搬</span>&nbsp;
<span class="cs__keyword">this</span>.ManualTwoWay&nbsp;=&nbsp;<span class="cs__keyword">this</span>.p.ObserveProperty(x&nbsp;=&gt;&nbsp;x.Name).ToReactiveProperty();&nbsp;
<span class="cs__keyword">this</span>.ManualTwoWay.Subscribe(x&nbsp;=&gt;&nbsp;<span class="cs__keyword">this</span>.p.Name&nbsp;=&nbsp;x);</pre>
</div>
</div>
</h1>
</h1>
<h1>まとめ</h1>
<p>ReactivePropertyには、様々な方法でReactiveProperty&lt;T&gt;型を作る方法を提供しています。今回はその中からINotifyPropertyChangedを実装したクラスをベースに作成する方法を紹介しました。POCOから簡単にReactivePropertyを作ることができることを感じていただけたと思います。</p>
