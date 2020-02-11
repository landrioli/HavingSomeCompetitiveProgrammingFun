using System;
using System.Collections.Generic;
using System.Text;

namespace LeetCodeChallenges.Arrays
{
    public class NumbersAndLettersCombination
    {

        private static string[] KEYS = { "", "", "abc", "def", "ghi", "jkl", "mno", "pqrs", "tuv", "wxyz" };

        public List<string> LetterCombinationRecursive(string digits)
        {
            var ret = new List<string>();
            CombinationRecursive("", digits, 0, ret);
            return ret;
        }

        private void CombinationRecursive(string prefix, string digits, int offset, List<string> ret)
        {
            if (offset >= digits.Length)
            {
                ret.Add(prefix);
                return;
            }
            var letters = KEYS[(digits[offset]) - '0']; //digits.charAt(offset)'s return type is char.For instance '1', '2', '3'...and so on, so you need to minus '0' to get sequence number whose type is int.
            for (int i = 0; i < letters.Length; i++)
            {
                CombinationRecursive(prefix + letters[i], digits, offset + 1, ret);
            }
        }

        public List<String> LetterCombinationiterative(int[] number)
        {
            // To store the generated letter combinations 
            List<String> list = new List<String>();
            int n = number.Length;
            Queue<String> q = new Queue<String>();
            q.Enqueue("");

            while (q.Count != 0)
            {
                String s = q.Dequeue();

                // If complete word is generated  
                // push it in the list 
                if (s.Length == n)
                    list.Add(s);
                else
                {
                    String val = KEYS[number[s.Length]];
                    for (int i = 0; i < val.Length; i++)
                    {
                        q.Enqueue(s + val[i]);
                    }
                }
            }
            return list;
        }
    }
}
