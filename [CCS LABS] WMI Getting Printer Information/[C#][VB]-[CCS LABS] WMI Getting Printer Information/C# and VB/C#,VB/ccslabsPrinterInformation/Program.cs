using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Management;

namespace ccslabsPrinterInformation
{
    class Program
    {
        static void Main(string[] args)
        {

            try
            {
                ManagementObjectSearcher searcher =
                   new ManagementObjectSearcher("root\\CIMV2",
                   "SELECT * FROM Win32_Printer");

                foreach (ManagementObject queryObj in searcher.Get())
                {
                    Console.WriteLine("-----------------------------------");
                    Console.WriteLine("Win32_Printer instance");
                    Console.WriteLine("-----------------------------------");
                    Console.WriteLine("Attributes: {0}", queryObj["Attributes"]);
                    Console.WriteLine("Availability: {0}", queryObj["Availability"]);

                    if (queryObj["AvailableJobSheets"] == null)
                        Console.WriteLine("AvailableJobSheets: {0}", queryObj["AvailableJobSheets"]);
                    else
                    {
                        String[] arrAvailableJobSheets = (String[])(queryObj["AvailableJobSheets"]);
                        foreach (String arrValue in arrAvailableJobSheets)
                        {
                            Console.WriteLine("AvailableJobSheets: {0}", arrValue);
                        }
                    }
                    Console.WriteLine("AveragePagesPerMinute: {0}", queryObj["AveragePagesPerMinute"]);

                    if (queryObj["Capabilities"] == null)
                        Console.WriteLine("Capabilities: {0}", queryObj["Capabilities"]);
                    else
                    {
                        UInt16[] arrCapabilities = (UInt16[])(queryObj["Capabilities"]);
                        foreach (UInt16 arrValue in arrCapabilities)
                        {
                            Console.WriteLine("Capabilities: {0}", arrValue);
                        }
                    }

                    if (queryObj["CapabilityDescriptions"] == null)
                        Console.WriteLine("CapabilityDescriptions: {0}", queryObj["CapabilityDescriptions"]);
                    else
                    {
                        String[] arrCapabilityDescriptions = (String[])(queryObj["CapabilityDescriptions"]);
                        foreach (String arrValue in arrCapabilityDescriptions)
                        {
                            Console.WriteLine("CapabilityDescriptions: {0}", arrValue);
                        }
                    }
                    Console.WriteLine("Caption: {0}", queryObj["Caption"]);

                    if (queryObj["CharSetsSupported"] == null)
                        Console.WriteLine("CharSetsSupported: {0}", queryObj["CharSetsSupported"]);
                    else
                    {
                        String[] arrCharSetsSupported = (String[])(queryObj["CharSetsSupported"]);
                        foreach (String arrValue in arrCharSetsSupported)
                        {
                            Console.WriteLine("CharSetsSupported: {0}", arrValue);
                        }
                    }
                    Console.WriteLine("Comment: {0}", queryObj["Comment"]);
                    Console.WriteLine("ConfigManagerErrorCode: {0}", queryObj["ConfigManagerErrorCode"]);
                    Console.WriteLine("ConfigManagerUserConfig: {0}", queryObj["ConfigManagerUserConfig"]);
                    Console.WriteLine("CreationClassName: {0}", queryObj["CreationClassName"]);

                    if (queryObj["CurrentCapabilities"] == null)
                        Console.WriteLine("CurrentCapabilities: {0}", queryObj["CurrentCapabilities"]);
                    else
                    {
                        UInt16[] arrCurrentCapabilities = (UInt16[])(queryObj["CurrentCapabilities"]);
                        foreach (UInt16 arrValue in arrCurrentCapabilities)
                        {
                            Console.WriteLine("CurrentCapabilities: {0}", arrValue);
                        }
                    }
                    Console.WriteLine("CurrentCharSet: {0}", queryObj["CurrentCharSet"]);
                    Console.WriteLine("CurrentLanguage: {0}", queryObj["CurrentLanguage"]);
                    Console.WriteLine("CurrentMimeType: {0}", queryObj["CurrentMimeType"]);
                    Console.WriteLine("CurrentNaturalLanguage: {0}", queryObj["CurrentNaturalLanguage"]);
                    Console.WriteLine("CurrentPaperType: {0}", queryObj["CurrentPaperType"]);
                    Console.WriteLine("Default: {0}", queryObj["Default"]);

                    if (queryObj["DefaultCapabilities"] == null)
                        Console.WriteLine("DefaultCapabilities: {0}", queryObj["DefaultCapabilities"]);
                    else
                    {
                        UInt16[] arrDefaultCapabilities = (UInt16[])(queryObj["DefaultCapabilities"]);
                        foreach (UInt16 arrValue in arrDefaultCapabilities)
                        {
                            Console.WriteLine("DefaultCapabilities: {0}", arrValue);
                        }
                    }
                    Console.WriteLine("DefaultCopies: {0}", queryObj["DefaultCopies"]);
                    Console.WriteLine("DefaultLanguage: {0}", queryObj["DefaultLanguage"]);
                    Console.WriteLine("DefaultMimeType: {0}", queryObj["DefaultMimeType"]);
                    Console.WriteLine("DefaultNumberUp: {0}", queryObj["DefaultNumberUp"]);
                    Console.WriteLine("DefaultPaperType: {0}", queryObj["DefaultPaperType"]);
                    Console.WriteLine("DefaultPriority: {0}", queryObj["DefaultPriority"]);
                    Console.WriteLine("Description: {0}", queryObj["Description"]);
                    Console.WriteLine("DetectedErrorState: {0}", queryObj["DetectedErrorState"]);
                    Console.WriteLine("DeviceID: {0}", queryObj["DeviceID"]);
                    Console.WriteLine("Direct: {0}", queryObj["Direct"]);
                    Console.WriteLine("DoCompleteFirst: {0}", queryObj["DoCompleteFirst"]);
                    Console.WriteLine("DriverName: {0}", queryObj["DriverName"]);
                    Console.WriteLine("EnableBIDI: {0}", queryObj["EnableBIDI"]);
                    Console.WriteLine("EnableDevQueryPrint: {0}", queryObj["EnableDevQueryPrint"]);
                    Console.WriteLine("ErrorCleared: {0}", queryObj["ErrorCleared"]);
                    Console.WriteLine("ErrorDescription: {0}", queryObj["ErrorDescription"]);

                    if (queryObj["ErrorInformation"] == null)
                        Console.WriteLine("ErrorInformation: {0}", queryObj["ErrorInformation"]);
                    else
                    {
                        String[] arrErrorInformation = (String[])(queryObj["ErrorInformation"]);
                        foreach (String arrValue in arrErrorInformation)
                        {
                            Console.WriteLine("ErrorInformation: {0}", arrValue);
                        }
                    }
                    Console.WriteLine("ExtendedDetectedErrorState: {0}", queryObj["ExtendedDetectedErrorState"]);
                    Console.WriteLine("ExtendedPrinterStatus: {0}", queryObj["ExtendedPrinterStatus"]);
                    Console.WriteLine("Hidden: {0}", queryObj["Hidden"]);
                    Console.WriteLine("HorizontalResolution: {0}", queryObj["HorizontalResolution"]);
                    Console.WriteLine("InstallDate: {0}", queryObj["InstallDate"]);
                    Console.WriteLine("JobCountSinceLastReset: {0}", queryObj["JobCountSinceLastReset"]);
                    Console.WriteLine("KeepPrintedJobs: {0}", queryObj["KeepPrintedJobs"]);

                    if (queryObj["LanguagesSupported"] == null)
                        Console.WriteLine("LanguagesSupported: {0}", queryObj["LanguagesSupported"]);
                    else
                    {
                        UInt16[] arrLanguagesSupported = (UInt16[])(queryObj["LanguagesSupported"]);
                        foreach (UInt16 arrValue in arrLanguagesSupported)
                        {
                            Console.WriteLine("LanguagesSupported: {0}", arrValue);
                        }
                    }
                    Console.WriteLine("LastErrorCode: {0}", queryObj["LastErrorCode"]);
                    Console.WriteLine("Local: {0}", queryObj["Local"]);
                    Console.WriteLine("Location: {0}", queryObj["Location"]);
                    Console.WriteLine("MarkingTechnology: {0}", queryObj["MarkingTechnology"]);
                    Console.WriteLine("MaxCopies: {0}", queryObj["MaxCopies"]);
                    Console.WriteLine("MaxNumberUp: {0}", queryObj["MaxNumberUp"]);
                    Console.WriteLine("MaxSizeSupported: {0}", queryObj["MaxSizeSupported"]);

                    if (queryObj["MimeTypesSupported"] == null)
                        Console.WriteLine("MimeTypesSupported: {0}", queryObj["MimeTypesSupported"]);
                    else
                    {
                        String[] arrMimeTypesSupported = (String[])(queryObj["MimeTypesSupported"]);
                        foreach (String arrValue in arrMimeTypesSupported)
                        {
                            Console.WriteLine("MimeTypesSupported: {0}", arrValue);
                        }
                    }
                    Console.WriteLine("Name: {0}", queryObj["Name"]);

                    if (queryObj["NaturalLanguagesSupported"] == null)
                        Console.WriteLine("NaturalLanguagesSupported: {0}", queryObj["NaturalLanguagesSupported"]);
                    else
                    {
                        String[] arrNaturalLanguagesSupported = (String[])(queryObj["NaturalLanguagesSupported"]);
                        foreach (String arrValue in arrNaturalLanguagesSupported)
                        {
                            Console.WriteLine("NaturalLanguagesSupported: {0}", arrValue);
                        }
                    }
                    Console.WriteLine("Network: {0}", queryObj["Network"]);

                    if (queryObj["PaperSizesSupported"] == null)
                        Console.WriteLine("PaperSizesSupported: {0}", queryObj["PaperSizesSupported"]);
                    else
                    {
                        UInt16[] arrPaperSizesSupported = (UInt16[])(queryObj["PaperSizesSupported"]);
                        foreach (UInt16 arrValue in arrPaperSizesSupported)
                        {
                            Console.WriteLine("PaperSizesSupported: {0}", arrValue);
                        }
                    }

                    if (queryObj["PaperTypesAvailable"] == null)
                        Console.WriteLine("PaperTypesAvailable: {0}", queryObj["PaperTypesAvailable"]);
                    else
                    {
                        String[] arrPaperTypesAvailable = (String[])(queryObj["PaperTypesAvailable"]);
                        foreach (String arrValue in arrPaperTypesAvailable)
                        {
                            Console.WriteLine("PaperTypesAvailable: {0}", arrValue);
                        }
                    }
                    Console.WriteLine("Parameters: {0}", queryObj["Parameters"]);
                    Console.WriteLine("PNPDeviceID: {0}", queryObj["PNPDeviceID"]);
                    Console.WriteLine("PortName: {0}", queryObj["PortName"]);

                    if (queryObj["PowerManagementCapabilities"] == null)
                        Console.WriteLine("PowerManagementCapabilities: {0}", queryObj["PowerManagementCapabilities"]);
                    else
                    {
                        UInt16[] arrPowerManagementCapabilities = (UInt16[])(queryObj["PowerManagementCapabilities"]);
                        foreach (UInt16 arrValue in arrPowerManagementCapabilities)
                        {
                            Console.WriteLine("PowerManagementCapabilities: {0}", arrValue);
                        }
                    }
                    Console.WriteLine("PowerManagementSupported: {0}", queryObj["PowerManagementSupported"]);

                    if (queryObj["PrinterPaperNames"] == null)
                        Console.WriteLine("PrinterPaperNames: {0}", queryObj["PrinterPaperNames"]);
                    else
                    {
                        String[] arrPrinterPaperNames = (String[])(queryObj["PrinterPaperNames"]);
                        foreach (String arrValue in arrPrinterPaperNames)
                        {
                            Console.WriteLine("PrinterPaperNames: {0}", arrValue);
                        }
                    }
                    Console.WriteLine("PrinterState: {0}", queryObj["PrinterState"]);
                    Console.WriteLine("PrinterStatus: {0}", queryObj["PrinterStatus"]);
                    Console.WriteLine("PrintJobDataType: {0}", queryObj["PrintJobDataType"]);
                    Console.WriteLine("PrintProcessor: {0}", queryObj["PrintProcessor"]);
                    Console.WriteLine("Priority: {0}", queryObj["Priority"]);
                    Console.WriteLine("Published: {0}", queryObj["Published"]);
                    Console.WriteLine("Queued: {0}", queryObj["Queued"]);
                    Console.WriteLine("RawOnly: {0}", queryObj["RawOnly"]);
                    Console.WriteLine("SeparatorFile: {0}", queryObj["SeparatorFile"]);
                    Console.WriteLine("ServerName: {0}", queryObj["ServerName"]);
                    Console.WriteLine("Shared: {0}", queryObj["Shared"]);
                    Console.WriteLine("ShareName: {0}", queryObj["ShareName"]);
                    Console.WriteLine("SpoolEnabled: {0}", queryObj["SpoolEnabled"]);
                    Console.WriteLine("StartTime: {0}", queryObj["StartTime"]);
                    Console.WriteLine("Status: {0}", queryObj["Status"]);
                    Console.WriteLine("StatusInfo: {0}", queryObj["StatusInfo"]);
                    Console.WriteLine("SystemCreationClassName: {0}", queryObj["SystemCreationClassName"]);
                    Console.WriteLine("SystemName: {0}", queryObj["SystemName"]);
                    Console.WriteLine("TimeOfLastReset: {0}", queryObj["TimeOfLastReset"]);
                    Console.WriteLine("UntilTime: {0}", queryObj["UntilTime"]);
                    Console.WriteLine("VerticalResolution: {0}", queryObj["VerticalResolution"]);
                    Console.WriteLine("WorkOffline: {0}", queryObj["WorkOffline"]);
                }


            }
            catch (ManagementException e)
            {
                Console.WriteLine("An error occurred while querying for WMI data: " + e.Message);
            }

            Console.WriteLine();
            Console.WriteLine("Press any key to quit");
            Console.ReadKey();

        }
    }
}
