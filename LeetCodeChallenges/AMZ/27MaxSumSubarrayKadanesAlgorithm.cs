using System;
using System.Collections.Generic;
using System.Text;

namespace LeetCodeChallenges.AMZ
{
    public class MaxSumSubarrayKadanesAlgorithm
    {
        public int MaxSubArray(int[] a)
        {
            if (a.Length == 0)
                return 0;

            int maxSoFar = a[0];
            int maxEndingHere = a[0];

            for (int i = 1; i < a.Length; i++)
            {
                maxEndingHere = Math.Max(maxEndingHere + a[i], a[i]);
                maxSoFar = Math.Max(maxSoFar, maxEndingHere);
            }

            return maxSoFar;
        }

        public int MaxProduct(int[] nums)
        {
            int max = int.MinValue, imax = 1, imin = 1;
            for (int i = 0; i < nums.Length; i++)
            {
                // multiplied by a negative makes big number smaller, small number bigger
                // so we redefine the extremums by swapping them
                if (nums[i] < 0)
                {
                    int tmp = imax;
                    imax = imin;
                    imin = tmp;
                }

                // max/min product for the current number is either the current number itself
                // or the max/min by the previous number times the current one
                imax = Math.Max(imax * nums[i], nums[i]);
                imin = Math.Min(imin * nums[i], nums[i]);

                max = Math.Max(max, imax);
            }
            return max;
        }
    }
}
