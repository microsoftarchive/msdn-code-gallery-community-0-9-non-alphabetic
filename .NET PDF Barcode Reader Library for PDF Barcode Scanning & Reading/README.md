# .NET PDF Barcode Reader Library for PDF Barcode Scanning & Reading
## Requires
- Visual Studio 2013
## License
- Apache License, Version 2.0
## Technologies
- C#
- ASP.NET
- Visual Studio 2008
- .NET
- Class Library
- Windows Forms
- Visual Studio 2010
- Console Application
- .NET Framework
- Visual Basic .NET
- ASP.NET Web Forms
- VB.Net
- Visual Studio
- C# Language
- WinForms
- PDF
- Visual C#
- Visual C Sharp .NET
- Visual Studio 2012
- Visual Studio 2013
- .NET Development
- Visual Studio 2015
- Barcode
- Barcode Recognition
- Barcode Reading
- Visual Studio 2017
## Topics
- How to
- PDF
- PDF file
- .NET PDF
- C# PDF
- Read Barcode
- Scan Barcode
- Pdf Library
- Barcode
- Barcode Recognition
- Barcode scanner
- .NET PDF library
## Updated
- 03/06/2019
## Description

<h1>Use .NET Barcode Reader Library to Read Barcode from PDF File in&nbsp;C#&nbsp;&amp; VB.NET</h1>
<p>CnetSDK .NET PDF Barcode Reader SDK library provides&nbsp;advanced APIs&nbsp;for scanning and reading barcodes from PDF file&nbsp;in C# &amp; VB.NET windows and web projects.&nbsp;It supports most popular 2d and 1d barcode symbologies.</p>
<p>&nbsp;</p>
<h2 class="p"><span style="color:#333333"><strong>CnetSDK .NET </strong><strong>PDF
</strong><strong>Barcode </strong><strong>Reader</strong><strong>&nbsp;Library </strong>
<strong>Overview</strong></span></h2>
<p class="p">CnetSDK .NET PDF Barcode Reader SDK is quite easy to be used for your C# and VB.NET windows desktop and web applications development. It is an independent barcode reader library for .NET projects programming, which supports scanning and reading
 most popular 1d and 2d barcodes from PDF file pages. It provides flexible .NET barcode reader/scanner APIs for you to choose from. And you can easily scan &amp; read single and multiple types of barcodes from one or more pages of PDF document.</p>
<p class="p">&nbsp;</p>
<ul>
<li>Read and Decode Most Popular 2D Barcodes&nbsp;from PDF File: include QR Code, Data Matrix, PDF417
</li><li>Read and Decode Most Popular&nbsp;1D Barcodes&nbsp;from PDF File: include&nbsp;Code 128, Code 39, EAN-13, EAN-8,&nbsp;UPC-A,&nbsp;UPC-E, Interleaved 2 of 5
</li><li>Support Reading One&nbsp;Barcode&nbsp;Type&nbsp;from&nbsp;One&nbsp;PDF Page </li><li>Support Reading Multiple Barcode&nbsp;Types from&nbsp;One&nbsp;PDF Page </li><li>Support Reading One&nbsp;Barcode&nbsp;Type&nbsp;from&nbsp;Multiple PDF Pages </li><li>Support Reading Multiple Barcode&nbsp;Types from&nbsp;Multiple PDF Pages </li></ul>
<p>&nbsp;</p>
<h2><span style="color:#333333"><strong>Development</strong><strong>&nbsp;</strong><strong>Requirement</strong></span></h2>
<p>This&nbsp;.NET PDF Barcode Reader SDK library is fully&nbsp;compatible with Visual Studio .NET applications development.&nbsp;&nbsp;Please make sure that your development environment is&nbsp;Microsoft Windows System, 32-bit or 64-bit system, Visual Studio
 2005&#43;, and .NET Framework 2.0&#43;.</p>
<p>It is quite easy to integrate this scanner library into your VS projects, simply adding&nbsp;CnetSDK.PDFBarcode.Reader.Trial.dll to your Visual Studio .NET project reference. Moreover, you should copy CnetSDK.Support.dll from x86 or x64 folder under bin
 folder of the download package to the bin directory, bin\Debug.</p>
<p>Now, you may have a try with the following&nbsp;C#&nbsp;sample code to scan and read barcode&nbsp;from PDF.&nbsp;Code 128 is taken as an example barcode type. You may get more examples for all barcode types in the downloaded package.</p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>C#</span><span>Visual Basic</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">编辑脚本</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">csharp</span><span class="hidden">vb</span>


