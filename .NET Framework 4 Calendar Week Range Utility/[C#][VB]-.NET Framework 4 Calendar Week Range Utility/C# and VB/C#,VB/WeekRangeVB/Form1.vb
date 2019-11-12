Imports System.Collections
Imports System.Globalization
Imports System.Reflection
Imports System.Windows.Forms

Public Class Form1
   Private Const JapaneseLunisolarEras As Integer = 2
   Dim label As ToolStripStatusLabel

   Private Sub Form1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
      ' To test the application's behavior with a different current calendar other than Gregorian, 
      ' uncomment the respective code block.
      '
      '' Change culture and calendar (JapaneseCalendar)
      'Dim japaneseCulture As New CultureInfo("ja-JP")
      'japaneseCulture.DateTimeFormat.Calendar = New JapaneseCalendar()
      'System.Threading.Thread.CurrentThread.CurrentCulture = japaneseCulture

      '' Change culture and calendar (HebrewCalendar)
      'Dim hebrewCulture As New CultureInfo("he-IL")
      'hebrewCulture.DateTimeFormat.Calendar = New HebrewCalendar()
      'System.Threading.Thread.CurrentThread.CurrentCulture = hebrewCulture

      '' Change culture and calendar (UmALQuraCalendar)
      'Dim arabCulture As New CultureInfo("ar-AE")
      'arabCulture.DateTimeFormat.Calendar = New UmAlQuraCalendar()
      'System.Threading.Thread.CurrentThread.CurrentCulture = arabCulture

      '' Change culture and calendar (HijriCalendar)
      'Dim arabCulture As New CultureInfo("ar-AE")
      'arabCulture.DateTimeFormat.Calendar = New HijriCalendar()
      'System.Threading.Thread.CurrentThread.CurrentCulture = arabCulture

      '' Change culture and calendar (KoreanCalendar)
      'Dim koreanCulture As New CultureInfo("ko-KR")
      'koreanCulture.DateTimeFormat.Calendar = New KoreanCalendar()
      'System.Threading.Thread.CurrentThread.CurrentCulture = koreanCulture

      '' Change culture and calendar (ThaiBuddhistCalendar)
      'Dim thaiCulture As New CultureInfo("th-TH")
      'thaiCulture.DateTimeFormat.Calendar = New ThaiBuddhistCalendar()
      'System.Threading.Thread.CurrentThread.CurrentCulture = thaiCulture

      '' Change culture and calendar (TaiwanCalendar)
      'Dim taiwanCulture As New CultureInfo("zh-TW")
      'taiwanCulture.DateTimeFormat.Calendar = New TaiwanCalendar()
      'System.Threading.Thread.CurrentThread.CurrentCulture = taiwanCulture

      ' Add label to status bar.
      label = New ToolStripStatusLabel()
      StatusBar.Items.AddRange(New ToolStripItem() {label})

      ' Get strings for window.
      Me.Text = My.Resources.WindowTitle
      Me.CalendarLabel.Text = My.Resources.CalendarLabel
      Me.YearsLabel.Text = My.Resources.YearLabel
      Me.RuleGroup.Text = My.Resources.RuleLabel
      Me.DayOfWeekLabel.Text = My.Resources.FirstDayOfWeekLabel
      Me.WeekRangeLabel.Text = My.Resources.ResultText
      Me.Calculate.Text = My.Resources.ButtonText
      Me.WeekRangeLabel.Text = My.Resources.WeekRangeLabel
      Me.EraLabel.Text = My.Resources.EraLabel
      Me.FirstDay.Text = My.Resources.FirstDay
      Me.FirstFullWeek.Text = My.Resources.FirstFullWeek
      Me.FirstFourDayWeek.Text = My.Resources.FirstFourDayWeek

      ' Initialize list of calendars using reflection.
      Dim assem As Assembly = Assembly.GetAssembly(GetType(Calendar))
      Dim types() As Type = assem.GetExportedTypes()
      Dim calendars() As Type = Array.FindAll(types, AddressOf Utility.IsValidCalendar)
      Array.Sort(calendars, New CalendarComparer())

      For Each cal In calendars
         Dim calendarName As String = Utility.GetProperName(cal)
         If calendarName IsNot Nothing Then
            Me.CalendarsList.Items.Add(calendarName)
            If (CultureInfo.CurrentCulture.Calendar.ToString().Contains(cal.Name)) Then
               Me.CalendarsList.SelectedIndex = Me.CalendarsList.Items.Count - 1
            End If
         End If
      Next

      ' Set selected calendar week rule.
      For Each ctrl In RuleGroup.Controls
         Dim rb As RadioButton = DirectCast(ctrl, RadioButton)
         If DateTimeFormatInfo.CurrentInfo.CalendarWeekRule.ToString().Equals(rb.Name) Then
            rb.Checked = True
         Else
            DirectCast(RuleGroup.Controls(0), RadioButton).Checked = True
         End If
      Next

      ' Initialize days of week.
      For Each dayOfWeek In [Enum].GetNames(GetType(DayOfWeek))
         Me.DayOfWeekList.Items.Add(dayOfWeek)
      Next
      Me.DayOfWeekList.SelectedIndex = 0
   End Sub

   Private Sub Calculate_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Calculate.Click
      ' Clear the text box with week ranges.
      Me.WeekRanges.Clear()

      ' Get calendar name and instantiate calendar
      Dim calName As String = CStr(Me.CalendarsList.SelectedItem).Replace(" ", String.Empty)
      Dim fullCalName As String = "System.Globalization." + calName + "Calendar"
      Dim assem As Assembly = Assembly.GetAssembly(GetType(Calendar))
      Dim cal As Calendar
      Dim adjustedRange As String = String.Empty

      ' If both selected calendar and current culture's calendar are Gregorian, use the current culture's
      If (fullCalName.Contains("Gregorian") And DateTimeFormatInfo.CurrentInfo.Calendar.ToString().Contains("Gregorian")) Then
         cal = DateTimeFormatInfo.CurrentInfo.Calendar
      Else
         cal = DirectCast(assem.CreateInstance(fullCalName), Calendar)
      End If

      ' Is the selected calendar also the current calendar?
      Dim usingDefaultCalendar As Boolean
      If fullCalName.Equals(DateTimeFormatInfo.CurrentInfo.Calendar) Then
         usingDefaultCalendar = True
      Else
         usingDefaultCalendar = False
      End If

      ' Get selected calendar week rule.
      Dim rule As CalendarWeekRule = 0
      For Each ctrl As Control In RuleGroup.Controls
         Dim rdo As RadioButton = TryCast(ctrl, RadioButton)
         If rdo Is Nothing Then Continue For
         If rdo.Checked Then
            rule = DirectCast([Enum].Parse(GetType(CalendarWeekRule), rdo.Name), CalendarWeekRule)
            Exit For
         End If
      Next

      ' Get first day of week.
      Dim firstDay As DayOfWeek = DirectCast([Enum].Parse(GetType(DayOfWeek), CStr(Me.DayOfWeekList.SelectedItem)), DayOfWeek)

      ' Parse selected year.
      Dim startYear As Integer = 0
      If Me.YearsList.SelectedIndex = -1 Then
         Try
            startYear = Int32.Parse(Me.YearsList.Text)
         Catch ex As FormatException
            label.Text = My.Resources.MSG_YearFormat
            Return
         Catch ex As ArgumentNullException
            label.Text = My.Resources.MSG_YearEmpty
            Return
         Catch ex As OverflowException
            label.Text += My.Resources.MSG_YearOutOfRange
            Return
         End Try
      Else
         startYear = CInt(Me.YearsList.SelectedItem)
      End If

      Dim era As Integer
      Dim japanese As Boolean = False
      Dim startDate, endDate As Date
      Dim adjusted As Boolean

      ' If this is a Japanese calendar, get the era.
      If calName.Contains("Japanese") Then
         japanese = True
         Dim eraName As String = CStr(Me.ErasList.SelectedItem)
         era = CInt([Enum].Parse(GetType(JapaneseEras), eraName, True))
      End If

      ' Determine if year is in range of the calendar
      If japanese Then
         ' The complication here is that the year without the era is ambiguous, so we can't tell whether it is in
         ' the calendar's range without attempting to instantiate a DateTime object for that year and era.
         Try
            ' If calendar is JapaneseCalendar and era is 1, then use minimum date, since it starts in month 9.
            If era = JapaneseEras.Meiji And startYear = 1 Then
               startDate = cal.ToDateTime(startYear, 9, 8, 0, 0, 0, 0, era)
               ' Use hard-coded start dates for other Japanese calender eras.
            ElseIf era = JapaneseEras.Taisho And startYear = 1 Then
               startDate = cal.ToDateTime(startYear, 7, 30, 0, 0, 0, 0, era)
            ElseIf era = JapaneseEras.Showa And startYear = 1 Then
               startDate = cal.ToDateTime(startYear, 12, 25, 0, 0, 0, 0, era)
            ElseIf era = JapaneseEras.Heisei And startYear = 1 Then
               startDate = cal.ToDateTime(startYear, 1, 8, 0, 0, 0, 0, era)
            Else
               startDate = cal.ToDateTime(startYear, 1, 1, 0, 0, 0, 0, era)
            End If
            endDate = cal.ToDateTime(startYear, cal.GetMonthsInYear(startYear), cal.GetDaysInMonth(startYear, cal.GetMonthsInYear(startYear)), 0, 0, 0, 0, era)
         Catch ex As ArgumentOutOfRangeException
            label.Text = My.Resources.MSG_YearOutOfRange
            Return
         End Try
      Else
         If (startYear < cal.GetYear(cal.MinSupportedDateTime) Or startYear > cal.GetYear(cal.MaxSupportedDateTime)) Then
            label.Text = My.Resources.MSG_YearOutOfRange
            Return
         End If

         Dim currentCal As Calendar = DateTimeFormatInfo.CurrentInfo.Calendar

         ' Is selected calendar the current culture's calendar?
         If usingDefaultCalendar Then
            startDate = New DateTime(startYear, 1, 1)
            endDate = New DateTime(startYear, currentCal.GetMonthsInYear(startYear),
                                            currentCal.GetDaysInMonth(startYear, currentCal.GetMonthsInYear(startYear)))
         Else
            ' Handle non-current calendar.
            If cal.GetYear(cal.MinSupportedDateTime) = startYear Then
               If Utility.StartDates.ContainsKey(calName) Then
                  startDate = Utility.StartDates.Item(calName)
                  adjusted = True
                  ' Readjust starting year in the event that it is a new year.
                  startYear = cal.GetYear(startDate)
               Else
                  startDate = cal.MinSupportedDateTime
                  adjusted = True
               End If
            Else
               startDate = New DateTime(startYear, 1, 1, 0, 0, 0, cal)
            End If

            If cal.GetYear(cal.MaxSupportedDateTime) = startYear Then
               endDate = cal.MaxSupportedDateTime.Date
               adjusted = True
            Else
               Dim nMonths As Integer = cal.GetMonthsInYear(startYear)
               endDate = New DateTime(startYear, nMonths, cal.GetDaysInMonth(startYear, nMonths), cal)
            End If
         End If

         If adjusted Then
            adjustedRange = String.Format(My.Resources.MSG_AdjustedRange,
                                          cal.GetMonth(startDate), cal.GetYear(startDate),
                                          cal.GetMonth(endDate), cal.GetYear(endDate))
         End If
      End If

      Dim thisWeek As Integer = 0
      Dim currentWeek As Integer = 0
      Dim thisEra As Integer = 0

      Dim thisDay As DateTime = startDate
      Dim output As String = Nothing
      Do
         ' Some calendars throw ArgumentOutOfRangeException even if the date is valid but in the early part of the
         ' calendar's date range. Handle this by ignoring it.
         Try
            ' Get the week of the year for this date.
            thisWeek = cal.GetWeekOfYear(thisDay, rule, firstDay)

            ' If this is a Japanese calendar, get the era.
            If japanese Then thisEra = cal.GetEra(thisDay)

            ' Output the end of week date if the week number or the era (for Japanese calendars) has changed 
            If thisWeek <> currentWeek Or thisDay = endDate Or era <> thisEra Then

               If currentWeek > 0 Then
                  If thisDay <> endDate Then
                     If usingDefaultCalendar Then
                        output += String.Format("{0:d}", thisDay.AddDays(-1)) + Environment.NewLine
                     Else
                        output += Utility.GetNonDefaultCalendarDate(thisDay.AddDays(-1), cal) + Environment.NewLine
                     End If
                  Else
                     If (usingDefaultCalendar) Then
                        output += String.Format("{0:d}", thisDay) + Environment.NewLine
                     Else
                        output += Utility.GetNonDefaultCalendarDate(thisDay, cal) + Environment.NewLine
                     End If
                  End If
                  WeekRanges.Text += output
               End If

               currentWeek = thisWeek
               If (usingDefaultCalendar) Then
                  output = String.Format("{0,3}: {1,10:d} - ", currentWeek, thisDay)
               Else
                  output = String.Format("{0,3}: {1,10:d} - ", currentWeek, Utility.GetNonDefaultCalendarDate(thisDay, cal))
               End If
            End If
         Catch ex As ArgumentOutOfRangeException
            label.Text = My.Resources.MSG_Exception
         End Try

         Try
            ' Make sure that we're not adding a day beyond the calendar range.
            thisDay = thisDay.AddDays(1)
         Catch ex As ArgumentOutOfRangeException
            Exit Do
         End Try
         ' Exit if the era for a Japanese calendar has changed. 
         If era <> thisEra Then Exit Do
      Loop While thisDay <= endDate
      If adjusted Then
         label.Text = adjustedRange
      End If
   End Sub

   Private Sub YearsList_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles YearsList.SelectedIndexChanged
      label.Text = New String(" "c, label.Text.Length)
   End Sub

   Private Sub CalendarsList_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CalendarsList.SelectedIndexChanged
      Dim calName As String = CStr(Me.CalendarsList.SelectedItem).Replace(" ", String.Empty)

      Me.WeekRanges.Text = ""

      If calName.Contains("Japanese") Then
         PopulateEras(calName)
         Me.EraLabel.Visible = True
         Me.ErasList.Visible = True
      Else
         Me.EraLabel.Hide()
         Me.ErasList.Hide()
      End If
      Me.PopulateYears(calName)
   End Sub

   Private Sub PopulateYears(ByVal calName As String)
      ' Get calendar name.
      calName = "System.Globalization." + calName + "Calendar"
      If DateTimeFormatInfo.CurrentInfo.Calendar.ToString().Contains(calName) Then
         PopulateYears(True, calName)
      Else
         PopulateYears(False, calName)
      End If
   End Sub

   Private Sub PopulateEras(ByVal calName As String)
      Me.ErasList.Items.Clear()

      Dim eras() As String = [Enum].GetNames(GetType(JapaneseEras))
      Array.Sort([Enum].GetValues(GetType(JapaneseEras)), eras)

      For ctr As Integer = eras.GetLowerBound(0) To eras.GetUpperBound(0)
         ' There are only two eras in the JapaneseLunisolarCalendar.
         If calName.Contains("Lunisolar") And ctr < JapaneseLunisolarEras Then Continue For

         Me.ErasList.Items.Add(eras(ctr))
      Next

      If Not calName.Contains("Lunisolar") Then
         Me.ErasList.SelectedIndex = (New JapaneseCalendar).Eras(JapaneseCalendar.CurrentEra) - 1
      Else
         Me.ErasList.SelectedIndex = JapaneseLunisolarCalendar.JapaneseEra
      End If
   End Sub

   Private Sub PopulateYears(ByVal currentCalendar As Boolean, ByVal calName As String)
      Me.YearsList.Items.Clear()
      Me.YearsList.Text = ""

      Dim cal As Calendar
      If currentCalendar Then
         cal = CultureInfo.CurrentCulture.DateTimeFormat.Calendar
      Else
         Dim calendarAssembly As Assembly = Assembly.GetAssembly(GetType(Calendar))
         cal = CType(calendarAssembly.CreateInstance(calName), Calendar)
      End If

      If Not calName.Contains("Japanese") Then
         For ctr As Integer = cal.GetYear(DateTime.Now) - 20 To cal.GetYear(DateTime.Now)
            Me.YearsList.Items.Add(ctr)
         Next
         '      End If
      Else
         For ctr As Integer = cal.GetYear(DateTime.Now) - 20 To cal.GetYear(DateTime.Now)
            Dim dateToAdd As New Date(ctr, 1, 1, cal)
            If calName.Contains("Lunisolar") Then
               If cal.GetEra(dateToAdd) = cal.Eras(JapaneseLunisolarCalendar.CurrentEra) Then
                  Me.YearsList.Items.Add(cal.GetYear(dateToAdd))
               End If
            Else
               If cal.GetEra(dateToAdd) = cal.Eras(JapaneseCalendar.CurrentEra) Then
                  Me.YearsList.Items.Add(cal.GetYear(dateToAdd))
               End If
            End If
         Next
      End If

      Me.YearsList.SelectedIndex = Me.YearsList.Items.Count - 1
   End Sub

   Private Sub YearsList_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles YearsList.TextChanged
      Me.WeekRanges.Text = ""
      label.Text = New String(" "c, label.Text.Length)
   End Sub

End Class
