Imports System.Windows.Forms

Public NotInheritable Class DelegateExpansion
	Private Sub New()
	End Sub
	' Prevent CrossThreadException by invoking delegate through target control's thread.
	
	Public Shared Function CrossInvoke(delgt As [Delegate], sender As Object, e As EventArgs) As Object
		If TypeOf delgt.Target Is Control AndAlso DirectCast(delgt.Target, Control).InvokeRequired Then
			Return DirectCast(delgt.Target, Control).Invoke(delgt, New Object() {sender, e})
		End If
		Return delgt.Method.Invoke(delgt.Target, New Object() {sender, e})
	End Function
End Class
