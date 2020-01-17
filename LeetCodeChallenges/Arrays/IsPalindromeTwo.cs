using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Test
{
    public class IsPalindromeTwo
    {
		//https://leetcode.com/problems/valid-palindrome-ii/
        //Given a non-empty string s, you may delete at most one character. Judge whether you can make it a palindrome.
        public bool ValidPalindrome(string s)
        {
            {
                for (int i = 0; i < s.Length / 2; i++)
                {
                    if (s[i] != s[s.Length - 1 - i])
                    {
                        int j = s.Length - 1 - i;
                        return (IsPalindromeRange(s, i + 1, j) ||
                                IsPalindromeRange(s, i, j - 1));
                    }
                }
                return true;
            }
        }

        public bool IsPalindromeRange(string s, int i, int j)
        {
            for (int k = i; k <= i + (j - i) / 2; k++)
            {
                if (s[k] != s[j - k + i]) return false;
            }
            return true;
        }

    }
}
