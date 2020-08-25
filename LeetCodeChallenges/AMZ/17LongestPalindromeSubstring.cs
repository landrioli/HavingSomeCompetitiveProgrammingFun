using System;
using System.Collections.Generic;
using System.Text;

namespace LeetCodeChallenges.AMZ
{
    public class LongestPalindromeSubstring
    {
        public string LongestPalindrome(string s)
        {
            if (string.IsNullOrEmpty(s))
                return string.Empty;

            var longestPalindrome = new KeyValuePair<int, int>(0, 0);
            for (int i = 0; i < s.Length; i++)
            {
                var odd = GetPalindromeSize(s, i, i);
                var even = GetPalindromeSize(s, i, i + 1);

                var currentLongest = odd.Value - odd.Key < even.Value - even.Key ? even : odd;
                longestPalindrome = longestPalindrome.Value - longestPalindrome.Key < currentLongest.Value - currentLongest.Key ?
                    currentLongest :
                    longestPalindrome;
            }
            return s.Substring(longestPalindrome.Key, longestPalindrome.Value - longestPalindrome.Key + 1);
        }

        public KeyValuePair<int, int> GetPalindromeSize(string input, int left, int right)
        {
            while (left >= 0 && right < input.Length)
            {
                if (input[left] != input[right])
                    break;
                left--;
                right++;
            }
            return new KeyValuePair<int, int>(left + 1, right - 1); //start and end positions
        }

        public void Main()
        {
            LongestPalindrome("babad");
        }

    }
}
