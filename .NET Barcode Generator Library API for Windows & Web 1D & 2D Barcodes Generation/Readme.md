# .NET Barcode Generator Library API for Windows & Web 1D & 2D Barcodes Generation
## Requires
- Visual Studio 2010
## License
- Apache License, Version 2.0
## Technologies
- Controls
- C#
- ASP.NET
- Visual Studio 2008
- Class Library
- Windows Forms
- Visual Studio 2010
- Console Application
- .NET Framework
- Visual Basic .NET
- ASP.NET Web Forms
- Visual Basic.NET
- Console
- VB.Net
- Library
- WinForms
- Visual C#
- Visual Studio 2012
- .NET Development
- c# control
- Visual Studio 2015
- Visual C#.NET
- Visual Studio 2017
## Topics
- Generate Barcode
- Create Barcode
- Encode Barcode
- Barcode
## Updated
- 03/06/2019
## Description

<h1 style="text-align:justify">.NET Barcode Generator for C#/VB.NET Web &amp; Windows Applications</h1>
<p class="p" style="text-align:justify">CnetSDK .NET Barcode Generator Library API for .NET barcodes creation&nbsp;&amp; barcodes generation in C# &amp; VB.NET windows and ASP.NET web applications development.</p>
<p class="p" style="text-align:justify">&nbsp;</p>
<h2 class="p" style="text-align:justify"><strong>CnetSDK .NET Barcode </strong>
<strong>Generator</strong><strong>&nbsp;Library </strong><strong>Overview</strong></h2>
<p style="text-align:justify">CnetSDK .NET Barcode Generator SDK can encode, create, and generate most popular 1d and 2d barcodes for .NET application development. It is a professional and flexible .NET library dll that creates and generate all popular bar
 code formats in your .NET Framework-based applications, like ASP.NET web application, .NET Windows Forms applicaiton, .NET Class Library, Console Application, etc. This barcode generator library&nbsp;supports most commonly used barcode symbologies (linear
 and 2D barcodes) and has proven its reliability&nbsp;among customers&nbsp;throughout the world.</p>
<ul style="text-align:justify">
<li>Generate 2D&nbsp;Barcodes&nbsp;in .NET Windows &amp; ASP.NET Web Applications
</li></ul>
<p style="text-align:justify">Generate the most popular matrix/2d&nbsp;barcodes, including
<strong><a title="Generate QR Code in .NET Applications" href="http://www.cnetsdk.com/net-barcode-generator-sdk-create-qrcode-2d-barcode" target="_blank">QR Code</a></strong><strong>, PDF417, Data Matrix, and Aztec Code</strong></p>
<ul style="text-align:justify">
<li>Generate 1D Barcodes&nbsp;in .NET Windows &amp; ASP.NET Web Applications </li></ul>
<p style="text-align:justify">Generate the most popular linear/1d&nbsp;barcodes, including<strong>&nbsp;</strong><strong>Code 39, Code 128, EAN-8, EAN-13,
</strong><strong>and </strong><strong>UPC-A</strong></p>
<ul style="text-align:justify">
<li>Save&nbsp;Barcode&nbsp;as Raster Image Formats </li></ul>
<p style="text-align:justify">Create barcode and save it to raster image files,&nbsp;like JPG, JPEG, TIFF, PNG, BMP, and GIF&nbsp;formats</p>
<ul style="text-align:justify">
<li>Save&nbsp;Barcode&nbsp;into Other Forms </li></ul>
<p style="text-align:justify">Generate&nbsp;barcode to a byte array, stream object or bitmap object in .NET web and windows applications</p>
<h2 class="p" style="text-align:justify"><strong><br>
</strong></h2>
<h2 class="p" style="text-align:justify"><strong>CnetSDK .NET Barcode </strong>
<strong>Generator </strong><strong>Library </strong><strong>Usage</strong><strong>&nbsp;</strong></h2>
<p style="text-align:justify"><a title="CnetSDK .NET Barcode Generator SDK" href="http://www.cnetsdk.com/net-barcode-generator-sdk" target="_blank"><strong>CnetSDK
</strong><strong>.NET Barcode </strong><strong>Generator </strong><strong>Library</strong></a>&nbsp;is compatible with Microsoft Windows System, 32 or 64 bit, Visual Studio 2005 or above, and .NET Framework 2.0 or above.&nbsp;By simply adding project reference,
 you can integrate barcode generator library dll into your C#/VB web and windows applications. We provide a demo project in the free trail package. Now, directly
<a title="Download Free Trial to Test" href="https://storage.googleapis.com/wzukusers/user-29892693/documents/5add58b5d1800Hq9BkLU/CnetSDK.Barcode.Generator.Trial.zip" target="_blank">
download CnetSDK .NET Barcode Generator SDK free trial</a>&nbsp;to have a test.</p>
<p class="p" style="text-align:justify">The following two pieces of C# codes are simple examples to illustrates how to use CnetSDK .NET Barcode Generator SDK for ASP.NET web and .NET Windows Forms application. You may use our barcode generator library dll
 for advanced .NET applications development. For full usage of our .NET Barcode Generator SDK, you may refer to the following online tutorials.</p>
