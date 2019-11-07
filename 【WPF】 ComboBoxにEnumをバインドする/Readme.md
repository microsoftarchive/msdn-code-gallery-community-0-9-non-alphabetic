# 【WPF】 ComboBoxにEnumをバインドする
## Requires
- Visual Studio 2015
## License
- MIT
## Technologies
- C#
- WPF
- XAML
## Topics
- WPF、ComboBox、Enum、コンボボックス、列挙型、バインド、バインディング
## Updated
- 03/21/2016
## Description

<p>静的なリストをComboBoxにバインドさせ、選択させたいことがあると思います。この場合、以下のように書くのが簡単なのですが、コードからこのComboBoxの選択肢をセットしたり取得する際に、Tagに設定されている数字を直接操作しなければならなくなり、後にわかりにくいコードになる可能性があります。いわゆるマジックナンバーです。</p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>C#</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">スクリプトの編集</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">csharp</span>
<pre class="hidden">&lt;ComboBox x:Name=&quot;comb_Color&quot;
    Width=&quot;200&quot; Margin=&quot;30,33,0,0&quot;
     SelectedValuePath=&quot;Tag&quot; &gt;
      &lt;ComboBoxItem Tag=&quot;0&quot; Content=&quot;White&quot;/&gt;
      &lt;ComboBoxItem Tag=&quot;1&quot; Content=&quot;Blue&quot; /&gt;
      &lt;ComboBoxItem Tag=&quot;2&quot; Content=&quot;Red&quot;/&gt;
      &lt;ComboBoxItem Tag=&quot;3&quot; Content=&quot;Black&quot;/&gt;
&lt;/ComboBox&gt;</pre>
<div class="preview">
<pre class="csharp">&lt;ComboBox&nbsp;x:Name=<span class="cs__string">&quot;comb_Color&quot;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;Width=<span class="cs__string">&quot;200&quot;</span>&nbsp;Margin=<span class="cs__string">&quot;30,33,0,0&quot;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;SelectedValuePath=<span class="cs__string">&quot;Tag&quot;</span>&nbsp;&gt;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&lt;ComboBoxItem&nbsp;Tag=<span class="cs__string">&quot;0&quot;</span>&nbsp;Content=<span class="cs__string">&quot;White&quot;</span>/&gt;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&lt;ComboBoxItem&nbsp;Tag=<span class="cs__string">&quot;1&quot;</span>&nbsp;Content=<span class="cs__string">&quot;Blue&quot;</span>&nbsp;/&gt;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&lt;ComboBoxItem&nbsp;Tag=<span class="cs__string">&quot;2&quot;</span>&nbsp;Content=<span class="cs__string">&quot;Red&quot;</span>/&gt;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&lt;ComboBoxItem&nbsp;Tag=<span class="cs__string">&quot;3&quot;</span>&nbsp;Content=<span class="cs__string">&quot;Black&quot;</span>/&gt;&nbsp;
&lt;/ComboBox&gt;</pre>
</div>
</div>
</div>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>C#</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">スクリプトの編集</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">csharp</span>
<pre class="hidden">// コードからComboBoxの選択肢を指定する例
// 3がマジックナンバー
comb_Color.SelectedValue = &quot;3&quot;;</pre>
<div class="preview">
<pre class="csharp"><span class="cs__com">//&nbsp;コードからComboBoxの選択肢を指定する例</span>&nbsp;
<span class="cs__com">//&nbsp;3がマジックナンバー</span>&nbsp;
comb_Color.SelectedValue&nbsp;=&nbsp;<span class="cs__string">&quot;3&quot;</span>;</pre>
</div>
</div>
</div>
<p>これを避け、アプリケーション全体として統一して管理するためには、Enumとして定義し、それを利用するのが簡単で便利です。</p>
<p>EnumをComboBoxのソースとして指定するには、以下のようになります。</p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>XAML</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">スクリプトの編集</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">xaml</span>
<pre class="hidden">&lt;Window.Resources&gt;
    &lt;ObjectDataProvider x:Key=&quot;ColorEnumKey&quot; MethodName=&quot;GetValues&quot;
                        ObjectType=&quot;{x:Type sys:Enum}&quot;&gt;
        &lt;ObjectDataProvider.MethodParameters&gt;
            &lt;x:Type TypeName=&quot;local:ColorEnum&quot;/&gt;
        &lt;/ObjectDataProvider.MethodParameters&gt;
    &lt;/ObjectDataProvider&gt;
