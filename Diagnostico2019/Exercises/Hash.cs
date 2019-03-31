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
            int[] result = new int[16];
            byte[] ba = Encoding.Default.GetBytes("sample");
            var hexString = BitConverter.ToString(ba).Replace("-", string.Empty);

            for (int i = 0; i < hexString.Length; i++)
            {
                if (i == 0)
                {
                    int index = GetHexValue(hexString[hexString.Length - 1]);
                    var hexResult = AddTwoHexa(result[index], GetHexValue(hexString[i]));
                    result[index] = hexResult.result;
                }
                else
                {
                    int index = GetHexValue(hexString[i - 1]);
                    Update(result, index, hexString[i]);
                }
            }

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
