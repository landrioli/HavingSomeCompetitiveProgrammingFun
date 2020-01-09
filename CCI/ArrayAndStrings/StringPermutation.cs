using System;
using System.Collections.Generic;
using System.Text;

namespace CCIChallenges.ArrayAndStrings
{
    //Check Permutation: Given two strings, write a method to decide if one is a permutation of the other.
    public class StringPermutation
    {
        public static bool Permutation(string s, string t)
        {
            if (s.Length != t.Length)
            {
                return false;
            }

            int[] letters = new int[128];
            char[] s_array = s.ToCharArray();
            foreach (char c in s_array) //count number of each char i n s.
            {
                letters[c]++;
            }

            for (int i = 0; i < t.Length; i++)
            {
                int c = (int)t[i];
                letters[c]--;
                if (letters[c] < 0)
                {
                    return false;
                }
            }

            return true;
        }
    }
}
