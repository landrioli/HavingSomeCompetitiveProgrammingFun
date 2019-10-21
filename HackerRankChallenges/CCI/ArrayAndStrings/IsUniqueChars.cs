using System;

namespace CCI.ArrayAndStrings
{
    public class IsUniqueChars
    {
        //Implement an algorithm to determine if a string has all unique characters. What if you
        //cannot use additional data structures?
        public static bool IsUnique(string str)
        {
            if (str.Length > 128) return false;

            bool[] char_set = new bool[128];
            for (int i = 0; i < str.Length; i++)
            {
                int val = str[i];
                if (char_set[val]) //Already found this char in string
                {
                    return false;
                }
                char_set[val] = true;
            }
            return true;
        }
    }
}
