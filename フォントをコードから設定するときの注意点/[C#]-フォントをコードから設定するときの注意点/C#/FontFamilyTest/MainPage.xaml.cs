using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// 基本ページのアイテム テンプレートについては、http://go.microsoft.com/fwlink/?LinkId=234237 を参照してください

namespace FontFamilyTest
{
  /// <summary>
  /// 多くのアプリケーションに共通の特性を指定する基本ページ。
  /// </summary>
  public sealed partial class MainPage : FontFamilyTest.Common.LayoutAwarePage
  {
    public MainPage()
    {
      this.InitializeComponent();
    }

    /// <summary>
    /// このページには、移動中に渡されるコンテンツを設定します。前のセッションからページを
    /// 再作成する場合は、保存状態も指定されます。
    /// </summary>
    /// <param name="navigationParameter">このページが最初に要求されたときに
    /// <see cref="Frame.Navigate(Type, Object)"/> に渡されたパラメーター値。
    /// </param>
    /// <param name="pageState">前のセッションでこのページによって保存された状態の
    /// ディクショナリ。ページに初めてアクセスするとき、状態は null になります。</param>
    protected override void LoadState(Object navigationParameter, Dictionary<String, Object> pageState)
    {
    }

    /// <summary>
    /// アプリケーションが中断される場合、またはページがナビゲーション キャッシュから破棄される場合、
    /// このページに関連付けられた状態を保存します。値は、
    /// <see cref="SuspensionManager.SessionState"/> のシリアル化の要件に準拠する必要があります。
    /// </summary>
    /// <param name="pageState">シリアル化可能な状態で作成される空のディクショナリ。</param>
    protected override void SaveState(Dictionary<String, Object> pageState)
    {
    }

    private async void textbox1_Loaded(object sender, RoutedEventArgs e)
    {
      // TextBox の FontFamily に日本語の名称(例:メイリオ)を設定すると、シンボル系フォントが表示されなくなる
      textbox1.FontFamily = new FontFamily("メイリオ");
      await Task.Yield();
      textbox1.FontFamily = new FontFamily("Wide Latin"); // 英字フォントの指定はOK
      await Task.Yield();
      textbox1.FontFamily = new FontFamily("Wingdings"); // シンボル系フォントの指定はNG (追加入力分には反映される)
      await Task.Yield();
      //textbox1.Text += " "; //コードから文字列を変更してやると、正しいフォントで表示される!
    }

    private async void textblock1_Loaded(object sender, RoutedEventArgs e)
    {
      // TextBlock は問題無い
      textblock1.FontFamily = new FontFamily("メイリオ");
      await Task.Yield();
      textblock1.FontFamily = new FontFamily("Wide Latin");
      await Task.Yield();
      textblock1.FontFamily = new FontFamily("Wingdings");
      await Task.Yield();
    }



    private async void textbox2_Loaded(object sender, RoutedEventArgs e)
    {
      // 英語の名称(例:Meiryo)を使えば大丈夫
      textbox2.FontFamily = new FontFamily("Meiryo");
      await Task.Yield();
      textbox2.FontFamily = new FontFamily("Wide Latin"); 
      await Task.Yield();
      textbox2.FontFamily = new FontFamily("Wingdings"); 
      await Task.Yield();
    }

    private async void textblock2_Loaded(object sender, RoutedEventArgs e)
    {
      // TextBlock は問題無い
      textblock2.FontFamily = new FontFamily("Meiryo");
      await Task.Yield();
      textblock2.FontFamily = new FontFamily("Wide Latin");
      await Task.Yield();
      textblock2.FontFamily = new FontFamily("Wingdings");
      await Task.Yield();
    }
  }
}
