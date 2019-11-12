Partial Class HDControl
	''' <summary>
	''' Required designer variable.
	''' </summary>
	Private components As System.ComponentModel.IContainer = Nothing

	''' <summary>
	''' Clean up any resources being used.
	''' </summary>
	''' <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
	Protected Overrides Sub Dispose(disposing As Boolean)
		If disposing AndAlso (components IsNot Nothing) Then
			components.Dispose()
		End If
		MyBase.Dispose(disposing)
	End Sub

	#Region "Component Designer generated code"

	''' <summary>
	''' Required method for Designer support - do not modify 
	''' the contents of this method with the code editor.
	''' </summary>
	Private Sub InitializeComponent()
		Me.components = New System.ComponentModel.Container()
		Dim resources As New System.ComponentModel.ComponentResourceManager(GetType(HDControl))
		Me.pbDiskStatus = New System.Windows.Forms.PictureBox()
		Me.progressFreeSpace = New System.Windows.Forms.ProgressBar()
		Me.lbDriveName = New System.Windows.Forms.Label()
		Me.imagesHDActivity = New System.Windows.Forms.ImageList(Me.components)
		Me.rptTimer = New System.Windows.Forms.Timer(Me.components)
		Me.ProgressRead = New System.Windows.Forms.ProgressBar()
		Me.progressWrite = New System.Windows.Forms.ProgressBar()
		Me.fastTimer = New System.Windows.Forms.Timer(Me.components)
		DirectCast(Me.pbDiskStatus, System.ComponentModel.ISupportInitialize).BeginInit()
		Me.SuspendLayout()
		' 
		' pbDiskStatus
		' 
		Me.pbDiskStatus.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
		Me.pbDiskStatus.Image = DirectCast(resources.GetObject("pbDiskStatus.Image"), System.Drawing.Image)
		Me.pbDiskStatus.Location = New System.Drawing.Point(159, 0)
		Me.pbDiskStatus.Name = "pbDiskStatus"
		Me.pbDiskStatus.Size = New System.Drawing.Size(44, 54)
		Me.pbDiskStatus.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
		Me.pbDiskStatus.TabIndex = 5
		Me.pbDiskStatus.TabStop = False
		' 
		' progressFreeSpace
		' 
		Me.progressFreeSpace.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
		Me.progressFreeSpace.Location = New System.Drawing.Point(6, 17)
		Me.progressFreeSpace.Name = "progressFreeSpace"
		Me.progressFreeSpace.Size = New System.Drawing.Size(136, 10)
		Me.progressFreeSpace.TabIndex = 4
		' 
		' lbDriveName
		' 
		Me.lbDriveName.AutoSize = True
		Me.lbDriveName.ForeColor = System.Drawing.Color.Yellow
		Me.lbDriveName.Location = New System.Drawing.Point(3, 0)
		Me.lbDriveName.Name = "lbDriveName"
		Me.lbDriveName.Size = New System.Drawing.Size(35, 13)
		Me.lbDriveName.TabIndex = 3
		Me.lbDriveName.Text = "label1"
		' 
		' imagesHDActivity
		' 
		Me.imagesHDActivity.ImageStream = DirectCast(resources.GetObject("imagesHDActivity.ImageStream"), System.Windows.Forms.ImageListStreamer)
		Me.imagesHDActivity.TransparentColor = System.Drawing.Color.Transparent
		Me.imagesHDActivity.Images.SetKeyName(0, "drive_3_cb_clean.png")
		Me.imagesHDActivity.Images.SetKeyName(1, "drive_3_sg_clean.png")
		Me.imagesHDActivity.Images.SetKeyName(2, "drive_3_br_clean.png")
		' 
		' rptTimer
		' 
		Me.rptTimer.Interval = 1000
		AddHandler Me.rptTimer.Tick, New System.EventHandler(AddressOf Me.RptTimerTick)
		' 
		' ProgressRead
		' 
		Me.ProgressRead.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
		Me.ProgressRead.ForeColor = System.Drawing.Color.PaleGreen
		Me.ProgressRead.Location = New System.Drawing.Point(6, 28)
		Me.ProgressRead.Name = "ProgressRead"
		Me.ProgressRead.Size = New System.Drawing.Size(136, 10)
		Me.ProgressRead.[Step] = 1
		Me.ProgressRead.Style = System.Windows.Forms.ProgressBarStyle.Continuous
		Me.ProgressRead.TabIndex = 6
		' 
		' progressWrite
		' 
		Me.progressWrite.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
		Me.progressWrite.ForeColor = System.Drawing.Color.Red
		Me.progressWrite.Location = New System.Drawing.Point(6, 39)
		Me.progressWrite.Name = "progressWrite"
		Me.progressWrite.Size = New System.Drawing.Size(136, 10)
		Me.progressWrite.[Step] = 1
		Me.progressWrite.Style = System.Windows.Forms.ProgressBarStyle.Continuous
		Me.progressWrite.TabIndex = 7
		' 
		' fastTimer
		' 
		Me.fastTimer.Interval = 500
		AddHandler Me.fastTimer.Tick, New System.EventHandler(AddressOf Me.FastTimerTick)
		' 
		' HDControl
		' 
		Me.AutoScaleDimensions = New System.Drawing.SizeF(6F, 13F)
		Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
		Me.BackColor = System.Drawing.Color.Transparent
		Me.Controls.Add(Me.progressWrite)
		Me.Controls.Add(Me.ProgressRead)
		Me.Controls.Add(Me.pbDiskStatus)
		Me.Controls.Add(Me.progressFreeSpace)
		Me.Controls.Add(Me.lbDriveName)
		Me.Name = "HDControl"
		Me.Size = New System.Drawing.Size(206, 54)
		DirectCast(Me.pbDiskStatus, System.ComponentModel.ISupportInitialize).EndInit()
		Me.ResumeLayout(False)
		Me.PerformLayout()

	End Sub

	#End Region

	Private pbDiskStatus As System.Windows.Forms.PictureBox
	Private progressFreeSpace As System.Windows.Forms.ProgressBar
	Private lbDriveName As System.Windows.Forms.Label
	Private imagesHDActivity As System.Windows.Forms.ImageList
	Private rptTimer As System.Windows.Forms.Timer
	Private ProgressRead As System.Windows.Forms.ProgressBar
	Private progressWrite As System.Windows.Forms.ProgressBar
	Private fastTimer As System.Windows.Forms.Timer
End Class
