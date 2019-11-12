Public Class Form1

  Public Sub New()
    ' この呼び出しはデザイナーで必要です。
    InitializeComponent()

    ' InitializeComponent() 呼び出しの後で初期化を追加します。
    ToolStripProgressBar1.Value = 0
  End Sub



  ' 進捗なしでバックグラウンド処理
  Private Async Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
    DisableAllButtons()
    ToolStripStatusLabel1.Text = "処理中…"
    ToolStripProgressBar1.Value = 0

    ' 時間のかかる処理をUIスレッドで実行
    ' Dim result As String = DoWork(100)
    ' これではフォームがフリーズしてしまう

    ' 時間のかかる処理を別スレッドで開始
    Dim result As String = Await Task.Run(Function() DoWork(100))

    ' ↑
    ' この間10秒ほど掛かるが、フォームの移動／リサイズなどは可能
    ' ↓

    ' 処理結果の表示
    ToolStripStatusLabel1.Text = result
    ToolStripProgressBar1.Value = 100
    MessageBox.Show("正常に完了")

    EableAllButtons()
  End Sub

  ' 時間のかかる処理を行うメソッド（進捗なし）
  Private Function DoWork(n As Integer) As String
    ' 時間のかかる処理
    For i As Integer = 0 To n - 1
      System.Threading.Thread.Sleep(100)
    Next

    ' このメソッドからの戻り値
    Return "全て完了"
  End Function



  ' 進捗付きのバックグラウンド処理
  Private Async Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
    DisableAllButtons()
    ToolStripStatusLabel1.Text = "処理中…"
    ToolStripProgressBar1.Value = 0

    ' Progressクラスのインスタンスを生成
    Dim p = New Progress(Of Integer)(AddressOf ShowProgress)

    ' 時間のかかる処理を別スレッドで開始
    Dim result As String = Await Task.Run(Function() DoWork(p, 100))

    ' 処理結果の表示
    ToolStripStatusLabel1.Text = result
    ToolStripProgressBar1.Value = 100
    MessageBox.Show("正常に完了")

    EableAllButtons()
  End Sub

  ' 進捗を表示するメソッド（これはUIスレッドで呼び出される）
  Private Sub ShowProgress(percent As Integer)
    ToolStripStatusLabel1.Text = percent & "％完了"
    ToolStripProgressBar1.Value = percent
  End Sub

  ' 時間のかかる処理を行うメソッド（進捗付き）
  Private Function DoWork(progress As IProgress(Of Integer), n As Integer) As String
    ' 別スレッドで実行されるため、このメソッドでは
    ' UI（コントロール）を操作してはいけない

    ' 時間のかかる処理
    For i As Integer = 0 To n - 1
      System.Threading.Thread.Sleep(100)

      Dim percentage As Integer = i * 100 \ n ' 進捗率
      progress.Report(percentage)
    Next

    ' このメソッドからの戻り値
    Return "全て完了"
  End Function




  Private Sub DisableAllButtons()
    Button1.Enabled = False
    Button2.Enabled = False
  End Sub

  Private Sub EableAllButtons()
    Button1.Enabled = True
    Button2.Enabled = True
  End Sub

End Class
