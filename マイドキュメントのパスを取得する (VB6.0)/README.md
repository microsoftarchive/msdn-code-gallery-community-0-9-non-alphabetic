# マイドキュメントのパスを取得する (VB6.0)
## License
- Apache License, Version 2.0
## Technologies
- Windows 7
- Visual Basic 6.0
## Topics
- 逆引きサンプル コード
- Windows プログラミング
- Windows 7 へのアプリ移行
## Updated
- 02/14/2011
## Description

<p>執筆者: <a href="http://msdn.microsoft.com/ja-jp/gg585574#mizobata" target="_blank">
株式会社クリエ・イルミネート 溝端 二三雄</a></p>
<p>マイドキュメントのフォルダーへのパスは Windows のバージョンによって異なります。また、Active Directory のメンバー コンピュータの場合、ネットワーク共有になる場合もあります (移動ユーザー プロファイルを使用時)。このため、マイドキュメントのフォルダーにアクセスする際にパスをハードコード</p>
<p>するのは推奨されません。実行環境のマイドキュメントのフォルダーへのパスを取得する専用の API を使用するべきです。</p>
<h2><br>
今回紹介するコード</h2>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title">Visual Basic</div>
<div class="pluginEditHolderLink">スクリプトの編集</div>
<span class="hidden">vb</span>

<pre class="js">Option&nbsp;Explicit&nbsp;
Private&nbsp;Const&nbsp;S_OK&nbsp;=&nbsp;&amp;H0&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;'&nbsp;Success&nbsp;
Private&nbsp;Const&nbsp;S_FALSE&nbsp;=&nbsp;&amp;H1&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;'&nbsp;The&nbsp;Folder&nbsp;is&nbsp;valid,&nbsp;but&nbsp;does&nbsp;not&nbsp;exist&nbsp;
Private&nbsp;Const&nbsp;E_INVALIDARG&nbsp;=&nbsp;&amp;H80070057&nbsp;'&nbsp;Invalid&nbsp;CSIDL&nbsp;Value&nbsp;
Private&nbsp;Const&nbsp;CSIDL_PERSONAL&nbsp;=&nbsp;&amp;H5&nbsp;
Private&nbsp;Declare&nbsp;<span class="js__object">Function</span>&nbsp;SHGetFolderPath&nbsp;Lib&nbsp;<span class="js__string">&quot;shfolder&quot;</span>&nbsp;_&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;Alias&nbsp;<span class="js__string">&quot;SHGetFolderPathA&quot;</span>&nbsp;_&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;(ByVal&nbsp;hwndOwner&nbsp;As&nbsp;Long,&nbsp;ByVal&nbsp;nFolder&nbsp;As&nbsp;Long,&nbsp;_&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;ByVal&nbsp;hToken&nbsp;As&nbsp;Long,&nbsp;ByVal&nbsp;dwFlags&nbsp;As&nbsp;Long,&nbsp;_&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;ByVal&nbsp;pszPath&nbsp;As&nbsp;<span class="js__object">String</span>)&nbsp;As&nbsp;Long&nbsp;
&nbsp;
Private&nbsp;Sub&nbsp;MyDocumentButton_Click()&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;Dim&nbsp;sPath&nbsp;As&nbsp;StringDim&nbsp;RetVal&nbsp;As&nbsp;LongsPath&nbsp;=&nbsp;<span class="js__object">String</span>(<span class="js__num">260</span>,&nbsp;<span class="js__num">0</span>)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;RetVal&nbsp;=&nbsp;SHGetFolderPath(<span class="js__num">0</span>,&nbsp;CSIDL_PERSONAL,&nbsp;<span class="js__num">0</span>,&nbsp;<span class="js__num">0</span>,&nbsp;sPath)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;Select&nbsp;Case&nbsp;RetVal&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Case&nbsp;S_OK&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;sPath&nbsp;=&nbsp;Left(sPath,&nbsp;InStr(<span class="js__num">1</span>,&nbsp;sPath,&nbsp;Chr(<span class="js__num">0</span>))&nbsp;-&nbsp;<span class="js__num">1</span>)&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;MyDocumentLabel.Caption&nbsp;=&nbsp;sPath&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Case&nbsp;S_FALSE&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;MyDocumentLabel.Caption&nbsp;=&nbsp;<span class="js__string">&quot;フォルダが存在しません。&quot;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Case&nbsp;E_INVALIDARG&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;MyDocumentLabel.Caption&nbsp;=&nbsp;<span class="js__string">&quot;不正なIDが指定されました。&quot;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;End&nbsp;Select&nbsp;
End&nbsp;Sub&nbsp;
&nbsp;
</pre>
</div>
</div>
<div class="endscriptcode">&nbsp;</div>
<pre><br><br></pre>
<h2>Windows API を呼び出すための準備</h2>
<p>次の 1 行 (Declare 構文) で Windows API を使用するための宣言を行っています。具体的には shfolder.dll 内にある SHGetFolderPathA 関数を使用 (オプションである Alias を指定しているので、VB6.0 では GetVersionEx と言う関数名で使用) するための宣言となります。<br>
Private Declare Function SHGetFolderPath Lib &quot;shfolder&quot; _</p>
<p>&nbsp;</p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title">Visual Basic</div>
<div class="pluginEditHolderLink">スクリプトの編集</div>
<span class="hidden">vb</span>

