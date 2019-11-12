using System;
using System.Windows.Forms;

namespace SingleDocumentSample.WinForm
{
    class SingleDocumentApplication
    {
        // ウィンドウズ フォーム用の ITicker の実装
        // 指定された時間毎に Tick イベントが起きる
        class Ticker : SingleDocumentHelper.ITicker
        {
            public event Action Tick;

            public const int DefaultInterval = 1000;
            readonly Timer timer;

            public Ticker(int interval = DefaultInterval)
            { timer = new Timer { Interval = interval }; }

            public void Start()
            {
                // Timer を使用して定期的に Tick イベントを起こす
                timer.Tick += (sender, e) => RaiseTick();
                timer.Start();
            }

            public void Dispose()
            { timer.Dispose(); }

            void RaiseTick()
            {
                if (Tick != null)
                    Tick();
            }
        }

        public event Action<string> OpenDocument;

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

        public bool Run(Form mainForm)
        {
            var commandLineArgs = Environment.GetCommandLineArgs();
            if (commandLineArgs.Length > 1) // コマンドライン引数があれば
                DocumentPath = commandLineArgs[1]; // ドキュメント ファイルのパスとする

            using (var singleDocumentApplication = new SingleDocumentHelper.Application()) {
                if (singleDocumentApplication.Initialize(new Ticker(), DocumentPath, sourcePath => DocumentPath = sourcePath)) {
                    Application.Run(mainForm);
                    return true;
                }
                return false; // 他のプロセスが既に起動していれば終了
            }
        }
    }
}
