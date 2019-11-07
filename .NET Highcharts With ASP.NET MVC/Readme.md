# .NET Highcharts With ASP.NET MVC
## Requires
- Visual Studio 2015
## License
- MIT
## Technologies
- ASP.NET MVC 4
- HighCharts
## Topics
- Charts
- Client Side Rendering
## Updated
- 10/23/2017
## Description

<h1>Introduction</h1>
<p><em><span>Highcharts is a JavaScript library to implement charting functionality like a line chart, bar chart, column chart etc. We can create different types of charts using Highcharts. Today, with this article, I will try to show you how to create Highcharts
 in ASP.NET MVC from the server side. Here, server-side means that everything will be created on the server and only the displaying part will happen at the client side.</span></em></p>
<h1><span>Building the Sample</span></h1>
<p>Just follow the below steps to complete this demonstration.</p>
<p><strong>STEP 1 Create a project in ASP.NET MVC</strong></p>
<p>Open Visual Studio 2015 and click on &quot;New Project&quot;. From the &quot;New Project&quot; window, choose web from the Installed Templates and select ASP.NET Web Application. Next, provide a suitable name like &ldquo;HighchartsWithMVC&rdquo;, choose location, and click
 OK.</p>
<p>Next, the Windows will ask to select project template, so we just need to select MVC and change authentication as &ldquo;No Authentication&rdquo; and click the OK button. It will take a few seconds to create the application.</p>
<p>Now, our ASP.NET MVC application is ready.</p>
<p><strong>STEP 2 Install .NET Highcharts</strong></p>
<p>To install DotNet.Highcharts in your application, just right click your project from Solution Explorer and choose &quot;Manage NuGet Packages&quot;. It will open the NuGet Package Manager from where we can search the required packages. Search for &ldquo;Dotnet.Highcharts&rdquo;
 from the search textbox as following and install it with the latest version.</p>
<p><img id="181178" src="181178-nuget_dotnet_highcharts.jpg" alt="" width="922" height="309"></p>
<p>&nbsp;</p>
<p>&nbsp;</p>
<p><strong>STEP 3 Create Highcharts</strong></p>
<p>Now, it is time to create a chart using Highcharts. Therefore, for this demonstration, I will create a column chart that shows the comparison of runs made in respective years by Sachin and Dhoni. This example is only for explaining.</p>
<p>First, I'm going to create a chart to initialize with basic configuration, such as the type of chart, background color, border etc., and provide a suitable name for it.</p>
<p></p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>C#</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">csharp</span>
<pre class="hidden">using DotNet.Highcharts;  
using DotNet.Highcharts.Enums;  
using DotNet.Highcharts.Helpers;  
using DotNet.Highcharts.Options;  
using System;  
using System.Collections.Generic;  
using System.Drawing;  
using System.Linq;  
using System.Web;  
using System.Web.Mvc;  
  