<pre class="js">&nbsp;&nbsp;&nbsp;&nbsp;Alias&nbsp;<span class="js__string">&quot;SHGetFolderPathA&quot;</span>&nbsp;_&nbsp;&nbsp;&nbsp;&nbsp;(ByVal&nbsp;hwndOwner&nbsp;As&nbsp;Long,&nbsp;ByVal&nbsp;nFolder&nbsp;As&nbsp;Long,&nbsp;_&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;ByVal&nbsp;hToken&nbsp;As&nbsp;Long,&nbsp;ByVal&nbsp;dwFlags&nbsp;As&nbsp;Long,&nbsp;_&nbsp;&nbsp;&nbsp;&nbsp;ByVal&nbsp;pszPath&nbsp;As&nbsp;<span class="js__object">String</span>)&nbsp;As&nbsp;Long&nbsp;
&nbsp;
</pre>
</div>
</div>
<div class="endscriptcode">&nbsp;</div>
<p>&nbsp;</p>
<p>&nbsp;</p>
<h2>SHGetFolderPath 関数の呼び出し</h2>
<p>マイドキュメントのフォルダーのパスを取得するために使用する SHGetFolderPath 関数には 5 個の引数があります。pszPath にはこの関数によって取得されたパスが返ってきます。それ以外の引数は以下の値を設定します。</p>
<ul>
<li>hwndOwner<br>
予約済みです。0 を指定します。 </li><li>nFolder<br>
どのフォルダーのパスを取得するかを 16 進で指定します。マイドキュメントの場合 5 を指定します。今回のコードでは CSIDL_PERSONAL として前半で定義しています。
</li><li>hToken<br>
特定のユーザー権限で関数を実行する場合、そのユーザーのアクセストークンを指定します。実行者の権限の場合、0 を指定します。 </li><li>dwFlags<br>
0:この値を使用します。現在のパスが取得されます。<br>
1:既定のパスが取得されます。 </li></ul>
<h2>サンプルコードの実行</h2>
<p>正しくフォルダーへのパスが取得できた場合、ラベルに表示するようになっているので、実行すると以下のような結果となります。</p>
<p><img src="17355-mizo2.png" alt="" width="320" height="240"></p>
<h2>参考</h2>
<p>nFolder で指定する 16 進の値で代表的なものを以下に記載します。各定数が何を示しているかに関しては、<a href="http://msdn.microsoft.com/en-us/library/bb762494(v=VS.85).aspx" target="_blank">CSIDL (英語)
</a>&nbsp;をご参照ください。</p>
<ul>
<li>CSIDL_DESKTOP $0000 </li><li>CSIDL_PROGRAMS $0002 </li><li>CSIDL_CONTROLS $0003&nbsp; </li><li>CSIDL_PRINTERS $0004&nbsp; </li><li>CSIDL_PERSONAL $0005 </li><li>CSIDL_STARTUP $0007&nbsp; </li><li>CSIDL_MYMUSIC $000D </li><li>CSIDL_APPDATA $001A&nbsp; </li><li>CSIDL_WINDOWS $0024 </li><li>CSIDL_SYSTEM $0025 </li><li>CSIDL_PROGRAM_FILES $0026 </li><li>CSIDL_MYPICTURES $0027&nbsp; </li><li>CSIDL_PROGRAM_FILES_COMMON $002B </li></ul>
<h2><br>
関連リンク</h2>
<ul>
<li><a href="http://support.microsoft.com/kb/252652/ja" target="_blank">Visual Basic からには、SHGetFolderPath 関数を使用する方法</a>
</li><li><a href="http://msdn.microsoft.com/en-us/library/bb762181(v=VS.85).aspx" target="_blank">SHGetFolderPath Function (英語)</a>
</li></ul>
<p>&nbsp;</p>
<hr style="clear:both; margin-bottom:8px; margin-top:20px">
<table>
<tbody>
<tr>
<td valign="top"><a href="http://msdn.microsoft.com/ja-jp/samplecode.recipe" target="_blank"><img src="http://i.msdn.microsoft.com/ff950935.coderecipe_180x70%28ja-jp,MSDN.10%29.jpg" border="0" alt="Code Recipe" width="180" height="70" style="margin-top:3px"></a></td>
<td valign="top"><a href="http://msdn.microsoft.com/ja-jp/windows/" target="_blank"><img src="http://i.msdn.microsoft.com/ff950935.windows_180x70%28ja-jp,MSDN.10%29.jpg" border="0" alt="Windows デベロッパー センター" width="180" height="70" style="margin-top:3px"></a></td>
<td valign="top">
<ul>
<li>もっと他の Windows 7 対応を見る &gt;&gt;<a href="http://msdn.microsoft.com/ja-jp/windows/gg581817" target="_blank">Windows XP から Windows 7 アプリ移行 実践ガイド へ</a>
</li><li>もっと他のコンテンツを見る &gt;&gt; <a href="http://msdn.microsoft.com/ja-jp/ff363212" target="_blank">
逆引きサンプル コード一覧へ</a> </li><li>もっと他のレシピを見る &gt;&gt; <a href="http://msdn.microsoft.com/ja-jp/samplecode.recipe">
Code Recipe へ</a> </li><li>もっと Windows の情報を見る &gt;&gt; <a href="http://msdn.microsoft.com/ja-jp/windows/" target="_blank">
Windows デベロッパー センターへ</a> </li></ul>
</td>
</tr>
</tbody>
</table>
<p style="margin-top:20px"><a href="#top"><img src="http://www.microsoft.com/japan/msdn/nodehomes/graphics/top.gif" border="0" alt="">ページのトップへ</a></p>
