using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CnetSDK.OCR.Trial;

namespace CnetSDKOCR.Demo
{
    class Program
    {
        static void Main(string[] args)
        {
            // Please note:
            // If you choose the x64 platform, please copy the "CnetSDKOCR_Tesseract.dll" and "CnetSDKOCR_Lept.dll"
            // from the x64 folder to the same level path which "CnetSDK.OCR.Trial.dll" in. 
            // Otherwise, please copy from x86 folder.

            // Create an OCR Engine instance
            OcrEngine engine = new OcrEngine();
            // Set the absolute path of tessdata
            engine.TessDataPath = @"F:\\tessdata\";
            // Set the target text language you want to recognize
            //engine.TextLanguage = "eng+deu";
            engine.TextLanguage = "eng";
            // Customized region can be set to OCR the text
            //engine.RecognizeArea = new System.Drawing.Rectangle(100, 100, 200, 200);
            // Recognize text from image file
            string ImageText = engine.PerformOCR(@"F:\CnetSDK.jpg");

            System.Console.WriteLine(ImageText);
            System.Console.ReadKey();
        }
    }
}
