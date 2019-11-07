using System;
using System.Collections.Generic;
using System.Text;
using CnetSDK.Barcode.Scanner.Trial;

namespace BarcodeScannerDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            //ScanOnlyBarcode();
            //SpecifyBarcodeType();
            ScanMultipleBarcodes();

        }

        public static void ScanOnlyBarcode()
        {
            ScanResult result = CSBarcodeScanner.ScanOnlyBarcode("CnetSDK.png");
            Console.WriteLine(result.BarcodeType.ToString() + "--" + result.BarcodeData);
            Console.ReadKey();
        }

        public static void ScanMultipleBarcodes()
        {
            ScanResult[] results = CSBarcodeScanner.ScanBarcode("CnetSDK.jpg");

            foreach (ScanResult result in results)
            {
                Console.WriteLine(result.BarcodeType.ToString() + "--" + result.BarcodeData);
            }

            Console.ReadKey();
        }


        public static void SpecifyBarcodeType()
        {
            ScanResult[] results = CSBarcodeScanner.ScanBarcode("CnetSDK.jpg", CSBarcodeType.QRCode);
            foreach (ScanResult result in results)
            {
                Console.WriteLine(result.BarcodeType.ToString() + "-" + result.BarcodeData);
            }

            Console.ReadKey();
        }

    }
}
