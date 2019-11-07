Imports System.Linq
Imports System.Threading.Tasks
Imports System.Windows.Forms
Imports System.ComponentModel
Imports System.Runtime.InteropServices
Imports System.Drawing
Imports System.Diagnostics
Imports System.Net
Imports System.Net.Sockets
Imports System.Text
Imports System.Net.NetworkInformation
Imports System.Collections.Generic
Imports System.IO
Imports HDControl

Public Partial Class Form1
	Inherits Form
	Private dictionaryProcess As New SortedDictionary(Of Integer, Single)()
	Private listDriveInfo As New List(Of DriveInfo)()
	Private idleSeconds As Double = 0
	Private iAmIdle As Boolean = True
	Private proc As New Process()
	Private taskA As Task = Nothing

	#Region "BottomMost"
	<DllImport("user32.dll")> _
	Private Shared Function SetWindowPos(hWnd As IntPtr, hWndInsertAfter As IntPtr, X As Integer, Y As Integer, cx As Integer, cy As Integer, _
		uFlags As UInteger) As Boolean
	End Function

	Shared ReadOnly HWND_BOTTOM As New IntPtr(1)
	Const SWP_NOSIZE As UInt32 = &H1
	Const SWP_NOMOVE As UInt32 = &H2
	Const SWP_NOACTIVATE As UInt32 = &H10
	#End Region

	#Region "Times"

	Private ReadOnly Property UpTime() As TimeSpan
		Get
			Using uptime__1 = New PerformanceCounter("System", "System Up Time")
				uptime__1.NextValue()
				'Call this an extra time before reading its value
				Return TimeSpan.FromSeconds(uptime__1.NextValue())
			End Using
		End Get
	End Property

	' How long has the computer been running?
	Private Function GetUpTime() As String
		Dim days As String = UpTime.Days.ToString("N0")
		' formatted like this 100,000 with no decimal places
		Dim hours As String = UpTime.Hours.ToString("00")
		' Padded with 2 zeros so 2 hours will look like this 02
		Dim minutes As String = UpTime.Minutes.ToString("00")
		Dim secs As String = UpTime.Seconds.ToString("00")

		Dim res As String = ""
		If UpTime.Days = 0 Then
			res = hours & ":" & minutes & ":" & secs
		End If
		' If there are no days show this
		If UpTime.Days = 1 Then
			res = days & " Day " & hours & ":" & minutes & ":" & secs
		End If
		' If there is only 1 day show this
		If [String].IsNullOrEmpty(res) Then
			res = days & " Days " & hours & ":" & minutes & ":" & secs
		End If
		' In all other cases show this
		Return res
	End Function

	Private Function IdleTime() As TimeSpan
		Return TimeSpan.FromSeconds(idleSeconds)
	End Function

	Private Function GetIdleTime() As String
		Dim days As String = IdleTime().Days.ToString("N0")
		' formatted like this 100,000 with no decimal places
		Dim hours As String = IdleTime().Hours.ToString("00")
		' Padded with 2 zeros so 2 hours will look like this 02
		Dim minutes As String = IdleTime().Minutes.ToString("00")
		Dim secs As String = IdleTime().Seconds.ToString("00")

		Dim res As String = ""
		If IdleTime().Days = 0 Then
			res = hours & ":" & minutes & ":" & secs
		End If
		' If there are no days show this
		If IdleTime().Days = 1 Then
			res = days & " Day " & hours & ":" & minutes & ":" & secs
		End If
		' If there is only 1 day show this
		If [String].IsNullOrEmpty(res) Then
			res = days & " Days " & hours & ":" & minutes & ":" & secs
		End If
		' In all other cases show this
		Return res
	End Function

	#End Region

	#Region "Networking"

	Private Function GetLocalIPAddress() As String
		Dim host As IPHostEntry
		Dim localIP As String = ""
		host = Dns.GetHostEntry(Dns.GetHostName())
		For Each ip As IPAddress In host.AddressList
			If ip.AddressFamily = AddressFamily.InterNetwork Then
				localIP = ip.ToString()
			End If
		Next
		Return localIP
	End Function

	Private Function GetExternalIPAddress() As String
		Dim utf8 As New UTF8Encoding()
		Dim webClient As New WebClient()
		Dim externalIp As [String] = utf8.GetString(webClient.DownloadData("http://checkip.dyndns.org"))
		' <html><head><title>Current IP Check</title></head><body>Current IP Address: 92.19.223.72</body></html>
		externalIp = externalIp.Replace("<html><head><title>Current IP Check</title></head><body>Current IP Address:", "")
		externalIp = externalIp.Replace("</body></html>", "")
		Return externalIp.ToString().Trim()
	End Function

	Private Function GetDefaultGatewayIP() As String
		Dim card = NetworkInterface.GetAllNetworkInterfaces().FirstOrDefault()
		If card Is Nothing Then
			Return "Not Known"
		End If
		Dim address = card.GetIPProperties().GatewayAddresses.FirstOrDefault()
		Return address.Address.ToString()
	End Function

	#End Region

	#Region "Memory"

	' Shows how much memory the computer has installed.
	Private Function GetTotalMemory() As ULong
		Return New Microsoft.VisualBasic.Devices.ComputerInfo().TotalPhysicalMemory

	End Function

	' Shows How much memory the computer currently has available
	Private Function GetCurrentMemory() As ULong
		Return New Microsoft.VisualBasic.Devices.ComputerInfo().AvailablePhysicalMemory
	End Function

	#End Region

	#Region "Drives"

	' Get a list of logical drives and their associated Info
	Private Sub GetDrives()
		Dim driveCounter As Integer = 0
		For Each drive As String In Environment.GetLogicalDrives()
			Dim dinfo As New DriveInfo(drive)
			If dinfo.IsReady = True Then
				Dim hdc As New HDControl.HDControl()
				hdc.Name = driveCounter.ToString()
				' ensures a simple but unique name for each drive
				flpDiskStatus.Controls.Add(hdc)
				hdc.Start(dinfo.Name)
				driveCounter += 1
			End If
		Next

	End Sub

	#End Region

	#Region "MouseXY"

	Private Sub MouseKeyEventsMouseMoveExt(sender As Object, e As MouseKeyboardActivityMonitor.MouseEventExtArgs)
		Active()

		Dim mouseX As Integer = e.X
		Dim mouseY As Integer = e.Y

		lblMouseXY.Text = mouseX.ToString("0000") & ":" & mouseY.ToString("0000")
		Inactive()
	End Sub



	#End Region

	#Region "Activity"

	Private Sub Active()
		iAmIdle = False
	End Sub


	Private Sub Inactive()
		iAmIdle = True
		idleSeconds = -1
	End Sub

	Private Sub MouseKeyEventsKeyPress(sender As Object, e As KeyPressEventArgs)
		Active()

		Inactive()
	End Sub

	Private Sub MouseKeyEventsMouseClick(sender As Object, e As MouseEventArgs)
		Active()
		Inactive()
	End Sub

	Private Sub MouseKeyEventsMouseWheel(sender As Object, e As MouseEventArgs)
		Active()
		Inactive()
	End Sub


	#End Region

	#Region "TopProcesses"

	Private Sub TopProcesses()
		OrganiseProcesses(GetAllProcesses())
	End Sub

	Private Sub OrganiseProcesses(procList As List(Of Process))
		' Use Process ID (PID) as Unique IDX and CPU Usage Percent as Value
		' Recreate the Dictionary each time
		dictionaryProcess.Clear()

		For Each p As Process In procList
			Try
				Dim counter = New PerformanceCounter("Process", "% Processor Time", p.ProcessName, True)
				counter.NextValue()

				System.Threading.Thread.Sleep(1000)
				Dim cpu As Single = counter.NextValue()

				If cpu > 0 Then
					dictionaryProcess.Add(p.Id, cpu)
					' Only add processes that are actually using CPU resources

					If dictionaryProcess.Count > 0 Then
					End If
				End If
					' Ignore - process has been removed from the list
					'    Despatcher.Invoke      rtbConOut.Text = ex.Message + Environment.NewLine;
					'           rtbConOut.Refresh();
			Catch ex As Exception
			End Try
		Next
	End Sub

	Private Function GetAllProcesses() As List(Of Process)
		Dim procList As New List(Of Process)()
		Dim procs As Process() = Process.GetProcesses()
		' GC will clean this up later.
		For Each p As Process In procs
			procList.Add(p)
		Next
		Return procList
	End Function

	#End Region


	Public Sub New()
		Me.InitializeComponent()


		SetWindowPos(Handle, HWND_BOTTOM, 0, 0, 0, 0, _
			SWP_NOMOVE Or SWP_NOSIZE Or SWP_NOACTIVATE)
		' Set Form1 as BottomMost
		Me.Visible = False
		timerGUI.Enabled = True
		AddHandler timerGUI.Tick, AddressOf TimerGuiTick
		lblDefaultGateway.Text = GetDefaultGatewayIP()
		lblExternalIPAddress.Text = GetExternalIPAddress()
		lblInternalIPAddress.Text = GetLocalIPAddress()
		lblTotalMemory.Text = ConvertBytesToMegabytes(GetTotalMemory())
		GetDrives()
	End Sub

	Private Sub TimerGuiTick(sender As Object, e As EventArgs)
		SetWindowPos(Handle, HWND_BOTTOM, 0, 0, 0, 0, _
			SWP_NOMOVE Or SWP_NOSIZE Or SWP_NOACTIVATE)
		' Set Form1 as BottomMost
		If iAmIdle Then
			idleSeconds += 1
		End If

		lblUpTime.Text = GetUpTime()
		lblIdleTime.Text = GetIdleTime()
		lblFreeMemory.Text = ConvertBytesToMegabytes(GetCurrentMemory())

		lblInternalIPAddress.Text = GetLocalIPAddress()

	End Sub

	#Region "Formatting Helpers"

	Private Function ConvertBytesToMegabytes(bytes As ULong) As String
		Return ((bytes / 1024F) / 1024F).ToString("N") & " MB"
	End Function


	#End Region

	Private Sub TimerFiveSecondsTick(sender As Object, e As EventArgs)

	End Sub


End Class
