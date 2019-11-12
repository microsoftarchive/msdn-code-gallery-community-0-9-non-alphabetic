Partial Class Wic
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
		Dim resources As New System.ComponentModel.ComponentResourceManager(GetType(Wic))
		Me.label1 = New System.Windows.Forms.Label()
		Me.tbURL = New System.Windows.Forms.TextBox()
		Me.btnGo = New System.Windows.Forms.Button()
		Me.SuspendLayout()
		' 
		' label1
		' 
		Me.label1.AutoSize = True
		Me.label1.Location = New System.Drawing.Point(12, 9)
		Me.label1.Name = "label1"
		Me.label1.Size = New System.Drawing.Size(71, 13)
		Me.label1.TabIndex = 0
		Me.label1.Text = "Starting URL:"
		' 
		' tbURL
		' 
		Me.tbURL.Location = New System.Drawing.Point(15, 26)
		Me.tbURL.Name = "tbURL"
		Me.tbURL.Size = New System.Drawing.Size(291, 20)
		Me.tbURL.TabIndex = 1
		' 
		' btnGo
		' 
		Me.btnGo.Location = New System.Drawing.Point(231, 68)
		Me.btnGo.Name = "btnGo"
		Me.btnGo.Size = New System.Drawing.Size(75, 23)
		Me.btnGo.TabIndex = 2
		Me.btnGo.Text = "Go"
		Me.btnGo.UseVisualStyleBackColor = True
		AddHandler Me.btnGo.Click, New System.EventHandler(AddressOf Me.BtnGoClick)
		' 
		' Wic
		' 
		Me.AutoScaleDimensions = New System.Drawing.SizeF(6F, 13F)
		Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
		Me.BackColor = System.Drawing.Color.LightSteelBlue
		Me.ClientSize = New System.Drawing.Size(322, 103)
		Me.Controls.Add(Me.btnGo)
		Me.Controls.Add(Me.tbURL)
		Me.Controls.Add(Me.label1)
		Me.Icon = DirectCast(resources.GetObject("$this.Icon"), System.Drawing.Icon)
		Me.Name = "Wic"
		Me.Text = "Web Image Crawler"
		Me.ResumeLayout(False)
		Me.PerformLayout()

	End Sub

	#End Region

	Private label1 As System.Windows.Forms.Label
	Private tbURL As System.Windows.Forms.TextBox
	Private btnGo As System.Windows.Forms.Button
End Class

