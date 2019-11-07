# .NET Video Reader and Thumbnailer
## Requires
- Visual Studio 2015
## License
- MIT
## Technologies
- ASP.NET
## Topics
- video reader
- video thumbnail
- video metadata
## Updated
- 08/08/2019
## Description

<h1>VideoUltimate: .NET Video Reader and Thumbnailer</h1>
<p>VideoUltimate is the fastest and easiest .NET Video Reader and Thumbnailer library for reading video files without any dependencies.</p>
<ul>
<li>Read any video file format on the planet. </li><li>Read a video file frame by frame. </li><li>Generate meaningful thumbnails. </li><li>Read info and metadata of the video file. </li></ul>
<p><img id="158775" src="158775-videoultimate-screenshot.png" alt="" width="736"></p>
<p><strong>Note:</strong> This project&nbsp;contains a fully working version of the product, however without a license key it will run in trial mode. For more information, please see&nbsp;<a href="http://www.gleamtech.com/videoultimate">VideoUltimate: .NET
 Video Reader and Thumbnailer</a>&nbsp;product page.</p>
<div>
<h3 style="margin-top:24px; margin-bottom:16px; font-size:1.25em; font-weight:600; line-height:1.25; color:#24292e">
To use VideoUltimate in a project, do the following in Visual Studio:</h3>
<ol style="padding-left:2em; margin-top:0px; color:#24292e; font-size:16px; margin-bottom:0px!important">
<li>
<p style="margin-top:16px; margin-bottom:16px">Add references to VideoUltimate assemblies. There are two ways to perform this:</p>
<ul style="padding-left:2em; margin-top:0px; margin-bottom:0px">
<li>
<p style="margin-top:16px; margin-bottom:16px">Add reference to&nbsp;<span style="font-weight:600">GleamTech.Core.dll</span>&nbsp;and&nbsp;<span style="font-weight:600">GleamTech.VideoUltimate.dll</span>&nbsp;found in &quot;Bin&quot; folder of VideoUltimate-vX.X.X.X.zip
 package which you already downloaded and extracted.</p>
</li><li style="margin-top:0.25em">
<p style="margin-top:16px; margin-bottom:16px">Or install NuGet package and add references automatically via NuGet Package Manager in Visual Studio: Go to&nbsp;<span style="font-weight:600">Tools -&gt; NuGet Package Manager -&gt; Package Manager Console</span>&nbsp;and
 run this command:</p>
<p style="margin-top:16px; margin-bottom:16px"><code style="font-family:SFMono-Regular,Consolas,&quot;Liberation Mono&quot;,Menlo,Courier,monospace; font-size:13.6px; padding:0.2em 0.4em; margin:0px">Install-Package VideoUltimate -Source https://get.gleamtech.com/nuget/default/</code></p>
<p style="margin-top:16px; margin-bottom:16px">If you prefer using the user interface when working with NuGet, you can also install the package this way:</p>
<ul style="padding-left:2em; margin-top:0px; margin-bottom:0px">
<li>
<p style="margin-top:16px; margin-bottom:16px">&nbsp;GleamTech has its own NuGet feed so first you need to add this feed to be able to find GleamTech's packages. Go to&nbsp;<span style="font-weight:600">Tools -&gt; NuGet Package Manager -&gt; Package Manager
 Settings</span>&nbsp;and then click the&nbsp;<span style="font-weight:600">&#43;</span>&nbsp;button to add a new package source. Enter&nbsp;<code style="font-family:SFMono-Regular,Consolas,&quot;Liberation Mono&quot;,Menlo,Courier,monospace; font-size:13.6px; padding:0.2em 0.4em; margin:0px">GleamTech</code>&nbsp;in&nbsp;<span style="font-weight:600">Name</span>&nbsp;field
 and&nbsp;<code style="font-family:SFMono-Regular,Consolas,&quot;Liberation Mono&quot;,Menlo,Courier,monospace; font-size:13.6px; padding:0.2em 0.4em; margin:0px">https://get.gleamtech.com/nuget/default/</code>&nbsp;in&nbsp;<span style="font-weight:600">Source</span>field
 and click&nbsp;<span style="font-weight:600">OK</span>.</p>
</li><li style="margin-top:0.25em">
<p style="margin-top:16px; margin-bottom:16px">Go to&nbsp;<span style="font-weight:600">Tools -&gt; NuGet Package Manager -&gt; Manage NuGet Packages for Solution</span>, select&nbsp;<code style="font-family:SFMono-Regular,Consolas,&quot;Liberation Mono&quot;,Menlo,Courier,monospace; font-size:13.6px; padding:0.2em 0.4em; margin:0px">GleamTech</code>&nbsp;or&nbsp;<code style="font-family:SFMono-Regular,Consolas,&quot;Liberation Mono&quot;,Menlo,Courier,monospace; font-size:13.6px; padding:0.2em 0.4em; margin:0px">All</code>&nbsp;in
 the Package source dropdown on the top right. Now enter&nbsp;<code style="font-family:SFMono-Regular,Consolas,&quot;Liberation Mono&quot;,Menlo,Courier,monospace; font-size:13.6px; padding:0.2em 0.4em; margin:0px">VideoUltimate</code>&nbsp;in the search field, and click&nbsp;<span style="font-weight:600">Install</span>button
 on the found package.</p>
