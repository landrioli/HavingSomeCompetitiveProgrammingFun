using System;
using System.Collections.Generic;
using System.Text;

namespace LeetCodeChallenges.AMZ
{
    public class LongestSubstringWithNoDuplicates
    {
        public int LengthOfLongestSubstring(string s)
        {
            var dict = new Dictionary<char, int>(); //dict of letter and las seen position
            var position = new KeyValuePair<int, int>(0, 0); //begin, end
            var startIndex = 0;
            for (int i = 0; i < s.Length; i++)
            {
                var currentChar = s[i];
                if (dict.ContainsKey(currentChar))
                    startIndex = Math.Max(startIndex, dict[currentChar] + 1);

                var currentMaxSize = position.Value - position.Key;
                if (currentMaxSize < i + 1 - startIndex)
                    position = new KeyValuePair<int, int>(startIndex, i + 1);

                dict[currentChar] = i;
            }
            Console.WriteLine(s.Substring(position.Key, position.Value - position.Key));
            return position.Value - position.Key;
        }

        public string ContentOfLongestSubstring(string s)
        {
            var dict = new Dictionary<char, int>(); //dict of letter and las seen position
            var position = new KeyValuePair<int, int>(0, 0); //begin, end
            var startIndex = 0;
            for (int i = 0; i < s.Length; i++)
            {
                var currentChar = s[i];
                if (dict.ContainsKey(currentChar))
                    startIndex = Math.Max(startIndex, dict[currentChar] + 1);

                var currentMaxSize = position.Value - position.Key;
                if (currentMaxSize < i + 1 - startIndex)
                    position = new KeyValuePair<int, int>(startIndex, i + 1);

                dict[currentChar] = i;
            }

            return s.Substring(position.Key, position.Value - position.Key);
        }

        public void Main()
        {
            LengthOfLongestSubstring("abcabsh");
        }
    }
}