&lt;/Window.Resources&gt;

&lt;Grid&gt;
    &lt;ComboBox x:Name=&quot;comb_color&quot; HorizontalAlignment=&quot;Left&quot;
        ItemsSource=&quot;{Binding Source={StaticResource ColorEnumKey}}&quot;
        SelectedItem=&quot;{x:Static local:ColorEnum.Blue}&quot;
        VerticalAlignment=&quot;Top&quot; Width=&quot;142&quot; Margin=&quot;30,33,0,0&quot; Height=&quot;27&quot;&gt;
    &lt;/ComboBox&gt;
　　　　　　　　　　　・
　　　　　　　　　　　・
　　　　　　　　　　　・
&lt;/Grid&gt;
</pre>
<div class="preview">
<pre class="xaml"><span class="xaml__tag_start">&lt;Window</span>.Resources<span class="xaml__tag_start">&gt;&nbsp;
</span>&nbsp;&nbsp;&nbsp;&nbsp;<span class="xaml__tag_start">&lt;ObjectDataProvider</span>&nbsp;x:<span class="xaml__attr_name">Key</span>=<span class="xaml__attr_value">&quot;ColorEnumKey&quot;</span>&nbsp;<span class="xaml__attr_name">MethodName</span>=<span class="xaml__attr_value">&quot;GetValues&quot;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="xaml__attr_name">ObjectType</span>=<span class="xaml__attr_value">&quot;{x:Type&nbsp;sys:Enum}&quot;</span><span class="xaml__tag_start">&gt;&nbsp;
</span>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="xaml__tag_start">&lt;ObjectDataProvider</span>.MethodParameters<span class="xaml__tag_start">&gt;&nbsp;
</span>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="xaml__tag_start">&lt;x</span>:Type&nbsp;<span class="xaml__attr_name">TypeName</span>=<span class="xaml__attr_value">&quot;local:ColorEnum&quot;</span><span class="xaml__tag_start">/&gt;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&lt;/ObjectDataProvider.MethodParameters&gt;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="xaml__tag_end">&lt;/ObjectDataProvider&gt;</span>&nbsp;
&lt;/Window.Resources&gt;&nbsp;
&nbsp;
<span class="xaml__tag_start">&lt;Grid</span><span class="xaml__tag_start">&gt;&nbsp;
</span>&nbsp;&nbsp;&nbsp;&nbsp;<span class="xaml__tag_start">&lt;ComboBox</span>&nbsp;x:<span class="xaml__attr_name">Name</span>=<span class="xaml__attr_value">&quot;comb_color&quot;</span>&nbsp;<span class="xaml__attr_name">HorizontalAlignment</span>=<span class="xaml__attr_value">&quot;Left&quot;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="xaml__attr_name">ItemsSource</span>=<span class="xaml__attr_value">&quot;{Binding&nbsp;Source={StaticResource&nbsp;ColorEnumKey}}&quot;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="xaml__attr_name">SelectedItem</span>=<span class="xaml__attr_value">&quot;{x:Static&nbsp;local:ColorEnum.Blue}&quot;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="xaml__attr_name">VerticalAlignment</span>=<span class="xaml__attr_value">&quot;Top&quot;</span>&nbsp;<span class="xaml__attr_name">Width</span>=<span class="xaml__attr_value">&quot;142&quot;</span>&nbsp;<span class="xaml__attr_name">Margin</span>=<span class="xaml__attr_value">&quot;30,33,0,0&quot;</span>&nbsp;<span class="xaml__attr_name">Height</span>=<span class="xaml__attr_value">&quot;27&quot;</span><span class="xaml__tag_start">&gt;&nbsp;
</span>&nbsp;&nbsp;&nbsp;&nbsp;<span class="xaml__tag_end">&lt;/ComboBox&gt;</span>&nbsp;
　　　　　　　　　　　・&nbsp;
　　　　　　　　　　　・&nbsp;
　　　　　　　　　　　・&nbsp;
<span class="xaml__tag_end">&lt;/Grid&gt;</span>&nbsp;
</pre>
</div>
</div>
</div>
<div class="endscriptcode">ObjectDataProviderを使用すると、Xamlにおいてメソッドを実行し、バインドするソースを生成することができます。<br>
今回は、EnumクラスのGetValuesメソッドを使用し、ユーザー定義のColorEnumというEnumの全ての一覧をArrayクラスとして取り出しています。そして、これをComboBoxのデータソースとしてバインドさせています。<br>
SelectedItemにEnum値をセットしているところにも注目して下さい。Enum値はこのようにセットすることができます。&nbsp;</div>
<div class="endscriptcode"></div>
<div class="endscriptcode">特に説明は要りませんが、ColorEnumも掲載しておきます。いたって普通のEnumです。</div>
<div class="endscriptcode"></div>
<div class="endscriptcode">
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>C#</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">スクリプトの編集</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">csharp</span>
<pre class="hidden">public enum ColorEnum
{
    White = 0,
    Blue = 1,
    Red = 2,
    Black = 3
}</pre>
<div class="preview">
<pre class="js">public&nbsp;enum&nbsp;ColorEnum&nbsp;
<span class="js__brace">{</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;White&nbsp;=&nbsp;<span class="js__num">0</span>,&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;Blue&nbsp;=&nbsp;<span class="js__num">1</span>,&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;Red&nbsp;=&nbsp;<span class="js__num">2</span>,&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;Black&nbsp;=&nbsp;<span class="js__num">3</span>&nbsp;
<span class="js__brace">}</span></pre>
</div>
</div>
</div>
<div class="endscriptcode">また、ComboBoxの選択肢の設定や取得は以下のようにしてできます。</div>
<div class="endscriptcode"></div>
<div class="endscriptcode">
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>JavaScript</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">スクリプトの編集</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">js</span>
<pre class="hidden">//設定の例
comb_color.SelectedItem = ColorEnum.Red;

