# 3D Modeling using GDI+
## Requires
- Visual Studio 2010
## License
- MS-LPL
## Technologies
- C#
## Topics
- 3D Graphics
## Updated
- 03/30/2014
## Description

<h1>Introduction</h1>
<p><em>Most of us use OpenGL/ DirectX&nbsp; based program to meet our 3d requirement. Also we need not to reinvent the wheel as most of the methods / capabilities established by these libraries are well tested and confirmed. However these tools does not help&nbsp;&nbsp;a&nbsp;
 learner&nbsp; to understand how 3d graphics being rendered into 2d screen, because those are controlled by different APIs. This attached samples explains how typical 3d modeling graphics projected into 2d screen.</em></p>
<h1><span>Building the Sample</span></h1>
<p><em>This sample project created using Visual studio 2010 and <em>targeted </em>
dot net framework 4.0</em></p>
<p><span style="font-size:20px; font-weight:bold">Description</span></p>
<p><em>This sample contains 3 different parts.</em></p>
<p><em>1. VecrorLib</em></p>
<p><em>Contains Vector2D, Vector3D, Point2D, Point 3D classes which are required for any 3d modeling</em></p>
<p><em>Matrix3D, Quaternion(under development) class to do transformation such as Translation, scaling, rotation, shear, projection etc</em></p>
<p><em>2. Renderer</em></p>
<p><em>Contains a camera class and canvas object</em></p>
<p><em>3. Sample Project</em></p>
<p><em>Sample winform screen which uses Renderer and&nbsp;VectorLib to draw sample 3D cube and provides
<em>rotational </em>transformation of the camera and UI to position the Coordinate axes.</em></p>
<p><em><img id="111424" src="111424-sample1.png" alt="" width="897" height="472"></em></p>
<p>&nbsp;<img id="111425" src="111425-sample3.png" alt="" width="897" height="472"></p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>C#</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">csharp</span>

