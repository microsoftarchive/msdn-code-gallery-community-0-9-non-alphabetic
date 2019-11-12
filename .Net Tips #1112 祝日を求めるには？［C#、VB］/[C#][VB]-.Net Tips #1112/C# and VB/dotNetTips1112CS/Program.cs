using System;
using System.Collections.Generic;
using System.Linq;

namespace dotNetTips1112CS
{
  public enum HolidayKind
  { 
    平日 = 0,
    国民の祝日 = 1,
    振替休日 = 2,
    国民の休日 = 3,
  }

  public class Holiday
  {
    public DateTime Date { get; set; }
    public HolidayKind Kind { get; set; }
    public string Name { get; set; }
    public string Definition { get; set; }
  }


  class Program
  {
    // 指定月の第N月曜日を求める
    private static DateTime GetNthMonday(int nth, int year, int month)
    {
      // 指定された月の日数
      int days = DateTime.DaysInMonth(year, month);

      // 指定された月の全ての日から、月曜日だけを取り出す
      IEnumerable<DateTime> allMondays
        = Enumerable.Range(1, days) // 1～月末の日付（int型のコレクション）を
            .Select(d => new DateTime(year, month, d)) // DateTime型のコレクションに変換して
            .Where(dt => dt.DayOfWeek == DayOfWeek.Monday); // そこから月曜日だけを取り出す

      // N番目の月曜日を求める
      return allMondays.ElementAt(nth - 1);
    }

    // 春分日を求める（2099年まで有効な実験式）
    private static DateTime CalcVernalEquinoxDay(int year)
    {
      // １．2000年の太陽の春分点通過日
      double 基準日 = 20.69115;

      // ２．春分点通過日の移動量＝（西暦年－2000年）×0.242194
      double 移動量 = (year - 2000) * 0.242194;

      // ３．閏年によるリセット量＝INT｛（西暦年－2000年）/ 4｝
      int 閏年補正 = (int)((year - 2000) / 4.0);

      // 求める年の春分日＝INT｛（１）＋（２）－（３）｝
      int 春分日 = (int)(基準日 + 移動量 - 閏年補正);

      return new DateTime(year, 3, 春分日);
    }

    // 秋分日を求める（2099年まで有効な実験式）
    private static DateTime CalcAutumnalEquinoxDay(int year)
    {
      // １．2000年の太陽の秋分点通過日
      double 基準日 = 23.09; // 秋分点の揺らぎ補正済みの値

      // ２．秋分点通過日の移動量＝（西暦年－2000年）×0.242194
      double 移動量 = (year - 2000) * 0.242194;

      // ３．閏年によるリセット量＝INT｛（西暦年－2000年）/ 4｝
      int 閏年補正 = (int)((year - 2000) / 4.0);

      // 求める年の秋分日＝INT｛（１）＋（２）－（３）｝
      int 秋分日 = (int)(基準日 + 移動量 - 閏年補正);

      return new DateTime(year, 9, 秋分日);
    }

    // 振替休日を全て求める
    // 国民の祝日に関する法律 第3条2
    //「国民の祝日」が日曜日に当たるときは、その日後において
    // その日に最も近い「国民の祝日」でない日を休日とする。
    private static IEnumerable<Holiday> GetSubstituteHolidays(SortedDictionary<DateTime, Holiday> holidays)
    {
      List<Holiday> substituteHolidays = new List<Holiday>();

      foreach (var holiday in holidays.Values)
      {
        if (holiday.Date.DayOfWeek != DayOfWeek.Sunday)
          continue; // 日曜でなければ除外する

        // 翌日（＝月曜日）を仮に振替休日とする
        DateTime substitute = holiday.Date.AddDays(1.0);

        // その日がすでに祝日ならば振替休日はさらにその翌日
        while (holidays.ContainsKey(substitute))
          substitute = substitute.AddDays(1.0);

        // 見つかった振替休日をコレクションに追加する
        var substituteHoliday = new Holiday()
        {
          Date = substitute,
          Kind = HolidayKind.振替休日,
          Name = "振替休日",
          Definition = string.Format("{0}の振替休日", holiday.Name),
        };
        substituteHolidays.Add(substituteHoliday);
      }
      return substituteHolidays;
    }


