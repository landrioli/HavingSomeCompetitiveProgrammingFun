using System;
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
            HashSet<string> hash = new HashSet<string>(magazine);

            for (int i = 0; i < note.Length; i++)
            {
                if (!hash.Contains(note[i]))
                {
                    Console.WriteLine("No");
                    return;
                }
                hash.Remove(note[i]);
            }
            Console.WriteLine("Yes");
        }

        static void Main(string[] args)
        {
            checkMagazine(new string[] { "casa" }, new string[] { "Casa" });
            checkMagazine(new string[] { "casa teste" }, new string[] { "casa" });
            checkMagazine(new string[] { "two", "times", "three", "is", "not", "four" }, new string[] { "two", "times", "two", "is", "four" });
            
        }
    }
}
