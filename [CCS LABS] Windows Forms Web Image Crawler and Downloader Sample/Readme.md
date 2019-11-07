# [CCS LABS] Windows Forms: Web Image Crawler and Downloader Sample
## Requires
- Visual Studio 2010
## License
- MS-LPL
## Technologies
- COM
- Interop
- C#
- File System
- Win32
- Windows Forms
- Multithreading
- Visual Studio 2010
- threading
- Visual Basic .NET
- .NET Framework 4.0
- Async
## Topics
- Interop
- Asynchronous Programming
- User Interface
- Multithreading
- UI Layout
- Background thread
- Full Screen
- Download
- Image
- HTTP Download
- COM Interop
- Async
- Threads
- UI Design
- Networking
- HTTP
- Language Samples
- Web API
- Queues
## Updated
- 12/06/2013
## Description

<h1>Introduction</h1>
<p><em>This sample is a working, albeit, incomplete web crawler which downloads every image that it finds. The program makes use of a number of advanced features but is written in such a way that even a novice will be able to use and take advantage of the most
 advanced features included.<br>
</em></p>
<h1><span>Building the Sample</span></h1>
<p><em>The sample was written in Visual Studio 2010. It should run on any Windows XP or better computer that is correctly configured.
<br>
</em></p>
<p><span style="font-size:20px; font-weight:bold">Description</span></p>
<p><em>I have written this sample to show you how some of the advanced features work in the axample supplied. It is not a full release candidate of the program; for that you should go to codeplex, or sourceforge. The following features are employed in this
 sample.</em></p>
<h3><em>Threading:</em></h3>
<p><em>The application does two main things - it crawls each page it finds starting at a link you provide. Each page it finds it checks all the links on the page and downloads all the images and add all the non-image links to the list of pages to crawl. To
 increase the speed and efficiency of the application these two tasks are run on separate threads.
<br>
</em></p>
<h3><em>Queues:</em></h3>
<p><em>Each thread has a corresponding Queue which it regularly checks - if there is a link in the Queue then the link is removed and processed. The imageQueue is where all the image urls are stored and they are downloaded with a WebClient in Async mode - which
 further increases the speed of the application. The urlQueue holds all the links to the pages that will be crawled for new links to add to the Queues.<br>
</em></p>
<h3><em>Desktop Display:</em></h3>
<p><em>As the program could theoretically run for years without user intervention it is not necessary for it to have a true Window's Form display clogging up the Desktop. Therefore, I created the Output GUI to display a small amount of information on the Desktop
 itself. <br>
</em></p>
<h3><em>Automatic File Downloading and Naming:</em></h3>
<p><em>Because we are not required to manually do anything with this program after it starts we need to handle the downloading of the files automatically. This means that we need to organise the files, and rename the files if necessary to ensure that we get
 them all and not just keep re-writting over the top of a few files.</em></p>
<p><em>If you like my samples then please nominate me for an MVP. <a href="http://mvp.microsoft.com/en-us/nominate-an-mvp.aspx">
http://mvp.microsoft.com/en-us/nominate-an-mvp.aspx</a>. Leave me a message if you nominated me!</em></p>
<h1>More Information</h1>
<p><em>The original program was written in C# and converted to VB.NEt using SharpDevelop.<br>
</em></p>
