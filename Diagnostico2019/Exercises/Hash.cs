using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Diagnostico2019.Exercises
{
    public static class Hash
    {
        public static void Encode()
        {
            var result = Encode("Fadasdasd");
        }

        public static string Encode(string value)
        {
            // Get the first byte as binary
            byte[] bytesArray = Encoding.Default.GetBytes(value);
            string binaryString = Convert.ToString(bytesArray[0], 2).PadLeft(8, '0');
            int firstQuartet = Convert.ToInt32(binaryString.Substring(0, 4), 2);
            int secondQuartet = Convert.ToInt32(binaryString.Substring(4), 2);

            int repetitions = Fibonacci.GetSequence(firstQuartet + secondQuartet).Last();

            string result = value;
            for (int i = 0; i < repetitions; i++)
            {
                result = Calculate(result);
                result = result.Length != 16 ? GeneratePadding(result) : result;
            }

            return result;
        }

        private static string Calculate(string value)
        {
            int[] result = new int[16];
            byte[] ba = Encoding.Default.GetBytes(value);
            var hexString = BitConverter.ToString(ba).Replace("-", string.Empty);

            int index = GetHexValue(hexString[hexString.Length - 1]);
            Update(result, index, hexString[0]);

            for (int i = 1; i < hexString.Length; i++)
            {
                index = GetHexValue(hexString[i - 1]);
                Update(result, index, hexString[i]);
            }

            var finalResult = string.Concat(result.Select(x => x.ToString("X")).ToArray());
            finalResult = InvertString(finalResult);

            return finalResult;
        }

        private static string GeneratePadding(string value)
        {
            if (value.Length == 16)
            {
                return value;
            }

            var neededPadding = 16 - value.Length;
            var padding = string.Empty;

            while (padding.Length <= neededPadding)
            {
                padding += InvertString(Calculate(value));
            }

            return padding.Substring(0, neededPadding) + value;
        }

        private static string InvertString(string value)
        {
            char[] charArray = value.ToCharArray();
            Array.Reverse(charArray);
            return new string(charArray).TrimStart(new char[] { '0' } );
        }

        private static bool Update(int[] array, int index, char value)
        {
            index = index > 15 ? 0 : index;
            var hexResult = AddTwoHexa(array[index], GetHexValue(value));
            array[index] = hexResult.result;

            while (hexResult.overflow)
            {
                hexResult.overflow = Update(array, index + 1, hexResult.excess);
            }

            return hexResult.overflow;
        }

        private static int GetHexValue(char value)
        {
            return int.Parse(value.ToString(), NumberStyles.HexNumber);
        }

        private static HexaResult AddTwoHexa(int number1, int number2)
        {
            int result = number1 + number2;
            if (result > 15)
            {
                string hexResult = result.ToString("X");
                return new HexaResult
                {
                    result = GetHexValue(hexResult[1]),
                    excess = hexResult[0],
                    overflow = true
                };
            }
            else
            {
                return new HexaResult
                {
                    result = result,
                    excess = (char)0,
                    overflow = false
                };
            }
        }
    }

    public class HexaResult
    {
        public int result;
        public char excess;
        public bool overflow;
    }
}
