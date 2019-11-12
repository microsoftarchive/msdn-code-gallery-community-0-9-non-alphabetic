# .Net Tips #1112 祝日を求めるには？［C#、VB］
## Requires
- Visual Studio 2012
## License
- MS-LPL
## Technologies
- .NET Framework
## Topics
- Calendar
- Holiday
- カレンダー
- 祝日
- 休日
## Updated
- 07/21/2015
## Description

<h1>Introduction</h1>
<div>これは次の記事のサンプルコードです。</div>
<blockquote>
<div>@IT 2015/07/22 掲載<br>
<img id="68637" src="-top_news025.png" alt="" width="120" height="90"><br>
<strong><a href="http://www.atmarkit.co.jp/ait/subtop/features/dotnet/dotnettips_index.html" target="_blank">.NET TIPS：</a><br>
<a href="http://www.atmarkit.co.jp/ait/articles/1507/22/news024.html" target="_blank">祝日を求めるには？［C#、VB］</a></strong><br>
<br>
カレンダーを表示するプログラムを作ろうとしたとき、厄介なのは祝日だ。日本の祝日には、特定の日に固定されていないものがあるからだ。法律に書いてある通りにロジックを組めば祝日を決定できるとはいうものの、なかなか面倒なコーディングになる。本稿では、2007年以降のある年の祝日を求める方法を紹介しよう。</div>
</blockquote>
<div><img id="140171" src="140171-01.png" alt="" width="640" height="320">
<br>
<br>
<img id="140172" src="140172-02.png" alt="" width="640" height="320"><br>
<br>
以下の解説は記事の概要である。ぜひ記事のほうもお読みいただきたい。</div>
<div>&nbsp;</div>
<h1>Building the Sample</h1>
<div>本稿では無償の Visual Studio Express 2012 for Desktop を使っている。 コードで Visual Studio 2008 / 2010 で追加された新機能を使っているため、 Visual Studio 2010 以前の環境で試す場合は適宜修正していただきたい。</div>
<div>&nbsp;</div>
<div>&nbsp;</div>
<h1>Description</h1>
<h2>● 曜日指定の祝日を求めるには？</h2>
<p>現在のところそのような祝日は全て月曜日になっているので、「○月の第N月曜日」が算出できればよい。そのようなロジックを「GetNthMonday」メソッドとしてまとめると、次のコードのようになる。</p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>Visual Basic</span><span>C#</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">スクリプトの編集</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">vb</span><span class="hidden">csharp</span>


