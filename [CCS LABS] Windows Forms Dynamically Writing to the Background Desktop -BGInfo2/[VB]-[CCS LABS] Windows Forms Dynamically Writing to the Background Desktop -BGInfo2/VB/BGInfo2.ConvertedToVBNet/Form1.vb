Imports System.Linq
Imports System.Windows.Forms
Imports System.ComponentModel
Imports System.Runtime.InteropServices
Imports System.Drawing
Imports System.Diagnostics

Public Partial Class Form1
	Inherits Form
	Private Delegate Sub SetTextCallback(text As String, ctrl As Control)

	Private bgw As New BackgroundWorker()
	Private lblUpTime As Label
	Private lblUsername As Label
	Private rightMargin As Integer = 500

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



	Public ReadOnly Property UpTime() As TimeSpan
		Get
			Using uptime__1 = New PerformanceCounter("System", "System Up Time")
				uptime__1.NextValue()
				'Call this an extra time before reading its value
				Return TimeSpan.FromSeconds(uptime__1.NextValue())
			End Using
		End Get
	End Property


	Public Sub New()
		Me.InitializeComponent()
		Me.Visible = False
		SetWindowPos(Handle, HWND_BOTTOM, 0, 0, 0, 0, _
			SWP_NOMOVE Or SWP_NOSIZE Or SWP_NOACTIVATE)
		' Set Form1 as BottomMost
		AssignLabels()

		AddHandler bgw.DoWork, New DoWorkEventHandler(AddressOf BgwDoWork)

		bgw.RunWorkerAsync()
	End Sub

	' What does the person want shown on the desktop?
	Private Sub AssignLabels()
		' Hard coded for demo
		lblUpTime = New Label()
		lblUpTime.Name = "Up Time"
		lblUpTime.ForeColor = Color.Yellow
		lblUpTime.AutoSize = True
		lblUpTime.Top = Me.Top + 10
		Me.Controls.Add(lblUpTime)

		lblUsername = New Label()
		lblUsername.Name = "Username"
		lblUsername.ForeColor = Color.Yellow
		lblUsername.AutoSize = True
		lblUsername.Top = Me.Top + 25
		Me.Controls.Add(lblUsername)


	End Sub

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

	' Run the backgroundworker that updates the background information display
	Private Sub BgwDoWork(sender As Object, e As DoWorkEventArgs)



	End Sub

	' Only required for cross-thread operations
	Private Sub SetText(text As String, ctrl As Control)
		' InvokeRequired required compares the thread ID of the 
		' calling thread to the thread ID of the creating thread. 
		' If these threads are different, it returns true. 
		If ctrl.InvokeRequired Then
			Dim d As New SetTextCallback(AddressOf SetText)
			Me.Invoke(d, New Object() {text, ctrl})
		Else
			ctrl.Text = text
		End If
	End Sub

	Private Sub TimerGuiTick(sender As Object, e As EventArgs)
		SetWindowPos(Handle, HWND_BOTTOM, 0, 0, 0, 0, _
			SWP_NOMOVE Or SWP_NOSIZE Or SWP_NOACTIVATE)
		' Set Form1 as BottomMost
		lblUpTime.Left = Me.Right - rightMargin
		lblUpTime.Text = "Up Time: " & GetUpTime()

		lblUsername.Left = Me.Right - rightMargin
		lblUsername.Text = "Username: " & Environment.UserName

		Application.DoEvents()

	End Sub

End Class
