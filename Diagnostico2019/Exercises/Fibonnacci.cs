using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Diagnostico2019.Exercises
{
    public static class Fibonacci
    {
        public static void GetFibonacci()
        {
            Console.WriteLine("Enter the desired length of the Fibonacci sequence. Minimum length is 2 and maximum is 47 due to capacity storage limitation");

            Console.WriteLine(string.Join(", ", GetSequence(IOHelper.GetNumericInput()).Select(x => x.ToString())));
        }

        public static int[] GetSequence(int length)
        {
            int[] fibonacci = new int[] { 0, 1 };

            for (int i = 0; i < length; i++)
            {
                int newFibonacciElement = fibonacci[i] + fibonacci[i + 1];

                // Due to the limitation of int type, if we overflow it will become negative. If that happens we escape the loop
                if (IsNegative(newFibonacciElement)) break;

                // Otherwise we simply add it to the sequence
                fibonacci = fibonacci.Concat(new int[] { newFibonacciElement }).ToArray();

                // If the array has the amount of element specified, we escape the loop
                if (fibonacci.Length == length) break;
            }

            return fibonacci;
        }

        private static bool IsNegative(int number)
        {
            return number < 0;
        }
    }
}
