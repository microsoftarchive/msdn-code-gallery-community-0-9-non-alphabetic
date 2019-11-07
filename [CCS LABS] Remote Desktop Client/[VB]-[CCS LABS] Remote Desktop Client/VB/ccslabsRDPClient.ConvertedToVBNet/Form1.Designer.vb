Partial Class RDC
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
		Dim resources As New System.ComponentModel.ComponentResourceManager(GetType(RDC))
		Me.rdpClient = New AxMSTSCLib.AxMsRdpClient8()
		Me.btnConnect = New System.Windows.Forms.Button()
		Me.lblServer = New System.Windows.Forms.Label()
		Me.tbtServer = New System.Windows.Forms.TextBox()
		Me.tbUsername = New System.Windows.Forms.TextBox()
		Me.lblUsername = New System.Windows.Forms.Label()
		Me.tbPassword = New System.Windows.Forms.TextBox()
		Me.label2 = New System.Windows.Forms.Label()
		Me.tbPort = New System.Windows.Forms.TextBox()
		Me.label1 = New System.Windows.Forms.Label()
		Me.shapeContainer1 = New Microsoft.VisualBasic.PowerPacks.ShapeContainer()
		Me.lineShape1 = New Microsoft.VisualBasic.PowerPacks.LineShape()
		DirectCast(Me.rdpClient, System.ComponentModel.ISupportInitialize).BeginInit()
		Me.SuspendLayout()
		' 
		' rdpClient
		' 
		Me.rdpClient.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) Or System.Windows.Forms.AnchorStyles.Left) Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
		Me.rdpClient.Enabled = True
		Me.rdpClient.Location = New System.Drawing.Point(12, 12)
		Me.rdpClient.Name = "rdpClient"
		Me.rdpClient.OcxState = DirectCast(resources.GetObject("rdpClient.OcxState"), System.Windows.Forms.AxHost.State)
		Me.rdpClient.Size = New System.Drawing.Size(381, 271)
		Me.rdpClient.TabIndex = 0
		' 
		' btnConnect
		' 
		Me.btnConnect.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
		Me.btnConnect.BackColor = System.Drawing.Color.PaleGreen
		Me.btnConnect.Location = New System.Drawing.Point(318, 359)
		Me.btnConnect.Name = "btnConnect"
		Me.btnConnect.Size = New System.Drawing.Size(75, 23)
		Me.btnConnect.TabIndex = 1
		Me.btnConnect.Text = "Connect"
		Me.btnConnect.UseVisualStyleBackColor = False
		AddHandler Me.btnConnect.Click, New System.EventHandler(AddressOf Me.btnConnect_Click)
		' 
		' lblServer
		' 
		Me.lblServer.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
		Me.lblServer.AutoSize = True
		Me.lblServer.Location = New System.Drawing.Point(9, 301)
		Me.lblServer.Name = "lblServer"
		Me.lblServer.Size = New System.Drawing.Size(38, 13)
		Me.lblServer.TabIndex = 2
		Me.lblServer.Text = "Server"
		' 
		' tbtServer
		' 
		Me.tbtServer.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
		Me.tbtServer.Location = New System.Drawing.Point(12, 317)
		Me.tbtServer.Name = "tbtServer"
		Me.tbtServer.Size = New System.Drawing.Size(174, 20)
		Me.tbtServer.TabIndex = 3
		' 
		' tbUsername
		' 
		Me.tbUsername.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
		Me.tbUsername.Location = New System.Drawing.Point(12, 361)
		Me.tbUsername.Name = "tbUsername"
		Me.tbUsername.Size = New System.Drawing.Size(105, 20)
		Me.tbUsername.TabIndex = 5
		' 
		' lblUsername
		' 
		Me.lblUsername.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
		Me.lblUsername.AutoSize = True
		Me.lblUsername.Location = New System.Drawing.Point(9, 345)
		Me.lblUsername.Name = "lblUsername"
		Me.lblUsername.Size = New System.Drawing.Size(55, 13)
		Me.lblUsername.TabIndex = 4
		Me.lblUsername.Text = "Username"
		' 
		' tbPassword
		' 
		Me.tbPassword.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
		Me.tbPassword.Location = New System.Drawing.Point(136, 361)
		Me.tbPassword.Name = "tbPassword"
		Me.tbPassword.PasswordChar = "*"C
		Me.tbPassword.Size = New System.Drawing.Size(105, 20)
		Me.tbPassword.TabIndex = 7
		' 
		' label2
		' 
		Me.label2.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
		Me.label2.AutoSize = True
		Me.label2.Location = New System.Drawing.Point(133, 345)
		Me.label2.Name = "label2"
		Me.label2.Size = New System.Drawing.Size(53, 13)
		Me.label2.TabIndex = 6
		Me.label2.Text = "Password"
		' 
		' tbPort
		' 
		Me.tbPort.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
		Me.tbPort.Location = New System.Drawing.Point(195, 317)
		Me.tbPort.Name = "tbPort"
		Me.tbPort.Size = New System.Drawing.Size(46, 20)
		Me.tbPort.TabIndex = 9
		Me.tbPort.Text = "3389"
		Me.tbPort.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
		' 
		' label1
		' 
		Me.label1.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
		Me.label1.AutoSize = True
		Me.label1.Location = New System.Drawing.Point(192, 301)
		Me.label1.Name = "label1"
		Me.label1.Size = New System.Drawing.Size(26, 13)
		Me.label1.TabIndex = 8
		Me.label1.Text = "Port"
		' 
		' shapeContainer1
		' 
		Me.shapeContainer1.Location = New System.Drawing.Point(0, 0)
		Me.shapeContainer1.Margin = New System.Windows.Forms.Padding(0)
		Me.shapeContainer1.Name = "shapeContainer1"
		Me.shapeContainer1.Shapes.AddRange(New Microsoft.VisualBasic.PowerPacks.Shape() {Me.lineShape1})
		Me.shapeContainer1.Size = New System.Drawing.Size(405, 394)
		Me.shapeContainer1.TabIndex = 10
		Me.shapeContainer1.TabStop = False
		' 
		' lineShape1
		' 
		Me.lineShape1.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
		Me.lineShape1.Name = "lineShape1"
		Me.lineShape1.X1 = 280
		Me.lineShape1.X2 = 280
		Me.lineShape1.Y1 = 311
		Me.lineShape1.Y2 = 378
		' 
		' RDC
		' 
		Me.AutoScaleDimensions = New System.Drawing.SizeF(6F, 13F)
		Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
		Me.ClientSize = New System.Drawing.Size(405, 394)
		Me.Controls.Add(Me.tbPort)
		Me.Controls.Add(Me.label1)
		Me.Controls.Add(Me.tbPassword)
		Me.Controls.Add(Me.label2)
		Me.Controls.Add(Me.tbUsername)
		Me.Controls.Add(Me.lblUsername)
		Me.Controls.Add(Me.tbtServer)
		Me.Controls.Add(Me.lblServer)
		Me.Controls.Add(Me.btnConnect)
		Me.Controls.Add(Me.rdpClient)
		Me.Controls.Add(Me.shapeContainer1)
		Me.Icon = DirectCast(resources.GetObject("$this.Icon"), System.Drawing.Icon)
		Me.Name = "RDC"
		Me.Text = "Remote Desktop Client"
		DirectCast(Me.rdpClient, System.ComponentModel.ISupportInitialize).EndInit()
		Me.ResumeLayout(False)
		Me.PerformLayout()

	End Sub

	#End Region

	Private rdpClient As AxMSTSCLib.AxMsRdpClient8
	Private btnConnect As System.Windows.Forms.Button
	Private lblServer As System.Windows.Forms.Label
	Private tbtServer As System.Windows.Forms.TextBox
	Private tbUsername As System.Windows.Forms.TextBox
	Private lblUsername As System.Windows.Forms.Label
	Private tbPassword As System.Windows.Forms.TextBox
	Private label2 As System.Windows.Forms.Label
	Private tbPort As System.Windows.Forms.TextBox
	Private label1 As System.Windows.Forms.Label
	Private shapeContainer1 As Microsoft.VisualBasic.PowerPacks.ShapeContainer
	Private lineShape1 As Microsoft.VisualBasic.PowerPacks.LineShape
End Class

