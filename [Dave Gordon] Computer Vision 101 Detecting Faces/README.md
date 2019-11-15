# [Dave Gordon] Computer Vision 101: Detecting Faces
## Requires
- Visual Studio 2012
## License
- MS-LPL
## Technologies
- C#
- vb
- File System
- User Interface
- Windows Forms
- Multithreading
- threading
- .NET Framework
- Visual Basic .NET
- Visual Basic.NET
- VB.Net
- Parallel Programming
- C# Language
- Async
- VB.NET Language Features
- Parallel Patterns Library (PPL)
- Task&lt;T&gt;
- WinForms
- Task Parallel Library
- C# 3.0
- Graphics Functions
- .NET 4.5
- OpenCV
- EmGU CV
- ZedGraph
## Topics
- Graphics
- C#
- Asynchronous Programming
- File System
- Dialogs
- User Interface
- Windows Forms
- Graphics and 3D
- Architecture and Design
- Multithreading
- threading
- Images
- visualization
- UI Layout
- Performance
- Collections
- Compare
- Parallel Programming
- Image manipulation
- Background thread
- Getting Started
- Image
- Concurrency
- Async
- Thread Synchronization
- Arrays
- .NET 4
- Drawing
- How to
- Threads
- Conversions
- Task Parallelism
- UI Design
- File Systems
- Files
- multimedia
- Gestures
- Language Samples
- Face detection
- Audio and video
- User Experience
- Async Programming
- Computer Vision
## Updated
- 12/17/2013
## Description

<div>
<h1>Introduction</h1>
</div>
<p>Now that we have all our images &ndash; it is time to start detecting the faces within those images. Once we have detected the faces we can then start to &ldquo;recognise&rdquo; them. This sample shows how to detect faces and parts of faces within a given
 image.</p>
<div>
<h1><img id="75521" src="http://i1.code.msdn.s-msft.com/dave-gordon-computer-b1012ed0/image/file/75521/1/screenhunter_02%20feb.%2004%2016.22.gif" alt="" width="718" height="473"></h1>
<h1>Building the Sample</h1>
</div>
<p>The sample was written in Visual Studio 2012, on Windows Server x64. It should run on any machine with Windows XP and better with the appropriate configuration. You will need to install Intel's
<a href="http://opencv.org/">OpenCV</a> (free) and the <a href="http://www.emgu.com/wiki/index.php/Main_Page">
EmGU CV</a> .Net wrappers (free).</p>
<p><img id="75493" src="75493-screenhunter_01%20feb.%2004%2012.09.gif" alt="" width="349" height="695" style="margin-left:10px; margin-right:10px; float:left">The solution explorer shows all the libraries you need to have in the root of
 your solution. These all need to be set to &quot;Copy Always&quot; within their properties. You can do that by selecting all of the libraries at once and right clickon on one of them and selecting properties.</p>
<p>You should reference the EMGU CV Assemblies in your project as normal.</p>
<p>You will notice I created a folder called cascades this where all the cascades are held and any new cascades you add should be added here as well.</p>
<p>With this number of libraries and cascades (although the cascades are quite small) the solution is very large indeed.</p>
<p>Computer Vision is a very complex science and the work we have to do to generate a solution is substantial.</p>
<p>&nbsp;</p>
<div>
<h1>Description</h1>
</div>
<p>We have changed the GUI for this sample as we are starting to get a little more complicated in what we want to achieve. The code was also refactored to ensure that the final code is understandable. As usual, the code is not written in, necessarily, the best
 way &ndash; it has been written to be understood which often means a more verbose writing method is employed.</p>
<p>The first thing we need to do is load the cascades &ndash; there are many cascades available on the internet, it is for you to select which ones are best for your particular needs. In the sample we are using 14 different cascades which holds the information
 required for our detector to recognise ROIs. An ROI is a Region Of Interest, such as eyes, faces, mouths, bodies and the like.</p>
<p>With so many cascades in operation we have had to employ multiple threads, through the Parallel Task library contained with .Net.</p>
<p>&nbsp;</p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>C#</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">csharp</span>

