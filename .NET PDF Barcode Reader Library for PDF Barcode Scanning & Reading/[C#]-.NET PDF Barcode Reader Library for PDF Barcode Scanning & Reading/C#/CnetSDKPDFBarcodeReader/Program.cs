using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using System.Drawing.Imaging;
using CnetSDK.PDFBarcode.Reader.Trial;
using CnetSDK.PDFBarcode.Reader.Trial.Pdf;

namespace CnetSDKPDFBarcodeReader
{
    class Program
    {
        static void Main(string[] args)
        {
            ReadOneBarcodeTypeFromOnePdfPage();
            //ReadMultipleBarcodeTypesFromOnePdfPage();                        
            //ReadOneBarcodeTypeFromMultiplePdfPages();
            //ReadMultipleBarcodeTypesFromMultiplePdfPages();
        }

        public static void ReadOneBarcodeTypeFromOnePdfPage()
        {
            PdfFile pdf = new PdfFile("test.pdf");
            pdf.SetDPI = 72;
            Image pageImage = pdf.ConvertToImage(0, 1000, 1000);
            Bitmap bitmap = new Bitmap(pageImage);
            string[] data = PdfBarcodeReader.Recognize(bitmap, PdfBarcodeReader.Code128);
            foreach (string result in data)
            {
                Console.WriteLine(result);
            }
            Console.ReadKey();
        }

        public static void ReadMultipleBarcodeTypesFromOnePdfPage()
        {
            PdfFile pdf = new PdfFile("test1.pdf");
            pdf.SetDPI = 72;
            Image pageImage = pdf.ConvertToImage(0, 1000, 1200);
            Bitmap bitmap = new Bitmap(pageImage);            
            string[] data = PdfBarcodeReader.Recognize(bitmap, PdfBarcodeReader.Code128);
            foreach (string result in data)
            {
                Console.WriteLine(result);
            }
            string[] data1 = PdfBarcodeReader.Recognize(bitmap, PdfBarcodeReader.Qrcode);
            foreach (string result in data1)
            {
                Console.WriteLine(result);
            }
            Console.ReadKey();
        }

        public static void ReadOneBarcodeTypeFromMultiplePdfPages()
        {
            PdfFile pdf = new PdfFile("test2.pdf");
            pdf.SetDPI = 72;
            for (int i = 0; i < pdf.FilePageCount; i++)
            {
                Image pageImage = pdf.ConvertToImage(i, 1000, 1200);                
                Bitmap bitmap = new Bitmap(pageImage);
                //pageImage.Save("Page" + i + ".jpg", ImageFormat.Jpeg);
                string[] data = PdfBarcodeReader.Recognize(bitmap, PdfBarcodeReader.Qrcode);
                foreach (string result in data)
                {
                    Console.WriteLine(result);
                }
            }
            Console.ReadKey();
        }

        public static void ReadMultipleBarcodeTypesFromMultiplePdfPages()
        {
            PdfFile pdf = new PdfFile("test3.pdf");
            pdf.SetDPI = 72;
            for (int i = 0; i < pdf.FilePageCount; i++)
            {
                Image pageImage = pdf.ConvertToImage(i, 1000, 1200);
                //Bitmap bitmap = new Bitmap(pageImage);
                pageImage.Save("Page" + i + ".jpg", ImageFormat.Jpeg);
                string[] data = PdfBarcodeReader.Recognize("Page" + i + ".jpg", PdfBarcodeReader.Code128);
                foreach (string result in data)
                {
                    Console.WriteLine(result);
                }

                string[] data1 = PdfBarcodeReader.Recognize("Page" + i + ".jpg", PdfBarcodeReader.Qrcode);
                foreach (string result in data1)
                {
                    Console.WriteLine(result);
                }
            }
            Console.ReadKey();
        }
    }
}
