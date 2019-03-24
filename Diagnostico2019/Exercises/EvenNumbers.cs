using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Diagnostico2019.Exercises
{
    public static class EvenNumbers
    {
        /// <summary>
        /// Trtied to avoid the use of List<int> since the exercise used the word "vector"
        /// </summary>

        public static void GetNumbers()
        {
            int[] array = IOHelper.GetNumericArrayInput();

            Console.WriteLine("====================");
            foreach (var number in FilterEvenNumbers(array))
            {
                Console.WriteLine($"Number {number} is even");
            }

            Console.WriteLine(Environment.NewLine + $"There are { CountEvenNumbers(array) } even numbers");
        }

        /// The following two methods are not extrictly neccesary,
        /// their logic was extracted just to be used for unit testing.

        public static int[] FilterEvenNumbers(int[] number)
        {
            return number.Where(x => x % 2 == 0).ToArray();
        }

        public static int CountEvenNumbers(int[] number)
        {
            return number.Count(x => x % 2 == 0);
        }
    }
}
