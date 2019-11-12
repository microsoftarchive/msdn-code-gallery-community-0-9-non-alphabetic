using System;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace dotNetTips1121VS2012CS
{
  public partial class Form1 : Form
  {
    public Form1()
    {
      InitializeComponent();
      toolStripProgressBar1.Value = 0;
    }



    // 進捗なしでバックグラウンド処理
    private async void button1_Click(object sender, EventArgs e)
    {
      DisableAllButtons();
      toolStripStatusLabel1.Text = "処理中…";
      toolStripProgressBar1.Value = 0;

      // 時間のかかる処理をUIスレッドで実行
      // string result = DoWork(100);
      // これではフォームがフリーズしてしまう

      // 時間のかかる処理を別スレッドで開始
      string result = await Task.Run(() => DoWork(100));

      // ↑
      // この間10秒ほど掛かるが、フォームの移動／リサイズなどは可能
      // ↓

      // 処理結果の表示
      toolStripStatusLabel1.Text = result;
      toolStripProgressBar1.Value = 100;
      MessageBox.Show("正常に完了");

      EableAllButtons();
    }

    // 時間のかかる処理を行うメソッド（進捗なし）
    private string DoWork(int n)
    {
      // 時間のかかる処理
      for (int i = 1; i <= n; i++)
      {
        System.Threading.Thread.Sleep(100);
      }

      // このメソッドからの戻り値
      return "全て完了";
    }



    // 進捗付きのバックグラウンド処理
    private async void button2_Click(object sender, EventArgs e)
    {
      DisableAllButtons();
      toolStripStatusLabel1.Text = "処理中…";
      toolStripProgressBar1.Value = 0;

      // Progressクラスのインスタンスを生成
      var p = new Progress<int>(ShowProgress);

      // 時間のかかる処理をUIスレッドで実行
      //string result = DoWork(p, 100);
      // これではフォームがフリーズしてしまう

      // 時間のかかる処理を別スレッドで開始
      string result = await Task.Run(() => DoWork(p, 100));

      // 処理結果の表示
      toolStripStatusLabel1.Text = result;
      toolStripProgressBar1.Value = 100;
      MessageBox.Show("正常に完了");

      EableAllButtons();
    }

    // 進捗を表示するメソッド（これはUIスレッドで呼び出される）
    private void ShowProgress(int percent)
    {
      toolStripStatusLabel1.Text = percent + "％完了";
      toolStripProgressBar1.Value = percent;
    }

    // 時間のかかる処理を行うメソッド（進捗付き）
    private string DoWork(IProgress<int> progress, int n)
    {
      // 別スレッドで実行されるため、このメソッドでは
      // UI（コントロール）を操作してはいけない

      // 時間のかかる処理
      for (int i = 1; i <= n; i++)
      {
        System.Threading.Thread.Sleep(100);

        int percentage = i * 100 / n; // 進捗率
        progress.Report(percentage);
      }

      // このメソッドからの戻り値
      return "全て完了";
    }




    private void DisableAllButtons()
    {
      button1.Enabled = false;
      button2.Enabled = false;
    }

    private void EableAllButtons()
    {
      button1.Enabled = true;
      button2.Enabled = true;
    }


  }
}
