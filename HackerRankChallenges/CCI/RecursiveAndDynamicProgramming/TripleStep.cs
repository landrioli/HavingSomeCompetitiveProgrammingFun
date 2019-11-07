using System;
using System.Collections.Generic;
using System.Text;

namespace CCIChallenges.RecursiveAndDynamicProgramming
{
    /*Triple Step: A child is running up a staircase with n steps and can hop either 1 step, 2 steps, or 3
        steps at a time. Implement a method to count how many possible ways the child can run up the
        stairs.
     */
    public static class TripleStep
    {
        //BruteForce
        public static int CountWays(int n)
        {
            if (n < 0)
            {
                return 0;
            }
            else if (n == 0)
            {
                return 1;
            }
            else
            {
                return countWays(n - 1) + countWays(n - 2) + countWays(n - 3);
            }
        }

        //Implementantion with dynamic programming
        public static int CountWaysDynamicProgramming(int n)
        {
            int[] map = new int[n + 1];
            Array.Fill(map, -1);
            return CountWays(n, map);
        }

        public static int CountWays(int n, int[] memo)
        {
            if (n < 0)
            {
                return 0;
            }
            else if (n == 0)
            {
                return 1;
            }
            else if (memo[n] > -1)
            {
                return memo[n];
            }
            else
            {
                memo[n] = CountWays(n - 1, memo) + CountWays(n - 2, memo) + CountWays(n - 3, memo);
                return memo[n];
            }
        }

        public static void main(String[] args)
        {
            int n = 50;
            int ways = CountWaysDynamicProgramming(n);
        }

    }
}
