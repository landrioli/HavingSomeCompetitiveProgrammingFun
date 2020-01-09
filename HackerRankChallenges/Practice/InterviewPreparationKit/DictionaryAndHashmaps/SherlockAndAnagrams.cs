using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestConsole
{
    /*
     Two strings are anagrams of each other if the letters of one string can be rearranged to form the other string.
     Given a string, find the number of pairs of substrings of the string that are anagrams of each other.

        PS:What's the easiest way of checking if two words are anagrams? We could count the occurrences of the
        distinct characters in each string and return true if they match. Or, we could just sort the string. After all,
        two words which are anagrams will look the same once they're sorted. In this case we will sort.
         */
    public class SherlockAndAnagrams
    {
        static int SherlockAndAnagramsMethod(string s)
        {
            var dic = new Dictionary<string, int>();
            var count = 0;
            var substrings = GetSubstrings(s);

            foreach (var substring in substrings)
            {
                Console.WriteLine(substring);

                if (dic.ContainsKey(substring))
                {
                    var value = dic[substring];
                    count += value;

                    dic[substring] = value + 1;
                }
                else
                {
                    dic.Add(substring, 1);
                }
            }

            return count;
        }

        static IEnumerable<string> GetSubstrings(string s)
        {
            var listPairs = new List<string>();

            for (var i = 0; i < s.Length; i++)
            {
                for (var j = 1; j <= s.Length - i; j++)
                {
                    var substring = s.Substring(i, j);
                    var chars = substring.ToCharArray();
                    // The jump of the gat - order so you do not need to deal with format each key after to comparison
                    Array.Sort(chars);

                    listPairs.Add(new string(chars));
                }
            }
            return listPairs;
        }
    }
}
