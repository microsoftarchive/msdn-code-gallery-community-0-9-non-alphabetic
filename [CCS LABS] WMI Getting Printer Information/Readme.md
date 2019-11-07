# [CCS LABS] WMI: Getting Printer Information
## Requires
- Visual Studio 2010
## License
- MS-LPL
## Technologies
- WMI
- LINQ
- printer
## Topics
- System Information
- Printers
## Updated
- 10/09/2012
## Description

<h1>Introduction</h1>
<p><em>It is sometimes necessary to discover Information about the computer&rsquo;s Printer. Thanks to .Net this is a very easy thing to do. In this example we will get a large amount of data concerning the currently attached device.</em></p>
<h1><span>Building the Sample</span></h1>
<p><em>This was written in Visual Studio 2010 on a Windows Server 2012 x64 machine so should run on any appropriately configured Windows XP or better machine. Visual Basic and C# code is included.</em></p>
<p><span style="font-size:20px; font-weight:bold">Description</span></p>
<p>We use the <a title="Auto generated link to System.Management" href="http://msdn.microsoft.com/en-US/library/System.Management.aspx" target="_blank">
System.Management</a> reference to access WMI functionality which allows us to access low level information without having to write copious amounts of code. As you can see from the following snippet there is a great deal of information that can be easily and
 quickly gathered.</p>
