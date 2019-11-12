Imports System.Collections
Imports System.Collections.Generic
Imports System.Globalization
Imports System.Text.RegularExpressions

Public Enum JapaneseEras As Integer
   Heisei = 4
   Showa = 3
   Taisho = 2
   Meiji = 1
End Enum

Public Class CalendarComparer : Implements IComparer
   Public Function Compare(ByVal x As Object, ByVal y As Object) As Integer _
                  Implements IComparer.Compare
      Dim tX As Type = DirectCast(x, Type)
      Dim tY As Type = DirectCast(y, Type)

      Return tX.Name.CompareTo(tY.Name)
   End Function
End Class

Module Utility
    Friend StartDates As Dictionary(Of String, DateTime)

    Sub New()
        StartDates = New Dictionary(Of String, DateTime)()
        StartDates.Add("Hebrew", New DateTime(1583, 9, 17))
    End Sub

    Friend Function IsValidCalendar(ByVal t As Type) As Boolean
        If t.ToString().EndsWith("Calendar") Then
            If t.IsAbstract Then
                Return False
            Else
                Return True
            End If
        Else
            Return False
        End If
    End Function

    Friend Function GetProperName(ByVal calendarType As Type) As String
        Return Regex.Replace(calendarType.Name, "(\p{Lu}\p{Ll}+)(\p{Lu}\p{Ll}+)*(Calendar)", AddressOf AddSpaces)
    End Function

    Friend Function AddSpaces(ByVal m As Match) As String
        If m.Groups(2).Captures.Count <= 1 Then
            Return m.Groups(1).Value + " " + m.Groups(2).Value
        Else
            Dim name As String = m.Groups(1).Value
            For Each capture As Capture In m.Groups(2).Captures
                name += " " + capture.Value
            Next
            Return name
        End If
    End Function

    Friend Function GetNonDefaultCalendarDate(ByVal dat As DateTime, ByVal cal As Calendar) As String
        Return String.Format("{0:d2}/{1:d2}/{2:d4}", cal.GetMonth(dat), cal.GetDayOfMonth(dat), cal.GetYear(dat))
    End Function
End Module
