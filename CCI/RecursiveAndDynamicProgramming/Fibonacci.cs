using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;

namespace CCIChallenges.RecursiveAndDynamicProgramming
{
    public static class Fibonacci
    {


        public static int FindFibonacciNumbers(int n)
        {
            if (n <= 1)
                return n;

            return FindFibonacciNumbers(n - 1) + FindFibonacciNumbers(n - 2);
        }

        public static int FibDynamicProgramming2(int N)
        {
            if (N == 0 || N == 1)
                return N;
            int[] dp = new int[N + 1];
            dp[0] = 0;
            dp[1] = 1;
            for (int i = 2; i <= N; i++)
            {
                dp[i] = dp[i - 1] + dp[i - 2];
            }
            return dp[N];
        }

        private static Dictionary<int, int> cache = new Dictionary<int, int>();
        public static int FindFibonacciNumbersDynamicProgrammin(int n)
        {
            if (n <= 1)
                return n;

            if (cache.ContainsKey(n))
            {
                return cache[n];
            }

            var result = FindFibonacciNumbersDynamicProgrammin(n - 1) + FindFibonacciNumbersDynamicProgrammin(n - 2);
            cache[n] = result;
            return result;
        }

        //You only use memo [i] for memo [i+l] and memo [i+2]. You don't need it after that.Therefore, we can get rid of the memo table and just store a few variables.
        public static int FindFibonacciNumbersSmallSpace(int n)
        {
            if (n == 0) return 0;
            int a = 0;
            int b = 1;
            for (int i = 2; i < n; i++)
            {
                int c = a + b;
                a = b;
                b = c;
            }
            return a + b;
        }

        public static void Main()
        {
            var watch = new Stopwatch();
            watch.Start();
            int result = FindFibonacciNumbers(42);
            watch.Stop();
            var ts = watch.Elapsed.TotalSeconds;

            watch.Restart();
            int result2 = FindFibonacciNumbersDynamicProgrammin(42);
            watch.Stop();
            var ts2 = watch.Elapsed.TotalSeconds;

            watch.Restart();
            int result3 = FindFibonacciNumbersSmallSpace(42);
            watch.Stop();
            var ts3 = watch.Elapsed.TotalSeconds;
        }
    }
}
