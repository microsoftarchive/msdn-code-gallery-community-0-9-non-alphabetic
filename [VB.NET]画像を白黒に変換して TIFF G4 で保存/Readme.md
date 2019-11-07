# [VB.NET]画像を白黒に変換して TIFF G4 で保存
## Requires
- Visual Studio 2010
## License
- Apache License, Version 2.0
## Technologies
- GDI+
- Visual Studio 2010
## Topics
- 画像処理
## Updated
- 05/29/2011
## Description

<p>画像を白黒に変換して TIFF G4 形式で保存する方法を説明します。ピクセルデータを配列に取り出して処理します。</p>
<h1>白黒変換</h1>
<p>TIFF G4 は白黒画像の圧縮で標準的に使用される形式です。G4 のエンコーダには 1bpp の画像を渡す必要があります。1bpp の白黒画像を作成する方法として、RGBの平均を閾値として白と黒に分ける方法を説明します。</p>
<p>1bpp の画像を作成するのに Bitmap.SetPixel は使用できません。Bitmap.LockBits を使ってピクセルデータを渡す必要があります。元画像がフルカラーの場合は GetPixel が使用できますが、ピクセルデータで処理した方が高速なため、こちらも Bitmap.LockBits を使用します。</p>
<p>元画像 srcbmp のピクセルデータを Bitmap.LockBits で取り出し、Marshal.Copy で配列にコピーします。白黒用のデータを&#26684;納する配列を作成して、1ピクセルずつ処理して画像を変換します。視覚効果より処理速度を優先するため、白黒変換は単純に RGB の平均を取って閾値 threshold と比較しています。</p>
<p>ピクセルデータは行ごとに 32bit のアラインメントが必要です。元画像は 32bpp で取り出しているためアラインメントを考慮しなくても大丈夫ですが、白黒画像では考慮する必要があります。アラインメントを考慮したビット幅が w2a です。</p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>Visual Basic</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">スクリプトの編集</span>|<span class="pluginRemoveHolderLink">{#scriptcode_dlg.remove_script}</span></div>
<span class="hidden">vb</span>
<pre class="hidden">Public Function ConvertMonochrome(srcbmp As Bitmap, threshold%) As Bitmap
    Dim w = srcbmp.Width, h = srcbmp.Height, w2a = ((w &#43; 31) \ 32) * 32
    Dim bd1 = srcbmp.LockBits(New Rectangle(0, 0, w, h), ImageLockMode.ReadOnly, PixelFormat.Format32bppArgb)
    Dim src(w * h * 4 - 1) As Byte
    Marshal.Copy(bd1.Scan0, src, 0, src.Length)
    srcbmp.UnlockBits(bd1)

    Dim dst(((w2a * h) \ 8) - 1) As Byte
    Dim p1 = 0
    For y = 0 To h - 1
        Dim p2 = (w2a \ 8) * y
        Dim b = 128
        For x = 0 To w - 1
            Dim v = (CInt(src(p1)) &#43; CInt(src(p1 &#43; 1)) &#43; CInt(src(p1 &#43; 2))) \ 3
            If v &gt;= threshold Then dst(p2) &#43;= b
            p1 &#43;= 4
            b &gt;&gt;= 1
            If b = 0 Then
                b = 128
                p2 &#43;= 1
            End If
        Next
    Next

    Dim dstbmp = New Bitmap(w, h, PixelFormat.Format1bppIndexed)
    dstbmp.SetResolution(srcbmp.VerticalResolution, srcbmp.HorizontalResolution)
    Dim bd2 = dstbmp.LockBits(New Rectangle(0, 0, w, h), ImageLockMode.WriteOnly, PixelFormat.Format1bppIndexed)
    Marshal.Copy(dst, 0, bd2.Scan0, dst.Length)
    dstbmp.UnlockBits(bd2)
    Return dstbmp
End Function</pre>
<div class="preview">
<pre class="vb"><span class="visualBasic__keyword">Public</span>&nbsp;<span class="visualBasic__keyword">Function</span>&nbsp;ConvertMonochrome(srcbmp&nbsp;<span class="visualBasic__keyword">As</span>&nbsp;Bitmap,&nbsp;threshold%)&nbsp;<span class="visualBasic__keyword">As</span>&nbsp;Bitmap&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">Dim</span>&nbsp;w&nbsp;=&nbsp;srcbmp.Width,&nbsp;h&nbsp;=&nbsp;srcbmp.Height,&nbsp;w2a&nbsp;=&nbsp;((w&nbsp;&#43;&nbsp;<span class="visualBasic__number">31</span>)&nbsp;\&nbsp;<span class="visualBasic__number">32</span>)&nbsp;*&nbsp;<span class="visualBasic__number">32</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">Dim</span>&nbsp;bd1&nbsp;=&nbsp;srcbmp.LockBits(<span class="visualBasic__keyword">New</span>&nbsp;Rectangle(<span class="visualBasic__number">0</span>,&nbsp;<span class="visualBasic__number">0</span>,&nbsp;w,&nbsp;h),&nbsp;ImageLockMode.<span class="visualBasic__keyword">ReadOnly</span>,&nbsp;PixelFormat.Format32bppArgb)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">Dim</span>&nbsp;src(w&nbsp;*&nbsp;h&nbsp;*&nbsp;<span class="visualBasic__number">4</span>&nbsp;-&nbsp;<span class="visualBasic__number">1</span>)&nbsp;<span class="visualBasic__keyword">As</span>&nbsp;<span class="visualBasic__keyword">Byte</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;Marshal.Copy(bd1.Scan0,&nbsp;src,&nbsp;<span class="visualBasic__number">0</span>,&nbsp;src.Length)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;srcbmp.UnlockBits(bd1)&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">Dim</span>&nbsp;dst(((w2a&nbsp;*&nbsp;h)&nbsp;\&nbsp;<span class="visualBasic__number">8</span>)&nbsp;-&nbsp;<span class="visualBasic__number">1</span>)&nbsp;<span class="visualBasic__keyword">As</span>&nbsp;<span class="visualBasic__keyword">Byte</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">Dim</span>&nbsp;p1&nbsp;=&nbsp;<span class="visualBasic__number">0</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">For</span>&nbsp;y&nbsp;=&nbsp;<span class="visualBasic__number">0</span>&nbsp;<span class="visualBasic__keyword">To</span>&nbsp;h&nbsp;-&nbsp;<span class="visualBasic__number">1</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">Dim</span>&nbsp;p2&nbsp;=&nbsp;(w2a&nbsp;\&nbsp;<span class="visualBasic__number">8</span>)&nbsp;*&nbsp;y&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">Dim</span>&nbsp;b&nbsp;=&nbsp;<span class="visualBasic__number">128</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">For</span>&nbsp;x&nbsp;=&nbsp;<span class="visualBasic__number">0</span>&nbsp;<span class="visualBasic__keyword">To</span>&nbsp;w&nbsp;-&nbsp;<span class="visualBasic__number">1</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">Dim</span>&nbsp;v&nbsp;=&nbsp;(<span class="visualBasic__keyword">CInt</span>(src(p1))&nbsp;&#43;&nbsp;<span class="visualBasic__keyword">CInt</span>(src(p1&nbsp;&#43;&nbsp;<span class="visualBasic__number">1</span>))&nbsp;&#43;&nbsp;<span class="visualBasic__keyword">CInt</span>(src(p1&nbsp;&#43;&nbsp;<span class="visualBasic__number">2</span>)))&nbsp;\&nbsp;<span class="visualBasic__number">3</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">If</span>&nbsp;v&nbsp;&gt;=&nbsp;threshold&nbsp;<span class="visualBasic__keyword">Then</span>&nbsp;dst(p2)&nbsp;&#43;=&nbsp;b&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;p1&nbsp;&#43;=&nbsp;<span class="visualBasic__number">4</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;b&nbsp;&gt;&gt;=&nbsp;<span class="visualBasic__number">1</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">If</span>&nbsp;b&nbsp;=&nbsp;<span class="visualBasic__number">0</span>&nbsp;<span class="visualBasic__keyword">Then</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;b&nbsp;=&nbsp;<span class="visualBasic__number">128</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;p2&nbsp;&#43;=&nbsp;<span class="visualBasic__number">1</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">End</span>&nbsp;<span class="visualBasic__keyword">If</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">Next</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">Next</span>&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">Dim</span>&nbsp;dstbmp&nbsp;=&nbsp;<span class="visualBasic__keyword">New</span>&nbsp;Bitmap(w,&nbsp;h,&nbsp;PixelFormat.Format1bppIndexed)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;dstbmp.SetResolution(srcbmp.VerticalResolution,&nbsp;srcbmp.HorizontalResolution)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">Dim</span>&nbsp;bd2&nbsp;=&nbsp;dstbmp.LockBits(<span class="visualBasic__keyword">New</span>&nbsp;Rectangle(<span class="visualBasic__number">0</span>,&nbsp;<span class="visualBasic__number">0</span>,&nbsp;w,&nbsp;h),&nbsp;ImageLockMode.<span class="visualBasic__keyword">WriteOnly</span>,&nbsp;PixelFormat.Format1bppIndexed)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;Marshal.Copy(dst,&nbsp;<span class="visualBasic__number">0</span>,&nbsp;bd2.Scan0,&nbsp;dst.Length)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;dstbmp.UnlockBits(bd2)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">Return</span>&nbsp;dstbmp&nbsp;
<span class="visualBasic__keyword">End</span>&nbsp;<span class="visualBasic__keyword">Function</span></pre>
</div>
</div>
</div>
<h1>TIFF G4 で保存</h1>
<p>TIFF のエンコーダにパラメータとして G4 を渡して画像を保存します。保存する画像は 1bpp でなければ例外が発生するため、ConvertMonochrome で変換した白黒画像を使用しています。</p>
<p>以下の例ではクエリ式により TIFF エンコーダが必ず取得できることを前提に例外チェックを省略しています。</p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>Visual Basic</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">スクリプトの編集</span>|<span class="pluginRemoveHolderLink">{#scriptcode_dlg.remove_script}</span></div>
<span class="hidden">vb</span>
<pre class="hidden">Public Sub SaveAsG4(srcbmp As Bitmap, threshold%, f$)
    Using dstbmp = ConvertMonochrome(srcbmp, threshold)
        Dim tiff = (From enc In ImageCodecInfo.GetImageEncoders() Where enc.MimeType = &quot;image/tiff&quot; Select enc)(0)
        Dim g4 = New EncoderParameters(2)
        g4.Param(0) = New EncoderParameter(Encoder.ColorDepth, 1)
        g4.Param(1) = New EncoderParameter(Encoder.Compression, EncoderValue.CompressionCCITT4)
        dstbmp.Save(f, tiff, g4)
    End Using
End Sub</pre>
<div class="preview">
<pre class="vb"><span class="visualBasic__keyword">Public</span>&nbsp;<span class="visualBasic__keyword">Sub</span>&nbsp;SaveAsG4(srcbmp&nbsp;<span class="visualBasic__keyword">As</span>&nbsp;Bitmap,&nbsp;threshold%,&nbsp;f$)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">Using</span>&nbsp;dstbmp&nbsp;=&nbsp;ConvertMonochrome(srcbmp,&nbsp;threshold)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">Dim</span>&nbsp;tiff&nbsp;=&nbsp;(From&nbsp;enc&nbsp;<span class="visualBasic__keyword">In</span>&nbsp;ImageCodecInfo.GetImageEncoders()&nbsp;Where&nbsp;enc.MimeType&nbsp;=&nbsp;<span class="visualBasic__string">&quot;image/tiff&quot;</span>&nbsp;<span class="visualBasic__keyword">Select</span>&nbsp;enc)(<span class="visualBasic__number">0</span>)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">Dim</span>&nbsp;g4&nbsp;=&nbsp;<span class="visualBasic__keyword">New</span>&nbsp;EncoderParameters(<span class="visualBasic__number">2</span>)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;g4.Param(<span class="visualBasic__number">0</span>)&nbsp;=&nbsp;<span class="visualBasic__keyword">New</span>&nbsp;EncoderParameter(Encoder.ColorDepth,&nbsp;<span class="visualBasic__number">1</span>)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;g4.Param(<span class="visualBasic__number">1</span>)&nbsp;=&nbsp;<span class="visualBasic__keyword">New</span>&nbsp;EncoderParameter(Encoder.Compression,&nbsp;EncoderValue.CompressionCCITT4)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;dstbmp.Save(f,&nbsp;tiff,&nbsp;g4)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">End</span>&nbsp;<span class="visualBasic__keyword">Using</span>&nbsp;
<span class="visualBasic__keyword">End</span>&nbsp;<span class="visualBasic__keyword">Sub</span></pre>
</div>
</div>
</div>
<p class="endscriptcode">画像のファイル名を渡すと TIFF に変換して保存するコードを示します。閾値の 128 は 50% を基準に白と黒にわけることを意味します。濃くする場合は数値を上げます。</p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>Visual Basic</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">スクリプトの編集</span>|<span class="pluginRemoveHolderLink">{#scriptcode_dlg.remove_script}</span></div>
<span class="hidden">vb</span>
<pre class="hidden">Private Sub Convert(f$)
    Using srcimg = New Bitmap(f)
        SaveAsG4(srcimg, 128, Path.ChangeExtension(f, &quot;.tiff&quot;))
    End Using
End Sub</pre>
<div class="preview">
<pre class="vb"><span class="visualBasic__keyword">Private</span>&nbsp;<span class="visualBasic__keyword">Sub</span>&nbsp;Convert(f$)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">Using</span>&nbsp;srcimg&nbsp;=&nbsp;<span class="visualBasic__keyword">New</span>&nbsp;Bitmap(f)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;SaveAsG4(srcimg,&nbsp;<span class="visualBasic__number">128</span>,&nbsp;Path.ChangeExtension(f,&nbsp;<span class="visualBasic__string">&quot;.tiff&quot;</span>))&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">End</span>&nbsp;<span class="visualBasic__keyword">Using</span>&nbsp;
<span class="visualBasic__keyword">End</span>&nbsp;<span class="visualBasic__keyword">Sub</span></pre>
</div>
</div>
</div>
<h1 class="endscriptcode">サンプル</h1>
<p class="endscriptcode">サンプルではフォームにドラッグ＆ドロップすると output&nbsp;ディレクトリを作って TIFF G4 で保存するようになっています。複数のファイルを渡した場合はプログレスバーで進捗状況を確認できます。</p>
<h2 class="endscriptcode">制限事項</h2>
<ul>
<li>
<div class="endscriptcode">進捗表示がブロックされないように BackgroundWorker を使用していますが、中断処理は省略しています。</div>
</li><li>
<div class="endscriptcode">処理中に更にファイルを追加することはできません。</div>
</li><li>
<div class="endscriptcode">処理中にフォームを閉じるケースは想定していません。</div>
</li></ul>
