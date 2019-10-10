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
        // Complete the twoStrings function below.
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

        // Complete the twoStrings function below.
        static string twoStringsChar(string s1, string s2)
        {
            var s1HashSet = s1.ToCharArray();
            var s2HashSet = s2.ToCharArray();

            foreach (var item in s1HashSet)
            {
                if (s2HashSet.Contains(item))
                    return "YES";
            }
            return "NO";
        }


        static void Main(string[] args)
        {
            var a = new StringBuilder();
            for (int i = 0; i < 100000; i++)
            {
                a.Append("a");
            }
            a.Append("b");
            var b = new StringBuilder();
            for (int i = 0; i < 100000; i++)
            {
                b.Append("b");
            }

            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();
            Console.WriteLine(twoStrings(a.ToString(), b.ToString()));
            stopwatch.Stop();
            Console.WriteLine("TIME WITH HASSET: {0}", stopwatch.Elapsed);

            Stopwatch stopwatch2 = new Stopwatch();
            stopwatch2.Start();
            Console.WriteLine(twoStringsChar(a.ToString(), b.ToString()));

            stopwatch2.Stop();
            Console.WriteLine("TIME WITH CHAR ARRAY: {0}", stopwatch2.Elapsed);
        }
    }
}
