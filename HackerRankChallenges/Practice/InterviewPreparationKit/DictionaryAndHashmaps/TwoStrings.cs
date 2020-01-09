using System;
using System.Collections.Generic;
using System.Text;

namespace HackerRankChallenges.Practice.InterviewPreparationKit.DictionaryAndHashmaps
{
    //https://www.hackerrank.com/challenges/two-strings/problem
    class TwoStrings
    {
        // Complete the twoStrings function below.
        // Given two strings, determine if they share a common substring
        static string twoStrings(string s1, string s2)
        {
            var s1HashSet = new HashSet<char>(s1);
            var s2HashSet = new HashSet<char>(s2);

            foreach (var item in s1HashSet)
            {
                if (s2HashSet.Contains(item))
                    return "YES";
            }
            return "NO";
        }

        /* BENCHMARK COMPARISON BETWEEN ARRAY X HASHSET
            for STRING.SIZE() = 100.000
            TIME WITH HAShSET: 00:00:00.0505917 good
            TIME WITH ARRAY: 00:00:08.0506651   bad ;)
         */
    }
}
