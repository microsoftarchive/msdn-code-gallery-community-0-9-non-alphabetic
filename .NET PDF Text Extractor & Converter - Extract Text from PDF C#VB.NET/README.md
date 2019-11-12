# .NET PDF Text Extractor & Converter - Extract Text from PDF C#/VB.NET
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
- .NET Framework
- Visual Basic .NET
- Console
- Library
- WinForms
- Visual C#
- Visual Studio 2012
- Visual Studio 2013
- .NET Development
- Visual Studio 2015
- Visual Studio 2017
## Topics
- PDF
- Extract text from PDF
- PDF API
- C# PDF
- PDF Convert
- .NET PDF library
## Updated
- 03/06/2019
## Description

<h1 style="text-align:justify"><strong>How to Extract Text from PDF in C# &amp; VB.NET</strong><strong>&nbsp;</strong></h1>
<p class="p" style="text-align:justify">How to extract text from PDF file and how to convert PDF to txt file in C# &amp; VB.NET windows and ASP.NET web projects.</p>
<p class="p" style="text-align:justify">&nbsp;</p>
<h2 class="p" style="text-align:justify"><strong>Development Environment</strong><strong>&nbsp;</strong></h2>
<p class="p" style="text-align:justify">CnetSDK .NET PDF Text Extractor &amp;&nbsp;Converter SDK can be easily integrated into .NET applications development that is development in the environment of&nbsp;x86 &amp; x64 systems, Windows XP &amp; above, .NET
 Framework 2.0&nbsp;&amp; above, and Visual Studio 2005&nbsp;&amp; above.&nbsp;<strong><a title="CnetSDK .NET PDF Text Converter SDK" href="http://www.cnetsdk.com/net-pdf-to-text-converter-sdk" target="_blank">This robust PDF text extractor and converter library</a></strong>&nbsp;is
 available for C# &amp; VB.NET Class Library, .NET Windows Forms, ASP.NET web, Console application, etc.</p>
<p class="p" style="text-align:justify"><br>
<strong>Please Note</strong>: The free demo&nbsp;project&nbsp;provided here is for .NET Framework 4.0, x86&nbsp;and x64. Certainly, CnetSDK full free trial package contains all dll libraries for .NET Framework 2.0&nbsp;and above versions, x86 and x64. You may&nbsp;<a title="Download the Free Trial to Test" href="https://storage.googleapis.com/wzukusers/user-29892693/documents/5c59542aa19c10aUwWwi/CnetSDK.PDFtoText.Converter.Trial.zip" target="_blank">download&nbsp;CnetSDK
 .NET PDF to Text Converter&nbsp;free trial&nbsp;here</a>&nbsp;and text more.</p>
<p class="p" style="text-align:justify">&nbsp;</p>
<h2 class="p" style="text-align:justify"><strong>Main Features Supported</strong></h2>
<p class="p" style="text-align:justify">If you are searching for a .NET library/control/component for PDF text extraction or PDF to text conversion, you can directly have a try with CnetSDK .NET PDF text extractor and PDF converter SDK. It enables C# and
 VB programmers to easily extract text from PDF file and convert PDF to text file (.txt) using C# &amp; VB.NET programming languages. This .NET PDF processing library is applied independently. No other .NET assemblies or software are needed for your .NET windows
 or web applications development. Main features are listed below.</p>
<ul>
<li>Easy to integrate into Visual Studio .NET/C#/VB projects </li><li>Get&nbsp;or extract&nbsp;text from PDF file&nbsp;single page, several pages, and all pages
</li><li>Transform and convert PDF document to text file in .txt format </li><li>Support multiple languages like English, Spanish, German, etc </li></ul>
<p>&nbsp;</p>
<h2 class="p" style="text-align:justify"><strong>Convert PDF to Text &amp; Extract Text from PDF C#</strong><strong>&nbsp;</strong></h2>
<p style="text-align:justify">The&nbsp;following two pieces of C# sample codes&nbsp;illustrates how to extract text from PDF file and how to convert PDF to text file (.txt).</p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>C#</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">编辑脚本</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">csharp</span>

