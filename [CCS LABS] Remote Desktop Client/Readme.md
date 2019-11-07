# [CCS LABS] Remote Desktop Client
## Requires
- Visual Studio 2010
## License
- Apache License, Version 2.0
## Technologies
- COM
- C#
- ActiveX
## Topics
- COM Client
- remote desktop
## Updated
- 01/13/2013
## Description

<h1>Introduction</h1>
<p><em>Ever wanted a better remote desktop client? With the features you really want, or perhaps a restricted version for your users which prevents them using it for purposes that you do not want them to do? Then this is how you do it - and it is simple!<br>
</em></p>
<h1><span>Building the Sample</span></h1>
<p><em>The sample was built using Windows Server 2012 x64, on Visual Studio 2010 - built as an x86 CPU based application. Under .Net 4. So it will work on any Windows based machine running Windows XP or better, with the correct .Net framework.<br>
</em></p>
<p><span style="font-size:20px; font-weight:bold">Description</span></p>
<p><img id="74601" src="74601-screenhunter_02%20jan.%2013%2010.57.gif" alt="" width="608" height="325"></p>
<p><em>In this sample we have created a very simple interface - yours of course will be much better with all the features you have ever wanted. As you can see there was a log in failure in the abive image - this is because the RDP Client requires the domain
 name of the computer you are connecting to - in the code supplied it is hard coded to &quot;ccslabs&quot; - you will need to change that to your requirements or add a new textbox to collect the correct domain name.</em></p>
<p><em>As you can see from the image below the system works.</em></p>
<p><img id="74602" src="74602-screenhunter_03%20jan.%2013%2022.35.gif" alt="" width="590" height="384"></p>
<p><em>This is the main code that is employed:</em></p>
<p><em></p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>C#</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">csharp</span>
<pre class="hidden">rdpClient.Domain = &quot;ccslabs&quot;;
rdpClient.Server = tbtServer.Text;
rdpClient.UserName = tbUsername.Text;

rdpClient.AdvancedSettings2.SmartSizing = true;
rdpClient.AdvancedSettings9.NegotiateSecurityLayer = true;

rdpClient.AdvancedSettings5.ClearTextPassword = tbPassword.Text;

rdpClient.Connect();</pre>
<div class="preview">
<pre class="csharp">rdpClient.Domain&nbsp;=&nbsp;<span class="cs__string">&quot;ccslabs&quot;</span>;&nbsp;
rdpClient.Server&nbsp;=&nbsp;tbtServer.Text;&nbsp;
rdpClient.UserName&nbsp;=&nbsp;tbUsername.Text;&nbsp;
&nbsp;
rdpClient.AdvancedSettings2.SmartSizing&nbsp;=&nbsp;<span class="cs__keyword">true</span>;&nbsp;
rdpClient.AdvancedSettings9.NegotiateSecurityLayer&nbsp;=&nbsp;<span class="cs__keyword">true</span>;&nbsp;
&nbsp;
rdpClient.AdvancedSettings5.ClearTextPassword&nbsp;=&nbsp;tbPassword.Text;&nbsp;
&nbsp;
rdpClient.Connect();</pre>
</div>
</div>
</div>
<div class="endscriptcode">All you need to do is add the COM assembly, Remote Desktop Client, to your toolbox and that will allow you to add it to you application - whether it is a Windows Form, ASP.NET web page, or Mobile application.</div>
<br>
</em>
<p></p>
<h1>More Information</h1>
<p><em>Remember to Vote! You get points for it :P<br>
</em></p>
