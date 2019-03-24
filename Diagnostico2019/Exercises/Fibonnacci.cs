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
            Console.WriteLine("Enter the desired lenght of the Fibonacci sequence. Minimum length is 2.");

            Console.WriteLine(string.Join(", ", GetSequence(IOHelper.GetNumericInput()).Select(x => x.ToString())));
        }

        public static int[] GetSequence(int length)
        {
            int[] fibonacci = new int[] { 0, 1 };

            for (int i = 0; i < length; i++)
            {
                fibonacci = fibonacci.Concat(new int[] { fibonacci[i] + fibonacci[i + 1] }).ToArray();
                if (fibonacci.Length == length) break;
            }

            return fibonacci;
        }
    }
}