<p>&nbsp;</p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>C#</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">csharp</span>
<pre class="hidden">using System;
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
                   new ManagementObjectSearcher(&quot;root\\CIMV2&quot;,
                   &quot;SELECT * FROM Win32_Printer&quot;);

                foreach (ManagementObject queryObj in searcher.Get())
                {
                    Console.WriteLine(&quot;-----------------------------------&quot;);
                    Console.WriteLine(&quot;Win32_Printer instance&quot;);
                    Console.WriteLine(&quot;-----------------------------------&quot;);
                    Console.WriteLine(&quot;Attributes: {0}&quot;, queryObj[&quot;Attributes&quot;]);
                    Console.WriteLine(&quot;Availability: {0}&quot;, queryObj[&quot;Availability&quot;]);

                    if (queryObj[&quot;AvailableJobSheets&quot;] == null)
                        Console.WriteLine(&quot;AvailableJobSheets: {0}&quot;, queryObj[&quot;AvailableJobSheets&quot;]);
                    else
                    {
                        String[] arrAvailableJobSheets = (String[])(queryObj[&quot;AvailableJobSheets&quot;]);
                        foreach (String arrValue in arrAvailableJobSheets)
                        {
                            Console.WriteLine(&quot;AvailableJobSheets: {0}&quot;, arrValue);
                        }
                    }
                    Console.WriteLine(&quot;AveragePagesPerMinute: {0}&quot;, queryObj[&quot;AveragePagesPerMinute&quot;]);

                    if (queryObj[&quot;Capabilities&quot;] == null)
                        Console.WriteLine(&quot;Capabilities: {0}&quot;, queryObj[&quot;Capabilities&quot;]);
                    else
                    {
                        UInt16[] arrCapabilities = (UInt16[])(queryObj[&quot;Capabilities&quot;]);
                        foreach (UInt16 arrValue in arrCapabilities)
                        {
                            Console.WriteLine(&quot;Capabilities: {0}&quot;, arrValue);
                        }
                    }

                    if (queryObj[&quot;CapabilityDescriptions&quot;] == null)
                        Console.WriteLine(&quot;CapabilityDescriptions: {0}&quot;, queryObj[&quot;CapabilityDescriptions&quot;]);
                    else
                    {
                        String[] arrCapabilityDescriptions = (String[])(queryObj[&quot;CapabilityDescriptions&quot;]);
                        foreach (String arrValue in arrCapabilityDescriptions)
                        {
                            Console.WriteLine(&quot;CapabilityDescriptions: {0}&quot;, arrValue);
                        }
                    }
                    Console.WriteLine(&quot;Caption: {0}&quot;, queryObj[&quot;Caption&quot;]);

                    if (queryObj[&quot;CharSetsSupported&quot;] == null)
                        Console.WriteLine(&quot;CharSetsSupported: {0}&quot;, queryObj[&quot;CharSetsSupported&quot;]);
                    else
                    {
                        String[] arrCharSetsSupported = (String[])(queryObj[&quot;CharSetsSupported&quot;]);
                        foreach (String arrValue in arrCharSetsSupported)
                        {
                            Console.WriteLine(&quot;CharSetsSupported: {0}&quot;, arrValue);
                        }
                    }
                    Console.WriteLine(&quot;Comment: {0}&quot;, queryObj[&quot;Comment&quot;]);
                    Console.WriteLine(&quot;ConfigManagerErrorCode: {0}&quot;, queryObj[&quot;ConfigManagerErrorCode&quot;]);
                    Console.WriteLine(&quot;ConfigManagerUserConfig: {0}&quot;, queryObj[&quot;ConfigManagerUserConfig&quot;]);
                    Console.WriteLine(&quot;CreationClassName: {0}&quot;, queryObj[&quot;CreationClassName&quot;]);

                    if (queryObj[&quot;CurrentCapabilities&quot;] == null)
                        Console.WriteLine(&quot;CurrentCapabilities: {0}&quot;, queryObj[&quot;CurrentCapabilities&quot;]);
                    else
                    {
                        UInt16[] arrCurrentCapabilities = (UInt16[])(queryObj[&quot;CurrentCapabilities&quot;]);
                        foreach (UInt16 arrValue in arrCurrentCapabilities)
                        {
                            Console.WriteLine(&quot;CurrentCapabilities: {0}&quot;, arrValue);
                        }
                    }
                    Console.WriteLine(&quot;CurrentCharSet: {0}&quot;, queryObj[&quot;CurrentCharSet&quot;]);
                    Console.WriteLine(&quot;CurrentLanguage: {0}&quot;, queryObj[&quot;CurrentLanguage&quot;]);
                    Console.WriteLine(&quot;CurrentMimeType: {0}&quot;, queryObj[&quot;CurrentMimeType&quot;]);
                    Console.WriteLine(&quot;CurrentNaturalLanguage: {0}&quot;, queryObj[&quot;CurrentNaturalLanguage&quot;]);
                    Console.WriteLine(&quot;CurrentPaperType: {0}&quot;, queryObj[&quot;CurrentPaperType&quot;]);
                    Console.WriteLine(&quot;Default: {0}&quot;, queryObj[&quot;Default&quot;]);

                    if (queryObj[&quot;DefaultCapabilities&quot;] == null)
                        Console.WriteLine(&quot;DefaultCapabilities: {0}&quot;, queryObj[&quot;DefaultCapabilities&quot;]);
                    else
                    {
                        UInt16[] arrDefaultCapabilities = (UInt16[])(queryObj[&quot;DefaultCapabilities&quot;]);
                        foreach (UInt16 arrValue in arrDefaultCapabilities)
                        {
                            Console.WriteLine(&quot;DefaultCapabilities: {0}&quot;, arrValue);
                        }
                    }
                    Console.WriteLine(&quot;DefaultCopies: {0}&quot;, queryObj[&quot;DefaultCopies&quot;]);
                    Console.WriteLine(&quot;DefaultLanguage: {0}&quot;, queryObj[&quot;DefaultLanguage&quot;]);
                    Console.WriteLine(&quot;DefaultMimeType: {0}&quot;, queryObj[&quot;DefaultMimeType&quot;]);
                    Console.WriteLine(&quot;DefaultNumberUp: {0}&quot;, queryObj[&quot;DefaultNumberUp&quot;]);
                    Console.WriteLine(&quot;DefaultPaperType: {0}&quot;, queryObj[&quot;DefaultPaperType&quot;]);
                    Console.WriteLine(&quot;DefaultPriority: {0}&quot;, queryObj[&quot;DefaultPriority&quot;]);
                    Console.WriteLine(&quot;Description: {0}&quot;, queryObj[&quot;Description&quot;]);
                    Console.WriteLine(&quot;DetectedErrorState: {0}&quot;, queryObj[&quot;DetectedErrorState&quot;]);
                    Console.WriteLine(&quot;DeviceID: {0}&quot;, queryObj[&quot;DeviceID&quot;]);
                    Console.WriteLine(&quot;Direct: {0}&quot;, queryObj[&quot;Direct&quot;]);
                    Console.WriteLine(&quot;DoCompleteFirst: {0}&quot;, queryObj[&quot;DoCompleteFirst&quot;]);
                    Console.WriteLine(&quot;DriverName: {0}&quot;, queryObj[&quot;DriverName&quot;]);
                    Console.WriteLine(&quot;EnableBIDI: {0}&quot;, queryObj[&quot;EnableBIDI&quot;]);
                    Console.WriteLine(&quot;EnableDevQueryPrint: {0}&quot;, queryObj[&quot;EnableDevQueryPrint&quot;]);
                    Console.WriteLine(&quot;ErrorCleared: {0}&quot;, queryObj[&quot;ErrorCleared&quot;]);
                    Console.WriteLine(&quot;ErrorDescription: {0}&quot;, queryObj[&quot;ErrorDescription&quot;]);

                    if (queryObj[&quot;ErrorInformation&quot;] == null)
                        Console.WriteLine(&quot;ErrorInformation: {0}&quot;, queryObj[&quot;ErrorInformation&quot;]);
                    else
                    {
                        String[] arrErrorInformation = (String[])(queryObj[&quot;ErrorInformation&quot;]);
                        foreach (String arrValue in arrErrorInformation)
                        {
                            Console.WriteLine(&quot;ErrorInformation: {0}&quot;, arrValue);
                        }
                    }
                    Console.WriteLine(&quot;ExtendedDetectedErrorState: {0}&quot;, queryObj[&quot;ExtendedDetectedErrorState&quot;]);
                    Console.WriteLine(&quot;ExtendedPrinterStatus: {0}&quot;, queryObj[&quot;ExtendedPrinterStatus&quot;]);
                    Console.WriteLine(&quot;Hidden: {0}&quot;, queryObj[&quot;Hidden&quot;]);
                    Console.WriteLine(&quot;HorizontalResolution: {0}&quot;, queryObj[&quot;HorizontalResolution&quot;]);
                    Console.WriteLine(&quot;InstallDate: {0}&quot;, queryObj[&quot;InstallDate&quot;]);
                    Console.WriteLine(&quot;JobCountSinceLastReset: {0}&quot;, queryObj[&quot;JobCountSinceLastReset&quot;]);
                    Console.WriteLine(&quot;KeepPrintedJobs: {0}&quot;, queryObj[&quot;KeepPrintedJobs&quot;]);

                    if (queryObj[&quot;LanguagesSupported&quot;] == null)
                        Console.WriteLine(&quot;LanguagesSupported: {0}&quot;, queryObj[&quot;LanguagesSupported&quot;]);
                    else
                    {
                        UInt16[] arrLanguagesSupported = (UInt16[])(queryObj[&quot;LanguagesSupported&quot;]);
                        foreach (UInt16 arrValue in arrLanguagesSupported)
                        {
                            Console.WriteLine(&quot;LanguagesSupported: {0}&quot;, arrValue);
                        }
                    }
                    Console.WriteLine(&quot;LastErrorCode: {0}&quot;, queryObj[&quot;LastErrorCode&quot;]);
                    Console.WriteLine(&quot;Local: {0}&quot;, queryObj[&quot;Local&quot;]);
                    Console.WriteLine(&quot;Location: {0}&quot;, queryObj[&quot;Location&quot;]);
                    Console.WriteLine(&quot;MarkingTechnology: {0}&quot;, queryObj[&quot;MarkingTechnology&quot;]);
                    Console.WriteLine(&quot;MaxCopies: {0}&quot;, queryObj[&quot;MaxCopies&quot;]);
                    Console.WriteLine(&quot;MaxNumberUp: {0}&quot;, queryObj[&quot;MaxNumberUp&quot;]);
                    Console.WriteLine(&quot;MaxSizeSupported: {0}&quot;, queryObj[&quot;MaxSizeSupported&quot;]);

                    if (queryObj[&quot;MimeTypesSupported&quot;] == null)
                        Console.WriteLine(&quot;MimeTypesSupported: {0}&quot;, queryObj[&quot;MimeTypesSupported&quot;]);
                    else
                    {
                        String[] arrMimeTypesSupported = (String[])(queryObj[&quot;MimeTypesSupported&quot;]);
                        foreach (String arrValue in arrMimeTypesSupported)
                        {
                            Console.WriteLine(&quot;MimeTypesSupported: {0}&quot;, arrValue);
                        }
                    }
                    Console.WriteLine(&quot;Name: {0}&quot;, queryObj[&quot;Name&quot;]);

                    if (queryObj[&quot;NaturalLanguagesSupported&quot;] == null)
                        Console.WriteLine(&quot;NaturalLanguagesSupported: {0}&quot;, queryObj[&quot;NaturalLanguagesSupported&quot;]);
                    else
                    {
                        String[] arrNaturalLanguagesSupported = (String[])(queryObj[&quot;NaturalLanguagesSupported&quot;]);
                        foreach (String arrValue in arrNaturalLanguagesSupported)
                        {
                            Console.WriteLine(&quot;NaturalLanguagesSupported: {0}&quot;, arrValue);
                        }
                    }
                    Console.WriteLine(&quot;Network: {0}&quot;, queryObj[&quot;Network&quot;]);

                    if (queryObj[&quot;PaperSizesSupported&quot;] == null)
                        Console.WriteLine(&quot;PaperSizesSupported: {0}&quot;, queryObj[&quot;PaperSizesSupported&quot;]);
                    else
                    {
                        UInt16[] arrPaperSizesSupported = (UInt16[])(queryObj[&quot;PaperSizesSupported&quot;]);
                        foreach (UInt16 arrValue in arrPaperSizesSupported)
                        {
                            Console.WriteLine(&quot;PaperSizesSupported: {0}&quot;, arrValue);
                        }
                    }

                    if (queryObj[&quot;PaperTypesAvailable&quot;] == null)
                        Console.WriteLine(&quot;PaperTypesAvailable: {0}&quot;, queryObj[&quot;PaperTypesAvailable&quot;]);
                    else
                    {
                        String[] arrPaperTypesAvailable = (String[])(queryObj[&quot;PaperTypesAvailable&quot;]);
                        foreach (String arrValue in arrPaperTypesAvailable)
                        {
                            Console.WriteLine(&quot;PaperTypesAvailable: {0}&quot;, arrValue);
                        }
                    }
                    Console.WriteLine(&quot;Parameters: {0}&quot;, queryObj[&quot;Parameters&quot;]);
                    Console.WriteLine(&quot;PNPDeviceID: {0}&quot;, queryObj[&quot;PNPDeviceID&quot;]);
                    Console.WriteLine(&quot;PortName: {0}&quot;, queryObj[&quot;PortName&quot;]);

                    if (queryObj[&quot;PowerManagementCapabilities&quot;] == null)
                        Console.WriteLine(&quot;PowerManagementCapabilities: {0}&quot;, queryObj[&quot;PowerManagementCapabilities&quot;]);
                    else
                    {
                        UInt16[] arrPowerManagementCapabilities = (UInt16[])(queryObj[&quot;PowerManagementCapabilities&quot;]);
                        foreach (UInt16 arrValue in arrPowerManagementCapabilities)
                        {
                            Console.WriteLine(&quot;PowerManagementCapabilities: {0}&quot;, arrValue);
                        }
                    }
                    Console.WriteLine(&quot;PowerManagementSupported: {0}&quot;, queryObj[&quot;PowerManagementSupported&quot;]);

                    if (queryObj[&quot;PrinterPaperNames&quot;] == null)
                        Console.WriteLine(&quot;PrinterPaperNames: {0}&quot;, queryObj[&quot;PrinterPaperNames&quot;]);
                    else
                    {
                        String[] arrPrinterPaperNames = (String[])(queryObj[&quot;PrinterPaperNames&quot;]);
                        foreach (String arrValue in arrPrinterPaperNames)
                        {
                            Console.WriteLine(&quot;PrinterPaperNames: {0}&quot;, arrValue);
                        }
                    }
                    Console.WriteLine(&quot;PrinterState: {0}&quot;, queryObj[&quot;PrinterState&quot;]);
                    Console.WriteLine(&quot;PrinterStatus: {0}&quot;, queryObj[&quot;PrinterStatus&quot;]);
                    Console.WriteLine(&quot;PrintJobDataType: {0}&quot;, queryObj[&quot;PrintJobDataType&quot;]);
                    Console.WriteLine(&quot;PrintProcessor: {0}&quot;, queryObj[&quot;PrintProcessor&quot;]);
                    Console.WriteLine(&quot;Priority: {0}&quot;, queryObj[&quot;Priority&quot;]);
                    Console.WriteLine(&quot;Published: {0}&quot;, queryObj[&quot;Published&quot;]);
                    Console.WriteLine(&quot;Queued: {0}&quot;, queryObj[&quot;Queued&quot;]);
                    Console.WriteLine(&quot;RawOnly: {0}&quot;, queryObj[&quot;RawOnly&quot;]);
                    Console.WriteLine(&quot;SeparatorFile: {0}&quot;, queryObj[&quot;SeparatorFile&quot;]);
                    Console.WriteLine(&quot;ServerName: {0}&quot;, queryObj[&quot;ServerName&quot;]);
                    Console.WriteLine(&quot;Shared: {0}&quot;, queryObj[&quot;Shared&quot;]);
                    Console.WriteLine(&quot;ShareName: {0}&quot;, queryObj[&quot;ShareName&quot;]);
                    Console.WriteLine(&quot;SpoolEnabled: {0}&quot;, queryObj[&quot;SpoolEnabled&quot;]);
                    Console.WriteLine(&quot;StartTime: {0}&quot;, queryObj[&quot;StartTime&quot;]);
                    Console.WriteLine(&quot;Status: {0}&quot;, queryObj[&quot;Status&quot;]);
                    Console.WriteLine(&quot;StatusInfo: {0}&quot;, queryObj[&quot;StatusInfo&quot;]);
                    Console.WriteLine(&quot;SystemCreationClassName: {0}&quot;, queryObj[&quot;SystemCreationClassName&quot;]);
                    Console.WriteLine(&quot;SystemName: {0}&quot;, queryObj[&quot;SystemName&quot;]);
                    Console.WriteLine(&quot;TimeOfLastReset: {0}&quot;, queryObj[&quot;TimeOfLastReset&quot;]);
                    Console.WriteLine(&quot;UntilTime: {0}&quot;, queryObj[&quot;UntilTime&quot;]);
                    Console.WriteLine(&quot;VerticalResolution: {0}&quot;, queryObj[&quot;VerticalResolution&quot;]);
                    Console.WriteLine(&quot;WorkOffline: {0}&quot;, queryObj[&quot;WorkOffline&quot;]);
                }


            }
            catch (ManagementException e)
            {
                Console.WriteLine(&quot;An error occurred while querying for WMI data: &quot; &#43; e.Message);
            }

            Console.WriteLine();
            Console.WriteLine(&quot;Press any key to quit&quot;);
            Console.ReadKey();

        }
    }
}
</pre>
<div class="preview">
<pre class="csharp"><span class="cs__keyword">using</span>&nbsp;System;&nbsp;
<span class="cs__keyword">using</span>&nbsp;System.Collections.Generic;&nbsp;
<span class="cs__keyword">using</span>&nbsp;System.Linq;&nbsp;
<span class="cs__keyword">using</span>&nbsp;System.Text;&nbsp;
<span class="cs__keyword">using</span>&nbsp;System.Management;&nbsp;
&nbsp;
<span class="cs__keyword">namespace</span>&nbsp;ccslabsPrinterInformation&nbsp;
{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">class</span>&nbsp;Program&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">static</span><span class="cs__keyword">void</span>&nbsp;Main(<span class="cs__keyword">string</span>[]&nbsp;args)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">try</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;ManagementObjectSearcher&nbsp;searcher&nbsp;=&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">new</span>&nbsp;ManagementObjectSearcher(<span class="cs__string">&quot;root\\CIMV2&quot;</span>,&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__string">&quot;SELECT&nbsp;*&nbsp;FROM&nbsp;Win32_Printer&quot;</span>);&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">foreach</span>&nbsp;(ManagementObject&nbsp;queryObj&nbsp;<span class="cs__keyword">in</span>&nbsp;searcher.Get())&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Console.WriteLine(<span class="cs__string">&quot;-----------------------------------&quot;</span>);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Console.WriteLine(<span class="cs__string">&quot;Win32_Printer&nbsp;instance&quot;</span>);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Console.WriteLine(<span class="cs__string">&quot;-----------------------------------&quot;</span>);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Console.WriteLine(<span class="cs__string">&quot;Attributes:&nbsp;{0}&quot;</span>,&nbsp;queryObj[<span class="cs__string">&quot;Attributes&quot;</span>]);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Console.WriteLine(<span class="cs__string">&quot;Availability:&nbsp;{0}&quot;</span>,&nbsp;queryObj[<span class="cs__string">&quot;Availability&quot;</span>]);&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">if</span>&nbsp;(queryObj[<span class="cs__string">&quot;AvailableJobSheets&quot;</span>]&nbsp;==&nbsp;<span class="cs__keyword">null</span>)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Console.WriteLine(<span class="cs__string">&quot;AvailableJobSheets:&nbsp;{0}&quot;</span>,&nbsp;queryObj[<span class="cs__string">&quot;AvailableJobSheets&quot;</span>]);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">else</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;String[]&nbsp;arrAvailableJobSheets&nbsp;=&nbsp;(String[])(queryObj[<span class="cs__string">&quot;AvailableJobSheets&quot;</span>]);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">foreach</span>&nbsp;(String&nbsp;arrValue&nbsp;<span class="cs__keyword">in</span>&nbsp;arrAvailableJobSheets)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Console.WriteLine(<span class="cs__string">&quot;AvailableJobSheets:&nbsp;{0}&quot;</span>,&nbsp;arrValue);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Console.WriteLine(<span class="cs__string">&quot;AveragePagesPerMinute:&nbsp;{0}&quot;</span>,&nbsp;queryObj[<span class="cs__string">&quot;AveragePagesPerMinute&quot;</span>]);&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">if</span>&nbsp;(queryObj[<span class="cs__string">&quot;Capabilities&quot;</span>]&nbsp;==&nbsp;<span class="cs__keyword">null</span>)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Console.WriteLine(<span class="cs__string">&quot;Capabilities:&nbsp;{0}&quot;</span>,&nbsp;queryObj[<span class="cs__string">&quot;Capabilities&quot;</span>]);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">else</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;UInt16[]&nbsp;arrCapabilities&nbsp;=&nbsp;(UInt16[])(queryObj[<span class="cs__string">&quot;Capabilities&quot;</span>]);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">foreach</span>&nbsp;(UInt16&nbsp;arrValue&nbsp;<span class="cs__keyword">in</span>&nbsp;arrCapabilities)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Console.WriteLine(<span class="cs__string">&quot;Capabilities:&nbsp;{0}&quot;</span>,&nbsp;arrValue);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">if</span>&nbsp;(queryObj[<span class="cs__string">&quot;CapabilityDescriptions&quot;</span>]&nbsp;==&nbsp;<span class="cs__keyword">null</span>)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Console.WriteLine(<span class="cs__string">&quot;CapabilityDescriptions:&nbsp;{0}&quot;</span>,&nbsp;queryObj[<span class="cs__string">&quot;CapabilityDescriptions&quot;</span>]);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">else</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;String[]&nbsp;arrCapabilityDescriptions&nbsp;=&nbsp;(String[])(queryObj[<span class="cs__string">&quot;CapabilityDescriptions&quot;</span>]);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">foreach</span>&nbsp;(String&nbsp;arrValue&nbsp;<span class="cs__keyword">in</span>&nbsp;arrCapabilityDescriptions)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Console.WriteLine(<span class="cs__string">&quot;CapabilityDescriptions:&nbsp;{0}&quot;</span>,&nbsp;arrValue);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Console.WriteLine(<span class="cs__string">&quot;Caption:&nbsp;{0}&quot;</span>,&nbsp;queryObj[<span class="cs__string">&quot;Caption&quot;</span>]);&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">if</span>&nbsp;(queryObj[<span class="cs__string">&quot;CharSetsSupported&quot;</span>]&nbsp;==&nbsp;<span class="cs__keyword">null</span>)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Console.WriteLine(<span class="cs__string">&quot;CharSetsSupported:&nbsp;{0}&quot;</span>,&nbsp;queryObj[<span class="cs__string">&quot;CharSetsSupported&quot;</span>]);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">else</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;String[]&nbsp;arrCharSetsSupported&nbsp;=&nbsp;(String[])(queryObj[<span class="cs__string">&quot;CharSetsSupported&quot;</span>]);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">foreach</span>&nbsp;(String&nbsp;arrValue&nbsp;<span class="cs__keyword">in</span>&nbsp;arrCharSetsSupported)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Console.WriteLine(<span class="cs__string">&quot;CharSetsSupported:&nbsp;{0}&quot;</span>,&nbsp;arrValue);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Console.WriteLine(<span class="cs__string">&quot;Comment:&nbsp;{0}&quot;</span>,&nbsp;queryObj[<span class="cs__string">&quot;Comment&quot;</span>]);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Console.WriteLine(<span class="cs__string">&quot;ConfigManagerErrorCode:&nbsp;{0}&quot;</span>,&nbsp;queryObj[<span class="cs__string">&quot;ConfigManagerErrorCode&quot;</span>]);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Console.WriteLine(<span class="cs__string">&quot;ConfigManagerUserConfig:&nbsp;{0}&quot;</span>,&nbsp;queryObj[<span class="cs__string">&quot;ConfigManagerUserConfig&quot;</span>]);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Console.WriteLine(<span class="cs__string">&quot;CreationClassName:&nbsp;{0}&quot;</span>,&nbsp;queryObj[<span class="cs__string">&quot;CreationClassName&quot;</span>]);&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">if</span>&nbsp;(queryObj[<span class="cs__string">&quot;CurrentCapabilities&quot;</span>]&nbsp;==&nbsp;<span class="cs__keyword">null</span>)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Console.WriteLine(<span class="cs__string">&quot;CurrentCapabilities:&nbsp;{0}&quot;</span>,&nbsp;queryObj[<span class="cs__string">&quot;CurrentCapabilities&quot;</span>]);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">else</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;UInt16[]&nbsp;arrCurrentCapabilities&nbsp;=&nbsp;(UInt16[])(queryObj[<span class="cs__string">&quot;CurrentCapabilities&quot;</span>]);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">foreach</span>&nbsp;(UInt16&nbsp;arrValue&nbsp;<span class="cs__keyword">in</span>&nbsp;arrCurrentCapabilities)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Console.WriteLine(<span class="cs__string">&quot;CurrentCapabilities:&nbsp;{0}&quot;</span>,&nbsp;arrValue);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Console.WriteLine(<span class="cs__string">&quot;CurrentCharSet:&nbsp;{0}&quot;</span>,&nbsp;queryObj[<span class="cs__string">&quot;CurrentCharSet&quot;</span>]);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Console.WriteLine(<span class="cs__string">&quot;CurrentLanguage:&nbsp;{0}&quot;</span>,&nbsp;queryObj[<span class="cs__string">&quot;CurrentLanguage&quot;</span>]);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Console.WriteLine(<span class="cs__string">&quot;CurrentMimeType:&nbsp;{0}&quot;</span>,&nbsp;queryObj[<span class="cs__string">&quot;CurrentMimeType&quot;</span>]);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Console.WriteLine(<span class="cs__string">&quot;CurrentNaturalLanguage:&nbsp;{0}&quot;</span>,&nbsp;queryObj[<span class="cs__string">&quot;CurrentNaturalLanguage&quot;</span>]);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Console.WriteLine(<span class="cs__string">&quot;CurrentPaperType:&nbsp;{0}&quot;</span>,&nbsp;queryObj[<span class="cs__string">&quot;CurrentPaperType&quot;</span>]);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Console.WriteLine(<span class="cs__string">&quot;Default:&nbsp;{0}&quot;</span>,&nbsp;queryObj[<span class="cs__string">&quot;Default&quot;</span>]);&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">if</span>&nbsp;(queryObj[<span class="cs__string">&quot;DefaultCapabilities&quot;</span>]&nbsp;==&nbsp;<span class="cs__keyword">null</span>)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Console.WriteLine(<span class="cs__string">&quot;DefaultCapabilities:&nbsp;{0}&quot;</span>,&nbsp;queryObj[<span class="cs__string">&quot;DefaultCapabilities&quot;</span>]);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">else</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;UInt16[]&nbsp;arrDefaultCapabilities&nbsp;=&nbsp;(UInt16[])(queryObj[<span class="cs__string">&quot;DefaultCapabilities&quot;</span>]);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">foreach</span>&nbsp;(UInt16&nbsp;arrValue&nbsp;<span class="cs__keyword">in</span>&nbsp;arrDefaultCapabilities)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Console.WriteLine(<span class="cs__string">&quot;DefaultCapabilities:&nbsp;{0}&quot;</span>,&nbsp;arrValue);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Console.WriteLine(<span class="cs__string">&quot;DefaultCopies:&nbsp;{0}&quot;</span>,&nbsp;queryObj[<span class="cs__string">&quot;DefaultCopies&quot;</span>]);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Console.WriteLine(<span class="cs__string">&quot;DefaultLanguage:&nbsp;{0}&quot;</span>,&nbsp;queryObj[<span class="cs__string">&quot;DefaultLanguage&quot;</span>]);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Console.WriteLine(<span class="cs__string">&quot;DefaultMimeType:&nbsp;{0}&quot;</span>,&nbsp;queryObj[<span class="cs__string">&quot;DefaultMimeType&quot;</span>]);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Console.WriteLine(<span class="cs__string">&quot;DefaultNumberUp:&nbsp;{0}&quot;</span>,&nbsp;queryObj[<span class="cs__string">&quot;DefaultNumberUp&quot;</span>]);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Console.WriteLine(<span class="cs__string">&quot;DefaultPaperType:&nbsp;{0}&quot;</span>,&nbsp;queryObj[<span class="cs__string">&quot;DefaultPaperType&quot;</span>]);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Console.WriteLine(<span class="cs__string">&quot;DefaultPriority:&nbsp;{0}&quot;</span>,&nbsp;queryObj[<span class="cs__string">&quot;DefaultPriority&quot;</span>]);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Console.WriteLine(<span class="cs__string">&quot;Description:&nbsp;{0}&quot;</span>,&nbsp;queryObj[<span class="cs__string">&quot;Description&quot;</span>]);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Console.WriteLine(<span class="cs__string">&quot;DetectedErrorState:&nbsp;{0}&quot;</span>,&nbsp;queryObj[<span class="cs__string">&quot;DetectedErrorState&quot;</span>]);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Console.WriteLine(<span class="cs__string">&quot;DeviceID:&nbsp;{0}&quot;</span>,&nbsp;queryObj[<span class="cs__string">&quot;DeviceID&quot;</span>]);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Console.WriteLine(<span class="cs__string">&quot;Direct:&nbsp;{0}&quot;</span>,&nbsp;queryObj[<span class="cs__string">&quot;Direct&quot;</span>]);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Console.WriteLine(<span class="cs__string">&quot;DoCompleteFirst:&nbsp;{0}&quot;</span>,&nbsp;queryObj[<span class="cs__string">&quot;DoCompleteFirst&quot;</span>]);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Console.WriteLine(<span class="cs__string">&quot;DriverName:&nbsp;{0}&quot;</span>,&nbsp;queryObj[<span class="cs__string">&quot;DriverName&quot;</span>]);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Console.WriteLine(<span class="cs__string">&quot;EnableBIDI:&nbsp;{0}&quot;</span>,&nbsp;queryObj[<span class="cs__string">&quot;EnableBIDI&quot;</span>]);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Console.WriteLine(<span class="cs__string">&quot;EnableDevQueryPrint:&nbsp;{0}&quot;</span>,&nbsp;queryObj[<span class="cs__string">&quot;EnableDevQueryPrint&quot;</span>]);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Console.WriteLine(<span class="cs__string">&quot;ErrorCleared:&nbsp;{0}&quot;</span>,&nbsp;queryObj[<span class="cs__string">&quot;ErrorCleared&quot;</span>]);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Console.WriteLine(<span class="cs__string">&quot;ErrorDescription:&nbsp;{0}&quot;</span>,&nbsp;queryObj[<span class="cs__string">&quot;ErrorDescription&quot;</span>]);&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">if</span>&nbsp;(queryObj[<span class="cs__string">&quot;ErrorInformation&quot;</span>]&nbsp;==&nbsp;<span class="cs__keyword">null</span>)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Console.WriteLine(<span class="cs__string">&quot;ErrorInformation:&nbsp;{0}&quot;</span>,&nbsp;queryObj[<span class="cs__string">&quot;ErrorInformation&quot;</span>]);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">else</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;String[]&nbsp;arrErrorInformation&nbsp;=&nbsp;(String[])(queryObj[<span class="cs__string">&quot;ErrorInformation&quot;</span>]);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">foreach</span>&nbsp;(String&nbsp;arrValue&nbsp;<span class="cs__keyword">in</span>&nbsp;arrErrorInformation)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Console.WriteLine(<span class="cs__string">&quot;ErrorInformation:&nbsp;{0}&quot;</span>,&nbsp;arrValue);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Console.WriteLine(<span class="cs__string">&quot;ExtendedDetectedErrorState:&nbsp;{0}&quot;</span>,&nbsp;queryObj[<span class="cs__string">&quot;ExtendedDetectedErrorState&quot;</span>]);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Console.WriteLine(<span class="cs__string">&quot;ExtendedPrinterStatus:&nbsp;{0}&quot;</span>,&nbsp;queryObj[<span class="cs__string">&quot;ExtendedPrinterStatus&quot;</span>]);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Console.WriteLine(<span class="cs__string">&quot;Hidden:&nbsp;{0}&quot;</span>,&nbsp;queryObj[<span class="cs__string">&quot;Hidden&quot;</span>]);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Console.WriteLine(<span class="cs__string">&quot;HorizontalResolution:&nbsp;{0}&quot;</span>,&nbsp;queryObj[<span class="cs__string">&quot;HorizontalResolution&quot;</span>]);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Console.WriteLine(<span class="cs__string">&quot;InstallDate:&nbsp;{0}&quot;</span>,&nbsp;queryObj[<span class="cs__string">&quot;InstallDate&quot;</span>]);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Console.WriteLine(<span class="cs__string">&quot;JobCountSinceLastReset:&nbsp;{0}&quot;</span>,&nbsp;queryObj[<span class="cs__string">&quot;JobCountSinceLastReset&quot;</span>]);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Console.WriteLine(<span class="cs__string">&quot;KeepPrintedJobs:&nbsp;{0}&quot;</span>,&nbsp;queryObj[<span class="cs__string">&quot;KeepPrintedJobs&quot;</span>]);&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">if</span>&nbsp;(queryObj[<span class="cs__string">&quot;LanguagesSupported&quot;</span>]&nbsp;==&nbsp;<span class="cs__keyword">null</span>)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Console.WriteLine(<span class="cs__string">&quot;LanguagesSupported:&nbsp;{0}&quot;</span>,&nbsp;queryObj[<span class="cs__string">&quot;LanguagesSupported&quot;</span>]);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">else</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;UInt16[]&nbsp;arrLanguagesSupported&nbsp;=&nbsp;(UInt16[])(queryObj[<span class="cs__string">&quot;LanguagesSupported&quot;</span>]);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">foreach</span>&nbsp;(UInt16&nbsp;arrValue&nbsp;<span class="cs__keyword">in</span>&nbsp;arrLanguagesSupported)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Console.WriteLine(<span class="cs__string">&quot;LanguagesSupported:&nbsp;{0}&quot;</span>,&nbsp;arrValue);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Console.WriteLine(<span class="cs__string">&quot;LastErrorCode:&nbsp;{0}&quot;</span>,&nbsp;queryObj[<span class="cs__string">&quot;LastErrorCode&quot;</span>]);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Console.WriteLine(<span class="cs__string">&quot;Local:&nbsp;{0}&quot;</span>,&nbsp;queryObj[<span class="cs__string">&quot;Local&quot;</span>]);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Console.WriteLine(<span class="cs__string">&quot;Location:&nbsp;{0}&quot;</span>,&nbsp;queryObj[<span class="cs__string">&quot;Location&quot;</span>]);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Console.WriteLine(<span class="cs__string">&quot;MarkingTechnology:&nbsp;{0}&quot;</span>,&nbsp;queryObj[<span class="cs__string">&quot;MarkingTechnology&quot;</span>]);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Console.WriteLine(<span class="cs__string">&quot;MaxCopies:&nbsp;{0}&quot;</span>,&nbsp;queryObj[<span class="cs__string">&quot;MaxCopies&quot;</span>]);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Console.WriteLine(<span class="cs__string">&quot;MaxNumberUp:&nbsp;{0}&quot;</span>,&nbsp;queryObj[<span class="cs__string">&quot;MaxNumberUp&quot;</span>]);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Console.WriteLine(<span class="cs__string">&quot;MaxSizeSupported:&nbsp;{0}&quot;</span>,&nbsp;queryObj[<span class="cs__string">&quot;MaxSizeSupported&quot;</span>]);&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">if</span>&nbsp;(queryObj[<span class="cs__string">&quot;MimeTypesSupported&quot;</span>]&nbsp;==&nbsp;<span class="cs__keyword">null</span>)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Console.WriteLine(<span class="cs__string">&quot;MimeTypesSupported:&nbsp;{0}&quot;</span>,&nbsp;queryObj[<span class="cs__string">&quot;MimeTypesSupported&quot;</span>]);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">else</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;String[]&nbsp;arrMimeTypesSupported&nbsp;=&nbsp;(String[])(queryObj[<span class="cs__string">&quot;MimeTypesSupported&quot;</span>]);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">foreach</span>&nbsp;(String&nbsp;arrValue&nbsp;<span class="cs__keyword">in</span>&nbsp;arrMimeTypesSupported)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Console.WriteLine(<span class="cs__string">&quot;MimeTypesSupported:&nbsp;{0}&quot;</span>,&nbsp;arrValue);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Console.WriteLine(<span class="cs__string">&quot;Name:&nbsp;{0}&quot;</span>,&nbsp;queryObj[<span class="cs__string">&quot;Name&quot;</span>]);&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">if</span>&nbsp;(queryObj[<span class="cs__string">&quot;NaturalLanguagesSupported&quot;</span>]&nbsp;==&nbsp;<span class="cs__keyword">null</span>)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Console.WriteLine(<span class="cs__string">&quot;NaturalLanguagesSupported:&nbsp;{0}&quot;</span>,&nbsp;queryObj[<span class="cs__string">&quot;NaturalLanguagesSupported&quot;</span>]);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">else</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;String[]&nbsp;arrNaturalLanguagesSupported&nbsp;=&nbsp;(String[])(queryObj[<span class="cs__string">&quot;NaturalLanguagesSupported&quot;</span>]);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">foreach</span>&nbsp;(String&nbsp;arrValue&nbsp;<span class="cs__keyword">in</span>&nbsp;arrNaturalLanguagesSupported)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Console.WriteLine(<span class="cs__string">&quot;NaturalLanguagesSupported:&nbsp;{0}&quot;</span>,&nbsp;arrValue);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Console.WriteLine(<span class="cs__string">&quot;Network:&nbsp;{0}&quot;</span>,&nbsp;queryObj[<span class="cs__string">&quot;Network&quot;</span>]);&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">if</span>&nbsp;(queryObj[<span class="cs__string">&quot;PaperSizesSupported&quot;</span>]&nbsp;==&nbsp;<span class="cs__keyword">null</span>)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Console.WriteLine(<span class="cs__string">&quot;PaperSizesSupported:&nbsp;{0}&quot;</span>,&nbsp;queryObj[<span class="cs__string">&quot;PaperSizesSupported&quot;</span>]);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">else</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;UInt16[]&nbsp;arrPaperSizesSupported&nbsp;=&nbsp;(UInt16[])(queryObj[<span class="cs__string">&quot;PaperSizesSupported&quot;</span>]);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">foreach</span>&nbsp;(UInt16&nbsp;arrValue&nbsp;<span class="cs__keyword">in</span>&nbsp;arrPaperSizesSupported)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Console.WriteLine(<span class="cs__string">&quot;PaperSizesSupported:&nbsp;{0}&quot;</span>,&nbsp;arrValue);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">if</span>&nbsp;(queryObj[<span class="cs__string">&quot;PaperTypesAvailable&quot;</span>]&nbsp;==&nbsp;<span class="cs__keyword">null</span>)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Console.WriteLine(<span class="cs__string">&quot;PaperTypesAvailable:&nbsp;{0}&quot;</span>,&nbsp;queryObj[<span class="cs__string">&quot;PaperTypesAvailable&quot;</span>]);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">else</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;String[]&nbsp;arrPaperTypesAvailable&nbsp;=&nbsp;(String[])(queryObj[<span class="cs__string">&quot;PaperTypesAvailable&quot;</span>]);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">foreach</span>&nbsp;(String&nbsp;arrValue&nbsp;<span class="cs__keyword">in</span>&nbsp;arrPaperTypesAvailable)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Console.WriteLine(<span class="cs__string">&quot;PaperTypesAvailable:&nbsp;{0}&quot;</span>,&nbsp;arrValue);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Console.WriteLine(<span class="cs__string">&quot;Parameters:&nbsp;{0}&quot;</span>,&nbsp;queryObj[<span class="cs__string">&quot;Parameters&quot;</span>]);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Console.WriteLine(<span class="cs__string">&quot;PNPDeviceID:&nbsp;{0}&quot;</span>,&nbsp;queryObj[<span class="cs__string">&quot;PNPDeviceID&quot;</span>]);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Console.WriteLine(<span class="cs__string">&quot;PortName:&nbsp;{0}&quot;</span>,&nbsp;queryObj[<span class="cs__string">&quot;PortName&quot;</span>]);&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">if</span>&nbsp;(queryObj[<span class="cs__string">&quot;PowerManagementCapabilities&quot;</span>]&nbsp;==&nbsp;<span class="cs__keyword">null</span>)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Console.WriteLine(<span class="cs__string">&quot;PowerManagementCapabilities:&nbsp;{0}&quot;</span>,&nbsp;queryObj[<span class="cs__string">&quot;PowerManagementCapabilities&quot;</span>]);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">else</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;UInt16[]&nbsp;arrPowerManagementCapabilities&nbsp;=&nbsp;(UInt16[])(queryObj[<span class="cs__string">&quot;PowerManagementCapabilities&quot;</span>]);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">foreach</span>&nbsp;(UInt16&nbsp;arrValue&nbsp;<span class="cs__keyword">in</span>&nbsp;arrPowerManagementCapabilities)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Console.WriteLine(<span class="cs__string">&quot;PowerManagementCapabilities:&nbsp;{0}&quot;</span>,&nbsp;arrValue);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Console.WriteLine(<span class="cs__string">&quot;PowerManagementSupported:&nbsp;{0}&quot;</span>,&nbsp;queryObj[<span class="cs__string">&quot;PowerManagementSupported&quot;</span>]);&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">if</span>&nbsp;(queryObj[<span class="cs__string">&quot;PrinterPaperNames&quot;</span>]&nbsp;==&nbsp;<span class="cs__keyword">null</span>)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Console.WriteLine(<span class="cs__string">&quot;PrinterPaperNames:&nbsp;{0}&quot;</span>,&nbsp;queryObj[<span class="cs__string">&quot;PrinterPaperNames&quot;</span>]);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">else</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;String[]&nbsp;arrPrinterPaperNames&nbsp;=&nbsp;(String[])(queryObj[<span class="cs__string">&quot;PrinterPaperNames&quot;</span>]);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">foreach</span>&nbsp;(String&nbsp;arrValue&nbsp;<span class="cs__keyword">in</span>&nbsp;arrPrinterPaperNames)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Console.WriteLine(<span class="cs__string">&quot;PrinterPaperNames:&nbsp;{0}&quot;</span>,&nbsp;arrValue);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Console.WriteLine(<span class="cs__string">&quot;PrinterState:&nbsp;{0}&quot;</span>,&nbsp;queryObj[<span class="cs__string">&quot;PrinterState&quot;</span>]);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Console.WriteLine(<span class="cs__string">&quot;PrinterStatus:&nbsp;{0}&quot;</span>,&nbsp;queryObj[<span class="cs__string">&quot;PrinterStatus&quot;</span>]);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Console.WriteLine(<span class="cs__string">&quot;PrintJobDataType:&nbsp;{0}&quot;</span>,&nbsp;queryObj[<span class="cs__string">&quot;PrintJobDataType&quot;</span>]);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Console.WriteLine(<span class="cs__string">&quot;PrintProcessor:&nbsp;{0}&quot;</span>,&nbsp;queryObj[<span class="cs__string">&quot;PrintProcessor&quot;</span>]);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Console.WriteLine(<span class="cs__string">&quot;Priority:&nbsp;{0}&quot;</span>,&nbsp;queryObj[<span class="cs__string">&quot;Priority&quot;</span>]);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Console.WriteLine(<span class="cs__string">&quot;Published:&nbsp;{0}&quot;</span>,&nbsp;queryObj[<span class="cs__string">&quot;Published&quot;</span>]);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Console.WriteLine(<span class="cs__string">&quot;Queued:&nbsp;{0}&quot;</span>,&nbsp;queryObj[<span class="cs__string">&quot;Queued&quot;</span>]);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Console.WriteLine(<span class="cs__string">&quot;RawOnly:&nbsp;{0}&quot;</span>,&nbsp;queryObj[<span class="cs__string">&quot;RawOnly&quot;</span>]);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Console.WriteLine(<span class="cs__string">&quot;SeparatorFile:&nbsp;{0}&quot;</span>,&nbsp;queryObj[<span class="cs__string">&quot;SeparatorFile&quot;</span>]);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Console.WriteLine(<span class="cs__string">&quot;ServerName:&nbsp;{0}&quot;</span>,&nbsp;queryObj[<span class="cs__string">&quot;ServerName&quot;</span>]);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Console.WriteLine(<span class="cs__string">&quot;Shared:&nbsp;{0}&quot;</span>,&nbsp;queryObj[<span class="cs__string">&quot;Shared&quot;</span>]);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Console.WriteLine(<span class="cs__string">&quot;ShareName:&nbsp;{0}&quot;</span>,&nbsp;queryObj[<span class="cs__string">&quot;ShareName&quot;</span>]);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Console.WriteLine(<span class="cs__string">&quot;SpoolEnabled:&nbsp;{0}&quot;</span>,&nbsp;queryObj[<span class="cs__string">&quot;SpoolEnabled&quot;</span>]);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Console.WriteLine(<span class="cs__string">&quot;StartTime:&nbsp;{0}&quot;</span>,&nbsp;queryObj[<span class="cs__string">&quot;StartTime&quot;</span>]);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Console.WriteLine(<span class="cs__string">&quot;Status:&nbsp;{0}&quot;</span>,&nbsp;queryObj[<span class="cs__string">&quot;Status&quot;</span>]);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Console.WriteLine(<span class="cs__string">&quot;StatusInfo:&nbsp;{0}&quot;</span>,&nbsp;queryObj[<span class="cs__string">&quot;StatusInfo&quot;</span>]);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Console.WriteLine(<span class="cs__string">&quot;SystemCreationClassName:&nbsp;{0}&quot;</span>,&nbsp;queryObj[<span class="cs__string">&quot;SystemCreationClassName&quot;</span>]);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Console.WriteLine(<span class="cs__string">&quot;SystemName:&nbsp;{0}&quot;</span>,&nbsp;queryObj[<span class="cs__string">&quot;SystemName&quot;</span>]);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Console.WriteLine(<span class="cs__string">&quot;TimeOfLastReset:&nbsp;{0}&quot;</span>,&nbsp;queryObj[<span class="cs__string">&quot;TimeOfLastReset&quot;</span>]);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Console.WriteLine(<span class="cs__string">&quot;UntilTime:&nbsp;{0}&quot;</span>,&nbsp;queryObj[<span class="cs__string">&quot;UntilTime&quot;</span>]);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Console.WriteLine(<span class="cs__string">&quot;VerticalResolution:&nbsp;{0}&quot;</span>,&nbsp;queryObj[<span class="cs__string">&quot;VerticalResolution&quot;</span>]);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Console.WriteLine(<span class="cs__string">&quot;WorkOffline:&nbsp;{0}&quot;</span>,&nbsp;queryObj[<span class="cs__string">&quot;WorkOffline&quot;</span>]);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">catch</span>&nbsp;(ManagementException&nbsp;e)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Console.WriteLine(<span class="cs__string">&quot;An&nbsp;error&nbsp;occurred&nbsp;while&nbsp;querying&nbsp;for&nbsp;WMI&nbsp;data:&nbsp;&quot;</span>&nbsp;&#43;&nbsp;e.Message);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Console.WriteLine();&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Console.WriteLine(<span class="cs__string">&quot;Press&nbsp;any&nbsp;key&nbsp;to&nbsp;quit&quot;</span>);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Console.ReadKey();&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
}&nbsp;
</pre>
</div>
</div>
</div>
<p>&nbsp;</p>
<h3>Members</h3>
<p>The <strong>Win32_Printer</strong> class has these types of members:</p>
<ul>
<li><a href="http://msdn.microsoft.com/en-us/library/windows/desktop/aa394363(v=vs.85).aspx#methods">Methods</a>
</li><li><a href="http://msdn.microsoft.com/en-us/library/windows/desktop/aa394363(v=vs.85).aspx#properties">Properties</a>
</li></ul>
<h4><a id="methods"></a>Methods</h4>
<p>The <strong>Win32_Printer</strong> class has these methods.</p>
<table>
<tbody>
<tr>
<th>Method</th>
<th>Description</th>
</tr>
<tr>
<td><a href="http://msdn.microsoft.com/en-us/library/windows/desktop/aa384769(v=vs.85).aspx"><strong>AddPrinterConnection</strong></a></td>
<td>
<p>Adds a connection to the printer.</p>
<blockquote>
<div><strong>Windows&nbsp;2000 and Windows&nbsp;NT&nbsp;4.0:&nbsp;&nbsp;</strong>This method is not available.</div>
</blockquote>
</td>
</tr>
<tr>
<td><a href="http://msdn.microsoft.com/en-us/library/windows/desktop/aa384838(v=vs.85).aspx"><strong>CancelAllJobs</strong></a></td>
<td>
<p>Cancels all jobs.</p>
<blockquote>
<div><strong>Windows&nbsp;2000 and Windows&nbsp;NT&nbsp;4.0:&nbsp;&nbsp;</strong>This method is not available.</div>
</blockquote>
</td>
</tr>
<tr>
<td><a href="http://msdn.microsoft.com/en-us/library/windows/desktop/aa390778(v=vs.85).aspx"><strong>GetSecurityDescriptor</strong></a></td>
<td>
<p>Returns the&nbsp; security descriptor&nbsp; that controls access to the printer. This method is available starting with Windows&nbsp;Vista.</p>
<blockquote>
<div><strong>Windows Server&nbsp;2003, Windows&nbsp;XP, Windows&nbsp;2000, and Windows&nbsp;NT&nbsp;4.0:&nbsp;&nbsp;</strong>This method is not available.</div>
</blockquote>
</td>
</tr>
<tr>
<td><a href="http://msdn.microsoft.com/en-us/library/windows/desktop/aa392735(v=vs.85).aspx"><strong>Pause</strong></a></td>
<td>
<p>Pauses the print queue.</p>
<blockquote>
<div><strong>Windows&nbsp;2000 and Windows&nbsp;NT&nbsp;4.0:&nbsp;&nbsp;</strong>This method is not available.</div>
</blockquote>
</td>
</tr>
<tr>
<td><a href="http://msdn.microsoft.com/en-us/library/windows/desktop/aa392757(v=vs.85).aspx"><strong>PrintTestPage</strong></a></td>
<td>
<p>Prints a test page.</p>
<blockquote>
<div><strong>Windows&nbsp;2000 and Windows&nbsp;NT&nbsp;4.0:&nbsp;&nbsp;</strong>This method is not available.</div>
</blockquote>
</td>
</tr>
<tr>
<td><a href="http://msdn.microsoft.com/en-us/library/windows/desktop/aa393050(v=vs.85).aspx"><strong>RenamePrinter</strong></a></td>
<td>
<p>Renames a printer.</p>
<blockquote>
<div><strong>Windows&nbsp;2000 and Windows&nbsp;NT&nbsp;4.0:&nbsp;&nbsp;</strong>This method is not available.</div>
</blockquote>
</td>
</tr>
<tr>
<td><strong>Reset</strong></td>
<td>
<p>Not implemented. For more information about how to implement this method, see the
<a href="http://msdn.microsoft.com/en-us/library/windows/desktop/aa393077(v=vs.85).aspx">
<strong>Reset</strong></a> method in <a href="http://msdn.microsoft.com/en-us/library/windows/desktop/aa387974(v=vs.85).aspx">
<strong>CIM_Printer</strong></a>.</p>
</td>
</tr>
<tr>
<td><a href="http://msdn.microsoft.com/en-us/library/windows/desktop/aa393237(v=vs.85).aspx"><strong>Resume</strong></a></td>
<td>
<p>Resumes paused print queue.</p>
<blockquote>
<div><strong>Windows&nbsp;2000 and Windows&nbsp;NT&nbsp;4.0:&nbsp;&nbsp;</strong>This method is not available.</div>
</blockquote>
</td>
</tr>
<tr>
<td><a href="http://msdn.microsoft.com/en-us/library/windows/desktop/aa393291(v=vs.85).aspx"><strong>SetDefaultPrinter</strong></a></td>
<td>
<p>Sets the default printer.</p>
<blockquote>
<div><strong>Windows&nbsp;2000 and Windows&nbsp;NT&nbsp;4.0:&nbsp;&nbsp;</strong>This method is not available.</div>
</blockquote>
</td>
</tr>
<tr>
<td><strong>SetPowerState</strong></td>
<td>
<p>Not implemented. For more information about how to implement this method, see the
<a href="http://msdn.microsoft.com/en-us/library/windows/desktop/aa393485(v=vs.85).aspx">
<strong>SetPowerState</strong></a> method in <a href="http://msdn.microsoft.com/en-us/library/windows/desktop/aa387974(v=vs.85).aspx">
<strong>CIM_Printer</strong></a>.</p>
</td>
</tr>
<tr>
<td><a href="http://msdn.microsoft.com/en-us/library/windows/desktop/aa393594(v=vs.85).aspx"><strong>SetSecurityDescriptor</strong></a></td>
<td>
<p>Writes an updated version of&nbsp; the&nbsp; security descriptor&nbsp; that controls access to the printer. This method is available starting with Windows&nbsp;Vista.</p>
<blockquote>
<div><strong>Windows Server&nbsp;2003, Windows&nbsp;XP, Windows&nbsp;2000, and Windows&nbsp;NT&nbsp;4.0:&nbsp;&nbsp;</strong>This method is not available.</div>
</blockquote>
</td>
</tr>
</tbody>
</table>
<p>&nbsp;</p>
<h4><a id="properties"></a>Properties</h4>
<p>The <strong>Win32_Printer</strong> class has these properties.</p>
<dl><dt><strong>Attributes</strong></dt><dd>
<dl><dt>Data type: <strong>uint32</strong></dt><dt>Access type: Read-only</dt></dl>
<p>&nbsp;</p>
<p>Bitmap of attributes for a Windows-based printing device.</p>
<table>
<tbody>
<tr>
<th>Value used to set the bit</th>
<th>Meaning</th>
</tr>
<tr>
<td><a id="PRINTER_ATTRIBUTE_QUEUED"></a><a id="printer_attribute_queued"></a>
<dl><dt><strong>PRINTER_ATTRIBUTE_QUEUED</strong></dt><dt>1 (0x1)</dt></dl>
</td>
<td>
<p>Queued</p>
<p>Print jobs are buffered and queued.</p>
</td>
</tr>
<tr>
<td><a id="PRINTER_ATTRIBUTE_DIRECT"></a><a id="printer_attribute_direct"></a>
<dl><dt><strong>PRINTER_ATTRIBUTE_DIRECT</strong></dt><dt>2 (0x2)</dt></dl>
</td>
<td>
<p>Direct</p>
<p>Document to&nbsp; be sent directly to the printer. This value is used if print jobs are not queued correctly.</p>
</td>
</tr>
<tr>
<td><a id="PRINTER_ATTRIBUTE_DEFAULT"></a><a id="printer_attribute_default"></a>
<dl><dt><strong>PRINTER_ATTRIBUTE_DEFAULT</strong></dt><dt>4 (0x4)</dt></dl>
</td>
<td>
<p>Default</p>
<p>Default printer on a&nbsp; computer.</p>
</td>
</tr>
<tr>
<td><a id="PRINTER_ATTRIBUTE_SHARED"></a><a id="printer_attribute_shared"></a>
<dl><dt><strong>PRINTER_ATTRIBUTE_SHARED</strong></dt><dt>8 (0x8)</dt></dl>
</td>
<td>
<p>Shared</p>
<p>Available as a shared network resource.</p>
</td>
</tr>
<tr>
<td><a id="PRINTER_ATTRIBUTE_NETWORK"></a><a id="printer_attribute_network"></a>
<dl><dt><strong>PRINTER_ATTRIBUTE_NETWORK</strong></dt><dt>16 (0x10)</dt></dl>
</td>
<td>
<p>Network</p>
<p>Attached to a&nbsp;&nbsp; network.&nbsp; If both Local and Network bits are set, this indicates a network printer.</p>
</td>
</tr>
<tr>
<td><a id="PRINTER_ATTRIBUTE_HIDDEN"></a><a id="printer_attribute_hidden"></a>
<dl><dt><strong>PRINTER_ATTRIBUTE_HIDDEN</strong></dt><dt>32 (0x20)</dt></dl>
</td>
<td>
<p>Hidden</p>
<p>Hidden from some users on the network.</p>
</td>
</tr>
<tr>
<td><a id="PRINTER_ATTRIBUTE_LOCAL"></a><a id="printer_attribute_local"></a>
<dl><dt><strong>PRINTER_ATTRIBUTE_LOCAL</strong></dt><dt>64 (0x40)</dt></dl>
</td>
<td>
<p>Local</p>
<p>Directly connected to a&nbsp; computer. If both Local and Network bits are set, this indicates a network printer.</p>
</td>
</tr>
<tr>
<td><a id="PRINTER_ATTRIBUTE_ENABLEDEVQ"></a><a id="printer_attribute_enabledevq"></a>
<dl><dt><strong>PRINTER_ATTRIBUTE_ENABLEDEVQ</strong></dt><dt>128 (0x80)</dt></dl>
</td>
<td>
<p>EnableDevQ</p>
<p>Enable the queue on the printer if available.</p>
</td>
</tr>
<tr>
<td><a id="PRINTER_ATTRIBUTE_KEEPPRINTEDJOBS"></a><a id="printer_attribute_keepprintedjobs"></a>
<dl><dt><strong>PRINTER_ATTRIBUTE_KEEPPRINTEDJOBS</strong></dt><dt>256 (0x100)</dt></dl>
</td>
<td>
<p>KeepPrintedJobs</p>
<p>Spooler should not delete documents after they are printed.</p>
</td>
</tr>
<tr>
<td><a id="PRINTER_ATTRIBUTE_DO_COMPLETE_FIRST"></a><a id="printer_attribute_do_complete_first"></a>
<dl><dt><strong>PRINTER_ATTRIBUTE_DO_COMPLETE_FIRST</strong></dt><dt>512 (0x200)</dt></dl>
</td>
<td>
<p>DoCompleteFirst</p>
<p>Start jobs that are finished spooling first.</p>
</td>
</tr>
<tr>
<td><a id="PRINTER_ATTRIBUTE_WORK_OFFLINE"></a><a id="printer_attribute_work_offline"></a>
<dl><dt><strong>PRINTER_ATTRIBUTE_WORK_OFFLINE</strong></dt><dt>1024 (0x400)</dt></dl>
</td>
<td>
<p>WorkOffline</p>
<p>Queue print jobs when&nbsp; a printer is not available.</p>
</td>
</tr>
<tr>
<td><a id="PRINTER_ATTRIBUTE_ENABLE_BIDI"></a><a id="printer_attribute_enable_bidi"></a>
<dl><dt><strong>PRINTER_ATTRIBUTE_ENABLE_BIDI</strong></dt><dt>2048 (0x800)</dt></dl>
</td>
<td>
<p>EnableBIDI</p>
<p>Enable bidirectional printing.</p>
</td>
</tr>
<tr>
<td><a id="PRINTER_ATTRIBUTE_RAW_ONLY"></a><a id="printer_attribute_raw_only"></a>
<dl><dt><strong>PRINTER_ATTRIBUTE_RAW_ONLY</strong></dt><dt>4096 (0x1000)</dt></dl>
</td>
<td>
<p>Allow only raw data type jobs to be spooled.</p>
</td>
</tr>
<tr>
<td><a id="PRINTER_ATTRIBUTE_PUBLISHED"></a><a id="printer_attribute_published"></a>
<dl><dt><strong>PRINTER_ATTRIBUTE_PUBLISHED</strong></dt><dt>8192 (0x2000)</dt></dl>
</td>
<td>
<p>Published</p>
<p>Published in the network directory service.</p>
</td>
</tr>
</tbody>
</table>
<p>&nbsp;</p>
</dd><dt><strong>Availability</strong></dt><dd>
<dl><dt>Data type: <strong>uint16</strong></dt><dt>Access type: Read-only</dt></dl>
<p>&nbsp;</p>
<p>Availability and status of the device.&nbsp; Inherited from <a href="http://msdn.microsoft.com/en-us/library/windows/desktop/aa387884(v=vs.85).aspx">
<strong>CIM_LogicalDevice</strong></a>.</p>
<table>
<tbody>
<tr>
<th>Value</th>
<th>Meaning</th>
</tr>
<tr>
<td>
<dl><dt>1 (0x1)</dt></dl>
</td>
<td>
<p>Other</p>
</td>
</tr>
<tr>
<td>
<dl><dt>2 (0x2)</dt></dl>
</td>
<td>
<p>Unknown</p>
</td>
</tr>
<tr>
<td>
<dl><dt>3 (0x3)</dt></dl>
</td>
<td>
<p>Running or Full Power</p>
</td>
</tr>
<tr>
<td>
<dl><dt>4 (0x4)</dt></dl>
</td>
<td>
<p>Warning</p>
</td>
</tr>
<tr>
<td>
<dl><dt>5 (0x5)</dt></dl>
</td>
<td>
<p>In Test</p>
</td>
</tr>
<tr>
<td>
<dl><dt>6 (0x6)</dt></dl>
</td>
<td>
<p>Not Applicable</p>
</td>
</tr>
<tr>
<td>
<dl><dt>7 (0x7)</dt></dl>
</td>
<td>
<p>Power Off</p>
</td>
</tr>
<tr>
<td>
<dl><dt>8 (0x8)</dt></dl>
</td>
<td>
<p>Off Line</p>
</td>
</tr>
<tr>
<td>
<dl><dt>9 (0x9)</dt></dl>
</td>
<td>
<p>Off Duty</p>
</td>
</tr>
<tr>
<td>
<dl><dt>10 (0xA)</dt></dl>
</td>
<td>
<p>Degraded</p>
</td>
</tr>
<tr>
<td>
<dl><dt>11 (0xB)</dt></dl>
</td>
<td>
<p>Not Installed</p>
</td>
</tr>
<tr>
<td>
<dl><dt>12 (0xC)</dt></dl>
</td>
<td>
<p>Install Error</p>
</td>
</tr>
<tr>
<td>
<dl><dt>13 (0xD)</dt></dl>
</td>
<td>
<p>Power Save - Unknown</p>
<p>The device is known to be in a power save mode, but its exact status is unknown.</p>
</td>
</tr>
<tr>
<td>
<dl><dt>14 (0xE)</dt></dl>
</td>
<td>
<p>Power Save - Low Power Mode</p>
<p>The device is in a power save state but is still functioning, and may exhibit degraded performance.</p>
</td>
</tr>
<tr>
<td>
<dl><dt>15 (0xF)</dt></dl>
</td>
<td>
<p>Power Save - Standby</p>
<p>The device is not functioning, but could be brought to full power quickly.</p>
</td>
</tr>
<tr>
<td>
<dl><dt>16 (0x10)</dt></dl>
</td>
<td>
<p>Power Cycle</p>
</td>
</tr>
<tr>
<td>
<dl><dt>17 (0x11)</dt></dl>
</td>
<td>
<p>Power Save - Warning</p>
<p>The device is in a warning state, though also in a power save mode.</p>
</td>
</tr>
</tbody>
</table>
<p>&nbsp;</p>
</dd><dt><strong>AvailableJobSheets</strong></dt><dd>
<dl><dt>Data type: <strong>string</strong> array</dt><dt>Access type: Read-only</dt></dl>
<p>&nbsp;</p>
<p>Array of all&nbsp; the job sheets available on a&nbsp; printer. Can also be used to describe the banner that a printer might provide at the beginning of each job, or other user-specified options. This property is inherited from
<a href="http://msdn.microsoft.com/en-us/library/windows/desktop/aa387974(v=vs.85).aspx">
<strong>CIM_Printer</strong></a>.</p>
<blockquote>
<div><strong>Windows&nbsp;2000 and Windows&nbsp;NT&nbsp;4.0:&nbsp;&nbsp;</strong>This property is not supported.</div>
</blockquote>
</dd><dt><strong>AveragePagesPerMinute</strong></dt><dd>
<dl><dt>Data type: <strong>uint32</strong></dt><dt>Access type: Read-only</dt></dl>
<p>&nbsp;</p>
<p>Printing rate, in average number of pages per minute,&nbsp; that a&nbsp; printer&nbsp; can produce output.</p>
</dd><dt><strong>Capabilities</strong></dt><dd>
<dl><dt>Data type: <strong>uint16</strong> array</dt><dt>Access type: Read-only</dt></dl>
<p>&nbsp;</p>
<p>Array of printer capabilities. This property is inherited from <a href="http://msdn.microsoft.com/en-us/library/windows/desktop/aa387974(v=vs.85).aspx">
<strong>CIM_Printer</strong></a>.</p>
<table>
<tbody>
<tr>
<th>Value</th>
<th>Meaning</th>
</tr>
<tr>
<td>
<dl><dt>0 (0x0)</dt></dl>
</td>
<td>
<p>Unknown</p>
</td>
</tr>
<tr>
<td>
<dl><dt>1 (0x1)</dt></dl>
</td>
<td>
<p>Other</p>
</td>
</tr>
<tr>
<td>
<dl><dt>2 (0x2)</dt></dl>
</td>
<td>
<p>Color Printing</p>
</td>
</tr>
<tr>
<td>
<dl><dt>3 (0x3)</dt></dl>
</td>
<td>
<p>Duplex Printing</p>
</td>
</tr>
<tr>
<td>
<dl><dt>4 (0x4)</dt></dl>
</td>
<td>
<p>Copies</p>
</td>
</tr>
<tr>
<td>
<dl><dt>5 (0x5)</dt></dl>
</td>
<td>
<p>Collation</p>
</td>
</tr>
<tr>
<td>
<dl><dt>6 (0x6)</dt></dl>
</td>
<td>
<p>Stapling</p>
</td>
</tr>
<tr>
<td>
<dl><dt>7 (0x7)</dt></dl>
</td>
<td>
<p>Transparency Printing</p>
</td>
</tr>
<tr>
<td>
<dl><dt>8 (0x8)</dt></dl>
</td>
<td>
<p>Punch</p>
</td>
</tr>
<tr>
<td>
<dl><dt>9 (0x9)</dt></dl>
</td>
<td>
<p>Cover</p>
</td>
</tr>
<tr>
<td>
<dl><dt>10 (0xA)</dt></dl>
</td>
<td>
<p>Bind</p>
</td>
</tr>
<tr>
<td>
<dl><dt>11 (0xB)</dt></dl>
</td>
<td>
<p>Black and White Printing</p>
</td>
</tr>
<tr>
<td>
<dl><dt>12 (0xC)</dt></dl>
</td>
<td>
<p>One-Sided</p>
</td>
</tr>
<tr>
<td>
<dl><dt>13 (0xD)</dt></dl>
</td>
<td>
<p>Two-Sided Long Edge</p>
</td>
</tr>
<tr>
<td>
<dl><dt>14 (0xE)</dt></dl>
</td>
<td>
<p>Two-Sided Short Edge</p>
</td>
</tr>
<tr>
<td>
<dl><dt>15 (0xF)</dt></dl>
</td>
<td>
<p>Portrait</p>
</td>
</tr>
<tr>
<td>
<dl><dt>16 (0x10)</dt></dl>
</td>
<td>
<p>Landscape</p>
</td>
</tr>
<tr>
<td>
<dl><dt>17 (0x11)</dt></dl>
</td>
<td>
<p>Reverse Portrait</p>
</td>
</tr>
<tr>
<td>
<dl><dt>18 (0x12)</dt></dl>
</td>
<td>
<p>Reverse Landscape</p>
</td>
</tr>
<tr>
<td>
<dl><dt>19 (0x13)</dt></dl>
</td>
<td>
<p>Quality High</p>
</td>
</tr>
<tr>
<td>
<dl><dt>20 (0x14)</dt></dl>
</td>
<td>
<p>Quality Normal</p>
</td>
</tr>
<tr>
<td>
<dl><dt>21 (0x15)</dt></dl>
</td>
<td>
<p>Quality Low</p>
</td>
</tr>
</tbody>
</table>
<p>&nbsp;</p>
</dd><dt><strong>CapabilityDescriptions</strong></dt><dd>
<dl><dt>Data type: <strong>string</strong> array</dt><dt>Access type: Read-only</dt></dl>
<p>&nbsp;</p>
<p>Array of free-form strings that provide&nbsp; detailed explanations for&nbsp; the printer features indicated in the
<strong>Capabilities</strong> array. Each&nbsp; entry of this array is related to an&nbsp; entry in the
<strong>Capabilities</strong> array that is located in&nbsp; the same index. This property is inherited from
<a href="http://msdn.microsoft.com/en-us/library/windows/desktop/aa387974(v=vs.85).aspx">
<strong>CIM_Printer</strong></a>.</p>
</dd><dt><strong>Caption</strong></dt><dd>
<dl><dt>Data type: <strong>string</strong></dt><dt>Access type: Read-only</dt><dt>Qualifiers: <a href="http://msdn.microsoft.com/en-us/library/windows/desktop/aa393650(v=vs.85).aspx">
<strong>MaxLen</strong></a>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
 (64)&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
</dt></dl>
<p>&nbsp;</p>
<p>Short description&nbsp; of an&nbsp; object&mdash;a one-line string. This property is inherited from
<a href="http://msdn.microsoft.com/en-us/library/windows/desktop/aa387898(v=vs.85).aspx">
<strong>CIM_ManagedSystemElement</strong></a>.</p>
</dd><dt><strong>CharSetsSupported</strong></dt><dd>
<dl><dt>Data type: <strong>string</strong> array</dt><dt>Access type: Read-only</dt></dl>
<p>&nbsp;</p>
<p>Array of available character sets for&nbsp; output. Strings provided in this property must&nbsp; conform to the semantics and syntax specified by section 4.1.2 (&quot;Charset parameters&quot;) in RFC 2046 (MIME Part 2) and contained in the IANA character-set registry.
 Examples include, UTF-8, us-ASCII, and iso-8859-1. This property is inherited from
<a href="http://msdn.microsoft.com/en-us/library/windows/desktop/aa387974(v=vs.85).aspx">
<strong>CIM_Printer</strong></a>.</p>
<blockquote>
<div><strong>Windows&nbsp;2000 and Windows&nbsp;NT&nbsp;4.0:&nbsp;&nbsp;</strong>This property is not supported.</div>
</blockquote>
</dd><dt><strong>Comment</strong></dt><dd>
<dl><dt>Data type: <strong>string</strong></dt><dt>Access type: Read/write</dt></dl>
<p>&nbsp;</p>
<p>Comment for a print queue.</p>
<blockquote>
<div><strong>Windows&nbsp;2000 and Windows&nbsp;NT&nbsp;4.0:&nbsp;&nbsp;</strong>This property is not supported.</div>
</blockquote>
<p>Example: Color printer</p>
</dd><dt><strong>ConfigManagerErrorCode</strong></dt><dd>
<dl><dt>Data type: <strong>uint32</strong></dt><dt>Access type: Read-only</dt></dl>
<p>&nbsp;</p>
<p>Win32 Configuration Manager error code.</p>
<table>
<tbody>
<tr>
<th>Value</th>
<th>Meaning</th>
</tr>
<tr>
<td>
<dl><dt>0 (0x0)</dt></dl>
</td>
<td>
<p>Device is working properly.</p>
</td>
</tr>
<tr>
<td>
<dl><dt>1 (0x1)</dt></dl>
</td>
<td>
<p>Device is not configured correctly.</p>
</td>
</tr>
<tr>
<td>
<dl><dt>2 (0x2)</dt></dl>
</td>
<td>
<p>Windows cannot load the driver for this device.</p>
</td>
</tr>
<tr>
<td>
<dl><dt>3 (0x3)</dt></dl>
</td>
<td>
<p>Driver for this device might be corrupted, or the&nbsp; system may be&nbsp; low on memory or other resources.</p>
</td>
</tr>
<tr>
<td>
<dl><dt>4 (0x4)</dt></dl>
</td>
<td>
<p>Device is not working properly. One of its drivers or the&nbsp; registry might be corrupted.</p>
</td>
</tr>
<tr>
<td>
<dl><dt>5 (0x5)</dt></dl>
</td>
<td>
<p>Driver for the device requires a resource that Windows cannot manage.</p>
</td>
</tr>
<tr>
<td>
<dl><dt>6 (0x6)</dt></dl>
</td>
<td>
<p>Boot configuration for the device conflicts with other devices.</p>
</td>
</tr>
<tr>
<td>
<dl><dt>7 (0x7)</dt></dl>
</td>
<td>
<p>Cannot filter.</p>
</td>
</tr>
<tr>
<td>
<dl><dt>8 (0x8)</dt></dl>
</td>
<td>
<p>Driver loader for the device is missing.</p>
</td>
</tr>
<tr>
<td>
<dl><dt>9 (0x9)</dt></dl>
</td>
<td>
<p>Device is not working properly.&nbsp; The controlling firmware is incorrectly reporting the resources for the device.</p>
</td>
</tr>
<tr>
<td>
<dl><dt>10 (0xA)</dt></dl>
</td>
<td>
<p>Device cannot start.</p>
</td>
</tr>
<tr>
<td>
<dl><dt>11 (0xB)</dt></dl>
</td>
<td>
<p>Device failed.</p>
</td>
</tr>
<tr>
<td>
<dl><dt>12 (0xC)</dt></dl>
</td>
<td>
<p>Device cannot find enough free resources to use.</p>
</td>
</tr>
<tr>
<td>
<dl><dt>13 (0xD)</dt></dl>
</td>
<td>
<p>Windows cannot verify the device's resources.</p>
</td>
</tr>
<tr>
<td>
<dl><dt>14 (0xE)</dt></dl>
</td>
<td>
<p>Device cannot work properly until the computer is restarted.</p>
</td>
</tr>
<tr>
<td>
<dl><dt>15 (0xF)</dt></dl>
</td>
<td>
<p>Device is not working properly due to a possible re-enumeration problem.</p>
</td>
</tr>
<tr>
<td>
<dl><dt>16 (0x10)</dt></dl>
</td>
<td>
<p>Windows cannot identify all of the resources that the device uses.</p>
</td>
</tr>
<tr>
<td>
<dl><dt>17 (0x11)</dt></dl>
</td>
<td>
<p>Device is requesting&nbsp; an unknown resource type.</p>
</td>
</tr>
<tr>
<td>
<dl><dt>18 (0x12)</dt></dl>
</td>
<td>
<p>Device drivers must be reinstalled.</p>
</td>
</tr>
<tr>
<td>
<dl><dt>19 (0x13)</dt></dl>
</td>
<td>
<p>Failure using the VxD loader.</p>
</td>
</tr>
<tr>
<td>
<dl><dt>20 (0x14)</dt></dl>
</td>
<td>
<p>Registry might be corrupted.</p>
</td>
</tr>
<tr>
<td>
<dl><dt>21 (0x15)</dt></dl>
</td>
<td>
<p>System failure. If changing the device driver is ineffective, see the hardware documentation. Windows is removing the device.</p>
</td>
</tr>
<tr>
<td>
<dl><dt>22 (0x16)</dt></dl>
</td>
<td>
<p>Device is disabled.</p>
</td>
</tr>
<tr>
<td>
<dl><dt>23 (0x17)</dt></dl>
</td>
<td>
<p>System failure. If changing the device driver is ineffective, see the hardware documentation.</p>
</td>
</tr>
<tr>
<td>
<dl><dt>24 (0x18)</dt></dl>
</td>
<td>
<p>Device is not present,&nbsp; not working properly, or does not have all of its drivers installed.</p>
</td>
</tr>
<tr>
<td>
<dl><dt>25 (0x19)</dt></dl>
</td>
<td>
<p>Windows is still setting up the device.</p>
</td>
</tr>
<tr>
<td>
<dl><dt>26 (0x1A)</dt></dl>
</td>
<td>
<p>Windows is still setting up the device.</p>
</td>
</tr>
<tr>
<td>
<dl><dt>27 (0x1B)</dt></dl>
</td>
<td>
<p>Device does not have a valid log configuration.</p>
</td>
</tr>
<tr>
<td>
<dl><dt>28 (0x1C)</dt></dl>
</td>
<td>
<p>Device drivers&nbsp;&nbsp; are not installed.</p>
</td>
</tr>
<tr>
<td>
<dl><dt>29 (0x1D)</dt></dl>
</td>
<td>
<p>Device is disabled.&nbsp; The device firmware&nbsp;&nbsp; did not provide&nbsp; the required resources.</p>
</td>
</tr>
<tr>
<td>
<dl><dt>30 (0x1E)</dt></dl>
</td>
<td>
<p>Device is using an IRQ resource that another device is using.</p>
</td>
</tr>
<tr>
<td>
<dl><dt>31 (0x1F)</dt></dl>
</td>
<td>
<p>Device is not working properly.&nbsp; Windows cannot load the&nbsp; required device drivers.</p>
</td>
</tr>
</tbody>
</table>
<p>&nbsp;</p>
</dd><dt><strong>ConfigManagerUserConfig</strong></dt><dd>
<dl><dt>Data type: <strong>boolean</strong></dt><dt>Access type: Read-only</dt></dl>
<p>&nbsp;</p>
<p>If <strong>TRUE</strong>, the device is using a user-defined configuration. This property is inherited from
<a href="http://msdn.microsoft.com/en-us/library/windows/desktop/aa387884(v=vs.85).aspx">
<strong>CIM_LogicalDevice</strong></a>.</p>
</dd><dt><strong>CreationClassName</strong></dt><dd>
<dl><dt>Data type: <strong>string</strong></dt><dt>Access type: Read-only</dt></dl>
<p>&nbsp;</p>
<p>Name of the first concrete class to appear in the inheritance chain used to create&nbsp; an instance. When used with&nbsp; other key properties of the class, the property allows all instances of this class and its subclasses to be identified uniquely. This
 property is inherited from <a href="http://msdn.microsoft.com/en-us/library/windows/desktop/aa387884(v=vs.85).aspx">
<strong>CIM_LogicalDevice</strong></a>.</p>
</dd><dt><strong>CurrentCapabilities</strong></dt><dd>
<dl><dt>Data type: <strong>uint16</strong> array</dt><dt>Access type: Read-only</dt></dl>
<p>&nbsp;</p>
<p>Array of printer capabilities that are&nbsp; being used currently. An entry in this property must also be listed in the
<strong>Capabilities</strong> array. This property is inherited from <a href="http://msdn.microsoft.com/en-us/library/windows/desktop/aa387974(v=vs.85).aspx">
<strong>CIM_Printer</strong></a>.</p>
<blockquote>
<div><strong>Windows&nbsp;2000 and Windows&nbsp;NT&nbsp;4.0:&nbsp;&nbsp;</strong>This property is not supported.</div>
</blockquote>
<table>
<tbody>
<tr>
<th>Value</th>
<th>Meaning</th>
</tr>
<tr>
<td>
<dl><dt>0 (0x0)</dt></dl>
</td>
<td>
<p>Unknown</p>
</td>
</tr>
<tr>
<td>
<dl><dt>1 (0x1)</dt></dl>
</td>
<td>
<p>Other</p>
</td>
</tr>
<tr>
<td>
<dl><dt>2 (0x2)</dt></dl>
</td>
<td>
<p>Color Printing</p>
</td>
</tr>
<tr>
<td>
<dl><dt>3 (0x3)</dt></dl>
</td>
<td>
<p>Duplex Printing</p>
</td>
</tr>
<tr>
<td>
<dl><dt>4 (0x4)</dt></dl>
</td>
<td>
<p>Copies</p>
</td>
</tr>
<tr>
<td>
<dl><dt>5 (0x5)</dt></dl>
</td>
<td>
<p>Collation</p>
</td>
</tr>
<tr>
<td>
<dl><dt>6 (0x6)</dt></dl>
</td>
<td>
<p>Stapling</p>
</td>
</tr>
<tr>
<td>
<dl><dt>7 (0x7)</dt></dl>
</td>
<td>
<p>Transparency Printing</p>
</td>
</tr>
<tr>
<td>
<dl><dt>8 (0x8)</dt></dl>
</td>
<td>
<p>Punch</p>
</td>
</tr>
<tr>
<td>
<dl><dt>9 (0x9)</dt></dl>
</td>
<td>
<p>Cover</p>
</td>
</tr>
<tr>
<td>
<dl><dt>10 (0xA)</dt></dl>
</td>
<td>
<p>Bind</p>
</td>
</tr>
<tr>
<td>
<dl><dt>11 (0xB)</dt></dl>
</td>
<td>
<p>Black and White Printing</p>
</td>
</tr>
<tr>
<td>
<dl><dt>12 (0xC)</dt></dl>
</td>
<td>
<p>One-Sided</p>
</td>
</tr>
<tr>
<td>
<dl><dt>13 (0xD)</dt></dl>
</td>
<td>
<p>Two-Sided Long Edge</p>
</td>
</tr>
<tr>
<td>
<dl><dt>14 (0xE)</dt></dl>
</td>
<td>
<p>Two-Sided Short Edge</p>
</td>
</tr>
<tr>
<td>
<dl><dt>15 (0xF)</dt></dl>
</td>
<td>
<p>Portrait</p>
</td>
</tr>
<tr>
<td>
<dl><dt>16 (0x10)</dt></dl>
</td>
<td>
<p>Landscape</p>
</td>
</tr>
<tr>
<td>
<dl><dt>17 (0x11)</dt></dl>
</td>
<td>
<p>Reverse Portrait</p>
</td>
</tr>
<tr>
<td>
<dl><dt>18 (0x12)</dt></dl>
</td>
<td>
<p>Reverse Landscape</p>
</td>
</tr>
<tr>
<td>
<dl><dt>19 (0x13)</dt></dl>
</td>
<td>
<p>Quality High</p>
</td>
</tr>
<tr>
<td>
<dl><dt>20 (0x14)</dt></dl>
</td>
<td>
<p>Quality Normal</p>
</td>
</tr>
<tr>
<td>
<dl><dt>21 (0x15)</dt></dl>
</td>
<td>
<p>Quality Low</p>
</td>
</tr>
</tbody>
</table>
<p>&nbsp;</p>
</dd><dt><strong>CurrentCharSet</strong></dt><dd>
<dl><dt>Data type: <strong>string</strong></dt><dt>Access type: Read-only</dt></dl>
<p>&nbsp;</p>
<p>The character set currently&nbsp; used for output. Strings provided in this property must conform to the semantics and syntax specified by section 4.1.2 (&quot;Charset parameters&quot;) in RFC 2046 (MIME Part 2) and contained in the IANA character-set registry. Examples
 include, utf-8, us-ASCII, and iso-8859-1. This property is inherited from <a href="http://msdn.microsoft.com/en-us/library/windows/desktop/aa387974(v=vs.85).aspx">
<strong>CIM_Printer</strong></a>.</p>
<blockquote>
<div><strong>Windows&nbsp;2000 and Windows&nbsp;NT&nbsp;4.0:&nbsp;&nbsp;</strong>This property is not supported.</div>
</blockquote>
</dd><dt><strong>CurrentLanguage</strong></dt><dd>
<dl><dt>Data type: <strong>uint16</strong></dt><dt>Access type: Read-only</dt><dt>Qualifiers: <a href="http://msdn.microsoft.com/en-us/library/windows/desktop/aa393650(v=vs.85).aspx">
<strong>ValueMap</strong></a> </dt></dl>
<p>&nbsp;</p>
<p>Printer language currently&nbsp; used. The language used must&nbsp; be listed in the
<strong>LanguagesSupported</strong> property. This property is inherited from <a href="http://msdn.microsoft.com/en-us/library/windows/desktop/aa387974(v=vs.85).aspx">
<strong>CIM_Printer</strong></a>.</p>
<blockquote>
<div><strong>Windows&nbsp;2000 and Windows&nbsp;NT&nbsp;4.0:&nbsp;&nbsp;</strong>This property is not supported.</div>
</blockquote>
<table>
<tbody>
<tr>
<th>Value</th>
<th>Meaning</th>
</tr>
<tr>
<td>
<dl><dt>1 (0x1)</dt></dl>
</td>
<td>
<p>Other</p>
</td>
</tr>
<tr>
<td>
<dl><dt>2 (0x2)</dt></dl>
</td>
<td>
<p>Unknown</p>
</td>
</tr>
<tr>
<td>
<dl><dt>3 (0x3)</dt></dl>
</td>
<td>
<p>PCL</p>
</td>
</tr>
<tr>
<td>
<dl><dt>4 (0x4)</dt></dl>
</td>
<td>
<p>HPGL</p>
</td>
</tr>
<tr>
<td>
<dl><dt>5 (0x5)</dt></dl>
</td>
<td>
<p>PJL</p>
</td>
</tr>
<tr>
<td>
<dl><dt>6 (0x6)</dt></dl>
</td>
<td>
<p>PS</p>
</td>
</tr>
<tr>
<td>
<dl><dt>7 (0x7)</dt></dl>
</td>
<td>
<p>PSPrinter</p>
</td>
</tr>
<tr>
<td>
<dl><dt>8 (0x8)</dt></dl>
</td>
<td>
<p>IPDS</p>
</td>
</tr>
<tr>
<td>
<dl><dt>9 (0x9)</dt></dl>
</td>
<td>
<p>PPDS</p>
</td>
</tr>
<tr>
<td>
<dl><dt>10 (0xA)</dt></dl>
</td>
<td>
<p>EscapeP</p>
</td>
</tr>
<tr>
<td>
<dl><dt>11 (0xB)</dt></dl>
</td>
<td>
<p>Epson</p>
</td>
</tr>
<tr>
<td>
<dl><dt>12 (0xC)</dt></dl>
</td>
<td>
<p>DDIF</p>
</td>
</tr>
<tr>
<td>
<dl><dt>13 (0xD)</dt></dl>
</td>
<td>
<p>Interpress</p>
</td>
</tr>
<tr>
<td>
<dl><dt>14 (0xE)</dt></dl>
</td>
<td>
<p>ISO6429</p>
</td>
</tr>
<tr>
<td>
<dl><dt>15 (0xF)</dt></dl>
</td>
<td>
<p>LineData</p>
</td>
</tr>
<tr>
<td>
<dl><dt>16 (0x10)</dt></dl>
</td>
<td>
<p>DODCA</p>
</td>
</tr>
<tr>
<td>
<dl><dt>17 (0x11)</dt></dl>
</td>
<td>
<p>REGIS</p>
</td>
</tr>
<tr>
<td>
<dl><dt>18 (0x12)</dt></dl>
</td>
<td>
<p>SCS</p>
</td>
</tr>
<tr>
<td>
<dl><dt>19 (0x13)</dt></dl>
</td>
<td>
<p>SPDL</p>
</td>
</tr>
<tr>
<td>
<dl><dt>20 (0x14)</dt></dl>
</td>
<td>
<p>TEK4014</p>
</td>
</tr>
<tr>
<td>
<dl><dt>21 (0x15)</dt></dl>
</td>
<td>
<p>PDS</p>
</td>
</tr>
<tr>
<td>
<dl><dt>22 (0x16)</dt></dl>
</td>
<td>
<p>IGP</p>
</td>
</tr>
<tr>
<td>
<dl><dt>23 (0x17)</dt></dl>
</td>
<td>
<p>CodeV</p>
</td>
</tr>
<tr>
<td>
<dl><dt>24 (0x18)</dt></dl>
</td>
<td>
<p>DSCDSE</p>
</td>
</tr>
<tr>
<td>
<dl><dt>25 (0x19)</dt></dl>
</td>
<td>
<p>WPS</p>
</td>
</tr>
<tr>
<td>
<dl><dt>26 (0x1A)</dt></dl>
</td>
<td>
<p>LN03</p>
</td>
</tr>
<tr>
<td>
<dl><dt>27 (0x1B)</dt></dl>
</td>
<td>
<p>CCITT</p>
</td>
</tr>
<tr>
<td>
<dl><dt>28</dt></dl>
</td>
<td>
<p>QUIC</p>
</td>
</tr>
<tr>
<td>
<dl><dt>29 (0x1D)</dt></dl>
</td>
<td>
<p>CPAP</p>
</td>
</tr>
<tr>
<td>
<dl><dt>30 (0x1E)</dt></dl>
</td>
<td>
<p>DecPPL</p>
</td>
</tr>
<tr>
<td>
<dl><dt>31 (0x1F)</dt></dl>
</td>
<td>
<p>SimpleText</p>
</td>
</tr>
<tr>
<td>
<dl><dt>32 (0x20)</dt></dl>
</td>
<td>
<p>NPAP</p>
</td>
</tr>
<tr>
<td>
<dl><dt>33 (0x21)</dt></dl>
</td>
<td>
<p>DOC</p>
</td>
</tr>
<tr>
<td>
<dl><dt>34 (0x22)</dt></dl>
</td>
<td>
<p>imPress</p>
</td>
</tr>
<tr>
<td>
<dl><dt>35 (0x23)</dt></dl>
</td>
<td>
<p>Pinwriter</p>
</td>
</tr>
<tr>
<td>
<dl><dt>36 (0x24)</dt></dl>
</td>
<td>
<p>NPDL</p>
</td>
</tr>
<tr>
<td>
<dl><dt>37 (0x25)</dt></dl>
</td>
<td>
<p>NEC201PL</p>
</td>
</tr>
<tr>
<td>
<dl><dt>38 (0x26)</dt></dl>
</td>
<td>
<p>Automatic</p>
</td>
</tr>
<tr>
<td>
<dl><dt>39 (0x27)</dt></dl>
</td>
<td>
<p>Pages</p>
</td>
</tr>
<tr>
<td>
<dl><dt>40 (0x28)</dt></dl>
</td>
<td>
<p>LIPS</p>
</td>
</tr>
<tr>
<td>
<dl><dt>41 (0x29)</dt></dl>
</td>
<td>
<p>TIFF</p>
</td>
</tr>
<tr>
<td>
<dl><dt>42 (0x2A)</dt></dl>
</td>
<td>
<p>Diagnostic</p>
</td>
</tr>
<tr>
<td>
<dl><dt>43 (0x2B)</dt></dl>
</td>
<td>
<p>CaPSL</p>
</td>
</tr>
<tr>
<td>
<dl><dt>44 (0x2C)</dt></dl>
</td>
<td>
<p>EXCL</p>
</td>
</tr>
<tr>
<td>
<dl><dt>45 (0x2D)</dt></dl>
</td>
<td>
<p>LCDS</p>
</td>
</tr>
<tr>
<td>
<dl><dt>46 (0x2E)</dt></dl>
</td>
<td>
<p>XES</p>
</td>
</tr>
<tr>
<td>
<dl><dt>47 (0x2F)</dt></dl>
</td>
<td>
<p>MIME</p>
</td>
</tr>
<tr>
<td>
<dl><dt>48 (0x30)</dt></dl>
</td>
<td>
<p>XPS</p>
</td>
</tr>
<tr>
<td>
<dl><dt>49 (0x31)</dt></dl>
</td>
<td>
<p>HPGL2</p>
</td>
</tr>
<tr>
<td>
<dl><dt>50 (0x32)</dt></dl>
</td>
<td>
<p>PCLXL</p>
</td>
</tr>
</tbody>
</table>
<p>&nbsp;</p>
</dd><dt><strong>CurrentMimeType</strong></dt><dd>
<dl><dt>Data type: <strong>string</strong></dt><dt>Access type: Read-only</dt></dl>
<p>&nbsp;</p>
<p>MIME type currently&nbsp; being used if the <strong>CurrentLanguage</strong> is a MIME type (value = 47). This property is inherited from
<a href="http://msdn.microsoft.com/en-us/library/windows/desktop/aa387974(v=vs.85).aspx">
<strong>CIM_Printer</strong></a>.</p>
<blockquote>
<div><strong>Windows&nbsp;2000 and Windows&nbsp;NT&nbsp;4.0:&nbsp;&nbsp;</strong>This property is not supported.</div>
</blockquote>
</dd><dt><strong>CurrentNaturalLanguage</strong></dt><dd>
<dl><dt>Data type: <strong>string</strong></dt><dt>Access type: Read-only</dt></dl>
<p>&nbsp;</p>
<p>Language that&nbsp; the printer is using for management currently. The language listed here must also be listed in the
<strong>NaturalLanguagesSupported</strong> property. This property is inherited from
<a href="http://msdn.microsoft.com/en-us/library/windows/desktop/aa387974(v=vs.85).aspx">
<strong>CIM_Printer</strong></a>.</p>
<blockquote>
<div><strong>Windows&nbsp;2000 and Windows&nbsp;NT&nbsp;4.0:&nbsp;&nbsp;</strong>This property is not supported.</div>
</blockquote>
</dd><dt><strong>CurrentPaperType</strong></dt><dd>
<dl><dt>Data type: <strong>string</strong></dt><dt>Access type: Read-only</dt></dl>
<p>&nbsp;</p>
<p>Type of paper the printer is&nbsp; using. Must be expressed in the form specified by the ISO/IEC&nbsp;10175 Document Printing Application&nbsp; (DPA), which is summarized in Appendix&nbsp;C of RFC&nbsp;1759 (Printer&nbsp;MIB). This property is inherited
 from <a href="http://msdn.microsoft.com/en-us/library/windows/desktop/aa387974(v=vs.85).aspx">
<strong>CIM_Printer</strong></a>.</p>
<blockquote>
<div><strong>Windows&nbsp;2000 and Windows&nbsp;NT&nbsp;4.0:&nbsp;&nbsp;</strong>This property is not supported.</div>
</blockquote>
</dd><dt><strong>Default</strong></dt><dd>
<dl><dt>Data type: <strong>boolean</strong></dt><dt>Access type: Read-only</dt></dl>
<p>&nbsp;</p>
<p>If <strong>TRUE</strong>, the printer is the default printer.</p>
<blockquote>
<div><strong>Windows&nbsp;2000 and Windows&nbsp;NT&nbsp;4.0:&nbsp;&nbsp;</strong>This property is not supported.</div>
</blockquote>
</dd><dt><strong>DefaultCapabilities</strong></dt><dd>
<dl><dt>Data type: <strong>uint16</strong> array</dt><dt>Access type: Read-only</dt></dl>
<p>&nbsp;</p>
<p>Array of the printer capabilities&nbsp; used by default. Each entry in the <strong>
DefaultCapabilities</strong> array must also be listed in the <strong>Capabilities</strong> array. This property is inherited from
<a href="http://msdn.microsoft.com/en-us/library/windows/desktop/aa387974(v=vs.85).aspx">
<strong>CIM_Printer</strong></a>.</p>
<blockquote>
<div><strong>Windows&nbsp;2000 and Windows&nbsp;NT&nbsp;4.0:&nbsp;&nbsp;</strong>This property is not supported.</div>
</blockquote>
<table>
<tbody>
<tr>
<th>Value</th>
<th>Meaning</th>
</tr>
<tr>
<td>
<dl><dt>0 (0x0)</dt></dl>
</td>
<td>
<p>Unknown</p>
</td>
</tr>
<tr>
<td>
<dl><dt>1 (0x1)</dt></dl>
</td>
<td>
<p>Other</p>
</td>
</tr>
<tr>
<td>
<dl><dt>2 (0x2)</dt></dl>
</td>
<td>
<p>Color Printing</p>
</td>
</tr>
<tr>
<td>
<dl><dt>3 (0x3)</dt></dl>
</td>
<td>
<p>Duplex Printing</p>
</td>
</tr>
<tr>
<td>
<dl><dt>4 (0x4)</dt></dl>
</td>
<td>
<p>Copies</p>
</td>
</tr>
<tr>
<td>
<dl><dt>5 (0x5)</dt></dl>
</td>
<td>
<p>Collation</p>
</td>
</tr>
<tr>
<td>
<dl><dt>6 (0x6)</dt></dl>
</td>
<td>
<p>Stapling</p>
</td>
</tr>
<tr>
<td>
<dl><dt>7</dt></dl>
</td>
<td>
<p>Transparency Printing</p>
</td>
</tr>
<tr>
<td>
<dl><dt>8 (0x8)</dt></dl>
</td>
<td>
<p>Punch</p>
</td>
</tr>
<tr>
<td>
<dl><dt>9 (0x9)</dt></dl>
</td>
<td>
<p>Cover</p>
</td>
</tr>
<tr>
<td>
<dl><dt>10 (0xA)</dt></dl>
</td>
<td>
<p>Bind</p>
</td>
</tr>
<tr>
<td>
<dl><dt>11 (0xB)</dt></dl>
</td>
<td>
<p>Black and White Printing</p>
</td>
</tr>
<tr>
<td>
<dl><dt>12 (0xC)</dt></dl>
</td>
<td>
<p>One-Sided</p>
</td>
</tr>
<tr>
<td>
<dl><dt>13 (0xD)</dt></dl>
</td>
<td>
<p>Two-Sided Long Edge</p>
</td>
</tr>
<tr>
<td>
<dl><dt>14 (0xE)</dt></dl>
</td>
<td>
<p>Two-Sided Short Edge</p>
</td>
</tr>
<tr>
<td>
<dl><dt>15 (0xF)</dt></dl>
</td>
<td>
<p>Portrait</p>
</td>
</tr>
<tr>
<td>
<dl><dt>16</dt></dl>
</td>
<td>
<p>Landscape</p>
</td>
</tr>
<tr>
<td>
<dl><dt>17 (0x11)</dt></dl>
</td>
<td>
<p>Reverse Portrait</p>
</td>
</tr>
<tr>
<td>
<dl><dt>18 (0x12)</dt></dl>
</td>
<td>
<p>Reverse Landscape</p>
</td>
</tr>
<tr>
<td>
<dl><dt>19 (0x13)</dt></dl>
</td>
<td>
<p>Quality High</p>
</td>
</tr>
<tr>
<td>
<dl><dt>20 (0x14)</dt></dl>
</td>
<td>
<p>Quality Normal</p>
</td>
</tr>
<tr>
<td>
<dl><dt>21 (0x15)</dt></dl>
</td>
<td>
<p>Quality Low</p>
</td>
</tr>
</tbody>
</table>
<p>&nbsp;</p>
</dd><dt><strong>DefaultCopies</strong></dt><dd>
<dl><dt>Data type: <strong>uint32</strong></dt><dt>Access type: Read-only</dt></dl>
<p>&nbsp;</p>
<p>Number of copies produced for one&nbsp; job&mdash;unless otherwise specified. This property is inherited from
<a href="http://msdn.microsoft.com/en-us/library/windows/desktop/aa387974(v=vs.85).aspx">
<strong>CIM_Printer</strong></a>.</p>
<blockquote>
<div><strong>Windows&nbsp;2000 and Windows&nbsp;NT&nbsp;4.0:&nbsp;&nbsp;</strong>This property is not supported.</div>
</blockquote>
</dd><dt><strong>DefaultLanguage</strong></dt><dd>
<dl><dt>Data type: <strong>uint16</strong></dt><dt>Access type: Read-only</dt></dl>
<p>&nbsp;</p>
<p>Default printer language. The language listed here must also be listed in the <strong>
LanguagesSupported</strong> property. This property is inherited from <a href="http://msdn.microsoft.com/en-us/library/windows/desktop/aa387974(v=vs.85).aspx">
<strong>CIM_Printer</strong></a>.</p>
<blockquote>
<div><strong>Windows&nbsp;2000 and Windows&nbsp;NT&nbsp;4.0:&nbsp;&nbsp;</strong>This property is not supported.</div>
</blockquote>
<table>
<tbody>
<tr>
<th>Value</th>
<th>Meaning</th>
</tr>
<tr>
<td>
<dl><dt>1 (0x1)</dt></dl>
</td>
<td>
<p>Other</p>
</td>
</tr>
<tr>
<td>
<dl><dt>2 (0x2)</dt></dl>
</td>
<td>
<p>Unknown</p>
</td>
</tr>
<tr>
<td>
<dl><dt>3 (0x3)</dt></dl>
</td>
<td>
<p>PCL</p>
</td>
</tr>
<tr>
<td>
<dl><dt>4 (0x4)</dt></dl>
</td>
<td>
<p>HPGL</p>
</td>
</tr>
<tr>
<td>
<dl><dt>5 (0x5)</dt></dl>
</td>
<td>
<p>PJL</p>
</td>
</tr>
<tr>
<td>
<dl><dt>6 (0x6)</dt></dl>
</td>
<td>
<p>PS</p>
</td>
</tr>
<tr>
<td>
<dl><dt>7 (0x7)</dt></dl>
</td>
<td>
<p>PSPrinter</p>
</td>
</tr>
<tr>
<td>
<dl><dt>8 (0x8)</dt></dl>
</td>
<td>
<p>IPDS</p>
</td>
</tr>
<tr>
<td>
<dl><dt>9 (0x9)</dt></dl>
</td>
<td>
<p>PPDS</p>
</td>
</tr>
<tr>
<td>
<dl><dt>10 (0xA)</dt></dl>
</td>
<td>
<p>EscapeP</p>
</td>
</tr>
<tr>
<td>
<dl><dt>11 (0xB)</dt></dl>
</td>
<td>
<p>Epson</p>
</td>
</tr>
<tr>
<td>
<dl><dt>12 (0xC)</dt></dl>
</td>
<td>
<p>DDIF</p>
</td>
</tr>
<tr>
<td>
<dl><dt>13 (0xD)</dt></dl>
</td>
<td>
<p>Interpress</p>
</td>
</tr>
<tr>
<td>
<dl><dt>14 (0xE)</dt></dl>
</td>
<td>
<p>ISO6429</p>
</td>
</tr>
<tr>
<td>
<dl><dt>15 (0xF)</dt></dl>
</td>
<td>
<p>LineData</p>
</td>
</tr>
<tr>
<td>
<dl><dt>16 (0x10)</dt></dl>
</td>
<td>
<p>DODCA</p>
</td>
</tr>
<tr>
<td>
<dl><dt>17 (0x11)</dt></dl>
</td>
<td>
<p>REGIS</p>
</td>
</tr>
<tr>
<td>
<dl><dt>18 (0x12)</dt></dl>
</td>
<td>
<p>SCS</p>
</td>
</tr>
<tr>
<td>
<dl><dt>19 (0x13)</dt></dl>
</td>
<td>
<p>SPDL</p>
</td>
</tr>
<tr>
<td>
<dl><dt>20 (0x14)</dt></dl>
</td>
<td>
<p>TEK4014</p>
</td>
</tr>
<tr>
<td>
<dl><dt>21 (0x15)</dt></dl>
</td>
<td>
<p>PDS</p>
</td>
</tr>
<tr>
<td>
<dl><dt>22 (0x16)</dt></dl>
</td>
<td>
<p>IGP</p>
</td>
</tr>
<tr>
<td>
<dl><dt>23 (0x17)</dt></dl>
</td>
<td>
<p>CodeV</p>
</td>
</tr>
<tr>
<td>
<dl><dt>24 (0x18)</dt></dl>
</td>
<td>
<p>DSCDSE</p>
</td>
</tr>
<tr>
<td>
<dl><dt>25 (0x19)</dt></dl>
</td>
<td>
<p>WPS</p>
</td>
</tr>
<tr>
<td>
<dl><dt>26 (0x1A)</dt></dl>
</td>
<td>
<p>LN03</p>
</td>
</tr>
<tr>
<td>
<dl><dt>27 (0x1B)</dt></dl>
</td>
<td>
<p>CCITT</p>
</td>
</tr>
<tr>
<td>
<dl><dt>28 (0x1C)</dt></dl>
</td>
<td>
<p>QUIC</p>
</td>
</tr>
<tr>
<td>
<dl><dt>29 (0x1D)</dt></dl>
</td>
<td>
<p>CPAP</p>
</td>
</tr>
<tr>
<td>
<dl><dt>30 (0x1E)</dt></dl>
</td>
<td>
<p>DecPPL</p>
</td>
</tr>
<tr>
<td>
<dl><dt>31 (0x1F)</dt></dl>
</td>
<td>
<p>SimpleText</p>
</td>
</tr>
<tr>
<td>
<dl><dt>32 (0x20)</dt></dl>
</td>
<td>
<p>NPAP</p>
</td>
</tr>
<tr>
<td>
<dl><dt>33 (0x21)</dt></dl>
</td>
<td>
<p>DOC</p>
</td>
</tr>
<tr>
<td>
<dl><dt>34 (0x22)</dt></dl>
</td>
<td>
<p>imPress</p>
</td>
</tr>
<tr>
<td>
<dl><dt>35 (0x23)</dt></dl>
</td>
<td>
<p>Pinwriter</p>
</td>
</tr>
<tr>
<td>
<dl><dt>36 (0x24)</dt></dl>
</td>
<td>
<p>NPDL</p>
</td>
</tr>
<tr>
<td>
<dl><dt>37 (0x25)</dt></dl>
</td>
<td>
<p>NEC201PL</p>
</td>
</tr>
<tr>
<td>
<dl><dt>38 (0x26)</dt></dl>
</td>
<td>
<p>Automatic</p>
</td>
</tr>
<tr>
<td>
<dl><dt>39 (0x27)</dt></dl>
</td>
<td>
<p>Pages</p>
</td>
</tr>
<tr>
<td>
<dl><dt>40 (0x28)</dt></dl>
</td>
<td>
<p>LIPS</p>
</td>
</tr>
<tr>
<td>
<dl><dt>41 (0x29)</dt></dl>
</td>
<td>
<p>TIFF</p>
</td>
</tr>
<tr>
<td>
<dl><dt>42 (0x2A)</dt></dl>
</td>
<td>
<p>Diagnostic</p>
</td>
</tr>
<tr>
<td>
<dl><dt>43 (0x2B)</dt></dl>
</td>
<td>
<p>CaPSL</p>
</td>
</tr>
<tr>
<td>
<dl><dt>44 (0x2C)</dt></dl>
</td>
<td>
<p>EXCL</p>
</td>
</tr>
<tr>
<td>
<dl><dt>45 (0x2D)</dt></dl>
</td>
<td>
<p>LCDS</p>
</td>
</tr>
<tr>
<td>
<dl><dt>46 (0x2E)</dt></dl>
</td>
<td>
<p>XES</p>
</td>
</tr>
<tr>
<td>
<dl><dt>47 (0x2F)</dt></dl>
</td>
<td>
<p>MIME</p>
</td>
</tr>
<tr>
<td>
<dl><dt>48 (0x30)</dt></dl>
</td>
<td>
<p>XPS</p>
</td>
</tr>
<tr>
<td>
<dl><dt>49 (0x31)</dt></dl>
</td>
<td>
<p>HPGL2</p>
</td>
</tr>
<tr>
<td>
<dl><dt>50 (0x32)</dt></dl>
</td>
<td>
<p>PCLXL</p>
</td>
</tr>
</tbody>
</table>
<p>&nbsp;</p>
</dd><dt><strong>DefaultMimeType</strong></dt><dd>
<dl><dt>Data type: <strong>string</strong></dt><dt>Access type: Read-only</dt></dl>
<p>&nbsp;</p>
<p>MIME type currently being used, if the <strong>DefaultLanguage</strong> value is a MIME type (value = 47). This property is inherited from
<a href="http://msdn.microsoft.com/en-us/library/windows/desktop/aa387974(v=vs.85).aspx">
<strong>CIM_Printer</strong></a>.</p>
<blockquote>
<div><strong>Windows&nbsp;2000 and Windows&nbsp;NT&nbsp;4.0:&nbsp;&nbsp;</strong>This property is not supported.</div>
</blockquote>
</dd><dt><strong>DefaultNumberUp</strong></dt><dd>
<dl><dt>Data type: <strong>uint32</strong></dt><dt>Access type: Read-only</dt></dl>
<p>&nbsp;</p>
<p>&nbsp; Number of print-stream pages that the printer renders on one&nbsp; media sheet&mdash;unless a job specifies otherwise. This property is inherited from
<a href="http://msdn.microsoft.com/en-us/library/windows/desktop/aa387974(v=vs.85).aspx">
<strong>CIM_Printer</strong></a>.</p>
<blockquote>
<div><strong>Windows&nbsp;2000 and Windows&nbsp;NT&nbsp;4.0:&nbsp;&nbsp;</strong>This property is not supported.</div>
</blockquote>
</dd><dt><strong>DefaultPaperType</strong></dt><dd>
<dl><dt>Data type: <strong>string</strong></dt><dt>Access type: Read-only</dt></dl>
<p>&nbsp;</p>
<p>Paper type that the printer uses&mdash;unless a print job specifies a different paper&nbsp; type. The string must be expressed in the form specified by ISO/IEC&nbsp;1017 Document Printing Application (DPA),&nbsp; which is summarized in Appendix&nbsp;C of
<a href="http://go.microsoft.com/FWLink/?LinkId=84407">RFC&nbsp;1759</a> (Printer MIB). This property is inherited from
<a href="http://msdn.microsoft.com/en-us/library/windows/desktop/aa387974(v=vs.85).aspx">
<strong>CIM_Printer</strong></a>.</p>
<blockquote>
<div><strong>Windows&nbsp;2000 and Windows&nbsp;NT&nbsp;4.0:&nbsp;&nbsp;</strong>This property is not supported.</div>
</blockquote>
</dd><dt><strong>DefaultPriority</strong></dt><dd>
<dl><dt>Data type: <strong>uint32</strong></dt><dt>Access type: Read/write</dt></dl>
<p>&nbsp;</p>
<p>Default priority value assigned to each print job.</p>
</dd><dt><strong>Description</strong></dt><dd>
<dl><dt>Data type: <strong>string</strong></dt><dt>Access type: Read-only</dt></dl>
<p>&nbsp;</p>
<p>Description of an object. This property is inherited from <a href="http://msdn.microsoft.com/en-us/library/windows/desktop/aa387898(v=vs.85).aspx">
<strong>CIM_ManagedSystemElement</strong></a>.</p>
</dd><dt><strong>DetectedErrorState</strong></dt><dd>
<dl><dt>Data type: <strong>uint16</strong></dt><dt>Access type: Read-only</dt></dl>
<p>&nbsp;</p>
<p>Printer error information. This property is inherited from <a href="http://msdn.microsoft.com/en-us/library/windows/desktop/aa387974(v=vs.85).aspx">
<strong>CIM_Printer</strong></a>.</p>
<table>
<tbody>
<tr>
<th>Value</th>
<th>Meaning</th>
</tr>
<tr>
<td>
<dl><dt>0 (0x0)</dt></dl>
</td>
<td>
<p>Unknown</p>
</td>
</tr>
<tr>
<td>
<dl><dt>1 (0x1)</dt></dl>
</td>
<td>
<p>Other</p>
</td>
</tr>
<tr>
<td>
<dl><dt>2 (0x2)</dt></dl>
</td>
<td>
<p>No Error</p>
</td>
</tr>
<tr>
<td>
<dl><dt>3 (0x3)</dt></dl>
</td>
<td>
<p>Low Paper</p>
</td>
</tr>
<tr>
<td>
<dl><dt>4 (0x4)</dt></dl>
</td>
<td>
<p>No Paper</p>
</td>
</tr>
<tr>
<td>
<dl><dt>5 (0x5)</dt></dl>
</td>
<td>
<p>Low Toner</p>
</td>
</tr>
<tr>
<td>
<dl><dt>6 (0x6)</dt></dl>
</td>
<td>
<p>No Toner</p>
</td>
</tr>
<tr>
<td>
<dl><dt>7 (0x7)</dt></dl>
</td>
<td>
<p>Door Open</p>
</td>
</tr>
<tr>
<td>
<dl><dt>8 (0x8)</dt></dl>
</td>
<td>
<p>Jammed</p>
</td>
</tr>
<tr>
<td>
<dl><dt>9 (0x9)</dt></dl>
</td>
<td>
<p>Offline</p>
</td>
</tr>
<tr>
<td>
<dl><dt>10 (0xA)</dt></dl>
</td>
<td>
<p>Service Requested</p>
</td>
</tr>
<tr>
<td>
<dl><dt>11 (0xB)</dt></dl>
</td>
<td>
<p>Output Bin Full</p>
</td>
</tr>
</tbody>
</table>
<p>&nbsp;</p>
</dd><dt><strong>DeviceID</strong></dt><dd>
<dl><dt>Data type: <strong>string</strong></dt><dt>Access type: Read-only</dt><dt>Qualifiers: <a href="http://msdn.microsoft.com/en-us/library/windows/desktop/aa393650(v=vs.85).aspx">
<strong>Key</strong></a>, <a href="http://msdn.microsoft.com/en-us/library/windows/desktop/aa393650(v=vs.85).aspx">
<strong>Override</strong></a> </dt></dl>
<p>&nbsp;</p>
<p>Unique identifier of the printer&nbsp; on a&nbsp; system. This property is inherited from
<a href="http://msdn.microsoft.com/en-us/library/windows/desktop/aa387884(v=vs.85).aspx">
<strong>CIM_LogicalDevice</strong></a>.</p>
</dd><dt><strong>Direct</strong></dt><dd>
<dl><dt>Data type: <strong>boolean</strong></dt><dt>Access type: Read/write</dt></dl>
<p>&nbsp;</p>
<p>If <strong>TRUE</strong>, the print job is&nbsp; sent directly to the printer. If
<strong>FALSE</strong>, the print job is&nbsp; spooled.</p>
<blockquote>
<div><strong>Windows&nbsp;2000 and Windows&nbsp;NT&nbsp;4.0:&nbsp;&nbsp;</strong>This property is not supported.</div>
</blockquote>
</dd><dt><strong>DoCompleteFirst</strong></dt><dd>
<dl><dt>Data type: <strong>boolean</strong></dt><dt>Access type: Read/write</dt></dl>
<p>&nbsp;</p>
<p>If <strong>TRUE</strong>, the printer starts&nbsp; jobs that are finished spooling. If&nbsp;
<strong>FALSE</strong>, the printer starts jobs in the order that the jobs are&nbsp; received.</p>
<blockquote>
<div><strong>Windows&nbsp;2000 and Windows&nbsp;NT&nbsp;4.0:&nbsp;&nbsp;</strong>This property is not supported.</div>
</blockquote>
</dd><dt><strong>DriverName</strong></dt><dd>
<dl><dt>Data type: <strong>string</strong></dt><dt>Access type: Read/write</dt></dl>
<p>&nbsp;</p>
<p>Name of the Windows printer driver.</p>
<p>Example: Windows&nbsp;NT Fax Driver</p>
</dd><dt><strong>EnableBIDI</strong></dt><dd>
<dl><dt>Data type: <strong>boolean</strong></dt><dt>Access type: Read/write</dt></dl>
<p>&nbsp;</p>
<p>If <strong>TRUE</strong>, the printer can&nbsp; print bidirectionally.</p>
<blockquote>
<div><strong>Windows&nbsp;2000 and Windows&nbsp;NT&nbsp;4.0:&nbsp;&nbsp;</strong>This property is not supported.</div>
</blockquote>
</dd><dt><strong>EnableDevQueryPrint</strong></dt><dd>
<dl><dt>Data type: <strong>boolean</strong></dt><dt>Access type: Read/write</dt></dl>
<p>&nbsp;</p>
<p>If <strong>TRUE</strong>, the printer holds documents in the queue when document and printer setups do not match.</p>
<blockquote>
<div><strong>Windows&nbsp;2000 and Windows&nbsp;NT&nbsp;4.0:&nbsp;&nbsp;</strong>This property is not supported.</div>
</blockquote>
</dd><dt><strong>ErrorCleared</strong></dt><dd>
<dl><dt>Data type: <strong>boolean</strong></dt><dt>Access type: Read-only</dt></dl>
<p>&nbsp;</p>
<p>If <strong>TRUE</strong>, the error reported in <strong>LastErrorCode</strong> has been cleared. This property is inherited from
<a href="http://msdn.microsoft.com/en-us/library/windows/desktop/aa387884(v=vs.85).aspx">
<strong>CIM_LogicalDevice</strong></a>.</p>
</dd><dt><strong>ErrorDescription</strong></dt><dd>
<dl><dt>Data type: <strong>string</strong></dt><dt>Access type: Read-only</dt></dl>
<p>&nbsp;</p>
<p>Information&nbsp; about the error recorded in <strong>LastErrorCode</strong>, and information about corrective actions&nbsp; that can be taken. This property is inherited from
<a href="http://msdn.microsoft.com/en-us/library/windows/desktop/aa387884(v=vs.85).aspx">
<strong>CIM_LogicalDevice</strong></a>.</p>
</dd><dt><strong>ErrorInformation</strong></dt><dd>
<dl><dt>Data type: <strong>string</strong> array</dt><dt>Access type: Read/write</dt></dl>
<p>&nbsp;</p>
<p>Array of supplemental information for the current error state indicated in <strong>
DetectedErrorState</strong>. This property is inherited from <a href="http://msdn.microsoft.com/en-us/library/windows/desktop/aa387974(v=vs.85).aspx">
<strong>CIM_Printer</strong></a>.</p>
<blockquote>
<div><strong>Windows&nbsp;2000 and Windows&nbsp;NT&nbsp;4.0:&nbsp;&nbsp;</strong>This property is not supported.</div>
</blockquote>
</dd><dt><strong>ExtendedDetectedErrorState</strong></dt><dd>
<dl><dt>Data type: <strong>uint16</strong></dt><dt>Access type: Read-only</dt></dl>
<p>&nbsp;</p>
<p>Reports standard error information. Additional information should be recorded in
<strong>DetectedErrorState</strong>.</p>
<blockquote>
<div><strong>Windows&nbsp;2000 and Windows&nbsp;NT&nbsp;4.0:&nbsp;&nbsp;</strong>This property is not supported.</div>
</blockquote>
<p>Values are:</p>
<table>
<tbody>
<tr>
<th>Values</th>
<th>Meaning</th>
</tr>
<tr>
<td>
<dl><dt>0 (0x0)</dt></dl>
</td>
<td>
<p>Unknown</p>
</td>
</tr>
<tr>
<td>
<dl><dt>1 (0x1)</dt></dl>
</td>
<td>
<p>Other</p>
</td>
</tr>
<tr>
<td>
<dl><dt>2 (0x2)</dt></dl>
</td>
<td>
<p>No Error</p>
</td>
</tr>
<tr>
<td>
<dl><dt>3 (0x3)</dt></dl>
</td>
<td>
<p>Low Paper</p>
</td>
</tr>
<tr>
<td>
<dl><dt>4 (0x4)</dt></dl>
</td>
<td>
<p>No Paper</p>
</td>
</tr>
<tr>
<td>
<dl><dt>5 (0x5)</dt></dl>
</td>
<td>
<p>Low Toner</p>
</td>
</tr>
<tr>
<td>
<dl><dt>6 (0x6)</dt></dl>
</td>
<td>
<p>No Toner</p>
</td>
</tr>
<tr>
<td>
<dl><dt>7 (0x7)</dt></dl>
</td>
<td>
<p>Door Open</p>
</td>
</tr>
<tr>
<td>
<dl><dt>8 (0x8)</dt></dl>
</td>
<td>
<p>Jammed</p>
</td>
</tr>
<tr>
<td>
<dl><dt>9 (0x9)</dt></dl>
</td>
<td>
<p>Service Requested</p>
</td>
</tr>
<tr>
<td>
<dl><dt>10 (0xA)</dt></dl>
</td>
<td>
<p>Output Bin Full</p>
</td>
</tr>
<tr>
<td>
<dl><dt>11 (0xB)</dt></dl>
</td>
<td>
<p>Paper Problem</p>
</td>
</tr>
<tr>
<td>
<dl><dt>12 (0xC)</dt></dl>
</td>
<td>
<p>Cannot Print Page</p>
</td>
</tr>
<tr>
<td>
<dl><dt>13 (0xD)</dt></dl>
</td>
<td>
<p>User Intervention Required</p>
</td>
</tr>
<tr>
<td>
<dl><dt>14 (0xE)</dt></dl>
</td>
<td>
<p>Out of Memory</p>
</td>
</tr>
<tr>
<td>
<dl><dt>15 (0xF)</dt></dl>
</td>
<td>
<p>Server Unknown</p>
</td>
</tr>
</tbody>
</table>
<p>&nbsp;</p>
</dd><dt><strong>ExtendedPrinterStatus</strong></dt><dd>
<dl><dt>Data type: <strong>uint16</strong></dt><dt>Access type: Read-only</dt></dl>
<p>&nbsp;</p>
<p>Status information for a printer that is different from information specified in the
<strong>Availability</strong> property.</p>
<blockquote>
<div><strong>Windows&nbsp;2000 and Windows&nbsp;NT&nbsp;4.0:&nbsp;&nbsp;</strong>This property is not supported.</div>
</blockquote>
<table>
<tbody>
<tr>
<th>Value</th>
<th>Meaning</th>
</tr>
<tr>
<td>
<dl><dt>1 (0x1)</dt></dl>
</td>
<td>
<p>Other</p>
</td>
</tr>
<tr>
<td>
<dl><dt>2 (0x2)</dt></dl>
</td>
<td>
<p>Unknown</p>
</td>
</tr>
<tr>
<td>
<dl><dt>3 (0x3)</dt></dl>
</td>
<td>
<p>Idle</p>
</td>
</tr>
<tr>
<td>
<dl><dt>4 (0x4)</dt></dl>
</td>
<td>
<p>Printing</p>
</td>
</tr>
<tr>
<td>
<dl><dt>5 (0x5)</dt></dl>
</td>
<td>
<p>Warming Up</p>
</td>
</tr>
<tr>
<td>
<dl><dt>6 (0x6)</dt></dl>
</td>
<td>
<p>Stopped Printing</p>
</td>
</tr>
<tr>
<td>
<dl><dt>7</dt></dl>
</td>
<td>
<p>Offline</p>
</td>
</tr>
<tr>
<td>
<dl><dt>8 (0x8)</dt></dl>
</td>
<td>
<p>Paused</p>
</td>
</tr>
<tr>
<td>
<dl><dt>9 (0x9)</dt></dl>
</td>
<td>
<p>Error</p>
</td>
</tr>
<tr>
<td>
<dl><dt>10 (0xA)</dt></dl>
</td>
<td>
<p>Busy</p>
</td>
</tr>
<tr>
<td>
<dl><dt>11 (0xB)</dt></dl>
</td>
<td>
<p>Not Available</p>
</td>
</tr>
<tr>
<td>
<dl><dt>12 (0xC)</dt></dl>
</td>
<td>
<p>Waiting</p>
</td>
</tr>
<tr>
<td>
<dl><dt>13 (0xD)</dt></dl>
</td>
<td>
<p>Processing</p>
</td>
</tr>
<tr>
<td>
<dl><dt>14 (0xE)</dt></dl>
</td>
<td>
<p>Initialization</p>
</td>
</tr>
<tr>
<td>
<dl><dt>15</dt></dl>
</td>
<td>
<p>Power Save</p>
</td>
</tr>
<tr>
<td>
<dl><dt>16 (0x10)</dt></dl>
</td>
<td>
<p>Pending Deletion</p>
</td>
</tr>
<tr>
<td>
<dl><dt>17 (0x11)</dt></dl>
</td>
<td>
<p>I/O Active</p>
</td>
</tr>
<tr>
<td>
<dl><dt>18 (0x12)</dt></dl>
</td>
<td>
<p>Manual Feed</p>
</td>
</tr>
</tbody>
</table>
<p>&nbsp;</p>
</dd><dt><strong>Hidden</strong></dt><dd>
<dl><dt>Data type: <strong>boolean</strong></dt><dt>Access type: Read/write</dt></dl>
<p>&nbsp;</p>
<p>If <strong>TRUE</strong>, the printer is hidden from network users.</p>
<blockquote>
<div><strong>Windows&nbsp;2000 and Windows&nbsp;NT&nbsp;4.0:&nbsp;&nbsp;</strong>This property is not supported.</div>
</blockquote>
</dd><dt><strong>HorizontalResolution</strong></dt><dd>
<dl><dt>Data type: <strong>uint32</strong></dt><dt>Access type: Read-only</dt></dl>
<p>&nbsp;</p>
<p>Horizontal&nbsp; resolution of the printer&mdash;in pixels per inch. This property is inherited from
<a href="http://msdn.microsoft.com/en-us/library/windows/desktop/aa387974(v=vs.85).aspx">
<strong>CIM_Printer</strong></a>.</p>
</dd><dt><strong>InstallDate</strong></dt><dd>
<dl><dt>Data type: <strong>datetime</strong></dt><dt>Access type: Read-only</dt></dl>
<p>&nbsp;</p>
<p>Date and time an object was installed. The object may be installed without a value being written to this property.&nbsp; This property is inherited from
<a href="http://msdn.microsoft.com/en-us/library/windows/desktop/aa387898(v=vs.85).aspx">
<strong>CIM_ManagedSystemElement</strong></a>.</p>
</dd><dt><strong>JobCountSinceLastReset</strong></dt><dd>
<dl><dt>Data type: <strong>uint32</strong></dt><dt>Access type: Read-only</dt></dl>
<p>&nbsp;</p>
<p>Number of print jobs since the printer was last reset. This property is inherited from
<a href="http://msdn.microsoft.com/en-us/library/windows/desktop/aa387974(v=vs.85).aspx">
<strong>CIM_Printer</strong></a>.</p>
</dd><dt><strong>KeepPrintedJobs</strong></dt><dd>
<dl><dt>Data type: <strong>boolean</strong></dt><dt>Access type: Read/write</dt></dl>
<p>&nbsp;</p>
<p>If <strong>TRUE</strong>, the print spooler does&nbsp; not delete the completed jobs.</p>
<blockquote>
<div><strong>Windows&nbsp;2000 and Windows&nbsp;NT&nbsp;4.0:&nbsp;&nbsp;</strong>This property is not supported.</div>
</blockquote>
</dd><dt><strong>LanguagesSupported</strong></dt><dd>
<dl><dt>Data type: <strong>uint16</strong> array</dt><dt>Access type: Read-only</dt></dl>
<p>&nbsp;</p>
<p>Array of the print languages natively supported. This property is inherited from
<a href="http://msdn.microsoft.com/en-us/library/windows/desktop/aa387974(v=vs.85).aspx">
<strong>CIM_Printer</strong></a>.</p>
<table>
<tbody>
<tr>
<th>Value</th>
<th>Meaning</th>
</tr>
<tr>
<td>
<dl><dt>1 (0x1)</dt></dl>
</td>
<td>
<p>Other</p>
</td>
</tr>
<tr>
<td>
<dl><dt>2 (0x2)</dt></dl>
</td>
<td>
<p>Unknown</p>
</td>
</tr>
<tr>
<td>
<dl><dt>3 (0x3)</dt></dl>
</td>
<td>
<p>PCL</p>
</td>
</tr>
<tr>
<td>
<dl><dt>4 (0x4)</dt></dl>
</td>
<td>
<p>HPGL</p>
</td>
</tr>
<tr>
<td>
<dl><dt>5 (0x5)</dt></dl>
</td>
<td>
<p>PJL</p>
</td>
</tr>
<tr>
<td>
<dl><dt>6 (0x6)</dt></dl>
</td>
<td>
<p>PS</p>
</td>
</tr>
<tr>
<td>
<dl><dt>7 (0x7)</dt></dl>
</td>
<td>
<p>PSPrinter</p>
</td>
</tr>
<tr>
<td>
<dl><dt>8 (0x8)</dt></dl>
</td>
<td>
<p>IPDS</p>
</td>
</tr>
<tr>
<td>
<dl><dt>9 (0x9)</dt></dl>
</td>
<td>
<p>PPDS</p>
</td>
</tr>
<tr>
<td>
<dl><dt>10 (0xA)</dt></dl>
</td>
<td>
<p>EscapeP</p>
</td>
</tr>
<tr>
<td>
<dl><dt>11 (0xB)</dt></dl>
</td>
<td>
<p>Epson</p>
</td>
</tr>
<tr>
<td>
<dl><dt>12 (0xC)</dt></dl>
</td>
<td>
<p>DDIF</p>
</td>
</tr>
<tr>
<td>
<dl><dt>13 (0xD)</dt></dl>
</td>
<td>
<p>Interpress</p>
</td>
</tr>
<tr>
<td>
<dl><dt>14 (0xE)</dt></dl>
</td>
<td>
<p>ISO6429</p>
</td>
</tr>
<tr>
<td>
<dl><dt>15 (0xF)</dt></dl>
</td>
<td>
<p>LineData</p>
</td>
</tr>
<tr>
<td>
<dl><dt>16 (0x10)</dt></dl>
</td>
<td>
<p>DODCA</p>
</td>
</tr>
<tr>
<td>
<dl><dt>17 (0x11)</dt></dl>
</td>
<td>
<p>REGIS</p>
</td>
</tr>
<tr>
<td>
<dl><dt>18 (0x12)</dt></dl>
</td>
<td>
<p>SCS</p>
</td>
</tr>
<tr>
<td>
<dl><dt>19 (0x13)</dt></dl>
</td>
<td>
<p>SPDL</p>
</td>
</tr>
<tr>
<td>
<dl><dt>20 (0x14)</dt></dl>
</td>
<td>
<p>TEK4014</p>
</td>
</tr>
<tr>
<td>
<dl><dt>21 (0x15)</dt></dl>
</td>
<td>
<p>PDS</p>
</td>
</tr>
<tr>
<td>
<dl><dt>22 (0x16)</dt></dl>
</td>
<td>
<p>IGP</p>
</td>
</tr>
<tr>
<td>
<dl><dt>23 (0x17)</dt></dl>
</td>
<td>
<p>CodeV</p>
</td>
</tr>
<tr>
<td>
<dl><dt>24 (0x18)</dt></dl>
</td>
<td>
<p>DSCDSE</p>
</td>
</tr>
<tr>
<td>
<dl><dt>25 (0x19)</dt></dl>
</td>
<td>
<p>WPS</p>
</td>
</tr>
<tr>
<td>
<dl><dt>26 (0x1A)</dt></dl>
</td>
<td>
<p>LN03</p>
</td>
</tr>
<tr>
<td>
<dl><dt>27 (0x1B)</dt></dl>
</td>
<td>
<p>CCITT</p>
</td>
</tr>
<tr>
<td>
<dl><dt>28 (0x1C)</dt></dl>
</td>
<td>
<p>QUIC</p>
</td>
</tr>
<tr>
<td>
<dl><dt>29 (0x1D)</dt></dl>
</td>
<td>
<p>CPAP</p>
</td>
</tr>
<tr>
<td>
<dl><dt>30 (0x1E)</dt></dl>
</td>
<td>
<p>DecPPL</p>
</td>
</tr>
<tr>
<td>
<dl><dt>31 (0x1F)</dt></dl>
</td>
<td>
<p>SimpleText</p>
</td>
</tr>
<tr>
<td>
<dl><dt>32 (0x20)</dt></dl>
</td>
<td>
<p>NPAP</p>
</td>
</tr>
<tr>
<td>
<dl><dt>33 (0x21)</dt></dl>
</td>
<td>
<p>DOC</p>
</td>
</tr>
<tr>
<td>
<dl><dt>34 (0x22)</dt></dl>
</td>
<td>
<p>imPress</p>
</td>
</tr>
<tr>
<td>
<dl><dt>35 (0x23)</dt></dl>
</td>
<td>
<p>Pinwriter</p>
</td>
</tr>
<tr>
<td>
<dl><dt>36 (0x24)</dt></dl>
</td>
<td>
<p>NPDL</p>
</td>
</tr>
<tr>
<td>
<dl><dt>37 (0x25)</dt></dl>
</td>
<td>
<p>NEC201PL</p>
</td>
</tr>
<tr>
<td>
<dl><dt>38 (0x26)</dt></dl>
</td>
<td>
<p>Automatic</p>
</td>
</tr>
<tr>
<td>
<dl><dt>39 (0x27)</dt></dl>
</td>
<td>
<p>Pages</p>
</td>
</tr>
<tr>
<td>
<dl><dt>40 (0x28)</dt></dl>
</td>
<td>
<p>LIPS</p>
</td>
</tr>
<tr>
<td>
<dl><dt>41 (0x29)</dt></dl>
</td>
<td>
<p>TIFF</p>
</td>
</tr>
<tr>
<td>
<dl><dt>42 (0x2A)</dt></dl>
</td>
<td>
<p>Diagnostic</p>
</td>
</tr>
<tr>
<td>
<dl><dt>43 (0x2B)</dt></dl>
</td>
<td>
<p>CaPSL</p>
</td>
</tr>
<tr>
<td>
<dl><dt>44 (0x2C)</dt></dl>
</td>
<td>
<p>EXCL</p>
</td>
</tr>
<tr>
<td>
<dl><dt>45 (0x2D)</dt></dl>
</td>
<td>
<p>LCDS</p>
</td>
</tr>
<tr>
<td>
<dl><dt>46 (0x2E)</dt></dl>
</td>
<td>
<p>XES</p>
</td>
</tr>
<tr>
<td>
<dl><dt>47 (0x2F)</dt></dl>
</td>
<td>
<p>MIME</p>
</td>
</tr>
<tr>
<td>
<dl><dt>48 (0x30)</dt></dl>
</td>
<td>
<p>XPS</p>
</td>
</tr>
<tr>
<td>
<dl><dt>49 (0x31)</dt></dl>
</td>
<td>
<p>HPGL2</p>
</td>
</tr>
<tr>
<td>
<dl><dt>50 (0x32)</dt></dl>
</td>
<td>
<p>PCLXL</p>
</td>
</tr>
</tbody>
</table>
<p>&nbsp;</p>
</dd><dt><strong>LastErrorCode</strong></dt><dd>
<dl><dt>Data type: <strong>uint32</strong></dt><dt>Access type: Read-only</dt></dl>
<p>&nbsp;</p>
<p>Last error code that&nbsp; the logical device reports. This property is inherited from
<a href="http://msdn.microsoft.com/en-us/library/windows/desktop/aa387884(v=vs.85).aspx">
<strong>CIM_LogicalDevice</strong></a>.</p>
</dd><dt><strong>Local</strong></dt><dd>
<dl><dt>Data type: <strong>boolean</strong></dt><dt>Access type: Read/write</dt></dl>
<p>&nbsp;</p>
<p>If <strong>TRUE</strong>, the printer is not attached to a network. If both the
<strong>Local</strong> and <strong>Network</strong> properties are set to <strong>
TRUE</strong>, then the printer is a network printer.</p>
<blockquote>
<div><strong>Windows&nbsp;2000 and Windows&nbsp;NT&nbsp;4.0:&nbsp;&nbsp;</strong>This property is not supported.</div>
</blockquote>
</dd><dt><strong>Location</strong></dt><dd>
<dl><dt>Data type: <strong>string</strong></dt><dt>Access type: Read/write</dt></dl>
<p>&nbsp;</p>
<p>Physical location of the printer.</p>
<p>Example: Bldg. 38, Room 1164</p>
</dd><dt><strong>MarkingTechnology</strong></dt><dd>
<dl><dt>Data type: <strong>uint16</strong></dt><dt>Access type: Read-only</dt></dl>
<p>&nbsp;</p>
<p>Marking technology the printer uses. This property is inherited from <a href="http://msdn.microsoft.com/en-us/library/windows/desktop/aa387974(v=vs.85).aspx">
<strong>CIM_Printer</strong></a>.</p>
<blockquote>
<div><strong>Windows&nbsp;2000 and Windows&nbsp;NT&nbsp;4.0:&nbsp;&nbsp;</strong>This property is not supported.</div>
</blockquote>
<table>
<tbody>
<tr>
<th>Value</th>
<th>Meaning</th>
</tr>
<tr>
<td>
<dl><dt>1 (0x1)</dt></dl>
</td>
<td>
<p>Other</p>
</td>
</tr>
<tr>
<td>
<dl><dt>2 (0x2)</dt></dl>
</td>
<td>
<p>Unknown</p>
</td>
</tr>
<tr>
<td>
<dl><dt>3 (0x3)</dt></dl>
</td>
<td>
<p>Electrophotographic LED</p>
</td>
</tr>
<tr>
<td>
<dl><dt>4 (0x4)</dt></dl>
</td>
<td>
<p>Electrophotographic Laser</p>
</td>
</tr>
<tr>
<td>
<dl><dt>5 (0x5)</dt></dl>
</td>
<td>
<p>Electrophotographic Other</p>
</td>
</tr>
<tr>
<td>
<dl><dt>6 (0x6)</dt></dl>
</td>
<td>
<p>Impact Moving Head Dot Matrix 9pin</p>
</td>
</tr>
<tr>
<td>
<dl><dt>7 (0x7)</dt></dl>
</td>
<td>
<p>Impact Moving Head Dot Matrix 24pin</p>
</td>
</tr>
<tr>
<td>
<dl><dt>8 (0x8)</dt></dl>
</td>
<td>
<p>Impact Moving Head Dot Matrix Other</p>
</td>
</tr>
<tr>
<td>
<dl><dt>9 (0x9)</dt></dl>
</td>
<td>
<p>Impact Moving Head Fully Formed</p>
</td>
</tr>
<tr>
<td>
<dl><dt>10 (0xA)</dt></dl>
</td>
<td>
<p>Impact Band</p>
</td>
</tr>
<tr>
<td>
<dl><dt>11 (0xB)</dt></dl>
</td>
<td>
<p>Impact Other</p>
</td>
</tr>
<tr>
<td>
<dl><dt>12 (0xC)</dt></dl>
</td>
<td>
<p>Inkjet Aqueous</p>
</td>
</tr>
<tr>
<td>
<dl><dt>13 (0xD)</dt></dl>
</td>
<td>
<p>Inkjet Solid</p>
</td>
</tr>
<tr>
<td>
<dl><dt>14 (0xE)</dt></dl>
</td>
<td>
<p>Inkjet Other</p>
</td>
</tr>
<tr>
<td>
<dl><dt>15 (0xF)</dt></dl>
</td>
<td>
<p>Pen</p>
</td>
</tr>
<tr>
<td>
<dl><dt>16 (0x10)</dt></dl>
</td>
<td>
<p>Thermal Transfer</p>
</td>
</tr>
<tr>
<td>
<dl><dt>17 (0x11)</dt></dl>
</td>
<td>
<p>Thermal Sensitive</p>
</td>
</tr>
<tr>
<td>
<dl><dt>18 (0x12)</dt></dl>
</td>
<td>
<p>Thermal Diffusion</p>
</td>
</tr>
<tr>
<td>
<dl><dt>19 (0x13)</dt></dl>
</td>
<td>
<p>Thermal Other</p>
</td>
</tr>
<tr>
<td>
<dl><dt>20 (0x14)</dt></dl>
</td>
<td>
<p>Electroerosion</p>
</td>
</tr>
<tr>
<td>
<dl><dt>21 (0x15)</dt></dl>
</td>
<td>
<p>Electrostatic</p>
</td>
</tr>
<tr>
<td>
<dl><dt>22 (0x16)</dt></dl>
</td>
<td>
<p>Photographic Microfiche</p>
</td>
</tr>
<tr>
<td>
<dl><dt>23 (0x17)</dt></dl>
</td>
<td>
<p>Photographic Imagesetter</p>
</td>
</tr>
<tr>
<td>
<dl><dt>24 (0x18)</dt></dl>
</td>
<td>
<p>Photographic Other</p>
</td>
</tr>
<tr>
<td>
<dl><dt>25 (0x19)</dt></dl>
</td>
<td>
<p>Ion Deposition</p>
</td>
</tr>
<tr>
<td>
<dl><dt>26 (0x1A)</dt></dl>
</td>
<td>
<p>eBeam</p>
</td>
</tr>
<tr>
<td>
<dl><dt>27 (0x1B)</dt></dl>
</td>
<td>
<p>Typesetter</p>
</td>
</tr>
</tbody>
</table>
<p>&nbsp;</p>
</dd><dt><strong>MaxCopies</strong></dt><dd>
<dl><dt>Data type: <strong>uint32</strong></dt><dt>Access type: Read-only</dt></dl>
<p>&nbsp;</p>
<p>Maximum number of copies the printer can&nbsp; produce for one&nbsp; job. This property is inherited from
<a href="http://msdn.microsoft.com/en-us/library/windows/desktop/aa387974(v=vs.85).aspx">
<strong>CIM_Printer</strong></a>.</p>
<blockquote>
<div><strong>Windows&nbsp;2000 and Windows&nbsp;NT&nbsp;4.0:&nbsp;&nbsp;</strong>This property is not supported.</div>
</blockquote>
</dd><dt><strong>MaxNumberUp</strong></dt><dd>
<dl><dt>Data type: <strong>uint32</strong></dt><dt>Access type: Read-only</dt></dl>
<p>&nbsp;</p>
<p>Maximum number of print-stream pages the printer can&nbsp; render on&nbsp; one&nbsp; media sheet, such as paper. This property is inherited from
<a href="http://msdn.microsoft.com/en-us/library/windows/desktop/aa387974(v=vs.85).aspx">
<strong>CIM_Printer</strong></a>.</p>
<blockquote>
<div><strong>Windows&nbsp;2000 and Windows&nbsp;NT&nbsp;4.0:&nbsp;&nbsp;</strong>This property is not supported.</div>
</blockquote>
</dd><dt><strong>MaxSizeSupported</strong></dt><dd>
<dl><dt>Data type: <strong>uint32</strong></dt><dt>Access type: Read-only</dt></dl>
<p>&nbsp;</p>
<p>Largest job as a byte stream, in kilobytes, that the printer can&nbsp; accept. A value of 0 (zero) indicates that no limit is&nbsp; set. This property is inherited from
<a href="http://msdn.microsoft.com/en-us/library/windows/desktop/aa387974(v=vs.85).aspx">
<strong>CIM_Printer</strong></a>.</p>
<blockquote>
<div><strong>Windows&nbsp;2000 and Windows&nbsp;NT&nbsp;4.0:&nbsp;&nbsp;</strong>This property is not supported.</div>
</blockquote>
</dd><dt><strong>MimeTypesSupported</strong></dt><dd>
<dl><dt>Data type: <strong>string</strong> array</dt><dt>Access type: Read-only</dt></dl>
<p>&nbsp;</p>
<p>Array of detailed MIME-type explanations&nbsp; that&nbsp; the printer supports. If data is provided, then the value 47 (&quot;MIME&quot;) must be included in the
<strong>LanguagesSupported</strong> property. This property is inherited from <a href="http://msdn.microsoft.com/en-us/library/windows/desktop/aa387974(v=vs.85).aspx">
<strong>CIM_Printer</strong></a>.</p>
<blockquote>
<div><strong>Windows&nbsp;2000 and Windows&nbsp;NT&nbsp;4.0:&nbsp;&nbsp;</strong>This property is not supported.</div>
</blockquote>
</dd><dt><strong>Name</strong></dt><dd>
<dl><dt>Data type: <strong>string</strong></dt><dt>Access type: Read-only</dt></dl>
<p>&nbsp;</p>
<p>Name of the printer.</p>
</dd><dt><strong>NaturalLanguagesSupported</strong></dt><dd>
<dl><dt>Data type: <strong>string</strong> array</dt><dt>Access type: Read-only</dt></dl>
<p>&nbsp;</p>
<p>Array of languages supported for strings that the printer uses for output of management information. Must conform to
<a href="http://go.microsoft.com/FWLink/?LinkId=84408">RFC&nbsp;1766</a>. For example, &quot;en&quot; is used for English. This property is inherited from
<a href="http://msdn.microsoft.com/en-us/library/windows/desktop/aa387974(v=vs.85).aspx">
<strong>CIM_Printer</strong></a>.</p>
<blockquote>
<div><strong>Windows&nbsp;2000 and Windows&nbsp;NT&nbsp;4.0:&nbsp;&nbsp;</strong>This property is not supported.</div>
</blockquote>
</dd><dt><strong>Network</strong></dt><dd>
<dl><dt>Data type: <strong>boolean</strong></dt><dt>Access type: Read/write</dt></dl>
<p>&nbsp;</p>
<p>If <strong>TRUE</strong>, the printer is a network printer. If both the <strong>
Local</strong> and <strong>Network</strong> properties are set to <strong>TRUE</strong>, then the printer is a network printer.</p>
<blockquote>
<div><strong>Windows&nbsp;2000 and Windows&nbsp;NT&nbsp;4.0:&nbsp;&nbsp;</strong>This property is not supported.</div>
</blockquote>
</dd><dt><strong>PaperSizesSupported</strong></dt><dd>
<dl><dt>Data type: <strong>uint16</strong> array</dt><dt>Access type: Read-only</dt></dl>
<p>&nbsp;</p>
<p>Array of the paper&nbsp; types that the printer supports. This property is inherited from
<a href="http://msdn.microsoft.com/en-us/library/windows/desktop/aa387974(v=vs.85).aspx">
<strong>CIM_Printer</strong></a>.</p>
<table>
<tbody>
<tr>
<th>Value</th>
<th>Meaning</th>
</tr>
<tr>
<td>
<dl><dt>0</dt></dl>
</td>
<td>
<p>Unknown</p>
</td>
</tr>
<tr>
<td>
<dl><dt>1 (0x1)</dt></dl>
</td>
<td>
<p>Other</p>
</td>
</tr>
<tr>
<td>
<dl><dt>2 (0x2)</dt></dl>
</td>
<td>
<p>A</p>
</td>
</tr>
<tr>
<td>
<dl><dt>3 (0x3)</dt></dl>
</td>
<td>
<p>B</p>
</td>
</tr>
<tr>
<td>
<dl><dt>4 (0x4)</dt></dl>
</td>
<td>
<p>C</p>
</td>
</tr>
<tr>
<td>
<dl><dt>5 (0x5)</dt></dl>
</td>
<td>
<p>D</p>
</td>
</tr>
<tr>
<td>
<dl><dt>6 (0x6)</dt></dl>
</td>
<td>
<p>E</p>
</td>
</tr>
<tr>
<td>
<dl><dt>7 (0x7)</dt></dl>
</td>
<td>
<p>Letter</p>
</td>
</tr>
<tr>
<td>
<dl><dt>8 (0x8)</dt></dl>
</td>
<td>
<p>Legal</p>
</td>
</tr>
<tr>
<td>
<dl><dt>9 (0x9)</dt></dl>
</td>
<td>
<p>NA-10x13-Envelope</p>
</td>
</tr>
<tr>
<td>
<dl><dt>10 (0xA)</dt></dl>
</td>
<td>
<p>NA-9x12-Envelope</p>
</td>
</tr>
<tr>
<td>
<dl><dt>11 (0xB)</dt></dl>
</td>
<td>
<p>NA-Number-10-Envelope</p>
</td>
</tr>
<tr>
<td>
<dl><dt>12 (0xC)</dt></dl>
</td>
<td>
<p>NA-7x9-Envelope</p>
</td>
</tr>
<tr>
<td>
<dl><dt>13 (0xD)</dt></dl>
</td>
<td>
<p>NA-9x11-Envelope</p>
</td>
</tr>
<tr>
<td>
<dl><dt>14 (0xE)</dt></dl>
</td>
<td>
<p>NA-10x14-Envelope</p>
</td>
</tr>
<tr>
<td>
<dl><dt>15 (0xF)</dt></dl>
</td>
<td>
<p>NA-Number-9-Envelope</p>
</td>
</tr>
<tr>
<td>
<dl><dt>16 (0x10)</dt></dl>
</td>
<td>
<p>NA-6x9-Envelope</p>
</td>
</tr>
<tr>
<td>
<dl><dt>17 (0x11)</dt></dl>
</td>
<td>
<p>NA-10x15-Envelope</p>
</td>
</tr>
<tr>
<td>
<dl><dt>18 (0x12)</dt></dl>
</td>
<td>
<p>A0</p>
</td>
</tr>
<tr>
<td>
<dl><dt>19 (0x13)</dt></dl>
</td>
<td>
<p>A1</p>
</td>
</tr>
<tr>
<td>
<dl><dt>20 (0x14)</dt></dl>
</td>
<td>
<p>A2</p>
</td>
</tr>
<tr>
<td>
<dl><dt>21 (0x15)</dt></dl>
</td>
<td>
<p>A3</p>
</td>
</tr>
<tr>
<td>
<dl><dt>22 (0x16)</dt></dl>
</td>
<td>
<p>A4</p>
</td>
</tr>
<tr>
<td>
<dl><dt>23 (0x17)</dt></dl>
</td>
<td>
<p>A5</p>
</td>
</tr>
<tr>
<td>
<dl><dt>24 (0x18)</dt></dl>
</td>
<td>
<p>A6</p>
</td>
</tr>
<tr>
<td>
<dl><dt>25 (0x19)</dt></dl>
</td>
<td>
<p>A7</p>
</td>
</tr>
<tr>
<td>
<dl><dt>26 (0x1A)</dt></dl>
</td>
<td>
<p>A8</p>
</td>
</tr>
<tr>
<td>
<dl><dt>27 (0x1B)</dt></dl>
</td>
<td>
<p>A9A10</p>
</td>
</tr>
<tr>
<td>
<dl><dt>28 (0x1C)</dt></dl>
</td>
<td>
<p>B0</p>
</td>
</tr>
<tr>
<td>
<dl><dt>29 (0x1D)</dt></dl>
</td>
<td>
<p>B1</p>
</td>
</tr>
<tr>
<td>
<dl><dt>30 (0x1E)</dt></dl>
</td>
<td>
<p>B2</p>
</td>
</tr>
<tr>
<td>
<dl><dt>31 (0x1F)</dt></dl>
</td>
<td>
<p>B3</p>
</td>
</tr>
<tr>
<td>
<dl><dt>32 (0x20)</dt></dl>
</td>
<td>
<p>B4</p>
</td>
</tr>
<tr>
<td>
<dl><dt>33 (0x21)</dt></dl>
</td>
<td>
<p>B5</p>
</td>
</tr>
<tr>
<td>
<dl><dt>34 (0x22)</dt></dl>
</td>
<td>
<p>B6</p>
</td>
</tr>
<tr>
<td>
<dl><dt>35 (0x23)</dt></dl>
</td>
<td>
<p>B7</p>
</td>
</tr>
<tr>
<td>
<dl><dt>36 (0x24)</dt></dl>
</td>
<td>
<p>B8</p>
</td>
</tr>
<tr>
<td>
<dl><dt>37 (0x25)</dt></dl>
</td>
<td>
<p>B9</p>
</td>
</tr>
<tr>
<td>
<dl><dt>38 (0x26)</dt></dl>
</td>
<td>
<p>B10</p>
</td>
</tr>
<tr>
<td>
<dl><dt>39 (0x27)</dt></dl>
</td>
<td>
<p>C0</p>
</td>
</tr>
<tr>
<td>
<dl><dt>40 (0x28)</dt></dl>
</td>
<td>
<p>C1</p>
</td>
</tr>
<tr>
<td>
<dl><dt>41 (0x29)</dt></dl>
</td>
<td>
<p>C2</p>
</td>
</tr>
<tr>
<td>
<dl><dt>42 (0x2A)</dt></dl>
</td>
<td>
<p>C3</p>
</td>
</tr>
<tr>
<td>
<dl><dt>43 (0x2B)</dt></dl>
</td>
<td>
<p>C4</p>
</td>
</tr>
<tr>
<td>
<dl><dt>44 (0x2C)</dt></dl>
</td>
<td>
<p>C5</p>
</td>
</tr>
<tr>
<td>
<dl><dt>45 (0x2D)</dt></dl>
</td>
<td>
<p>C6</p>
</td>
</tr>
<tr>
<td>
<dl><dt>46 (0x2E)</dt></dl>
</td>
<td>
<p>C7</p>
</td>
</tr>
<tr>
<td>
<dl><dt>47 (0x2F)</dt></dl>
</td>
<td>
<p>C8</p>
</td>
</tr>
<tr>
<td>
<dl><dt>48 (0x30)</dt></dl>
</td>
<td>
<p>ISO-Designated</p>
</td>
</tr>
<tr>
<td>
<dl><dt>49 (0x31)</dt></dl>
</td>
<td>
<p>JIS B0</p>
</td>
</tr>
<tr>
<td>
<dl><dt>50 (0x32)</dt></dl>
</td>
<td>
<p>JIS B1</p>
</td>
</tr>
<tr>
<td>
<dl><dt>51 (0x33)</dt></dl>
</td>
<td>
<p>JIS B2</p>
</td>
</tr>
<tr>
<td>
<dl><dt>52 (0x34)</dt></dl>
</td>
<td>
<p>JIS B3</p>
</td>
</tr>
<tr>
<td>
<dl><dt>53 (0x35)</dt></dl>
</td>
<td>
<p>JIS B4</p>
</td>
</tr>
<tr>
<td>
<dl><dt>54 (0x36)</dt></dl>
</td>
<td>
<p>JIS B5</p>
</td>
</tr>
<tr>
<td>
<dl><dt>55 (0x37)</dt></dl>
</td>
<td>
<p>JIS B6</p>
</td>
</tr>
<tr>
<td>
<dl><dt>56 (0x38)</dt></dl>
</td>
<td>
<p>JIS B7</p>
</td>
</tr>
<tr>
<td>
<dl><dt>57 (0x39)</dt></dl>
</td>
<td>
<p>JIS B8</p>
</td>
</tr>
<tr>
<td>
<dl><dt>58 (0x3A)</dt></dl>
</td>
<td>
<p>JIS B9</p>
</td>
</tr>
<tr>
<td>
<dl><dt>59 (0x3B)</dt></dl>
</td>
<td>
<p>JIS B10</p>
</td>
</tr>
</tbody>
</table>
<p>&nbsp;</p>
</dd><dt><strong>PaperTypesAvailable</strong></dt><dd>
<dl><dt>Data type: <strong>string</strong> array</dt><dt>Access type: Read-only</dt></dl>
<p>&nbsp;</p>
<p>Array of&nbsp; paper types that are currently available on the printer. Each string must be expressed in the format specified by ISO/IEC&nbsp;10175 Document Printing Application (DPA),&nbsp; which is summarized in Appendix&nbsp;C of
<a href="http://go.microsoft.com/FWLink/?LinkId=84407">RFC&nbsp;1759</a> (Printer MIB). Any paper size&nbsp; identified in this property must also appear in the
<strong>PaperSizesSupported</strong> property. This property is inherited from <a href="http://msdn.microsoft.com/en-us/library/windows/desktop/aa387974(v=vs.85).aspx">
<strong>CIM_Printer</strong></a>.</p>
<p>Example: iso-a4-colored</p>
<blockquote>
<div><strong>Windows&nbsp;2000 and Windows&nbsp;NT&nbsp;4.0:&nbsp;&nbsp;</strong>This property is not supported.</div>
</blockquote>
</dd><dt><strong>Parameters</strong></dt><dd>
<dl><dt>Data type: <strong>string</strong></dt><dt>Access type: Read/write</dt></dl>
<p>&nbsp;</p>
<p>Optional parameters for the print processor.</p>
<p>Example: Copies=2</p>
<blockquote>
<div><strong>Windows&nbsp;2000 and Windows&nbsp;NT&nbsp;4.0:&nbsp;&nbsp;</strong>This property is not supported.</div>
</blockquote>
</dd><dt><strong>PNPDeviceID</strong></dt><dd>
<dl><dt>Data type: <strong>string</strong></dt><dt>Access type: Read-only</dt></dl>
<p>&nbsp;</p>
<p>Windows Plug and Play device identifier of the logical device. This property is inherited from
<a href="http://msdn.microsoft.com/en-us/library/windows/desktop/aa387884(v=vs.85).aspx">
<strong>CIM_LogicalDevice</strong></a>.</p>
<p>Example: *PNP030b</p>
</dd><dt><strong>PortName</strong></dt><dd>
<dl><dt>Data type: <strong>string</strong></dt><dt>Access type: Read/write</dt></dl>
<p>&nbsp;</p>
<p>Port that is&nbsp; used to transmit data to a printer. If a printer is connected to more than one port, the names of each port are separated by commas. Under Windows&nbsp;95, only one port can be specified.</p>
<p>Example: LPT1:, LPT2:, LPT3:</p>
</dd><dt><strong>PowerManagementCapabilities</strong></dt><dd>
<dl><dt>Data type: <strong>uint16</strong> array</dt><dt>Access type: Read-only</dt></dl>
<p>&nbsp;</p>
<p>Array of the specific power-related capabilities of a logical device. This property is inherited from
<strong>CIM_LogicalDevice</strong>.</p>
<table>
<tbody>
<tr>
<th>Value</th>
<th>Meaning</th>
</tr>
<tr>
<td>
<dl><dt>0 (0x0)</dt></dl>
</td>
<td>
<p>Unknown</p>
</td>
</tr>
<tr>
<td>
<dl><dt>1 (0x1)</dt></dl>
</td>
<td>
<p>Not Supported</p>
</td>
</tr>
<tr>
<td>
<dl><dt>2 (0x2)</dt></dl>
</td>
<td>
<p>Disabled</p>
</td>
</tr>
<tr>
<td>
<dl><dt>3 (0x3)</dt></dl>
</td>
<td>
<p>Enabled</p>
<p>The power management features are currently enabled, but the exact feature set is unknown or the information is unavailable.</p>
</td>
</tr>
<tr>
<td>
<dl><dt>4 (0x4)</dt></dl>
</td>
<td>
<p>Power Saving Modes Entered Automatically</p>
<p>The device can change its power state based on usage or other criteria.</p>
</td>
</tr>
<tr>
<td>
<dl><dt>5 (0x5)</dt></dl>
</td>
<td>
<p>Power State Settable</p>
<p>The <a href="http://msdn.microsoft.com/en-us/library/windows/desktop/aa393485(v=vs.85).aspx">
<strong>SetPowerState</strong></a> method is supported. This method is found on the parent
<strong>CIM_LogicalDevice</strong> class and can be implemented. For more information, see
<a href="http://msdn.microsoft.com/en-us/library/windows/desktop/aa390351(v=vs.85).aspx">
Designing Managed Object Format (MOF) Classes</a>.</p>
</td>
</tr>
<tr>
<td>
<dl><dt>6 (0x6)</dt></dl>
</td>
<td>
<p>Power Cycling Supported</p>
<p>The <a href="http://msdn.microsoft.com/en-us/library/windows/desktop/aa393485(v=vs.85).aspx">
<strong>SetPowerState</strong></a> method can be invoked with the <em>PowerState </em>
parameter set to 5 (Power Cycle).</p>
</td>
</tr>
<tr>
<td>
<dl><dt>7 (0x7)</dt></dl>
</td>
<td>
<p>Timed Power-On Supported</p>
<p>The <a href="http://msdn.microsoft.com/en-us/library/windows/desktop/aa393485(v=vs.85).aspx">
<strong>SetPowerState</strong></a> method can be invoked with the <em>PowerState</em> parameter set to 5 (Power Cycle) and
<em>Time</em> set to a specific date and time, or interval, for power-on.</p>
</td>
</tr>
</tbody>
</table>
<p>&nbsp;</p>
</dd><dt><strong>PowerManagementSupported</strong></dt><dd>
<dl><dt>Data type: <strong>boolean</strong></dt><dt>Access type: Read-only</dt></dl>
<p>&nbsp;</p>
<p>If <strong>TRUE</strong>, the power of the device can be managed, which means that it can be put into suspend mode. The property does not indicate that power management features are&nbsp; enabled, only that the logical device is capable of power management.
 This property is inherited from <a href="http://msdn.microsoft.com/en-us/library/windows/desktop/aa387884(v=vs.85).aspx">
<strong>CIM_LogicalDevice</strong></a>.</p>
</dd><dt><strong>PrinterPaperNames</strong></dt><dd>
<dl><dt>Data type: <strong>string</strong> array</dt><dt>Access type: Read-only</dt></dl>
<p>&nbsp;</p>
<p>Array of paper sizes supported by the printer. The printer-specified names are used to represent supported paper sizes.</p>
<p>Example: B5 (JIS)</p>
</dd><dt><strong>PrinterState</strong></dt><dd>
<dl><dt>Data type: <strong>uint32</strong></dt><dt>Access type: Read-only</dt><dt>Qualifiers: <a href="http://msdn.microsoft.com/en-us/library/windows/desktop/aa393651(v=vs.85).aspx">
<strong>Deprecated</strong></a> </dt></dl>
<p>&nbsp;</p>
<p>One of the possible states relating to this printer. This property is obsolete. In place of this property,&nbsp; use
<strong>PrinterStatus</strong>.</p>
<table>
<tbody>
<tr>
<th>Value</th>
<th>Meaning</th>
</tr>
<tr>
<td>
<dl><dt>1</dt></dl>
</td>
<td>
<p>Paused</p>
</td>
</tr>
<tr>
<td>
<dl><dt>2</dt></dl>
</td>
<td>
<p>Error</p>
</td>
</tr>
<tr>
<td>
<dl><dt>3</dt></dl>
</td>
<td>
<p>Pending Deletion</p>
</td>
</tr>
<tr>
<td>
<dl><dt>4</dt></dl>
</td>
<td>
<p>Paper Jam</p>
</td>
</tr>
<tr>
<td>
<dl><dt>5</dt></dl>
</td>
<td>
<p>Paper Out</p>
</td>
</tr>
<tr>
<td>
<dl><dt>6</dt></dl>
</td>
<td>
<p>Manual Feed</p>
</td>
</tr>
<tr>
<td>
<dl><dt>7</dt></dl>
</td>
<td>
<p>Paper Problem</p>
</td>
</tr>
<tr>
<td>
<dl><dt>8</dt></dl>
</td>
<td>
<p>Offline</p>
</td>
</tr>
<tr>
<td>
<dl><dt>9</dt></dl>
</td>
<td>
<p>I/O Active</p>
</td>
</tr>
<tr>
<td>
<dl><dt>10</dt></dl>
</td>
<td>
<p>Busy</p>
</td>
</tr>
<tr>
<td>
<dl><dt>11</dt></dl>
</td>
<td>
<p>Printing</p>
</td>
</tr>
<tr>
<td>
<dl><dt>12</dt></dl>
</td>
<td>
<p>Output Bin Full</p>
</td>
</tr>
<tr>
<td>
<dl><dt>13</dt></dl>
</td>
<td>
<p>Not Available</p>
</td>
</tr>
<tr>
<td>
<dl><dt>14</dt></dl>
</td>
<td>
<p>Waiting</p>
</td>
</tr>
<tr>
<td>
<dl><dt>15</dt></dl>
</td>
<td>
<p>Processing</p>
</td>
</tr>
<tr>
<td>
<dl><dt>16</dt></dl>
</td>
<td>
<p>Initialization</p>
</td>
</tr>
<tr>
<td>
<dl><dt>17</dt></dl>
</td>
<td>
<p>Warming Up</p>
</td>
</tr>
<tr>
<td>
<dl><dt>18</dt></dl>
</td>
<td>
<p>Toner Low</p>
</td>
</tr>
<tr>
<td>
<dl><dt>19</dt></dl>
</td>
<td>
<p>No Toner</p>
</td>
</tr>
<tr>
<td>
<dl><dt>20</dt></dl>
</td>
<td>
<p>Page Punt</p>
</td>
</tr>
<tr>
<td>
<dl><dt>21</dt></dl>
</td>
<td>
<p>User Intervention Required</p>
</td>
</tr>
<tr>
<td>
<dl><dt>22</dt></dl>
</td>
<td>
<p>Out of Memory</p>
</td>
</tr>
<tr>
<td>
<dl><dt>23</dt></dl>
</td>
<td>
<p>Door Open</p>
</td>
</tr>
<tr>
<td>
<dl><dt>24</dt></dl>
</td>
<td>
<p>Server_Unknown</p>
</td>
</tr>
<tr>
<td>
<dl><dt>25</dt></dl>
</td>
<td>
<p>Power Save</p>
</td>
</tr>
</tbody>
</table>
<p>&nbsp;</p>
</dd><dt><strong>PrinterStatus</strong></dt><dd>
<dl><dt>Data type: <strong>uint16</strong></dt><dt>Access type: Read-only</dt></dl>
<p>&nbsp;</p>
<p>Status information for a printer&nbsp; that is different from information&nbsp; specified in the logical device
<strong>Availability</strong> property. This property is inherited from <a href="http://msdn.microsoft.com/en-us/library/windows/desktop/aa387974(v=vs.85).aspx">
<strong>CIM_Printer</strong></a>.</p>
<table>
<tbody>
<tr>
<th>Value</th>
<th>Meaning</th>
</tr>
<tr>
<td>
<dl><dt>1 (0x1)</dt></dl>
</td>
<td>
<p>Other</p>
</td>
</tr>
<tr>
<td>
<dl><dt>2 (0x2)</dt></dl>
</td>
<td>
<p>Unknown</p>
</td>
</tr>
<tr>
<td>
<dl><dt>3 (0x3)</dt></dl>
</td>
<td>
<p>Idle</p>
</td>
</tr>
<tr>
<td>
<dl><dt>4 (0x4)</dt></dl>
</td>
<td>
<p>Printing</p>
</td>
</tr>
<tr>
<td>
<dl><dt>5 (0x5)</dt></dl>
</td>
<td>
<p>Warming Up</p>
</td>
</tr>
<tr>
<td>
<dl><dt>6 (0x6)</dt></dl>
</td>
<td>
<p>Stopped printing</p>
</td>
</tr>
<tr>
<td>
<dl><dt>7 (0x7)</dt></dl>
</td>
<td>
<p>Offline</p>
</td>
</tr>
</tbody>
</table>
<p>&nbsp;</p>
</dd><dt><strong>PrintJobDataType</strong></dt><dd>
<dl><dt>Data type: <strong>string</strong></dt><dt>Access type: Read/write</dt></dl>
<p>&nbsp;</p>
<p>Data type of a print job waiting for&nbsp; the Windows-based printing device.</p>
</dd><dt><strong>PrintProcessor</strong></dt><dd>
<dl><dt>Data type: <strong>string</strong></dt><dt>Access type: Read/write</dt></dl>
<p>&nbsp;</p>
<p>Name of the print spooler that handles print jobs.</p>
<p>Example: SPOOLSS.DLL</p>
</dd><dt><strong>Priority</strong></dt><dd>
<dl><dt>Data type: <strong>uint32</strong></dt><dt>Access type: Read/write</dt></dl>
<p>&nbsp;</p>
<p>Priority of the printer. Jobs on a higher priority printer are scheduled first.</p>
<blockquote>
<div><strong>Windows&nbsp;2000 and Windows&nbsp;NT&nbsp;4.0:&nbsp;&nbsp;</strong>This property is not supported.</div>
</blockquote>
</dd><dt><strong>Published</strong></dt><dd>
<dl><dt>Data type: <strong>boolean</strong></dt><dt>Access type: Read/write</dt></dl>
<p>&nbsp;</p>
<p>If <strong>TRUE</strong>, the printer is published in the network directory service.</p>
<blockquote>
<div><strong>Windows&nbsp;2000 and Windows&nbsp;NT&nbsp;4.0:&nbsp;&nbsp;</strong>This property is not supported.</div>
</blockquote>
</dd><dt><strong>Queued</strong></dt><dd>
<dl><dt>Data type: <strong>boolean</strong></dt><dt>Access type: Read/write</dt></dl>
<p>&nbsp;</p>
<p>If <strong>TRUE</strong>, the printer buffers and queues print jobs.</p>
<blockquote>
<div><strong>Windows&nbsp;2000 and Windows&nbsp;NT&nbsp;4.0:&nbsp;&nbsp;</strong>This property is not supported.</div>
</blockquote>
</dd><dt><strong>RawOnly</strong></dt><dd>
<dl><dt>Data type: <strong>boolean</strong></dt><dt>Access type: Read/write</dt></dl>
<p>&nbsp;</p>
<p>If <strong>TRUE</strong>, the printer accepts only raw data to be spooled.</p>
<blockquote>
<div><strong>Windows&nbsp;2000 and Windows&nbsp;NT&nbsp;4.0:&nbsp;&nbsp;</strong>This property is not supported.</div>
</blockquote>
</dd><dt><strong>SeparatorFile</strong></dt><dd>
<dl><dt>Data type: <strong>string</strong></dt><dt>Access type: Read/write</dt></dl>
<p>&nbsp;</p>
<p>Name of the file used to create a separator page. This page is used to separate print jobs sent to the printer.</p>
</dd><dt><strong>ServerName</strong></dt><dd>
<dl><dt>Data type: <strong>string</strong></dt><dt>Access type: Read-only</dt></dl>
<p>&nbsp;</p>
<p>Name of the server that controls&nbsp; the printer. If this string is <strong>
NULL</strong>, the printer is controlled locally.</p>
</dd><dt><strong>Shared</strong></dt><dd>
<dl><dt>Data type: <strong>boolean</strong></dt><dt>Access type: Read/write</dt></dl>
<p>&nbsp;</p>
<p>If <strong>TRUE</strong>, the printer is available as a shared network resource.</p>
<blockquote>
<div><strong>Windows&nbsp;2000 and Windows&nbsp;NT&nbsp;4.0:&nbsp;&nbsp;</strong>This property is not supported.</div>
</blockquote>
</dd><dt><strong>ShareName</strong></dt><dd>
<dl><dt>Data type: <strong>string</strong></dt><dt>Access type: Read/write</dt></dl>
<p>&nbsp;</p>
<p>Share name of the Windows-based printing device.</p>
<p>Example: \\PRINTSERVER1\PRINTER2</p>
</dd><dt><strong>SpoolEnabled</strong></dt><dd>
<dl><dt>Data type: <strong>boolean</strong></dt><dt>Access type: Read-only</dt><dt>Qualifiers: <a href="http://msdn.microsoft.com/en-us/library/windows/desktop/aa393651(v=vs.85).aspx">
<strong>Deprecated</strong></a> </dt></dl>
<p>&nbsp;</p>
<p>This property is obsolete; do not use. If <strong>TRUE</strong>, spooling is enabled for&nbsp; printer.</p>
</dd><dt><strong>StartTime</strong></dt><dd>
<dl><dt>Data type: <strong>datetime</strong></dt><dt>Access type: Read/write</dt></dl>
<p>&nbsp;</p>
<p>Date and time that&nbsp; a&nbsp; printer can&nbsp; start to print a job&mdash;if the printer is limited to print at specific times. This value is expressed as the time elapsed since&nbsp; 12:00 AM GMT (Greenwich Mean Time).</p>
</dd><dt><strong>Status</strong></dt><dd>
<dl><dt>Data type: <strong>string</strong></dt><dt>Access type: Read-only</dt><dt>Qualifiers: <a href="http://msdn.microsoft.com/en-us/library/windows/desktop/aa393650(v=vs.85).aspx">
<strong>MaxLen</strong></a>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
 (10)&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
</dt></dl>
<p>&nbsp;</p>
<p>Current status of the object. Various operational and nonoperational statuses can be defined. Operational statuses include: &quot;OK&quot;, &quot;Degraded&quot;, and &quot;Pred Fail&quot; (an element, such as a SMART-enabled hard disk drive, may be functioning properly but predicting
 a failure in the near future). Nonoperational statuses include: &quot;Error&quot;, &quot;Starting&quot;, &quot;Stopping&quot;, and &quot;Service&quot;. The latter, &quot;Service&quot;, could apply during mirror-resilvering of a disk, reload of a user permissions list, or other administrative work. Not all
 such work is online, yet the managed element is neither &quot;OK&quot; nor in one of the other states. This property is inherited from
<a href="http://msdn.microsoft.com/en-us/library/windows/desktop/aa387898(v=vs.85).aspx">
<strong>CIM_ManagedSystemElement</strong></a>.</p>
<p>&nbsp;</p>
<p>Values are:</p>
<dl><dt><strong>&quot;OK&quot;</strong></dt><dt><strong>&quot;Error&quot;</strong></dt><dt><strong>&quot;Degraded&quot;</strong></dt><dt><strong>&quot;Unknown&quot;</strong></dt><dt><strong>&quot;Pred Fail&quot;</strong></dt><dt><strong>&quot;Starting&quot;</strong></dt><dt><strong>&quot;Stopping&quot;</strong></dt><dt><strong>&quot;Service&quot;</strong></dt><dt><strong>&quot;Stressed&quot;</strong></dt><dt><strong>&quot;NonRecover&quot;</strong></dt><dt><strong>&quot;No Contact&quot;</strong></dt><dt><strong>&quot;Lost Comm&quot;</strong></dt></dl>
</dd><dt><strong>StatusInfo</strong></dt><dd>
<dl><dt>Data type: <strong>uint16</strong></dt><dt>Access type: Read-only</dt></dl>
<p>&nbsp;</p>
<p>State of the logical device. If this property does not apply to the logical device, the value 5 (Not Applicable) should be used. This property is inherited from
<a href="http://msdn.microsoft.com/en-us/library/windows/desktop/aa387884(v=vs.85).aspx">
<strong>CIM_LogicalDevice</strong></a>.</p>
<table>
<tbody>
<tr>
<th>Value</th>
<th>Meaning</th>
</tr>
<tr>
<td>
<dl><dt>1 (0x1)</dt></dl>
</td>
<td>
<p>Other</p>
</td>
</tr>
<tr>
<td>
<dl><dt>2 (0x2)</dt></dl>
</td>
<td>
<p>Unknown</p>
</td>
</tr>
<tr>
<td>
<dl><dt>3 (0x3)</dt></dl>
</td>
<td>
<p>Enabled</p>
</td>
</tr>
<tr>
<td>
<dl><dt>4 (0x4)</dt></dl>
</td>
<td>
<p>Disabled</p>
</td>
</tr>
<tr>
<td>
<dl><dt>5 (0x5)</dt></dl>
</td>
<td>
<p>Not Applicable</p>
</td>
</tr>
</tbody>
</table>
<p>&nbsp;</p>
</dd><dt><strong>SystemCreationClassName</strong></dt><dd>
<dl><dt>Data type: <strong>string</strong></dt><dt>Access type: Read-only</dt><dt>Qualifiers: <a href="http://msdn.microsoft.com/en-us/library/windows/desktop/aa393650(v=vs.85).aspx">
<strong>Propagated</strong></a> </dt></dl>
<p>&nbsp;</p>
<p>Value of the scoping computer's <strong>CreationClassName</strong> property. This property is inherited from
<a href="http://msdn.microsoft.com/en-us/library/windows/desktop/aa387884(v=vs.85).aspx">
<strong>CIM_LogicalDevice</strong></a>.</p>
</dd><dt><strong>SystemName</strong></dt><dd>
<dl><dt>Data type: <strong>string</strong></dt><dt>Access type: Read-only</dt><dt>Qualifiers: <a href="http://msdn.microsoft.com/en-us/library/windows/desktop/aa393650(v=vs.85).aspx">
<strong>Propagated</strong></a> </dt></dl>
<p>&nbsp;</p>
<p>Name of the scoping system. This property is inherited from <a href="http://msdn.microsoft.com/en-us/library/windows/desktop/aa387884(v=vs.85).aspx">
<strong>CIM_LogicalDevice</strong></a>.</p>
</dd><dt><strong>TimeOfLastReset</strong></dt><dd>
<dl><dt>Data type: <strong>datetime</strong></dt><dt>Access type: Read-only</dt></dl>
<p>&nbsp;</p>
<p>Date and time the&nbsp; printer was last reset. This property is inherited from
<a href="http://msdn.microsoft.com/en-us/library/windows/desktop/aa387974(v=vs.85).aspx">
<strong>CIM_Printer</strong></a>.</p>
</dd><dt><strong>UntilTime</strong></dt><dd>
<dl><dt>Data type: <strong>datetime</strong></dt><dt>Access type: Read/write</dt></dl>
<p>&nbsp;</p>
<p>Date and time that a&nbsp; printer can print the last&nbsp; job&mdash;if the printer is&nbsp; limited to print&nbsp; at specific&nbsp; times. This value is expressed as&nbsp; the time elapsed since&nbsp; 12:00 AM GMT (Greenwich Mean Time).</p>
</dd><dt><strong>VerticalResolution</strong></dt><dd>
<dl><dt>Data type: <strong>uint32</strong></dt><dt>Access type: Read-only</dt></dl>
<p>&nbsp;</p>
<p>Vertical resolution, in pixels-per-inch,&nbsp; of the printer. This property is inherited from
<a href="http://msdn.microsoft.com/en-us/library/windows/desktop/aa387974(v=vs.85).aspx">
<strong>CIM_Printer</strong></a>.</p>
</dd><dt><strong>WorkOffline</strong></dt><dd>
<dl><dt>Data type: <strong>boolean</strong></dt><dt>Access type: Read/write</dt></dl>
<p>&nbsp;</p>
<p>If <strong>TRUE</strong>, you can&nbsp; queue print jobs on the computer when&nbsp; the printer is offline.</p>
<blockquote>
<div><strong>Windows&nbsp;2000 and Windows&nbsp;NT&nbsp;4.0:&nbsp;&nbsp;</strong>This property is not supported.</div>
</blockquote>
</dd></dl>
<h3>Remarks</h3>
<p>The&nbsp; <strong>Win32_Printer</strong> class is derived from <a href="http://msdn.microsoft.com/en-us/library/windows/desktop/aa387974(v=vs.85).aspx">
<strong>CIM_Printer</strong></a>. Before calling <a href="http://msdn.microsoft.com/en-us/library/windows/desktop/aa393783(v=vs.85).aspx">
<strong>SWbemObject.Put_</strong></a> or <a href="http://msdn.microsoft.com/en-us/library/windows/desktop/aa392115(v=vs.85).aspx">
<strong>IWbemServices::PutInstance</strong></a> for a <strong>Win32_Printer</strong> instance,&nbsp; the
<strong>SeLoadDriverPrivilege</strong>&nbsp; privilege (<strong>wbemPrivilegeLoadDriver</strong> for Visual Basic and LoadDriver for scripting monikers) must be enabled. For more information, see
<a href="http://msdn.microsoft.com/en-us/library/windows/desktop/aa392758(v=vs.85).aspx">
<strong>Privilege Constants</strong></a> and <a href="http://msdn.microsoft.com/en-us/library/windows/desktop/aa390428(v=vs.85).aspx">
Executing Privileged Operations</a>. The following VBScript code example shows how to enable the
<strong>SeLoadDriverPrivilege</strong> privilege in script.</p>
<h1>More Information</h1>
<p><em>The code was created using the WMI Code Creator tool from Microsoft. The code was then slightly modified to work as a stand alone console application. Finally, it was converted into a Mixed C#, VB project using SharpDevelop. Additional information was
 derived from the MSDN Library.</em></p>
