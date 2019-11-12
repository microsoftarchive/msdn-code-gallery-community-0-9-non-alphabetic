Imports System.Collections.Generic
Imports System.Linq
Imports System.Text

Class Program
	Friend Shared Sub Main(args As String())
		Dim GUI As ccslabsConsoleGUI.ccslabsGUI = New ccslabsGUI()

		GUI.PrintMiddle("CCS LABS GUI DEMO")

		GUI.WaitKey()

		GUI.CLS()

		GUI.PrintLeft("Writing on the Left")
		GUI.PrintRight("Writing on the Right")
		GUI.PrintMiddle("Writing in the Middle of the Line")
		GUI.PrintReverse("This text is reversed")
		GUI.PrintHorizontalLeft("Left AND Down")
		GUI.PrintHorizontalRight("Right AND Down")


		GUI.WaitKey("Press any key to exit...")
	End Sub
End Class
