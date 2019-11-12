# 3D graphics. Load and animation model.
## Requires
- Visual Studio 2010
## License
- MIT
## Technologies
- Windows Forms
- Visual Studio 2010
- C++
- .NET Framework
- 3D animations
- OpenGL
## Topics
- User Interface
- Windows Forms
- Graphics and 3D
- .NET 4
## Updated
- 08/27/2015
## Description

<h1>Introduction</h1>
<p>There are many file formats. In this example we look at the structure .mdl file. This format is used in such legendary games as Half-Life and Counter-Strike.</p>
<p>Many people wonder how it all works. The example shows how to load a file and animation.</p>
<p>&nbsp;</p>
<p>The main objective of this example to show how to mix managed and unmanaged code. Those interested in 3D graphics just do not find for themselves a lot of interesting things.<br>
<br>
</p>
<h1><span>Building the Sample</span></h1>
<p>For assembly, open the solution in VS, and then build. If you are using the express version, the libraries are not included. In case if you can not find them, then lay out further.</p>
<p><span style="font-size:20px; font-weight:bold">Description</span></p>
<p><em>&nbsp;</em>Quick start.<br>
The results are output.</p>
<p><img id="141716" src="141716-sample_mdl.jpg" alt="" width="534" height="341"></p>
<p>&nbsp;</p>
<p>In this case, the window inherits the System :: Windows :: Forms :: Form. HDC we obtain in the usual manner.</p>
<p>&nbsp;</p>
<p></p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>C&#43;&#43;</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Из&#1084;енение сценария</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">cplusplus</span>

