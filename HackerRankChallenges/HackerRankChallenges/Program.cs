﻿using CCI.ArrayAndStrings;
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
using static CCIChallenges.BinaryTree.BreadthFirstSearch;

namespace HackerRankChallenges
{
    public class Program
    {
        static void Main(string[] args)
        {
            FindMissingNumberSortedArray.Main();
            //var instance = new Program();
            //int n =3;

            //int[] arr = new int[n];
            //var result = new List<List<string>>();
            //result.Add(new List<string> { "happy", "joy" });
            //result.Add(new List<string> { "sad", "sorrow" });
            //result.Add(new List<string> { "joy", "cheerful" });
            //BiWeeklyContextSolutions.generateSentences(result, "I am happy today but was sad yesterday");
            //BiWeeklyContextSolutions.NumberOfWays(6);
            //var result = new List<List<string>>();
            //result.Add(new List<string> { "Earth", "North America", "South America" });
            //result.Add(new List<string> { "North America", "United States", "Canada" });
            //result.Add(new List<string> { "United States", "New York", "Boston" });
            //result.Add(new List<string> { "Canada", "Ontario", "Quebec" });
            //result.Add(new List<string> { "South America","Brazil"});

            //BiWeeklyContextSolutions.FindSmallestRegion(result, "Quebec", "New York");

        }


        public string Encode(int num)
        {
            if (num == 0)
            {
                return string.Empty;
            }

            int countBitSize = 1;
            int total = 2;
            int counter = 2;
            while (num > counter)
            {
                total *= 2;
                counter += total;
                countBitSize++;
            }

            int[] arr = new int[countBitSize];
            var result = new List<string>();
            generateAllBinaryStrings(countBitSize, arr, 0, result);

        
            return result[2];

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
        




        //Dictionary<string, TreeNode> hash = new Dictionary<string, TreeNode>();
        //public string FindSmallestRegion(IList<IList<string>> regions, string region1, string region2)
        //{
        //    //var region1Node = new TreeNode(region1);
        //    //var region2Node = new TreeNode(region2);
        //    //hash.Add(region1);
        //    //hash.Add(region2);
        //    TreeNode previus = null;
        //    foreach (var region in regions)
        //    {
        //        foreach (var local in region)
        //        {
        //            TreeNode node;
        //            if (hash.ContainsKey(local))
        //            {
        //                node = hash[local];
        //            }
        //            else
        //            {
        //                node = new TreeNode(region2);
        //                hash.Add(local, node);
        //            }
        //            if (previus != null)
        //            {
        //                previus.adjacents.Add(node);
        //            }
        //            previus = hash[local];
        //        }
        //    }


        //}
        //public class TreeNode
        //{
        //    public string val;
        //    public List<TreeNode> adjacents;
        //    public TreeNode(string x) { val = x; adjacents = new List<TreeNode>(); }
        //}




        

    }
}
