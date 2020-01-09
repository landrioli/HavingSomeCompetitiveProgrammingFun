using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HackerRankChallenges.Practice.Algorithm.Strings
{
    /* https://www.hackerrank.com/challenges/special-palindrome-again/problem
    A string is said to be a special string if either of two conditions is met:
        All of the characters are the same, e.g. aaa.
        All characters except the middle one are the same, e.g. aadaa.
    A special substring is any substring of a string which meets one of those criteria. 
    Given a string, determine how many special substrings can be formed from it.
    */
    class SpecialStringAgain
    {

        // Complete the substrCount function below.
        // The number of possible substrings is EX: abc = 3 => 3! => 3 + 2 + 1 = 6 substrings => n(n+1)/2
        // The number of possible combinations is EX: abcd = 2^N = 2^4 = 16
        // Brute force is not possible... So I will find all the ocurrencies and calculate how many substrings a can generate for the sequence ( repeats * (repeats + 1) / 2)
        static long substrCountBadPerf(int n, string s)
        {
            long specialStrings = 0;
            List<string> allSubstrings = ExtractAllSubstrings(s);
            foreach (var item in allSubstrings)
            {
                var letters = item.ToCharArray();
                char expectedChar = letters[0];
                bool isValid = true;
                for (int i = 0; i < letters.Length / 2; i++)
                {
                    if (letters[i] != expectedChar || letters[item.Length - 1 - i] != expectedChar)
                    {
                        isValid = false;
                        break;
                    }
                }
                if (isValid)
                {
                    specialStrings++;
                }
            }

            return specialStrings;
        }

        public static long substrCount(int length, string s1)
        {
            long counter = 0;
            var s = s1.ToCharArray();
            for (int i = 0; i < s.Length; i++)
            {
                // if the current symbol is in the middle of palindrome, e.g. aba
                // Necessary while because aabaa means 2 counters...
                int offset = 1;
                while (i - offset >= 0 &&  //Não pode ser o primeiro caracter
                        i + offset < s.Length && //Não pode ser o ultimo caracter
                        s.ElementAt(i - offset) == s.ElementAt(i - 1) && //o anterior precisam ser iguais
                        s.ElementAt(i + offset) == s.ElementAt(i - 1)) //o próximo precisam ser iguais
                {
                    counter++;
                    offset++;
                }
                // if this is repeatable characters aa
                int repeats = 0;
                while (i + 1 < s.Length && s.ElementAt(i) == s.ElementAt(i + 1))
                {
                    repeats++;
                    i++;
                }
                counter += repeats * (repeats + 1) / 2;
            }
            return counter + s.Length;
        }


        private static List<string> ExtractAllSubstrings(string s)
        {
            List<string> substrings = new List<string>();
            for (int i = 0; i < s.Length; i++)
            {
                for (int j = 1; j <= s.Length - i; j++)
                {
                    substrings.Add(s.Substring(i, j));
                }
            }
            return substrings;
        }
    }
}
