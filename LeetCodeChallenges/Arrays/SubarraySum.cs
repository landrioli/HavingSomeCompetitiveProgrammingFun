using System;
using System.Collections.Generic;
using System.Text;

namespace LeetCodeChallenges.Arrays
{
    //https://leetcode.com/problems/subarray-sum-equals-k/
    public class SubarraySum
    {
        //Given an array of integers and an integer k, you need to find the total number of continuous subarrays whose sum equals to k.
        //Example 1:
        //Input:nums = [1,1,1], k = 2
        //Output: 2

        //Time complexity : O(n^2). We need to consider every subarray possible.
        //Space complexity : O(1). Constant space is used.
        public int SubarraySumBruteForceMethod(int[] nums, int k)
        {
            int numberOfMatches = 0;
            for (int i = 0; i < nums.Length; i++)
            {
                int sum = nums[i];
                if (sum == k)
                    numberOfMatches++;
                for (int j = i + 1; j < nums.Length; j++)
                {
                    sum += nums[j];
                    if (sum == k)
                        numberOfMatches++;
                }
            }
            return numberOfMatches;
        }

        //Time complexity : O(n). The entire numsnums array is traversed only once.
        //Space complexity : O(n). Hashmap mapmap can contain upto nn distinct entries in the worst case.
        public int SubarraySumOptimizedMethod(int[] nums, int k)
        {
            int numberOfMatches = 0;
            int sum = 0;
            var dict = new Dictionary<int, int>();
            dict.Add(0, 1); //Need it because we need to compare the number itself - k == 0
            for (int i = 0; i < nums.Length; i++)
            {
                sum += nums[i];
                if (dict.ContainsKey(sum - k))
                    numberOfMatches += dict[sum - k];

                if (dict.ContainsKey(sum))
                    dict[sum] = dict[sum] + 1;
                else
                    dict.Add(sum, 1);
            }
            return numberOfMatches;
        }
    }
}
