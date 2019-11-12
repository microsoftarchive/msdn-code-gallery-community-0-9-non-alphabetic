# .NET Core extented architecture and  separation of concerns (Divide and conquer)
## Requires
- Visual Studio 2017
## License
- MIT
## Technologies
- C#
- SQL Server
- Entity Framework
- ASP.NET Core 2.0
## Topics
- Entity Framework Code First
- Generic Repository
- Web Architecture
## Updated
- 02/16/2018
## Description

<h1>Introduction</h1>
<p><em><span>Most of the projects start as&nbsp;</span><em>small projects</em><span>&nbsp;and with time they turn into&nbsp;</span><em><span class="badge">medium</span>&nbsp;or even&nbsp;<span class="badge">large</span></em><span>&nbsp;projects. By the
 time that we realize this is happening, it might be too&nbsp;</span><span class="badge">late</span><span>&nbsp;and can&nbsp;</span><span class="badge">cost us</span><span>&nbsp;a lot to change the project architecture.&nbsp;</span></em></p>
<p><strong><em>So why don't we do the whole process smarter and think about this from the beginning?</em></strong></p>
<p><em><span><strong>The separation of concerns</strong><span>&nbsp;is often neglected topic when dealing with web applications. Everyone who has created even once a basic web app knows that by default .NET has a&nbsp;</span><em>decent template</em><span>.</span></span></em></p>
<p><em><span><span>That's okay for&nbsp;</span><strong>starter</strong><span>&nbsp;and for people that are new to these concepts, but if you want to create easily&nbsp;</span><span class="badge">maintainable</span><span>&nbsp;and&nbsp;</span><span class="badge">extendable</span><span>&nbsp;application
 you should absolutely put some effort to extend the basic MVC template.</span></span></em></p>
<p><em><span>So let's see what this template gives us!</span></em></p>
<p><em>*More templates like this one can be downloaded from <a href="https://asptemplatestack.com" target="_blank">
https://asptemplatestack.com</a></em></p>
<h1><span>Building the Sample</span></h1>
<p><em>Building this template requires installed Visual Studio 2015 or latter with inscluded .NET Core. Once you have it just build the solution, which will trigger package restore and after a few seconds your solution would be build!</em></p>
<p><em><img id="188939" src="188939-01.build.png" alt="" width="528" height="582" style="display:block; margin-left:auto; margin-right:auto"></em></p>
<p><em>This will trigger bower restore and NuGet package restore.</em></p>
<p><em>*If bower restore fails, just save the bower.json and .bowerrc files&nbsp; like this:<br>
</em></p>
<ul>
<li>Open the file in&nbsp;<em>Visual Studio</em> </li><li>Click on &quot;Save file as&quot; under File menu </li><li>Click on the down arrow sign on the right side of Save button </li><li>Select &quot;Save with Encoding&quot; </li><li>Agree to replace the file </li><li>Change the Encoding type to &quot;Western European (Windows) - Codepage 1252&quot; and leave the Line endings to &quot;Current Settings&quot;
</li><li>Hit Save button </li></ul>
<p><em><br>
</em></p>
<p><span style="font-size:20px; font-weight:bold">Description</span></p>
<h3>What does this architecture&nbsp;<strong>give you</strong>&nbsp;more than the usual boilerplate templates?</h3>
<p>&lt;samp&gt;(Those advantages are applicable for medium to large projects)&lt;/samp&gt;</p>
<ul>
<li><strong>Easier development&nbsp;</strong>- one look at the project structure tells you where all different components are situated
</li><li><strong>Lower barrier for understanding, when new people are working on the project</strong>&nbsp;- when introducing new people to some project that is already in progress it's always better to do that step by step. And when these components are well structured
 and neat it is easier to go through them </li><li><strong>Improved maintenance&nbsp;</strong>- whether you have created the project from scratch or not, when a problem occurs it's a lot easier to define where this problem comes from
</li><li><strong>Easier extension of the project</strong>&nbsp;- having all the components separated makes it a lot easier to extend them
</li></ul>
<h3>Detailed explanation of the architecture</h3>
<p>Data</p>
<blockquote>
<ul>
<li><strong>Project for the database tables</strong>&nbsp;- contains the Db Context and the configurations of the migrations
</li><li><strong>Project for abstraction levels over the database</strong>&nbsp;- contains implemention of different abstraction levels over the database like&nbsp;<span class="badge">Unit of work</span>&nbsp;and&nbsp;<span class="badge">Repository pattern</span>
</li><li><strong>Project for the database models</strong>&nbsp;- contains all the db models including these from the ASP.NET identity which are moved from the web project
</li></ul>
</blockquote>
<p>Services</p>
<blockquote>
<ul>
<li><strong>Project for the services related to the database access</strong>&nbsp;- these services&nbsp;<strong>are not</strong>&nbsp;Web Api services, or any other ASP.NET services. They are just called like that. They might be called 'Providers',or whatever
 descriptive name you like. They are just regular classes plus interfaces that are responsible for the containment of the&nbsp;<span class="badge">business logic</span>&nbsp;of the application as well as the tasks related to&nbsp;<span class="badge">CRUD
 operations</span>&nbsp;over the database. </li><li><strong>Project for the services related to the web operations</strong>&nbsp;- the same thing is valid here, but here are the services related to more complex logic that is not related to the database like&nbsp;<span class="badge">Caching</span>&nbsp;services,&nbsp;<span class="badge">Email</span>&nbsp;services
 and etc. </li></ul>
