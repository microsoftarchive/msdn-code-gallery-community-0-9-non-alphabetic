Imports System.Collections.Generic
Imports System.ComponentModel
Imports System.Data
Imports System.Drawing
Imports System.Linq
Imports System.Text
Imports System.Windows.Forms
Imports MSTSCLib

Public Partial Class RDC
	Inherits Form
	Public Sub New()
		InitializeComponent()
	End Sub

	Private Sub btnConnect_Click(sender As Object, e As EventArgs)
		If btnConnect.Text = "Connect" Then
			If String.IsNullOrEmpty(tbtServer.Text) OrElse String.IsNullOrEmpty(tbPassword.Text) OrElse String.IsNullOrEmpty(tbPort.Text) OrElse String.IsNullOrEmpty(tbUsername.Text) Then
				MessageBox.Show("You need to enter a valid server, port, password and username to connect", "Login Details Required", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning)
			Else
				' for example, I have my AxMsRdpClient control named rdpClient.
				rdpClient.Domain = "ccslabs"
				rdpClient.Server = tbtServer.Text
				rdpClient.UserName = tbUsername.Text
				rdpClient.AdvancedSettings2.SmartSizing = True
				rdpClient.AdvancedSettings9.NegotiateSecurityLayer = True

				' Due to security reasons, you have to implement an interface (IMsTscNonScriptable) to cast it separately.
				'     IMsTscNonScriptable secured = (IMsTscNonScriptable)rdpClient.GetOcx();
				'     secured.ClearTextPassword = tbPassword.Text;

				rdpClient.AdvancedSettings5.ClearTextPassword = tbPassword.Text
				' optional 
				rdpClient.ColorDepth = 24
				' int value can be 8, 15, 16, or 24


				rdpClient.Connect()

				' Ok we have everything we need to continue.
				btnConnect.Text = "Disconnect"

				btnConnect.BackColor = Color.Red
			End If
		Else
			btnConnect.Text = "Connect"
			btnConnect.BackColor = Color.PaleGreen
			Try
				rdpClient.Disconnect()
					' ignore
			Catch generatedExceptionName As Exception
			End Try

			rdpClient.Refresh()
		End If
	End Sub


End Class