<div class="preview">
<pre class="csharp"><span class="cs__keyword">namespace</span>&nbsp;ExtractTextfromPDF&nbsp;
{&nbsp;
&nbsp;&nbsp;<span class="cs__keyword">class</span>&nbsp;Program&nbsp;
&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">static</span>&nbsp;<span class="cs__keyword">void</span>&nbsp;Main(<span class="cs__keyword">string</span>[]&nbsp;args)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__com">//&nbsp;Create&nbsp;an&nbsp;instance&nbsp;of&nbsp;PDF&nbsp;text&nbsp;extractor&nbsp;object.</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;CSPdfExtractor&nbsp;PDFTextExtractor&nbsp;=&nbsp;<span class="cs__keyword">new</span>&nbsp;CSPdfExtractor();&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__com">//&nbsp;Load&nbsp;a&nbsp;PDF&nbsp;from&nbsp;a&nbsp;local&nbsp;file.</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;PDFTextExtractor.LoadPdfFile(<span class="cs__string">&quot;F:/Test.pdf&quot;</span>);&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__com">//&nbsp;Get&nbsp;the&nbsp;total&nbsp;page&nbsp;count&nbsp;of&nbsp;the&nbsp;PDF&nbsp;file.</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">int</span>&nbsp;Count&nbsp;=&nbsp;PDFTextExtractor.FilePageCount;&nbsp;
&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">for</span>&nbsp;(<span class="cs__keyword">int</span>&nbsp;i&nbsp;=&nbsp;<span class="cs__number">0</span>;&nbsp;i&nbsp;&lt;&nbsp;Count;&nbsp;i&#43;&#43;)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__com">//&nbsp;Extract&nbsp;text&nbsp;from&nbsp;each&nbsp;PDF&nbsp;page.</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">string</span>&nbsp;PdfPageText&nbsp;=&nbsp;PDFTextExtractor.ConvertToText(i);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Console.WriteLine(PdfPageText);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Console.ReadKey();&nbsp;
&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__com">//&nbsp;Extract&nbsp;text&nbsp;from&nbsp;whole&nbsp;PDF&nbsp;file.</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__com">//&nbsp;string&nbsp;AllText&nbsp;=&nbsp;PDFTextExtractor.ConvertToText();</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__com">//&nbsp;Console.WriteLine(AllText);</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
&nbsp;&nbsp;}&nbsp;
}&nbsp;
&nbsp;
&nbsp;
&nbsp;
<span class="cs__keyword">namespace</span>&nbsp;ConvertPDFtoText&nbsp;
{&nbsp;
&nbsp;&nbsp;<span class="cs__keyword">class</span>&nbsp;Program&nbsp;
&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">static</span>&nbsp;<span class="cs__keyword">void</span>&nbsp;Main(<span class="cs__keyword">string</span>[]&nbsp;args)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__com">//&nbsp;Create&nbsp;an&nbsp;instance&nbsp;of&nbsp;PDF&nbsp;to&nbsp;text&nbsp;converter&nbsp;object.</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;CSPdfExtractor&nbsp;ConvertPDFtoText&nbsp;=&nbsp;<span class="cs__keyword">new</span>&nbsp;CSPdfExtractor();&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__com">//&nbsp;Load&nbsp;a&nbsp;PDF&nbsp;from&nbsp;a&nbsp;local&nbsp;file.</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;ConvertPDFtoText.LoadPdfFile(<span class="cs__string">&quot;F:/Test.pdf&quot;</span>);&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__com">//&nbsp;Convert&nbsp;PDF&nbsp;to&nbsp;txt&nbsp;file.</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;ConvertPDFtoText.ConvertToTextFile(<span class="cs__string">&quot;F:/Test.txt&quot;</span>);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
&nbsp;&nbsp;}&nbsp;
}</pre>
</div>
</div>
</div>
<h2 style="text-align:justify"><strong>More </strong><strong>Related</strong><strong>&nbsp;</strong></h2>
<p class="p" style="text-align:justify">Click to see more&nbsp;related articles about CnetSDK .NET PDF Text Extractor &amp; Converter SDK.</p>
<ul>
<li><strong><a title="Online Tutorial for .NET PDF Text SDK" href="http://www.cnetsdk.com/tutorial-for-net-pdf-to-text-conversion" target="_blank">Online Guide</a></strong><strong>&nbsp;</strong>
</li><li><strong><a title="C# PDF to Text Conversion & Extraction" href="http://www.cnetsdk.com/net-pdf-to-text-converter-csharp-sample-code" target="_blank">PDF Text Extraction C#</a></strong><strong>&nbsp;</strong>
</li><li><strong><a title="VB.NET PDF to Text Conversion & Extraction" href="http://www.cnetsdk.com/net-pdf-to-text-converter-vb-sample-code" target="_blank">PDF Text Extraction VB.NET</a></strong><strong>&nbsp;</strong>
</li><li><strong><a title="ASP.NET PDF to Text Conversion & Extraction" href="http://www.cnetsdk.com/aspnet-pdf-to-text-converter" target="_blank">ASP.NET PDF Text Extraction</a></strong><strong>&nbsp;</strong>
</li></ul>
<p>Support Email: <span style="text-decoration:underline"><a title="CnetSDK Support Team" href="mailto:support@cnetsdk.com">support@cnetsdk.com</a></span></p>