    // 国民の休日を全て求める
    // 国民の祝日に関する法律 第3条3
    // その前日及び翌日が「国民の祝日」である日（「国民の祝日」でない日に限る。）は、休日とする。
    private static IEnumerable<Holiday> GetSandwichedHolidays(SortedDictionary<DateTime, Holiday> holidays)
    {
      List<Holiday> sandwichedHolidays = new List<Holiday>();

      foreach (var holiday0 in holidays.Values)
      {
        if (holiday0.Kind != HolidayKind.国民の祝日)
          continue; // その休日が国民の祝日でなければ除外する

        var day0 = holiday0.Date;

        var day2 = day0.AddDays(2.0); // 2日後
        if (!holidays.ContainsKey(day2))
          continue; // 2日後が祝日でないときは除外する
        var holiday2 = holidays[day2];
        if (holiday2.Kind != HolidayKind.国民の祝日)
          continue; // 2日後が祝日であっても国民の祝日でなければ除外する

        var day1 = day0.AddDays(1.0); // 1日後=国民の祝日で挟まれた日
        if (day1.DayOfWeek == DayOfWeek.Sunday)
          continue; // その日が日曜（＝もともと休日）のときは除外する
        if (holidays.ContainsKey(day1))
          continue; // その日がすでに祝日のときは除外する

        // 見つかった国民の休日をコレクションに追加する
        var sandwichedHoliday = new Holiday()
        {
          Date = day1,
          Kind = HolidayKind.国民の休日,
          Name = "国民の休日",
          Definition = string.Format("{0}と{1}の間の日", holiday0.Name, holiday2.Name),
        };
        sandwichedHolidays.Add(sandwichedHoliday);
      }
      return sandwichedHolidays;
    }