<div class="preview">
<pre class="csharp">&nbsp;&nbsp;<span class="cs__keyword">public</span>&nbsp;<span class="cs__keyword">void</span>&nbsp;Project(<span class="cs__keyword">double</span>&nbsp;theta=<span class="cs__number">0</span>,&nbsp;<span class="cs__keyword">double</span>&nbsp;phi=<span class="cs__number">0</span>,&nbsp;<span class="cs__keyword">double</span>&nbsp;tx=<span class="cs__number">0</span>,<span class="cs__keyword">double</span>&nbsp;ty=<span class="cs__number">0</span>,&nbsp;<span class="cs__keyword">double</span>&nbsp;tz=<span class="cs__number">0</span>)&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">if</span>&nbsp;(m_upVector&nbsp;==&nbsp;Vector3d.YAxis)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;m_temp.Y&nbsp;=&nbsp;Distance&nbsp;*&nbsp;Math.Sin(Math.PI&nbsp;*&nbsp;(m_cameraPhi&nbsp;&#43;&nbsp;phi)&nbsp;/&nbsp;<span class="cs__number">180</span>);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;m_temp.X&nbsp;=&nbsp;Distance&nbsp;*&nbsp;Math.Cos(Math.PI&nbsp;*&nbsp;(m_cameraTheta&nbsp;&#43;&nbsp;theta)&nbsp;/&nbsp;<span class="cs__number">180</span>)&nbsp;*&nbsp;Math.Cos(Math.PI&nbsp;*&nbsp;(m_cameraPhi&nbsp;&#43;&nbsp;phi)&nbsp;/&nbsp;<span class="cs__number">180</span>);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;m_temp.Z&nbsp;=&nbsp;Distance&nbsp;*&nbsp;Math.Sin(Math.PI&nbsp;*&nbsp;(m_cameraTheta&nbsp;&#43;&nbsp;theta)&nbsp;/&nbsp;<span class="cs__number">180</span>)&nbsp;*&nbsp;Math.Cos(Math.PI&nbsp;*&nbsp;(m_cameraPhi&nbsp;&#43;&nbsp;phi)&nbsp;/&nbsp;<span class="cs__number">180</span>);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">else</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;m_temp.Z&nbsp;=&nbsp;Distance&nbsp;*&nbsp;Math.Sin(Math.PI&nbsp;*&nbsp;(m_cameraPhi&nbsp;&#43;&nbsp;phi)&nbsp;/&nbsp;<span class="cs__number">180</span>);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;m_temp.X&nbsp;=&nbsp;Distance&nbsp;*&nbsp;Math.Cos(Math.PI&nbsp;*&nbsp;(m_cameraTheta&nbsp;&#43;&nbsp;theta)&nbsp;/&nbsp;<span class="cs__number">180</span>)&nbsp;*&nbsp;Math.Cos(Math.PI&nbsp;*&nbsp;(m_cameraPhi&nbsp;&#43;&nbsp;phi)&nbsp;/&nbsp;<span class="cs__number">180</span>);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;m_temp.Y&nbsp;=&nbsp;Distance&nbsp;*&nbsp;Math.Sin(Math.PI&nbsp;*&nbsp;(m_cameraTheta&nbsp;&#43;&nbsp;theta)&nbsp;/&nbsp;<span class="cs__number">180</span>)&nbsp;*&nbsp;Math.Cos(Math.PI&nbsp;*&nbsp;(m_cameraPhi&nbsp;&#43;&nbsp;phi)&nbsp;/&nbsp;<span class="cs__number">180</span>);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">double</span>&nbsp;_sin1,&nbsp;_cos1,&nbsp;_sin2,&nbsp;_cos2,&nbsp;_sin3,&nbsp;_cos3;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">double</span>&nbsp;_d1,_d2,_d3;&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Matrix3d&nbsp;_m1&nbsp;=&nbsp;Matrix3d.IdentityMatrix();&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;_m1.Translate(-(m_temp.X),&nbsp;-(m_temp.Y),&nbsp;-(m_temp.Z));&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Point3d&nbsp;_dist&nbsp;=&nbsp;m_temp-TargetPoint;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;_d2&nbsp;=&nbsp;m_temp.DistanceTo(TargetPoint);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;_d1&nbsp;=&nbsp;Math.Sqrt((_dist.X&nbsp;*&nbsp;_dist.X)&nbsp;&#43;&nbsp;(_dist.Z&nbsp;*&nbsp;_dist.Z));&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__com">//&nbsp;X&nbsp;Axis&nbsp;rotation</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Matrix3d&nbsp;_m2&nbsp;=&nbsp;Matrix3d.IdentityMatrix();&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">if</span>&nbsp;(_d1&nbsp;!=&nbsp;<span class="cs__number">0.0</span>)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;_sin1&nbsp;=&nbsp;-_dist.X&nbsp;/&nbsp;_d1;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;_cos1&nbsp;=&nbsp;_dist.Z&nbsp;/&nbsp;_d1;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;_m2.Matrix[<span class="cs__number">0</span>,&nbsp;<span class="cs__number">0</span>]&nbsp;=&nbsp;_cos1;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;_m2.Matrix[<span class="cs__number">0</span>,&nbsp;<span class="cs__number">2</span>]&nbsp;=&nbsp;-_sin1;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;_m2.Matrix[<span class="cs__number">2</span>,&nbsp;<span class="cs__number">0</span>]&nbsp;=&nbsp;_sin1;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;_m2.Matrix[<span class="cs__number">2</span>,&nbsp;<span class="cs__number">2</span>]&nbsp;=&nbsp;_cos1;&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__com">//&nbsp;Y&nbsp;Axis&nbsp;rotation</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;_d2&nbsp;=&nbsp;Math.Sqrt((_dist.X&nbsp;*&nbsp;_dist.X)&nbsp;&#43;&nbsp;(_dist.Y&nbsp;*&nbsp;_dist.Y)&nbsp;&#43;&nbsp;(_dist.Z&nbsp;*&nbsp;_dist.Z));&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Matrix3d&nbsp;_m3&nbsp;=&nbsp;Matrix3d.IdentityMatrix();&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">if</span>&nbsp;(_d2&nbsp;!=&nbsp;<span class="cs__number">0.0</span>)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;_sin2&nbsp;=&nbsp;_dist.Y&nbsp;/&nbsp;_d2;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;_cos2&nbsp;=&nbsp;_d1&nbsp;/&nbsp;_d2;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;_m3.Matrix[<span class="cs__number">1</span>,<span class="cs__number">1</span>]&nbsp;=&nbsp;_cos2;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;_m3.Matrix[<span class="cs__number">1</span>,&nbsp;<span class="cs__number">2</span>]&nbsp;=&nbsp;_sin2;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;_m3.Matrix[<span class="cs__number">2</span>,&nbsp;<span class="cs__number">1</span>]&nbsp;=&nbsp;-_sin2;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;_m3.Matrix[<span class="cs__number">2</span>,&nbsp;<span class="cs__number">2</span>]&nbsp;=&nbsp;_cos2;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">double</span>[]&nbsp;_up2=&nbsp;_m2.ApplyTransform(m_upVector.X,&nbsp;UpVector.Y,&nbsp;UpVector.Z,&nbsp;<span class="cs__number">1</span>);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">double</span>[]&nbsp;_up1=_m3.ApplyTransform(_up2[<span class="cs__number">0</span>],&nbsp;_up2[<span class="cs__number">1</span>],&nbsp;_up2[<span class="cs__number">2</span>],&nbsp;_up2[<span class="cs__number">3</span>]);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__com">//&nbsp;Z&nbsp;Axis&nbsp;Rotation</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;_d3&nbsp;=&nbsp;Math.Sqrt((_up1[<span class="cs__number">0</span>]&nbsp;*&nbsp;_up1[<span class="cs__number">0</span>])&nbsp;&#43;&nbsp;(_up1[<span class="cs__number">1</span>]&nbsp;*&nbsp;_up1[<span class="cs__number">1</span>]));&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Matrix3d&nbsp;_m4&nbsp;=&nbsp;Matrix3d.IdentityMatrix();&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">if</span>&nbsp;(_d3&nbsp;!=&nbsp;<span class="cs__number">0.0</span>)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;_sin3&nbsp;=&nbsp;_up1[<span class="cs__number">0</span>]&nbsp;/&nbsp;_d3;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;_cos3&nbsp;=&nbsp;_up1[<span class="cs__number">1</span>]&nbsp;/&nbsp;_d3;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;_m4.Matrix[<span class="cs__number">0</span>,&nbsp;<span class="cs__number">0</span>]&nbsp;=&nbsp;_cos3;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;_m4.Matrix[<span class="cs__number">0</span>,&nbsp;<span class="cs__number">1</span>]&nbsp;=&nbsp;_sin3;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;_m4.Matrix[<span class="cs__number">1</span>,&nbsp;<span class="cs__number">0</span>]&nbsp;=-_sin3;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;_m4.Matrix[<span class="cs__number">1</span>,&nbsp;<span class="cs__number">1</span>]&nbsp;=&nbsp;_cos3;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Matrix3d&nbsp;_m5=Matrix3d.IdentityMatrix();&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">if</span>&nbsp;(ProjectType&nbsp;==&nbsp;ProjectionTypes.Perspective&nbsp;&amp;&amp;&nbsp;_d2&nbsp;!=&nbsp;<span class="cs__number">0.0</span>)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;_m5.Matrix[<span class="cs__number">2</span>,&nbsp;<span class="cs__number">3</span>]&nbsp;=&nbsp;-<span class="cs__number">1</span>&nbsp;/&nbsp;_d2;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">else</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;_m5&nbsp;=&nbsp;Matrix3d.IdentityMatrix();&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Matrix3d&nbsp;_a=&nbsp;Matrix3d.MatrixMultiply3D(_m1,&nbsp;_m2);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Matrix3d&nbsp;_b&nbsp;=Matrix3d.MatrixMultiply3D(_m3,&nbsp;_m4);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Matrix3d&nbsp;_res&nbsp;=&nbsp;Matrix3d.MatrixMultiply3D(_a,&nbsp;_b);&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__com">//&nbsp;Still&nbsp;in&nbsp;progress&nbsp;code</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">if</span>&nbsp;(m_viewType&nbsp;==&nbsp;ViewTypes.Front)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Matrix3d&nbsp;m_view&nbsp;=&nbsp;Matrix3d.IdentityMatrix();&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;m_view.Matrix[<span class="cs__number">2</span>,&nbsp;<span class="cs__number">2</span>]&nbsp;=&nbsp;<span class="cs__number">0</span>;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;ProjectedMatrix&nbsp;=&nbsp;m_view;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">else</span>&nbsp;<span class="cs__keyword">if</span>&nbsp;(m_viewType&nbsp;==&nbsp;ViewTypes.Top)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Matrix3d&nbsp;m_view&nbsp;=&nbsp;Matrix3d.IdentityMatrix();&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;m_view.Matrix[<span class="cs__number">1</span>,&nbsp;<span class="cs__number">1</span>]&nbsp;=&nbsp;<span class="cs__number">0</span>;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;m_view.Matrix[<span class="cs__number">2</span>,&nbsp;<span class="cs__number">1</span>]&nbsp;=&nbsp;-<span class="cs__number">1</span>;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;m_view.Matrix[<span class="cs__number">2</span>,&nbsp;<span class="cs__number">2</span>]&nbsp;=&nbsp;<span class="cs__number">0</span>;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;ProjectedMatrix&nbsp;=&nbsp;m_view;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">else</span>&nbsp;<span class="cs__keyword">if</span>&nbsp;(m_viewType&nbsp;==&nbsp;ViewTypes.Left)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Matrix3d&nbsp;m_view&nbsp;=&nbsp;Matrix3d.IdentityMatrix();&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;m_view.Matrix[<span class="cs__number">0</span>,&nbsp;<span class="cs__number">0</span>]&nbsp;=&nbsp;<span class="cs__number">0</span>;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;m_view.Matrix[<span class="cs__number">2</span>,&nbsp;<span class="cs__number">0</span>]&nbsp;=&nbsp;-<span class="cs__number">1</span>;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;m_view.Matrix[<span class="cs__number">2</span>,&nbsp;<span class="cs__number">2</span>]&nbsp;=&nbsp;<span class="cs__number">0</span>;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;ProjectedMatrix&nbsp;=&nbsp;m_view;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">else</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;ProjectedMatrix&nbsp;=&nbsp;Matrix3d.MatrixMultiply3D(_res,&nbsp;_m5);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;}</pre>
</div>
</div>
</div>
<p>This sample currently provides support to render wireframe modeling and rotational transformation to support orthographic, perspective projections. Later it will be extended to support Quaternion based camera rotations and translations. which will include
 hidden line removal and depth buffer algorithms lighting concepts.</p>
<p>&nbsp;</p>
<p><img id="111426" src="111426-sample2.png" alt=""></p>
