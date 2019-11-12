Partial Class FrmDesktopView
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

	#Region "Windows Form Designer generated code"

	''' <summary>
	''' Required method for Designer support - do not modify
	''' the contents of this method with the code editor.
	''' </summary>
	Private Sub InitializeComponent()
		Me.components = New System.ComponentModel.Container()
		Me.label1 = New System.Windows.Forms.Label()
		Me.label2 = New System.Windows.Forms.Label()
		Me.lblImages = New System.Windows.Forms.Label()
		Me.lblDomains = New System.Windows.Forms.Label()
		Me.lblImagesQueue = New System.Windows.Forms.Label()
		Me.lblDomainQueue = New System.Windows.Forms.Label()
		Me.label5 = New System.Windows.Forms.Label()
		Me.label6 = New System.Windows.Forms.Label()
		Me.lblStop = New System.Windows.Forms.Label()
		Me.timerGUI = New System.Windows.Forms.Timer(Me.components)
		Me.label3 = New System.Windows.Forms.Label()
		Me.lblPRocessing = New System.Windows.Forms.Label()
		Me.SuspendLayout()
		' 
		' label1
		' 
		Me.label1.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
		Me.label1.AutoSize = True
		Me.label1.Location = New System.Drawing.Point(243, 460)
		Me.label1.Name = "label1"
		Me.label1.Size = New System.Drawing.Size(51, 13)
		Me.label1.TabIndex = 0
		Me.label1.Text = "Domains:"
		' 
		' label2
		' 
		Me.label2.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
		Me.label2.AutoSize = True
		Me.label2.Location = New System.Drawing.Point(250, 473)
		Me.label2.Name = "label2"
		Me.label2.Size = New System.Drawing.Size(44, 13)
		Me.label2.TabIndex = 1
		Me.label2.Text = "Images:"
		' 
		' lblImages
		' 
		Me.lblImages.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
		Me.lblImages.AutoSize = True
		Me.lblImages.Location = New System.Drawing.Point(300, 473)
		Me.lblImages.Name = "lblImages"
		Me.lblImages.Size = New System.Drawing.Size(13, 13)
		Me.lblImages.TabIndex = 3
		Me.lblImages.Text = "0"
		' 
		' lblDomains
		' 
		Me.lblDomains.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
		Me.lblDomains.AutoSize = True
		Me.lblDomains.Location = New System.Drawing.Point(300, 460)
		Me.lblDomains.Name = "lblDomains"
		Me.lblDomains.Size = New System.Drawing.Size(13, 13)
		Me.lblDomains.TabIndex = 2
		Me.lblDomains.Text = "0"
		' 
		' lblImagesQueue
		' 
		Me.lblImagesQueue.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
		Me.lblImagesQueue.AutoSize = True
		Me.lblImagesQueue.Location = New System.Drawing.Point(459, 473)
		Me.lblImagesQueue.Name = "lblImagesQueue"
		Me.lblImagesQueue.Size = New System.Drawing.Size(13, 13)
		Me.lblImagesQueue.TabIndex = 7
		Me.lblImagesQueue.Text = "0"
		' 
		' lblDomainQueue
		' 
		Me.lblDomainQueue.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
		Me.lblDomainQueue.AutoSize = True
		Me.lblDomainQueue.Location = New System.Drawing.Point(459, 460)
		Me.lblDomainQueue.Name = "lblDomainQueue"
		Me.lblDomainQueue.Size = New System.Drawing.Size(13, 13)
		Me.lblDomainQueue.TabIndex = 6
		Me.lblDomainQueue.Text = "0"
		' 
		' label5
		' 
		Me.label5.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
		Me.label5.AutoSize = True
		Me.label5.Location = New System.Drawing.Point(409, 473)
		Me.label5.Name = "label5"
		Me.label5.Size = New System.Drawing.Size(42, 13)
		Me.label5.TabIndex = 5
		Me.label5.Text = "Queue:"
		' 
		' label6
		' 
		Me.label6.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
		Me.label6.AutoSize = True
		Me.label6.Location = New System.Drawing.Point(409, 460)
		Me.label6.Name = "label6"
		Me.label6.Size = New System.Drawing.Size(42, 13)
		Me.label6.TabIndex = 4
		Me.label6.Text = "Queue:"
		' 
		' lblStop
		' 
		Me.lblStop.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
		Me.lblStop.AutoSize = True
		Me.lblStop.BackColor = System.Drawing.Color.Transparent
		Me.lblStop.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
		Me.lblStop.Location = New System.Drawing.Point(550, 471)
		Me.lblStop.Name = "lblStop"
		Me.lblStop.Size = New System.Drawing.Size(31, 15)
		Me.lblStop.TabIndex = 8
		Me.lblStop.Text = "Stop"
		AddHandler Me.lblStop.Click, New System.EventHandler(AddressOf Me.LblStopClick)
		' 
		' timerGUI
		' 
		Me.timerGUI.Enabled = True
		AddHandler Me.timerGUI.Tick, New System.EventHandler(AddressOf Me.TimerGuiTick)
		' 
		' label3
		' 
		Me.label3.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
		Me.label3.AutoSize = True
		Me.label3.Location = New System.Drawing.Point(232, 486)
		Me.label3.Name = "label3"
		Me.label3.Size = New System.Drawing.Size(62, 13)
		Me.label3.TabIndex = 9
		Me.label3.Text = "Processing:"
		' 
		' lblPRocessing
		' 
		Me.lblPRocessing.Anchor = CType(((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left) Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
		Me.lblPRocessing.AutoEllipsis = True
		Me.lblPRocessing.ForeColor = System.Drawing.Color.Aquamarine
		Me.lblPRocessing.Location = New System.Drawing.Point(300, 486)
		Me.lblPRocessing.Name = "lblPRocessing"
		Me.lblPRocessing.Size = New System.Drawing.Size(356, 13)
		Me.lblPRocessing.TabIndex = 10
		' 
		' FrmDesktopView
		' 
		Me.AutoScaleDimensions = New System.Drawing.SizeF(6F, 13F)
		Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
		Me.BackColor = System.Drawing.Color.Black
		Me.ClientSize = New System.Drawing.Size(766, 533)
		Me.ControlBox = False
		Me.Controls.Add(Me.lblPRocessing)
		Me.Controls.Add(Me.label3)
		Me.Controls.Add(Me.lblStop)
		Me.Controls.Add(Me.lblImagesQueue)
		Me.Controls.Add(Me.lblDomainQueue)
		Me.Controls.Add(Me.label5)
		Me.Controls.Add(Me.label6)
		Me.Controls.Add(Me.lblImages)
		Me.Controls.Add(Me.lblDomains)
		Me.Controls.Add(Me.label2)
		Me.Controls.Add(Me.label1)
		Me.ForeColor = System.Drawing.Color.Gold
		Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
		Me.MaximizeBox = False
		Me.MinimizeBox = False
		Me.Name = "FrmDesktopView"
		Me.ShowIcon = False
		Me.ShowInTaskbar = False
		Me.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide
		Me.Text = "frmDesktopView"
		Me.TransparencyKey = System.Drawing.Color.Black
		Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
		Me.ResumeLayout(False)
		Me.PerformLayout()

	End Sub

	#End Region

	Private label1 As System.Windows.Forms.Label
	Private label2 As System.Windows.Forms.Label
	Private lblImages As System.Windows.Forms.Label
	Private lblDomains As System.Windows.Forms.Label
	Private lblImagesQueue As System.Windows.Forms.Label
	Private lblDomainQueue As System.Windows.Forms.Label
	Private label5 As System.Windows.Forms.Label
	Private label6 As System.Windows.Forms.Label
	Private lblStop As System.Windows.Forms.Label
	Private timerGUI As System.Windows.Forms.Timer
	Private label3 As System.Windows.Forms.Label
	Private lblPRocessing As System.Windows.Forms.Label
End Class
