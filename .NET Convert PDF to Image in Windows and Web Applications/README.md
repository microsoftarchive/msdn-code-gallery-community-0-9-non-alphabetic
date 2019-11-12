# .NET Convert PDF to Image in Windows and Web Applications
## Requires
- Visual Studio 2013
## License
- Apache License, Version 2.0
## Technologies
- C#
- ASP.NET
- Visual Studio 2008
- Class Library
- Windows Forms
- Visual Studio 2010
- Windows 7
- Windows SDK
- .NET Framework
- Visual Basic.NET
- VB.Net
- WinForms
- Windows 8
- Visual C#
- Visual Studio 2012
- Visual Studio 2013
- Windows XP
- Windows Server
- .NET Development
- Visual Studio 2015
- Windows10
- Visual Studio 2017
## Topics
- How to
- C# PDF
- PDF Convert
- Convert PDF to Image
- PDF to Jpeg
- PDF to Tiff
- PDF to Png
- PDF to Gif
- PDF to Bmp
- PDF to jpg
- PDF to multi-page tiff
- Convert PDF page to Jpeg
- Convert PDF page to Tiff
- .NET PDF library
## Updated
- 03/06/2019
## Description

<h1><span style="color:#000000"><strong>How to </strong><strong>Convert PDF to Image
</strong><strong>in .NET Projects</strong><strong>&nbsp;</strong></span></h1>
<p style="text-align:justify">CnetSDK .NET PDF to Image Converter SDK helps to integrates high-quality VB.NET, C# PDF to image converting features into your Visual Studio .NET Windows and web applications development. You will know
<strong><a title="CnetSDK .NET Guide: How to Convert PDF to Images" href="http://www.cnetsdk.com/tutorial-for-net-pdf-to-image-conversion" target="_blank">how to convert PDF to images in .NET, C#, VB.NET programming projects</a></strong>. Details are as below.</p>
<ul>
<li><a title="CnetSDK .NET Guide: Convert PDF to JPG/JPEG" href="http://www.cnetsdk.com/net-pdf-to-image-converter-convert-pdf-to-jpeg" target="_blank"><strong>How to convert PDF to JPG/JPEG</strong><strong>&nbsp;</strong><strong>image .NET</strong></a><strong>&nbsp;</strong>
</li><li>How to <strong>convert PDF to PNG</strong>&nbsp;image .NET </li><li>How to <strong>convert PDF to BMP</strong>&nbsp;image .NET </li><li>How to <strong>convert PDF to BMP</strong>&nbsp;image .NET </li><li>How to <strong>convert PDF to T</strong><strong>IFF</strong>&nbsp;image/file .NET (with single or multiple pages)
</li></ul>
<p class="p" style="text-align:justify">&nbsp;</p>
<h2><strong>Basic </strong><strong>Requirement</strong><strong>&nbsp;</strong></h2>
<p class="p" style="text-align:justify">The requirement for using CnetSDK .NET PDF to Image Converter SDK in .NET Windows desktop and web applications is quite simple. It complies&nbsp;with .NET Framework 2.0&#43;, Visual Studio 2005&#43;, Windows XP&#43;, and x86 &amp;
 x64 systems.</p>
<p style="text-align:justify"><br>
<strong>Please Note</strong>: The demo provided here is for .NET Framework 4.5, x86&nbsp;and x64. You can
<strong><a title="Download CnetSDK .NET PDF to Image SDK Online" href="http://www.cnetsdk.com/net-pdf-to-image-converter-sdk" target="_blank">download the free full trial of .NET Convert PDF to Image SDK&nbsp;here</a></strong> or from any of the following links,
 which&nbsp;contains all dll libraries for .NET Framework 2.0&nbsp;and above versions, x86 and x64.</p>
<p style="text-align:justify">&nbsp;</p>
<h2><strong>C# Code Example</strong></h2>
<p style="text-align:justify">This piece of C# code illustrates how to convert PDF to image using CnetSDK .NET convert PDF to image APIs, keeping the original PDF document page size. You may also specify the size of the image, converted from PDF file.</p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>C#</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">编辑脚本</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">csharp</span>

<div class="preview">
<pre class="csharp"><span class="cs__keyword">public</span>&nbsp;<span class="cs__keyword">void</span>&nbsp;ConvertPDFtoImage(<span class="cs__keyword">string</span>&nbsp;filename)&nbsp;
&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;PdfFile&nbsp;PDFConverterSDK&nbsp;=&nbsp;<span class="cs__keyword">new</span>&nbsp;PdfFile();&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;PDFConverterSDK.LoadPdfFile(filename);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;PDFConverterSDK.SetDPI&nbsp;=&nbsp;<span class="cs__number">72</span>;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">int</span>&nbsp;Count&nbsp;=&nbsp;PDFConverterSDK.FilePageCount;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">for</span>&nbsp;(<span class="cs__keyword">int</span>&nbsp;i&nbsp;=&nbsp;<span class="cs__number">0</span>;&nbsp;i&nbsp;&lt;&nbsp;Count;&nbsp;i&#43;&#43;)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Bitmap&nbsp;bmp&nbsp;=&nbsp;PDFConverterSDK.ConvertToImage(i);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
&nbsp;&nbsp;&nbsp;}</pre>
</div>
</div>
</div>
<p>&nbsp;</p>
<h2><strong>Read </strong><strong>More</strong><strong>&nbsp;</strong></h2>
<ul>
<li><strong><a title="Online C# Guide for PDF to Image Converting" href="http://www.cnetsdk.com/net-pdf-to-image-converter-csharp-sample-code" target="_blank">C# Convert PDF to Image Tutorial on CnetSDK</a>
</strong></li><li><strong><a title="Online VB.NET Guide for PDF to Image Converting" href="http://www.cnetsdk.com/net-pdf-to-image-converter-vb-sample-code" target="_blank">VB.NET Convert PDF to Image Tutorial on CnetSDK</a></strong>
</li></ul>
<p>Support Email: <a title="Contact CnetSDK Support Team" href="mailto:support@cnetsdk.com">
<span style="text-decoration:underline">support@cnetsdk.com</span></a></p>
