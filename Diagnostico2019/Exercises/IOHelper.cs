using System;
using System.Linq;

namespace Diagnostico2019.Exercises
{
    public static class IOHelper
    {
        public static int[] GetNumericArrayInput()
        {
            Console.WriteLine("Add numbers to sort them in descending order. When done insert 'done'.");
            int[] array = new int[] { };
            while (true)
            {
                string line = Console.ReadLine();
                if (int.TryParse(line, out int enteredNumber))
                {
                    array = array.Concat(new int[] { enteredNumber }).ToArray();
                }
                else if (line == "done")
                {
                    break;
                }
                else
                {
                    Console.WriteLine("Only numbers are accepted.");
                }
            }

            return array;
        }
    }
}
