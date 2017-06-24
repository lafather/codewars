using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
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

        public static int BinaryArrayToNumber(int[] binaryArray)
        {
            var result = 0;
            var length = binaryArray.Length;

            for (int i = length - 1; i >= 0; i--)
            {
                result += binaryArray[i] * (int)Math.Pow(2, length - i - 1);
            }

            return result;
        }

        public static int GetLengthOfMissingArray(object[][] arrayOfArrays)
        {
            if (arrayOfArrays == null || !arrayOfArrays.Any() || arrayOfArrays.Any(x => x == null || !x.Any()))
            {
                return 0;
            }

            var countOfArrays = arrayOfArrays.Count();
            var minLength = arrayOfArrays.Min(x => x.Length);
            var maxLength = arrayOfArrays.Max(y => y.Length);
            var expectedSumOfLengths = (minLength + maxLength) * (countOfArrays + 1) / 2;
            var actualSumOfLengths = arrayOfArrays.Sum(arr => arr.Length);

            return expectedSumOfLengths - actualSumOfLengths;
        }

        public static string RevRot(string str, int sz)
        {
            return 
                string.IsNullOrEmpty(str) || sz <= 0 || sz > str.Length 
                    ? string.Empty 
                    : string.Join(
                        string.Empty, 
                        str.GetChunks(sz).Select(RotateOrReverse));
        }

        public static string ToCamelCase(string str)
        {            
            var words = str.Split('-', '_');

            return words.Skip(1).Aggregate(new StringBuilder(words.First()), (x, y) => x.Append(y.Capitalize())).ToString();
        }

        public static int BouncingBall(double h, double bounce, double window)
        {
            return 
                h > 0 && bounce > 0 && bounce < 1 && window < h 
                    ? 1 + 2 * (int)Math.Ceiling(Math.Log(window / h) / Math.Log(bounce) - 1) 
                    : -1;
        }

        public static bool IsMerge(string s, string part1, string part2)
        {
            var wordStatistics = s.GetLettersStatistics();
            var partsStatistics = part1.GetLettersStatistics().Merge(part2.GetLettersStatistics());
            var primaryValidation = !wordStatistics.Any(x => !partsStatistics.ContainsKey(x.Key) || x.Value != partsStatistics[x.Key]);

            return primaryValidation && part1.IsOrderOfLettersCorrect(s) && part2.IsOrderOfLettersCorrect(s);
        }

        #region String extensions
        private static IEnumerable<string> GetChunks(this string str, int size)
        {
            var result = new List<string>();

            for (int i = 0; i < str.Length / size; i++)
            {
                result.Add(str.Substring(i * size, size));
            }

            return result;
        }

        private static int GetSumOfCubes(this string input)
        {
            return input.Sum(x => (int)Math.Pow(int.Parse(x.ToString()), 3));
        }

        private static string RotateOrReverse(string chunk)
        {
            return (chunk.GetSumOfCubes() & 1) == 0 ? chunk.Reverse() : chunk.Rotate(true, 1);
        }

        private static IEnumerable<string> GraphemeClusters(this string s)
        {
            var enumerator = StringInfo.GetTextElementEnumerator(s);

            while (enumerator.MoveNext())
            {
                yield return (string)enumerator.Current;
            }
        }

        private static string Reverse(this string s)
        {
            return string.Join(string.Empty, s.GraphemeClusters().Reverse().ToArray());
        }

        private static string Rotate(this string s, bool left, int positions)
        {
            var insertionUndex = left ? s.Length - positions : 0;
            var subStringStartIndex = left ? 0 : s.Length - positions;
            var subString = s.Substring(subStringStartIndex, positions);

            return new StringBuilder(s).Remove(subStringStartIndex, positions).Insert(insertionUndex, subString).ToString();
        }

        private static string Capitalize(this string input)
        {
            return 
                new StringBuilder(input)
                    .Replace(
                        input.First(), 
                        input.First().ToString().ToUpper().ToCharArray().First(), 
                        0, 
                        1)
                    .ToString();
        }

        private static IDictionary<char, int> GetLettersStatistics(this string str)
        {
            return str.GroupBy(x => x).ToDictionary(y => y.Key, z => z.Count());
        }

        private static bool IsOrderOfLettersCorrect(this string input, string str)
        {
            var previousIndex = 0;
            var newIndex = 0;

            foreach (var letter in input)
            {
                newIndex = str.IndexOf(letter, previousIndex);

                if (newIndex == -1)
                {
                    return false;
                }

                previousIndex = ++newIndex;
            }

            return true;
        }
        #endregion

        #region Dictionary extensions
        private static IDictionary<T, int> Merge<T>(this IDictionary<T, int> dict1, IDictionary<T, int> dict2)
        {
            var result = new Dictionary<T, int>();

            foreach (var pair in dict1.Where(x => dict2.ContainsKey(x.Key)))
            {
                result.Add(pair.Key, pair.Value + dict2[pair.Key]);
            }

            foreach (var pair in dict1.Where(x => !dict2.ContainsKey(x.Key)).Concat(dict2.Where(x => !dict1.ContainsKey(x.Key))))
            {
                result.Add(pair.Key, pair.Value);
            }

            return result;
        }
        #endregion
    }
}
