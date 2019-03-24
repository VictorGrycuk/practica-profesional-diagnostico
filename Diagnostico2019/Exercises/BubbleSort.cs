using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Diagnostico2019.Exercises
{
    public static class BubbleSort
    {
        public static void Descending()
        {
            int[] array = new int[] { 23, 1, 5, 2, 98, 14, 76, 98, 104, 3, 9 };
            Console.WriteLine(string.Join(", ", array.Select(x => x.ToString()).ToArray()));

            for (int i = 0; i < array.Length; i++)
            {
                for (int j = 0; j < array.Length; j++)
                {
                    if (array[i] > array[j])
                    {
                        array[i] += array[j];
                        array[j] = array[i] - array[j];
                        array[i] -= array[j];
                    }
                }
            }

            Console.WriteLine(string.Join(", ", array.Select(x => x.ToString()).ToArray()));
        }
    }
}
