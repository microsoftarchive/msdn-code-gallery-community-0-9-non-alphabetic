Imports Emgu.CV
Imports Emgu.CV.CvEnum
Imports Emgu.CV.Structure
Imports Emgu.CV.UI


Imports System
Imports System.Collections.Generic
Imports System.ComponentModel
Imports System.Data
Imports System.Drawing
Imports System.IO
Imports System.Linq
Imports System.Text
Imports System.Threading
Imports System.Threading.Tasks
Imports System.Windows.Forms


Namespace ComputerVision101
	Partial Public Class Form1
		Inherits Form

		Public Property ScaleFactor() As Double
		Public Property MinimumNeighbours() As Integer
		Public Property MinimumFaceSize() As Integer
		Public Property MaximumFaceSize() As Integer
		Public Property MinFSDetected() As Integer
		Public Property MaxFSDetected() As Integer

		Public ReadOnly ImageExtensions As New List(Of String)() From {".jpg", ".jpe", "jpeg", ".bmp", ".gif", ".png"} ' Will do for now
		Private [STOP] As Boolean = False


		Private wd As String = ""
		Private FrontalFaceAlt2HaarPath As String = ""
		Private EyeHaarPath As String = ""
		Private ProfileFaceHaarPath As String = ""
		Private parojosGPath As String = ""
		Private parojosPath As String = ""
		Private ojoIPath As String = ""
		Private ojoDPath As String = ""
		Private NarizPath As String = ""
		Private MouthPath As String = ""
		Private HSPath As String = ""
		Private upperbodyPath As String = ""
		Private lowerbodyPath As String = ""
		Private fullbodyPath As String = ""
		Private frontalEyesPath As String = ""

		Public Sub New()
			InitializeComponent()
			Try
				ScaleFactor = 1.1R
				tbAutoscaleFactor.Text = ScaleFactor.ToString()
				MinimumNeighbours = 4
				tbMinNeighbours.Text = MinimumNeighbours.ToString()
				MinimumFaceSize = 10
				tbMinFaceSize.Text = MinimumFaceSize.ToString()
				MaximumFaceSize = 100
				tbMaxFaceSize.Text = MaximumFaceSize.ToString()
				Me.Refresh()

				wd = Directory.GetCurrentDirectory()
				FrontalFaceAlt2HaarPath = Path.Combine(wd, "Cascades\haarcascade_frontalface_alt2.xml") ' Remember when changing the cascade to change the detect cascade below
				EyeHaarPath = Path.Combine(wd, "Cascades\haarcascade_eye.xml")
				ProfileFaceHaarPath = Path.Combine(wd, "Cascades\haarcascade_profileface.xml")
				parojosGPath = Path.Combine(wd, "Cascades\parojosG.xml")
				parojosPath = Path.Combine(wd, "Cascades\parojos.xml")
				ojoIPath = Path.Combine(wd, "Cascades\ojoI.xml")
				ojoDPath = Path.Combine(wd, "Cascades\ojoD.xml")
				NarizPath = Path.Combine(wd, "Cascades\Nariz.xml")
				MouthPath = Path.Combine(wd, "Cascades\Mouth.xml")
				HSPath = Path.Combine(wd, "Cascades\HS.xml")
				upperbodyPath = Path.Combine(wd, "Cascades\haarcascade_upperbody.xml")
				lowerbodyPath = Path.Combine(wd, "Cascades\haarcascade_lowerbody.xml")
				fullbodyPath = Path.Combine(wd, "Cascades\haarcascade_fullbody.xml")
				frontalEyesPath = Path.Combine(wd, "Cascades\frontalEyes35x16.xml")
			Catch ex As Exception
				MessageBox.Show(ex.Message)
			End Try
		End Sub

		Private Sub btnStartStop_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnStartStop.Click

			If btnStartStop.Text <> "Stop" Then
				Try
					ScaleFactor = Double.Parse(tbAutoscaleFactor.Text)
					MinimumNeighbours = Integer.Parse(tbMinNeighbours.Text)
					MinimumFaceSize = Integer.Parse(tbMinFaceSize.Text)
					MaximumFaceSize = Integer.Parse(tbMaxFaceSize.Text)
					MinFSDetected = 32500 ' Just set it large for now - it will be corrected automatically within the program
				Catch e1 As Exception
					' Just keep with the defaults for now.
				End Try


				Dim dr As DialogResult = FBD.ShowDialog()
				If dr = System.Windows.Forms.DialogResult.OK Then
					btnStartStop.Text = "Stop"
					Dim files = Directory.GetFiles(FBD.SelectedPath, "*.*", System.IO.SearchOption.AllDirectories)
					For Each file As String In files
						If [STOP] Then ' Exit the loop if the StartStop button is pressed
							Exit For
						End If

						Dim finfo As New FileInfo(file)
						If ImageExtensions.Contains(finfo.Extension.ToLowerInvariant()) AndAlso finfo.Length > 0 Then
							Try
								' Refactored code

								' Load Original image
								Dim Original As New Image(Of Rgb, Byte)(file) ' Needs Disposing at End
								Dim Greyscale As Image(Of Gray, Byte) = Original.Convert(Of Gray, Byte)() ' Needs Disposing at End

								' Setup the processing tasks
								Dim po As New ParallelOptions()
								po.MaxDegreeOfParallelism = Environment.ProcessorCount

								Dim allTasks(13) As Task(Of Rectangle())



								Dim taskProfileFace As New Task(Of Rectangle())(Function() processProfileFace(Greyscale)) ' Detect faces in Greyscale image
								Dim taskEye As New Task(Of Rectangle())(Function() processEye(Greyscale)) ' Detect Eyes in Greyscale image
								Dim taskFrontalFaceAlt2 As New Task(Of Rectangle())(Function() processFrontalFaceAlt2(Greyscale)) ' Detect faces in Greyscale image
								Dim taskParojosG As New Task(Of Rectangle())(Function() processParojosG(Greyscale)) ' Detect faces in Greyscale image
								Dim taskParojos As New Task(Of Rectangle())(Function() processParojos(Greyscale)) ' Detect faces in Greyscale image + Normalised Histogram
								Dim taskOjoI As New Task(Of Rectangle())(Function() processOjoI(Greyscale)) ' Detect faces in Greyscale image + Normalised Histogram + Gama Correction
								Dim taskOjoD As New Task(Of Rectangle())(Function() processOjoD(Greyscale)) ' Detect faces in Greyscale image
								Dim taskNariz As New Task(Of Rectangle())(Function() processNariz(Greyscale)) ' Detect faces in Greyscale image + Normalised Histogram
								Dim taskMouth As New Task(Of Rectangle())(Function() processMouth(Greyscale)) ' Detect faces in Greyscale image + Normalised Histogram + Gama Correction
								Dim taskHS As New Task(Of Rectangle())(Function() processHS(Greyscale)) ' Detect faces in Greyscale image
								Dim taskUpperBody As New Task(Of Rectangle())(Function() processUpperBody(Greyscale)) ' Detect faces in Greyscale image + Normalised Histogram
								Dim taskLowerBody As New Task(Of Rectangle())(Function() processLowerBody(Greyscale)) ' Detect faces in Greyscale image + Normalised Histogram + Gama Correction
								Dim taskFullBody As New Task(Of Rectangle())(Function() processFullBody(Greyscale)) ' Detect faces in Greyscale image
								Dim taskFrontalEye As New Task(Of Rectangle())(Function() processFrontalEye(Greyscale)) ' Detect faces in Greyscale image + Normalised Histogram

								' Add all the tasks to a task array for use later when waiting all the tasks.
								' There are better ways of doing all this task work, but none more clear in my opinion.
								allTasks(0) = taskProfileFace
								allTasks(1) = taskEye
								allTasks(2) = taskFrontalFaceAlt2
								allTasks(3) = taskParojosG
								allTasks(4) = taskParojos
								allTasks(5) = taskOjoI
								allTasks(6) = taskOjoD
								allTasks(7) = taskNariz
								allTasks(8) = taskMouth
								allTasks(9) = taskHS
								allTasks(10) = taskUpperBody
								allTasks(11) = taskLowerBody
								allTasks(12) = taskFullBody
								allTasks(13) = taskFrontalEye

								' Start the Processing Tasks
								taskProfileFace.Start()
								taskEye.Start()
								taskFrontalFaceAlt2.Start()
								taskParojosG.Start()
								taskParojos.Start()
								taskOjoI.Start()
								taskOjoD.Start()
								taskNariz.Start()
								taskMouth.Start()
								taskHS.Start()
								taskUpperBody.Start()
								taskLowerBody.Start()
								taskFullBody.Start()
								taskFrontalEye.Start()

								Task.WaitAll(allTasks, New CancellationToken([STOP])) ' Wait for all the tasks to complete

								If [STOP] Then ' If the tasks were cancelled STOP will be true so tidy up and leave
									Original.Dispose()
									Greyscale.Dispose()
									Exit For
								Else ' Get results from the processing Tasks once they have all completed
									Dim ProfileFaceRectangles() As Rectangle = taskProfileFace.Result
									Dim EyeRectangles() As Rectangle = taskEye.Result
									Dim FrontalFaceAlt2Rectangles() As Rectangle = taskFrontalFaceAlt2.Result
									Dim ParajosGRectangles() As Rectangle = taskParojosG.Result
									Dim ParajosRectangles() As Rectangle = taskParojos.Result
									Dim OjoIRectangles() As Rectangle = taskOjoI.Result
									Dim OjoDRectangles() As Rectangle = taskOjoD.Result
									Dim NarizRectangles() As Rectangle = taskNariz.Result
									Dim MouthRectangles() As Rectangle = taskMouth.Result
									Dim HSRectangles() As Rectangle = taskHS.Result
									Dim UpperBodyRectangles() As Rectangle = taskUpperBody.Result
									Dim LowerBodyRectangles() As Rectangle = taskLowerBody.Result
									Dim FullBodyRectangles() As Rectangle = taskFullBody.Result
									Dim FrontalEyeRectangles() As Rectangle = taskFrontalEye.Result



									' We don't need the greyscale image any more so we can dispose of it now
									Greyscale.Dispose()

									' How many features have been found? Need the max for the progress bar!
									Dim max As Integer = ProfileFaceRectangles.Count()
									max += EyeRectangles.Count()
									max += FrontalFaceAlt2Rectangles.Count()
									max += ParajosGRectangles.Count()
									max += ParajosRectangles.Count()
									max += OjoIRectangles.Count()
									max += OjoDRectangles.Count()
									max += NarizRectangles.Count()
									max += MouthRectangles.Count()
									max += HSRectangles.Count()
									max += UpperBodyRectangles.Count()
									max += LowerBodyRectangles.Count()
									max += FullBodyRectangles.Count()
									max += FrontalEyeRectangles.Count()
									progressThisPicture.Maximum = max

									progressThisPicture.Value = 0
									Dim iterations As Integer = 0

									' Map results on to the Original image
									AddRectanglesToOriginalImage(Original, ProfileFaceRectangles, Color.AliceBlue)
									AddRectanglesToOriginalImage(Original, EyeRectangles, Color.Azure)
									AddRectanglesToOriginalImage(Original, FrontalFaceAlt2Rectangles, Color.Beige)
									AddRectanglesToOriginalImage(Original, ParajosGRectangles, Color.Black)
									AddRectanglesToOriginalImage(Original, ParajosRectangles, Color.BlueViolet)
									AddRectanglesToOriginalImage(Original, OjoIRectangles, Color.CadetBlue)
									AddRectanglesToOriginalImage(Original, OjoDRectangles, Color.Coral)
									AddRectanglesToOriginalImage(Original, NarizRectangles, Color.DarkCyan)
									AddRectanglesToOriginalImage(Original, MouthRectangles, Color.ForestGreen)
									AddRectanglesToOriginalImage(Original, UpperBodyRectangles, Color.Fuchsia)
									AddRectanglesToOriginalImage(Original, LowerBodyRectangles, Color.Goldenrod)
									AddRectanglesToOriginalImage(Original, FullBodyRectangles, Color.Honeydew)
									AddRectanglesToOriginalImage(Original, FrontalEyeRectangles, Color.Indigo)


									' Show the result
									lblMinFaceSize.Text = MinFSDetected.ToString()
									lblMaxFaceSize.Text = MaxFSDetected.ToString()
									pbResult.Image = Original.ToBitmap()
									pbResult.Refresh()
									progressThisPicture.Value = 0
								End If
							Catch ex As Exception
								MessageBox.Show(ex.Message)
							End Try
						End If
						Application.DoEvents()
					Next file
					btnStartStop.Text = "Start"
					[STOP] = False
				End If
			Else
				[STOP] = True
				btnStartStop.Text = "Start"
			End If
		End Sub

		Private Sub AddRectanglesToOriginalImage(ByVal Original As Image(Of Rgb, Byte), ByVal ProfileFaceRectangles() As Rectangle, ByVal displayColour As System.Drawing.Color)
			Try
				For Each face In ProfileFaceRectangles
					If face.Width < MinFSDetected AndAlso face.Width > 0 Then
						MinFSDetected = face.Width
					End If
					If face.Width > MaxFSDetected Then
						MaxFSDetected = face.Width
					End If
					Original.Draw(New Rectangle(face.X, face.Y, face.Width, face.Height), New Rgb(displayColour), 1)
					progressThisPicture.Value = progressThisPicture.Value + 1
					progressThisPicture.Refresh()
				Next face
			Catch ex As Exception
				MessageBox.Show(ex.Message)
			End Try
		End Sub

		Private Function processFrontalEye(ByVal Greyscale As Image(Of Gray, Byte)) As Rectangle()
			Dim h As New CascadeClassifier(frontalEyesPath)
			Return h.DetectMultiScale(Greyscale, ScaleFactor, MinimumNeighbours, New Size(MinimumFaceSize, MinimumFaceSize), New Size(MaximumFaceSize, MaximumFaceSize))
		End Function

		Private Function processFullBody(ByVal Greyscale As Image(Of Gray, Byte)) As Rectangle()
			Dim h As New CascadeClassifier(fullbodyPath)
			Return h.DetectMultiScale(Greyscale, ScaleFactor, MinimumNeighbours, New Size(MinimumFaceSize, MinimumFaceSize), New Size(MaximumFaceSize, MaximumFaceSize))
		End Function

		Private Function processLowerBody(ByVal Greyscale As Image(Of Gray, Byte)) As Rectangle()
			Dim h As New CascadeClassifier(lowerbodyPath)
			Return h.DetectMultiScale(Greyscale, ScaleFactor, MinimumNeighbours, New Size(MinimumFaceSize, MinimumFaceSize), New Size(MaximumFaceSize, MaximumFaceSize))
		End Function

		Private Function processUpperBody(ByVal Greyscale As Image(Of Gray, Byte)) As Rectangle()
			Dim h As New CascadeClassifier(upperbodyPath)
			Return h.DetectMultiScale(Greyscale, ScaleFactor, MinimumNeighbours, New Size(MinimumFaceSize, MinimumFaceSize), New Size(MaximumFaceSize, MaximumFaceSize))
		End Function

		Private Function processHS(ByVal Greyscale As Image(Of Gray, Byte)) As Rectangle()
			Dim h As New CascadeClassifier(HSPath)
			Return h.DetectMultiScale(Greyscale, ScaleFactor, MinimumNeighbours, New Size(MinimumFaceSize, MinimumFaceSize), New Size(MaximumFaceSize, MaximumFaceSize))
		End Function

		Private Function processMouth(ByVal Greyscale As Image(Of Gray, Byte)) As Rectangle()
			Dim h As New CascadeClassifier(MouthPath)
			Return h.DetectMultiScale(Greyscale, ScaleFactor, MinimumNeighbours, New Size(MinimumFaceSize, MinimumFaceSize), New Size(MaximumFaceSize, MaximumFaceSize))
		End Function

		Private Function processNariz(ByVal Greyscale As Image(Of Gray, Byte)) As Rectangle()
			Dim h As New CascadeClassifier(NarizPath)
			Return h.DetectMultiScale(Greyscale, ScaleFactor, MinimumNeighbours, New Size(MinimumFaceSize, MinimumFaceSize), New Size(MaximumFaceSize, MaximumFaceSize))
		End Function

		Private Function processOjoD(ByVal Greyscale As Image(Of Gray, Byte)) As Rectangle()
			Dim h As New CascadeClassifier(ojoDPath)
			Return h.DetectMultiScale(Greyscale, ScaleFactor, MinimumNeighbours, New Size(MinimumFaceSize, MinimumFaceSize), New Size(MaximumFaceSize, MaximumFaceSize))
		End Function

		Private Function processOjoI(ByVal Greyscale As Image(Of Gray, Byte)) As Rectangle()
			Dim h As New CascadeClassifier(ojoIPath)
			Return h.DetectMultiScale(Greyscale, ScaleFactor, MinimumNeighbours, New Size(MinimumFaceSize, MinimumFaceSize), New Size(MaximumFaceSize, MaximumFaceSize))
		End Function

		Private Function processParojos(ByVal Greyscale As Image(Of Gray, Byte)) As Rectangle()
			Dim h As New CascadeClassifier(parojosPath)
			Return h.DetectMultiScale(Greyscale, ScaleFactor, MinimumNeighbours, New Size(MinimumFaceSize, MinimumFaceSize), New Size(MaximumFaceSize, MaximumFaceSize))
		End Function

		Private Function processParojosG(ByVal Greyscale As Image(Of Gray, Byte)) As Rectangle()
			Dim h As New CascadeClassifier(parojosGPath)
			Return h.DetectMultiScale(Greyscale, ScaleFactor, MinimumNeighbours, New Size(MinimumFaceSize, MinimumFaceSize), New Size(MaximumFaceSize, MaximumFaceSize))
		End Function

		Private Function processFrontalFaceAlt2(ByVal Greyscale As Image(Of Gray, Byte)) As Rectangle()
			Dim h As New CascadeClassifier(ProfileFaceHaarPath)
			Return h.DetectMultiScale(Greyscale, ScaleFactor, MinimumNeighbours, New Size(MinimumFaceSize, MinimumFaceSize), New Size(MaximumFaceSize, MaximumFaceSize))
		End Function

		Private Function processEye(ByVal Greyscale As Image(Of Gray, Byte)) As Rectangle()
			Dim h As New CascadeClassifier(EyeHaarPath)
			Return h.DetectMultiScale(Greyscale, ScaleFactor, MinimumNeighbours, New Size(MinimumFaceSize, MinimumFaceSize), New Size(MaximumFaceSize, MaximumFaceSize))
		End Function

		Private Function processProfileFace(ByVal Greyscale As Image(Of Gray, Byte)) As Rectangle()
			Dim h As New CascadeClassifier(FrontalFaceAlt2HaarPath)
			Return h.DetectMultiScale(Greyscale, ScaleFactor, MinimumNeighbours, New Size(MinimumFaceSize, MinimumFaceSize), New Size(MaximumFaceSize, MaximumFaceSize))
		End Function





		Private Sub Form1_Load(ByVal sender As Object, ByVal e As EventArgs) Handles MyBase.Load

		End Sub

		Private Sub Form1_SizeChanged(ByVal sender As Object, ByVal e As EventArgs) Handles MyBase.SizeChanged
			pbResult.Refresh()
		End Sub

		Private Sub Form1_FormClosing(ByVal sender As Object, ByVal e As FormClosingEventArgs) Handles MyBase.FormClosing
			[STOP] = True

		End Sub






	End Class
End Namespace
