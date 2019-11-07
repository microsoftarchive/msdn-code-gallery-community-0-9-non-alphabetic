# コレクションの分割
## Requires
- Visual Studio 2010
## License
- MS-LPL
## Technologies
- C#
- LINQ
- Visual Studio 2010
## Topics
- Collections
## Updated
- 02/24/2013
## Description

<h1>概要</h1>
<p>コレクションの要素を、指定した数のコレクションに分割する方法を示します。サンプルでは、10 個の整数を含む HashSet&lt;int&gt; を 3 個の HashSet&lt;int&gt; に分割します。</p>
<p><img id="76400" src="76400-fig.png" alt="" width="574" height="259"></p>
<p>本方法では、コレクションから列挙される順番にそって要素を均等に振り分けます。つまり、要素数 90 のコレクションを&nbsp;3 つのコレクションに分割する場合、最初の 30 個を 1 番目のコレクションに、次の 30 個を 2 番目のコレクションに、残りの 30 個を&nbsp;3 番目のコレクションに割り当てます。また、コレクションの要素の列挙操作 (GetEnumerator メソッドの呼び出し) をコード内で 1 回に抑えます。実際の列挙回数は ICollection&lt;T&gt; の実装内容に依存しますが、標準的なコレクションでは
 1 回で済みます。</p>
<h1>サンプルを実行するには</h1>
<ol>
<li>Visual Studio 2010 で DividingCollection.sln を開きます。 </li><li>[デバッグ] メニューの [デバッグなしで開始] をクリックするか、Ctrl&#43;F5 を押します。 </li></ol>
<h1>説明</h1>
<p>コレクションの分割を LINQ を使って単純に書けば、以下のようになります。</p>
<div>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>C#</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">スクリプトの編集</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">csharp</span>
<pre class="hidden">var coll = new HashSet&lt;int&gt;(Enumerable.Range(1, 30));

