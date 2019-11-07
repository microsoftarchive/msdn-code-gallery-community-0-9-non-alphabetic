# 使用AngularJs打造一个简易权限管理系统
## Requires
- Visual Studio 2013
## License
- MIT
## Technologies
- AngularJS
- ASP.NET Web API 2
## Topics
- ASP.NET Web API
- ioc
- AngularJS
## Updated
- 05/07/2016
## Description

<h1>介绍</h1>
<p><span>AngularJS是Google推出的一款Web应用开发框架。它提供了一系列兼容性良好并可扩展的服务，包括数据绑定、DOM操作、MVC和依赖注入等特性。相信下面图片可以更好地诠释AngularJs具体支持哪些特性。</span></p>
<p><span>AngularJs几乎支持构建一个Web应用的所有内容&mdash;&mdash;数据绑定、表单验证、路由、依赖注入、控制器、模板和视图等。</span></p>
<p><span>但并不是所有的应用都适合用AngularJs来做。AngularJS主要考虑的是构建CURD应用，但至少90%的Web应用都是CURD应用。哪什么不适合用AngularJs来做呢? 如游戏、图像界面编辑器等应用不适合用AngularJs来构建。</span></p>
<h2>三、AngularJS核心知识点</h2>
<p><span>接下来，我们就详细介绍了AngularJS的几个核心知识点，其中包括：</span></p>
<ul>
<li><span>指令（directive）和&nbsp;数据绑定(Data Binding)</span> </li><li><span>模板(Module)</span> </li><li><span>控制器(Controller)</span> </li><li><span>路由(Route)</span> </li><li><span>服务(service)</span> </li><li><span>过滤器(Filter)</span> </li></ul>
<p><span style="font-size:20px"><strong>描述</strong></span></p>
<p><span>首先看下整个项目的架构设计图：<br>
</span></p>
<p><img src="-383187-20160508113957189-1354902211.png" alt=""></p>
<p><span>从上图可以看出整个项目的一个整体结构，接下来，我来详细介绍了项目的整体架构：</span></p>
<p><span></span><span>采用Asp.net Web API来实现REST 服务。这样的实现方式，已达到后端服务的公用、分别部署和更好地扩展。</span><span>Web层依赖应用服务接口，并且使用Castle Windsor实现依赖注入。</span></p>
<ul>
<li><span>显示层(用户UI)</span> </li></ul>
<p><span>显示层采用了AngularJS来实现的SPA页面。所有的页面数据都是异步加载和局部刷新，这样的实现将会有更好的用户体验。</span></p>
<ul>
<li><span>应用层(Application Service)</span> </li></ul>
<p><span>AngularJS通过Http服务去请求Web API来获得数据，而Web API的实现则是调用应用层来请求数据。</span></p>
<ul>
<li><span>基础架构层</span> </li></ul>
<p><span>基础架构层包括仓储的实现和一些公用方法的实现。</span></p>
<p><span>仓储层的实现采用EF Code First的方式来实现的，并使用<a href="http://www.cnblogs.com/jinzhao/archive/2012/08/13/2636747.html" target="_blank">EF Migration</a>的方式来创建数据库和更新数据库。</span></p>
<p><span>LH.Common层实现了一些公用的方法，如日志帮助类、表达式树扩展等类的实现。</span></p>
<ul>
<li><span>领域层</span> </li></ul>
<p><span>领域层主要实现了该项目的所有领域模型，其中包括领域模型的实现和仓储接口的定义。</span></p>
<h2>三、后端服务实现</h2>
<p>&nbsp;　　<span>后端服务主要采用Asp.net Web API来实现后端服务，并且采用Castle Windsor来完成依赖注入。</span></p>
<p><span>这里拿权限管理中的用户管理来介绍Rest Web API服务的实现。</span></p>
<p><span>提供用户数据的REST服务的实现：</span></p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>C#</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">编辑脚本</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">csharp</span>
<pre class="hidden">public class UserController : ApiController
    {
        private readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpGet]
        [Route(&quot;api/user/GetUsers&quot;)]
        public OutputBase GetUsers([FromUri]PageInput input)
        {
            return _userService.GetUsers(input);
        }

        [HttpGet]
        [Route(&quot;api/user/UserInfo&quot;)]
        public OutputBase GetUserInfo(int id)
        {
            return _userService.GetUser(id);
        }

        [HttpPost]
        [Route(&quot;api/user/AddUser&quot;)]
        public OutputBase CreateUser([FromBody] UserDto userDto)
        {
            return _userService.AddUser(userDto);
        }

        [HttpPost]
        [Route(&quot;api/user/UpdateUser&quot;)]
        public OutputBase UpdateUser([FromBody] UserDto userDto)
        {
            return _userService.UpdateUser(userDto);
        }

        [HttpPost]
        [Route(&quot;api/user/UpdateRoles&quot;)]
        public OutputBase UpdateRoles([FromBody] UserDto userDto)
        {
            return _userService.UpdateRoles(userDto);
        }

        [HttpPost]
        [Route(&quot;api/user/DeleteUser/{id}&quot;)]
        public OutputBase DeleteUser(int id)
        {
            return _userService.DeleteUser(id);
        }

        [HttpPost]
        [Route(&quot;api/user/DeleteRole/{id}/{roleId}&quot;)]
        public OutputBase DeleteRole(int id, int roleId)
        {
            return _userService.DeleteRole(id, roleId);
        }
    }</pre>
