using System;
using System.Collections.Generic;
using System.Text;

namespace HackerRankChallenges.Practice.InterviewPreparationKit.Sorting
{
    //https://www.hackerrank.com/challenges/mark-and-toys/problem
    class MarkAndToys
    {
        // Complete the maximumToys function below.
        static int maximumToys(int[] prices, int k)
        {
            int maximumToys = 0;
            long totalSpent = 0;
            var orderedPrices = prices.OrderBy(p => p);

            foreach (var price in orderedPrices)
            {
                totalSpent += price;
                if (totalSpent > k)
                {
                    break;
                }
                maximumToys++;
            }

            return maximumToys;
        }
    }
}
