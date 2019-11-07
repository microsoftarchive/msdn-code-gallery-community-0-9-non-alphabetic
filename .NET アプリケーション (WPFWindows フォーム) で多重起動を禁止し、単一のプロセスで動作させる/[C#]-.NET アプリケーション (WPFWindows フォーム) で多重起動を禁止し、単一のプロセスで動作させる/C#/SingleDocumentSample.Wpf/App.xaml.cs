using System.Windows;

namespace SingleDocumentSample.Wpf
{
    partial class App : SingleDocumentApplication
    {
        public App()
            : base(new MainWindow())
        { OpenDocument += sourcePath => ((MainWindow)MainWindow).DocumentPath = sourcePath; }
    }
}
