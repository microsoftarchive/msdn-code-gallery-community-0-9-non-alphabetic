# .NET Framework 4 Calendar Week Range Utility
## Requires
- Visual Studio 2010
## License
- Apache License, Version 2.0
## Technologies
- .NET Framework
- CLR
- .NET Framework 4.0
## Topics
- calendars
- Calendars in the .NET Framework
## Updated
- 06/27/2012
## Description

<h1>Introduction</h1>
<p>The way in which the weeks of the year are counted, and the way in which particular date ranges are assigned to particular weeks, depends on which day is considered the first day of the week and on how the rule that determines what the first week of the
 year is in a particular year.&nbsp; In addition, each <strong><span style="color:#888888">Calendar</span></strong> class supported by the .NET Framework supports a different range of dates. This often makes enumerating the weeks of the year in a particular
 calendar year confusing.</p>
<h1><span>Building the Sample</span></h1>
<p>The example is packaged with an MSBuild project file that targets the .NET Framework Version 4. Download the sample code files to your computer. Open the solution file (GetWeekRange.sln) in Visual Studio 2010 and build the solution.</p>
<p><span style="font-size:20px; font-weight:bold">Description</span></p>
<p>The sample is a Windows Forms application that, at its most simple level, wraps a call to the
<strong>GetWeekOfYear</strong> method of a designated calendar class to display the week ranges of a particular year. The sample allows you to select the calendar with which you'd like to work and to indicate the year for which you'd like to get date range
 information. In addition, for the two calendar classes (the <strong>JapaneseCalendar</strong> and
<strong>JapaneseLunisolarCalendar</strong> classes) in the .NET Framework that support multiple eras, you can indicate the era to which the designated year belongs. You can then indicate which day is considered the first day of the week and which calendar week
 rule you'd like to apply in determining week ranges.</p>
<p>The sample also illustrates how to work with the calendar classes in the <strong>
<a class="libraryLink" href="http://msdn.microsoft.com/en-US/library/System.Globalization.aspx" target="_blank" title="Auto generated link to System.Globalization">System.Globalization</a></strong> namespace in the .NET Framework. The .NET Framework allows you to work with calendar classes in two ways. You can work with dates in all calendars by calling relevant
<strong>Calendar</strong> class methods. In addition, all classes derived from the
<strong>Calendar</strong> class except the lunisolar calendar classes, the <strong>
PersianCalendar</strong> class, and the <strong>JulianCalendar</strong> can be the current calendar for a specifric culture. In this case, date and time operations work with that calendar automatically. You can change the current calendar of the sample by uncommenting
 relevent lines of code in the samples <strong>Form.Load</strong> event handler.</p>
<h1><span>Source Code Files</span></h1>
<p>The Calendar Week Range Utility (WeekRange.exe) is a Windows Forms application that consists of the following project files:</p>
<ul>
<li>WeekRange.sln, a Visual Studio solution file that serves as a container for its two individual language projects.
</li><li>FormatUtilityCS.csproj, a C# project file. </li><li>FormatUtilityVB.vbproj, a Visual Basic project file. </li></ul>
<h1>More Information</h1>
<p>For more information about working with calendars in the .NET Frmework, see <a title="Working with Calendars" href="http://go.microsoft.com/fwlink/?LinkId=204465" target="_blank">
Working with Calendars.</a> For information on calculating the week of the year for a particular date, see the documentation for the
<a title="Calendar.GetWeekOfYear" href="http://go.microsoft.com/fwlink/?LinkId=204466" target="_blank">
Calendar.GetWeekOfYear </a>method.</p>