//取得の例　（色をEnumで取得する）
comb_color.SelectedItem;

//取得の例　（色を文字で取得する）
comb_color.SelectedItem.ToString();</pre>
<div class="preview">
<pre class="js"><span class="js__sl_comment">//設定の例</span>&nbsp;
comb_color.SelectedItem&nbsp;=&nbsp;ColorEnum.Red;&nbsp;
&nbsp;
<span class="js__sl_comment">//取得の例　（色をEnumで取得する）</span>&nbsp;
comb_color.SelectedItem;&nbsp;
&nbsp;
<span class="js__sl_comment">//取得の例　（色を文字で取得する）</span>&nbsp;
comb_color.SelectedItem.ToString();</pre>
</div>
</div>
</div>
<div class="endscriptcode">&nbsp;最後に、全体のコードを掲載しておきます。</div>
<div class="endscriptcode"></div>
<div class="endscriptcode">
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>XAML</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">スクリプトの編集</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">xaml</span>
<pre class="hidden">&lt;Window x:Class=&quot;ComboboxEnumBinding.MainWindow&quot;
        xmlns=&quot;http://schemas.microsoft.com/winfx/2006/xaml/presentation&quot;
        xmlns:x=&quot;http://schemas.microsoft.com/winfx/2006/xaml&quot;
        xmlns:d=&quot;http://schemas.microsoft.com/expression/blend/2008&quot;
        xmlns:mc=&quot;http://schemas.openxmlformats.org/markup-compatibility/2006&quot;
        xmlns:local=&quot;clr-namespace:ComboboxEnumBinding&quot;
        xmlns:sys=&quot;clr-namespace:System;assembly=mscorlib&quot;
        mc:Ignorable=&quot;d&quot;
        Title=&quot;MainWindow&quot; Height=&quot;350&quot; Width=&quot;525&quot;&gt;

    &lt;Window.Resources&gt;

        &lt;ObjectDataProvider x:Key=&quot;ColorEnumKey&quot; MethodName=&quot;GetValues&quot;
                            ObjectType=&quot;{x:Type sys:Enum}&quot;&gt;
            &lt;ObjectDataProvider.MethodParameters&gt;
                &lt;x:Type TypeName=&quot;local:ColorEnum&quot;/&gt;
            &lt;/ObjectDataProvider.MethodParameters&gt;
        &lt;/ObjectDataProvider&gt;

    &lt;/Window.Resources&gt;

    &lt;Grid&gt;
        &lt;ComboBox x:Name=&quot;comb_color&quot; HorizontalAlignment=&quot;Left&quot;
            ItemsSource=&quot;{Binding Source={StaticResource ColorEnumKey}}&quot;
            SelectedItem=&quot;{x:Static local:ColorEnum.Blue}&quot;
            VerticalAlignment=&quot;Top&quot; Width=&quot;142&quot; Margin=&quot;30,33,0,0&quot; Height=&quot;27&quot;&gt;
        &lt;/ComboBox&gt;
        &lt;Button x:Name=&quot;bttn_SelectRed&quot; Content=&quot;Select Red&quot; HorizontalAlignment=&quot;Left&quot; Margin=&quot;196,33,0,0&quot;
             VerticalAlignment=&quot;Top&quot; Width=&quot;75&quot; Height=&quot;27&quot; Click=&quot;bttn_SelectRed_Click&quot;/&gt;
        &lt;Button x:Name=&quot;bttn_ShowSelectedColor&quot; Content=&quot;Selected Color&quot; HorizontalAlignment=&quot;Left&quot;
             Margin=&quot;124,122,0,0&quot; VerticalAlignment=&quot;Top&quot; Width=&quot;99&quot; Height=&quot;30&quot;
             Click=&quot;bttn_ShowSelectedColor_Click&quot;/&gt;
    &lt;/Grid&gt;
