using System;
using System.Collections.Generic;
using System.Text;

namespace HackerRankChallenges.Practice.Algorithm.Implementation
{
    //https://www.hackerrank.com/challenges/bon-appetit/problem
    internal class BonAppetit
    {
        static void bonAppetit(List<int> bill, int k, int b)
        {
            int total = 0;
            //total = bill.Sum(); using linq
            for (int i = 0; i < bill.Count; i++)
            {
                total += bill[i];
            }

            total -= bill[k];

            Console.WriteLine((total / 2) == b ? "Bon Appetit" : (b - (total / 2)).ToString());
        }
    }
}
