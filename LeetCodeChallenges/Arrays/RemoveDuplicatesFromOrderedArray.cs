using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Test
{
	/**https://leetcode.com/problems/remove-duplicates-from-sorted-array/submissions/
	Given a sorted array nums, remove the duplicates in-place such that each element appear only once and return the new length.
	Do not allocate extra space for another array, you must do this by modifying the input array in-place with O(1) extra memory.
	Example 1:  Given nums = [1,1,2], Your function should return length = 2, with the first two elements of nums being 1 and 2 respectively.
	It doesn't matter what you leave beyond the returned length.*/
    public class RemoveDuplicatesFromOrderedArray
    {				
		public int RemoveDuplicates(int[] nums) {
			if(nums == null || nums.Length == 0)
				return 0;
			int count = 1;
			int id = 1;
			for(int i = 1; i<nums.Length;i++){
				if(nums[i] == nums[i-1])
					continue;
				nums[id] = nums[i];
				count++;
				id++;
			}
			return count;
		}
    }
}