</blockquote>
<p>Tests</p>
<blockquote>
<ul>
<li><strong>Project for the services tests</strong>&nbsp;- just to keep the different types of tests separately
</li><li><strong>Project for the controllers tests</strong> </li><li><strong>Project for the routes tests</strong> </li></ul>
</blockquote>
<blockquote>
<ul>
</ul>
</blockquote>
<p>Web</p>
<blockquote>
<ul>
<li><strong>Project for the web application&nbsp;</strong>- this is the classic MVC project which is stripped of the Db context dependency as well as the db models dependencies . Contains configurations for the&nbsp;<span class="badge">Dependency Injection</span>,&nbsp;<span class="badge">Automapper</span>&nbsp;and
 other external libraries. The architecture is supposed to keep all your contoller actions very tiny and do all of your business logic in the services, which are injected by your IoC (inversion of control) container. In our case this is&nbsp;<span class="badge">Autofac</span>
</li><li><strong>Project for the web application infrastructure&nbsp;</strong>-this project contains source code which is related to the Web application, but might be reusable, and this is why it is separated by the Web App. For example here we can put our View
 Models, custom filters and annotations, html extention methods and helpers, and etc.
</li></ul>
</blockquote>
<blockquote>Lastly there is a separate project intendted to combine all the common classes between all the projects like Global Constants, Global Helper and etc.</blockquote>
<p>&nbsp;</p>
<h1>Additional Features</h1>
<ul>
<li><strong>Extended database models</strong> - this is needed because we always have similar fields in our database tables. This can be avoid using the priciples of the Object Oriented Programming like inheritance.
</li></ul>
<p>&nbsp;</p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title">C#</div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<div class="preview">
<pre class="csharp"><span class="cs__keyword">public</span>&nbsp;<span class="cs__keyword">interface</span>&nbsp;IDeletableEntity&nbsp;
{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">bool</span>&nbsp;IsDeleted&nbsp;{&nbsp;<span class="cs__keyword">get</span>;&nbsp;<span class="cs__keyword">set</span>;&nbsp;}&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;DateTime?&nbsp;DeletedOn&nbsp;{&nbsp;<span class="cs__keyword">get</span>;&nbsp;<span class="cs__keyword">set</span>;&nbsp;}&nbsp;
}</pre>
</div>
</div>
</div>
<div class="endscriptcode">&nbsp;</div>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title">C#</div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<div class="preview">
<pre class="csharp"><span class="cs__keyword">public</span>&nbsp;<span class="cs__keyword">interface</span>&nbsp;IAuditInfo&nbsp;
{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;DateTime&nbsp;CreatedOn&nbsp;{&nbsp;<span class="cs__keyword">get</span>;&nbsp;<span class="cs__keyword">set</span>;&nbsp;}&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;DateTime?&nbsp;ModifiedOn&nbsp;{&nbsp;<span class="cs__keyword">get</span>;&nbsp;<span class="cs__keyword">set</span>;&nbsp;}&nbsp;
}</pre>
</div>
</div>
</div>
<div class="endscriptcode">&nbsp;</div>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title">C#</div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<div class="preview">
<pre class="csharp">&nbsp;<span class="cs__keyword">public</span>&nbsp;<span class="cs__keyword">abstract</span>&nbsp;<span class="cs__keyword">class</span>&nbsp;BaseModel&lt;TKey&gt;&nbsp;:&nbsp;IAuditInfo&nbsp;
&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;[Key]&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">public</span>&nbsp;TKey&nbsp;Id&nbsp;{&nbsp;<span class="cs__keyword">get</span>;&nbsp;<span class="cs__keyword">set</span>;&nbsp;}&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">public</span>&nbsp;DateTime&nbsp;CreatedOn&nbsp;{&nbsp;<span class="cs__keyword">get</span>;&nbsp;<span class="cs__keyword">set</span>;&nbsp;}&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">public</span>&nbsp;DateTime?&nbsp;ModifiedOn&nbsp;{&nbsp;<span class="cs__keyword">get</span>;&nbsp;<span class="cs__keyword">set</span>;&nbsp;}&nbsp;
}</pre>
</div>
</div>
</div>
<div class="endscriptcode">&nbsp;</div>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title">C#</div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<div class="preview">
<pre class="csharp">&nbsp;<span class="cs__keyword">public</span>&nbsp;<span class="cs__keyword">abstract</span>&nbsp;<span class="cs__keyword">class</span>&nbsp;BaseDeletableModel&lt;TKey&gt;&nbsp;:&nbsp;BaseModel&lt;TKey&gt;,&nbsp;IDeletableEntity&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">public</span>&nbsp;<span class="cs__keyword">bool</span>&nbsp;IsDeleted&nbsp;{&nbsp;<span class="cs__keyword">get</span>;&nbsp;<span class="cs__keyword">set</span>;&nbsp;}&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">public</span>&nbsp;DateTime?&nbsp;DeletedOn&nbsp;{&nbsp;<span class="cs__keyword">get</span>;&nbsp;<span class="cs__keyword">set</span>;&nbsp;}&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;}</pre>
</div>
</div>
</div>
<div class="endscriptcode">&nbsp;Now we can use these <strong>base classes </strong>
and prevent adding their properties in each of our classes separately like this:<br>
<br>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title">C#</div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<div class="preview">
<pre class="csharp">&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">public</span>&nbsp;<span class="cs__keyword">class</span>&nbsp;Setting&nbsp;:&nbsp;BaseDeletableModel&lt;<span class="cs__keyword">int</span>&gt;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">public</span>&nbsp;<span class="cs__keyword">string</span>&nbsp;Name&nbsp;{&nbsp;<span class="cs__keyword">get</span>;&nbsp;<span class="cs__keyword">set</span>;&nbsp;}&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">public</span>&nbsp;<span class="cs__keyword">string</span>&nbsp;Value&nbsp;{&nbsp;<span class="cs__keyword">get</span>;&nbsp;<span class="cs__keyword">set</span>;&nbsp;}&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;}</pre>
</div>
</div>
</div>
<div class="endscriptcode">&nbsp;</div>
</div>
<ul>
<li><strong>Generic Repositiry Pattern</strong> - Creating some kind of abstraction over the database is almost mandatory when talking about a real project.&nbsp;
</li></ul>
<p>&nbsp;</p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title">C#</div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<div class="preview">
<pre class="csharp">&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">public</span>&nbsp;<span class="cs__keyword">interface</span>&nbsp;IRepository&lt;TEntity&gt;&nbsp;:&nbsp;IDisposable&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;where&nbsp;TEntity&nbsp;:&nbsp;<span class="cs__keyword">class</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;IQueryable&lt;TEntity&gt;&nbsp;All();&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;IQueryable&lt;TEntity&gt;&nbsp;AllAsNoTracking();&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Task&lt;TEntity&gt;&nbsp;GetByIdAsync(<span class="cs__keyword">params</span>&nbsp;<span class="cs__keyword">object</span>[]&nbsp;id);&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">void</span>&nbsp;Add(TEntity&nbsp;entity);&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">void</span>&nbsp;Update(TEntity&nbsp;entity);&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">void</span>&nbsp;Delete(TEntity&nbsp;entity);&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Task&lt;<span class="cs__keyword">int</span>&gt;&nbsp;SaveChangesAsync();&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;}</pre>
</div>
</div>
</div>
<div class="endscriptcode">&nbsp;Our repository shoud contain all operations needed for work with our database like:</div>
<ul>
<li>Create </li><li>Read </li><li>Updated </li><li>Delete </li></ul>
<p>or so called crud operations. In the provided solution we have two implementaions of the interface&nbsp;<strong>EfRepository.cs</strong> and&nbsp;<strong>EfDeletableEntityRepository.cs</strong></p>
<p>&nbsp;</p>
<h1><span>Source Code Files</span></h1>
<ul>
<li><em><strong>EfRepository.cs&nbsp;</strong>- We use this repository for entities that are not implementing the BaseDeletableModel class.</em>
</li><li><strong>EfDeletableEntityRepository.cs - </strong>we use this repository implementaion for entities that implement&nbsp;<em>BaseDeletableModel class and it handles the deleted items automatically.</em>
</li><li><strong>AutoMapperConfig </strong>- additional configurations for the automapper which allows us to set the mappings like this:<br>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>C#</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">csharp</span>

<div class="preview">
<pre class="csharp">&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">public</span>&nbsp;<span class="cs__keyword">class</span>&nbsp;SettingViewModel&nbsp;:&nbsp;IMapFrom&lt;Setting&gt;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">public</span>&nbsp;<span class="cs__keyword">int</span>&nbsp;Id&nbsp;{&nbsp;<span class="cs__keyword">get</span>;&nbsp;<span class="cs__keyword">set</span>;&nbsp;}&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">public</span>&nbsp;<span class="cs__keyword">string</span>&nbsp;Name&nbsp;{&nbsp;<span class="cs__keyword">get</span>;&nbsp;<span class="cs__keyword">set</span>;&nbsp;}&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">public</span>&nbsp;<span class="cs__keyword">string</span>&nbsp;Value&nbsp;{&nbsp;<span class="cs__keyword">get</span>;&nbsp;<span class="cs__keyword">set</span>;&nbsp;}&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;}</pre>
</div>
</div>
</div>
</li></ul>
<h1>More Information</h1>
<p><em>For more advanced templates using this architecture visit&nbsp;<em><a href="https://asptemplatestack.com">https://asptemplatestack.com</a></em></em></p>
