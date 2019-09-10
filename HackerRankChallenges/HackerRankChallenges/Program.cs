using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace HackerRankChallenges
{
    public class Program
    {
        public static void Main(string[] args)
        {
            TextWriter textWriter = new StreamWriter(@System.Environment.GetEnvironmentVariable("OUTPUT_PATH"), true);

            List<int> a = Console.ReadLine().TrimEnd().Split(' ').ToList().Select(aTemp => Convert.ToInt32(aTemp)).ToList();

            List<int> b = Console.ReadLine().TrimEnd().Split(' ').ToList().Select(bTemp => Convert.ToInt32(bTemp)).ToList();

            List<int> result = compareTriplets(a, b);

            textWriter.WriteLine(String.Join(" ", result));

            textWriter.Flush();
            textWriter.Close();
        }

        static List<int> compareTriplets(List<int> a, List<int> b)
        {
            var result = new List<int>();
            int alicePoints = 0;
            int bobPoints = 0;

            for (int i = 0; i < a.Count; i++)
            {
                if (a[i] > b[i])
                    alicePoints++;
                else if (a[i] < b[i])
                    bobPoints++;
            }

            result.Add(alicePoints);
            result.Add(bobPoints);

            return result;
        }
    }
}
