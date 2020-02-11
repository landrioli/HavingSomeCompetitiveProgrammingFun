using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Test
{
    public class RomanToInt
    {
		//https://leetcode.com/problems/roman-to-integer/submissions/
        public int ConvertRomanToInt(string s)
        {
            if (string.IsNullOrEmpty(s))
                return -1;

            int num = 0;
            var dict = new Dictionary<char, int>(){
                {'M', 1000},
                {'D', 500},
                {'L', 50},
                {'C', 100},
                {'X', 10},
                {'V', 5},
                {'I', 1}
            };           
            var split = s.ToCharArray();
            for (int i = 0; i < split.Length; i++)
            {
                if (i == split.Length - 1 || dict[split[i]] >= dict[split[i + 1]])
                {
                    num += dict[split[i]];
                }
                else {
                    num -= dict[split[i]];
                }
            }
            return num;
        }
    }
}