<div class="preview">
<pre class="vb"><span class="visualBasic__keyword">Private</span>&nbsp;<span class="visualBasic__keyword">Function</span>&nbsp;GetNthMonday(nth&nbsp;<span class="visualBasic__keyword">As</span>&nbsp;<span class="visualBasic__keyword">Integer</span>,&nbsp;year&nbsp;<span class="visualBasic__keyword">As</span>&nbsp;<span class="visualBasic__keyword">Integer</span>,&nbsp;month&nbsp;<span class="visualBasic__keyword">As</span>&nbsp;<span class="visualBasic__keyword">Integer</span>)&nbsp;<span class="visualBasic__keyword">As</span>&nbsp;DateTime&nbsp;
&nbsp;
&nbsp;&nbsp;<span class="visualBasic__com">'&nbsp;指定された月の日数</span>&nbsp;
&nbsp;&nbsp;<span class="visualBasic__keyword">Dim</span>&nbsp;days&nbsp;<span class="visualBasic__keyword">As</span>&nbsp;<span class="visualBasic__keyword">Integer</span>&nbsp;=&nbsp;DateTime.DaysInMonth(year,&nbsp;month)&nbsp;
&nbsp;
&nbsp;&nbsp;<span class="visualBasic__com">'&nbsp;指定された月の全ての日から、月曜日だけを取り出す</span>&nbsp;
&nbsp;&nbsp;<span class="visualBasic__keyword">Dim</span>&nbsp;allMondays&nbsp;<span class="visualBasic__keyword">As</span>&nbsp;IEnumerable(<span class="visualBasic__keyword">Of</span>&nbsp;DateTime)&nbsp;_&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;=&nbsp;Enumerable.Range(<span class="visualBasic__number">1</span>,&nbsp;days)&nbsp;_&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;.<span class="visualBasic__keyword">Select</span>(<span class="visualBasic__keyword">Function</span>(d)&nbsp;<span class="visualBasic__keyword">New</span>&nbsp;DateTime(year,&nbsp;month,&nbsp;d))&nbsp;_&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;.Where(<span class="visualBasic__keyword">Function</span>(dt)&nbsp;dt.DayOfWeek&nbsp;=&nbsp;DayOfWeek.Monday)&nbsp;
&nbsp;&nbsp;<span class="visualBasic__com">'&nbsp;Enumerable.Rangeで1日～月末の日付（int型のコレクション）を作り</span>&nbsp;
&nbsp;&nbsp;<span class="visualBasic__com">'&nbsp;SelectでDateTime型のコレクションに変換して</span>&nbsp;
&nbsp;&nbsp;<span class="visualBasic__com">'&nbsp;Whereでそこから月曜日だけを取り出す</span>&nbsp;
&nbsp;
&nbsp;&nbsp;<span class="visualBasic__com">'&nbsp;N番目の月曜日を求める</span>&nbsp;
&nbsp;&nbsp;<span class="visualBasic__keyword">Return</span>&nbsp;allMondays.ElementAt(nth&nbsp;-&nbsp;<span class="visualBasic__number">1</span>)&nbsp;
<span class="visualBasic__keyword">End</span>&nbsp;<span class="visualBasic__keyword">Function</span>&nbsp;
</pre>
</div>
</div>
</div>
<div class="endscriptcode"></div>
<p>ここでは現代風にLINQを使ったが、「<a href="http://www.atmarkit.co.jp/fdotnet/dotnettips/785getdayofweek/getdayofweek.html" target="_blank">.NET TIPS：指定した月から特定の曜日の日付を取得するには？［C#、VB］</a>」のようにループで書いてももちろん構わないかまわない。また、剰余演算を使ってうまく式を組み立てれば、1行で求めることも可能ではある（可読性に劣るのであまりお勧めはしない）。</p>
<p>&nbsp;</p>
<h2>● 春分の日／秋分の日を求めるには？</h2>
<p>春分日／秋分日は、<a href="http://koyomi8.com/reki_doc/doc_0330.htm" target="_blank">実験式</a>から求める。そのようなロジックを「CalcVernalEquinoxDay」メソッド（春分日を求める）／「CalcAutumnalEquinoxDay」メソッド（秋分日を求める）としてまとめると、次のコードのようになる。</p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>Visual Basic</span><span>C#</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">スクリプトの編集</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">vb</span><span class="hidden">csharp</span>


