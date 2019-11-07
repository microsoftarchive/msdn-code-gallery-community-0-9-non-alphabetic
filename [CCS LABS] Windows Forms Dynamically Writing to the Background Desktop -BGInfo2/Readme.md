# [CCS LABS] Windows Forms: Dynamically Writing to the Background Desktop -BGInfo2
## Requires
- Visual Studio 2010
## License
- MS-LPL
## Technologies
- C#
- Win32
- Windows Forms
- VB.Net
## Topics
- C#
- Windows Forms
- VB.Net
- desktop
- Dynamic Update
- Dynamic-Link Libraries (DLL)
- Win32 Interop
## Updated
- 12/30/2012
## Description

<h1>Introduction</h1>
<p>Sysinternals provide a great utility called BGInfo. This utility writes information about your computer system on the Desktop. The problem is that the information is not dynamically updated - so quickly the information becomes outdated. This example shows
 how to created a dynamically created BGInfo application.</p>
<h1><span>Building the Sample</span></h1>
<p><em>The sample is written using the .Net framework version 4, on a Windows Server x64 machine using Visual Studio 2010. It will work on any appropriately configured computer running Windows XP and better.<br>
</em></p>
<p><span style="font-size:20px; font-weight:bold">Description</span></p>
<p><img id="73864" src="73864-screenhunter_01%20dec.%2030%2016.47.gif" alt="" width="857" height="481"></p>
<p>The above image shows BGInfo by SysInternals. The application we will be producing writes yellow dynamically updating information to the screen. In the sample we only show two peices of information the logged on user's name and how long the computer has
 been running since it was switched on.</p>
<p>We have used a little employed cheat to produce the sample. Which is using a full screen window which is fully transparent - this allows you to see the background icons etc and click through the transparent window to the icons below.</p>
<p>The only real task we have is to set the transparent window to the furthest back that we can. This we do with the following code:</p>
<p>&nbsp;</p>
<p>&nbsp;</p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>C#</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">csharp</span>
<pre class="hidden">&lt;DllImport(&quot;user32.dll&quot;)&gt; _
	Private Shared Function SetWindowPos(hWnd As IntPtr, hWndInsertAfter As IntPtr, X As Integer, Y As Integer, cx As Integer, cy As Integer, _
		uFlags As UInteger) As Boolean
	End Function

	Shared ReadOnly HWND_BOTTOM As New IntPtr(1)
	Const SWP_NOSIZE As UInt32 = &amp;H1
	Const SWP_NOMOVE As UInt32 = &amp;H2
	Const SWP_NOACTIVATE As UInt32 = &amp;H10</pre>
<div class="preview">
<pre class="csharp">&lt;DllImport(<span class="cs__string">&quot;user32.dll&quot;</span>)&gt;&nbsp;_&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;Private&nbsp;Shared&nbsp;Function&nbsp;SetWindowPos(hWnd&nbsp;As&nbsp;IntPtr,&nbsp;hWndInsertAfter&nbsp;As&nbsp;IntPtr,&nbsp;X&nbsp;As&nbsp;Integer,&nbsp;Y&nbsp;As&nbsp;Integer,&nbsp;cx&nbsp;As&nbsp;Integer,&nbsp;cy&nbsp;As&nbsp;Integer,&nbsp;_&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;uFlags&nbsp;As&nbsp;UInteger)&nbsp;As&nbsp;Boolean&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;End&nbsp;Function&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;Shared&nbsp;ReadOnly&nbsp;HWND_BOTTOM&nbsp;As&nbsp;New&nbsp;IntPtr(<span class="cs__number">1</span>)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;Const&nbsp;SWP_NOSIZE&nbsp;As&nbsp;UInt32&nbsp;=&nbsp;&amp;H1&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;Const&nbsp;SWP_NOMOVE&nbsp;As&nbsp;UInt32&nbsp;=&nbsp;&amp;H2&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;Const&nbsp;SWP_NOACTIVATE&nbsp;As&nbsp;UInt32&nbsp;=&nbsp;&amp;H10</pre>
</div>
</div>
</div>
<div class="endscriptcode">&nbsp;</div>
<p>&nbsp;</p>
<p>To set the window to the BottomMost we simply call this command</p>
<p>&nbsp;</p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>C#</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">csharp</span>
<pre class="hidden">	SetWindowPos(Handle, HWND_BOTTOM, 0, 0, 0, 0, _
			SWP_NOMOVE Or SWP_NOSIZE Or SWP_NOACTIVATE)
		' Set Form1 as BottomMost</pre>
<div class="preview">
<pre class="csharp">&nbsp;&nbsp;&nbsp;&nbsp;SetWindowPos(Handle,&nbsp;HWND_BOTTOM,&nbsp;<span class="cs__number">0</span>,&nbsp;<span class="cs__number">0</span>,&nbsp;<span class="cs__number">0</span>,&nbsp;<span class="cs__number">0</span>,&nbsp;_&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;SWP_NOMOVE&nbsp;Or&nbsp;SWP_NOSIZE&nbsp;Or&nbsp;SWP_NOACTIVATE)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;'&nbsp;Set&nbsp;Form1&nbsp;<span class="cs__keyword">as</span>&nbsp;BottomMost</pre>
</div>
</div>
</div>
<div class="endscriptcode">&nbsp;</div>
<h1>More Information</h1>
<p><em>The original C# code was converted to VB using SharpDevelop's convert facility.<br>
</em></p>
