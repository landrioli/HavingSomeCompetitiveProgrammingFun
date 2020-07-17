using System;
using System.Collections.Generic;
using System.Text;

namespace LeetCodeChallenges.AMZ
{
    //https://leetcode.com/problems/subsets/
    /*Given a set of distinct integers, nums, return all possible subsets (the power set).
        Note: The solution set must not contain duplicate subsets.
            Input: nums = [1,2,3]
            Output:
            [
              [3],
              [1],
              [2],
              [1,2,3],
              [1,3],
              [2,3],
              [1,2],
              []
            ]
     */
    public class PowersetSubsets
    {
        // Let's start from empty subset in output list. At each step one takes new integer into consideration and generates new subsets from the existing ones.
        //Time complexity:(N * 2^N) generate all subsets and then copy them into output list.
        // Space: (N * 2^N)
        public IList<IList<int>> Subsets(int[] nums)
        {
            var subsets = new List<IList<int>>();
            subsets.Add(new List<int>());
            for (int i = 0; i < nums.Length; i++)
            {
                var size = subsets.Count;
                for (int j = 0; j < size; j++)
                {
                    var newSubset = new List<int>(subsets[j]);
                    newSubset.Add(nums[i]);
                    subsets.Add(newSubset);
                }
            }

            return subsets;
        }
    }
}