<div class="preview">
<pre class="csharp">&nbsp;Task&lt;Rectangle[]&gt;[]&nbsp;allTasks&nbsp;=&nbsp;<span class="cs__keyword">new</span>&nbsp;Task&lt;Rectangle[]&gt;[<span class="cs__number">14</span>];&nbsp;
&nbsp;
&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Task&lt;Rectangle[]&gt;&nbsp;taskProfileFace&nbsp;=&nbsp;<span class="cs__keyword">new</span>&nbsp;Task&lt;Rectangle[]&gt;(()&nbsp;=&gt;&nbsp;processProfileFace(Greyscale));&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__com">//&nbsp;Detect&nbsp;faces&nbsp;in&nbsp;Greyscale&nbsp;image</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Task&lt;Rectangle[]&gt;&nbsp;taskEye&nbsp;=&nbsp;<span class="cs__keyword">new</span>&nbsp;Task&lt;Rectangle[]&gt;(()&nbsp;=&gt;&nbsp;processEye(Greyscale));&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__com">//&nbsp;Detect&nbsp;Eyes&nbsp;in&nbsp;Greyscale&nbsp;image&nbsp;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Task&lt;Rectangle[]&gt;&nbsp;taskFrontalFaceAlt2&nbsp;=&nbsp;<span class="cs__keyword">new</span>&nbsp;Task&lt;Rectangle[]&gt;(()&nbsp;=&gt;&nbsp;processFrontalFaceAlt2(Greyscale));&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__com">//&nbsp;Detect&nbsp;faces&nbsp;in&nbsp;Greyscale&nbsp;image</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Task&lt;Rectangle[]&gt;&nbsp;taskParojosG&nbsp;=&nbsp;<span class="cs__keyword">new</span>&nbsp;Task&lt;Rectangle[]&gt;(()&nbsp;=&gt;&nbsp;processParojosG(Greyscale));&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__com">//&nbsp;Detect&nbsp;faces&nbsp;in&nbsp;Greyscale&nbsp;image</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Task&lt;Rectangle[]&gt;&nbsp;taskParojos&nbsp;=&nbsp;<span class="cs__keyword">new</span>&nbsp;Task&lt;Rectangle[]&gt;(()&nbsp;=&gt;&nbsp;processParojos(Greyscale));&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__com">//&nbsp;Detect&nbsp;faces&nbsp;in&nbsp;Greyscale&nbsp;image&nbsp;&#43;&nbsp;Normalised&nbsp;Histogram</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Task&lt;Rectangle[]&gt;&nbsp;taskOjoI&nbsp;=&nbsp;<span class="cs__keyword">new</span>&nbsp;Task&lt;Rectangle[]&gt;(()&nbsp;=&gt;&nbsp;processOjoI(Greyscale));&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__com">//&nbsp;Detect&nbsp;faces&nbsp;in&nbsp;Greyscale&nbsp;image&nbsp;&#43;&nbsp;Normalised&nbsp;Histogram&nbsp;&#43;&nbsp;Gama&nbsp;Correction</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Task&lt;Rectangle[]&gt;&nbsp;taskOjoD&nbsp;=&nbsp;<span class="cs__keyword">new</span>&nbsp;Task&lt;Rectangle[]&gt;(()&nbsp;=&gt;&nbsp;processOjoD(Greyscale));&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__com">//&nbsp;Detect&nbsp;faces&nbsp;in&nbsp;Greyscale&nbsp;image</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Task&lt;Rectangle[]&gt;&nbsp;taskNariz&nbsp;=&nbsp;<span class="cs__keyword">new</span>&nbsp;Task&lt;Rectangle[]&gt;(()&nbsp;=&gt;&nbsp;processNariz(Greyscale));&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__com">//&nbsp;Detect&nbsp;faces&nbsp;in&nbsp;Greyscale&nbsp;image&nbsp;&#43;&nbsp;Normalised&nbsp;Histogram</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Task&lt;Rectangle[]&gt;&nbsp;taskMouth&nbsp;=&nbsp;<span class="cs__keyword">new</span>&nbsp;Task&lt;Rectangle[]&gt;(()&nbsp;=&gt;&nbsp;processMouth(Greyscale));&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__com">//&nbsp;Detect&nbsp;faces&nbsp;in&nbsp;Greyscale&nbsp;image&nbsp;&#43;&nbsp;Normalised&nbsp;Histogram&nbsp;&#43;&nbsp;Gama&nbsp;Correction</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Task&lt;Rectangle[]&gt;&nbsp;taskHS&nbsp;=&nbsp;<span class="cs__keyword">new</span>&nbsp;Task&lt;Rectangle[]&gt;(()&nbsp;=&gt;&nbsp;processHS(Greyscale));&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__com">//&nbsp;Detect&nbsp;faces&nbsp;in&nbsp;Greyscale&nbsp;image</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Task&lt;Rectangle[]&gt;&nbsp;taskUpperBody&nbsp;=&nbsp;<span class="cs__keyword">new</span>&nbsp;Task&lt;Rectangle[]&gt;(()&nbsp;=&gt;&nbsp;processUpperBody(Greyscale));&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__com">//&nbsp;Detect&nbsp;faces&nbsp;in&nbsp;Greyscale&nbsp;image&nbsp;&#43;&nbsp;Normalised&nbsp;Histogram</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Task&lt;Rectangle[]&gt;&nbsp;taskLowerBody&nbsp;=&nbsp;<span class="cs__keyword">new</span>&nbsp;Task&lt;Rectangle[]&gt;(()&nbsp;=&gt;&nbsp;processLowerBody(Greyscale));&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__com">//&nbsp;Detect&nbsp;faces&nbsp;in&nbsp;Greyscale&nbsp;image&nbsp;&#43;&nbsp;Normalised&nbsp;Histogram&nbsp;&#43;&nbsp;Gama&nbsp;Correction</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Task&lt;Rectangle[]&gt;&nbsp;taskFullBody&nbsp;=&nbsp;<span class="cs__keyword">new</span>&nbsp;Task&lt;Rectangle[]&gt;(()&nbsp;=&gt;&nbsp;processFullBody(Greyscale));&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__com">//&nbsp;Detect&nbsp;faces&nbsp;in&nbsp;Greyscale&nbsp;image</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Task&lt;Rectangle[]&gt;&nbsp;taskFrontalEye&nbsp;=&nbsp;<span class="cs__keyword">new</span>&nbsp;Task&lt;Rectangle[]&gt;(()&nbsp;=&gt;&nbsp;processFrontalEye(Greyscale));&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__com">//&nbsp;Detect&nbsp;faces&nbsp;in&nbsp;Greyscale&nbsp;image&nbsp;&#43;&nbsp;Normalised&nbsp;Histogram</span><span class="cs__com">//&nbsp;Add&nbsp;all&nbsp;the&nbsp;tasks&nbsp;to&nbsp;a&nbsp;task&nbsp;array&nbsp;for&nbsp;use&nbsp;later&nbsp;when&nbsp;waiting&nbsp;all&nbsp;the&nbsp;tasks.</span><span class="cs__com">//&nbsp;There&nbsp;are&nbsp;better&nbsp;ways&nbsp;of&nbsp;doing&nbsp;all&nbsp;this&nbsp;task&nbsp;work,&nbsp;but&nbsp;none&nbsp;more&nbsp;clear&nbsp;in&nbsp;my&nbsp;opinion.</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;allTasks[<span class="cs__number">0</span>]&nbsp;=&nbsp;taskProfileFace;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;allTasks[<span class="cs__number">1</span>]&nbsp;=&nbsp;taskEye;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;allTasks[<span class="cs__number">2</span>]&nbsp;=&nbsp;taskFrontalFaceAlt2;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;allTasks[<span class="cs__number">3</span>]&nbsp;=&nbsp;taskParojosG;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;allTasks[<span class="cs__number">4</span>]&nbsp;=&nbsp;taskParojos;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;allTasks[<span class="cs__number">5</span>]&nbsp;=&nbsp;taskOjoI;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;allTasks[<span class="cs__number">6</span>]&nbsp;=&nbsp;taskOjoD;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;allTasks[<span class="cs__number">7</span>]&nbsp;=&nbsp;taskNariz;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;allTasks[<span class="cs__number">8</span>]&nbsp;=&nbsp;taskMouth;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;allTasks[<span class="cs__number">9</span>]&nbsp;=&nbsp;taskHS;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;allTasks[<span class="cs__number">10</span>]&nbsp;=&nbsp;taskUpperBody;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;allTasks[<span class="cs__number">11</span>]&nbsp;=&nbsp;taskLowerBody;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;allTasks[<span class="cs__number">12</span>]&nbsp;=&nbsp;taskFullBody;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;allTasks[<span class="cs__number">13</span>]&nbsp;=&nbsp;taskFrontalEye;&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__com">//&nbsp;Start&nbsp;the&nbsp;Processing&nbsp;Tasks</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;taskProfileFace.Start();&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;taskEye.Start();&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;taskFrontalFaceAlt2.Start();&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;taskParojosG.Start();&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;taskParojos.Start();&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;taskOjoI.Start();&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;taskOjoD.Start();&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;taskNariz.Start();&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;taskMouth.Start();&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;taskHS.Start();&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;taskUpperBody.Start();&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;taskLowerBody.Start();&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;taskFullBody.Start();&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;taskFrontalEye.Start();&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Task.WaitAll(allTasks,&nbsp;<span class="cs__keyword">new</span>&nbsp;CancellationToken(STOP));&nbsp;<span class="cs__com">//&nbsp;Wait&nbsp;for&nbsp;all&nbsp;the&nbsp;tasks&nbsp;to&nbsp;complete</span></pre>
</div>
</div>
</div>
<p>We created a Task Array in which all our tasks were added. This allowed us to do a simple Task.WaitAll once all the tasks were started. The lines which set up what the task will do looks like this:</p>
<p>&nbsp;</p>
<pre style="font-family:Consolas; font-size:13; color:gainsboro; background:#1e1e1e"><span style="color:#4ec9b0">Task</span><span style="color:#b4b4b4">&lt;</span>Rectangle[]<span style="color:#b4b4b4">&gt;</span>&nbsp;<span style="color:white">taskProfileFace</span>&nbsp;<span style="color:#b4b4b4">=</span>&nbsp;<span style="color:#569cd6">new</span>&nbsp;<span style="color:#4ec9b0">Task</span><span style="color:#b4b4b4">&lt;</span>Rectangle[]<span style="color:#b4b4b4">&gt;</span>(()&nbsp;<span style="color:#b4b4b4">=&gt;</span>&nbsp;<span style="color:white">processProfileFace</span>(<span style="color:white">Greyscale</span>));&nbsp;
</pre>
<p>All this says is the Task which returns an array of Rectangles, runs the method ProcessProfileFace which takes Greyscal as a parameter. Greyscale is a greyscal version of the original which has been converted to Greyscale regardless of what form it originally
 was provided in.</p>
