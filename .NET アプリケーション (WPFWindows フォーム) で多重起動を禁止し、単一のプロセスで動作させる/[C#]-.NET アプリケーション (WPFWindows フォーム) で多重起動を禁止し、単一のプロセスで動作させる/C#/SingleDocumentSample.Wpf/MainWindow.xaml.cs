using System;
using System.Windows;

namespace SingleDocumentSample.Wpf
{
    partial class MainWindow : Window
    {
        public string DocumentPath
        {
            get { return browser.Source == null ? null : browser.Source.AbsolutePath; }
            set {
                browser.Source = new Uri(value, UriKind.RelativeOrAbsolute);
                Title          = value;
                ToTop();
            }
        }

        public MainWindow()
        { InitializeComponent(); }

        // ウィンドウを最前面に表示
        void ToTop()
        {
            if (WindowState == WindowState.Minimized)
                WindowState = WindowState.Normal;
            Activate();
        }
    }
}
