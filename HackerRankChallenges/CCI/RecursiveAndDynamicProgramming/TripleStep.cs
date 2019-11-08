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
                return CountWays(n - 1) + CountWays(n - 2) + CountWays(n - 3);
            }
        }

        //Implementantion with dynamic programming array
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

        //Implementantion with dynamic programming Dictionary
        //You are climbing a stair case. It takes n steps to reach to the top. Each time you can either climb 1 or 2 steps.In how many distinct ways can you climb to the top?
        private static Dictionary<int, int> cache = new Dictionary<int, int>();
        public static int ClimbStairsTwoSteps(int n)
        {
            if (n < 0)
                return 0;
            else if (n == 0)
                return 1;
            else if (cache.ContainsKey(n))
                return cache[n];
            else
                cache[n] = ClimbStairsTwoSteps(n - 1) + ClimbStairsTwoSteps(n - 2);
            return cache[n];
        }

        public static void Main()
        {
            int n = 3;
            int ways = CountWaysDynamicProgramming(n);
        }

    }
}