&lt;/Window&gt;
</pre>
<div class="preview">
<pre class="xaml"><span class="xaml__tag_start">&lt;Window</span>&nbsp;x:<span class="xaml__attr_name">Class</span>=<span class="xaml__attr_value">&quot;ComboboxEnumBinding.MainWindow&quot;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="xaml__attr_name">xmlns</span>=<span class="xaml__attr_value">&quot;http://schemas.microsoft.com/winfx/2006/xaml/presentation&quot;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="xaml__keyword">xmlns</span>:<span class="xaml__attr_name">x</span>=<span class="xaml__attr_value">&quot;http://schemas.microsoft.com/winfx/2006/xaml&quot;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="xaml__keyword">xmlns</span>:<span class="xaml__attr_name">d</span>=<span class="xaml__attr_value">&quot;http://schemas.microsoft.com/expression/blend/2008&quot;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="xaml__keyword">xmlns</span>:<span class="xaml__attr_name">mc</span>=<span class="xaml__attr_value">&quot;http://schemas.openxmlformats.org/markup-compatibility/2006&quot;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="xaml__keyword">xmlns</span>:<span class="xaml__attr_name">local</span>=<span class="xaml__attr_value">&quot;clr-namespace:ComboboxEnumBinding&quot;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="xaml__keyword">xmlns</span>:<span class="xaml__attr_name">sys</span>=<span class="xaml__attr_value">&quot;clr-namespace:System;assembly=mscorlib&quot;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;mc:<span class="xaml__attr_name">Ignorable</span>=<span class="xaml__attr_value">&quot;d&quot;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="xaml__attr_name">Title</span>=<span class="xaml__attr_value">&quot;MainWindow&quot;</span>&nbsp;<span class="xaml__attr_name">Height</span>=<span class="xaml__attr_value">&quot;350&quot;</span>&nbsp;<span class="xaml__attr_name">Width</span>=<span class="xaml__attr_value">&quot;525&quot;</span><span class="xaml__tag_start">&gt;&nbsp;
</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="xaml__tag_start">&lt;Window</span>.Resources<span class="xaml__tag_start">&gt;&nbsp;
</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="xaml__tag_start">&lt;ObjectDataProvider</span>&nbsp;x:<span class="xaml__attr_name">Key</span>=<span class="xaml__attr_value">&quot;ColorEnumKey&quot;</span>&nbsp;<span class="xaml__attr_name">MethodName</span>=<span class="xaml__attr_value">&quot;GetValues&quot;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="xaml__attr_name">ObjectType</span>=<span class="xaml__attr_value">&quot;{x:Type&nbsp;sys:Enum}&quot;</span><span class="xaml__tag_start">&gt;&nbsp;
</span>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="xaml__tag_start">&lt;ObjectDataProvider</span>.MethodParameters<span class="xaml__tag_start">&gt;&nbsp;
</span>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="xaml__tag_start">&lt;x</span>:Type&nbsp;<span class="xaml__attr_name">TypeName</span>=<span class="xaml__attr_value">&quot;local:ColorEnum&quot;</span><span class="xaml__tag_start">/&gt;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&lt;/ObjectDataProvider.MethodParameters&gt;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="xaml__tag_end">&lt;/ObjectDataProvider&gt;</span>&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&lt;/Window.Resources&gt;&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="xaml__tag_start">&lt;Grid</span><span class="xaml__tag_start">&gt;&nbsp;
</span>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="xaml__tag_start">&lt;ComboBox</span>&nbsp;x:<span class="xaml__attr_name">Name</span>=<span class="xaml__attr_value">&quot;comb_color&quot;</span>&nbsp;<span class="xaml__attr_name">HorizontalAlignment</span>=<span class="xaml__attr_value">&quot;Left&quot;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="xaml__attr_name">ItemsSource</span>=<span class="xaml__attr_value">&quot;{Binding&nbsp;Source={StaticResource&nbsp;ColorEnumKey}}&quot;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="xaml__attr_name">SelectedItem</span>=<span class="xaml__attr_value">&quot;{x:Static&nbsp;local:ColorEnum.Blue}&quot;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="xaml__attr_name">VerticalAlignment</span>=<span class="xaml__attr_value">&quot;Top&quot;</span>&nbsp;<span class="xaml__attr_name">Width</span>=<span class="xaml__attr_value">&quot;142&quot;</span>&nbsp;<span class="xaml__attr_name">Margin</span>=<span class="xaml__attr_value">&quot;30,33,0,0&quot;</span>&nbsp;<span class="xaml__attr_name">Height</span>=<span class="xaml__attr_value">&quot;27&quot;</span><span class="xaml__tag_start">&gt;&nbsp;
</span>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="xaml__tag_end">&lt;/ComboBox&gt;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="xaml__tag_start">&lt;Button</span>&nbsp;x:<span class="xaml__attr_name">Name</span>=<span class="xaml__attr_value">&quot;bttn_SelectRed&quot;</span>&nbsp;<span class="xaml__attr_name">Content</span>=<span class="xaml__attr_value">&quot;Select&nbsp;Red&quot;</span>&nbsp;<span class="xaml__attr_name">HorizontalAlignment</span>=<span class="xaml__attr_value">&quot;Left&quot;</span>&nbsp;<span class="xaml__attr_name">Margin</span>=<span class="xaml__attr_value">&quot;196,33,0,0&quot;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="xaml__attr_name">VerticalAlignment</span>=<span class="xaml__attr_value">&quot;Top&quot;</span>&nbsp;<span class="xaml__attr_name">Width</span>=<span class="xaml__attr_value">&quot;75&quot;</span>&nbsp;<span class="xaml__attr_name">Height</span>=<span class="xaml__attr_value">&quot;27&quot;</span>&nbsp;<span class="xaml__attr_name">Click</span>=<span class="xaml__attr_value">&quot;bttn_SelectRed_Click&quot;</span><span class="xaml__tag_start">/&gt;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="xaml__tag_start">&lt;Button</span>&nbsp;x:<span class="xaml__attr_name">Name</span>=<span class="xaml__attr_value">&quot;bttn_ShowSelectedColor&quot;</span>&nbsp;<span class="xaml__attr_name">Content</span>=<span class="xaml__attr_value">&quot;Selected&nbsp;Color&quot;</span>&nbsp;<span class="xaml__attr_name">HorizontalAlignment</span>=<span class="xaml__attr_value">&quot;Left&quot;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="xaml__attr_name">Margin</span>=<span class="xaml__attr_value">&quot;124,122,0,0&quot;</span>&nbsp;<span class="xaml__attr_name">VerticalAlignment</span>=<span class="xaml__attr_value">&quot;Top&quot;</span>&nbsp;<span class="xaml__attr_name">Width</span>=<span class="xaml__attr_value">&quot;99&quot;</span>&nbsp;<span class="xaml__attr_name">Height</span>=<span class="xaml__attr_value">&quot;30&quot;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="xaml__attr_name">Click</span>=<span class="xaml__attr_value">&quot;bttn_ShowSelectedColor_Click&quot;</span><span class="xaml__tag_start">/&gt;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="xaml__tag_end">&lt;/Grid&gt;</span>&nbsp;
<span class="xaml__tag_end">&lt;/Window&gt;</span>&nbsp;
</pre>
</div>
</div>
</div>
<div class="endscriptcode">&nbsp;
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>C#</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">スクリプトの編集</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">csharp</span>
<pre class="hidden">using System.Windows;

