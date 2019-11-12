# .NET Barcode Scanner Library API for .NET Barcode Reading and Recognition
## Requires
- Visual Studio 2010
## License
- Apache License, Version 2.0
## Technologies
- Controls
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
- VB.Net
- Visual Studio
- Visual C#
- Visual Studio 2012
- Visual Studio 2013
- .NET Development
- Visual Studio 2015
- Visual Studio 2017
## Topics
- How to
- QR codes
- Read Barcode
- Scan Barcode
- Code128-A
- Code39
- QR code scanning
- Barcode Recognition
- Barcode scanner
## Updated
- 03/06/2019
## Description

<h1>.NET Read Barcode from Image with Barcode Scanner API C#/VB.NET</h1>
<p>CnetSDK .NET Barcode Scanner Library API for .NET barcodes reading &amp; barcodes recognition in C# &amp; VBNET windows and web projects.</p>
<p>&nbsp;</p>
<h2><span style="color:#000080"><strong>CnetSDK .NET Barcode Scanner Library Introduction</strong></span></h2>
<p>CnetSDK barcode scanner library for C#, VB.NET, ASP.NET applications is an advanced and independent developer library that allows programmers to add highly accurate 1d and 2d barcodes reading and recognition capabilities to your Visual Studio .NET applications
 and ASP.NET websites. This .NET Barcode Reader SDK can scan, read, and recognize most popular 1d and 2d barcodes from images.</p>
<p>&nbsp;</p>
<ul>
<li>Read Popular Linear/1D Barcode: Read Code 39, Code 128, EAN-13, UPC-A, Codabar, Code 93, EAN-8, UPC-E, ITF-14
</li><li>Read Popular Matrix/2D Barcodes: <strong><a title="How to Recognize QR Code from Image" href="http://www.cnetsdk.com/net-barcode-scanner-sdk-read-qrcode-from-image" target="_blank">Read QR Code</a></strong>, PDF-417, Data Matrix, Aztec Code
</li><li>Support Barcode Recognition from Raster Image File Formats: Support JPG, JPEG, PNG, TIFF, BMP, GIF
</li></ul>
<p>&nbsp;</p>
<h2><span style="color:#000080"><strong>CnetSDK .NET Barcode Scanner Library Requirement</strong></span></h2>
<p>It is easy to integrate CnetSDK .NET Barcode Scanner Library to your <strong><a title="Read QR Code from Image in C# Programming" href="http://www.cnetsdk.com/net-barcode-scanner-csharp-sample-code" target="_blank">Visual C# barcode reading</a></strong>
 and <strong><a title="Read QR Code from Image in VB.NET Programming" href="http://www.cnetsdk.com/net-barcode-scanner-vb-sample-code">Visual Basic barcode reading projects</a></strong>. By simple adding project reference, you can use mature .NET barcode scanner
 APIs. This .NET barcode scanner library is compatible with Microsoft Windows System, 32 or 64 bit, Visual Studio 2005 or above, and .NET Framework 2.0 or above. &nbsp;</p>
<p>Now, you may have a try with the following sample code to scan and read QR Code from an image in C# .NET programming.</p>
<h1><em style="font-size:10px">&nbsp;</em></h1>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>C#</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">编辑脚本</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">csharp</span>

<div class="preview">
<pre class="csharp"><span class="cs__keyword">public</span>&nbsp;<span class="cs__keyword">void</span>&nbsp;ReadQRCodeBarcode(Bitmap&nbsp;bmp)&nbsp;
&nbsp;&nbsp;&nbsp;{&nbsp;
ScanResult[]&nbsp;results&nbsp;=&nbsp;CSBarcodeScanner.ScanBarcode(bmp,&nbsp;CSBarcodeType.QRCode);&nbsp;
<span class="cs__keyword">foreach</span>&nbsp;(ScanResult&nbsp;result&nbsp;<span class="cs__keyword">in</span>&nbsp;results)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Console.WriteLine(result.BarcodeType.ToString()&nbsp;&#43;&nbsp;<span class="cs__string">&quot;-&quot;</span>&nbsp;&#43;&nbsp;result.BarcodeData);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Console.ReadKey();&nbsp;
&nbsp;&nbsp;&nbsp;}</pre>
</div>
</div>
</div>
<p>CnetSDK .NET Barcode Scanner Library dll provides three methods to read 1d and 2d barcodes from images. The above C# sample code only illustrates how to define QR Code as the target barcode type to read and decode. You may also use other APIs to read the
 only one barcode or all barcodes from images.</p>
<p>&nbsp;</p>
<h2><span style="color:#000080">See More on CnetSDK.com</span></h2>
<p>Get more details about CnetSDK .NET Barcode Scanner SDK and how to use CnetSDK .NET barcode scanner library dll in your Visual Studio C# and VB.NET windows and web projects. You can also download the free trial package from the following pages.</p>
<ul>
<li><strong><a title="See CnetSDK .NET Barcode Scanner Library" href="http://www.cnetsdk.com/net-barcode-scanner-sdk" target="_blank">Product Overview: CnetSDK .NET Barcode Scanner SDK</a></strong>
</li><li><strong><a title="Developer Guide: CnetSDK .NET Barcode Scanner SDK" href="http://www.cnetsdk.com/tutorial-for-net-barcode-scanning" target="_blank">Online Tutorial: How to Use CnetSDK .NET Barcode Scanner SDK</a></strong>
</li></ul>
<p>Support Email: <a title="Send Email to CnetSDK Support Team" href="mailto:support@cnetsdk.com" target="_blank">
support@cnetsdk.com</a>.</p>