var first = new HashSet&lt;int&gt;(coll.Skip( 0).Take(10));
var secon = new HashSet&lt;int&gt;(coll.Skip(10).Take(10));
var third = new HashSet&lt;int&gt;(coll.Skip(20).Take(10));</pre>
<div class="preview">
<pre class="csharp">var&nbsp;coll&nbsp;=&nbsp;<span class="cs__keyword">new</span>&nbsp;HashSet&lt;<span class="cs__keyword">int</span>&gt;(Enumerable.Range(<span class="cs__number">1</span>,&nbsp;<span class="cs__number">30</span>));&nbsp;
&nbsp;
var&nbsp;first&nbsp;=&nbsp;<span class="cs__keyword">new</span>&nbsp;HashSet&lt;<span class="cs__keyword">int</span>&gt;(coll.Skip(&nbsp;<span class="cs__number">0</span>).Take(<span class="cs__number">10</span>));&nbsp;
var&nbsp;secon&nbsp;=&nbsp;<span class="cs__keyword">new</span>&nbsp;HashSet&lt;<span class="cs__keyword">int</span>&gt;(coll.Skip(<span class="cs__number">10</span>).Take(<span class="cs__number">10</span>));&nbsp;
var&nbsp;third&nbsp;=&nbsp;<span class="cs__keyword">new</span>&nbsp;HashSet&lt;<span class="cs__keyword">int</span>&gt;(coll.Skip(<span class="cs__number">20</span>).Take(<span class="cs__number">10</span>));</pre>
</div>
</div>
</div>
<div class="endscriptcode">
<p>上のコードでは、30 個の要素をもつコレクションを、要素数 10 の 3 つのコレクションに分割しています。しかしこの処理では、GetEnumerator メソッドが 3 回呼ばれており、コレクションの要素数を n 、分割数を m とすると、O(nm) 操作になると考えられます。</p>
<p>これを 1 回の呼び出しで済ますために、次の拡張メソッド (とヘルパーメソッド) を定義します。</p>
</div>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>C#</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">csharp</span>
<pre class="hidden">public static IEnumerable&lt;IEnumerable&lt;T&gt;&gt; 
    Divide&lt;T&gt;(this ICollection&lt;T&gt; collection, int divisions)
{
　　// 分割後の 1 コレクションあたりの要素数を求める
    int capacity = collection.Count / divisions;
    int remainder = collection.Count % divisions;

    using (var enumerator = collection.GetEnumerator())
    {
        // コレクションの要素数が分割数で割り切れない時の処理
        for (int i = 0; i &lt; remainder; i&#43;&#43;)
            yield return Take(enumerator, capacity &#43; 1);

        for (int i = remainder; i &lt; divisions; i&#43;&#43;)
            yield return Take(enumerator, capacity);
    }
}

// 指定した数だけ列挙子を進める
private static IEnumerable&lt;T&gt; Take&lt;T&gt;(IEnumerator&lt;T&gt; enumerator, int count)
{
    while (--count &gt;= 0 &amp;&amp; enumerator.MoveNext())
        yield return enumerator.Current;
}</pre>
<div class="preview">
<pre class="csharp"><span class="cs__keyword">public</span>&nbsp;<span class="cs__keyword">static</span>&nbsp;IEnumerable&lt;IEnumerable&lt;T&gt;&gt;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;Divide&lt;T&gt;(<span class="cs__keyword">this</span>&nbsp;ICollection&lt;T&gt;&nbsp;collection,&nbsp;<span class="cs__keyword">int</span>&nbsp;divisions)&nbsp;
{&nbsp;
　　<span class="cs__com">//&nbsp;分割後の&nbsp;1&nbsp;コレクションあたりの要素数を求める</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">int</span>&nbsp;capacity&nbsp;=&nbsp;collection.Count&nbsp;/&nbsp;divisions;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">int</span>&nbsp;remainder&nbsp;=&nbsp;collection.Count&nbsp;%&nbsp;divisions;&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">using</span>&nbsp;(var&nbsp;enumerator&nbsp;=&nbsp;collection.GetEnumerator())&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__com">//&nbsp;コレクションの要素数が分割数で割り切れない時の処理</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">for</span>&nbsp;(<span class="cs__keyword">int</span>&nbsp;i&nbsp;=&nbsp;<span class="cs__number">0</span>;&nbsp;i&nbsp;&lt;&nbsp;remainder;&nbsp;i&#43;&#43;)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;yield&nbsp;<span class="cs__keyword">return</span>&nbsp;Take(enumerator,&nbsp;capacity&nbsp;&#43;&nbsp;<span class="cs__number">1</span>);&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">for</span>&nbsp;(<span class="cs__keyword">int</span>&nbsp;i&nbsp;=&nbsp;remainder;&nbsp;i&nbsp;&lt;&nbsp;divisions;&nbsp;i&#43;&#43;)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;yield&nbsp;<span class="cs__keyword">return</span>&nbsp;Take(enumerator,&nbsp;capacity);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
}&nbsp;
&nbsp;
<span class="cs__com">//&nbsp;指定した数だけ列挙子を進める</span>&nbsp;
<span class="cs__keyword">private</span>&nbsp;<span class="cs__keyword">static</span>&nbsp;IEnumerable&lt;T&gt;&nbsp;Take&lt;T&gt;(IEnumerator&lt;T&gt;&nbsp;enumerator,&nbsp;<span class="cs__keyword">int</span>&nbsp;count)&nbsp;
{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">while</span>&nbsp;(--count&nbsp;&gt;=&nbsp;<span class="cs__number">0</span>&nbsp;&amp;&amp;&nbsp;enumerator.MoveNext())&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;yield&nbsp;<span class="cs__keyword">return</span>&nbsp;enumerator.Current;&nbsp;
}</pre>
</div>
</div>
</div>
<p>GetEnumerator メソッドによって新しい列挙子を作成しなくてもすむように、IEnumerator&lt;T&gt; に対して指定した数だけ MoveNext メソッドを呼び出す Take メソッドを繰り返し使用しています。Take メソッドを抜けた後、列挙子は破棄されず途中の要素を指したままなので、再び Take メソッドを呼び出せば、その続きから指定した数だけ要素を取得できる仕組みです。</p>
<p>なお、Divide メソッド内の場合分けは、コレクションの要素数がコレクションを分割する数で割り切れない場合を処理するためです。例えば、要素数 11 のコレクションを 3 分割する場合、11 &divide; 3 = 3 余り&nbsp;2 となります。今回の仕様は「コレクションから列挙される順番にそって、要素を振り分ける」としたので、11 個の要素は 4, 4, 3 と連続的に分かれるようにする必要があります。したがって、余りが出た場合は、それに等しい数だけコレクションの要素数を 1 個余分に多くします
 (capacity &#43; 1 の部分) 。</p>
<p>Divide 拡張メソッドは次のように使用します。</p>
<div><span>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>C#</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">スクリプトの編集</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">csharp</span>
<pre class="hidden">var coll = new HashSet&lt;int&gt;(Enumerable.Range(0, 30));
var query = from sub in coll.Divide(3) select new HashSet&lt;int&gt;(sub);
var sets = query.ToArray();</pre>
<div class="preview">
<pre class="csharp">var&nbsp;coll&nbsp;=&nbsp;<span class="cs__keyword">new</span>&nbsp;HashSet&lt;<span class="cs__keyword">int</span>&gt;(Enumerable.Range(<span class="cs__number">0</span>,&nbsp;<span class="cs__number">30</span>));&nbsp;
var&nbsp;query&nbsp;=&nbsp;from&nbsp;sub&nbsp;<span class="cs__keyword">in</span>&nbsp;coll.Divide(<span class="cs__number">3</span>)&nbsp;select&nbsp;<span class="cs__keyword">new</span>&nbsp;HashSet&lt;<span class="cs__keyword">int</span>&gt;(sub);&nbsp;
var&nbsp;sets&nbsp;=&nbsp;query.ToArray();</pre>
</div>
</div>
</div>
</span>
<div class="endscriptcode">
<p>Divide メソッドの実行は遅延実行になります。GetEnumerator メソッドが呼ばれるまで、実際のコレクションの分割操作は行われません。</p>
</div>
</div>
<h1>ソースファイル</h1>
<ul>
<li><em>Program.cs - </em>コレクションを分割する拡張メソッドとコンソール アプリケーションの&nbsp;Main メソッドを含みます。 </li></ul>
<h1>More Information</h1>
<p>ICollection&lt;T&gt; に対する拡張メソッドとして書いたので、HashSet&lt;T&gt; だけでなく List&lt;T&gt; や Dictionary&lt;TKey,TValue&gt; に対しても同様の分割操作が実行できます。さらに、戻り値が IEnumerable&lt;...&gt; なので別の LINQ クエリ演算子を続けることが可能です。</p>
<p>拡張メソッドの ICollection&lt;T&gt; を IReadOnlyCollection&lt;T&gt; (.NET 4.5 向け)&nbsp;にしても動作します。</p>
<p>なお、本サンプルは How to divide a collection of objects in HashSet&nbsp;<a href="http://social.msdn.microsoft.com/Forums/en-US/csharpgeneral/thread/bc6ff5bc-e8d9-45e7-abeb-acd9e0fd2c5f/#8622d12f-380a-427c-9dbf-ad5ecbc502a3">http://social.msdn.microsoft.com/Forums/en-US/csharpgeneral/thread/bc6ff5bc-e8d9-45e7-abeb-acd9e0fd2c5f/#8622d12f-380a-427c-9dbf-ad5ecbc502a3</a>&nbsp;での調査をまとめたものです。</p>
</div>