namespace ComboboxEnumBinding
{
    /// &lt;summary&gt;
    /// MainWindow.xaml の相互作用ロジック
    /// &lt;/summary&gt;
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void bttn_SelectRed_Click(object sender, RoutedEventArgs e)
        {
            comb_color.SelectedItem = ColorEnum.Red;
        }

        private void bttn_ShowSelectedColor_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show(comb_color.SelectedItem.ToString());
        }
    }
    public enum ColorEnum
    {
        White = 0,
        Blue = 1,
        Red = 2,
        Black = 3
    }
}
</pre>
<div class="preview">
<pre class="csharp"><span class="cs__keyword">using</span>&nbsp;System.Windows;&nbsp;
&nbsp;
<span class="cs__keyword">namespace</span>&nbsp;ComboboxEnumBinding&nbsp;
{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__com">///&nbsp;&lt;summary&gt;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__com">///&nbsp;MainWindow.xaml&nbsp;の相互作用ロジック</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__com">///&nbsp;&lt;/summary&gt;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">public</span>&nbsp;partial&nbsp;<span class="cs__keyword">class</span>&nbsp;MainWindow&nbsp;:&nbsp;Window&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">public</span>&nbsp;MainWindow()&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;InitializeComponent();&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">private</span>&nbsp;<span class="cs__keyword">void</span>&nbsp;bttn_SelectRed_Click(<span class="cs__keyword">object</span>&nbsp;sender,&nbsp;RoutedEventArgs&nbsp;e)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;comb_color.SelectedItem&nbsp;=&nbsp;ColorEnum.Red;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">private</span>&nbsp;<span class="cs__keyword">void</span>&nbsp;bttn_ShowSelectedColor_Click(<span class="cs__keyword">object</span>&nbsp;sender,&nbsp;RoutedEventArgs&nbsp;e)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;MessageBox.Show(comb_color.SelectedItem.ToString());&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">public</span>&nbsp;<span class="cs__keyword">enum</span>&nbsp;ColorEnum&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;White&nbsp;=&nbsp;<span class="cs__number">0</span>,&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Blue&nbsp;=&nbsp;<span class="cs__number">1</span>,&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Red&nbsp;=&nbsp;<span class="cs__number">2</span>,&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Black&nbsp;=&nbsp;<span class="cs__number">3</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
}&nbsp;
</pre>
</div>
</div>
</div>
<div class="endscriptcode">&nbsp;&nbsp;</div>
</div>
</div>
</div>
<div class="endscriptcode">ちょっとした手間ですが、これによりバグが発生しにくく、読みやすく保守がしやすいコードを書くことができますので、是非参考にしてみて下さい。<br>
特にコードを書く際にはインテリセンスを使用し、Enumの名前で文字色を確認しながら書けますので、楽に間違いなくコードを書くことができます。</div>
</div>
<div class="endscriptcode"></div>
<div class="endscriptcode">（ヒント）<br>
＃今回のサンプルコードは要点を明らかにするためにMVVMパターンで書いていませんが、通常はMVVMパターンを使用することをお勧めします。<br>
＃データベースにColorの一覧があり、それをデータソースとしてComboBoxにバインドする際にも、そのままでは1や3といったマジックナンバーを設定することになってしまいますので、今回と同じようにEnumを定義し、それを利用するようにすると良いでしょう。Enumからその値を取り出したり、逆に値からEnumに変換する方法は本題から外れますし、いくつか方法がありますのでここではご紹介しませんが、検索すれば簡単に見つかると思います。</div>
