Imports System.Collections.Generic
Imports System.ComponentModel
Imports System.Data
Imports System.Drawing
Imports System.IO
Imports System.Linq
Imports System.Net
Imports System.Text
Imports System.Windows.Forms
Imports System.Threading

Imports DevRain.Data.Extracting
Imports System.Runtime.InteropServices



Public Partial Class Wic
	Inherits Form

	Public Sub New()
		InitializeComponent()
	End Sub

	' Checks to see if it can start.
	Private Sub BtnGoClick(sender As Object, e As EventArgs)

		If Not String.IsNullOrEmpty(tbURL.Text) Then
			' Change to Desktop View
			DesktopView()
		Else
			MessageBox.Show("You need to add a valid starting URL")
		End If


	End Sub

	' Re-design the 
	Private Sub DesktopView()
		Me.Hide()
		Dim fdtv As New FrmDesktopView(tbURL.Text)
		fdtv.Show()


	End Sub






End Class
