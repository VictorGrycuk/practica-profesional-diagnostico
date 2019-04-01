using System;
using System.Globalization;
using System.Linq;
using System.Text;

namespace Diagnostico2019.Exercises
{
    public static class Hash
    {
        public static void Encode()
        {
            Console.WriteLine("Write a line of text to encode it.");
            var result = Encode(Console.ReadLine());

            Console.WriteLine(Environment.NewLine + "The resulting hash is: " + result);
        }

        /// <summary>
        /// The basic idea of this hash function is the following:
        /// 1. Given any string, get its hexadecimal value
        /// 2. For each hexa character:
        ///    i.   Get the decimal value of the previous char (if its the first char, use the last char)
        ///    ii.  Add current value to a 16 places array using the previous decimal value as index
        ///    iii. If there is an overflow (value over 16), add the excess to the next item in the array
        /// 3. Add padding in case it is needed
        /// 
        /// I created this function having the following rules in mind:
        /// * It should always return the same value for the same input
        /// * It should always return the same amount of characters every time
        /// * Each output should be as much as different as possible for different inputs
        /// At the moment, the function entropy is actually low. There seems to be a preference for multiples of 3.
        /// </summary>
        public static string Encode(string value)
        {
            /// To generate entropy, I decided to calculate the calculate the same result x times
            int repetitions = GetRepetitions(value);

            for (int i = 0; i < repetitions; i++)
            {
                // After calculating the hash, we add padding if it doesn't have 16 characters
                value = Calculate(value);
            }

            value = value.Length != 16 ? GeneratePadding(value) : value;

            return value;
        }

        /// <summary>
        /// To determine how many repetitions of the calculation will be made, I chose to use
        /// the value of the first character in case the function receives only one character.
        /// Also I decided to recycle the Fibonacci function.
        /// </summary>
        private static int GetRepetitions(string value)
        {
            byte[] bytesArray = Encoding.Default.GetBytes(value);
            string binaryString = Convert.ToString(bytesArray[0], 2).PadLeft(8, '0');
            int firstQuartet = Convert.ToInt32(binaryString.Substring(0, 4), 2);
            int secondQuartet = Convert.ToInt32(binaryString.Substring(4), 2);
            return Fibonacci.GetSequence(firstQuartet + secondQuartet).Last();
        }

        /// <summary>
        /// This function takes the string, converts it hexa, then populates the result array
        /// </summary>
        private static string Calculate(string value)
        {
            int[] result = new int[16];
            byte[] byteArray = Encoding.Default.GetBytes(value);

            var hexString = BitConverter.ToString(byteArray).Replace("-", string.Empty);

            int index = GetHexValue(hexString[hexString.Length - 1]);
            Update(result, index, hexString[0]);

            for (int i = 1; i < hexString.Length; i++)
            {
                index = GetHexValue(hexString[i - 1]);
                Update(result, index, hexString[i]);
            }

            /// I invert the array because I wanted the hash to be read from right to left,
            /// but there is really no need to do this...
            Array.Reverse(result);
            return string.Concat(result.Select(x => x.ToString("X")).ToArray()).TrimStart(new char[] { '0' });
        }

        /// <summary>
        /// This function updates a position in the array. I had to extract this logic from 'Calculate' so I
        /// could make it recursive in case there was an overflow
        /// </summary>
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

        private static string GeneratePadding(string value)
        {
            if (value.Length == 16)
            {
                return value;
            }

            var neededPadding = 16 - value.Length;
            var padding = value;

            while (padding.Length <= neededPadding)
            {
                padding += InvertString(Calculate(Math.Log10(GetHexValue(padding[0]) * neededPadding).ToString()));
            }

            return padding.Substring(0, neededPadding) + value;
        }

        /// <summary>
        /// This used to invert the result and the padding, but decided that using 'Array.Reverse()' would
        /// be better for the result. Now just the padding uses it and might as well remove it
        /// </summary>
        private static string InvertString(string value)
        {
            char[] charArray = value.ToCharArray();
            Array.Reverse(charArray);
            return new string(charArray);
        }

        private static int GetHexValue(char value)
        {
            return int.Parse(value.ToString(), NumberStyles.HexNumber);
        }

        /// <summary>
        /// Add two integers together. The result is a int representation of an hex number.
        /// If there was an overflow, it returns the excess.
        /// </summary>
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

    /// <summary>
    /// The purpose of this class is to make it easier to handle the overflow when adding two hex numbers
    /// </summary>
    public class HexaResult
    {
        public int result;
        public char excess;
        public bool overflow;
    }
}
