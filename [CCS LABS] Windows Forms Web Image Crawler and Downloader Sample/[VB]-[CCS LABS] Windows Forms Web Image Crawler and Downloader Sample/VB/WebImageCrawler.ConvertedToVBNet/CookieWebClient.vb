Imports System.Collections.Generic
Imports System.Linq
Imports System.Text
Imports System.Net

Class CookieWebClient
	Inherits WebClient
	Public Sub New(container As CookieContainer)
		Me.container = container
	End Sub

	Private ReadOnly container As New CookieContainer()

	Protected Overrides Function GetWebRequest(address As Uri) As WebRequest
		Dim r As WebRequest = MyBase.GetWebRequest(address)
		Dim request = TryCast(r, HttpWebRequest)
		If request IsNot Nothing Then
			request.CookieContainer = container
		End If
		Return r
	End Function

	Protected Overrides Function GetWebResponse(request As WebRequest, result As IAsyncResult) As WebResponse
		Dim response As WebResponse = MyBase.GetWebResponse(request, result)
		ReadCookies(response)
		Return response
	End Function

	Protected Overrides Function GetWebResponse(request As WebRequest) As WebResponse
		Dim response As WebResponse = MyBase.GetWebResponse(request)
		ReadCookies(response)
		Return response
	End Function

	Private Sub ReadCookies(r As WebResponse)
		Dim response = TryCast(r, HttpWebResponse)
		If response IsNot Nothing Then
			Dim cookies As CookieCollection = response.Cookies
			container.Add(cookies)
		End If
	End Sub
End Class
