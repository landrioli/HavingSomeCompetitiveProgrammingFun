using System;
using System.Collections.Generic;
using System.Text;

namespace LeetCodeChallenges.Arrays
{
    public class ThreeSumClosestPack
    {
        public int ThreeSumClosest(int[] nums, int target)
        {
            int closestSum = int.MaxValue;
            int selectedVal = 0;
            var hash = new HashSet<int>();
            for (int i = 0; i < nums.Length; i++)
            {
                for (int j = i + 1; j < nums.Length; j++)
                {
                    for (int k = j + 1; k < nums.Length; k++)
                    {
                        int sum = nums[i] + nums[j] + nums[k];
                        if (Math.Abs(Math.Abs(target) - Math.Abs(sum)) < Math.Abs(closestSum))
                            closestSum = sum;
                    }   
                }
            }
            // Given array nums = [-1, 2, -4, 1], and target = 1.
            // The sum that is closest to the target is 2. (-1 + 2 + 1 = 2).

            return closestSum;
        }
    }
}
