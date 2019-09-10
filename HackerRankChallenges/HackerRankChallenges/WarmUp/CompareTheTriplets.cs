using System;
using System.Collections.Generic;
using System.Text;

namespace HackerRankChallenges.WarmUp
{
    //https://www.hackerrank.com/challenges/compare-the-triplets/problem
    public class CompareTheTriplets
    {
        // Complete the compareTriplets function below.
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

        static List<int> compareTripletsTwo(List<int> a, List<int> b)
        {
            var result = new List<int>();

            int alicePoints = ((a[0] > b[0]) ? 1 : 0) + ((a[1] > b[1]) ? 1 : 0) + ((a[2] > b[2]) ? 1 : 0);
            int bobPoints = ((a[0] < b[0]) ? 1 : 0) + ((a[1] < b[1]) ? 1 : 0) + ((a[2] < b[2]) ? 1 : 0);

            result.Add(alicePoints);
            result.Add(bobPoints);

            return result;
        }
    }
}
