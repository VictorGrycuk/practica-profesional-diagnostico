using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Diagnostico2019.Exercises
{
    public static class BubbleSort
    {
        public static void SortDescending()
        {
            int[] array = IOHelper.GetNumericInput();

            Sort(array, IsGreater);

            Console.WriteLine(string.Join(", ", array.Select(x => x.ToString()).ToArray()));
        }

        /// <summary>
        /// Main sort logic, for either ascending or descending
        /// </summary>
        /// <param name="array">Array of int to sort</param>
        /// <param name="order">The sorting order for the array</param>
        /// <returns>Sorted array</returns>
        public static int[] Sort(int[] array, Func<int, int, bool> order)
        {
            for (int i = 0; i < array.Length; i++)
            {
                for (int j = 0; j < array.Length; j++)
                {
                    if (order.Invoke(array[i], array[j]))
                    {
                        SwapValues(ref array, i, j);
                    }
                }
            }

            return array;
        }

        /// <summary>
        /// Function that swaps two element in an array without using a temporal variable
        /// </summary>
        /// <param name="array"></param>
        /// <param name="i"></param>
        /// <param name="j"></param>
        private static void SwapValues(ref int[] array, int i, int j)
        {
            array[i] += array[j];
            array[j] = array[i] - array[j];
            array[i] -= array[j];
        }

        /// These two methods are used as parameters.
        /// Made it this way so that way the Sort() code
        /// is not repeated when sorting either way.

        private static bool IsGreater(int x, int y)
        {
            return x > y;
        }

        private static bool IsLess(int x, int y)
        {
            return x < y;
        }
    }
}
