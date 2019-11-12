Partial Class Form1
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
		Dim resources As New System.ComponentModel.ComponentResourceManager(GetType(Form1))
		Me.timerGUI = New System.Windows.Forms.Timer(Me.components)
		Me.mouseKeyEvents = New MouseKeyboardActivityMonitor.Controls.MouseKeyEventProvider()
		Me.label1 = New System.Windows.Forms.Label()
		Me.label2 = New System.Windows.Forms.Label()
		Me.label3 = New System.Windows.Forms.Label()
		Me.label4 = New System.Windows.Forms.Label()
		Me.label5 = New System.Windows.Forms.Label()
		Me.label6 = New System.Windows.Forms.Label()
		Me.label7 = New System.Windows.Forms.Label()
		Me.lblFreeMemory = New System.Windows.Forms.Label()
		Me.lblTotalMemory = New System.Windows.Forms.Label()
		Me.lblDefaultGateway = New System.Windows.Forms.Label()
		Me.lblIdleTime = New System.Windows.Forms.Label()
		Me.lblExternalIPAddress = New System.Windows.Forms.Label()
		Me.lblInternalIPAddress = New System.Windows.Forms.Label()
		Me.lblUpTime = New System.Windows.Forms.Label()
		Me.lblMouseXY = New System.Windows.Forms.Label()
		Me.label9 = New System.Windows.Forms.Label()
		Me.shapeContainer1 = New Microsoft.VisualBasic.PowerPacks.ShapeContainer()
		Me.lineShape4 = New Microsoft.VisualBasic.PowerPacks.LineShape()
		Me.lineShape3 = New Microsoft.VisualBasic.PowerPacks.LineShape()
		Me.lineShape2 = New Microsoft.VisualBasic.PowerPacks.LineShape()
		Me.lineShape1 = New Microsoft.VisualBasic.PowerPacks.LineShape()
		Me.timerFiveSeconds = New System.Windows.Forms.Timer(Me.components)
		Me.rtbConOut = New System.Windows.Forms.RichTextBox()
		Me.flpDiskStatus = New System.Windows.Forms.FlowLayoutPanel()
		Me.SuspendLayout()
		' 
		' timerGUI
		' 
		Me.timerGUI.Interval = 1000
		' 
		' mouseKeyEvents
		' 
		Me.mouseKeyEvents.Enabled = True
		Me.mouseKeyEvents.HookType = MouseKeyboardActivityMonitor.Controls.HookType.[Global]
		AddHandler Me.mouseKeyEvents.MouseClick, New System.Windows.Forms.MouseEventHandler(AddressOf Me.MouseKeyEventsMouseClick)
		AddHandler Me.mouseKeyEvents.MouseMoveExt, New System.EventHandler(Of MouseKeyboardActivityMonitor.MouseEventExtArgs)(AddressOf Me.MouseKeyEventsMouseMoveExt)
		AddHandler Me.mouseKeyEvents.MouseWheel, New System.EventHandler(Of System.Windows.Forms.MouseEventArgs)(AddressOf Me.MouseKeyEventsMouseWheel)
		AddHandler Me.mouseKeyEvents.KeyPress, New System.Windows.Forms.KeyPressEventHandler(AddressOf Me.MouseKeyEventsKeyPress)
		' 
		' label1
		' 
		Me.label1.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
		Me.label1.AutoSize = True
		Me.label1.Location = New System.Drawing.Point(451, 9)
		Me.label1.Name = "label1"
		Me.label1.Size = New System.Drawing.Size(98, 13)
		Me.label1.TabIndex = 1
		Me.label1.Text = "Computer Up Time:"
		' 
		' label2
		' 
		Me.label2.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
		Me.label2.AutoSize = True
		Me.label2.Location = New System.Drawing.Point(450, 47)
		Me.label2.Name = "label2"
		Me.label2.Size = New System.Drawing.Size(99, 13)
		Me.label2.TabIndex = 2
		Me.label2.Text = "Internal IP Address:"
		' 
		' label3
		' 
		Me.label3.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
		Me.label3.AutoSize = True
		Me.label3.Location = New System.Drawing.Point(447, 60)
		Me.label3.Name = "label3"
		Me.label3.Size = New System.Drawing.Size(102, 13)
		Me.label3.TabIndex = 3
		Me.label3.Text = "External IP Address:"
		' 
		' label4
		' 
		Me.label4.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
		Me.label4.AutoSize = True
		Me.label4.Location = New System.Drawing.Point(448, 22)
		Me.label4.Name = "label4"
		Me.label4.Size = New System.Drawing.Size(101, 13)
		Me.label4.TabIndex = 4
		Me.label4.Text = "Computer Idle Time:"
		' 
		' label5
		' 
		Me.label5.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
		Me.label5.AutoSize = True
		Me.label5.Location = New System.Drawing.Point(460, 73)
		Me.label5.Name = "label5"
		Me.label5.Size = New System.Drawing.Size(89, 13)
		Me.label5.TabIndex = 5
		Me.label5.Text = "Default Gateway:"
		' 
		' label6
		' 
		Me.label6.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
		Me.label6.AutoSize = True
		Me.label6.Location = New System.Drawing.Point(475, 101)
		Me.label6.Name = "label6"
		Me.label6.Size = New System.Drawing.Size(74, 13)
		Me.label6.TabIndex = 6
		Me.label6.Text = "Total Memory:"
		' 
		' label7
		' 
		Me.label7.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
		Me.label7.AutoSize = True
		Me.label7.Location = New System.Drawing.Point(478, 114)
		Me.label7.Name = "label7"
		Me.label7.Size = New System.Drawing.Size(71, 13)
		Me.label7.TabIndex = 7
		Me.label7.Text = "Free Memory:"
		' 
		' lblFreeMemory
		' 
		Me.lblFreeMemory.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
		Me.lblFreeMemory.AutoSize = True
		Me.lblFreeMemory.Location = New System.Drawing.Point(576, 114)
		Me.lblFreeMemory.Name = "lblFreeMemory"
		Me.lblFreeMemory.Size = New System.Drawing.Size(32, 13)
		Me.lblFreeMemory.TabIndex = 14
		Me.lblFreeMemory.Text = "0 MB"
		' 
		' lblTotalMemory
		' 
		Me.lblTotalMemory.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
		Me.lblTotalMemory.AutoSize = True
		Me.lblTotalMemory.Location = New System.Drawing.Point(576, 101)
		Me.lblTotalMemory.Name = "lblTotalMemory"
		Me.lblTotalMemory.Size = New System.Drawing.Size(32, 13)
		Me.lblTotalMemory.TabIndex = 13
		Me.lblTotalMemory.Text = "0 MB"
		' 
		' lblDefaultGateway
		' 
		Me.lblDefaultGateway.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
		Me.lblDefaultGateway.AutoSize = True
		Me.lblDefaultGateway.Location = New System.Drawing.Point(576, 73)
		Me.lblDefaultGateway.Name = "lblDefaultGateway"
		Me.lblDefaultGateway.Size = New System.Drawing.Size(76, 13)
		Me.lblDefaultGateway.TabIndex = 12
		Me.lblDefaultGateway.Text = "xxx:xxx:xxx:xxx"
		' 
		' lblIdleTime
		' 
		Me.lblIdleTime.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
		Me.lblIdleTime.AutoSize = True
		Me.lblIdleTime.Location = New System.Drawing.Point(576, 22)
		Me.lblIdleTime.Name = "lblIdleTime"
		Me.lblIdleTime.Size = New System.Drawing.Size(22, 13)
		Me.lblIdleTime.TabIndex = 11
		Me.lblIdleTime.Text = "NA"
		' 
		' lblExternalIPAddress
		' 
		Me.lblExternalIPAddress.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
		Me.lblExternalIPAddress.AutoSize = True
		Me.lblExternalIPAddress.Location = New System.Drawing.Point(576, 60)
		Me.lblExternalIPAddress.Name = "lblExternalIPAddress"
		Me.lblExternalIPAddress.Size = New System.Drawing.Size(76, 13)
		Me.lblExternalIPAddress.TabIndex = 10
		Me.lblExternalIPAddress.Text = "xxx:xxx:xxx:xxx"
		' 
		' lblInternalIPAddress
		' 
		Me.lblInternalIPAddress.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
		Me.lblInternalIPAddress.AutoSize = True
		Me.lblInternalIPAddress.Location = New System.Drawing.Point(576, 47)
		Me.lblInternalIPAddress.Name = "lblInternalIPAddress"
		Me.lblInternalIPAddress.Size = New System.Drawing.Size(76, 13)
		Me.lblInternalIPAddress.TabIndex = 9
		Me.lblInternalIPAddress.Text = "xxx:xxx:xxx:xxx"
		' 
		' lblUpTime
		' 
		Me.lblUpTime.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
		Me.lblUpTime.AutoSize = True
		Me.lblUpTime.Location = New System.Drawing.Point(576, 9)
		Me.lblUpTime.Name = "lblUpTime"
		Me.lblUpTime.Size = New System.Drawing.Size(22, 13)
		Me.lblUpTime.TabIndex = 8
		Me.lblUpTime.Text = "NA"
		' 
		' lblMouseXY
		' 
		Me.lblMouseXY.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
		Me.lblMouseXY.AutoSize = True
		Me.lblMouseXY.Location = New System.Drawing.Point(576, 435)
		Me.lblMouseXY.Name = "lblMouseXY"
		Me.lblMouseXY.Size = New System.Drawing.Size(24, 13)
		Me.lblMouseXY.TabIndex = 16
		Me.lblMouseXY.Text = "X:Y"
		' 
		' label9
		' 
		Me.label9.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
		Me.label9.AutoSize = True
		Me.label9.Location = New System.Drawing.Point(448, 435)
		Me.label9.Name = "label9"
		Me.label9.Size = New System.Drawing.Size(101, 13)
		Me.label9.TabIndex = 15
		Me.label9.Text = "Mouse Coordinates:"
		' 
		' shapeContainer1
		' 
		Me.shapeContainer1.Location = New System.Drawing.Point(0, 0)
		Me.shapeContainer1.Margin = New System.Windows.Forms.Padding(0)
		Me.shapeContainer1.Name = "shapeContainer1"
		Me.shapeContainer1.Shapes.AddRange(New Microsoft.VisualBasic.PowerPacks.Shape() {Me.lineShape4, Me.lineShape3, Me.lineShape2, Me.lineShape1})
		Me.shapeContainer1.Size = New System.Drawing.Size(700, 479)
		Me.shapeContainer1.TabIndex = 17
		Me.shapeContainer1.TabStop = False
		' 
		' lineShape4
		' 
		Me.lineShape4.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
		Me.lineShape4.BorderColor = System.Drawing.Color.Khaki
		Me.lineShape4.Name = "lineShape4"
		Me.lineShape4.X1 = 448
		Me.lineShape4.X2 = 650
		Me.lineShape4.Y1 = 428
		Me.lineShape4.Y2 = 428
		' 
		' lineShape3
		' 
		Me.lineShape3.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
		Me.lineShape3.BorderColor = System.Drawing.Color.Khaki
		Me.lineShape3.Name = "lineShape3"
		Me.lineShape3.X1 = 448
		Me.lineShape3.X2 = 650
		Me.lineShape3.Y1 = 135
		Me.lineShape3.Y2 = 135
		' 
		' lineShape2
		' 
		Me.lineShape2.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
		Me.lineShape2.BorderColor = System.Drawing.Color.Khaki
		Me.lineShape2.Name = "lineShape2"
		Me.lineShape2.X1 = 448
		Me.lineShape2.X2 = 650
		Me.lineShape2.Y1 = 92
		Me.lineShape2.Y2 = 92
		' 
		' lineShape1
		' 
		Me.lineShape1.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
		Me.lineShape1.BorderColor = System.Drawing.Color.Khaki
		Me.lineShape1.Name = "lineShape1"
		Me.lineShape1.X1 = 448
		Me.lineShape1.X2 = 650
		Me.lineShape1.Y1 = 43
		Me.lineShape1.Y2 = 43
		' 
		' timerFiveSeconds
		' 
		Me.timerFiveSeconds.Enabled = True
		Me.timerFiveSeconds.Interval = 60000
		AddHandler Me.timerFiveSeconds.Tick, New System.EventHandler(AddressOf Me.TimerFiveSecondsTick)
		' 
		' rtbConOut
		' 
		Me.rtbConOut.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
		Me.rtbConOut.BackColor = System.Drawing.SystemColors.Desktop
		Me.rtbConOut.BorderStyle = System.Windows.Forms.BorderStyle.None
		Me.rtbConOut.ForeColor = System.Drawing.Color.DarkSalmon
		Me.rtbConOut.Location = New System.Drawing.Point(448, 395)
		Me.rtbConOut.Name = "rtbConOut"
		Me.rtbConOut.[ReadOnly] = True
		Me.rtbConOut.Size = New System.Drawing.Size(203, 24)
		Me.rtbConOut.TabIndex = 21
		Me.rtbConOut.Text = ""
		' 
		' flpDiskStatus
		' 
		Me.flpDiskStatus.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
		Me.flpDiskStatus.AutoSize = True
		Me.flpDiskStatus.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
		Me.flpDiskStatus.BackColor = System.Drawing.Color.Black
		Me.flpDiskStatus.FlowDirection = System.Windows.Forms.FlowDirection.TopDown
		Me.flpDiskStatus.Location = New System.Drawing.Point(652, 144)
		Me.flpDiskStatus.Name = "flpDiskStatus"
		Me.flpDiskStatus.Size = New System.Drawing.Size(0, 0)
		Me.flpDiskStatus.TabIndex = 22
		' 
		' Form1
		' 
		Me.AutoScaleDimensions = New System.Drawing.SizeF(6F, 13F)
		Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
		Me.BackColor = System.Drawing.Color.Black
		Me.ClientSize = New System.Drawing.Size(700, 479)
		Me.Controls.Add(Me.flpDiskStatus)
		Me.Controls.Add(Me.rtbConOut)
		Me.Controls.Add(Me.lblMouseXY)
		Me.Controls.Add(Me.label9)
		Me.Controls.Add(Me.lblFreeMemory)
		Me.Controls.Add(Me.lblTotalMemory)
		Me.Controls.Add(Me.lblDefaultGateway)
		Me.Controls.Add(Me.lblIdleTime)
		Me.Controls.Add(Me.lblExternalIPAddress)
		Me.Controls.Add(Me.lblInternalIPAddress)
		Me.Controls.Add(Me.lblUpTime)
		Me.Controls.Add(Me.label7)
		Me.Controls.Add(Me.label6)
		Me.Controls.Add(Me.label5)
		Me.Controls.Add(Me.label4)
		Me.Controls.Add(Me.label3)
		Me.Controls.Add(Me.label2)
		Me.Controls.Add(Me.label1)
		Me.Controls.Add(Me.shapeContainer1)
		Me.ForeColor = System.Drawing.Color.Yellow
		Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
		Me.Icon = DirectCast(resources.GetObject("$this.Icon"), System.Drawing.Icon)
		Me.Name = "Form1"
		Me.ShowIcon = False
		Me.ShowInTaskbar = False
		Me.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide
		Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
		Me.Text = "BGInfo 2"
		Me.TransparencyKey = System.Drawing.Color.Black
		Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
		Me.ResumeLayout(False)
		Me.PerformLayout()

	End Sub

	#End Region

	Private timerGUI As System.Windows.Forms.Timer
	Private mouseKeyEvents As MouseKeyboardActivityMonitor.Controls.MouseKeyEventProvider
	Private label1 As System.Windows.Forms.Label
	Private label2 As System.Windows.Forms.Label
	Private label3 As System.Windows.Forms.Label
	Private label4 As System.Windows.Forms.Label
	Private label5 As System.Windows.Forms.Label
	Private label6 As System.Windows.Forms.Label
	Private label7 As System.Windows.Forms.Label
	Private lblFreeMemory As System.Windows.Forms.Label
	Private lblTotalMemory As System.Windows.Forms.Label
	Private lblDefaultGateway As System.Windows.Forms.Label
	Private lblIdleTime As System.Windows.Forms.Label
	Private lblExternalIPAddress As System.Windows.Forms.Label
	Private lblInternalIPAddress As System.Windows.Forms.Label
	Private lblUpTime As System.Windows.Forms.Label
	Private lblMouseXY As System.Windows.Forms.Label
	Private label9 As System.Windows.Forms.Label
	Private shapeContainer1 As Microsoft.VisualBasic.PowerPacks.ShapeContainer
	Private lineShape4 As Microsoft.VisualBasic.PowerPacks.LineShape
	Private lineShape3 As Microsoft.VisualBasic.PowerPacks.LineShape
	Private lineShape2 As Microsoft.VisualBasic.PowerPacks.LineShape
	Private lineShape1 As Microsoft.VisualBasic.PowerPacks.LineShape
	Private timerFiveSeconds As System.Windows.Forms.Timer
	Private rtbConOut As System.Windows.Forms.RichTextBox
	Private flpDiskStatus As System.Windows.Forms.FlowLayoutPanel
End Class

