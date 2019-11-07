using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using System.Text.RegularExpressions;

public enum JapaneseEras 
{
   Heisei = 4,
   Showa = 3,
   Taisho = 2,
   Meiji = 1,
}

public class CalendarComparer : IComparer
{
   public int Compare(object x, object y)
   {
      Type tX = x as Type;
      Type tY = y as Type;

      return tX.Name.CompareTo(tY.Name);
   }
}

internal static class Utility
{
   internal static Dictionary<string, DateTime> StartDates;

   static Utility() {
      StartDates = new Dictionary<string, DateTime>();
      StartDates.Add("Hebrew", new DateTime(1583, 9, 17));
   }

   internal static bool IsValidCalendar(Type t)
   {

      if (t.ToString().EndsWith("Calendar"))
         if (t.IsAbstract)
            return false;
         else
            return true;
      else
         return false;
   }

   internal static string GetProperName(Type calendarType)
   {
      return Regex.Replace(calendarType.Name, @"(\p{Lu}\p{Ll}+)(\p{Lu}\p{Ll}+)*(Calendar)", AddSpaces);
   }

   internal static string AddSpaces(Match m)
   {
      if (m.Groups[2].Captures.Count <= 1)
      {
         return m.Groups[1] + " " + m.Groups[2];
      }
      else
      {
         string name = m.Groups[1].Value;
         foreach (Capture capture in m.Groups[2].Captures)
            name += " " + capture.Value;
         return name;
      }
   }

   internal static string GetNonDefaultCalendarDate(DateTime date, Calendar cal)
   {
      return String.Format(@"{0:d2}/{1:d2}/{2:d4}", cal.GetMonth(date), cal.GetDayOfMonth(date), cal.GetYear(date));
   }
}

