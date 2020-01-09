using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestConsole
{
    //https://www.hackerrank.com/challenges/sherlock-and-valid-string
    class SherlockAndValidStrings
    {
        static String isValidManually(String s)
        {
            String GOOD = "YES";
            String BAD = "NO";

            if (s.Length <= 3) return GOOD;

            int[] letters = new int[26];
            //ArrayFreq ordenado
            for (int j = 0; j < s.Length; j++)
            {
                letters[s[j] - 'a']++;
            }
            Array.Sort(letters);

            //Position of the smallest
            int i = 0;
            while (letters[i] == 0)
            {
                i++;
            }
            //System.out.println(Arrays.toString(letters));
            int min = letters[i];   //the smallest frequency of some letter
            int max = letters[25]; // the largest frequency of some letter
            String ret = BAD;
            if (min == max) ret = GOOD;
            else
            {
                // remove one letter at higher frequency or the lower frequency 
                if (((max - min == 1) && (max > letters[24])) ||
                    (min == 1) && (letters[i + 1] == max))
                    ret = GOOD;
            }
            return ret;
        }

        // O(numberOfLetters log(n)) === O(n)
        static string isValid(string s)
        {
            var charArray = s.ToCharArray();
            var frequencyDictionary = BuildDictionary(charArray);
            int allowedExceptions = 1;
            if (s.Count() <= 3)
            {
                return "YES";
            }

            var ordered = frequencyDictionary.OrderBy(p => p.Value);
            var max = frequencyDictionary.First().Value;
            var min = frequencyDictionary.Last().Value;

            if (max == min)
            {
                return "YES";
            }
            if (min - 1 == 0 && ordered.ElementAt(1).Value == max)
            {
                return "YES";
            }
            if (max - min == 1 && ordered.ElementAt(frequencyDictionary.Count - 1 - 1).Value == min)
            {
                return "YES";
            }

            return "NO";
        }

        static Dictionary<char, int> BuildDictionary(char[] arr)
        {
            var listDic = new Dictionary<char, int>();
            foreach (var number in arr)
            {
                if (listDic.ContainsKey(number))
                {
                    listDic[number]++;
                }
                else
                {
                    listDic.Add(number, 1);
                }
            }
            return listDic;
        }
    }
}
