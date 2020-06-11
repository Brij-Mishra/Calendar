using CalendarEmitter;
using System;

namespace Client
{
  class Program
  {
    static void Main(string[] args)
    {
      int year = 0;
      int month = 0;

      Console.WriteLine("Kindly enter the command and hit enter. To exit hit Q/q!");
      Console.WriteLine("Ex: cal, cal <year>, cal <month> <year>.");
      string commandName = Console.ReadLine().Trim().ToLowerInvariant();
      while (commandName != "q")
      {
        commandName = commandName.Trim();

        if (!commandName.StartsWith("cal"))
          Console.WriteLine("Incorrect command.calen");

        string[] commandParameters = commandName.Split(' ');

        if (commandParameters.Length == 2 && commandParameters[1].Length == 4)
        {
          int.TryParse(commandParameters[1], out year);
        }

        if (commandParameters.Length == 3 && commandParameters[1].Length <= 2 && commandParameters[2].Length == 4)
        {
          int.TryParse(commandParameters[1], out month);
          int.TryParse(commandParameters[2], out year);
        }

        Emitter objEmitter = new Emitter();

        if (commandParameters.Length == 1 && commandParameters[0].ToLowerInvariant() == "cal")
        {
          objEmitter.PrintMonth(DateTime.Now.Year, DateTime.Now.Month);
        }
        else if (commandParameters.Length == 2 && commandParameters[0].ToLowerInvariant() == "cal" && year != 0)
        {
          for (int m = 1; m <= 12; m++)
          {
            objEmitter.PrintMonth(year, m);
            Console.WriteLine();
          }
        }
        else if (commandParameters.Length == 3 && commandParameters[0].ToLowerInvariant() == "cal" && year != 0 && month != 0)
        {
          objEmitter.PrintMonth(year, month);
        }

        Console.WriteLine();
        Console.WriteLine("Kindly enter the command and hit enter. To exit hit Q/q!");
        commandName = Console.ReadLine().Trim().ToLowerInvariant();

      }

      Console.ReadKey();
    }
  }
}
