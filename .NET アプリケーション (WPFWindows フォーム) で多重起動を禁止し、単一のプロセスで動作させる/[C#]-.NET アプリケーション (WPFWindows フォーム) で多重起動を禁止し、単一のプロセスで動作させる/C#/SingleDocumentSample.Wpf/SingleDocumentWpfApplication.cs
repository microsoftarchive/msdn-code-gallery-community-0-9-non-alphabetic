using System;
using System.Windows;
using System.Windows.Threading;

namespace SingleDocumentSample.Wpf
{
    // WPF 多重起動防止アプリケーション
    public class SingleDocumentApplication : Application
    {
        // WPF 用の ITicker の実装
        // 指定された時間毎に Tick イベントが起きる
        class Ticker : SingleDocumentHelper.ITicker
        {
            public event Action Tick;

            public const int DefaultInterval = 1000;
            readonly DispatcherTimer timer;

            public Ticker(int interval = DefaultInterval)
            { timer = new DispatcherTimer { Interval = TimeSpan.FromMilliseconds(interval) }; }

            public void Start()
            {
                // DispatcherTimer を使用して定期的に Tick イベントを起こす
                timer.Tick += (sender, e) => RaiseTick();
                timer.Start();
            }

            public void Dispose()
            { timer.Stop(); }

            void RaiseTick()
            {
                if (Tick != null)
                    Tick();
            }
        }

        public event Action<string> OpenDocument;

        readonly SingleDocumentHelper.Application singleDocumentApplication = new SingleDocumentHelper.Application();
        string documentPath = null;

        protected string DocumentPath
        {
            get { return documentPath; }
            set {
                documentPath = value;
                if (OpenDocument != null)
                    OpenDocument(value); // ドキュメントを開く
            }
        }

        public SingleDocumentApplication(Window mainWindow)
        { MainWindow = mainWindow; }

        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);

            if (e.Args.Length > 0) // コマンドライン引数があれば
                DocumentPath = e.Args[0]; // ドキュメント ファイルのパスとする

            if (singleDocumentApplication.Initialize(new Ticker(), DocumentPath, sourcePath => DocumentPath = sourcePath))
                MainWindow.Show();
            else
                Shutdown(); // 他のプロセスが既に起動していれば終了
        }

        protected override void OnExit(ExitEventArgs e)
        {
            singleDocumentApplication.Dispose();
            base.OnExit(e);
        }
    }
}