<div class="preview">
<pre class="vb"><span class="visualBasic__com">'&nbsp;春分日を求める（2099年まで有効な実験式）</span>&nbsp;
<span class="visualBasic__keyword">Private</span>&nbsp;<span class="visualBasic__keyword">Function</span>&nbsp;CalcVernalEquinoxDay(year&nbsp;<span class="visualBasic__keyword">As</span>&nbsp;<span class="visualBasic__keyword">Integer</span>)&nbsp;<span class="visualBasic__keyword">As</span>&nbsp;DateTime&nbsp;
&nbsp;
&nbsp;&nbsp;<span class="visualBasic__com">'&nbsp;1.&nbsp;2000年の太陽の春分点通過日</span>&nbsp;
&nbsp;&nbsp;<span class="visualBasic__keyword">Dim</span>&nbsp;基準日&nbsp;<span class="visualBasic__keyword">As</span>&nbsp;<span class="visualBasic__keyword">Double</span>&nbsp;=&nbsp;<span class="visualBasic__number">20.69115</span>&nbsp;
&nbsp;
&nbsp;&nbsp;<span class="visualBasic__com">'&nbsp;2.&nbsp;春分点通過日の移動量＝（西暦年－2000年）&times;0.242194</span>&nbsp;
&nbsp;&nbsp;<span class="visualBasic__keyword">Dim</span>&nbsp;移動量&nbsp;<span class="visualBasic__keyword">As</span>&nbsp;<span class="visualBasic__keyword">Double</span>&nbsp;=&nbsp;(year&nbsp;-&nbsp;<span class="visualBasic__number">2000</span>)&nbsp;*&nbsp;<span class="visualBasic__number">0.242194</span>&nbsp;
&nbsp;
&nbsp;&nbsp;<span class="visualBasic__com">'&nbsp;3.&nbsp;閏年によるリセット量＝INT｛（西暦年－2000年）/&nbsp;4｝</span>&nbsp;
&nbsp;&nbsp;<span class="visualBasic__keyword">Dim</span>&nbsp;閏年補正&nbsp;<span class="visualBasic__keyword">As</span>&nbsp;<span class="visualBasic__keyword">Integer</span>&nbsp;=&nbsp;<span class="visualBasic__keyword">CType</span>(Int((year&nbsp;-&nbsp;<span class="visualBasic__number">2000</span>)&nbsp;/&nbsp;<span class="visualBasic__number">4.0</span>),&nbsp;<span class="visualBasic__keyword">Integer</span>)&nbsp;
&nbsp;
&nbsp;&nbsp;<span class="visualBasic__com">'&nbsp;求める年の春分日＝INT｛（1）＋（2）－（3）｝</span>&nbsp;
&nbsp;&nbsp;<span class="visualBasic__keyword">Dim</span>&nbsp;春分日&nbsp;<span class="visualBasic__keyword">As</span>&nbsp;<span class="visualBasic__keyword">Integer</span>&nbsp;=&nbsp;<span class="visualBasic__keyword">CType</span>(Int(基準日&nbsp;&#43;&nbsp;移動量&nbsp;-&nbsp;閏年補正),&nbsp;<span class="visualBasic__keyword">Integer</span>)&nbsp;
&nbsp;
&nbsp;&nbsp;<span class="visualBasic__keyword">Return</span>&nbsp;<span class="visualBasic__keyword">New</span>&nbsp;DateTime(year,&nbsp;<span class="visualBasic__number">3</span>,&nbsp;春分日)&nbsp;
<span class="visualBasic__keyword">End</span>&nbsp;<span class="visualBasic__keyword">Function</span>&nbsp;
&nbsp;
<span class="visualBasic__com">'&nbsp;秋分日を求める（2099年まで有効な実験式）</span>&nbsp;
<span class="visualBasic__keyword">Private</span>&nbsp;<span class="visualBasic__keyword">Function</span>&nbsp;CalcAutumnalEquinoxDay(year&nbsp;<span class="visualBasic__keyword">As</span>&nbsp;<span class="visualBasic__keyword">Integer</span>)&nbsp;<span class="visualBasic__keyword">As</span>&nbsp;DateTime&nbsp;
&nbsp;
&nbsp;&nbsp;<span class="visualBasic__com">'&nbsp;1.&nbsp;2000年の太陽の秋分点通過日</span>&nbsp;
&nbsp;&nbsp;<span class="visualBasic__keyword">Dim</span>&nbsp;基準日&nbsp;<span class="visualBasic__keyword">As</span>&nbsp;<span class="visualBasic__keyword">Double</span>&nbsp;=&nbsp;<span class="visualBasic__number">23.09</span>&nbsp;<span class="visualBasic__com">'&nbsp;秋分点の揺らぎ補正済みの値</span>&nbsp;
&nbsp;
&nbsp;&nbsp;<span class="visualBasic__com">'&nbsp;2.&nbsp;秋分点通過日の移動量＝（西暦年－2000年）&times;0.242194</span>&nbsp;
&nbsp;&nbsp;<span class="visualBasic__keyword">Dim</span>&nbsp;移動量&nbsp;<span class="visualBasic__keyword">As</span>&nbsp;<span class="visualBasic__keyword">Double</span>&nbsp;=&nbsp;(year&nbsp;-&nbsp;<span class="visualBasic__number">2000</span>)&nbsp;*&nbsp;<span class="visualBasic__number">0.242194</span>&nbsp;
&nbsp;
&nbsp;&nbsp;<span class="visualBasic__com">'&nbsp;3.&nbsp;閏年によるリセット量＝INT｛（西暦年－2000年）/&nbsp;4｝</span>&nbsp;
&nbsp;&nbsp;<span class="visualBasic__keyword">Dim</span>&nbsp;閏年補正&nbsp;<span class="visualBasic__keyword">As</span>&nbsp;<span class="visualBasic__keyword">Integer</span>&nbsp;=&nbsp;<span class="visualBasic__keyword">CType</span>(Int((year&nbsp;-&nbsp;<span class="visualBasic__number">2000</span>)&nbsp;/&nbsp;<span class="visualBasic__number">4.0</span>),&nbsp;<span class="visualBasic__keyword">Integer</span>)&nbsp;
&nbsp;
&nbsp;&nbsp;<span class="visualBasic__com">'&nbsp;求める年の秋分日＝INT｛（1）＋（2）－（3）｝</span>&nbsp;
&nbsp;&nbsp;<span class="visualBasic__keyword">Dim</span>&nbsp;秋分日&nbsp;<span class="visualBasic__keyword">As</span>&nbsp;<span class="visualBasic__keyword">Integer</span>&nbsp;=&nbsp;<span class="visualBasic__keyword">CType</span>(Int(基準日&nbsp;&#43;&nbsp;移動量&nbsp;-&nbsp;閏年補正),&nbsp;<span class="visualBasic__keyword">Integer</span>)&nbsp;
&nbsp;
&nbsp;&nbsp;<span class="visualBasic__keyword">Return</span>&nbsp;<span class="visualBasic__keyword">New</span>&nbsp;DateTime(year,&nbsp;<span class="visualBasic__number">9</span>,&nbsp;秋分日)&nbsp;
<span class="visualBasic__keyword">End</span>&nbsp;<span class="visualBasic__keyword">Function</span>&nbsp;
</pre>
</div>
</div>
</div>
<div class="endscriptcode">&nbsp;</div>
<p>&nbsp;</p>
<h2>● 振替休日を求めるには？</h2>
<p>法に定められた規則をそのままロジックに書き直せばよい。</p>
<p>国民の祝日に関する法律第三条2項には、「『国民の祝日』が日曜日に当たるときは、その日後においてその日に最も近い「国民の祝日」でない日を休日とする」と定められている。このロジックを「GetSubstituteHolidays」メソッドとしてまとめると、次のコードのようになる。</p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>Visual Basic</span><span>C#</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">スクリプトの編集</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">vb</span><span class="hidden">csharp</span>


<div class="preview">
<pre class="vb"><span class="visualBasic__com">'&nbsp;振替休日を全て求める</span>&nbsp;
<span class="visualBasic__keyword">Private</span>&nbsp;<span class="visualBasic__keyword">Function</span>&nbsp;GetSubstituteHolidays(&nbsp;
&nbsp;&nbsp;holidays&nbsp;<span class="visualBasic__keyword">As</span>&nbsp;SortedDictionary(<span class="visualBasic__keyword">Of</span>&nbsp;DateTime,&nbsp;Holiday))&nbsp;<span class="visualBasic__keyword">As</span>&nbsp;IEnumerable(<span class="visualBasic__keyword">Of</span>&nbsp;Holiday)&nbsp;
&nbsp;
&nbsp;&nbsp;<span class="visualBasic__com">'&nbsp;振替休日を&#26684;納するためのコレクション</span>&nbsp;
&nbsp;&nbsp;<span class="visualBasic__keyword">Dim</span>&nbsp;substituteHolidays&nbsp;<span class="visualBasic__keyword">As</span>&nbsp;List(<span class="visualBasic__keyword">Of</span>&nbsp;Holiday)&nbsp;=&nbsp;<span class="visualBasic__keyword">New</span>&nbsp;List(<span class="visualBasic__keyword">Of</span>&nbsp;Holiday)()&nbsp;
&nbsp;
&nbsp;&nbsp;<span class="visualBasic__com">'&nbsp;これまでに求めた祝日を全部チェックする</span>&nbsp;
&nbsp;&nbsp;<span class="visualBasic__keyword">For</span>&nbsp;<span class="visualBasic__keyword">Each</span>&nbsp;holiday&nbsp;<span class="visualBasic__keyword">In</span>&nbsp;holidays.Values&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">If</span>&nbsp;(holiday.<span class="visualBasic__keyword">Date</span>.DayOfWeek&nbsp;&lt;&gt;&nbsp;DayOfWeek.Sunday)&nbsp;<span class="visualBasic__keyword">Then</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">Continue</span>&nbsp;<span class="visualBasic__keyword">For</span>&nbsp;<span class="visualBasic__com">'&nbsp;日曜でなければ除外する</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">End</span>&nbsp;<span class="visualBasic__keyword">If</span>&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__com">'&nbsp;翌日（＝月曜日）を仮に振替休日とする</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">Dim</span>&nbsp;substitute&nbsp;<span class="visualBasic__keyword">As</span>&nbsp;DateTime&nbsp;=&nbsp;holiday.<span class="visualBasic__keyword">Date</span>.AddDays(<span class="visualBasic__number">1.0</span>)&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__com">'&nbsp;その日がすでに祝日ならば振替休日はさらにその翌日</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">While</span>&nbsp;(holidays.ContainsKey(substitute))&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;substitute&nbsp;=&nbsp;substitute.AddDays(<span class="visualBasic__number">1.0</span>)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">End</span>&nbsp;<span class="visualBasic__keyword">While</span>&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__com">'&nbsp;見つかった振替休日をコレクションに追加する</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">Dim</span>&nbsp;substituteHoliday&nbsp;=&nbsp;<span class="visualBasic__keyword">New</span>&nbsp;Holiday()&nbsp;<span class="visualBasic__keyword">With</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;.<span class="visualBasic__keyword">Date</span>&nbsp;=&nbsp;substitute,&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;.Kind&nbsp;=&nbsp;HolidayKind.振替休日,&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;.Name&nbsp;=&nbsp;<span class="visualBasic__string">&quot;振替休日&quot;</span>,&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;.Definition&nbsp;=&nbsp;<span class="visualBasic__keyword">String</span>.Format(<span class="visualBasic__string">&quot;{0}の振替休日&quot;</span>,&nbsp;holiday.Name)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;substituteHolidays.Add(substituteHoliday)&nbsp;
&nbsp;&nbsp;<span class="visualBasic__keyword">Next</span>&nbsp;
&nbsp;&nbsp;<span class="visualBasic__keyword">Return</span>&nbsp;substituteHolidays&nbsp;
<span class="visualBasic__keyword">End</span>&nbsp;<span class="visualBasic__keyword">Function</span>&nbsp;
</pre>
</div>
</div>
</div>
<div class="endscriptcode">&nbsp;</div>
<p>国民の休日も、同様に法で定められた規則をそのままロジックに書き直せばよい。</p>
<p>&nbsp;</p>
<div>&nbsp;</div>
<h1>More Information</h1>
<h2>著作権について</h2>
<div>このソースコードは MS-LPL ライセンスで提供しておりますので、 ご自由に利用いただけます。<br>
ただし、@ITの記事(ここへ転載・引用した部分も含む)そのものの著作権は、筆者とデジタルアドバンテージが保有しており、サンプルコード部分を除く記事の無断使用は固くお断りいたします。</div>
