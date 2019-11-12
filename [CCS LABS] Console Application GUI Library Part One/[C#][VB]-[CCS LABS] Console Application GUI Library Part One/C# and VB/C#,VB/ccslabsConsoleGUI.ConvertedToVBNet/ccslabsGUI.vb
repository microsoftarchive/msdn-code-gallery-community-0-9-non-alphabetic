Imports System.Collections.Generic
Imports System.Linq
Imports System.Text
Imports System.Drawing
' Not normally used in Console Apps - so add the reference
Class ccslabsGUI

	''' <summary>
	''' Returns a string that will be centered on the current console screen.
	''' </summary>
	''' <param name="txt">
	''' String: The text to center
	''' </param>
	Friend Sub PrintMiddle(txt As String, Optional NewLine As Boolean = True)
		Console.SetCursorPosition((Console.WindowWidth - txt.Length) \ 2, Console.CursorTop)
		If NewLine Then
			Console.WriteLine(txt)
		Else
			Console.Write(txt)
		End If
	End Sub

	Friend Sub PrintLeft(txt As String, Optional NewLine As Boolean = True)
		Console.SetCursorPosition(0, Console.CursorTop)
		If NewLine Then
			Console.WriteLine(txt)
		Else
			Console.Write(txt)
		End If
	End Sub

	Friend Sub PrintRight(txt As String, Optional NewLine As Boolean = True)
		Console.SetCursorPosition((Console.WindowWidth - txt.Length), Console.CursorTop)
		If NewLine Then
			Console.WriteLine(txt)
		Else
			Console.Write(txt)
		End If
	End Sub

	''' <summary>
	''' Reverses the text and prints at the current cursor position
	''' </summary>
	''' <param name="txt"></param>
	''' <param name="NewLine"></param>
	Friend Sub PrintReverse(txt As String, Optional NewLine As Boolean = True)
		Dim nText As Char() = New Char(txt.Length - 1) {}
		Dim idx As Integer = 1
		' fixes zero initialised arrays
		For Each c As Char In txt.ToCharArray()
			nText((txt.Length) - idx) = c
			' Zero initialised arrays !!
			idx += 1
		Next

		If NewLine Then
			Console.WriteLine(nText)
		Else
			Console.Write(nText)
		End If
	End Sub

	Friend Sub PrintHorizontalLeft(txt As String)
		Dim x As Integer = Console.CursorLeft
		Dim y As Integer = Console.CursorTop


		For Each c As Char In txt.ToCharArray()
			Console.SetCursorPosition(0, Console.CursorTop + 1)

			Console.Write(c.ToString())
		Next

		Console.SetCursorPosition(x, y)
	End Sub

	Friend Sub PrintHorizontalRight(txt As String)
		Dim x As Integer = Console.CursorLeft
		Dim y As Integer = Console.CursorTop


		For Each c As Char In txt.ToCharArray()
			Console.SetCursorPosition(Console.WindowWidth - 1, Console.CursorTop)

			Console.Write(c.ToString())
		Next

		Console.SetCursorPosition(x, y)
	End Sub

	Public Sub CLS()
		Console.Clear()

	End Sub

	Public Sub WaitKey(Optional txt As String = "Press Any Key to continue")
		Console.WriteLine(Environment.NewLine)
		Console.Write(txt)
		Console.ReadKey()
	End Sub
End Class
