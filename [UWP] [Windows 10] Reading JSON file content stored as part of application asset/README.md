# [UWP] [Windows 10] Reading JSON file content stored as part of application asset
## Requires
- Visual Studio 2015
## License
- MIT
## Technologies
- C#
- Windows Phone
- Windows 10
## Topics
- Isolated Storage
- Storage
- data and storage
- IsolatedStorageSettings
- Isolated Storage in windowsphone c#
## Updated
- 10/19/2015
## Description

<h1>Introduction</h1>
<p><em>Following sample helps the user to know how to create a settings or default data file which can be packaged as part of application deployment and read the details from the packed file.&nbsp; This sample try to address the common problem which a developer
 might come across while using accessing asset file using StorageFile class. </em>
</p>
<h1><span>Building the Sample</span></h1>
<p>Required environment : Visual Studio 2015 in Windows 10</p>
<p><em>Steps :</em></p>
<ol>
<li><em>Download the zip file to local folder.</em> </li><li><em>Unzip dowloaded file.</em> </li><li><em>Open up the ReadAppDataFromJsonAsset.sln file in Visual Studio 2015.</em>
</li><li><em>Build the solution with x86 (to run in mobile emulator)..</em> </li><li><em>Select mobile emulator for windows 10 (with required screen size).</em> </li><li><em>Run the application.<br>
</em></li></ol>
<p><span style="font-size:20px; font-weight:bold">Description</span></p>
<p>While creating an app for windows 10 mobile platform, I had a trouble in getting the details of how to create an app default settings files and how to read the same.&nbsp; After spending some time&nbsp;I got hold on how to creat the file&nbsp; as app asset
 but then stucked with a problem while reading the file content using GetFileFromApplicationUriAsyn(..),&nbsp;it just keep throwing error messages&nbsp;like &quot;A method was called at an unexpected time, File not found &quot; etc.</p>
<p>So I have decided to create a sample which could help developers like me in finding the way to add their setting file content as part of application package content and reading the details from the file.</p>
<ol>
<li>The attached sample create with Blank Universal Windows Platform template. </li><li>In the Mainpage.xaml added a list view control to bind the data read from file.
</li><li>Added a class file with required properties as a Model, SettingInfo.cs. </li><li>Added a MyAppDefaultValues.Json under Asset folder make sure to edit its properties with Build Action as Content.
</li><li>Then added simple FileIOHelper class which reads the content from settings file, we got read the file as task with GetAwaiter while using GetFileFromApplicationRuiAsync to avoid any surprises while gaining the access on content file.
</li><li>Once getting the access, I read the content and parse the same as Json array.
</li><li>Atlast serialize the JsonObject received from JsonArray as SettingInfo. </li><li>In the Mainpage.xaml.cs bind the details&nbsp;to listview control. </li></ol>
<p>&nbsp;</p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>C#</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">csharp</span>

<div class="preview">
<pre class="csharp">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Uri&nbsp;appUri&nbsp;=&nbsp;<span class="cs__keyword">new</span>&nbsp;Uri(fileName);<span class="cs__com">//File&nbsp;name&nbsp;should&nbsp;be&nbsp;prefixed&nbsp;with&nbsp;'ms-appx:///Assets/*</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;StorageFile&nbsp;anjFile&nbsp;=&nbsp;StorageFile.GetFileFromApplicationUriAsync(appUri).AsTask().ConfigureAwait(<span class="cs__keyword">false</span>).GetAwaiter().GetResult();&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">string</span>&nbsp;jsonText&nbsp;=&nbsp;FileIO.ReadTextAsync(anjFile).AsTask().ConfigureAwait(<span class="cs__keyword">false</span>).GetAwaiter().GetResult();&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;var&nbsp;jsonSerializer&nbsp;=&nbsp;<span class="cs__keyword">new</span>&nbsp;DataContractJsonSerializer(<span class="cs__keyword">typeof</span>(SettingInfo));&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;JsonArray&nbsp;anjarray&nbsp;=&nbsp;JsonArray.Parse(jsonText);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">foreach</span>&nbsp;(JsonValue&nbsp;oJsonVal&nbsp;<span class="cs__keyword">in</span>&nbsp;anjarray)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;JsonObject&nbsp;oJsonObj&nbsp;=&nbsp;oJsonVal.GetObject();&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">using</span>&nbsp;(MemoryStream&nbsp;jsonStream&nbsp;=&nbsp;<span class="cs__keyword">new</span>&nbsp;MemoryStream(Encoding.Unicode.GetBytes(oJsonObj.ToString())))&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;SettingInfo&nbsp;oContent&nbsp;=&nbsp;(SettingInfo)jsonSerializer.ReadObject(jsonStream);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;lstContent.Add(oContent);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}</pre>
</div>
</div>
</div>
<h1>More Information</h1>
<p><em>Refer:</em></p>
<p><em>For more details on best practices on&nbsp;file IO :</em></p>
<p><a href="https://www.suchan.cz/2014/07/file-io-best-practices-in-windows-and-phone-apps-part-1-available-apis-and-file-exists-checking/">https://www.suchan.cz/2014/07/file-io-best-practices-in-windows-and-phone-apps-part-1-available-apis-and-file-exists-checking/</a></p>
<p><em>For details on app package files : </em></p>
<p><a href="https://msdn.microsoft.com/en-us/library/windows/apps/xaml/hh965322.aspx">https://msdn.microsoft.com/en-us/library/windows/apps/xaml/hh965322.aspx</a></p>