</li></ul>
</li></ul>
</li><li style="margin-top:0.25em">
<p style="margin-top:16px; margin-bottom:16px">Set VideoUltimate's global configuration. For example, you may want to set the license key. Insert the following line into the&nbsp;<code style="font-family:SFMono-Regular,Consolas,&quot;Liberation Mono&quot;,Menlo,Courier,monospace; font-size:13.6px; padding:0.2em 0.4em; margin:0px">Application_Start</code>&nbsp;method
 of your&nbsp;<span style="font-weight:600">Global.asax.cs</span>&nbsp;for Web projects or Main method for other project types:</p>
<div class="highlight highlight-source-cs" style="margin-bottom:16px">
<pre style="font-family:SFMono-Regular,Consolas,&quot;Liberation Mono&quot;,Menlo,Courier,monospace; font-size:13.6px; margin-top:0px; margin-bottom:0px; word-wrap:normal; padding:16px; overflow:auto; line-height:1.45; background-color:#f6f8fa; word-break:normal"><span class="pl-c" style="color:#6a737d">//Set this property only if you have a valid license key, otherwise do not</span>
<span class="pl-c" style="color:#6a737d">//set it so VideoUltimate runs in trial mode.</span>
<span class="pl-en" style="color:#6f42c1">VideoUltimateConfiguration.Current.LicenseKey</span> = &quot;QQJDJLJP34...&quot;;</pre>
</div>
<p style="margin-top:16px; margin-bottom:16px">Alternatively you can specify the configuration in&nbsp;<code style="font-family:SFMono-Regular,Consolas,&quot;Liberation Mono&quot;,Menlo,Courier,monospace; font-size:13.6px; padding:0.2em 0.4em; margin:0px">&lt;appSettings&gt;</code>&nbsp;tag
 of your Web.config (or App.exe.config).</p>
