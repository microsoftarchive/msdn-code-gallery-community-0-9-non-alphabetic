# [C#] GPSによる位置情報の取得
## Requires
- 
## License
- Apache License, Version 2.0
## Technologies
- Silverlight
- Windows Phone 7
## Topics
- Silverlight アプリケーション
- Windows Phone アプリケーション
- 逆引きサンプル コード
## Updated
- 03/17/2011
## Description

<p>対応バージョン: Windows phone Developer Tools for RTM</p>
<hr style="clear:both; margin-bottom:8px; margin-top:20px">
<p style="margin-bottom:20px">GPS をはじめとするロケーション サービスを使ってデバイスの位置情報を取得するためのサンプル コードです。</p>
<p>初めに、「Project」メニューの「Add Reference」から、System.Device の参照を追加します。</p>
<p><img src="18891-image002.jpg" alt="図 1" width="269" height="195"></p>
<p>GPS をつかうには GeoCoordinateWatcher オブジェクトを使います。GeoCoordinateWatcher オブジェクトのインスタンスを作成したら、Start メソッドで GPS 入力を開始します。GPS の位置情報が変化すると、PositionChanged イベントが発生します。情報は引数である GeoPositionChangedEventArgs の Posiotion.Location.Latitude と Position.Location.Longitude から取得できます。</p>
<p>ただし、センサー イベントに対する処理は UI とは別スレッドでの処理となるため、もしセンサー内容を表示するなど UI に対して操作を行う場合は、Dispathcher.Invoke で処理を受け取るように実装する必要があります。</p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>C#</span></div>
<div class="pluginEditHolderLink">スクリプトの編集</div>
<span class="hidden">csharp</span>
<pre class="hidden">using System.Device.Location;

public MainPage()
{
    InitializeComponent();

    GeoCoordinateWatcher wtc = new GeoCoordinateWatcher();
    wtc.PositionChanged &#43;= new EventHandler&lt;GeoPositionChangedEventArgs&lt;GeoCoordinate&gt;&gt;(wtc_PositionChanged);
    wtc.Start();
}
 
void wtc_PositionChanged(object sender, GeoPositionChangedEventArgs&lt;GeoCoordinate&gt; e)
{
    Dispatcher.BeginInvoke(() =&gt;
        textBlock1.Text =
        e.Position.Location.Latitude.ToString() &#43; &quot;, &quot; &#43;
        e.Position.Location.Longitude.ToString()
        );
}</pre>
<div class="preview">
<pre class="csharp"><span class="cs__keyword">using</span>&nbsp;System.Device.Location;&nbsp;
&nbsp;
<span class="cs__keyword">public</span>&nbsp;MainPage()&nbsp;
{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;InitializeComponent();&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;GeoCoordinateWatcher&nbsp;wtc&nbsp;=&nbsp;<span class="cs__keyword">new</span>&nbsp;GeoCoordinateWatcher();&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;wtc.PositionChanged&nbsp;&#43;=&nbsp;<span class="cs__keyword">new</span>&nbsp;EventHandler&lt;GeoPositionChangedEventArgs&lt;GeoCoordinate&gt;&gt;(wtc_PositionChanged);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;wtc.Start();&nbsp;
}&nbsp;
&nbsp;&nbsp;
<span class="cs__keyword">void</span>&nbsp;wtc_PositionChanged(<span class="cs__keyword">object</span>&nbsp;sender,&nbsp;GeoPositionChangedEventArgs&lt;GeoCoordinate&gt;&nbsp;e)&nbsp;
{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;Dispatcher.BeginInvoke(()&nbsp;=&gt;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;textBlock1.Text&nbsp;=&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;e.Position.Location.Latitude.ToString()&nbsp;&#43;&nbsp;<span class="cs__string">&quot;,&nbsp;&quot;</span>&nbsp;&#43;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;e.Position.Location.Longitude.ToString()&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;);&nbsp;
}&nbsp;
&nbsp;
</pre>
</div>
</div>
</div>
<hr style="clear:both; margin-bottom:8px; margin-top:20px">
<table>
<tbody>
<tr>
<td><a href="http://code.msdn.microsoft.com/ja-jp"><img src="-ff950935.coderecipe_180x70%28ja-jp,msdn.10%29.jpg" border="0" alt="Code Recipe" width="180" height="70" style="margin-top:3px"></a></td>
<td><a href="http://msdn.microsoft.com/ja-jp/windowsphone" target="_blank"><img src="-ff950935.winphone_180x70(ja-jp,msdn.10).gif" border="0" alt="Windows Phone デベロッパー センター" width="180" height="70" style="margin-top:3px"></a></td>
<td>
<ul>
<li>もっと他のコンテンツを見る &gt;&gt; <a href="http://msdn.microsoft.com/ja-jp/ff363212" target="_blank">
逆引きサンプル コード一覧へ</a> </li><li>もっと他のレシピを見る &gt;&gt; <a href="http://code.msdn.microsoft.com/ja-jp">Code Recipe へ</a>
</li><li>もっと&nbsp;Windows Phone の情報を見る &gt;&gt; <a href="http://msdn.microsoft.com/ja-jp/windowsphone" target="_blank">
Windows Phone デベロッパー センターへ</a> </li></ul>
</td>
</tr>
</tbody>
</table>
<p style="margin-top:20px"><a href="#top"><img src="-top.gif" border="0" alt="">ページのトップへ</a></p>
