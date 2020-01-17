using System;
using System.Collections.Generic;
using System.Text;

namespace LeetCodeChallenges.Arrays
{
    public static class ConvertIntegerToRomanNumber
    {
        public static string IntToRoman(int num)
        {
            int[] values = { 1000, 900, 500, 400, 100, 90, 50, 40, 10, 9, 5, 4, 1 };
            String[] strs = { "M", "CM", "D", "CD", "C", "XC", "L", "XL", "X", "IX", "V", "IV", "I" };

            StringBuilder sb = new StringBuilder();

            for (int i = 0; i < values.Length; i++)
            {
                while (num >= values[i])
                {
                    num -= values[i];
                    sb.Append(strs[i]);
                }
            }
            return sb.ToString();
        }
    }
}