<div class="highlight highlight-text-xml" style="margin-bottom:16px">
<pre style="font-family:SFMono-Regular,Consolas,&quot;Liberation Mono&quot;,Menlo,Courier,monospace; font-size:13.6px; margin-top:0px; margin-bottom:0px; word-wrap:normal; padding:16px; overflow:auto; line-height:1.45; background-color:#f6f8fa; word-break:normal">&lt;<span class="pl-ent" style="color:#22863a">add</span> <span class="pl-e" style="color:#6f42c1">key</span>=<span class="pl-s" style="color:#032f62"><span class="pl-pds">&quot;</span>VideoUltimate:LicenseKey<span class="pl-pds">&quot;</span></span> <span class="pl-e" style="color:#6f42c1">value</span>=<span class="pl-s" style="color:#032f62"><span class="pl-pds">&quot;</span>QQJDJLJP34...<span class="pl-pds">&quot;</span></span> /&gt;</pre>
</div>
<p style="margin-top:16px; margin-bottom:16px">As you would notice,&nbsp;<code style="font-family:SFMono-Regular,Consolas,&quot;Liberation Mono&quot;,Menlo,Courier,monospace; font-size:13.6px; padding:0.2em 0.4em; margin:0px">VideoUltimate:</code>&nbsp;prefix maps to&nbsp;<code style="font-family:SFMono-Regular,Consolas,&quot;Liberation Mono&quot;,Menlo,Courier,monospace; font-size:13.6px; padding:0.2em 0.4em; margin:0px">VideoUltimateConfiguration.Current</code>.</p>
</li><li style="margin-top:0.25em">
<p style="margin-top:16px; margin-bottom:16px">Open one of your class files (eg. Program.cs) and at the top of your file add&nbsp;<code style="font-family:SFMono-Regular,Consolas,&quot;Liberation Mono&quot;,Menlo,Courier,monospace; font-size:13.6px; padding:0.2em 0.4em; margin:0px">GleamTech.VideoUltimate</code>&nbsp;namespace:</p>
<div class="highlight highlight-source-cs" style="margin-bottom:16px">
<pre style="font-family:SFMono-Regular,Consolas,&quot;Liberation Mono&quot;,Menlo,Courier,monospace; font-size:13.6px; margin-top:0px; margin-bottom:0px; word-wrap:normal; padding:16px; overflow:auto; line-height:1.45; background-color:#f6f8fa; word-break:normal"><span class="pl-k" style="color:#d73a49">using</span> <span class="pl-en" style="color:#6f42c1">GleamTech.VideoUltimate</span>;</pre>
</div>
<p style="margin-top:16px; margin-bottom:16px">Now in some method insert these lines:</p>
<div class="highlight highlight-source-cs" style="margin-bottom:16px">
<pre style="font-family:SFMono-Regular,Consolas,&quot;Liberation Mono&quot;,Menlo,Courier,monospace; font-size:13.6px; margin-top:0px; margin-bottom:0px; word-wrap:normal; padding:16px; overflow:auto; line-height:1.45; background-color:#f6f8fa; word-break:normal"><span class="pl-k" style="color:#d73a49">using</span> (<span class="pl-en" style="color:#6f42c1">var</span> videoFrameReader = <span class="pl-en" style="color:#6f42c1">new</span> <span class="pl-en" style="color:#6f42c1">VideoFrameReader</span>(@&quot;<span class="pl-en" style="color:#6f42c1">C</span>:\<span class="pl-en" style="color:#6f42c1">Video.mp4</span>&quot;))
{
    <span class="pl-en" style="color:#6f42c1">if</span> (<span class="pl-en" style="color:#6f42c1">videoFrameReader.Read</span>()) <span class="pl-c" style="color:#6a737d">//Only if frame was read successfully</span>
    {
        <span class="pl-c" style="color:#6a737d">//Get a System.Drawing.Bitmap for the current frame</span>
        <span class="pl-c" style="color:#6a737d">//You are responsible for disposing the bitmap when you are finished with it.</span>
        <span class="pl-c" style="color:#6a737d">//So it's good practice to have a &quot;using&quot; statement for the retrieved bitmap.</span>
        <span class="pl-en" style="color:#6f42c1">using</span> (<span class="pl-en" style="color:#6f42c1">var</span> <span class="pl-en" style="color:#6f42c1">frame</span> = <span class="pl-en" style="color:#6f42c1">videoFrameReader.GetFrame</span>())
            <span class="pl-c" style="color:#6a737d">//Reference System.Drawing and use System.Drawing.Imaging namespace for the following line.</span>
            <span class="pl-en" style="color:#6f42c1">frame.Save</span>(@&quot;<span class="pl-en" style="color:#6f42c1">C</span>:\<span class="pl-en" style="color:#6f42c1">Frame1.jpg</span>&quot;, <span class="pl-en" style="color:#6f42c1">ImageFormat.Jpeg</span>);
    }
}</pre>
</div>
<p style="margin-top:16px; margin-bottom:16px">This will open the source video &quot;C:\Video.mp4&quot;, read the first frame, and if the frame is read and decoded successfully, it will get a Bitmap instance of the frame and save it as &quot;C:\Frame1.jpg&quot;.</p>
<p style="margin-top:16px; margin-bottom:16px">Sometimes you may only need to quickly generate a meaningful thumbnail for a video, you can use VideoThumbnailer class for this:</p>
<div class="highlight highlight-source-cs" style="margin-bottom:16px">
<pre style="font-family:SFMono-Regular,Consolas,&quot;Liberation Mono&quot;,Menlo,Courier,monospace; font-size:13.6px; margin-top:0px; margin-bottom:0px; word-wrap:normal; padding:16px; overflow:auto; line-height:1.45; background-color:#f6f8fa; word-break:normal"><span class="pl-k" style="color:#d73a49">using</span> (<span class="pl-en" style="color:#6f42c1">var</span> videoThumbnailer = <span class="pl-en" style="color:#6f42c1">new</span> <span class="pl-en" style="color:#6f42c1">VideoThumbnailer</span>(@&quot;<span class="pl-en" style="color:#6f42c1">C</span>:\<span class="pl-en" style="color:#6f42c1">Video.mp4</span>&quot;))
<span class="pl-c" style="color:#6a737d">//Generate a meaningful thumbnail of the video and</span>
<span class="pl-c" style="color:#6a737d">//get a System.Drawing.Bitmap with 100x100 maximum size.</span>
<span class="pl-c" style="color:#6a737d">//You are responsible for disposing the bitmap when you are finished with it.</span>
<span class="pl-c" style="color:#6a737d">//So it's good practice to have a &quot;using&quot; statement for the retrieved bitmap.</span>
<span class="pl-en" style="color:#6f42c1">using</span> (<span class="pl-en" style="color:#6f42c1">var</span> <span class="pl-en" style="color:#6f42c1">thumbnail</span> = <span class="pl-en" style="color:#6f42c1">videoThumbnailer.GenerateThumbnail</span>(<span class="pl-en" style="color:#6f42c1">100</span>))
    <span class="pl-c" style="color:#6a737d">//Reference System.Drawing and use System.Drawing.Imaging namespace for the following line.</span>
    <span class="pl-en" style="color:#6f42c1">thumbnail.Save</span>(@&quot;<span class="pl-en" style="color:#6f42c1">C</span>:\<span class="pl-en" style="color:#6f42c1">Thumbnail1.jpg</span>&quot;, <span class="pl-en" style="color:#6f42c1">ImageFormat.Jpeg</span>);</pre>
</div>
</li></ol>
</div>
