# [CCS LABS] Windows Forms: Dynamically Writing to the Background Desktop - Part 2
## Requires
- Visual Studio 2010
## License
- MS-LPL
## Technologies
- COM
- Interop
- Controls
- C#
- File System
- Diagnostics
- Win32
- Windows Forms
- custom controls
- .NET Framework
- Visual Basic .NET
- Performance Counters
- VB.Net
- Windows General
- Network Monitor
- WinForms
- System.Windows.Forms.UserControl
## Topics
- Interop
- Controls
- C#
- File System
- Diagnostics
- Taskbar
- User Controls
- User Interface
- Windows Forms
- Architecture and Design
- Images
- Dynamic Controls
- Visual Basic .NET
- Performance
- VB.Net
- Full Screen
- Image
- COM Interop
- System Information
- UI Design
- File Systems
- Devices and sensors
- User Control
- Background tasks
## Updated
- 01/16/2013
## Description

<h1>Introduction</h1>
<p><em>In this, our second part of the sample we have added additional functionality to our Monitoring application which &quot;appears&quot; to write on the Windows' Desktop. We also needed to do some performance analysis to see where the application was taking the most
 time. And we added a new DiskDrive control.<br>
</em></p>
<h1><span>Building the Sample</span></h1>
<p><em>The sample is written using the .Net framework version 4, on a Windows Server x64 machine using Visual Studio 2010. It will work on any appropriately configured computer running Windows XP and better.</em></p>
<p><span style="font-size:20px; font-weight:bold">Description</span></p>
<p><img id="74746" src="74746-screenhunter_02%20jan.%2016%2016.05.gif" alt="" width="608" height="401"></p>
<p><em>The image above is not a static image but a Dynamic one - being updated every second - although as you will discover that is not quite accurate. You can also see the Disk Drive Control in action which shows the amount of free space, the amount of Read
 Activity the drive is conducting and the amount of Write activity the drive is conducting.</em></p>
<p><em>The Icon on the right of the control changes from Blue - No activity, to Green - primarily Read Activity, to Red - primarily Write activity. I created this because not all my drives are local to my machine and as such sometimes I wonder why a drive is
 appearing non-responsive - this will let you know if the drive is under heavy strain... is it time to update your RAID policy?</em></p>
<p><em><br>
</em></p>
<p><em><img id="74747" src="74747-screenhunter_03%20jan.%2016%2016.12.gif" alt="" width="628" height="624">&nbsp;</em></p>
<p>The above image shows the architecture of the main application and the HDControl.</p>
<p>&nbsp;</p>
<p>&nbsp;</p>
<h1>More Information</h1>
<p><em>The original C# code was converted to VB using SharpDevelop's convert facility.</em></p>