<div class="preview">
<pre class="csharp"><span class="cs__keyword">using</span>&nbsp;System;&nbsp;
<span class="cs__keyword">using</span>&nbsp;<a class="libraryLink" href="https://msdn.microsoft.com/en-US/library/System.IO.aspx" target="_blank" title="Auto generated link to System.IO">System.IO</a>;&nbsp;
<span class="cs__keyword">using</span>&nbsp;<a class="libraryLink" href="https://msdn.microsoft.com/en-US/library/System.Collections.Generic.aspx" target="_blank" title="Auto generated link to System.Collections.Generic">System.Collections.Generic</a>;&nbsp;
<span class="cs__keyword">using</span>&nbsp;<a class="libraryLink" href="https://msdn.microsoft.com/en-US/library/System.Linq.aspx" target="_blank" title="Auto generated link to System.Linq">System.Linq</a>;&nbsp;
<span class="cs__keyword">using</span>&nbsp;<a class="libraryLink" href="https://msdn.microsoft.com/en-US/library/System.Text.aspx" target="_blank" title="Auto generated link to System.Text">System.Text</a>;&nbsp;
<span class="cs__keyword">using</span>&nbsp;<a class="libraryLink" href="https://msdn.microsoft.com/en-US/library/System.Drawing.aspx" target="_blank" title="Auto generated link to System.Drawing">System.Drawing</a>;&nbsp;
<span class="cs__keyword">using</span>&nbsp;<a class="libraryLink" href="https://msdn.microsoft.com/en-US/library/System.Drawing.Imaging.aspx" target="_blank" title="Auto generated link to System.Drawing.Imaging">System.Drawing.Imaging</a>;&nbsp;
<span class="cs__keyword">using</span>&nbsp;CnetSDK.PDFBarcode.Reader.Trial;&nbsp;
<span class="cs__keyword">using</span>&nbsp;CnetSDK.PDFBarcode.Reader.Trial.Pdf;&nbsp;
&nbsp;&nbsp;
<span class="cs__keyword">namespace</span>&nbsp;CnetSDKPDFBarcodeReader&nbsp;
{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">class</span>&nbsp;Program&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">static</span>&nbsp;<span class="cs__keyword">void</span>&nbsp;Main(<span class="cs__keyword">string</span>[]&nbsp;args)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;ReadOneBarcodeTypeFromOnePdfPage();&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">public</span>&nbsp;<span class="cs__keyword">static</span>&nbsp;<span class="cs__keyword">void</span>&nbsp;ReadOneBarcodeTypeFromOnePdfPage()&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;PdfFile&nbsp;pdf&nbsp;=&nbsp;<span class="cs__keyword">new</span>&nbsp;PdfFile(<span class="cs__string">&quot;test.pdf&quot;</span>);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;pdf.SetDPI&nbsp;=&nbsp;<span class="cs__number">72</span>;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Image&nbsp;pageImage&nbsp;=&nbsp;pdf.ConvertToImage(<span class="cs__number">0</span>,&nbsp;<span class="cs__number">1000</span>,&nbsp;<span class="cs__number">1000</span>);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Bitmap&nbsp;bitmap&nbsp;=&nbsp;<span class="cs__keyword">new</span>&nbsp;Bitmap(pageImage);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">string</span>[]&nbsp;data&nbsp;=&nbsp;PdfBarcodeReader.Recognize(bitmap,&nbsp;PdfBarcodeReader.Code128);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">foreach</span>&nbsp;(<span class="cs__keyword">string</span>&nbsp;result&nbsp;<span class="cs__keyword">in</span>&nbsp;data)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Console.WriteLine(result);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Console.ReadKey();&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
}</pre>
</div>
</div>
</div>
<h2><span style="color:#333333"><strong>See More on CnetSDK.com</strong></span><strong>&nbsp;</strong></h2>
<p class="p">You may get more details about CnetSDK .NET PDF Barcode Reader SDK and how to use this mature&nbsp;.NET&nbsp;PDF&nbsp;barcode reader/scanner library in your Visual Studio C# and VB.NET windows and web projects.</p>
<ul>
<li><a title="CnetSDK .NET PDF Barcode Reader SDK" href="https://www.cnetsdk.com/net-pdf-barcode-reader-sdk" target="_blank">CnetSDK .NET PDF Barcode Reader SDK&nbsp;Introduction</a>&nbsp;(You can also download&nbsp;the free trial package on this page.)
</li><li><a title="Online Guide" href="https://www.cnetsdk.com/tutorial-for-net-pdf-barcode-reading" target="_blank">How to Use CnetSDK .NET PDF Barcode Reader Library</a>
</li></ul>
<p>Support Email: <a title="CnetSDK Support Team" href="mailto:support@cnetsdk.com">
<span style="text-decoration:underline">support@cnetsdk.com</span></a>.</p>
