# 使用WebApi+Bootstrap+KnockoutJs打造单页面程序
## Requires
- Visual Studio 2013
## License
- MIT
## Technologies
- ASP.NET Web API
- knockout.js
- SPA Web application
## Topics
- Single Page Application (SPA)
- ViewModel pattern (MVVM) Knockout
## Updated
- 04/23/2016
## Description

<h1>介绍</h1>
<p><span><span style="white-space:pre">&nbsp;</span>KnockoutJs也就是这样一个MVVM框架。其实与其称其框架，更准备地应该是一个MVVM类库。因为它没有MVVM框架是一个比较&ldquo;重&rdquo;的概念，其中应该包括路由等特性。而KnockoutJS中却没有，相比较，AngularJS应该称为一个MVVM框架更加合适。</span></p>
<p><span>KnockoutJS主要实现的功能有以下4点：</span></p>
<ul>
<li><span>声明式绑定（Declarative Bindings）：使用简单的语法将模型数据关联到DOM元素上。即&quot;data-bind&quot;语法</span>
</li><li><span>依赖跟踪（Dependency Tracking）：为转变和联合数据，在模型数据之间建立关系。如商品总价是由各个商品项价&#26684;之和。此时商品总价和商品项就可以使用依赖跟踪功能来建立关系。即由各个商品项的总价相加而得出。这种关系由KnockoutJs中computed函数完成。</span>
</li><li><span>UI界面自动刷新(Automatic UI Refresh):当你的模型状态改变时，UI界面的将自动更新。这点由observable函数完成。</span>
</li><li><span>模板(Templating)：为您的模型数据快速编写复杂的可嵌套UI。和WPF中模板的概念类&#20284;。</span> </li></ul>
<h1>描述</h1>
<p><span>SPA，即Single Page Web Application的缩写，是加载单个HTML 页面并在用户与应用程序交互时动态更新该页面的Web应用程序。浏览器一开始会加载必需的HTML、CSS和JavaScript，所有的操作都在这张页面上完成，都由JavaScript来控制。</span></p>
<p><span>单页面程序的好处在于：</span></p>
<ol>
<li><span>更好的用户体验，让用户在Web app感受native app的速度和流畅。</span> </li><li><span>分离前后端关注点，前端负责界面显示，后端负责数据存储和计算，各司其职，不会把前后端的逻辑混杂在一起。</span> </li><li><span>减轻服务器压力，服务器只用生成数据就可以，不用管展示逻辑和页面逻辑，增加服务器吞吐量。MVC中Razor语法写的前端是需要服务器完成页面的合成再输出的。</span>
</li><li><span>同一套后端程序，可以不用修改直接用于Web界面、手机、平板等多种客户端。</span> </li></ol>
<p><span>当然单页面程序除了上面列出的优点外，也有其不足：<br>
</span></p>
<ol>
<li><span>不利于SEO。这点如果是做管理系统的话是没影响的</span> </li><li><span>初次加载时间相对增加。因为所有的JS、CSS资源会在第一次加载完成，从而使得后面的页面流畅。对于这点可以使用Asp.net MVC中Bundle来进行文件绑定。关于Bundle的详细使用参考文章：<a href="http://www.cnblogs.com/xwgli/p/3296809.html" target="_blank">http://www.cnblogs.com/xwgli/p/3296809.html</a>和<a href="http://www.cnblogs.com/wangiqngpei557/p/3309812.html" target="_blank">http://www.cnblogs.com/wangiqngpei557/p/3309812.html</a>。</span>
</li><li><span>导航不可用。如果一定要导航需自行实现前进、后退。对于这点，可以自行实现前进、后退功能来弥补。其实现在手机端网页就是这么干的，现在还要上面导航的。对于一些企业后台管理系统，也可以这么做。</span>
</li><li><span>对开发人员技能水平、开发成本高。对于这点，也不是事，程序员嘛就需要不断学习来充电，好在一些前端框架都非常好上手。</span> </li></ol>
<ul>
</ul>
<h1>更多信息</h1>
<p>KnockoutJs官网：<a href="http://knockoutjs.com/documentation/introduction.html">http://knockoutjs.com/documentation/introduction.html</a></p>
<p>Bootstrap中文网：<a href="http://www.bootcss.com/">http://www.bootcss.com/</a></p>
<p>博客园文章介绍：<a href="http://www.cnblogs.com/zhili/p/SPAWithKnockoutJs.html">http://www.cnblogs.com/zhili/p/SPAWithKnockoutJs.html</a></p>
<p>&nbsp;</p>