namespace HighchartsWithMVC.Controllers  
{  
    public class HomeController : Controller  
    {  
        public ActionResult Index()  
        {  
            Highcharts columnChart = new Highcharts(&quot;columnchart&quot;);  
  
            columnChart.InitChart(new Chart()  
            {  
                Type = DotNet.Highcharts.Enums.ChartTypes.Column,  
                BackgroundColor = new BackColorOrGradient(System.Drawing.Color.AliceBlue),  
                Style = &quot;fontWeight: 'bold', fontSize: '17px'&quot;,  
                BorderColor = System.Drawing.Color.LightBlue,  
                BorderRadius = 0,  
                BorderWidth = 2  
  
            });  
  
            columnChart.SetTitle(new Title()  
            {  
                Text = &quot;Sachin Vs Dhoni&quot;  
            });  
  
            columnChart.SetSubtitle(new Subtitle()  
            {  
                Text = &quot;Played 9 Years Together From 2004 To 2012&quot;  
            });  
  
            columnChart.SetXAxis(new XAxis()  
            {  
                Type = AxisTypes.Category,  
                Title = new XAxisTitle() { Text = &quot;Years&quot;, Style = &quot;fontWeight: 'bold', fontSize: '17px'&quot; },  
                Categories = new[] { &quot;2004&quot;, &quot;2005&quot;, &quot;2006&quot;, &quot;2007&quot;, &quot;2008&quot;, &quot;2009&quot;, &quot;2010&quot;, &quot;2011&quot;, &quot;2012&quot; }  
            });  
  
            columnChart.SetYAxis(new YAxis()  
            {  
                Title = new YAxisTitle()  
                {  
                    Text = &quot;Runs&quot;,  
                    Style = &quot;fontWeight: 'bold', fontSize: '17px'&quot;  
                },  
                ShowFirstLabel = true,  
                ShowLastLabel = true,  
                Min = 0  
            });  
  
            columnChart.SetLegend(new Legend  
            {  
                Enabled = true,  
                BorderColor = System.Drawing.Color.CornflowerBlue,  
                BorderRadius = 6,  
                BackgroundColor = new BackColorOrGradient(ColorTranslator.FromHtml(&quot;#FFADD8E6&quot;))  
            });  
  
            columnChart.SetSeries(new Series[]  
            {  
                new Series{  
  
                    Name = &quot;Sachin Tendulkar&quot;,  
                    Data = new Data(new object[] { 812, 412, 628, 1425, 460, 972, 204, 513, 315 })  
                },  
                new Series()  
                {  
                    Name = &quot;M S Dhoni&quot;,  
                    Data = new Data(new object[] { 19, 895, 821, 1103, 1097, 1198, 600, 764, 524, })  
                }  
            }  
            );  
  
            return View(columnChart);  
        }  
}  </pre>
<div class="preview">
<pre class="js">using&nbsp;DotNet.Highcharts;&nbsp;&nbsp;&nbsp;
using&nbsp;DotNet.Highcharts.Enums;&nbsp;&nbsp;&nbsp;
using&nbsp;DotNet.Highcharts.Helpers;&nbsp;&nbsp;&nbsp;
using&nbsp;DotNet.Highcharts.Options;&nbsp;&nbsp;&nbsp;
using&nbsp;System;&nbsp;&nbsp;&nbsp;
using&nbsp;System.Collections.Generic;&nbsp;&nbsp;&nbsp;
using&nbsp;System.Drawing;&nbsp;&nbsp;&nbsp;
using&nbsp;System.Linq;&nbsp;&nbsp;&nbsp;
using&nbsp;System.Web;&nbsp;&nbsp;&nbsp;
using&nbsp;System.Web.Mvc;&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;
namespace&nbsp;HighchartsWithMVC.Controllers&nbsp;&nbsp;&nbsp;
<span class="js__brace">{</span>&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;public&nbsp;class&nbsp;HomeController&nbsp;:&nbsp;Controller&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">{</span>&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;public&nbsp;ActionResult&nbsp;Index()&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">{</span>&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Highcharts&nbsp;columnChart&nbsp;=&nbsp;<span class="js__operator">new</span>&nbsp;Highcharts(<span class="js__string">&quot;columnchart&quot;</span>);&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;columnChart.InitChart(<span class="js__operator">new</span>&nbsp;Chart()&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">{</span>&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Type&nbsp;=&nbsp;DotNet.Highcharts.Enums.ChartTypes.Column,&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;BackgroundColor&nbsp;=&nbsp;<span class="js__operator">new</span>&nbsp;BackColorOrGradient(System.Drawing.Color.AliceBlue),&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Style&nbsp;=&nbsp;<span class="js__string">&quot;fontWeight:&nbsp;'bold',&nbsp;fontSize:&nbsp;'17px'&quot;</span>,&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;BorderColor&nbsp;=&nbsp;System.Drawing.Color.LightBlue,&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;BorderRadius&nbsp;=&nbsp;<span class="js__num">0</span>,&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;BorderWidth&nbsp;=&nbsp;<span class="js__num">2</span><span class="js__brace">}</span>);&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;columnChart.SetTitle(<span class="js__operator">new</span>&nbsp;Title()&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">{</span>&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Text&nbsp;=&nbsp;<span class="js__string">&quot;Sachin&nbsp;Vs&nbsp;Dhoni&quot;</span><span class="js__brace">}</span>);&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;columnChart.SetSubtitle(<span class="js__operator">new</span>&nbsp;Subtitle()&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">{</span>&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Text&nbsp;=&nbsp;<span class="js__string">&quot;Played&nbsp;9&nbsp;Years&nbsp;Together&nbsp;From&nbsp;2004&nbsp;To&nbsp;2012&quot;</span><span class="js__brace">}</span>);&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;columnChart.SetXAxis(<span class="js__operator">new</span>&nbsp;XAxis()&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">{</span>&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Type&nbsp;=&nbsp;AxisTypes.Category,&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Title&nbsp;=&nbsp;<span class="js__operator">new</span>&nbsp;XAxisTitle()&nbsp;<span class="js__brace">{</span>&nbsp;Text&nbsp;=&nbsp;<span class="js__string">&quot;Years&quot;</span>,&nbsp;Style&nbsp;=&nbsp;<span class="js__string">&quot;fontWeight:&nbsp;'bold',&nbsp;fontSize:&nbsp;'17px'&quot;</span><span class="js__brace">}</span>,&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Categories&nbsp;=&nbsp;<span class="js__operator">new</span>[]&nbsp;<span class="js__brace">{</span><span class="js__string">&quot;2004&quot;</span>,&nbsp;<span class="js__string">&quot;2005&quot;</span>,&nbsp;<span class="js__string">&quot;2006&quot;</span>,&nbsp;<span class="js__string">&quot;2007&quot;</span>,&nbsp;<span class="js__string">&quot;2008&quot;</span>,&nbsp;<span class="js__string">&quot;2009&quot;</span>,&nbsp;<span class="js__string">&quot;2010&quot;</span>,&nbsp;<span class="js__string">&quot;2011&quot;</span>,&nbsp;<span class="js__string">&quot;2012&quot;</span><span class="js__brace">}</span><span class="js__brace">}</span>);&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;columnChart.SetYAxis(<span class="js__operator">new</span>&nbsp;YAxis()&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">{</span>&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Title&nbsp;=&nbsp;<span class="js__operator">new</span>&nbsp;YAxisTitle()&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">{</span>&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Text&nbsp;=&nbsp;<span class="js__string">&quot;Runs&quot;</span>,&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Style&nbsp;=&nbsp;<span class="js__string">&quot;fontWeight:&nbsp;'bold',&nbsp;fontSize:&nbsp;'17px'&quot;</span><span class="js__brace">}</span>,&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;ShowFirstLabel&nbsp;=&nbsp;true,&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;ShowLastLabel&nbsp;=&nbsp;true,&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Min&nbsp;=&nbsp;<span class="js__num">0</span><span class="js__brace">}</span>);&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;columnChart.SetLegend(<span class="js__operator">new</span>&nbsp;Legend&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">{</span>&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Enabled&nbsp;=&nbsp;true,&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;BorderColor&nbsp;=&nbsp;System.Drawing.Color.CornflowerBlue,&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;BorderRadius&nbsp;=&nbsp;<span class="js__num">6</span>,&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;BackgroundColor&nbsp;=&nbsp;<span class="js__operator">new</span>&nbsp;BackColorOrGradient(ColorTranslator.FromHtml(<span class="js__string">&quot;#FFADD8E6&quot;</span>))&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">}</span>);&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;columnChart.SetSeries(<span class="js__operator">new</span>&nbsp;Series[]&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">{</span><span class="js__operator">new</span>&nbsp;Series<span class="js__brace">{</span>&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Name&nbsp;=&nbsp;<span class="js__string">&quot;Sachin&nbsp;Tendulkar&quot;</span>,&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Data&nbsp;=&nbsp;<span class="js__operator">new</span>&nbsp;Data(<span class="js__operator">new</span>&nbsp;object[]&nbsp;<span class="js__brace">{</span><span class="js__num">812</span>,&nbsp;<span class="js__num">412</span>,&nbsp;<span class="js__num">628</span>,&nbsp;<span class="js__num">1425</span>,&nbsp;<span class="js__num">460</span>,&nbsp;<span class="js__num">972</span>,&nbsp;<span class="js__num">204</span>,&nbsp;<span class="js__num">513</span>,&nbsp;<span class="js__num">315</span><span class="js__brace">}</span>)&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">}</span>,&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__operator">new</span>&nbsp;Series()&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">{</span>&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Name&nbsp;=&nbsp;<span class="js__string">&quot;M&nbsp;S&nbsp;Dhoni&quot;</span>,&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Data&nbsp;=&nbsp;<span class="js__operator">new</span>&nbsp;Data(<span class="js__operator">new</span>&nbsp;object[]&nbsp;<span class="js__brace">{</span><span class="js__num">19</span>,&nbsp;<span class="js__num">895</span>,&nbsp;<span class="js__num">821</span>,&nbsp;<span class="js__num">1103</span>,&nbsp;<span class="js__num">1097</span>,&nbsp;<span class="js__num">1198</span>,&nbsp;<span class="js__num">600</span>,&nbsp;<span class="js__num">764</span>,&nbsp;<span class="js__num">524</span>,&nbsp;<span class="js__brace">}</span>)&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">}</span><span class="js__brace">}</span>&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;);&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__statement">return</span>&nbsp;View(columnChart);&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">}</span><span class="js__brace">}</span></pre>
</div>
</div>
</div>
<p></p>
<p><strong>STEP 4 Rendering Highcharts on UI</strong></p>
<p>Just move to Index.cshtml of home controller and add the following code that will render this column chart on UI.</p>
<p></p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>HTML</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">html</span>
<pre class="hidden">@model DotNet.Highcharts.Highcharts  
  
@{  
    ViewBag.Title = &quot;Highcharts Examples&quot;;  
}  
  
&lt;div class=&quot;jumbotron&quot;&gt;  
    &lt;h3&gt;DotNet Highcharts Example in Asp.Net MVC&lt;/h3&gt;  
    &lt;p&gt;&lt;a href=&quot;http://dotnet.highcharts.com/&quot; class=&quot;btn btn-primary btn-lg&quot;&gt;Learn more &raquo;&lt;/a&gt;&lt;/p&gt;  
&lt;/div&gt;  
  
&lt;div class=&quot;row&quot;&gt;  
    &lt;div&gt;  
  
        &lt;div class=&quot;col-md-12 col-md-6&quot;&gt;  
            @(Model)  
        &lt;/div&gt;  
    &lt;/div&gt;  
&lt;/div&gt; </pre>
<div class="preview">
<pre class="js">@model&nbsp;DotNet.Highcharts.Highcharts&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;
@<span class="js__brace">{</span>&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;ViewBag.Title&nbsp;=&nbsp;<span class="js__string">&quot;Highcharts&nbsp;Examples&quot;</span>;&nbsp;&nbsp;&nbsp;
<span class="js__brace">}</span>&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;
&lt;div&nbsp;class=<span class="js__string">&quot;jumbotron&quot;</span>&gt;&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&lt;h3&gt;DotNet&nbsp;Highcharts&nbsp;Example&nbsp;<span class="js__operator">in</span>&nbsp;Asp.Net&nbsp;MVC&lt;/h3&gt;&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&lt;p&gt;&lt;a&nbsp;href=<span class="js__string">&quot;http://dotnet.highcharts.com/&quot;</span>&nbsp;class=<span class="js__string">&quot;btn&nbsp;btn-primary&nbsp;btn-lg&quot;</span>&gt;Learn&nbsp;more&nbsp;&raquo;&lt;<span class="js__reg_exp">/a&gt;&lt;/</span>p&gt;&nbsp;&nbsp;&nbsp;
&lt;/div&gt;&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;
&lt;div&nbsp;class=<span class="js__string">&quot;row&quot;</span>&gt;&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&lt;div&gt;&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&lt;div&nbsp;class=<span class="js__string">&quot;col-md-12&nbsp;col-md-6&quot;</span>&gt;&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;@(Model)&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&lt;/div&gt;&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&lt;/div&gt;&nbsp;&nbsp;&nbsp;
&lt;/div&gt;&nbsp;</pre>
</div>
</div>
</div>
<p></p>
<p>To render Highchart on client side, it requires Highcharts.js. So, just add the Highchart.js on _Layout.cshtml file as following.</p>
<p><strong>Note</strong>&nbsp;-&nbsp;Please make sure that the jQuery is initialized before body tag otherwise it will throw an error.</p>
<p>&nbsp;</p>
<p></p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>HTML</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">html</span>
<pre class="hidden">&lt;!DOCTYPE html&gt;  
&lt;html&gt;  
&lt;head&gt;  
    &lt;meta charset=&quot;utf-8&quot; /&gt;  
    &lt;meta name=&quot;viewport&quot; content=&quot;width=device-width, initial-scale=1.0&quot;&gt;  
    &lt;title&gt;@ViewBag.Title - My ASP.NET Application&lt;/title&gt;  
    @Styles.Render(&quot;~/Content/css&quot;)  
    @Scripts.Render(&quot;~/bundles/modernizr&quot;)  
    @Scripts.Render(&quot;~/bundles/jquery&quot;)  
&lt;/head&gt;  
&lt;body&gt;  
    &lt;div class=&quot;navbar navbar-inverse navbar-fixed-top&quot;&gt;  
        &lt;div class=&quot;container&quot;&gt;  
            &lt;div class=&quot;navbar-header&quot;&gt;  
                &lt;button type=&quot;button&quot; class=&quot;navbar-toggle&quot; data-toggle=&quot;collapse&quot; data-target=&quot;.navbar-collapse&quot;&gt;  
                    &lt;span class=&quot;icon-bar&quot;&gt;&lt;/span&gt;  
                    &lt;span class=&quot;icon-bar&quot;&gt;&lt;/span&gt;  
                    &lt;span class=&quot;icon-bar&quot;&gt;&lt;/span&gt;  
                &lt;/button&gt;  
                @Html.ActionLink(&quot;Application name&quot;, &quot;Index&quot;, &quot;Home&quot;, new { area = &quot;&quot; }, new { @class = &quot;navbar-brand&quot; })  
            &lt;/div&gt;  
            &lt;div class=&quot;navbar-collapse collapse&quot;&gt;  
                &lt;ul class=&quot;nav navbar-nav&quot;&gt;  
                    &lt;li&gt;@Html.ActionLink(&quot;Home&quot;, &quot;Index&quot;, &quot;Home&quot;)&lt;/li&gt;  
                    &lt;li&gt;@Html.ActionLink(&quot;About&quot;, &quot;About&quot;, &quot;Home&quot;)&lt;/li&gt;  
                    &lt;li&gt;@Html.ActionLink(&quot;Contact&quot;, &quot;Contact&quot;, &quot;Home&quot;)&lt;/li&gt;  
                &lt;/ul&gt;  
            &lt;/div&gt;  
        &lt;/div&gt;  
    &lt;/div&gt;  
    &lt;div class=&quot;container body-content&quot;&gt;  
        @RenderBody()  
        &lt;hr /&gt;  
        &lt;footer&gt;  
            &lt;p&gt;&copy; @DateTime.Now.Year - My ASP.NET Application&lt;/p&gt;  
        &lt;/footer&gt;  
    &lt;/div&gt;  
  
      
    @Scripts.Render(&quot;~/bundles/bootstrap&quot;)  
    &lt;script src=&quot;~/Scripts/Highcharts-4.0.1/js/highcharts.js&quot;&gt;&lt;/script&gt;  
    @RenderSection(&quot;scripts&quot;, required: false)  
&lt;/body&gt;  
&lt;/html&gt;  </pre>
<div class="preview">
<pre class="js">&lt;!DOCTYPE&nbsp;html&gt;&nbsp;&nbsp;&nbsp;
&lt;html&gt;&nbsp;&nbsp;&nbsp;
&lt;head&gt;&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&lt;meta&nbsp;charset=<span class="js__string">&quot;utf-8&quot;</span>&nbsp;/&gt;&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&lt;meta&nbsp;name=<span class="js__string">&quot;viewport&quot;</span>&nbsp;content=<span class="js__string">&quot;width=device-width,&nbsp;initial-scale=1.0&quot;</span>&gt;&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&lt;title&gt;@ViewBag.Title&nbsp;-&nbsp;My&nbsp;ASP.NET&nbsp;Application&lt;/title&gt;&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;@Styles.Render(<span class="js__string">&quot;~/Content/css&quot;</span>)&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;@Scripts.Render(<span class="js__string">&quot;~/bundles/modernizr&quot;</span>)&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;@Scripts.Render(<span class="js__string">&quot;~/bundles/jquery&quot;</span>)&nbsp;&nbsp;&nbsp;
&lt;/head&gt;&nbsp;&nbsp;&nbsp;
&lt;body&gt;&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&lt;div&nbsp;class=<span class="js__string">&quot;navbar&nbsp;navbar-inverse&nbsp;navbar-fixed-top&quot;</span>&gt;&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&lt;div&nbsp;class=<span class="js__string">&quot;container&quot;</span>&gt;&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&lt;div&nbsp;class=<span class="js__string">&quot;navbar-header&quot;</span>&gt;&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&lt;button&nbsp;type=<span class="js__string">&quot;button&quot;</span>&nbsp;class=<span class="js__string">&quot;navbar-toggle&quot;</span>&nbsp;data-toggle=<span class="js__string">&quot;collapse&quot;</span>&nbsp;data-target=<span class="js__string">&quot;.navbar-collapse&quot;</span>&gt;&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&lt;span&nbsp;class=<span class="js__string">&quot;icon-bar&quot;</span>&gt;&lt;/span&gt;&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&lt;span&nbsp;class=<span class="js__string">&quot;icon-bar&quot;</span>&gt;&lt;/span&gt;&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&lt;span&nbsp;class=<span class="js__string">&quot;icon-bar&quot;</span>&gt;&lt;/span&gt;&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&lt;/button&gt;&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;@Html.ActionLink(<span class="js__string">&quot;Application&nbsp;name&quot;</span>,&nbsp;<span class="js__string">&quot;Index&quot;</span>,&nbsp;<span class="js__string">&quot;Home&quot;</span>,&nbsp;<span class="js__operator">new</span>&nbsp;<span class="js__brace">{</span>&nbsp;area&nbsp;=&nbsp;<span class="js__string">&quot;&quot;</span>&nbsp;<span class="js__brace">}</span>,&nbsp;<span class="js__operator">new</span>&nbsp;<span class="js__brace">{</span>&nbsp;@class&nbsp;=&nbsp;<span class="js__string">&quot;navbar-brand&quot;</span>&nbsp;<span class="js__brace">}</span>)&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&lt;/div&gt;&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&lt;div&nbsp;class=<span class="js__string">&quot;navbar-collapse&nbsp;collapse&quot;</span>&gt;&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&lt;ul&nbsp;class=<span class="js__string">&quot;nav&nbsp;navbar-nav&quot;</span>&gt;&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&lt;li&gt;@Html.ActionLink(<span class="js__string">&quot;Home&quot;</span>,&nbsp;<span class="js__string">&quot;Index&quot;</span>,&nbsp;<span class="js__string">&quot;Home&quot;</span>)&lt;/li&gt;&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&lt;li&gt;@Html.ActionLink(<span class="js__string">&quot;About&quot;</span>,&nbsp;<span class="js__string">&quot;About&quot;</span>,&nbsp;<span class="js__string">&quot;Home&quot;</span>)&lt;/li&gt;&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&lt;li&gt;@Html.ActionLink(<span class="js__string">&quot;Contact&quot;</span>,&nbsp;<span class="js__string">&quot;Contact&quot;</span>,&nbsp;<span class="js__string">&quot;Home&quot;</span>)&lt;/li&gt;&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&lt;/ul&gt;&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&lt;/div&gt;&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&lt;/div&gt;&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&lt;/div&gt;&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&lt;div&nbsp;class=<span class="js__string">&quot;container&nbsp;body-content&quot;</span>&gt;&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;@RenderBody()&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&lt;hr&nbsp;/&gt;&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&lt;footer&gt;&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&lt;p&gt;&copy;&nbsp;@DateTime.Now.Year&nbsp;-&nbsp;My&nbsp;ASP.NET&nbsp;Application&lt;/p&gt;&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&lt;/footer&gt;&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&lt;/div&gt;&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;@Scripts.Render(<span class="js__string">&quot;~/bundles/bootstrap&quot;</span>)&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&lt;script&nbsp;src=<span class="js__string">&quot;~/Scripts/Highcharts-4.0.1/js/highcharts.js&quot;</span>&gt;&lt;/script&gt;&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;@RenderSection(<span class="js__string">&quot;scripts&quot;</span>,&nbsp;required:&nbsp;false)&nbsp;&nbsp;&nbsp;
&lt;/body&gt;&nbsp;&nbsp;&nbsp;
&lt;/html&gt;&nbsp;&nbsp;</pre>
</div>
</div>
</div>
<div class="endscriptcode">&nbsp;<img id="181180" src="181180-highcharts_example.jpg" alt="" width="1158" height="603"></div>
<p></p>
<h1>More Information</h1>
<p><em>For more information on this, see ...<a title="http://www.c-sharpcorner.com/article/dotnet-highcharts-with-asp-net-mvc/" href="http://www.c-sharpcorner.com/article/dotnet-highcharts-with-asp-net-mvc/" target="_blank">http://www.c-sharpcorner.com/article/dotnet-highcharts-with-asp-net-mvc/</a></em></p>
