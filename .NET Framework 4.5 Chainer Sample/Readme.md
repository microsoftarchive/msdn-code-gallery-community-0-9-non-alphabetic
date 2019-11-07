# .NET Framework 4.5 Chainer Sample
## Requires
- Visual Studio 2012
## License
- Apache License, Version 2.0
## Technologies
- .NET Framework 4.5
## Topics
- Deploying .NET Framework
## Updated
- 08/21/2012
## Description

<h1>Introduction</h1>
<p>The .NET Framework 4.5 is a redistributable runtime. If you develop applications for this version, you can include (chain) .NET Framework setup as a prerequisite component in your application's setup. To present a customized or unified setup experience,
 you may want to silently launch .NET Framework setup and track its progress while showing your application's setup progress. To enable silent tracking, the .NET Framework setup process (which can be watched) can write progress messages to a memory-mapped I/O
 (MMIO) segment that your setup process (the watcher or chainer) can read. You can cancel .NET Framework setup by writing an
<strong><span class="input">Abort</span></strong> message to the MMIO segment. For more information, see
<a title="How to: Get Progress from the .NET Framework 4 Installer" href="http://msdn.microsoft.com/en-us/library/ff859983(v=VS.100).aspx" target="_blank">
How to: Get Progress from the .NET Framework Installer</a> in the MSDN Library. For the .NET Framework 4 version of this sample, see
<a title=".NET Framework 4 Chainer Sample" href="http://code.msdn.microsoft.com/NET-Framework-4-Chainer-5dc250a1" target="_blank">
.NET Framework 4 Chainer Sample</a>.</p>
<h1><span>Building the Sample</span></h1>
<p>Download the sample code files to your computer. Open the solution (Chainer4.5.sln) in Visual Studio 2012, and build the solution.</p>
<h1><span style="font-size:20px; font-weight:bold">Description</span></h1>
<p><strong><span class="label">Invocation</span>.</strong> To call .NET Framework setup and receive progress information from the MMIO section, your setup program must do the following:</p>
<ul>
<li>Call the .NET Framework 4.5 redistributable program:
<pre>dotNetFx45_Full_setup /q /pipe <em>section-name </em></pre>
<div>where <em><span class="parameter">section-name</span></em> is any name you want to use to identify your application. .NET Framework setup reads and writes to the MMIO section asynchronously, so you might find it convenient to use events and messages
 during that time. In the sample code, the .NET Framework setup process is created by a constructor that both allocates the MMIO section (<code>TheSectionName</code>) and defines an event (<code>TheEventName</code>).</div>
<pre>Server():ChainerSample::MmioChainer(L<span class="cpp__string">&quot;TheSectionName&quot;</span>, L<span class="cpp__string">&quot;TheEventName&quot;)</span></pre>
Please replace those names with names that are unique to your setup program.
<div></div>
</li><li>
<div>Read from the MMIO section. In the .NET Framework 4.5 Developer Preview, the download and installation operations are simultaneous: One component of the .NET Framework might be installing while another is downloading. As a result, progress is sent back
 (that is, written) to the MMIO section as a number that increases from 1 to 255. When 255 is written and .NET Framework setup exits, the installation is complete.</div>
</li></ul>
<div></div>
<div><strong><span class="label">Exit codes</span>.</strong> The following exit codes from the command to call the .NET Framework 4.5 redistributable program indicate whether setup has succeeded or failed:</div>
<ul>
<li>
<div>0 - Setup completed successfully.</div>
</li><li>
<div>3010 &ndash; Setup completed successfully; reboot is required.</div>
</li><li>
<div>1642 &ndash; Setup has been canceled.</div>
</li><li>
<div>All other codes - Setup encountered errors; examine the log files created in %temp% for details.</div>
</li></ul>
<div><strong><span class="label">Canceling setup</span>.</strong> You can cancel setup at any time by using the
<strong><span class="input">Abort</span></strong> method to set the <strong><span class="input">m_downloadAbort</span>
</strong>and <strong><span class="input">m_ installAbort</span> </strong>flags in the MMIO section.</div>
<p>&nbsp;</p>
<h1><span>Source Code Files</span></h1>
<ul>
<em>&nbsp;</em>
<li>ChainingdotNet4.5.cpp - The chainer code </li><li>IProgressObserver.h - Header file </li><li>MmIoChainer.h - Header file </li></ul>
<p>&nbsp;</p>
<h1>More Information</h1>
<ul>
<li><a title="How to: Get Progress from the .NET Framework 4 Installer" href="http://msdn.microsoft.com/en-us/library/ff859983(v=VS.100).aspx" target="_blank">How to: Get Progress from the .NET Framework Installer</a>
</li></ul>
