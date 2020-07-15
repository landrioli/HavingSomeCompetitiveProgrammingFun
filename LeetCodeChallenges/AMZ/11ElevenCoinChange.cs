using System;
using System.Collections.Generic;
using System.Text;

namespace LeetCodeChallenges.AMZ
{
    public class ElevenCoinChange
    {
        public int NumberOfWaysToMakeCoinChange(int[] coins, int amount)
        {
            var ways = new int[amount + 1];
            ways[0] = 1; //Base case for zero ammount there are one way that is no way
            foreach (var coin in coins)
            {
                for (int j = 1; j < ways.Length; j++)
                {
                    if (coin <= j)
                    {
                        ways[j] += ways[j - coin];
                    }
                }
            }
            return ways[amount];
        }

        /*The idea of the algorithm is to build the solution of the problem from top to bottom. It applies the idea described above. 
         * It use backtracking and cut the partial solutions in the recursive tree, which doesn't lead to a viable solution.
         * Тhis happens when we try to make a change of a coin with a value greater than the amount SS. 
         * To improve time complexity we should store the solutions of the already calculated subproblems in a table.*/
        public int FewestCoinsToAmount(int[] coins, int amount)
        {
            var ways = new int[amount + 1];
            for (int i = 0; i < ways.Length; i++)
            {
                ways[i] = int.MaxValue;
            }
            ways[0] = 0;

            foreach (var coin in coins)
            {
                for (int i = 1; i < ways.Length; i++)
                {
                    if (coin <= i)
                    {
                        ways[i] = Math.Min(ways[i], 1 + ways[i - coin]);
                    }
                }
            }

            return ways[amount] >= amount + 1 ? -1 : ways[amount];
        }

        public void Main()
        {
            FewestCoinsToAmount(new int[] { 2 }, 3);
            FewestCoinsToAmount(new int[] { 1, 2, 5 }, 11);
        }
    }
}
