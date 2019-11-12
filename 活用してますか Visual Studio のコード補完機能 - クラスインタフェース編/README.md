# 活用してますか? Visual Studio のコード補完機能 - クラス/インタフェース編
## License
- Apache License, Version 2.0
## Technologies
- Visual Studio 2008
- Visual Studio 2010
## Topics
- 今週の How-To
- Tips
## Updated
- 02/14/2011
## Description

<p>更新日: 2010 年 3 月 29 日</p>
<p>インタフェースの実装クラスや、抽象クラス (abstract class) を継承したクラスを作成する場合、決められたメソッドやプロパティを実装するのは大変面倒な作業です。わざわざドキュメントを調べて、引数や返り値の型などもちゃんと揃えておかなくてはいけません。</p>
<p>例えば以下のコードでは、ICollection インタフェースの CopyTo メソッド、Count プロパティ、さらに (ICollection の) 継承元の IEnumerable インタフェースのメンバーも含め、いくつかのメンバーを実装する必要があります。1 つ 1 つ調べるのは退屈で時間のかかる作業です。</p>
<div style="margin:20px 0px; padding:10px; background-color:#dedfde">
<p>public class Class1 : ICollection<br>
{<br>
}</p>
</div>
<p>このような場合、ICollection を選択して、マウスで右クリックをおこない、[インタフェースの実装] を選択します。実装が必要なメソッドやプロパティのスタブ コードが挿入されるため、あとはゆっくりと中身のロジックだけを実装すれば OK です。</p>
<p><img src="18074-image001.png" alt="図 1" width="500" height="93"></p>
<p>※Visual Basic の場合は、「Implements ICollection」と入力して Enter キーを押すと、実装が必要なスタブ コードが自動生成されます。</p>
<p>また、抽象クラス (abstract class) を継承したクラスの場合は、「override」&#43; Space キーを入力すると、オーバーライド可能なメンバーの一覧がインテリセンスで表示され、選択すると、そのスタブ コードが挿入されます。</p>
<p><img src="18075-image002.png" alt="図 2" width="498" height="291"></p>
<p>※Visual Basic の場合は、「Overrides」と入力してください。</p>
<div style="margin:20px 0px; padding:10px; background-color:#dedfde">
<p>public class Class1 : DictionaryBase<br>
{<br>
&nbsp;&nbsp;&nbsp; // 挿入されたスタブコード<br>
&nbsp;&nbsp;&nbsp; protected override void OnInsert(object key, object value)<br>
&nbsp;&nbsp;&nbsp; {<br>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; base.OnInsert(key, value);&nbsp; // あとは、ここを実装するだけ<br>
&nbsp;&nbsp;&nbsp; }<br>
}</p>
</div>
<p>コード補完機能は、コード品質の維持だけでなく、日々のプログラミングの迅速さ、快適さを与えてくれます。Visual Studio が持つさまざまなコード補完機能を活用して、プログラミングの楽しさを再発見してください。</p>
<hr style="clear:both; margin-bottom:8px; margin-top:20px">
<table>
<tbody>
<tr>
<td><a href="http://msdn.microsoft.com/ja-jp/samplecode.recipe"><img src="-ff950935.coderecipe_180x70%28ja-jp,msdn.10%29.jpg" border="0" alt="Code Recipe" width="180" height="70" style="margin-top:3px"></a></td>
<td>
<ul>
<li>もっと他のコンテンツを見る &gt;&gt; <a href="http://msdn.microsoft.com/ja-jp/ee708292" target="_blank">
今週の How-to 一覧へ</a> </li><li>もっと他のレシピを見る &gt;&gt; <a href="http://msdn.microsoft.com/ja-jp/samplecode.recipe">
Code Recipe へ</a> </li></ul>
</td>
</tr>
</tbody>
</table>
<p style="margin-top:20px"><a href="#top"><img src="-top.gif" border="0" alt="">ページのトップへ</a></p>
