using CCI.ArrayAndStrings;
using CCIChallenges.ArrayAndStrings;
using CCIChallenges.BinaryTree;
using CCIChallenges.Graph;
using CCIChallenges.LinkedList;
using CCIChallenges.MathAndPuzzles;
using CCIChallenges.RecursiveAndDynamicProgramming;
using CCIChallenges.SearchAndSort;
using CCIChallenges.Stack;
using CCIChallenges.SystemDesignAndScalability;
using CCIChallenges.Tree;
using GeneralChallenges;
using GeneralChallenges.Codility;
using HackerRankChallenges.Practice.InterviewPreparationKit.QueueAndStack;
using LeetCodeChallenges.Arrays;
using LeetCodeChallenges.BiWeeklyContext;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using HackerRankChallenges.Practice.Algorithm.Implementation;
using LeetCodeChallenges.WeeklyContest;
using TestConsole;
using UdemyMCI.Array;
using UdemyMCI.Dictionary;
using UdemyMCI.LinkedList;
using static CCIChallenges.BinaryTree.BreadthFirstSearch;

namespace HackerRankChallenges
{
    public class Program
    {
        static void Main(string[] args)
        {
            LongestPalindromeInstring.LongestPalindrome("babad");
            //new ClimbingTheLeaderboard().climbingLeaderboard(new int[7] { 100, 100, 50, 40, 40, 20, 10 },
            //    new int[4] { 2,25, 50, 120 });
        }

        // Function to generate all binary strings 
        static void generateAllBinaryStrings(int n,
                                int[] arr, int i, List<string> finalList)
        {
            if (i == n)
            {
                //printTheArray(arr, n);
                StringBuilder result = new StringBuilder();
                for (int j = 0; j < n; j++)
                {
                    result.Append(arr[j]);
                }
                finalList.Add(result.ToString());
                return;
            }

            // First assign "0" at ith position 
            // and try for all other permutations 
            // for remaining positions 
            arr[i] = 0;
            generateAllBinaryStrings(n, arr, i + 1, finalList);

            // And then assign "1" at ith position 
            // and try for all other permutations 
            // for remaining positions 
            arr[i] = 1;
            generateAllBinaryStrings(n, arr, i + 1, finalList);
        }

        public IList<string> GenerateSentences(List<List<string>> synonyms, string text)
        {
            HashSet<string> hash = new HashSet<string>();
            foreach (var item in synonyms)
            {
                hash.Add(item[0]);
                hash.Add(item[1]);
            }

            List<string> matchedWords = new List<string>();
            var phrase = text.Split(' ');
            foreach (var word in phrase)
            {
                if (hash.Contains(word))
                {
                    matchedWords.Add(word);
                }
            }

            IList<string> finalPhrases = new List<string>();
            foreach (var matchedWord in matchedWords)
            {
                foreach (var synonym in hash)
                {
                    string finalResultPhrase = text.Replace(matchedWord, synonym);
                    finalPhrases.Add(finalResultPhrase);
                }
            }

            return finalPhrases as IList<string>;
        }
    }
}
