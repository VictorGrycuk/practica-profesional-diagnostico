using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Diagnostico2019.Exercises
{
    public static class BubbleSort
    {
        public static void Sort()
        {
            int[] array = IOHelper.GetNumericInput();

            SortDescending(array);

            Console.WriteLine(string.Join(", ", array.Select(x => x.ToString()).ToArray()));
        }

        public static int[] SortDescending(int[] array)
        {
            for (int i = 0; i < array.Length; i++)
            {
                for (int j = 0; j < array.Length; j++)
                {
                    if (array[i] > array[j])
                    {
                        SwapValues(ref array, i, j);
                    }
                }
            }

            return array;
        }

        private static void SwapValues(ref int[] array, int i, int j)
        {
            array[i] += array[j];
            array[j] = array[i] - array[j];
            array[i] -= array[j];
        }
    }
}
