using System;
using System.Collections;
using System.Globalization;
using System.Reflection;
using System.Resources;
using System.Windows.Forms;

public partial class Form1 : Form
{
   private ResourceManager rm;

   private const int JapaneseLunisolarEras = 2;
   ToolStripStatusLabel label;

   public Form1()
   {
      InitializeComponent();
   }

   private void Form1_Load(object sender, EventArgs e)
   {
      // To test the application//s behavior with a different current calendar other than Gregorian, 
      // uncomment the respective code block.
      //
      // Change culture and calendar (JapaneseCalendar)
      // CultureInfo japaneseCulture = new CultureInfo("ja-JP");
      // japaneseCulture.DateTimeFormat.Calendar = new JapaneseCalendar();
      // System.Threading.Thread.CurrentThread.CurrentCulture = japaneseCulture;

      // Change culture and calendar (HebrewCalendar)
      // CultureInfo hebrewCulture = new CultureInfo("he-IL");
      // hebrewCulture.DateTimeFormat.Calendar = new HebrewCalendar();
      // System.Threading.Thread.CurrentThread.CurrentCulture = hebrewCulture;

      // Change culture and calendar (UmALQuraCalendar)
      // CultureInfo arabCulture = new CultureInfo("ar-AE");
      // arabCulture.DateTimeFormat.Calendar = new UmAlQuraCalendar();
      // System.Threading.Thread.CurrentThread.CurrentCulture = arabCulture;

      // Change culture and calendar (HijriCalendar)
      // CultureInfo arabCulture = new CultureInfo("ar-AE");
      // arabCulture.DateTimeFormat.Calendar = new HijriCalendar();
      // System.Threading.Thread.CurrentThread.CurrentCulture = arabCulture;

      // Change culture and calendar (KoreanCalendar)
      // CultureInfo koreanCulture = new CultureInfo("ko-KR");
      // koreanCulture.DateTimeFormat.Calendar = new KoreanCalendar();
      // System.Threading.Thread.CurrentThread.CurrentCulture = koreanCulture;

      // Change culture and calendar (ThaiBuddhistCalendar)
      // CultureInfo thaiCulture = new CultureInfo("th-TH");
      // thaiCulture.DateTimeFormat.Calendar = new ThaiBuddhistCalendar();
      // System.Threading.Thread.CurrentThread.CurrentCulture = thaiCulture;

      // Change culture and calendar (TaiwanCalendar)
      // CultureInfo taiwanCulture = new CultureInfo("zh-TW");
      // taiwanCulture.DateTimeFormat.Calendar = new TaiwanCalendar();
      // System.Threading.Thread.CurrentThread.CurrentCulture = taiwanCulture;

      // Instantiate Resource Manager.
      rm = new ResourceManager("WeekRange.Resources", Assembly.GetExecutingAssembly());

            // Add label to status bar.
      label = new ToolStripStatusLabel();
      ToolStripItem[] items = { label };
      this.StatusBar.Items.AddRange( items);

      // Get strings for window.
      this.Text = rm.GetString("WindowTitle");
      this.CalendarLabel.Text = rm.GetString("CalendarLabel");
      this.YearsLabel.Text = rm.GetString("YearLabel");
      this.RuleGroup.Text = rm.GetString("RuleLabel");
      this.DayOfWeekLabel.Text = rm.GetString("FirstDayOfWeekLabel");
      this.WeekRangeLabel.Text = rm.GetString("ResultText");
      this.Calculate.Text = rm.GetString("ButtonText");
      this.WeekRangeLabel.Text = rm.GetString("WeekRangeLabel");
      this.EraLabel.Text = rm.GetString("EraLabel");
      this.FirstDay.Text = rm.GetString("FirstDay");
      this.FirstFullWeek.Text = rm.GetString("FirstFullWeek");
      this.FirstFourDayWeek.Text = rm.GetString("FirstFourDayWeek");

      // Initialize list of calendars using reflection.
      Assembly assem = Assembly.GetAssembly(typeof(Calendar));
      Type[] types = assem.GetExportedTypes();
      Type[] calendars = Array.FindAll(types, Utility.IsValidCalendar);
      Array.Sort(calendars, new CalendarComparer());

      foreach (var cal in calendars) {
         string calendarName = Utility.GetProperName(cal);
         if (calendarName != null) {
            this.CalendarsList.Items.Add(calendarName);
            if (CultureInfo.CurrentCulture.Calendar.ToString().Contains(cal.Name))
               this.CalendarsList.SelectedIndex = this.CalendarsList.Items.Count - 1;
         }
      }

      // Set selected calendar week rule.
      foreach (var ctrl in RuleGroup.Controls) {
         RadioButton rb = (RadioButton) ctrl;
         if (DateTimeFormatInfo.CurrentInfo.CalendarWeekRule.ToString().Equals(rb.Name))
            rb.Checked = true;
         else
            ((RadioButton) RuleGroup.Controls[0]).Checked = true;
      }

      // Initialize days of week.
      foreach (var dayOfWeek in Enum.GetNames(typeof(DayOfWeek)))
         this.DayOfWeekList.Items.Add(dayOfWeek);

      this.DayOfWeekList.SelectedIndex = 0;
   }

