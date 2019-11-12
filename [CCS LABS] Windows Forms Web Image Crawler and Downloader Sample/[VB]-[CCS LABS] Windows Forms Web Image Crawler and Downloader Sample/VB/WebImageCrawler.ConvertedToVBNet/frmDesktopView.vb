Imports System.Collections.Generic
Imports System.ComponentModel
Imports System.Data
Imports System.Drawing
Imports System.Linq
Imports System.Text
Imports System.Windows.Forms
Imports System.Runtime.InteropServices
Imports System.Threading
Imports System.Net
Imports System.IO
Imports DevRain.Data.Extracting

Public Partial Class FrmDesktopView
	Inherits Form
	Private cookieContainer As New CookieContainer()

	Private totalUrls As Double = 0
	Private totalImages As Double = 0

	Private [stop] As Boolean = False
	' Should the application stop running?
	' The FiFo Queues
	Private urlQueue As New Queue(Of String)()
	' holds all the URLs to crawl.
	Private imageQueue As New Queue(Of String)()
	' holds all the images to process.
	' Main Threads
	Private urlThread As Thread
	Private imgThread As Thread

	Private processingNow As String = ""

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

	Public Sub New(url As String)
		InitializeComponent()
		SetWindowPos(Handle, HWND_BOTTOM, 0, 0, 0, 0, _
			SWP_NOMOVE Or SWP_NOSIZE Or SWP_NOACTIVATE)
		' Set this form as BottomMost
		urlQueue.Enqueue(url)
		Start()
	End Sub

	Private Sub LblStopClick(sender As Object, e As EventArgs)
		While urlThread.IsAlive OrElse imgThread.IsAlive
			If urlThread.IsAlive Then
				urlThread.Abort()
			End If
			If imgThread.IsAlive Then
				imgThread.Abort()

			End If
		End While
		Application.[Exit]()
	End Sub

	Private Sub TimerGuiTick(sender As Object, e As EventArgs)
		SetWindowPos(Handle, HWND_BOTTOM, 0, 0, 0, 0, _
			SWP_NOMOVE Or SWP_NOSIZE Or SWP_NOACTIVATE)
		' Set this form as BottomMost
		lblDomainQueue.Text = urlQueue.Count.ToString("N0")
		lblImagesQueue.Text = imageQueue.Count.ToString("N0")
		lblImages.Text = totalImages.ToString("N0")
		lblDomains.Text = totalUrls.ToString("N0")
		lblPRocessing.Text = processingNow
	End Sub

	' Start running the main threads!
	Private Sub Start()
		urlThread = New Thread(New ThreadStart(AddressOf ProcessUrls))
		urlThread.IsBackground = True
		' Let the GC handle this
		urlThread.Start()

		imgThread = New Thread(New ThreadStart(AddressOf ProcessImages))
		imgThread.IsBackground = True
		' Let the GC handle this
		imgThread.Start()


	End Sub



	' download each file from the queue
	Private Sub ProcessImages()
		Dim downloadPath As String = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyPictures), "Wic")

		While Not [stop]
			If imageQueue.Count > 0 Then
				Try
					Dim url As String = imageQueue.Dequeue().ToString()
					Dim fileName As String = url.Substring(url.LastIndexOf("/") + 1, (url.Length - url.LastIndexOf("/") - 1))
					Dim uri As New Uri(url)
					Dim domain As String = uri.Authority.ToString().Replace(".", "_")
					Dim client As New WebClient()

					AddHandler client.DownloadFileCompleted, New AsyncCompletedEventHandler(AddressOf ClientDownloadFileCompleted)
					Dim folder As String = Path.Combine(downloadPath, domain)
					fileName = GenerateFilename(Path.Combine(folder, fileName))

					If Directory.Exists(folder) Then

						client.DownloadFileAsync(uri, Path.Combine(folder, fileName))
					Else
						Directory.CreateDirectory(folder)
						client.DownloadFileAsync(uri, Path.Combine(folder, fileName))

						totalUrls += 1

					End If
						' Not really interested just now
				Catch generatedExceptionName As Exception
				End Try
			End If
		End While

		While imgThread.ThreadState <> ThreadState.Stopped
				' Keep aborting until successful
			imgThread.Abort()
		End While
	End Sub

	Private Sub ClientDownloadFileCompleted(sender As Object, e As AsyncCompletedEventArgs)
		totalImages += 1

	End Sub

	Private Function GenerateFilename(thispath As String) As String
		Dim counter As Integer = 0

		If File.Exists(thispath) Then
			Dim newfile As String = thispath
			While File.Exists(newfile)
				Dim fname As String = Path.GetFileNameWithoutExtension(thispath)
				Dim ext As String = Path.GetExtension(thispath)

				newfile = Path.Combine(Path.GetDirectoryName(thispath), fname & "_" & counter & ext)
				counter += 1
			End While

			Return newfile
		Else
			Return thispath
		End If
	End Function

	Private Sub CheckForDuplicate(thispath As String, newfile As String)
		Throw New NotImplementedException()
	End Sub

	' Add first URL to the urlQueue - get all URLs from that Page that are not Images - and add them to the urlQueue Process this urlQueue
	' Add all image Urls to the imgQueue
	Private Sub ProcessUrls()
		While Not [stop]
			' run this continuos loop until stopped
			If urlQueue.Count > 0 Then
				Try

					Dim thisPage As String = urlQueue.Dequeue()
					' Process the next url in the list
					processingNow = thisPage

					Dim client As New CookieWebClient(cookieContainer)

					Dim html As String = client.DownloadString(thisPage)


					' Get this web page's html
					' GetImageUrls(html);
					GetUrls(html)
						' Ignore for just now
				Catch generatedExceptionName As Exception

				End Try
			End If
		End While

		While urlThread.ThreadState <> ThreadState.Stopped
				' Keep aborting until successful
			urlThread.Abort()
		End While
	End Sub

	Private Sub GetUrls(html As String)
		Dim de As New DataExtractor(html, DataTypes.Url)
		For Each eInfo As ExtractedItemInfo In de.GetExtractedResults()

			' required by some sites ..
			eInfo.Value = eInfo.Value.Trim(")"C)
			If IsImage(eInfo.Value) Then

				imageQueue.Enqueue(eInfo.Value)
			Else

				urlQueue.Enqueue(eInfo.Value)
			End If
		Next
	End Sub

	Private Function IsImage(p As String) As Boolean
		If p.ToLower().EndsWith("jpg") OrElse p.ToLower().EndsWith("png") OrElse p.ToLower().EndsWith("gif") Then
			Return True
		Else
			Return False
		End If
	End Function


End Class
