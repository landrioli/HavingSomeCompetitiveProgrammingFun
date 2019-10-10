﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace HackerRankChallenges
{
    public class Program
    {
        // First Attemps -> Your code did not execute within the time limits
        static void checkMagazine2(string[] magazine, string[] note)
        {
            for (int i = 0; i < note.Length; i++)
            {
                if (!magazine.Contains(note[i]))
                {
                    Console.WriteLine("No");
                    return;
                }
                magazine[i] = string.Empty;
            }
            Console.WriteLine("Yes");
        }
        static void checkMagazine(string[] magazine, string[] note)
        {
            var magazineDic = new Dictionary<string, int>();
            for (int i = 0; i < magazine.Length; i++)
            {
                if (magazineDic.ContainsKey(magazine[i]))
                {
                    magazineDic[magazine[i]]++;
                }
                else
                {
                    magazineDic.Add(magazine[i], 1);
                }
            }

            for (int i = 0; i < note.Length; i++)
            {
                int totalOcurrencies = 0;
                magazineDic.TryGetValue(note[i], out totalOcurrencies);
                if (totalOcurrencies == 0)
                {
                    Console.WriteLine("No");
                    return;
                }
                magazineDic[note[i]]--;
            }
            Console.WriteLine("Yes");
        }

        static void Main(string[] args)
        {
            checkMagazine(new string[] { "a", "b", "a" }, new string[] { "a", "b", "a" });
            checkMagazine(new string[] { "casa teste" }, new string[] { "casa" });
            checkMagazine(new string[] { "two", "times", "three", "is", "not", "four" }, new string[] { "two", "times", "two", "is", "four" });
            
        }
    }
}