<div class="preview">
<pre class="cplusplus"><span class="cpp__keyword">if</span>&nbsp;(!(hDC=GetDC((<span class="cpp__datatype">HWND</span>)hwnd.ToPointer())))&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;MessageBox::Show(&nbsp;<span class="cpp__string">&quot;Can't&nbsp;Create&nbsp;A&nbsp;GL&nbsp;Device&nbsp;Context.&quot;</span>,<span class="cpp__string">&quot;ERROR&quot;</span>);&nbsp;
</pre>
</div>
</div>
</div>
<p></p>
<p>No additional libraries are required. It should also be said that use OpenGL. But you will not be difficult to rewrite the code of DirectX.</p>
<p>Interaction of managed and unmanaged code in this example is rather complicated. Because of the managed and unmanaged classes.</p>
<p></p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>C&#43;&#43;</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Из&#1084;енение сценария</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">cplusplus</span>

<div class="preview">
<pre class="cplusplus"><span class="cpp__keyword">public</span>&nbsp;ref&nbsp;<span class="cpp__keyword">class</span>&nbsp;Form1&nbsp;:&nbsp;<span class="cpp__keyword">public</span>&nbsp;System::Windows::Forms::Form&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cpp__keyword">public</span>:IntPtr&nbsp;hwnd;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cpp__com">//public:IntPtr&nbsp;hDC;</span><span class="cpp__keyword">public</span>:&nbsp;<span class="cpp__datatype">HDC</span>&nbsp;hDC;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cpp__keyword">public</span>:&nbsp;&nbsp;&nbsp;&nbsp;GLuint&nbsp;PixelFormat;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cpp__keyword">public</span>:&nbsp;&nbsp;&nbsp;&nbsp;HGLRC&nbsp;&nbsp;&nbsp;&nbsp;hRC;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cpp__com">//&nbsp;Permanent&nbsp;Rendering&nbsp;Context</span><span class="cpp__keyword">public</span>:&nbsp;<span class="cpp__keyword">static</span>&nbsp;&nbsp;&nbsp;&nbsp;GLfloat&nbsp;&nbsp;&nbsp;&nbsp;rtri;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cpp__com">//&nbsp;Angle&nbsp;For&nbsp;The&nbsp;Triangle&nbsp;(&nbsp;NEW&nbsp;)</span><span class="cpp__keyword">public</span>:&nbsp;&nbsp;&nbsp;&nbsp;<span class="cpp__keyword">static</span>&nbsp;GLfloat&nbsp;&nbsp;&nbsp;&nbsp;rquad;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cpp__com">//&nbsp;Angle&nbsp;For&nbsp;The&nbsp;Quad&nbsp;(&nbsp;NEW&nbsp;)</span><span class="cpp__keyword">public</span>:&nbsp;<span class="cpp__keyword">static</span>&nbsp;CountS&nbsp;*pCountSS;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cpp__keyword">public</span>:&nbsp;<span class="cpp__keyword">static</span><span class="cpp__datatype">double</span>&nbsp;gdAngleX,gdAngleY,gdTransX,gdTransY,gdTransZ;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cpp__keyword">private</span>:&nbsp;&nbsp;<span class="cpp__datatype">double</span>&nbsp;&nbsp;&nbsp;&nbsp;giX,&nbsp;giY,&nbsp;m_dx,m_dy;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cpp__keyword">public</span>:&nbsp;<span class="cpp__keyword">static</span><span class="cpp__datatype">int</span>&nbsp;keys;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cpp__keyword">public</span>:&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Form1(<span class="cpp__keyword">void</span>)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;InitializeComponent();&nbsp;
&nbsp;
&nbsp;
&hellip;&nbsp;
<span class="cpp__keyword">class</span>&nbsp;CountS{&nbsp;
<span class="cpp__keyword">public</span>:&nbsp;
&nbsp;
&nbsp;&nbsp;
<span class="cpp__keyword">struct</span>&nbsp;Vertex&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cpp__datatype">int</span>&nbsp;m_boneID;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cpp__com">//&nbsp;for&nbsp;skeletal&nbsp;animation</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;dfx::vector&lt;&gt;&nbsp;m_location;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cpp__datatype">float</span>&nbsp;m_location1[<span class="cpp__number">3</span>];&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;};&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
&nbsp;
&nbsp;
<span class="cpp__keyword">struct</span>&nbsp;Triangle&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cpp__datatype">float</span>&nbsp;m_vertexNormals[<span class="cpp__number">3</span>][<span class="cpp__number">3</span>];<span class="cpp__com">//&nbsp;Normals&nbsp;to&nbsp;each&nbsp;of&nbsp;vertex&nbsp;of&nbsp;a&nbsp;triangle&nbsp;</span><span class="cpp__datatype">float</span>&nbsp;m_s[<span class="cpp__number">3</span>],&nbsp;m_t[<span class="cpp__number">3</span>];<span class="cpp__com">//&nbsp;Textural&nbsp;coordinates&nbsp;for&nbsp;a&nbsp;triangle</span><span class="cpp__datatype">int</span>&nbsp;m_vertexIndices[<span class="cpp__number">3</span>];<span class="cpp__com">//3&nbsp;tops&nbsp;make&nbsp;a&nbsp;triangle&nbsp;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;};&nbsp;
</pre>
</div>
</div>
</div>
<p></p>
<p>You can see it in more detail.</p>
<p>&nbsp;</p>
<p>Consider the model itself. It is a set of standard set of vertices, texture, and above all skeletal animation.</p>
<p>&nbsp;</p>
<p>Sample 1. Reload(number key 2-4).</p>
<p><img id="141717" src="141717-reload.jpg" alt="" width="707" height="512"></p>
<p>Sample 1. Shot(number key 5-7).</p>
<p><img id="141718" src="141718-shot.jpg" alt="" width="638" height="393"></p>
<p>&nbsp;</p>
<p>To move and zoom model use a mouse.</p>
<p>It is important to note that we use for turns quaternion. This allows for smoother animation model.</p>
<p></p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>C&#43;&#43;</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Из&#1084;енение сценария</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">cplusplus</span>

<div class="preview">
<pre class="cplusplus">quaternion(&nbsp;<span class="cpp__keyword">const</span>&nbsp;dfx::vector&lt;&nbsp;T&nbsp;&gt;&nbsp;&amp;axis,&nbsp;T&nbsp;angle&nbsp;)&nbsp;{<span class="cpp__com">//&nbsp;quaternion</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;T&nbsp;scale&nbsp;=&nbsp;(&nbsp;T&nbsp;)sin(&nbsp;angle&nbsp;/&nbsp;T(<span class="cpp__number">2</span>)&nbsp;);&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;w&nbsp;=&nbsp;(&nbsp;T&nbsp;)cos(&nbsp;angle&nbsp;/&nbsp;T(<span class="cpp__number">2</span>)&nbsp;);&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;x&nbsp;=&nbsp;axis.x&nbsp;*&nbsp;scale;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;y&nbsp;=&nbsp;axis.y&nbsp;*&nbsp;scale;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;z&nbsp;=&nbsp;axis.z&nbsp;*&nbsp;scale;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cpp__keyword">friend</span>&nbsp;quaternion&nbsp;operator*(&nbsp;<span class="cpp__keyword">const</span>&nbsp;quaternion&nbsp;&amp;a,&nbsp;<span class="cpp__keyword">const</span>&nbsp;quaternion&nbsp;&amp;b&nbsp;)&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cpp__keyword">const</span>&nbsp;T&nbsp;Qx&nbsp;=&nbsp;a.w&nbsp;*&nbsp;b.x&nbsp;&#43;&nbsp;a.x&nbsp;*&nbsp;b.w&nbsp;&#43;&nbsp;a.y&nbsp;*&nbsp;b.z&nbsp;-&nbsp;a.z&nbsp;*&nbsp;b.y;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cpp__keyword">const</span>&nbsp;T&nbsp;Qy&nbsp;=&nbsp;a.w&nbsp;*&nbsp;b.y&nbsp;-&nbsp;a.x&nbsp;*&nbsp;b.z&nbsp;&#43;&nbsp;a.y&nbsp;*&nbsp;b.w&nbsp;&#43;&nbsp;a.z&nbsp;*&nbsp;b.x;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cpp__keyword">const</span>&nbsp;T&nbsp;Qz&nbsp;=&nbsp;a.w&nbsp;*&nbsp;b.z&nbsp;&#43;&nbsp;a.x&nbsp;*&nbsp;b.y&nbsp;-&nbsp;a.y&nbsp;*&nbsp;b.x&nbsp;&#43;&nbsp;a.z&nbsp;*&nbsp;b.w;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cpp__keyword">const</span>&nbsp;T&nbsp;Qw&nbsp;=&nbsp;a.w&nbsp;*&nbsp;b.w&nbsp;-&nbsp;a.x&nbsp;*&nbsp;b.x&nbsp;-&nbsp;a.y&nbsp;*&nbsp;b.y&nbsp;-&nbsp;a.z&nbsp;*&nbsp;b.z;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cpp__keyword">return</span>&nbsp;quaternion(&nbsp;Qw,&nbsp;Qx,&nbsp;Qy,&nbsp;Qz&nbsp;);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
</pre>
</div>
</div>
</div>
<p></p>
<p>You managed to use a model from Valve! But you can do better!</p>
<p>Good luck.</p>
<p>&nbsp;</p>
<h1>More Information</h1>
<p><em><span id="result_box" lang="en"><span class="hps">3D</span> <span class="hps">
model can be used</span> <span class="hps">only for training</span><span>.</span>
<span class="hps">Commercial use</span> <span class="hps">is prohibited.</span></span></em></p>
