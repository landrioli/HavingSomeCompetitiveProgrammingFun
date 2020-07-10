using System;
using System.Collections.Generic;
using System.Text;

namespace LeetCodeChallenges.AMZ
{
    public class Demo
    {
        public int[] cellCompete(int[] states, int days)
        {
            int[] originalArr = new int[states.Length];
            Array.Copy(states, originalArr, states.Length);
            for (int i = 0; i < days; i++)
            {
                for (int j = 0; j < states.Length; j++)
                {
                    // handle edge cases
                    if (j == 0)
                    {
                        if (j + 1 < states.Length - 1 && states[j + 1] == 0)
                            originalArr[j] = 0;
                        else
                            originalArr[j] = 1;
                    }
                    else if (j == states.Length - 1)
                    {
                        if (j == states.Length - 1 && states[j - 1] == 0)
                            originalArr[j] = 0;
                        else
                            originalArr[j] = 1;
                    }
                    else if (states[j - 1] == 0 && states[j + 1] == 0 ||
                    states[j - 1] == 1 && states[j + 1] == 1)
                        originalArr[j] = 0;
                    else
                        originalArr[j] = 1;
                }
                Array.Copy(originalArr, states, states.Length);
            }
            return states;
        }

        public int generalizedGCD(int num, int[] arr)
        {
            int result = arr[0];
            for (int i = 1; i < num; i++)
            {
                result = gcd(arr[i], result);

                if (result == 1)
                {
                    return 1;
                }
            }

            return result;
        }

        /* Based on euclidean algorithm
        The algorithm is based on below facts.
        If we subtract smaller number from larger (we reduce larger number), GCD doesn’t change. So if we keep subtracting repeatedly the larger of two, we end up with GCD.
        Now instead of subtraction, if we divide smaller number, the algorithm stops when we find remainder 0.
        */
        private int gcd(int a, int b)
        {
            if (a == 0)
                return b;
            return gcd(b % a, a);
        }

        public void Main()
        {
            generalizedGCD(5, new int[] { 10, 8, 6, 4, 2 });
            cellCompete(new int[8] { 1, 1, 1, 0, 1, 1, 1, 1 }, 2);
        }
    }
}
