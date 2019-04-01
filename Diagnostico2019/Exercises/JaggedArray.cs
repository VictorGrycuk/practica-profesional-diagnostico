using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Diagnostico2019.Exercises
{
    public static class ResolveJaggedArray
    {
        public static void FindElement()
        {
            int[][] array = new int[][]
            {
                new int[] {1, 3, 5, 7, 9},
                new int[] {0, 2, 4, 6},
                new int[] {11, 22}
            };

            int[] result = Find(array, IOHelper.GetNumericInput("Please inert the value to search:"));

            if (result != null)
            {
                Console.WriteLine(Environment.NewLine + $"The element was found in [{ result[0] }, { result[1] }]");
            }
            else
            {
                Console.WriteLine("The value was not find in the jagged array.");
            }
        }

        public static int[] Find(int[][] array, int value)
        {
            int[] result = null;
            for (int i = 0; i < array.Length; i++)
            {
                var tempArray = array[i];
                for (int j = 0; j < tempArray.Length; j++)
                {
                    if (tempArray[j] == value)
                    {
                        result = new int[2] { i + 1, j + 1 };
                    }
                }
            }

            return result;
        }
    }
}
