Imports System.Collections.Generic
Imports System.Linq
Imports System.Text
Imports System.Management

Class Program
	Friend Shared Sub Main(args As String())

		Try
			Dim searcher As New ManagementObjectSearcher("root\CIMV2", "SELECT * FROM Win32_Printer")

			For Each queryObj As ManagementObject In searcher.[Get]()
				Console.WriteLine("-----------------------------------")
				Console.WriteLine("Win32_Printer instance")
				Console.WriteLine("-----------------------------------")
				Console.WriteLine("Attributes: {0}", queryObj("Attributes"))
				Console.WriteLine("Availability: {0}", queryObj("Availability"))

				If queryObj("AvailableJobSheets") Is Nothing Then
					Console.WriteLine("AvailableJobSheets: {0}", queryObj("AvailableJobSheets"))
				Else
					Dim arrAvailableJobSheets As [String]() = DirectCast(queryObj("AvailableJobSheets"), [String]())
					For Each arrValue As [String] In arrAvailableJobSheets
						Console.WriteLine("AvailableJobSheets: {0}", arrValue)
					Next
				End If
				Console.WriteLine("AveragePagesPerMinute: {0}", queryObj("AveragePagesPerMinute"))

				If queryObj("Capabilities") Is Nothing Then
					Console.WriteLine("Capabilities: {0}", queryObj("Capabilities"))
				Else
					Dim arrCapabilities As UInt16() = DirectCast(queryObj("Capabilities"), UInt16())
					For Each arrValue As UInt16 In arrCapabilities
						Console.WriteLine("Capabilities: {0}", arrValue)
					Next
				End If

				If queryObj("CapabilityDescriptions") Is Nothing Then
					Console.WriteLine("CapabilityDescriptions: {0}", queryObj("CapabilityDescriptions"))
				Else
					Dim arrCapabilityDescriptions As [String]() = DirectCast(queryObj("CapabilityDescriptions"), [String]())
					For Each arrValue As [String] In arrCapabilityDescriptions
						Console.WriteLine("CapabilityDescriptions: {0}", arrValue)
					Next
				End If
				Console.WriteLine("Caption: {0}", queryObj("Caption"))

				If queryObj("CharSetsSupported") Is Nothing Then
					Console.WriteLine("CharSetsSupported: {0}", queryObj("CharSetsSupported"))
				Else
					Dim arrCharSetsSupported As [String]() = DirectCast(queryObj("CharSetsSupported"), [String]())
					For Each arrValue As [String] In arrCharSetsSupported
						Console.WriteLine("CharSetsSupported: {0}", arrValue)
					Next
				End If
				Console.WriteLine("Comment: {0}", queryObj("Comment"))
				Console.WriteLine("ConfigManagerErrorCode: {0}", queryObj("ConfigManagerErrorCode"))
				Console.WriteLine("ConfigManagerUserConfig: {0}", queryObj("ConfigManagerUserConfig"))
				Console.WriteLine("CreationClassName: {0}", queryObj("CreationClassName"))

				If queryObj("CurrentCapabilities") Is Nothing Then
					Console.WriteLine("CurrentCapabilities: {0}", queryObj("CurrentCapabilities"))
				Else
					Dim arrCurrentCapabilities As UInt16() = DirectCast(queryObj("CurrentCapabilities"), UInt16())
					For Each arrValue As UInt16 In arrCurrentCapabilities
						Console.WriteLine("CurrentCapabilities: {0}", arrValue)
					Next
				End If
				Console.WriteLine("CurrentCharSet: {0}", queryObj("CurrentCharSet"))
				Console.WriteLine("CurrentLanguage: {0}", queryObj("CurrentLanguage"))
				Console.WriteLine("CurrentMimeType: {0}", queryObj("CurrentMimeType"))
				Console.WriteLine("CurrentNaturalLanguage: {0}", queryObj("CurrentNaturalLanguage"))
				Console.WriteLine("CurrentPaperType: {0}", queryObj("CurrentPaperType"))
				Console.WriteLine("Default: {0}", queryObj("Default"))

				If queryObj("DefaultCapabilities") Is Nothing Then
					Console.WriteLine("DefaultCapabilities: {0}", queryObj("DefaultCapabilities"))
				Else
					Dim arrDefaultCapabilities As UInt16() = DirectCast(queryObj("DefaultCapabilities"), UInt16())
					For Each arrValue As UInt16 In arrDefaultCapabilities
						Console.WriteLine("DefaultCapabilities: {0}", arrValue)
					Next
				End If
				Console.WriteLine("DefaultCopies: {0}", queryObj("DefaultCopies"))
				Console.WriteLine("DefaultLanguage: {0}", queryObj("DefaultLanguage"))
				Console.WriteLine("DefaultMimeType: {0}", queryObj("DefaultMimeType"))
				Console.WriteLine("DefaultNumberUp: {0}", queryObj("DefaultNumberUp"))
				Console.WriteLine("DefaultPaperType: {0}", queryObj("DefaultPaperType"))
				Console.WriteLine("DefaultPriority: {0}", queryObj("DefaultPriority"))
				Console.WriteLine("Description: {0}", queryObj("Description"))
				Console.WriteLine("DetectedErrorState: {0}", queryObj("DetectedErrorState"))
				Console.WriteLine("DeviceID: {0}", queryObj("DeviceID"))
				Console.WriteLine("Direct: {0}", queryObj("Direct"))
				Console.WriteLine("DoCompleteFirst: {0}", queryObj("DoCompleteFirst"))
				Console.WriteLine("DriverName: {0}", queryObj("DriverName"))
				Console.WriteLine("EnableBIDI: {0}", queryObj("EnableBIDI"))
				Console.WriteLine("EnableDevQueryPrint: {0}", queryObj("EnableDevQueryPrint"))
				Console.WriteLine("ErrorCleared: {0}", queryObj("ErrorCleared"))
				Console.WriteLine("ErrorDescription: {0}", queryObj("ErrorDescription"))

				If queryObj("ErrorInformation") Is Nothing Then
					Console.WriteLine("ErrorInformation: {0}", queryObj("ErrorInformation"))
				Else
					Dim arrErrorInformation As [String]() = DirectCast(queryObj("ErrorInformation"), [String]())
					For Each arrValue As [String] In arrErrorInformation
						Console.WriteLine("ErrorInformation: {0}", arrValue)
					Next
				End If
				Console.WriteLine("ExtendedDetectedErrorState: {0}", queryObj("ExtendedDetectedErrorState"))
				Console.WriteLine("ExtendedPrinterStatus: {0}", queryObj("ExtendedPrinterStatus"))
				Console.WriteLine("Hidden: {0}", queryObj("Hidden"))
				Console.WriteLine("HorizontalResolution: {0}", queryObj("HorizontalResolution"))
				Console.WriteLine("InstallDate: {0}", queryObj("InstallDate"))
				Console.WriteLine("JobCountSinceLastReset: {0}", queryObj("JobCountSinceLastReset"))
				Console.WriteLine("KeepPrintedJobs: {0}", queryObj("KeepPrintedJobs"))

				If queryObj("LanguagesSupported") Is Nothing Then
					Console.WriteLine("LanguagesSupported: {0}", queryObj("LanguagesSupported"))
				Else
					Dim arrLanguagesSupported As UInt16() = DirectCast(queryObj("LanguagesSupported"), UInt16())
					For Each arrValue As UInt16 In arrLanguagesSupported
						Console.WriteLine("LanguagesSupported: {0}", arrValue)
					Next
				End If
				Console.WriteLine("LastErrorCode: {0}", queryObj("LastErrorCode"))
				Console.WriteLine("Local: {0}", queryObj("Local"))
				Console.WriteLine("Location: {0}", queryObj("Location"))
				Console.WriteLine("MarkingTechnology: {0}", queryObj("MarkingTechnology"))
				Console.WriteLine("MaxCopies: {0}", queryObj("MaxCopies"))
				Console.WriteLine("MaxNumberUp: {0}", queryObj("MaxNumberUp"))
				Console.WriteLine("MaxSizeSupported: {0}", queryObj("MaxSizeSupported"))

				If queryObj("MimeTypesSupported") Is Nothing Then
					Console.WriteLine("MimeTypesSupported: {0}", queryObj("MimeTypesSupported"))
				Else
					Dim arrMimeTypesSupported As [String]() = DirectCast(queryObj("MimeTypesSupported"), [String]())
					For Each arrValue As [String] In arrMimeTypesSupported
						Console.WriteLine("MimeTypesSupported: {0}", arrValue)
					Next
				End If
				Console.WriteLine("Name: {0}", queryObj("Name"))

				If queryObj("NaturalLanguagesSupported") Is Nothing Then
					Console.WriteLine("NaturalLanguagesSupported: {0}", queryObj("NaturalLanguagesSupported"))
				Else
					Dim arrNaturalLanguagesSupported As [String]() = DirectCast(queryObj("NaturalLanguagesSupported"), [String]())
					For Each arrValue As [String] In arrNaturalLanguagesSupported
						Console.WriteLine("NaturalLanguagesSupported: {0}", arrValue)
					Next
				End If
				Console.WriteLine("Network: {0}", queryObj("Network"))

				If queryObj("PaperSizesSupported") Is Nothing Then
					Console.WriteLine("PaperSizesSupported: {0}", queryObj("PaperSizesSupported"))
				Else
					Dim arrPaperSizesSupported As UInt16() = DirectCast(queryObj("PaperSizesSupported"), UInt16())
					For Each arrValue As UInt16 In arrPaperSizesSupported
						Console.WriteLine("PaperSizesSupported: {0}", arrValue)
					Next
				End If

				If queryObj("PaperTypesAvailable") Is Nothing Then
					Console.WriteLine("PaperTypesAvailable: {0}", queryObj("PaperTypesAvailable"))
				Else
					Dim arrPaperTypesAvailable As [String]() = DirectCast(queryObj("PaperTypesAvailable"), [String]())
					For Each arrValue As [String] In arrPaperTypesAvailable
						Console.WriteLine("PaperTypesAvailable: {0}", arrValue)
					Next
				End If
				Console.WriteLine("Parameters: {0}", queryObj("Parameters"))
				Console.WriteLine("PNPDeviceID: {0}", queryObj("PNPDeviceID"))
				Console.WriteLine("PortName: {0}", queryObj("PortName"))

				If queryObj("PowerManagementCapabilities") Is Nothing Then
					Console.WriteLine("PowerManagementCapabilities: {0}", queryObj("PowerManagementCapabilities"))
				Else
					Dim arrPowerManagementCapabilities As UInt16() = DirectCast(queryObj("PowerManagementCapabilities"), UInt16())
					For Each arrValue As UInt16 In arrPowerManagementCapabilities
						Console.WriteLine("PowerManagementCapabilities: {0}", arrValue)
					Next
				End If
				Console.WriteLine("PowerManagementSupported: {0}", queryObj("PowerManagementSupported"))

				If queryObj("PrinterPaperNames") Is Nothing Then
					Console.WriteLine("PrinterPaperNames: {0}", queryObj("PrinterPaperNames"))
				Else
					Dim arrPrinterPaperNames As [String]() = DirectCast(queryObj("PrinterPaperNames"), [String]())
					For Each arrValue As [String] In arrPrinterPaperNames
						Console.WriteLine("PrinterPaperNames: {0}", arrValue)
					Next
				End If
				Console.WriteLine("PrinterState: {0}", queryObj("PrinterState"))
				Console.WriteLine("PrinterStatus: {0}", queryObj("PrinterStatus"))
				Console.WriteLine("PrintJobDataType: {0}", queryObj("PrintJobDataType"))
				Console.WriteLine("PrintProcessor: {0}", queryObj("PrintProcessor"))
				Console.WriteLine("Priority: {0}", queryObj("Priority"))
				Console.WriteLine("Published: {0}", queryObj("Published"))
				Console.WriteLine("Queued: {0}", queryObj("Queued"))
				Console.WriteLine("RawOnly: {0}", queryObj("RawOnly"))
				Console.WriteLine("SeparatorFile: {0}", queryObj("SeparatorFile"))
				Console.WriteLine("ServerName: {0}", queryObj("ServerName"))
				Console.WriteLine("Shared: {0}", queryObj("Shared"))
				Console.WriteLine("ShareName: {0}", queryObj("ShareName"))
				Console.WriteLine("SpoolEnabled: {0}", queryObj("SpoolEnabled"))
				Console.WriteLine("StartTime: {0}", queryObj("StartTime"))
				Console.WriteLine("Status: {0}", queryObj("Status"))
				Console.WriteLine("StatusInfo: {0}", queryObj("StatusInfo"))
				Console.WriteLine("SystemCreationClassName: {0}", queryObj("SystemCreationClassName"))
				Console.WriteLine("SystemName: {0}", queryObj("SystemName"))
				Console.WriteLine("TimeOfLastReset: {0}", queryObj("TimeOfLastReset"))
				Console.WriteLine("UntilTime: {0}", queryObj("UntilTime"))
				Console.WriteLine("VerticalResolution: {0}", queryObj("VerticalResolution"))
				Console.WriteLine("WorkOffline: {0}", queryObj("WorkOffline"))


			Next
		Catch e As ManagementException
			Console.WriteLine("An error occurred while querying for WMI data: " & e.Message)
		End Try

		Console.WriteLine()
		Console.WriteLine("Press any key to quit")
		Console.ReadKey()

	End Sub
End Class
