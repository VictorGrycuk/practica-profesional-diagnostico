using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Diagnostico2019.Exercises
{
    public static class IOHelper
    {
        public static int[] GetNumericArrayInput()
        {
            Console.WriteLine("Add numbers and when ready insert 'done'.");
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

        public static int GetNumericInput()
        {
            Console.WriteLine("Insert a number.");
            string line = Console.ReadLine();
            if (int.TryParse(line, out int enteredNumber))
            {
                return enteredNumber;
            }
            else
            {
                Console.WriteLine("Only numbers are accepted." + Environment.NewLine);
                GetNumericInput();
            }

            // Doesnt really get here because of the recursion
            return -1;
        }

        public static DateTime GetDateInput()
        {
            Console.WriteLine("Insert a date:");
            string line = Console.ReadLine();
            if (DateTime.TryParse(line, out DateTime enteredDate))
            {
                return enteredDate;
            }
            else
            {
                Console.WriteLine("The entered text is not a valid date." + Environment.NewLine);
                GetDateInput();
            }

            // Doesnt really get here because of the recursion
            return DateTime.Now;
        }

        public static string GetFileInput()
        {
            string filePath = Console.ReadLine();
            if (File.Exists(filePath))
            {
                return filePath;
            }

            do
            {
                Console.WriteLine(Environment.NewLine + "The entered file does not exists. Please enter a new path.");
                filePath = Console.ReadLine();
            } while (!File.Exists(filePath));

            return filePath;
        }

        public static List<string> GetFileAsHexa(string filePath)
        {
            FileStream fs = new FileStream(filePath, FileMode.Open);
            var file = new List<string>();
            int hexIn;

            for (int i = 0; (hexIn = fs.ReadByte()) != -1; i++)
            {
                file.Add(string.Format("{0:X2}", hexIn));
            }

            return file;
        }
    }
}
