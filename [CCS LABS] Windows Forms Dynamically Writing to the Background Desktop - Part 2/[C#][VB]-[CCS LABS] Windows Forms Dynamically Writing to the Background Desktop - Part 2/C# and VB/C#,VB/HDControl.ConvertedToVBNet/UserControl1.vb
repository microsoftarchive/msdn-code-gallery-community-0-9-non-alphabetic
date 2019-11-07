Imports System.Collections.Generic
Imports System.ComponentModel
Imports System.Drawing
Imports System.Data
Imports System.Linq
Imports System.Text
Imports System.Windows.Forms
Imports System.Management

Public Partial Class HDControl
	Inherits UserControl
	Private MaxRead As Double = 0
	Private MaxWrite As Double = 0

	Private m_enable As Boolean

	Public Property Enable() As Boolean
		Get
			Return Me.m_enable
		End Get
		Set
			Me.m_enable = value
			Start()
		End Set
	End Property

	Private m_driveName As String

	Public Property DriveName() As String
		Get
			Return Me.m_driveName
		End Get
		Set
			Me.m_driveName = value
		End Set
	End Property




	Public Enum DiskStatusImage
		InActive
		Read
		Write
	End Enum
	' this is the order of the ImageList we use


	Public Sub New()
		InitializeComponent()
	End Sub

	' Start the Control monitoring the supplied Drive name
	Public Sub Start(drivename As String)
		lbDriveName.Text = drivename
		' This control monitors this drive
		rptTimer.Enabled = True
		' Start the update timer
		fastTimer.Enabled = True
		' For Drives
	End Sub

	' Start the Control monitoring the supplied Drive name
	Public Sub Start()
		If Not String.IsNullOrEmpty(DriveName) Then
			lbDriveName.Text = DriveName
			' This control monitors this drive
			rptTimer.Enabled = True
			' Start the update timer
				' For Drives
			fastTimer.Enabled = True
		Else
			m_enable = False
		End If
	End Sub

	' Stop the control when no longer needed - like shutting down or rebooting or whatever
	Public Sub [Stop]()
		rptTimer.Enabled = False
		fastTimer.Enabled = False
		' For Drives
		Try
			Me.Dispose()
				' We should manage this exception so we ensure the release of resources
				' Although the GC will catch up.
		Catch generatedExceptionName As Exception
		End Try
	End Sub

	' Ticks every second for an update
	Private Sub RptTimerTick(sender As Object, e As EventArgs)
		progressFreeSpace.Value = 100 - GetFreeSpace(lbDriveName.Text.Trim("\"C))
		' Set the free space bar.
		Me.Refresh()
	End Sub


	''' <summary>
	''' Gets the free space for the specified drive as a percentage
	''' </summary>
	''' <param name="drivename">
	''' The drive to get free space of
	''' </param>
	''' <returns>
	''' int: The Free space of the drive if no error is found
	''' int: 100 if the drive is not used or there has been an error
	''' </returns>
	Private Function GetFreeSpace(drivename As String) As Integer
		Try
			Dim searcher As New ManagementObjectSearcher("root\CIMV2", "SELECT * FROM Win32_PerfFormattedData_PerfDisk_LogicalDisk")

			For Each queryObj As ManagementObject In searcher.[Get]()
				If DirectCast(queryObj("Name"), String) = drivename Then
					Return Integer.Parse(queryObj("PercentFreeSpace").ToString())

				End If
			Next
				' Ignore this error for now
		Catch e As ManagementException
		End Try
		Return 100
	End Function

	Private Function InQuotes(p As String) As String
		Return "'" & p & "'"
	End Function

	Private Function GetDiskStatus(drivename As String) As Integer
		Try
			Dim searcher As New ManagementObjectSearcher("root\CIMV2", "SELECT * FROM Win32_PerfFormattedData_PerfDisk_LogicalDisk")

			For Each queryObj As ManagementObject In searcher.[Get]()
				If DirectCast(queryObj("Name"), String) = drivename Then
					Dim reads As Double = Double.Parse(queryObj("DiskReadsPersec").ToString())
					Dim writes As Double = Double.Parse(queryObj("DiskWritesPersec").ToString())

					If reads > MaxRead Then
						MaxRead = reads
					End If
					If writes > MaxWrite Then
						MaxWrite = writes
					End If

					ProgressRead.Maximum = CInt(Math.Truncate(MaxRead)) + 1
					progressWrite.Maximum = CInt(Math.Truncate(MaxWrite)) + 1

					ProgressRead.Value = CInt(Math.Truncate(reads))
					progressWrite.Value = CInt(Math.Truncate(writes))


					' decide which is happening most to decide what image to show
					If reads > writes Then
						Return CInt(DiskStatusImage.Read)
					ElseIf writes > reads Then
						Return CInt(DiskStatusImage.Write)
					Else
						Return CInt(DiskStatusImage.InActive)
					End If
				End If
			Next
		Catch e As ManagementException
			Return 0
		End Try
		Return 0
	End Function

	Private Sub FastTimerTick(sender As Object, e As EventArgs)
		pbDiskStatus.Image = imagesHDActivity.Images(GetDiskStatus(lbDriveName.Text.Trim("\"C)))
	End Sub
End Class
