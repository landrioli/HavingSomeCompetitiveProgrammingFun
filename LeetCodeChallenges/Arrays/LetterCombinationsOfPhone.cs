using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Test
{
	//https://leetcode.com/problems/letter-combinations-of-a-phone-number
	//Given a string containing digits from 2-9 inclusive, return all possible letter combinations that the number could represent.
	//A mapping of digit to letters (just like on the telephone buttons) is given below. Note that 1 does not map to any letters.
    public class LetterCombinations
    {				
        public IList<string> LetterCombinationsIterative(string number)
        {
             List<String> list = new List<String>();

             if (string.IsNullOrEmpty(number))
                 return list;

            String[] table = { "", "", "abc", "def", "ghi", "jkl",  
                           "mno", "pqrs", "tuv", "wxyz" };

           
            Queue<String> q = new Queue<String>();
            q.Enqueue("");

            while (q.Count != 0)
            {
                String s = q.Dequeue();
                // If complete word is generated push it in the list 
                if (s.Length == number.Length)
                    list.Add(s);
                else
                {
                    String val = table[number[s.Length]-'0'];
                    for (int i = 0; i < val.Length; i++)
                    {
                        q.Enqueue(s + val[i]);
                    }
                }
            }
            return list;
        }

        public List<String> LetterCombinationsRecursive(string digits)
        {
            var ret = new List<String>();
            LetterCombinationsRecursive("", digits, 0, ret);
            return ret;
        }
        IList<string> LetterCombinationsRecursive(string prefix, string digits, int offset, List<String> list)
        {
            String[] table = { "", "", "abc", "def", "ghi", "jkl", "mno", "pqrs", "tuv", "wxyz" };

            if (prefix.Length == digits.Length)
                list.Add(prefix);
            else
            {
                string values = table[digits[offset] - '0'];
                for (int i = 0; i < values.Length; i++)
                {
                    LetterCombinationsRecursive(prefix + values[i], digits, offset + 1, list);
                }
            }
            return list;
        } 
    }
}
