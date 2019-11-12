Friend Class Switches
   Friend Switch As String

   Public Sub New(ByVal switch As String)
      Me.Switch = switch
   End Sub

   Public Shared Function GetBufferSize(ByVal args() As String) As Integer
      For Each arg In args
         If arg.Trim().ToUpper().StartsWith("/S:") Then
            Dim bufferSize As Integer
            arg = arg.Remove(0, 3)
            If Int32.TryParse(arg, bufferSize) Then
               Return bufferSize
            End If
            Exit For
         End If
      Next
      Return Encode64.DefaultSize
   End Function

   Public Function IsSwitchSet(ByVal value As String) As Boolean
      Return value.ToUpper().Equals(Me.Switch.ToUpper())
   End Function

   Public Function HasSwitch(ByVal value As String) As Boolean
      Return value.Trim().ToUpper().StartsWith(Me.Switch.ToUpper())
   End Function
End Class