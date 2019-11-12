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
		Me.notificationIcon = New System.Windows.Forms.NotifyIcon(Me.components)
		Me.contextMenuStrip1 = New System.Windows.Forms.ContextMenuStrip(Me.components)
		Me.optionsToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
		Me.toolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator()
		Me.exitToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
		Me.timerGUI = New System.Windows.Forms.Timer(Me.components)
		Me.contextMenuStrip1.SuspendLayout()
		Me.SuspendLayout()
		' 
		' notificationIcon
		' 
		Me.notificationIcon.BalloonTipIcon = System.Windows.Forms.ToolTipIcon.Info
		Me.notificationIcon.ContextMenuStrip = Me.contextMenuStrip1
		Me.notificationIcon.Icon = DirectCast(resources.GetObject("notificationIcon.Icon"), System.Drawing.Icon)
		Me.notificationIcon.Text = "notifyIcon1"
		Me.notificationIcon.Visible = True
		' 
		' contextMenuStrip1
		' 
		Me.contextMenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.optionsToolStripMenuItem, Me.toolStripSeparator1, Me.exitToolStripMenuItem})
		Me.contextMenuStrip1.Name = "contextMenuStrip1"
		Me.contextMenuStrip1.Size = New System.Drawing.Size(117, 54)
		' 
		' optionsToolStripMenuItem
		' 
		Me.optionsToolStripMenuItem.Name = "optionsToolStripMenuItem"
		Me.optionsToolStripMenuItem.Size = New System.Drawing.Size(116, 22)
		Me.optionsToolStripMenuItem.Text = "Options"
		' 
		' toolStripSeparator1
		' 
		Me.toolStripSeparator1.Name = "toolStripSeparator1"
		Me.toolStripSeparator1.Size = New System.Drawing.Size(113, 6)
		' 
		' exitToolStripMenuItem
		' 
		Me.exitToolStripMenuItem.Name = "exitToolStripMenuItem"
		Me.exitToolStripMenuItem.Size = New System.Drawing.Size(116, 22)
		Me.exitToolStripMenuItem.Text = "Exit"
		' 
		' timerGUI
		' 
		Me.timerGUI.Enabled = True
		Me.timerGUI.Interval = 1000
		AddHandler Me.timerGUI.Tick, New System.EventHandler(AddressOf Me.TimerGuiTick)
		' 
		' Form1
		' 
		Me.AutoScaleDimensions = New System.Drawing.SizeF(6F, 13F)
		Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
		Me.BackColor = System.Drawing.Color.Black
		Me.ClientSize = New System.Drawing.Size(700, 479)
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
		Me.contextMenuStrip1.ResumeLayout(False)
		Me.ResumeLayout(False)

	End Sub

	#End Region

	Private notificationIcon As System.Windows.Forms.NotifyIcon
	Private contextMenuStrip1 As System.Windows.Forms.ContextMenuStrip
	Private optionsToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
	Private toolStripSeparator1 As System.Windows.Forms.ToolStripSeparator
	Private exitToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
	Private timerGUI As System.Windows.Forms.Timer
End Class