<p>We then get all the results of the tasks when they have completed using the following code:</p>
<p>&nbsp;</p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>C#</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">csharp</span>

<div class="preview">
<pre class="csharp">Rectangle[]&nbsp;ProfileFaceRectangles&nbsp;=&nbsp;taskProfileFace.Result;&nbsp;
Rectangle[]&nbsp;EyeRectangles&nbsp;=&nbsp;taskEye.Result;&nbsp;
Rectangle[]&nbsp;FrontalFaceAlt2Rectangles&nbsp;=&nbsp;taskFrontalFaceAlt2.Result;&nbsp;
Rectangle[]&nbsp;ParajosGRectangles&nbsp;=&nbsp;taskParojosG.Result;&nbsp;
Rectangle[]&nbsp;ParajosRectangles&nbsp;=&nbsp;taskParojos.Result;&nbsp;
Rectangle[]&nbsp;OjoIRectangles&nbsp;=&nbsp;taskOjoI.Result;&nbsp;
Rectangle[]&nbsp;OjoDRectangles&nbsp;=&nbsp;taskOjoD.Result;&nbsp;
Rectangle[]&nbsp;NarizRectangles&nbsp;=&nbsp;taskNariz.Result;&nbsp;
Rectangle[]&nbsp;MouthRectangles&nbsp;=&nbsp;taskMouth.Result;&nbsp;
Rectangle[]&nbsp;HSRectangles&nbsp;=&nbsp;taskHS.Result;&nbsp;
Rectangle[]&nbsp;UpperBodyRectangles&nbsp;=&nbsp;taskUpperBody.Result;&nbsp;
Rectangle[]&nbsp;LowerBodyRectangles&nbsp;=&nbsp;taskLowerBody.Result;&nbsp;
Rectangle[]&nbsp;FullBodyRectangles&nbsp;=&nbsp;taskFullBody.Result;&nbsp;
Rectangle[]&nbsp;FrontalEyeRectangles&nbsp;=&nbsp;taskFrontalEye.Result;</pre>
</div>
</div>
</div>
<div class="endscriptcode">It must be noted all these tasks are not strictly necessary, I have done it to show you how multiple cascades can be used - I am not suggesting they should be. That will depend on what you want to achieve, and the quality of the
 cascades.</div>
