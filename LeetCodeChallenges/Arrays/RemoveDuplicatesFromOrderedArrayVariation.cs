using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Test
{
	/**https://leetcode.com/problems/remove-duplicates-from-sorted-array-ii/
	Given a sorted array nums, remove the duplicates in-place such that duplicates appeared at most twice and return the new length.
	Do not allocate extra space for another array, you must do this by modifying the input array in-place with O(1) extra memory.*/
    public class RemoveTwoDuplicatesFromOrderedArray
    {				
		public int RemoveDuplicates(int[] nums) {
			int count = 0;
			int id = 0;
			if(nums == null || nums.Length == 0)
				return count;
			if(nums.Length == 1)
				return ++count;
			
			if(nums[0] == nums[1])
			{
				count = 2;
				id = 2;
			}
			else{
				count = 1;
				id = 1;
			}		

			for(int i = 1; i<nums.Length;i++){
				if(nums[i] == nums[i-1])
					continue;
				
				if(i < nums.Length - 2 && nums[i] == nums[i+1])
				{
					count += 2;
					nums[id++] = nums[i];
					nums[id++] = nums[i+1];
				}
				else{
					count += 1;
					nums[id++] = nums[i];
				}
			}
			return count;
		}
    }
}
