using System;
using System.Collections.Generic;
using System.Text;

namespace HackerRankChallenges.Practice.InterviewPreparationKit.Strings
{
    class MakingAnagrams
    {
        private static readonly List<char> alphabet = new List<char>() { 'a', 'b', 'c', 'd', 'e', 'f', 'g', 'h', 'i', 'j', 'k', 'l', 'm', 'n', 'o', 'p', 'q', 'r', 's', 't', 'u', 'v', 'w', 'x', 'y', 'z' };
        
        // Complete the makeAnagram function below.
        static int makeAnagram(string a, string b)
        {
            int totalDel = 0;
            var frequencyA = BuildFrequency(a.ToCharArray());
            var frequencyB = BuildFrequency(b.ToCharArray());

            foreach (var letter in alphabet)
            {
                var letterFrequencyInA = GetValueOrDefault(frequencyA, letter);
                var letterFrequencyInB = GetValueOrDefault(frequencyB, letter);
                totalDel += Math.Abs(letterFrequencyInA - letterFrequencyInB);
            }

            return totalDel;
        }

        private static int GetValueOrDefault(Dictionary<char, int> dict, char letter)
        {
            if (dict.ContainsKey(letter))
            {
                return dict[letter];
            }
            return 0;
        }

        private static Dictionary<char, int> BuildFrequency(char[] arr)
        {
            var frequency = new Dictionary<char, int>();
            for (int i = 0; i < arr.Length; i++)
            {
                if (frequency.ContainsKey(arr[i]))
                {
                    frequency[arr[i]]++;
                }
                else
                {
                    frequency.Add(arr[i], 1);
                }
            }
            return frequency;
        }
    }
}