<div class="endscriptcode"></div>
<div class="endscriptcode">The Tasks run methods which resemble this:</div>
<div class="endscriptcode"></div>
<div class="endscriptcode">
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>C#</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">csharp</span>

<div class="preview">
<pre class="csharp">&nbsp;<span class="cs__keyword">private</span>&nbsp;Rectangle[]&nbsp;processFrontalEye(Image&lt;Gray,&nbsp;<span class="cs__keyword">byte</span>&gt;&nbsp;Greyscale)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;CascadeClassifier&nbsp;h&nbsp;=&nbsp;<span class="cs__keyword">new</span>&nbsp;CascadeClassifier(frontalEyesPath);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">return</span>&nbsp;h.DetectMultiScale(Greyscale,&nbsp;ScaleFactor,&nbsp;MinimumNeighbours,&nbsp;<span class="cs__keyword">new</span>&nbsp;Size(MinimumFaceSize,&nbsp;MinimumFaceSize),&nbsp;<span class="cs__keyword">new</span>&nbsp;Size(MaximumFaceSize,&nbsp;MaximumFaceSize));&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}</pre>
</div>
</div>
</div>
<div class="endscriptcode">We instantiate a new CascadeClassifier with the path to the actual cascade xml file. then using the CascadeClassifier we Detect the features within the image. DetectMultiScale takes a number of parameters which I will detail in
 the next installment of this series when we start to look at optimising the quality of the results.</div>
