using System;
using System.Collections.Generic;
using System.Text;

namespace CCIChallenges.MathAndPuzzles
{
    public static class PrimeNumbers
    {
        public static bool PrimeNaive(int n)
        {
            for (int i = 2; i < n; i++)
            {
                if (n % i == 0)
                {
                    return false;
                }
            }
            return true;
        }


        public static bool PrimeSlightlyBetter(int n)
        {
            int sqrt = (int)Math.Sqrt(n);
            for (int i = 2; i <= sqrt; i++)
            {
                if (n % i == 0)
                {
                    return false;
                }
            }
            return true;
        }

        public static void Main()
        {
            for (int i = 2; i < 100; i++)
            {
                if (PrimeSlightlyBetter(i))
                {
                   Console.WriteLine(i);
                }
            }
        }
    }
}
