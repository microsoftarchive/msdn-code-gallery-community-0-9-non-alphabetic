Public Enum HolidayKind
  平日 = 0
  国民の祝日 = 1
  振替休日 = 2
  国民の休日 = 3
End Enum

Public Class Holiday
  Public Property [Date] As DateTime
  Public Property Kind As HolidayKind
  Public Property Name As String
  Public Property Definition As String
End Class



Module Module1

  ' 指定月の第N月曜日を求める
  Private Function GetNthMonday(nth As Integer, year As Integer, month As Integer) As DateTime

    ' 指定された月の日数
    Dim days As Integer = DateTime.DaysInMonth(year, month)

    ' 指定された月の全ての日から、月曜日だけを取り出す
    Dim allMondays As IEnumerable(Of DateTime) _
      = Enumerable.Range(1, days) _
          .Select(Function(d) New DateTime(year, month, d)) _
          .Where(Function(dt) dt.DayOfWeek = DayOfWeek.Monday)

    ' N番目の月曜日を求める
    Return allMondays.ElementAt(nth - 1)
  End Function

  ' 春分日を求める（2099年まで有効な実験式）
  Private Function CalcVernalEquinoxDay(year As Integer) As DateTime

    ' １．2000年の太陽の春分点通過日
    Dim 基準日 As Double = 20.69115

    ' ２．春分点通過日の移動量＝（西暦年－2000年）×0.242194
    Dim 移動量 As Double = (year - 2000) * 0.242194

    ' ３．閏年によるリセット量＝INT｛（西暦年－2000年）/ 4｝
    Dim 閏年補正 As Integer = CType(Int((year - 2000) / 4.0), Integer)

    ' 求める年の春分日＝INT｛（１）＋（２）－（３）｝
    Dim 春分日 As Integer = CType(Int(基準日 + 移動量 - 閏年補正), Integer)

    Return New DateTime(year, 3, 春分日)
  End Function

  ' 秋分日を求める（2099年まで有効な実験式）
  Private Function CalcAutumnalEquinoxDay(year As Integer) As DateTime

    ' １．2000年の太陽の秋分点通過日
    Dim 基準日 As Double = 23.09 ' 秋分点の揺らぎ補正済みの値

    ' ２．秋分点通過日の移動量＝（西暦年－2000年）×0.242194
    Dim 移動量 As Double = (year - 2000) * 0.242194

    ' ３．閏年によるリセット量＝INT｛（西暦年－2000年）/ 4｝
    Dim 閏年補正 As Integer = CType(Int((year - 2000) / 4.0), Integer)

    ' 求める年の秋分日＝INT｛（１）＋（２）－（３）｝
    Dim 秋分日 As Integer = CType(Int(基準日 + 移動量 - 閏年補正), Integer)

    Return New DateTime(year, 9, 秋分日)
  End Function

  ' 振替休日を全て求める
  ' 国民の祝日に関する法律 第3条2
  '「国民の祝日」が日曜日に当たるときは、その日後において
  ' その日に最も近い「国民の祝日」でない日を休日とする。
  Private Function GetSubstituteHolidays( _
    holidays As SortedDictionary(Of DateTime, Holiday)) As IEnumerable(Of Holiday)

    ' 振替休日を格納するためのコレクション
    Dim substituteHolidays As List(Of Holiday) = New List(Of Holiday)()

    ' これまでに求めた祝日を全部チェックする
    For Each holiday In holidays.Values

      If (holiday.Date.DayOfWeek <> DayOfWeek.Sunday) Then
        Continue For ' 日曜でなければ除外する
      End If

      ' 翌日（＝月曜日）を仮に振替休日とする
      Dim substitute As DateTime = holiday.Date.AddDays(1.0)

      ' その日がすでに祝日ならば振替休日はさらにその翌日
      While (holidays.ContainsKey(substitute))
        substitute = substitute.AddDays(1.0)
      End While

      ' 見つかった振替休日をコレクションに追加する
      Dim substituteHoliday = New Holiday() With
        {
          .Date = substitute,
          .Kind = HolidayKind.振替休日,
          .Name = "振替休日",
          .Definition = String.Format("{0}の振替休日", holiday.Name)
        }
      substituteHolidays.Add(substituteHoliday)
    Next
    Return substituteHolidays
  End Function

  ' 国民の休日を全て求める
  ' 国民の祝日に関する法律 第3条3
  ' その前日及び翌日が「国民の祝日」である日（「国民の祝日」でない日に限る。）は、休日とする。
  Private Function GetSandwichedHolidays(
    holidays As SortedDictionary(Of DateTime, Holiday)) As IEnumerable(Of Holiday)

    Dim sandwichedHolidays As List(Of Holiday) = New List(Of Holiday)()

    ' これまでに求めた祝日を全部チェックする
    For Each holiday0 In holidays.Values
      If (holiday0.Kind <> HolidayKind.国民の祝日) Then
        Continue For 'その休日が国民の祝日でなければ除外する
      End If

      Dim day0 = holiday0.Date

      Dim day2 = day0.AddDays(2.0) ' 2日後
      If (Not holidays.ContainsKey(day2)) Then
        Continue For '2日後が祝日でないときは除外する
      End If
      Dim holiday2 = holidays(day2)
      If (holiday2.Kind <> HolidayKind.国民の祝日) Then
        Continue For '2日後が祝日であっても国民の祝日でなければ除外する
      End If

      Dim day1 = day0.AddDays(1.0) ' 1日後=国民の祝日で挟まれた日
      If (day1.DayOfWeek = DayOfWeek.Sunday) Then
        Continue For ' その日が日曜（＝もともと休日）のときは除外する
      End If
      If (holidays.ContainsKey(day1)) Then
        Continue For ' その日がすでに祝日のときは除外する
      End If

      ' 見つかった国民の休日をコレクションに追加する
      Dim sandwichedHoliday = New Holiday() With
        {
          .Date = day1,
          .Kind = HolidayKind.国民の休日,
          .Name = "国民の休日",
          .Definition = String.Format("{0}と{1}の間の日", holiday0.Name, holiday2.Name)
        }
      sandwichedHolidays.Add(sandwichedHoliday)
    Next
    Return sandwichedHolidays
  End Function



  Sub Main(args As String())
    ' 祝日を計算する年
    Const MinYear As Integer = 2007 ' この年からみどりの日の実施と振替休日の変更
    Const MaxYear As Integer = 2099
    Dim Year As Integer = 2015
    If (args.Length > 0) Then
      Integer.TryParse(args(0), Year)
    End If
    If (Year < MinYear OrElse MaxYear < Year) Then
      Console.WriteLine("計算可能な年は{0}から{1}までです", MinYear, MaxYear)
      Return
    End If

    ' 祝日を格納するコレクション
    Dim holidays As SortedDictionary(Of DateTime, Holiday) _
      = New SortedDictionary(Of DateTime, Holiday)()



    ' 1. 日付けが固定の祝日
    ' 国民の祝日に関する法律 第2条の一部
    ' 建国記念の日となる日を定める政令

    ' 元日：1月1日 年のはじめを祝う。 
    Dim 元日 = New Holiday() With
                      {
                        .Date = New DateTime(Year, 1, 1),
                        .Kind = HolidayKind.国民の祝日,
                        .Name = "元日", .Definition = "1月1日"
                      }
    holidays.Add(元日.Date, 元日)

    ' 建国記念の日：2月11日
    ' 政令で定める日 建国をしのび、国を愛する心を養う。 
    Dim 建国記念の日 = New Holiday() With
                      {
                        .Date = New DateTime(Year, 2, 11),
                        .Kind = HolidayKind.国民の祝日,
                        .Name = "建国記念の日", .Definition = "2月11日"
                      }
    holidays.Add(建国記念の日.Date, 建国記念の日)

    ' 昭和の日：4月29日 激動の日々を経て、復興を遂げた昭和の時代を顧み、国の将来に思いをいたす。 
    Dim 昭和の日 = New Holiday() With
                    {
                      .Date = New DateTime(Year, 4, 29),
                      .Kind = HolidayKind.国民の祝日,
                      .Name = "昭和の日", .Definition = "4月29日"
                    }
    holidays.Add(昭和の日.Date, 昭和の日)

    ' 憲法記念日：5月3日 日本国憲法の施行を記念し、国の成長を期する。 
    Dim 憲法記念日 = New Holiday() With
                    {
                      .Date = New DateTime(Year, 5, 3),
                      .Kind = HolidayKind.国民の祝日,
                      .Name = "憲法記念日", .Definition = "5月3日"
                    }
    holidays.Add(憲法記念日.Date, 憲法記念日)

    ' みどりの日：5月4日 自然に親しむとともにその恩恵に感謝し、豊かな心をはぐくむ。 
    Dim みどりの日 = New Holiday() With
                    {
                      .Date = New DateTime(Year, 5, 4),
                      .Kind = HolidayKind.国民の祝日,
                      .Name = "みどりの日", .Definition = "5月4日"
                    }
    holidays.Add(みどりの日.Date, みどりの日)

    ' こどもの日：5月5日 こどもの人格を重んじ、こどもの幸福をはかるとともに、母に感謝する。 
    Dim こどもの日 = New Holiday() With
                    {
                      .Date = New DateTime(Year, 5, 5),
                      .Kind = HolidayKind.国民の祝日,
                      .Name = "こどもの日", .Definition = "5月5日"
                    }
    holidays.Add(こどもの日.Date, こどもの日)

    ' 山の日：8月11日 山に親しむ機会を得て、山の恩恵に感謝する。(2016年より) 
    If (2016 <= Year) Then
      Dim 山の日 = New Holiday() With
                  {
                    .Date = New DateTime(Year, 8, 11),
                    .Kind = HolidayKind.国民の祝日,
                    .Name = "山の日", .Definition = "8月11日"
                  }
      holidays.Add(山の日.Date, 山の日)
    End If
    '// 注：この「山の日」のように、本来はすべての祝日について施行される年をチェックすべき。
    '//     過去にさかのぼって適用する場合は必須。
    '//     成人の日／敬老の日／体育の日（いずれも過去には固定日付だった）のように、
    '//     定義が変更されることもある。

    ' 文化の日：11月3日 自由と平和を愛し、文化をすすめる。 
    Dim 文化の日 = New Holiday() With
                  {
                    .Date = New DateTime(Year, 11, 3),
                    .Kind = HolidayKind.国民の祝日,
                    .Name = "文化の日", .Definition = "11月3日"
                  }
    holidays.Add(文化の日.Date, 文化の日)

    ' 勤労感謝の日：11月23日 勤労をたっとび、生産を祝い、国民たがいに感謝しあう。 
    Dim 勤労感謝の日 = New Holiday() With
                  {
                    .Date = New DateTime(Year, 11, 23),
                    .Kind = HolidayKind.国民の祝日,
                    .Name = "勤労感謝の日", .Definition = "11月23日"
                  }
    holidays.Add(勤労感謝の日.Date, 勤労感謝の日)

    ' 天皇誕生日：12月23日 
    Dim 天皇誕生日 = New Holiday() With
                {
                  .Date = New DateTime(Year, 12, 23),
                  .Kind = HolidayKind.国民の祝日,
                  .Name = "天皇誕生日", .Definition = "12月23日"
                }
    holidays.Add(天皇誕生日.Date, 天皇誕生日)



    ' 2. 日付けが「○月第△月曜日」のパターン
    ' 国民の祝日に関する法律 第2条の一部

    ' 成人の日：1月の第2月曜日 おとなになったことを自覚し、みずから生き抜こうとする青年を祝いはげます。 
    Dim 成人の日 = New Holiday() With
                {
                  .Date = GetNthMonday(2, Year, 1),
                  .Kind = HolidayKind.国民の祝日,
                  .Name = "成人の日", .Definition = "1月の第2月曜日"
                }
    holidays.Add(成人の日.Date, 成人の日)

    ' 海の日：7月の第3月曜日 海の恩恵に感謝するとともに、海洋国日本の繁栄を願う。 
    Dim 海の日 = New Holiday() With
                {
                  .Date = GetNthMonday(3, Year, 7),
                  .Kind = HolidayKind.国民の祝日,
                  .Name = "海の日", .Definition = "7月の第3月曜日"
                }
    holidays.Add(海の日.Date, 海の日)

    ' 敬老の日：9月の第3月曜日 多年にわたり社会につくしてきた老人を敬愛し、長寿を祝う。 
    Dim 敬老の日 = New Holiday() With
                {
                  .Date = GetNthMonday(3, Year, 9),
                  .Kind = HolidayKind.国民の祝日,
                  .Name = "敬老の日", .Definition = "9月の第3月曜日"
                }
    holidays.Add(敬老の日.Date, 敬老の日)

    ' 体育の日：10月の第2月曜日 スポーツにしたしみ、健康な心身をつちかう。 
    Dim 体育の日 = New Holiday() With
                {
                  .Date = GetNthMonday(2, Year, 10),
                  .Kind = HolidayKind.国民の祝日,
                  .Name = "体育の日", .Definition = "10月の第2月曜日"
                }
    holidays.Add(体育の日.Date, 体育の日)



    ' 3. 春分の日と秋分の日
    ' 国民の祝日に関する法律 第2条の一部
    '
    ' 公式には前年の2月の官報で発表される。
    '
    ' ここでは西暦2099年まで合っているとされる実験式を使う。 http://koyomi8.com/reki_doc/doc_0330.htm
    '１．2000年の太陽の春分点通過日
    '3月20.69115日
    '例．20.69115　（これは、期間中変化しません）
    '２．１年ごとの春分点通過日の移動量
    '（西暦年－2000年）×0.242194　（日）
    '例．(2010 - 2000) × 0.242194 = 2.42194 
    '３．閏年によるリセット量
    'INT｛（西暦年－2000年）/ 4｝　（日）
    '例．INT{(2010 - 2000) / 4} = INT(2.5) = 2 
    '４．求める年の春分日の計算
    'INT｛（１）＋（２）－（３）｝　（日）
    '例．INT{20.69115 + 2.42194 - 2} = INT(21.11309) = 21
    ' 　　結果：2010年の春分日は　3/21日 
    '秋分日に関しては、春分日の説明の（１）を9/23.09日とする
    '※ 西暦2100は閏年ではないので、その年以降はこの計算式ではズレてしまう
    '
    ' また、国立天文台のWebページ http://www.nao.ac.jp/faq/a0301.html には、
    ' 西暦2030年までの表が掲載されている（春分の日と秋分の日がその通りになるとは限らない）。

    ' 春分の日
    ' 春分日 自然をたたえ、生物をいつくしむ。 
    Dim 春分の日 = New Holiday() With
                {
                  .Date = CalcVernalEquinoxDay(Year),
                  .Kind = HolidayKind.国民の祝日,
                  .Name = "春分の日", .Definition = "春分日"
                }
    holidays.Add(春分の日.Date, 春分の日)

    ' 秋分の日
    ' 秋分日 祖先をうやまい、なくなった人々をしのぶ。 
    Dim 秋分の日 = New Holiday() With
                {
                  .Date = CalcAutumnalEquinoxDay(Year),
                  .Kind = HolidayKind.国民の祝日,
                  .Name = "秋分の日", .Definition = "秋分日"
                }
    holidays.Add(秋分の日.Date, 秋分の日)



    ' 4. 振替休日
    ' 国民の祝日に関する法律 第3条2
    '「国民の祝日」が日曜日に当たるときは、その日後において
    ' その日に最も近い「国民の祝日」でない日を休日とする。
    Dim substituteHolidays = GetSubstituteHolidays(holidays)
    For Each s In substituteHolidays
      holidays.Add(s.Date, s)
    Next

    ' 5. 国民の休日
    ' 国民の祝日に関する法律 第3条3
    ' その前日及び翌日が「国民の祝日」である日（「国民の祝日」でない日に限る。）は、休日とする。
    Dim sandwichedHolidays = GetSandwichedHolidays(holidays)
    For Each s In sandwichedHolidays
      holidays.Add(s.Date, s)
    Next



    ' 祝日を出力する
    Console.WriteLine("{0}年の休日", Year)
    For Each d In holidays.Values
      Console.WriteLine("{0:MM/dd(ddd)} {1}（{2}、{3}）",
                        d.Date, d.Name, d.Definition, d.Kind)
    Next
    Console.WriteLine()

#If DEBUG Then
    Console.ReadKey()
#End If
  End Sub

End Module