<div class="preview">
<pre class="csharp"><span class="cs__keyword">public</span>&nbsp;<span class="cs__keyword">class</span>&nbsp;UserController&nbsp;:&nbsp;ApiController&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">private</span>&nbsp;<span class="cs__keyword">readonly</span>&nbsp;IUserService&nbsp;_userService;&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">public</span>&nbsp;UserController(IUserService&nbsp;userService)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;_userService&nbsp;=&nbsp;userService;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;[HttpGet]&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;[Route(<span class="cs__string">&quot;api/user/GetUsers&quot;</span>)]&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">public</span>&nbsp;OutputBase&nbsp;GetUsers([FromUri]PageInput&nbsp;input)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">return</span>&nbsp;_userService.GetUsers(input);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;[HttpGet]&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;[Route(<span class="cs__string">&quot;api/user/UserInfo&quot;</span>)]&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">public</span>&nbsp;OutputBase&nbsp;GetUserInfo(<span class="cs__keyword">int</span>&nbsp;id)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">return</span>&nbsp;_userService.GetUser(id);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;[HttpPost]&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;[Route(<span class="cs__string">&quot;api/user/AddUser&quot;</span>)]&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">public</span>&nbsp;OutputBase&nbsp;CreateUser([FromBody]&nbsp;UserDto&nbsp;userDto)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">return</span>&nbsp;_userService.AddUser(userDto);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;[HttpPost]&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;[Route(<span class="cs__string">&quot;api/user/UpdateUser&quot;</span>)]&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">public</span>&nbsp;OutputBase&nbsp;UpdateUser([FromBody]&nbsp;UserDto&nbsp;userDto)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">return</span>&nbsp;_userService.UpdateUser(userDto);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;[HttpPost]&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;[Route(<span class="cs__string">&quot;api/user/UpdateRoles&quot;</span>)]&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">public</span>&nbsp;OutputBase&nbsp;UpdateRoles([FromBody]&nbsp;UserDto&nbsp;userDto)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">return</span>&nbsp;_userService.UpdateRoles(userDto);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;[HttpPost]&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;[Route(<span class="cs__string">&quot;api/user/DeleteUser/{id}&quot;</span>)]&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">public</span>&nbsp;OutputBase&nbsp;DeleteUser(<span class="cs__keyword">int</span>&nbsp;id)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">return</span>&nbsp;_userService.DeleteUser(id);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;[HttpPost]&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;[Route(<span class="cs__string">&quot;api/user/DeleteRole/{id}/{roleId}&quot;</span>)]&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">public</span>&nbsp;OutputBase&nbsp;DeleteRole(<span class="cs__keyword">int</span>&nbsp;id,&nbsp;<span class="cs__keyword">int</span>&nbsp;roleId)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">return</span>&nbsp;_userService.DeleteRole(id,&nbsp;roleId);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;}</pre>
</div>
</div>
</div>
<p><span><span style="white-space:pre"></span>从上面代码实现可以看出，User REST 服务依赖与IUserService接口，并且也没有像传统的方式将所有的业务逻辑放在Web API实现中，而是将具体的一些业务实现封装到对应的应用层中，Rest API只负责调用对应的应用层中的服务。这样设计好处有：</span></p>
<ol>
<li><span>REST 服务部依赖与应用层接口，使得职责分离，将应用层服务的实例化交给单独的依赖注入容器去完成，而REST服务只负责调用对应应用服务的方法来获取数据。采用依赖接口而不依赖与具体类的实现，使得类与类之间低耦合。</span>
</li><li><span>REST服务内不包括具体的业务逻辑实现。这样的设计可以使得服务更好地分离，如果你后期想用WCF来实现REST服务的，这样就不需要重复在WCF的REST服务类中重复写一篇Web API中的逻辑了，这时候完全可以调用应用服务的接口方法来实现WCF REST服务。所以将业务逻辑实现抽到应用服务层去实现，这样的设计将使得REST 服务职责更加单一，REST服务实现更容易扩展。</span>
</li></ol>
<p>&nbsp;</p>
<h1>更多信息</h1>
<p><span>关于架构的设计也可以参考我的另一个开源项目：</span><a href="https://github.com/lizhi5753186/OnlineStore" target="_blank">OnlineStore</a>&nbsp;<span>和&nbsp;</span><a href="https://github.com/lizhi5753186/Fastworks" target="_blank">FastWorks</a><span>。</span></p>
