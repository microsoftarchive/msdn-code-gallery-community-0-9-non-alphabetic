# .NET Framework 4 Base64 Converter
## Requires
- Visual Studio 2010
## License
- Apache License, Version 2.0
## Technologies
- .NET Framework
- CLR
- .NET Framework 4.0
## Topics
- Base64 Encoding
- File Streams
## Updated
- 06/27/2012
## Description

<h1>Introduction</h1>
<p>The Base64 Converter (Base64Converter.exe) is a console-mode utility that converts a binary file's contents using Base64 encoding in a single operation or in a stream. The encoded string is written to a new file.</p>
<h1><span>Building the Sample</span></h1>
<p>The sample is packaged with an MSBuild project file that targets the .NET Framework Version 4. Download the sample code files to your computer. Open the solution (Base64Converter.sln) in Visual Studio 2010 and build the solution.</p>
<p><span style="font-size:20px; font-weight:bold">Description</span></p>
<p>Base64 encoding was&nbsp;originally developed to allow text-only medium to handle binary values. It remains an important means of&nbsp;representing Unicode characters and binary values as ASCII strings.</p>
<p><strong>Base64Converter.exe</strong> is a console-mode utility that performs base64 encoding and decoding. It illustrates how to encode or decode an entire file in a single operation by calling the
<strong><a class="libraryLink" href="http://msdn.microsoft.com/en-US/library/System.Convert.ToBase64String.aspx" target="_blank" title="Auto generated link to System.Convert.ToBase64String">System.Convert.ToBase64String</a></strong> method to perform the encoding and by calling the
<strong><a class="libraryLink" href="http://msdn.microsoft.com/en-US/library/System.Convert.FromBase64String.aspx" target="_blank" title="Auto generated link to System.Convert.FromBase64String">System.Convert.FromBase64String</a></strong> method to perform the decoding.</p>
<p><span style="color:#888888">In many cases, the number of bytes to be encoded is too large for a single operation. For those cases, the sample encodes or decodes a file stream by
</span>calling the methods of the <strong><a class="libraryLink" href="http://msdn.microsoft.com/en-US/library/System.Security.Cryptography.FromBase64Transform.aspx" target="_blank" title="Auto generated link to System.Security.Cryptography.FromBase64Transform">System.Security.Cryptography.FromBase64Transform</a></strong> and
<strong><a class="libraryLink" href="http://msdn.microsoft.com/en-US/library/System.Security.Cryptography.ToBase64Transform.aspx" target="_blank" title="Auto generated link to System.Security.Cryptography.ToBase64Transform">System.Security.Cryptography.ToBase64Transform</a></strong> classes.</p>
<h1><span>Source Code Files</span></h1>
<p>The Base64 Converter&nbsp;&nbsp;(Base64Converter.exe) is a Windows console mode application that consists of the following project files:</p>
<ul>
<li><strong>Base64Converter.sln</strong>, a Visual Studio solution file that servces as a container for its two individual language projects.
</li><li><strong>Base64ConverterCS.csproj</strong>, a C# project file. </li><li><strong>Base64ConvertVB.vbproj</strong>, a Visual Basic project file. </li></ul>
<h1>More Information</h1>
<p>For more information on encoding to and decoding from Base64, see the <a title="Convert.FromBase64CharArray Method" href="http://go.microsoft.com/fwlink/?LinkId=210681" target="_blank">
Convert.FromBase64CharArray Method</a>, the <a title="Convert.FromBase64String Method" href="http://go.microsoft.com/fwlink/?LinkId=210680" target="_blank">
Convert.FromBase64String Method</a>, the <a title="Convert.ToBase64CharArray Method" href="http://go.microsoft.com/fwlink/?LinkId=210682" target="_blank">
Convert.ToBase64CharArray Method</a>, the <a title="Convert.ToBase64String Method" href="http://go.microsoft.com/fwlink/?LinkId=210683" target="_blank">
Convert.ToBase64String Method</a>, the <a title="FromBase64Transform Class" href="http://go.microsoft.com/fwlink/?LinkId=210684" target="_blank">
FromBase64Transform Class</a>, and the <a title="ToBase64Transform Class" href="http://go.microsoft.com/fwlink/?LinkId=210685" target="_blank">
ToBase64Transform Class</a>.</p>
