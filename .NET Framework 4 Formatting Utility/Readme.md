# .NET Framework 4 Formatting Utility
## Requires
- Visual Studio 2010
## License
- Apache License, Version 2.0
## Technologies
- .NET Framework
- CLR
- .NET Framework 4.0
## Topics
- .NET Framework formatting
## Updated
- 03/10/2012
## Description

<h1>Introduction</h1>
<p><span style="font-size:small">The Format Utility (Formatter.exe) is a Windows Forms application that allows you to apply standard or custom format strings to either numeric values or date and time values and to&nbsp;determine how they affect the result string.</span></p>
<h1><span>Building the Sample</span></h1>
<p><span style="font-size:small">The example is packaged with an MSBuild project file that targets the .NET Framework Version 4. Download the sample code files to your computer. Open the solution (<strong>Formatter.sln</strong>) in Visual Studio 2010 and build
 the solution.</span></p>
<p><span style="font-size:20px; font-weight:bold">Description</span></p>
<p><span style="font-size:small">Formatting involves converting a value to its string representation. The overloaded
<strong>ToString</strong> method as well as the composite formatting feature supported by the
<strong>String.Format</strong> method, the <strong>StringBuilder.AppendFormat</strong> method, the
<strong>Console</strong> output methods, and the stream output methods give developers control over the string representations of numbers and dates. They allow such code as:</span>&nbsp;</p>
<pre><span style="font-size:small">Console.WriteLine(&quot;{0:YYYY-MM-dd}&quot;, thisDate);</span></pre>
<p><span style="font-size:small">or</span></p>
<pre><span style="font-size:small">Dim piString As String = Math.PI(&quot;r&quot;)</span></pre>
<p><span style="font-size:small">Frequently, though, developers forget what standard and custom format specifiers are available, and tehy forget how a particular format string is reflected in the result string. The Format Utility (Formatter.exe) allows you
 to enter a source value, indicate whether it is a number or a date and time value, and select a standard format string from a drop-down list or enter a custom format string in a text box. A text box then displays the result string, which is interpreted using
 the conventions of the current culture.</span></p>
<p><span style="font-size:small">A drop-down combo box allows you to either select one of the supported standard format strings, or you can enter your own standard or custom format string. Note that the standard numeric format strings do not include precision
 specifiers; if you want to include a precision specifier in a format string, you must enter it yourself.</span></p>
<p><span style="font-size:small">For an overview of formatting support in the .NET Framework, see
<a href="http://msdn.microsoft.com/en-us/library/26etazsy.aspx">Formatting Types</a>.</span></p>
<h1><span>Source Code Files</span></h1>
<p><span style="font-size:small">The Format Utility (Formatter.exe) is a Windows Forms application that consists of the following project files:</span></p>
<ul>
<li><span style="font-size:small"><strong>FormatUtility.sln</strong>, a Visual Studio solution file that serves as a container for its two individual language projects.</span>
</li><li><span style="font-size:small"><strong>FormatUtilityCS.csproj</strong>, a C# project file.</span>
</li><li><span style="font-size:small"><strong>FormatUtilityVB.vbproj</strong>, a Visual Basic project file.</span>
</li></ul>
<ul>
</ul>
<h1>More Information</h1>
<p><span style="font-size:small">For additional information about standard and custom format strings in the .NET Framework, see
<a href="http://go.microsoft.com/fwlink/?LinkId=209531" target="_blank">Standard Numeric Format Strings</a>,
<a href="http://go.microsoft.com/fwlink/?LinkId=209533" target="_blank">Custom Numeric Format Strings</a>,
<a href="http://go.microsoft.com/fwlink/?LinkId=209534" target="_blank">Standard Date and Time Format Strings</a>, and
<a href="http://go.microsoft.com/fwlink/?LinkId=209535" target="_blank">Custom Date and Time Format Strings</a>.</span></p>
