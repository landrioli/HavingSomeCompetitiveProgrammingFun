using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LeetCodeChallenges.Arrays
{
    //https://leetcode.com/problems/single-number/
    //Given a non-empty array of integers, every element appears twice except for one. Find that single one.
    //Your algorithm should have a linear runtime complexity.Could you implement it without using extra memory?
    //Example 1:
    //Input: [2,2,1]
    //Output: 1
    class SingleNumber
    {
        public int SingleNumberMethod(int[] nums)
        {
            var hash = new HashSet<int>();
            for (int i = 0; i < nums.Length; i++)
            {
                int key = nums[i];
                if (hash.Contains(key))
                    hash.Remove(key);
                else
                    hash.Add(key);
            }
            return hash.First();
        }
    }
}
