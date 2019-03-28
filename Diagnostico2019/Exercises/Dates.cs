using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Diagnostico2019.Exercises
{
    public static class Dates
    {
        public static void GetMondays()
        {
            Console.WriteLine("Enter the starting date.");
            DateTime startingDate = IOHelper.GetDateInput();

            Console.WriteLine(Environment.NewLine + "Enter the ending date.");
            DateTime endingDate = IOHelper.GetDateInput();

            startingDate = GetNextDayOfTheWeek(startingDate, DayOfWeek.Monday);

            foreach (var date in GetDays(startingDate, endingDate, DayOfWeek.Monday))
            {
                Console.WriteLine($"{date.DayOfWeek.ToString()} {date.ToShortDateString()}");
            }
        }

        public static DateTime GetNextDayOfTheWeek(DateTime date, DayOfWeek dayOfWeek)
        {
            while (date.DayOfWeek != dayOfWeek)
            {
                date = date.AddDays(1);
            }

            return date;
        }

        public static DateTime[] GetDays(DateTime startingDate, DateTime endingDate, DayOfWeek dayOfWeek)
        {
            DateTime[] dates = new DateTime[] { GetNextDayOfTheWeek(startingDate, dayOfWeek) };

            while (dates[dates.Length - 1] <= endingDate)
            {
                dates = dates.Concat(new DateTime[] { dates[dates.Length - 1].AddDays(7) }).ToArray();
            }

            return dates;
        }
    }
}
