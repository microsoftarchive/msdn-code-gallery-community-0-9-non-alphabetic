using System;
using System.Collections.Generic;
using System.Text;
using CnetSDK.Barcode.Generator.Trial;
using System.Drawing.Imaging;

namespace BarcodeCreatorDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            CSBarcode barcode = new CSBarcode();

            barcode.BarcodeType = CSBarcodeType.QRCode;
            
            barcode.BarcodeData = "www.cnetsdk.com";

            barcode.BarcodeWidth = 200;
            barcode.BarcodeHeight = 200;

            barcode.QRCodeErrorCorrectionLevel = ECLMode.L;

            barcode.CSPictureFormat = ImageFormat.Jpeg;

            barcode.CreateBarcode("CnetSDK.jpeg");

        }
    }
}
