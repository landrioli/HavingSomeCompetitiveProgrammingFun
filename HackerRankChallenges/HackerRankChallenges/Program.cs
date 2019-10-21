using CCI.ArrayAndStrings;
using CCIChallenges.ArrayAndStrings;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;

namespace HackerRankChallenges
{
    public class Program
    {
        //https://www.hackerrank.com/challenges/special-palindrome-again/problem
        // Complete the substrCount function below.
        // The number of possible substrings is !N. EX: abc = 3 => 3! => 3 + 2 + 1 = 6 substrings
        static long substrCount(int n, string s)
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

        static void Main(string[] args)
        {
            Console.WriteLine($"Expected 10 -> {substrCount(1, "abcbaba")}");
            Console.WriteLine($"Expected 7 -> {substrCount(1, "asasd")}");
            Console.WriteLine($"Expected 1 -> {substrCount(1, "a")}");

            var value = File.ReadAllText(@"C:\Users\leand\Desktop\posts\automatic\input02.txt");
            Console.WriteLine($"Expected 1272919 -> {substrCount(1, value)}");  
        }

    }
}
