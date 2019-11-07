Namespace ComputerVision101
	Partial Public Class Form1
		''' <summary>
		''' Required designer variable.
		''' </summary>
		Private components As System.ComponentModel.IContainer = Nothing

		''' <summary>
		''' Clean up any resources being used.
		''' </summary>
		''' <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		Protected Overrides Sub Dispose(ByVal disposing As Boolean)
			If disposing AndAlso (components IsNot Nothing) Then
				components.Dispose()
			End If
			MyBase.Dispose(disposing)
		End Sub

		#Region "Windows Form Designer generated code"

		''' <summary>
		''' Required method for Designer support - do not modify
		''' the contents of this method with the code editor.
		''' </summary>
		Private Sub InitializeComponent()
			Me.btnStartStop = New System.Windows.Forms.Button()
			Me.FBD = New System.Windows.Forms.FolderBrowserDialog()
			Me.label3 = New System.Windows.Forms.Label()
			Me.btnNext = New System.Windows.Forms.Button()
			Me.btnPrevious = New System.Windows.Forms.Button()
			Me.pbResult = New System.Windows.Forms.PictureBox()
			Me.progressThisPicture = New System.Windows.Forms.ProgressBar()
			Me.label1 = New System.Windows.Forms.Label()
			Me.tbAutoscaleFactor = New System.Windows.Forms.TextBox()
			Me.tbMinNeighbours = New System.Windows.Forms.TextBox()
			Me.label2 = New System.Windows.Forms.Label()
			Me.tbMinFaceSize = New System.Windows.Forms.TextBox()
			Me.label4 = New System.Windows.Forms.Label()
			Me.tbMaxFaceSize = New System.Windows.Forms.TextBox()
			Me.label5 = New System.Windows.Forms.Label()
			Me.label6 = New System.Windows.Forms.Label()
			Me.label7 = New System.Windows.Forms.Label()
			Me.lblMaxFaceSize = New System.Windows.Forms.Label()
			Me.lblMinFaceSize = New System.Windows.Forms.Label()
			Me.label8 = New System.Windows.Forms.Label()
			Me.label9 = New System.Windows.Forms.Label()
			Me.label10 = New System.Windows.Forms.Label()
			Me.shapeContainer1 = New Microsoft.VisualBasic.PowerPacks.ShapeContainer()
			Me.rectangleShape1 = New Microsoft.VisualBasic.PowerPacks.RectangleShape()
			Me.rectangleShape2 = New Microsoft.VisualBasic.PowerPacks.RectangleShape()
			Me.rectangleShape3 = New Microsoft.VisualBasic.PowerPacks.RectangleShape()
			DirectCast(Me.pbResult, System.ComponentModel.ISupportInitialize).BeginInit()
			Me.SuspendLayout()
			' 
			' btnStartStop
			' 
			Me.btnStartStop.Anchor = (CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles))
			Me.btnStartStop.Location = New System.Drawing.Point(828, 469)
			Me.btnStartStop.Name = "btnStartStop"
			Me.btnStartStop.Size = New System.Drawing.Size(75, 23)
			Me.btnStartStop.TabIndex = 1
			Me.btnStartStop.Text = "Start"
			Me.btnStartStop.UseVisualStyleBackColor = True
'			Me.btnStartStop.Click += New System.EventHandler(Me.btnStartStop_Click)
			' 
			' FBD
			' 
			Me.FBD.Description = "Folder to collect Images From"
			Me.FBD.RootFolder = System.Environment.SpecialFolder.MyPictures
			' 
			' label3
			' 
			Me.label3.AutoSize = True
			Me.label3.Font = New System.Drawing.Font("Monotype Corsiva", 15.75F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, (CByte(0)))
			Me.label3.Location = New System.Drawing.Point(13, 15)
			Me.label3.Name = "label3"
			Me.label3.Size = New System.Drawing.Size(61, 25)
			Me.label3.TabIndex = 13
			Me.label3.Text = "Result"
			' 
			' btnNext
			' 
			Me.btnNext.Anchor = (CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles))
			Me.btnNext.Location = New System.Drawing.Point(828, 508)
			Me.btnNext.Name = "btnNext"
			Me.btnNext.Size = New System.Drawing.Size(75, 23)
			Me.btnNext.TabIndex = 16
			Me.btnNext.Text = "Next >>"
			Me.btnNext.UseVisualStyleBackColor = True
			' 
			' btnPrevious
			' 
			Me.btnPrevious.Anchor = (CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles))
			Me.btnPrevious.Location = New System.Drawing.Point(747, 508)
			Me.btnPrevious.Name = "btnPrevious"
			Me.btnPrevious.Size = New System.Drawing.Size(75, 23)
			Me.btnPrevious.TabIndex = 17
			Me.btnPrevious.Text = "<< Previous "
			Me.btnPrevious.UseVisualStyleBackColor = True
			' 
			' pbResult
			' 
			Me.pbResult.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
			Me.pbResult.Location = New System.Drawing.Point(19, 43)
			Me.pbResult.Name = "pbResult"
			Me.pbResult.Size = New System.Drawing.Size(723, 459)
			Me.pbResult.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
			Me.pbResult.TabIndex = 18
			Me.pbResult.TabStop = False
			' 
			' progressThisPicture
			' 
			Me.progressThisPicture.Location = New System.Drawing.Point(18, 508)
			Me.progressThisPicture.Name = "progressThisPicture"
			Me.progressThisPicture.Size = New System.Drawing.Size(723, 10)
			Me.progressThisPicture.Step = 1
			Me.progressThisPicture.Style = System.Windows.Forms.ProgressBarStyle.Continuous
			Me.progressThisPicture.TabIndex = 19
			' 
			' label1
			' 
			Me.label1.AutoSize = True
			Me.label1.Location = New System.Drawing.Point(748, 43)
			Me.label1.Name = "label1"
			Me.label1.Size = New System.Drawing.Size(87, 13)
			Me.label1.TabIndex = 20
			Me.label1.Text = "Autoscale Factor"
			' 
			' tbAutoscaleFactor
			' 
			Me.tbAutoscaleFactor.BackColor = System.Drawing.SystemColors.Control
			Me.tbAutoscaleFactor.Location = New System.Drawing.Point(852, 41)
			Me.tbAutoscaleFactor.Name = "tbAutoscaleFactor"
			Me.tbAutoscaleFactor.Size = New System.Drawing.Size(35, 20)
			Me.tbAutoscaleFactor.TabIndex = 21
			Me.tbAutoscaleFactor.Text = "0.0"
			Me.tbAutoscaleFactor.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
			' 
			' tbMinNeighbours
			' 
			Me.tbMinNeighbours.BackColor = System.Drawing.SystemColors.Control
			Me.tbMinNeighbours.Location = New System.Drawing.Point(852, 62)
			Me.tbMinNeighbours.Name = "tbMinNeighbours"
			Me.tbMinNeighbours.Size = New System.Drawing.Size(35, 20)
			Me.tbMinNeighbours.TabIndex = 23
			Me.tbMinNeighbours.Text = "0"
			Me.tbMinNeighbours.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
			' 
			' label2
			' 
			Me.label2.AutoSize = True
			Me.label2.Location = New System.Drawing.Point(748, 64)
			Me.label2.Name = "label2"
			Me.label2.Size = New System.Drawing.Size(105, 13)
			Me.label2.TabIndex = 22
			Me.label2.Text = "Minimum Neighbours"
			' 
			' tbMinFaceSize
			' 
			Me.tbMinFaceSize.BackColor = System.Drawing.SystemColors.Control
			Me.tbMinFaceSize.Location = New System.Drawing.Point(852, 83)
			Me.tbMinFaceSize.Name = "tbMinFaceSize"
			Me.tbMinFaceSize.Size = New System.Drawing.Size(35, 20)
			Me.tbMinFaceSize.TabIndex = 25
			Me.tbMinFaceSize.Text = "0"
			Me.tbMinFaceSize.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
			' 
			' label4
			' 
			Me.label4.AutoSize = True
			Me.label4.Location = New System.Drawing.Point(748, 85)
			Me.label4.Name = "label4"
			Me.label4.Size = New System.Drawing.Size(98, 13)
			Me.label4.TabIndex = 24
			Me.label4.Text = "Minimum Face Size"
			' 
			' tbMaxFaceSize
			' 
			Me.tbMaxFaceSize.BackColor = System.Drawing.SystemColors.Control
			Me.tbMaxFaceSize.Location = New System.Drawing.Point(852, 104)
			Me.tbMaxFaceSize.Name = "tbMaxFaceSize"
			Me.tbMaxFaceSize.Size = New System.Drawing.Size(35, 20)
			Me.tbMaxFaceSize.TabIndex = 27
			Me.tbMaxFaceSize.Text = "0"
			Me.tbMaxFaceSize.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
			' 
			' label5
			' 
			Me.label5.AutoSize = True
			Me.label5.Location = New System.Drawing.Point(748, 106)
			Me.label5.Name = "label5"
			Me.label5.Size = New System.Drawing.Size(101, 13)
			Me.label5.TabIndex = 26
			Me.label5.Text = "Maximum Face Size"
			' 
			' label6
			' 
			Me.label6.AutoSize = True
			Me.label6.Location = New System.Drawing.Point(748, 144)
			Me.label6.Name = "label6"
			Me.label6.Size = New System.Drawing.Size(72, 13)
			Me.label6.TabIndex = 28
			Me.label6.Text = "Min face size:"
			' 
			' label7
			' 
			Me.label7.AutoSize = True
			Me.label7.Location = New System.Drawing.Point(745, 157)
			Me.label7.Name = "label7"
			Me.label7.Size = New System.Drawing.Size(75, 13)
			Me.label7.TabIndex = 29
			Me.label7.Text = "Max face size:"
			' 
			' lblMaxFaceSize
			' 
			Me.lblMaxFaceSize.AutoSize = True
			Me.lblMaxFaceSize.Location = New System.Drawing.Point(823, 157)
			Me.lblMaxFaceSize.Name = "lblMaxFaceSize"
			Me.lblMaxFaceSize.Size = New System.Drawing.Size(13, 13)
			Me.lblMaxFaceSize.TabIndex = 31
			Me.lblMaxFaceSize.Text = "0"
			' 
			' lblMinFaceSize
			' 
			Me.lblMinFaceSize.AutoSize = True
			Me.lblMinFaceSize.Location = New System.Drawing.Point(823, 144)
			Me.lblMinFaceSize.Name = "lblMinFaceSize"
			Me.lblMinFaceSize.Size = New System.Drawing.Size(13, 13)
			Me.lblMinFaceSize.TabIndex = 30
			Me.lblMinFaceSize.Text = "0"
			' 
			' label8
			' 
			Me.label8.AutoSize = True
			Me.label8.Location = New System.Drawing.Point(747, 197)
			Me.label8.Name = "label8"
			Me.label8.Size = New System.Drawing.Size(30, 13)
			Me.label8.TabIndex = 32
			Me.label8.Text = "Eyes"
			' 
			' label9
			' 
			Me.label9.AutoSize = True
			Me.label9.Location = New System.Drawing.Point(748, 210)
			Me.label9.Name = "label9"
			Me.label9.Size = New System.Drawing.Size(66, 13)
			Me.label9.TabIndex = 33
			Me.label9.Text = "Frontal Face"
			' 
			' label10
			' 
			Me.label10.AutoSize = True
			Me.label10.Location = New System.Drawing.Point(748, 223)
			Me.label10.Name = "label10"
			Me.label10.Size = New System.Drawing.Size(36, 13)
			Me.label10.TabIndex = 34
			Me.label10.Text = "Profile"
			' 
			' shapeContainer1
			' 
			Me.shapeContainer1.Location = New System.Drawing.Point(0, 0)
			Me.shapeContainer1.Margin = New System.Windows.Forms.Padding(0)
			Me.shapeContainer1.Name = "shapeContainer1"
			Me.shapeContainer1.Shapes.AddRange(New Microsoft.VisualBasic.PowerPacks.Shape() { Me.rectangleShape3, Me.rectangleShape2, Me.rectangleShape1})
			Me.shapeContainer1.Size = New System.Drawing.Size(915, 543)
			Me.shapeContainer1.TabIndex = 35
			Me.shapeContainer1.TabStop = False
			' 
			' rectangleShape1
			' 
			Me.rectangleShape1.BackColor = System.Drawing.Color.White
			Me.rectangleShape1.FillColor = System.Drawing.Color.White
			Me.rectangleShape1.FillGradientColor = System.Drawing.Color.White
			Me.rectangleShape1.FillStyle = Microsoft.VisualBasic.PowerPacks.FillStyle.Solid
			Me.rectangleShape1.Location = New System.Drawing.Point(814, 201)
			Me.rectangleShape1.Name = "rectangleShape1"
			Me.rectangleShape1.Size = New System.Drawing.Size(89, 9)
			' 
			' rectangleShape2
			' 
			Me.rectangleShape2.BackColor = System.Drawing.Color.White
			Me.rectangleShape2.FillColor = System.Drawing.Color.DarkRed
			Me.rectangleShape2.FillGradientColor = System.Drawing.Color.DarkRed
			Me.rectangleShape2.FillStyle = Microsoft.VisualBasic.PowerPacks.FillStyle.Solid
			Me.rectangleShape2.Location = New System.Drawing.Point(814, 213)
			Me.rectangleShape2.Name = "rectangleShape2"
			Me.rectangleShape2.Size = New System.Drawing.Size(89, 9)
			' 
			' rectangleShape3
			' 
			Me.rectangleShape3.BackColor = System.Drawing.Color.White
			Me.rectangleShape3.FillColor = System.Drawing.Color.Gold
			Me.rectangleShape3.FillGradientColor = System.Drawing.Color.Gold
			Me.rectangleShape3.FillStyle = Microsoft.VisualBasic.PowerPacks.FillStyle.Solid
			Me.rectangleShape3.Location = New System.Drawing.Point(814, 225)
			Me.rectangleShape3.Name = "rectangleShape3"
			Me.rectangleShape3.Size = New System.Drawing.Size(89, 9)
			' 
			' Form1
			' 
			Me.AutoScaleDimensions = New System.Drawing.SizeF(6F, 13F)
			Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
			Me.ClientSize = New System.Drawing.Size(915, 543)
			Me.Controls.Add(Me.label10)
			Me.Controls.Add(Me.label9)
			Me.Controls.Add(Me.label8)
			Me.Controls.Add(Me.lblMaxFaceSize)
			Me.Controls.Add(Me.lblMinFaceSize)
			Me.Controls.Add(Me.label7)
			Me.Controls.Add(Me.label6)
			Me.Controls.Add(Me.tbMaxFaceSize)
			Me.Controls.Add(Me.label5)
			Me.Controls.Add(Me.tbMinFaceSize)
			Me.Controls.Add(Me.label4)
			Me.Controls.Add(Me.tbMinNeighbours)
			Me.Controls.Add(Me.label2)
			Me.Controls.Add(Me.tbAutoscaleFactor)
			Me.Controls.Add(Me.label1)
			Me.Controls.Add(Me.progressThisPicture)
			Me.Controls.Add(Me.btnPrevious)
			Me.Controls.Add(Me.btnNext)
			Me.Controls.Add(Me.label3)
			Me.Controls.Add(Me.btnStartStop)
			Me.Controls.Add(Me.pbResult)
			Me.Controls.Add(Me.shapeContainer1)
			Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
			Me.Name = "Form1"
			Me.Text = "Computer Vision 101"
'			Me.FormClosing += New System.Windows.Forms.FormClosingEventHandler(Me.Form1_FormClosing)
'			Me.Load += New System.EventHandler(Me.Form1_Load)
'			Me.SizeChanged += New System.EventHandler(Me.Form1_SizeChanged)
			DirectCast(Me.pbResult, System.ComponentModel.ISupportInitialize).EndInit()
			Me.ResumeLayout(False)
			Me.PerformLayout()

		End Sub

		#End Region

		Private WithEvents btnStartStop As System.Windows.Forms.Button
		Private FBD As System.Windows.Forms.FolderBrowserDialog
		Private label3 As System.Windows.Forms.Label
		Private btnNext As System.Windows.Forms.Button
		Private btnPrevious As System.Windows.Forms.Button
		Private pbResult As System.Windows.Forms.PictureBox
		Private progressThisPicture As System.Windows.Forms.ProgressBar
		Private label1 As System.Windows.Forms.Label
		Private tbAutoscaleFactor As System.Windows.Forms.TextBox
		Private tbMinNeighbours As System.Windows.Forms.TextBox
		Private label2 As System.Windows.Forms.Label
		Private tbMinFaceSize As System.Windows.Forms.TextBox
		Private label4 As System.Windows.Forms.Label
		Private tbMaxFaceSize As System.Windows.Forms.TextBox
		Private label5 As System.Windows.Forms.Label
		Private label6 As System.Windows.Forms.Label
		Private label7 As System.Windows.Forms.Label
		Private lblMaxFaceSize As System.Windows.Forms.Label
		Private lblMinFaceSize As System.Windows.Forms.Label
		Private label8 As System.Windows.Forms.Label
		Private label9 As System.Windows.Forms.Label
		Private label10 As System.Windows.Forms.Label
		Private shapeContainer1 As Microsoft.VisualBasic.PowerPacks.ShapeContainer
		Private rectangleShape3 As Microsoft.VisualBasic.PowerPacks.RectangleShape
		Private rectangleShape2 As Microsoft.VisualBasic.PowerPacks.RectangleShape
		Private rectangleShape1 As Microsoft.VisualBasic.PowerPacks.RectangleShape
	End Class
End Namespace