   private void Calculate_Click(object sender, EventArgs e)
   {
      // Clear the text box with week ranges.
      this.WeekRanges.Clear();

      // Get calendar name and instantiate calendar
      string calName = ((string) this.CalendarsList.SelectedItem).Replace(" ", String.Empty);
      string fullCalName = "System.Globalization." + calName + "Calendar";
      Assembly assem = Assembly.GetAssembly(typeof(Calendar));
      Calendar cal;
      string adjustedRange = String.Empty;

      // If both selected calendar and current culture's calendar are Gregorian, use the current culture's
      if (fullCalName.Contains("Gregorian") && DateTimeFormatInfo.CurrentInfo.Calendar.ToString().Contains("Gregorian"))
         cal = DateTimeFormatInfo.CurrentInfo.Calendar;
      else
         cal = (Calendar) assem.CreateInstance(fullCalName);

      // Is the selected calendar also the current calendar?
      bool usingDefaultCalendar;
      if (fullCalName.Equals(DateTimeFormatInfo.CurrentInfo.Calendar))
         usingDefaultCalendar = true;
      else
         usingDefaultCalendar = false;

      // Get selected calendar week rule.
      CalendarWeekRule rule = 0;
      foreach (Control ctrl in RuleGroup.Controls)
      {
         RadioButton rdo = ctrl as RadioButton;
         if (rdo == null) continue;
         if (rdo.Checked) {
            rule = (CalendarWeekRule) Enum.Parse(typeof(CalendarWeekRule), rdo.Name);
            break;
         }
      }

      // Get first day of week.
      DayOfWeek firstDay = (DayOfWeek) Enum.Parse(typeof(DayOfWeek), (string) this.DayOfWeekList.SelectedItem);

      // Parse selected year.
      int startYear = 0;
      if (this.YearsList.SelectedIndex == -1)
      {
         try {
            startYear = Int32.Parse(this.YearsList.Text);
         }
         catch (FormatException) {
            label.Text = rm.GetString("MSG_YearFormat");
            return;
         }
         catch (ArgumentNullException) {
            label.Text = rm.GetString("MSG_YearEmpty"); 
            return;
         }
         catch (OverflowException) {
            label.Text = rm.GetString("MSG_YearOutOfRange");
            return;
         }
      }
      else
      {
         startYear = (int) this.YearsList.SelectedItem;
      }

      int era = 0;
      bool japanese = false;
      DateTime startDate, endDate;
      bool adjusted = false;

      // If this is a Japanese calendar, get the era.
      if (calName.Contains("Japanese")) {
         japanese = true;
         string eraName = (string) this.ErasList.SelectedItem;
         era = (int) Enum.Parse(typeof(JapaneseEras), eraName, true);
      }
      
      // Determine if year is in range of the calendar
      if (japanese) {
         // The complication here is that the year without the era is ambiguous, so we can't tell whether it is in
         // the calendar's range without attempting to instantiate a DateTime object for that year and era.
         try {
            // If calendar is JapaneseCalendar and era is 1, then use minimum date, since it starts in month 9.
            if (((JapaneseEras) era) == JapaneseEras.Meiji & startYear == 1)
               startDate = cal.ToDateTime(startYear, 9, 8, 0, 0, 0, 0, era);
               // Use hard-coded start dates for other Japanese calender eras.
            else if (((JapaneseEras) era) == JapaneseEras.Taisho & startYear == 1)
               startDate = cal.ToDateTime(startYear, 7, 30, 0, 0, 0, 0, era);
            else if (((JapaneseEras) era) == JapaneseEras.Showa & startYear == 1)
               startDate = cal.ToDateTime(startYear, 12, 25, 0, 0, 0, 0, era);
            else if (((JapaneseEras) era) == JapaneseEras.Heisei & startYear == 1)
               startDate = cal.ToDateTime(startYear, 1, 8, 0, 0, 0, 0, era);
            else
               startDate = cal.ToDateTime(startYear, 1, 1, 0, 0, 0, 0, era);

            endDate = cal.ToDateTime(startYear, cal.GetMonthsInYear(startYear), cal.GetDaysInMonth(startYear, cal.GetMonthsInYear(startYear)), 0, 0, 0, 0, era);
         }
         catch (ArgumentOutOfRangeException) {
            label.Text = rm.GetString("MSG_YearOutOfRange");
            return;
         }
      }
      else
      {
         if (startYear < cal.GetYear(cal.MinSupportedDateTime) | startYear > cal.GetYear(cal.MaxSupportedDateTime))
         {
            label.Text = rm.GetString("MSG_YearOutOfRange");
            return;
         }

         Calendar currentCal = DateTimeFormatInfo.CurrentInfo.Calendar;
          
         // Is selected calendar the current culture's calendar?
         if (usingDefaultCalendar) {
            startDate = new DateTime(startYear, 1, 1);
            endDate = new DateTime(startYear, currentCal.GetMonthsInYear(startYear),
                                   currentCal.GetDaysInMonth(startYear, currentCal.GetMonthsInYear(startYear)));
         }
         else {
            // Handle non-current calendar.
            if (cal.GetYear(cal.MinSupportedDateTime) == startYear) {
               if (Utility.StartDates.ContainsKey(calName)) {
                  startDate = Utility.StartDates[calName];
                  adjusted = true;
                  // Readjust starting year in the event that it is a new year.
                  startYear = cal.GetYear(startDate);
               }
               else {
                  startDate = cal.MinSupportedDateTime;
                  adjusted = true;
               }
            }
            else {
               startDate = new DateTime(startYear, 1, 1, 0, 0, 0, cal);
            }

            if (cal.GetYear(cal.MaxSupportedDateTime) == startYear) {
               endDate = cal.MaxSupportedDateTime.Date;
               adjusted = true;
            }
            else {
               int nMonths = cal.GetMonthsInYear(startYear);
               endDate = new DateTime(startYear, nMonths, cal.GetDaysInMonth(startYear, nMonths), cal);
            }
         }

         if (adjusted) 
            adjustedRange = String.Format(rm.GetString("MSG_AdjustedRange"),
                                          cal.GetMonth(startDate), cal.GetYear(startDate),
                                          cal.GetMonth(endDate), cal.GetYear(endDate));
      }

      int thisWeek = 0;
      int currentWeek = 0;
      int thisEra = 0;

      DateTime thisDay = startDate;
      string output = null;

      do {
         // Some calendars throw ArgumentOutOfRangeException even if the date is valid but in the early part of the
         // calendar's date range. Handle this by ignoring it.
         try {
            // Get the week of the year for this date.
            thisWeek = cal.GetWeekOfYear(thisDay, rule, firstDay);

            // If this is a Japanese calendar, get the era.
            if (japanese) thisEra = cal.GetEra(thisDay);

            // Output the end of week date if the week number or the era (for Japanese calendars) has changed 
            if (thisWeek != currentWeek || thisDay == endDate || era != thisEra) {
               if (currentWeek > 0) {
                  if (thisDay != endDate)
                     if (usingDefaultCalendar)
                        output += String.Format("{0:d}", thisDay.AddDays(-1)) + Environment.NewLine;
                     else
                        output += Utility.GetNonDefaultCalendarDate(thisDay.AddDays(-1), cal) + Environment.NewLine;
                  else
                     if (usingDefaultCalendar) 
                        output += String.Format("{0:d}", thisDay) + Environment.NewLine;
                     else
                        output += Utility.GetNonDefaultCalendarDate(thisDay, cal) + Environment.NewLine;

                  WeekRanges.Text += output;
               }

               currentWeek = thisWeek;
               if (usingDefaultCalendar) 
                  output = String.Format("{0,3}: {1,10:d} - ", currentWeek, thisDay);
               else
                  output = String.Format("{0,3}: {1,10:d} - ", currentWeek, Utility.GetNonDefaultCalendarDate(thisDay, cal));
            }
         }
         catch (ArgumentOutOfRangeException) {
            label.Text = rm.GetString("MSG_Exception");
         }

         try {
            // Make sure that we're not adding a day beyond the calendar range.
            thisDay = thisDay.AddDays(1);
         }
         catch (ArgumentOutOfRangeException) {
            break;
         }
         // Exit if the era for a Japanese calendar has changed. 
         if (era != thisEra) break;
      } while (thisDay <= endDate);

      if (adjusted)
         label.Text = adjustedRange;
   }

