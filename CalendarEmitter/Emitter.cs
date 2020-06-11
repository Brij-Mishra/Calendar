using System;

namespace CalendarEmitter
{
  public class Emitter
  {
    public void PrintMonth(int year, int month)
    {
      bool isCurrentMonthnYear = year == DateTime.Now.Year && month == DateTime.Now.Month;

      PrintCalenderheader(year, month);

      const string seperator = "\t";
      var days = Enum.GetValues(typeof(DayOfWeek));

      int daysinMonth = getDaysinCurrentMonth(year, month);
      int dayoftheWeek = (int)(new DateTime(year, month, 1)).DayOfWeek;
      int numberofWeeksToShow = daysinMonth == 28 && dayoftheWeek == (int)DayOfWeek.Sunday ? 4 : 5;
      int startDay = (-1) * (dayoftheWeek - 1);

      foreach (var day in days)
      {
        Console.Write(day.ToString().Substring(0,2));
        Console.Write(seperator);
      }

      Console.WriteLine();

      for (int i = 0; i < numberofWeeksToShow; i++)
      {
        for (int j = 0; j < 7; j++)
        {
          if (isCurrentMonthnYear && startDay == DateTime.Now.Day)
          {
            Console.ForegroundColor = ConsoleColor.Black;
            Console.BackgroundColor = ConsoleColor.White;
            Console.Write("{0}", startDay > 0 ? startDay.ToString() : string.Empty);
            Console.ResetColor();
          }
          else
          {
            Console.Write("{0}", startDay > 0 ? startDay.ToString() : string.Empty);
          }

          Console.Write(seperator);
          if (startDay < daysinMonth) startDay++;
          else break;
        }

        Console.Write('\n');
      }
    }

    private void PrintCalenderheader(int year, int month)
    {
      Console.WriteLine("\t\t{0} {1}", MonthName(month).ToUpperInvariant(), year);
    }

    private string MonthName(int month)
    {
      switch (month)
      {
        case 1: return "January";
        case 2: return "February";
        case 3: return "March";
        case 4: return "April";
        case 5: return "May";
        case 6: return "June";
        case 7: return "July";
        case 8: return "August";
        case 9: return "Sepetember";
        case 10: return "October";
        case 11: return "November";
        case 12: return "December";
        default: return "none";
      }
    }

    private int getDaysinCurrentMonth(int year, int month)
    {
      return DateTime.DaysInMonth(year, month);
    }
  }
}
