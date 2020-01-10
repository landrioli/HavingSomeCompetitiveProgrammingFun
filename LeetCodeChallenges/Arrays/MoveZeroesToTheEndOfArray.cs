using System;
using System.Collections.Generic;
using System.Text;

namespace LeetCodeChallenges.Arrays
{
    /*Given an array nums, write a function to move all 0's to the end of it while maintaining the relative order of the non-zero elements.
     Note:
        You must do this in-place without making a copy of the array.
        Minimize the total number of operations.*/
    class MoveZeroesToTheEndOfArray
    {
        //The idea here is bring all the number bigger than zer to the left and in the same iteration fill their old position with zero
        public void MoveZeroes(int[] nums)
        {
            if (nums == null || nums.Length == 0) return;

            int current = 0;
            for (int i = 0; i < nums.Length; i++)
            {
                if (nums[i] != 0)
                {
                    int temp = nums[current];
                    nums[current++] = nums[i];
                    nums[i] = temp;
                }
            }
        }
    }
}
