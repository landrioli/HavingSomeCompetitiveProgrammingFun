using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Test
{
    public class IsPalindrome
    {
		//https://leetcode.com/problems/valid-palindrome/
        //Given a string, determine if it is a palindrome, considering only alphanumeric characters and ignoring cases.
        public bool IsPalindromeMethod(string s)
        {
            var set = new HashSet<char> { 'a', 'b', 'c', 'd', 'e', 'f', 'g', 'h', 'i', 'j', 'k', 'l', 'm', 'n', 'o', 'p', 'q', 
                'r', 's', 't', 'u', 'v', 'w', 'x', 'y', 'z', '0', '1', '2', '3', '4', '5', '6', '7', '8', '9'};
            if (string.IsNullOrEmpty(s))
                return true; 

            var split = s.ToCharArray();
            int i = 0;
            int j = split.Length - 1;
            while(i < split.Length / 2)
            {
                var iChar = char.ToLower(split[i]);
                var jChar = char.ToLower(split[j]);
                if (!set.Contains(iChar))
                {
                    i++;
                    continue;
                }
                else if (!set.Contains(jChar))
                {
                    j--;
                    continue;
                }
                else if (iChar != jChar)
                    return false;
                i++;
                j--;
            }
            return true; 
        }
    }
}
