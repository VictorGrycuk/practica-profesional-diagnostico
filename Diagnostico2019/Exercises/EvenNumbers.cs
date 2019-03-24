using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Diagnostico2019.Exercises
{
    public static class EvenNumbers
    {
        public static void GetNumbers()
        {
            int[] array = new int[] { 45, 23, 52, 68, 2, 98, 106, 107, 465, 23, 18 };
            List<int> evenNumber = new List<int>();

            foreach (var number in array)
            {
                if (number % 2 == 0)
                {
                    Console.WriteLine($"Number {number} is even" + Environment.NewLine);
                    evenNumber.Add(number);
                }
            }

            Console.WriteLine($"There are {evenNumber.Count} even numbers");
        }
    }
}