    static void Main(string[] args)
    {
      // 日本の祝日・休日の日付一覧
      // http://koyomi8.com/sub/syukujitsu_table.htm

      // 祝日を計算する年
      const int MinYear = 2007; // この年からみどりの日の実施と振替休日の変更
      const int MaxYear = 2099;
      int Year = 2015;
      if (args.Length > 0)
        int.TryParse(args[0], out Year);
      if (Year < MinYear || MaxYear < Year)
      {
        Console.WriteLine("計算可能な年は{0}から{1}までです", MinYear, MaxYear);
        return;
      }
      


      // 祝日を格納するコレクション
      SortedDictionary<DateTime, Holiday> holidays 
        = new SortedDictionary<DateTime, Holiday>();


      // 1. 日付けが固定の祝日
      // 国民の祝日に関する法律 第2条の一部
      // 建国記念の日となる日を定める政令

      //元日：1月1日 年のはじめを祝う。 
      var 元日 = new Holiday() 
                      { 
                        Date = new DateTime(Year, 1, 1), 
                        Kind = HolidayKind.国民の祝日, 
                        Name = "元日", Definition = "1月1日", 
                      };
      holidays.Add(元日.Date, 元日);

      //建国記念の日：2月11日
      //政令で定める日 建国をしのび、国を愛する心を養う。 
      var 建国記念の日 = new Holiday()
      {
        Date = new DateTime(Year, 2, 11),
        Kind = HolidayKind.国民の祝日,
        Name = "建国記念の日",
        Definition = "2月11日",
      };
      holidays.Add(建国記念の日.Date, 建国記念の日);

      //昭和の日：4月29日 激動の日々を経て、復興を遂げた昭和の時代を顧み、国の将来に思いをいたす。 
      var 昭和の日 = new Holiday()
      {
        Date = new DateTime(Year, 4, 29),
        Kind = HolidayKind.国民の祝日,
        Name = "昭和の日",
        Definition = "4月29日",
      };
      holidays.Add(昭和の日.Date, 昭和の日);

      //憲法記念日：5月3日 日本国憲法の施行を記念し、国の成長を期する。 
      var 憲法記念日 = new Holiday()
      {
        Date = new DateTime(Year, 5, 3),
        Kind = HolidayKind.国民の祝日,
        Name = "憲法記念日",
        Definition = "5月3日",
      };
      holidays.Add(憲法記念日.Date, 憲法記念日);

      //みどりの日：5月4日 自然に親しむとともにその恩恵に感謝し、豊かな心をはぐくむ。 
      var みどりの日 = new Holiday()
      {
        Date = new DateTime(Year, 5, 4),
        Kind = HolidayKind.国民の祝日,
        Name = "みどりの日",
        Definition = "5月4日",
      };
      holidays.Add(みどりの日.Date, みどりの日);

      //こどもの日：5月5日 こどもの人格を重んじ、こどもの幸福をはかるとともに、母に感謝する。 
      var こどもの日 = new Holiday()
      {
        Date = new DateTime(Year, 5, 5),
        Kind = HolidayKind.国民の祝日,
        Name = "こどもの日",
        Definition = "5月5日",
      };
      holidays.Add(こどもの日.Date, こどもの日);

      //山の日：8月11日 山に親しむ機会を得て、山の恩恵に感謝する。(2016年より) 
      if (2016 <= Year)
      {
        var 山の日 = new Holiday()
        {
          Date = new DateTime(Year, 8, 11),
          Kind = HolidayKind.国民の祝日,
          Name = "山の日",
          Definition = "8月11日",
        };
        holidays.Add(山の日.Date, 山の日);
      }
      // 注：この「山の日」のように、本来はすべての祝日について施行される年をチェックすべき。
      //     過去にさかのぼって適用する場合は必須。
      //     成人の日／敬老の日／体育の日（いずれも過去には固定日付だった）のように、
      //     定義が変更されることもある。

      //文化の日：11月3日 自由と平和を愛し、文化をすすめる。 
      var 文化の日 = new Holiday()
      {
        Date = new DateTime(Year, 11, 3),
        Kind = HolidayKind.国民の祝日,
        Name = "文化の日",
        Definition = "11月3日",
      };
      holidays.Add(文化の日.Date, 文化の日);

      //勤労感謝の日：11月23日 勤労をたっとび、生産を祝い、国民たがいに感謝しあう。 
      var 勤労感謝の日 = new Holiday()
      {
        Date = new DateTime(Year, 11, 23),
        Kind = HolidayKind.国民の祝日,
        Name = "勤労感謝の日",
        Definition = "11月23日",
      };
      holidays.Add(勤労感謝の日.Date, 勤労感謝の日);

      //天皇誕生日：12月23日 
      var 天皇誕生日 = new Holiday()
      {
        Date = new DateTime(Year, 12, 23),
        Kind = HolidayKind.国民の祝日,
        Name = "天皇誕生日",
        Definition = "12月23日",
      };
      holidays.Add(天皇誕生日.Date, 天皇誕生日);



      // 2. 日付けが「○月第△月曜日」のパターン
      // 国民の祝日に関する法律 第2条の一部

      //成人の日：1月の第2月曜日 おとなになったことを自覚し、みずから生き抜こうとする青年を祝いはげます。 
      var 成人の日 = new Holiday()
      {
        Date = GetNthMonday(2, Year, 1),
        Kind = HolidayKind.国民の祝日,
        Name = "成人の日",
        Definition = "1月の第2月曜日",
      };
      holidays.Add(成人の日.Date, 成人の日);

      //海の日：7月の第3月曜日 海の恩恵に感謝するとともに、海洋国日本の繁栄を願う。 
      var 海の日 = new Holiday()
      {
        Date = GetNthMonday(3, Year, 7),
        Kind = HolidayKind.国民の祝日,
        Name = "海の日",
        Definition = "7月の第3月曜日",
      };
      holidays.Add(海の日.Date, 海の日);

      //敬老の日：9月の第3月曜日 多年にわたり社会につくしてきた老人を敬愛し、長寿を祝う。 
      var 敬老の日 = new Holiday()
      {
        Date = GetNthMonday(3, Year, 9),
        Kind = HolidayKind.国民の祝日,
        Name = "敬老の日",
        Definition = "9月の第3月曜日",
      };
      holidays.Add(敬老の日.Date, 敬老の日);

      //体育の日：10月の第2月曜日 スポーツにしたしみ、健康な心身をつちかう。 
      var 体育の日 = new Holiday()
      {
        Date = GetNthMonday(2, Year, 10),
        Kind = HolidayKind.国民の祝日,
        Name = "体育の日",
        Definition = "10月の第2月曜日",
      };
      holidays.Add(体育の日.Date, 体育の日);



      // 3. 春分の日と秋分の日
      // 国民の祝日に関する法律 第2条の一部
      //
      // 公式には前年の2月の官報で発表される。
      //
      // ここでは西暦2099年まで合っているとされる実験式を使う。 http://koyomi8.com/reki_doc/doc_0330.htm
      //１．2000年の太陽の春分点通過日
      //3月20.69115日
      //例．20.69115　（これは、期間中変化しません）
      //２．１年ごとの春分点通過日の移動量
      //（西暦年－2000年）×0.242194　（日）
      //例．(2010 - 2000) × 0.242194 = 2.42194 
      //３．閏年によるリセット量
      //INT｛（西暦年－2000年）/ 4｝　（日）
      //例．INT{(2010 - 2000) / 4} = INT(2.5) = 2 
      //４．求める年の春分日の計算
      //INT｛（１）＋（２）－（３）｝　（日）
      //例．INT{20.69115 + 2.42194 - 2} = INT(21.11309) = 21
      // 　　結果：2010年の春分日は　3/21日 
      //秋分日に関しては、春分日の説明の（１）を9/23.09日とする
      //※ 西暦2100は閏年ではないので、その年以降はこの計算式ではズレてしまう
      //
      // また、国立天文台のWebページ http://www.nao.ac.jp/faq/a0301.html には、
      // 西暦2030年までの表が掲載されている（春分の日と秋分の日がその通りになるとは限らない）。

      //春分の日
      //春分日 自然をたたえ、生物をいつくしむ。 
      var 春分の日 = new Holiday()
      {
        Date = CalcVernalEquinoxDay(Year),
        Kind = HolidayKind.国民の祝日,
        Name = "春分の日",
        Definition = "春分日",
      };
      holidays.Add(春分の日.Date, 春分の日);

      //秋分の日
      //秋分日 祖先をうやまい、なくなった人々をしのぶ。 
      var 秋分の日 = new Holiday()
      {
        Date = CalcAutumnalEquinoxDay(Year),
        Kind = HolidayKind.国民の祝日,
        Name = "秋分の日",
        Definition = "秋分日",
      };
      holidays.Add(秋分の日.Date, 秋分の日);



      // 4. 振替休日
      // 国民の祝日に関する法律 第3条2
      //「国民の祝日」が日曜日に当たるときは、その日後において
      // その日に最も近い「国民の祝日」でない日を休日とする。
      var substituteHolidays = GetSubstituteHolidays(holidays);
      foreach (var s in substituteHolidays)
        holidays.Add(s.Date, s);

      // 5. 国民の休日
      // 国民の祝日に関する法律 第3条3
      // その前日及び翌日が「国民の祝日」である日（「国民の祝日」でない日に限る。）は、休日とする。
      var sandwichedHolidays = GetSandwichedHolidays(holidays);
      foreach (var s in sandwichedHolidays)
        holidays.Add(s.Date, s);


      // 祝日を出力する
      Console.WriteLine("{0}年の休日", Year);
      foreach (var d in holidays.Values)
        Console.WriteLine("{0:MM/dd(ddd)} {1}（{2}、{3}）", 
                          d.Date, d.Name, d.Definition, d.Kind);
      Console.WriteLine();


#if DEBUG
      Console.ReadKey();
#endif
    }

  }
}