   private void YearsList_SelectedIndexChanged(object sender, EventArgs e)
   {
      label.Text = new String(' ', label.Text.Length); 
   }

   private void YearsList_TextChanged(object sender , EventArgs e )
   {
      this.WeekRanges.Text = "";
      label.Text = new String(' ', label.Text.Length);
    }

   private void CalendarsList_SelectedIndexChanged(object sender, EventArgs e)
   {
      string calName = ((string) this.CalendarsList.SelectedItem).Replace(" ", String.Empty);

      this.WeekRanges.Text = "";

      if (calName.Contains("Japanese")) {
         PopulateEras(calName);
         this.EraLabel.Visible = true;
         this.ErasList.Visible = true;
      }
      else {
         this.EraLabel.Hide();
         this.ErasList.Hide();
      }
      this.PopulateYears(calName);
   }

   private void PopulateEras(string calName )
   {
      this.ErasList.Items.Clear();

      string[] eras = Enum.GetNames(typeof(JapaneseEras));
      Array.Sort(Enum.GetValues(typeof(JapaneseEras)), eras);

      for (int ctr = eras.GetLowerBound(0); ctr <= eras.GetUpperBound(0); ctr++) {
         // There are only two eras in the JapaneseLunisolarCalendar.
         if (calName.Contains("Lunisolar") & (ctr < JapaneseLunisolarEras)) continue;

         this.ErasList.Items.Add(eras[ctr]);
      }

      if (! calName.Contains("Lunisolar"))
         this.ErasList.SelectedIndex = (new JapaneseCalendar()).Eras[JapaneseCalendar.CurrentEra] - 1;
      else
         this.ErasList.SelectedIndex = JapaneseLunisolarCalendar.JapaneseEra;
      }