<div class="endscriptcode"></div>
<div class="endscriptcode">The rectangles that are returned are then drawn onto the original image for us to determine the accuracy of the detection system; using the following method.</div>
<div class="endscriptcode"></div>
<div class="endscriptcode">
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>C#</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">csharp</span>

<div class="preview">
<pre class="csharp">&nbsp;<span class="cs__keyword">private</span>&nbsp;<span class="cs__keyword">void</span>&nbsp;AddRectanglesToOriginalImage(Image&lt;Rgb,&nbsp;Byte&gt;&nbsp;Original,&nbsp;Rectangle[]&nbsp;ProfileFaceRectangles,&nbsp;System.Drawing.Color&nbsp;displayColour)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">try</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">foreach</span>&nbsp;(var&nbsp;face&nbsp;<span class="cs__keyword">in</span>&nbsp;ProfileFaceRectangles)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">if</span>&nbsp;(face.Width&nbsp;&lt;&nbsp;MinFSDetected&nbsp;&amp;&amp;&nbsp;face.Width&nbsp;&gt;&nbsp;<span class="cs__number">0</span>)&nbsp;MinFSDetected&nbsp;=&nbsp;face.Width;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">if</span>&nbsp;(face.Width&nbsp;&gt;&nbsp;MaxFSDetected)&nbsp;MaxFSDetected&nbsp;=&nbsp;face.Width;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Original.Draw(<span class="cs__keyword">new</span>&nbsp;Rectangle(face.X,&nbsp;face.Y,&nbsp;face.Width,&nbsp;face.Height),&nbsp;<span class="cs__keyword">new</span>&nbsp;Rgb(displayColour),&nbsp;<span class="cs__number">1</span>);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;progressThisPicture.Value&nbsp;=&nbsp;progressThisPicture.Value&nbsp;&#43;&nbsp;<span class="cs__number">1</span>;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;progressThisPicture.Refresh();&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">catch</span>&nbsp;(Exception&nbsp;ex)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;MessageBox.Show(ex.Message);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}</pre>
</div>
</div>
</div>
<div class="endscriptcode">&nbsp;</div>
<div class="endscriptcode"></div>
<div class="endscriptcode"></div>
The program is started and stopped by clicking on the Start button.</div>
</div>
<p>&nbsp;</p>
<div>
<h1>More Information</h1>
</div>
<p>To convert the sample to a previous version of Visual Studio use this: <a href="http://www.codeproject.com/Articles/70569/Microsoft-Visual-Studio-Solution-File-Version-Chan">
Microsoft Visual Studio Solution File Version Change</a></p>
<p>To convert the sample to Visual Basic use this: <a href="http://www.icsharpcode.net/opensource/sd/">
SharpDevelop</a></p>
<div>
<h1>Further Articles</h1>
</div>
<ol>
<li><a href="http://code.msdn.microsoft.com/Dave-Gordon-Computer-3151dbdc">[Dave Gordon] Computer Vision 101: Iterating through File System Images</a>
</li><li><em>This Article</em> </li><li><em>Adding Detection and updating the UI</em> </li><li><em>Understanding Idetification</em> </li><li><em>Adding Identification and updating the UI</em> </li><li><em>Practical uses.</em> </li></ol>
<p>These further articles will be created if they are wanted and this article is voted for.</p>