<ul>
<li><strong><a title="ASP.NET Barcode Generation Guide" href="http://www.cnetsdk.com/aspnet-barcode-generator" target="_blank">Generate barcode in ASP.NET using C#</a></strong>
</li><li><strong><a title=".NET WinForms Barcode Generation Guide" href="http://www.cnetsdk.com/net-windows-forms-barcode-generator" target="_blank">Generate barcode in C# windows application</a></strong>
</li></ul>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>C#</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">编辑脚本</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">csharp</span>
<pre class="hidden">namespace ASPNETWebBarcodeGeneratorExample
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            CSBarcode Code128 = new CSBarcode();
            Code128.BarcodeData = &quot;www.cnetsdk.com&quot;;
            Code128.BarcodeType = CSBarcodeType.Code128;
            Code128.BarcodeWidth = 200;
            Code128.BarcodeHeight = 100;
            Code128.CreateBarcode(&quot;Code128barcode.jpg&quot;);
        }
    }
}



namespace NETWinFormsBarcodeGenerateExample
{
    public partial classForm1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            CSBarcode QRcode = new CSBarcode();
            QRcode.BarcodeData = &quot;www.cnetsdk.com&quot;;
            QRcode.BarcodeType = CSBarcodeType.QRCode;
            QRcode.BarcodeWidth = 200;
            QRcode.BarcodeHeight = 200;
            QRcode.CreateBarcode(&quot;QRcodebarcode.jpg&quot;);
        }
    }
}  
</pre>
<div class="preview">
<pre class="csharp"><span class="cs__keyword">namespace</span>&nbsp;ASPNETWebBarcodeGeneratorExample&nbsp;
{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">public</span>&nbsp;partial&nbsp;<span class="cs__keyword">class</span>&nbsp;WebForm1&nbsp;:&nbsp;System.Web.UI.Page&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">protected</span>&nbsp;<span class="cs__keyword">void</span>&nbsp;Page_Load(<span class="cs__keyword">object</span>&nbsp;sender,&nbsp;EventArgs&nbsp;e)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;CSBarcode&nbsp;Code128&nbsp;=&nbsp;<span class="cs__keyword">new</span>&nbsp;CSBarcode();&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Code128.BarcodeData&nbsp;=&nbsp;<span class="cs__string">&quot;www.cnetsdk.com&quot;</span>;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Code128.BarcodeType&nbsp;=&nbsp;CSBarcodeType.Code128;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Code128.BarcodeWidth&nbsp;=&nbsp;<span class="cs__number">200</span>;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Code128.BarcodeHeight&nbsp;=&nbsp;<span class="cs__number">100</span>;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Code128.CreateBarcode(<span class="cs__string">&quot;Code128barcode.jpg&quot;</span>);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
}&nbsp;
&nbsp;
&nbsp;
&nbsp;
<span class="cs__keyword">namespace</span>&nbsp;NETWinFormsBarcodeGenerateExample&nbsp;
{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">public</span>&nbsp;partial&nbsp;classForm1&nbsp;:&nbsp;Form&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">public</span>&nbsp;Form1()&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;InitializeComponent();&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;CSBarcode&nbsp;QRcode&nbsp;=&nbsp;<span class="cs__keyword">new</span>&nbsp;CSBarcode();&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;QRcode.BarcodeData&nbsp;=&nbsp;<span class="cs__string">&quot;www.cnetsdk.com&quot;</span>;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;QRcode.BarcodeType&nbsp;=&nbsp;CSBarcodeType.QRCode;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;QRcode.BarcodeWidth&nbsp;=&nbsp;<span class="cs__number">200</span>;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;QRcode.BarcodeHeight&nbsp;=&nbsp;<span class="cs__number">200</span>;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;QRcode.CreateBarcode(<span class="cs__string">&quot;QRcodebarcode.jpg&quot;</span>);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
}&nbsp;&nbsp;&nbsp;
</pre>
</div>
</div>
</div>
<h2><strong>Get</strong><strong>&nbsp;More </strong><strong>Details </strong><strong>on CnetSDK.com</strong><strong>&nbsp;</strong></h2>
<p class="p">You may also get more details about CnetSDK .NET Barcode Generator SDK on
<a title="Welcome to CnetSDK.com" href="http://www.cnetsdk.com/" target="_blank">
CnetSDK.com</a>. Or&nbsp;<span>you can directly get the details and download the free trial package from the following pages.</span></p>
<ul>
<li><a title="C# Barcode Generation Examples" href="http://www.cnetsdk.com/net-barcode-generator-csharp-sample-code" target="_blank"><strong>C#</strong>&nbsp;Generate Barcode for .NET Applications</a>
</li><li><a title="VB.NET Barcode Generation Examples" href="http://www.cnetsdk.com/net-barcode-generator-vb-sample-code" target="_blank"><strong>VB</strong>&nbsp;Generate Barcode for .NET Applications</a>
</li></ul>
<p>Support Email: <a title="CnetSDK Support Team" href="mailto:support@cnetsdk.com">
<span style="text-decoration:underline">support@cnetsdk.com</span></a>.</p>