   private void PopulateYears(string calName)
   {
      // Get calendar name.
      calName = "System.Globalization." + calName + "Calendar";
      if (DateTimeFormatInfo.CurrentInfo.Calendar.ToString().Contains(calName))
         PopulateYears(true, calName);
      else
         PopulateYears(false, calName);

   }
   
   private void PopulateYears(bool currentCalendar, string calName)
   {
      this.YearsList.Items.Clear();
      this.YearsList.Text = "";

      Calendar cal;
      if (currentCalendar) {
         cal = CultureInfo.CurrentCulture.DateTimeFormat.Calendar;
      }
      else {
         Assembly calendarAssembly = Assembly.GetAssembly(typeof(Calendar));
         cal = (Calendar) calendarAssembly.CreateInstance(calName);
      }

      if (! calName.Contains("Japanese")) {
         for (int ctr = cal.GetYear(DateTime.Now) - 20; ctr <= cal.GetYear(DateTime.Now); ctr++)
            this.YearsList.Items.Add(ctr);
      }
      else {
         for (int ctr = cal.GetYear(DateTime.Now) - 20; ctr <= cal.GetYear(DateTime.Now); ctr++) {
            DateTime dateToAdd = new DateTime(ctr, 1, 1, cal);
            if (calName.Contains("Lunisolar")) {
               if (cal.GetEra(dateToAdd) == cal.Eras[JapaneseLunisolarCalendar.CurrentEra])
                  this.YearsList.Items.Add(cal.GetYear(dateToAdd));
            }
            else {
               if (cal.GetEra(dateToAdd) == cal.Eras[JapaneseCalendar.CurrentEra])
                  this.YearsList.Items.Add(cal.GetYear(dateToAdd));
            }
         }
      }

      this.YearsList.SelectedIndex = this.YearsList.Items.Count - 1;
    }
}
