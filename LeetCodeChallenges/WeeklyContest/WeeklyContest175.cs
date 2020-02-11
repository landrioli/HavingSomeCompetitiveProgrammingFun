using System;
using System.Collections.Generic;
using System.Text;

namespace LeetCodeChallenges.WeeklyContest
{
    public class WeeklyContest175
    {
        //https://leetcode.com/contest/weekly-contest-175/problems/check-if-n-and-its-double-exist/
        //Given an array arr of integers, check if there exists two integers N and M such that N is the double of M ( i.e. N = 2 * M).
        public bool CheckIfExist(int[] arr)
        {
            for (int i = 0; i < arr.Length; i++)
            {
                for (int j = 0; j < arr.Length; j++)
                {
                    if (i != j && arr[i] == arr[j] * 2)
                        return true;
                }
            }
            return false;
        }

        //https://leetcode.com/contest/weekly-contest-175/problems/minimum-number-of-steps-to-make-two-strings-anagram/
        //Given two equal-size strings s and t. In one step you can choose any character of t and replace it with another character.
        //Return the minimum number of steps to make t an anagram of s.
        ////An Anagram of a string is a string that contains the same characters with a different(or the same) ordering.
        public int MinSteps(string s, string t)
        {
            if(s.Length != t.Length)
                throw new ArgumentException();

            int totalChanges = 0;
            var frequencyS = new Dictionary<char, int>();
            var frequencyT = new Dictionary<char, int>();

            for (int i = 0; i < s.Length; i++)
                AddToFrequencyMap(frequencyS, s[i]);

            for (int i = 0; i < s.Length; i++)
                AddToFrequencyMap(frequencyT, t[i]);

            foreach (var entry in frequencyS)
            {
                if (frequencyT.ContainsKey(entry.Key))
                {
                    if (entry.Value > frequencyT[entry.Key])
                        totalChanges += entry.Value - frequencyT[entry.Key];
                }
                else //If do not contains I need to add the full value of changes
                {
                    totalChanges += entry.Value;
                }
            }

            return totalChanges;
        }
        private void AddToFrequencyMap(Dictionary<char, int> frequency, char c)
        {
            if (frequency.ContainsKey(c))
                frequency[c] += 1;
            else
                frequency.Add(c, 1);
        }
        

        public void Main()
        {
            //CheckIfExist(new int[7] { -2, 0, 10, -19, 4, 6, -8 });
            MinSteps("leetcode", "practice");
        }
    }
}
