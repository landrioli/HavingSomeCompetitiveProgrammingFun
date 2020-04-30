using System;
using System.Collections.Generic;
using System.Text;

namespace LeetCodeChallenges._30DaysChallengeCovid
{
    public class DayFiveBestTimeToBuyAndSellStock
    {
        //https://leetcode.com/problems/best-time-to-buy-and-sell-stock-ii/solution/
        public int MaxProfit(int[] prices)
        {
            int maxprofit = 0;
            for (int i = 1; i < prices.Length; i++)
            {
                if (prices[i] > prices[i - 1])
                    maxprofit += prices[i] - prices[i - 1];
            }
            return maxprofit;
        }

        public int MaxProfitBruteForce(int[] prices)
        {
            return Calculate(prices, 0);
        }

        public int Calculate(int[] prices, int s)
        {
            if (s >= prices.Length)
                return 0;
            int max = 0;
            for (int start = s; start < prices.Length; start++)
            {
                int maxprofit = 0;
                for (int i = start + 1; i < prices.Length; i++)
                {
                    if (prices[start] < prices[i])
                    {
                        int profit = Calculate(prices, i + 1) + prices[i] - prices[start];
                        if (profit > maxprofit)
                            maxprofit = profit;
                    }
                }
                if (maxprofit > max)
                    max = maxprofit;
            }
            return max;
        }
    }
}
