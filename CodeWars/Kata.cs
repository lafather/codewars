using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeWars
{
    public static class Kata
    {
        public static string Disemvowel(string str)
        {
            var vowels = new[] { 'a', 'e', 'i', 'o', 'u', 'A', 'E', 'I', 'O', 'U' };

            return string.Join(string.Empty, str.Split(vowels));
        }

        public static int FindParityOutlier(int[] integers)
        {
            if (integers[0] % 2 != integers[1] % 2)
            {
                return integers[2] % 2 == integers[0] % 2 ? integers[1] : integers[0];
            }

            for (int i = 0; i < integers.Length; i++)
            {
                var value = integers[i];

                integers[i] &= 1;

                if (i > 0 && (integers[i] + integers[i-1]) % 2 == 1)
                {
                    return value;
                }
            }

            return integers[0];
        }

        public static bool XsAndOs(string input)
        {
            var builder = new StringBuilder(input);
            var inputWithoutXs = builder.Replace("x", string.Empty).Replace("X", string.Empty);
            var lengthWithoutXs = inputWithoutXs.Length;
            var inputWithoutXsAndOs = inputWithoutXs.Replace("o", string.Empty).Replace("O", string.Empty);
            var lengthWithoutXsAndOs = inputWithoutXsAndOs.Length;

            return input.Length + lengthWithoutXsAndOs == 2 * lengthWithoutXs;
        }

        public static string GetRectangleString(int width, int height)
        {
            var result = new StringBuilder();

            for (int row = 0; row < height; row++)
            {
                for (int column = 0; column < width; column++)
                {
                    if (row == 0 || row == height - 1 || column == 0 || column == width - 1)
                    {
                        result.Append('*');                        
                    }
                    else
                    {
                        result.Append(' ');
                    }
                }

                result.Append("\r\n");
            }

            return result.ToString();
        }
    }
}
