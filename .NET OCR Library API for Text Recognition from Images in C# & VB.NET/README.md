# .NET OCR Library API for Text Recognition from Images in C# & VB.NET
## Requires
- Visual Studio 2013
## License
- Apache License, Version 2.0
## Technologies
- Controls
- C#
- ASP.NET
- Visual Studio 2008
- Class Library
- Windows Forms
- Visual Studio 2010
- .NET Framework
- VB.Net
- Visual C#
- Visual Studio 2012
- Visual Studio 2013
- .NET Development
- Image Processing
- Visual Studio 2015
- Visual Studio 2017
## Topics
- Text Recognition
- Image Recognition
- Bing OCR Control
- OCR
- extract method
- Optical Character Recognition
## Updated
- 03/06/2019
## Description

<h1 style="text-align:justify">Recognize Text&nbsp;from Images&nbsp;in C#/VB.NET Using OCR&nbsp;API</h1>
<p class="p" style="text-align:justify">CnetSDK .NET OCR&nbsp;Library API for text&nbsp;recognition&nbsp;and extraction&nbsp;from JPG, JPEG, TIF, TIFF, PNG, BMP &amp; GIF in C# &amp; VB.NET applications.</p>
<p class="p" style="text-align:justify">&nbsp;</p>
<h2 class="p" style="text-align:justify"><strong>CnetSDK .NET </strong><strong>OCR</strong><strong>&nbsp;Library Introduction</strong></h2>
<p class="p" style="text-align:justify">CnetSDK .NET OCR library incorporates&nbsp;the robust optical character recognition technology to solve your .NET/C#/VB.NET OCR&nbsp;programming&nbsp;problems, which helps you develop high-performance text recognition
 and document processing applications. This advanced OCR scanner SDK is a standalone .NET library that recognizes and extracts text rapidly without using other third party tools or .NET assemblies. It can deal with image source that is obtained directly from
 your local disk, or captured from the digital camera, mobile phone, and Twain devices.</p>
<ul style="text-align:justify">
<li>More than 60 OCR languages are supported by our .NET OCR library </li><li>Support extracting text from raster images JPG/JPEG, TIF, TIFF, PNG, BMP &amp; GIF
</li><li>Provide zonal OCR scanning &amp; recognition APIs for special field recognition on an image
</li><li>Automatic image deskew improves the accuracy of OCR scanning and recognition </li></ul>
<p style="text-align:justify">Please firstly <a title="Download the Free Trial to Test" href="https://storage.googleapis.com/wzukusers/user-29892693/documents/5c59553ce381ca4qtisn/CnetSDK.OCR.Trial.zip" target="_blank">
download free OCR SDK trial here</a>. By simple adding project reference&nbsp;to our .NET OCR scanner library, you can use robust .NET OCR&nbsp;APIs&nbsp;for .NET, C# &amp; VB.NET applications development.
<a title="CnetSDK .NET OCR SDK Overview" href="http://www.cnetsdk.com/net-ocr-sdk" target="_blank">
<strong>This .NET </strong><strong>OCR scanner</strong><strong>&nbsp;library</strong></a>&nbsp;is compatible with Microsoft Windows System, 32 or 64 bit, Visual Studio 2005 or above, and .NET Framework 4.0 or above.</p>
<p style="text-align:justify">&nbsp;</p>
<h2 class="p" style="text-align:justify"><strong>C# OCR Scanning &amp; Recognition Example</strong><strong>&nbsp;</strong></h2>
<p style="text-align:justify">The following C# code example is provided for your test. The target language is English. To fully test this .NET OCR library, you may see the
<strong><a title="Online Tutorial for Text OCR" href="http://www.cnetsdk.com/for-net-ocr-application" target="_blank">full guide for using CnetSDK .NET OCR Library here</a></strong>.</p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>C#</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">编辑脚本</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">csharp</span>

<div class="preview">
<pre class="csharp"><span class="cs__com">//&nbsp;Create&nbsp;an&nbsp;OCR&nbsp;Engine&nbsp;instance.</span>&nbsp;
OcrEngine&nbsp;OCRLibrary&nbsp;=&nbsp;<span class="cs__keyword">new</span>&nbsp;OcrEngine();&nbsp;
&nbsp;
<span class="cs__com">//&nbsp;Set&nbsp;the&nbsp;absolute&nbsp;path&nbsp;of&nbsp;tessdata.</span>&nbsp;
OCRLibrary.TessDataPath&nbsp;=&nbsp;<span class="cs__string">&quot;F:/tessdata/&quot;</span>;&nbsp;
&nbsp;
<span class="cs__com">//&nbsp;Set&nbsp;the&nbsp;target&nbsp;text&nbsp;language.</span>&nbsp;
OCRLibrary.TextLanguage&nbsp;=&nbsp;<span class="cs__string">&quot;eng&quot;</span>;&nbsp;
&nbsp;
<span class="cs__com">//&nbsp;Recognize&nbsp;text&nbsp;from&nbsp;image&nbsp;file.</span>&nbsp;
<span class="cs__keyword">string</span>&nbsp;Imagetext&nbsp;=&nbsp;OCRLibrary.PerformOCR(<span class="cs__string">&quot;F:\CnetSDK.jpg&quot;</span>);&nbsp;
​&nbsp;
<a class="libraryLink" href="https://msdn.microsoft.com/en-US/library/System.Console.WriteLine.aspx" target="_blank" title="Auto generated link to System.Console.WriteLine">System.Console.WriteLine</a>(Imagetext)</pre>
</div>
</div>
</div>
<p><strong>Please note</strong>,&nbsp;<span style="text-align:justify">we provide .NET OCR solution for both x86 and x64 platforms. Please use suitable libraries. If you use x64 platform, please copy &quot;CnetSDKOCR_Lept.dll&quot; and &quot;CnetSDKOCR_Tesseract.dll&quot; from
 x64 folder to the same path of &quot;CnetSDK.OCR.Trial.dll&quot;. For x86 platform, do it in the same way.</span></p>
<p>&nbsp;</p>
<h2><strong>See More</strong><strong>&nbsp;</strong></h2>
<p class="p" style="text-align:justify">CnetSDK .NET OCR&nbsp;SDK also supports text extraction from multi-page TIFF file and zonal OCR scanning &amp; recognition&nbsp;in your C# and VB.NET windows and ASP.NET web projects.&nbsp;Please see more online tutorials
 below.</p>
<ul>
<li><strong><a title="How to: Text Extraction from Muti-page TIFF" href="http://www.cnetsdk.com/net-ocr-multi-page-tiff-image-ocr" target="_blank">Text extraction from multi-page TIFF image file using OCR library</a></strong>
</li><li><strong><a title="How to: Zonal OCR" href="http://www.cnetsdk.com/net-ocr-zonal-ocr-scanner-library" target="_blank">Apply zonal OCR technology for your .NET windows and web applications</a></strong>
</li><li><strong><a title="OCR Languages and Trained Data" href="http://www.cnetsdk.com/net-ocr-tesseract-ocr-languages-trained-data" target="_blank">Multiple OCR languages recognition and trained data download</a></strong>
</li></ul>
<p>Support Email: <a title="CnetSDK Support Team" href="mailto:support@cnetsdk.com">
<span style="text-decoration:underline">support@cnetsdk.com</span></a>.</p>
