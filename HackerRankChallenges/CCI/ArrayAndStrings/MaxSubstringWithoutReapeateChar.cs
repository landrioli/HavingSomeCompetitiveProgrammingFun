using System;
using System.Collections.Generic;
using System.Text;

namespace CCIChallenges.ArrayAndStrings
{
    public static class LongestSubstringWithoutReapeateChar
    {

        public static int LengthOfLongestSubstringV1(string s)
        {
            int n = s.Length;
            var set = new HashSet<char>();
            int ans = 0, i = 0, j = 0;
            while (i < n && j < n)
            {
                // try to extend the range [i, j]
                if (!set.Contains(s[j]))
                {
                    set.Add(s[j++]);
                    ans = Math.Max(ans, j - i);
                }
                else
                {
                    set.Remove(s[i++]);
                }
            }
            return ans;
        }

        /*The above solution requires at most 2n steps. In fact, it could be optimized to require only n steps.
         * Instead of using a set to tell if a character exists or not, we could define a mapping of the characters to its index. 
         * Then we can skip the characters immediately when we found a repeated character.
            The reason is that if s[j]s[j] have a duplicate we don't need to increase i little by little. We can skip all the elements 
         */
        public static int LengthOfLongestSubstringOptimized(String s)
        {
            int n = s.Length;
            var map = new Dictionary<char, int>();
            int ans = 0;
            // try to extend the range [i, j]
            for (int j = 0, i = 0; j < n; j++)
            {
                if (map.ContainsKey(s[j]))
                {
                    i = Math.Max(map[s[j]], i);
                }
                ans = Math.Max(ans, j - i + 1);
                map[s[j]] = j + 1;
            }
            return ans;
        }
    }
}
