using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HackerRankChallenges.Practice.InterviewPreparationKit.DictionaryAndHashmaps
{
    class RansomNoteChallenge
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

        //Improving perfomance 
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

            var noteDic = new Dictionary<string, int>();
            for (int i = 0; i < note.Length; i++)
            {
                if (noteDic.ContainsKey(note[i]))
                {
                    noteDic[note[i]]++;
                }
                else
                {
                    noteDic.Add(note[i], 1);
                }
            }

            foreach (var item in noteDic)
            {
                int totalMagazineOcurrencies = 0;
                magazineDic.TryGetValue(item.Key, out totalMagazineOcurrencies);
                if (totalMagazineOcurrencies < item.Value)
                {
                    Console.WriteLine("No");
                    return;
                }
            }
            Console.WriteLine("Yes");
        }
    }
}
