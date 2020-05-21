using System;
using System.Collections.Generic;
using System.Text;

namespace LeetCodeChallenges.Arrays
{
    //https://leetcode.com/problems/find-first-and-last-position-of-element-in-sorted-array/
    /*
        Given an array of integers nums sorted in ascending order, find the starting and ending position of a given target value.
        Your algorithm's runtime complexity must be in the order of O(log n).
        If the target is not found in the array, return [-1, -1].
            Example 1:
            Input: nums = [5,7,7,8,8,10], target = 8
            Output: [3,4]
            Example 2:
            Input: nums = [5,7,7,8,8,10], target = 6
            Output: [-1,-1]
         */
    public class FindFirstAndLastOcurrencyUsingBinarySearch
    {
        //First, because we are locating the leftmost (or rightmost) index containing target (rather than returning true iff we find target), the algorithm does not terminate as soon as we find a match. 
        //Instead, we continue to search until lo == hi and they contain some index at which target can be found.
        public int[] SearchRangeWithBinarySearch(int[] nums, int target)
        {
            int[] result = new int[2];
            result[0] = FIndBegin(nums, target);
            result[1] = FindLast(nums, target);
            return result;
        }
        //5, 7, 7, 8, 8, 8, 10 
        private int FIndBegin(int[] nums, int target)
        {
            int idx = -1;
            int start = 0;
            int end = nums.Length - 1;
            while (start <= end)
            {
                int mid = (start + end) / 2;
                if (nums[mid] >= target)
                {
                    end = mid - 1;
                }
                else
                {
                    start = mid + 1;
                }
                if (nums[mid] == target) idx = mid;
            }
            return idx;
        }

        private int FindLast(int[] nums, int target)
        {
            int idx = -1;
            int start = 0;
            int end = nums.Length - 1;
            while (start <= end)
            {
                int mid = (start + end) / 2;
                if (nums[mid] <= target)
                {
                    start = mid + 1;
                }
                else
                {
                    end = mid - 1;
                }
                if (nums[mid] == target) idx = mid;
            }
            return idx;
        }
    }
}
