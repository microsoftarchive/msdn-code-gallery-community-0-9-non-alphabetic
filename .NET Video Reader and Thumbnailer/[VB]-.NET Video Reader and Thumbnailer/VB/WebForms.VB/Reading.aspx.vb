Imports System.Drawing
Imports System.Drawing.Imaging
Imports System.Globalization
Imports System.IO
Imports GleamTech.AspNet
Imports GleamTech.Examples
Imports GleamTech.VideoUltimate

Public Class ReadingPage
    Inherits Page

	Protected TotalSeconds As String
	Protected FrameDownloaderUrl As String

    Protected Sub Page_Load(sender As Object, e As EventArgs) Handles Me.Load
		Dim videoPath = exampleFileSelector.SelectedFile
		Dim fileInfo = New FileInfo(videoPath)

		FrameDownloaderUrl = ExamplesConfiguration.GetDynamicDownloadUrl(
            FrameDownloaderHandlerName, 
            New NameValueCollection() From {
			    {"videoPath", ExamplesConfiguration.ProtectString(videoPath)},
			    {"version", fileInfo.LastWriteTimeUtc.Ticks.ToString() + "-" + fileInfo.Length.ToString()},
			    {"frameTime", "0"}
		    })

        Dim duration = GetDuration(videoPath)
        TotalSeconds = CInt(Int(duration.TotalSeconds)).ToString(CultureInfo.InvariantCulture)
	End Sub

	Public Shared Function GetDuration(videoPath As String) As TimeSpan
	    Using videoFrameReader = New VideoFrameReader(videoPath)
	        Return videoFrameReader.Duration
	    End Using
	End Function

	Public Shared Function GetFrame(videoPath As String, frameTime As Double) As Bitmap
	    Using videoFrameReader = New VideoFrameReader(videoPath)
	        If frameTime > 0 Then
	            videoFrameReader.Seek(frameTime)
	        End If

	        'videoFrameReader.SetFrameWidth(300);

	        If videoFrameReader.Read() Then
	            Return videoFrameReader.GetFrame()
	        End If

	        Return GetErrorFrame(videoFrameReader.Width, videoFrameReader.Height, "Reading frame failed")
	    End Using
	End Function

	Public Shared Function GetErrorFrame(width As Integer, height As Integer, [error] As String) As Bitmap
	    Dim bitmap = New Bitmap(width, height)

	    Using _graphics = Graphics.FromImage(bitmap)
	        _graphics.Clear(Color.Black)

	        _graphics.DrawString(
	            [error], 
	            New Font(FontFamily.GenericSansSerif, 12), 
	            New SolidBrush(Color.White), 
	            New RectangleF(0, 0, width, height), 
	            New StringFormat() With { 
	                                .Alignment = StringAlignment.Center, 
	                                .LineAlignment = StringAlignment.Center 
	                                })
	    End Using

	    Return bitmap
	End Function

    Public Shared Sub DownloadVideoFrame(context As IHttpContext)
        Dim videoPath = ExamplesConfiguration.UnprotectString(context.Request("videoPath"))
        Dim frameTime = Integer.Parse(context.Request("frameTime"))

        Using bitmap = GetFrame(videoPath, frameTime)
            Using stream = New MemoryStream()
                bitmap.Save(stream, ImageFormat.Jpeg)
                stream.Position = 0

                Dim fileResponse = New FileResponse(context)
                fileResponse.Transmit(
                    stream, "frame.jpg",
                    File.GetLastWriteTimeUtc(videoPath),
                    stream.Length,
                    neverExpires:=True)
            End Using
        End Using
    End Sub

    Protected ReadOnly Property FrameDownloaderHandlerName As String
	    Get
		    If _frameDownloaderHandlerName Is Nothing Then
			    _frameDownloaderHandlerName = "FrameDownloader"
			    ExamplesConfiguration.RegisterDynamicDownloadHandler(_frameDownloaderHandlerName, AddressOf DownloadVideoFrame)
		    End If

		    Return _frameDownloaderHandlerName
	    End Get
    End Property
    Private Shared _frameDownloaderHandlerName As String

	Protected ReadOnly Property PageCssBundle As ResourceBundle
		Get
			If _pageCssBundle Is Nothing Then
				_pageCssBundle = New ResourceBundle("page.css") From {
					Server.MapPath("~/resources/nouislider.min.css"), 
                    Server.MapPath("~/resources/table.css")
				}

				ResourceManager.Register(_pageCssBundle)
			End If

			Return _pageCssBundle
		End Get
	End Property
	Private Shared _pageCssBundle As ResourceBundle

	Protected ReadOnly Property PageJsBundle As ResourceBundle
		Get
			If _pageJsBundle Is Nothing Then
				_pageJsBundle = New ResourceBundle("page.js") From {
					Server.MapPath("~/resources/nouislider.min.js"),
					Server.MapPath("~/resources/timeslider.js")
				}

				ResourceManager.Register(_pageJsBundle)
			End If

			Return _pageJsBundle
		End Get
	End Property
	Private Shared _pageJsBundle As ResourceBundle
End Class