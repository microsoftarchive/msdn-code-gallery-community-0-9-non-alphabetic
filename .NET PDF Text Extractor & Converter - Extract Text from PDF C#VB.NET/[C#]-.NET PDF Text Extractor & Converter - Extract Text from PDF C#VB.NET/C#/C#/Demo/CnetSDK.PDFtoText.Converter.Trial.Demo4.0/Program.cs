using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CnetSDK.PDFtoText.Converter.Trial;

namespace PDFToText4._0
{
    class Program
    {
        static void Main(string[] args)
        {
            GetEachPageText();
            //GetWholePageText();
            //SaveTextToFile();
        }

        static void GetEachPageText()
        {
            CSPdfExtractor extractor = new CSPdfExtractor();
            extractor.LoadPdfFile("f://test1.pdf");

            int count = extractor.FilePageCount;

            for (int i = 0; i < count; i++)
            {
                String text = extractor.ConvertToText(i);
                Console.WriteLine(text);
            }
            Console.ReadKey();
        }

        static void GetWholePageText()
        {
            CSPdfExtractor extractor = new CSPdfExtractor();
            extractor.LoadPdfFile("f://test1.pdf");

            string text = extractor.ConvertToText();
            Console.WriteLine(text);
            Console.ReadKey();
        }

        static void SaveTextToFile()
        {
            CSPdfExtractor extractor = new CSPdfExtractor();
            extractor.LoadPdfFile("f://test3.pdf");

            extractor.ConvertToTextFile("f://output.txt");
        }

    }
}
