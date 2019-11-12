using System;

namespace SingleDocumentSample.WinForm
{
    static class Program
    {
        [STAThread]
        static void Main()
        {
            var application = new SingleDocumentApplication();
            var mainForm    = new MainForm();
            application.OpenDocument += documentPath => mainForm.DocumentPath = documentPath;
            application.Run(mainForm);
        }
    }
}
