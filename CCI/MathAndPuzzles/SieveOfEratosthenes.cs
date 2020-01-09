using System;
using System.Collections.Generic;
using System.Text;

namespace CCIChallenges.MathAndPuzzles
{
    public static class SieveOfEratosthenes
    {
        public static void crossOff(bool[] flags, int prime)
        {
            /* Cross off remaining multiples of prime. We can start with
             * (prime*prime), because if we have a k * prime, where k < prime,
             * this value would have already been crossed off in a prior
             * iteration. */
            for (int i = prime * prime; i < flags.Length; i += prime)
            {
                flags[i] = false;
            }
        }

        public static int getNextPrime(bool[] flags, int prime)
        {
            int next = prime + 1;
            while (next < flags.Length && !flags[next])
            {
                next++;
            }
            return next;
        }

        public static void init(bool[] flags)
        {
            flags[0] = false;
            flags[1] = false;
            for (int i = 2; i < flags.Length; i++)
            {
                flags[i] = true;
            }
        }

        public static int[] prune(bool[] flags, int count)
        {
            int[] primes = new int[count];
            int index = 0;
            for (int i = 0; i < flags.Length; i++)
            {
                if (flags[i])
                {
                    primes[index] = i;
                    index++;
                }
            }
            return primes;
        }

        public static bool[] sieveOfEratosthenes(int max)
        {
            bool[] flags = new bool[max + 1];

            init(flags);
            int prime = 2;

            while (prime <= Math.Sqrt(max))
            {
                /* Cross off remaining multiples of prime */
                crossOff(flags, prime);

                /* Find next value which is true */
                prime = getNextPrime(flags, prime);
            }

            return flags; //prune(flags, count);
        }

        public static void Main()
        {
            bool[] primes = sieveOfEratosthenes(30);
            for (int i = 0; i < primes.Length; i++)
            {
                if (primes[i])
                {
                    Console.WriteLine(i);
                }
            }
        }
    }
}
