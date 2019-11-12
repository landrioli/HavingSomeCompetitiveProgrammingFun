using System;
using System.Collections.Generic;
using System.Text;

namespace GeneralChallenges.Codility
{
    class ArrayRotateRight
    {
        /*Approach #2 Using Extra Array
         We use an extra array in which we place every element of the array at its correct position i.e. the number at index i in 
         the original array is placed at the index (i+k)%(Length of array)(i+k). Then, we copy the new array to the original one.
         Time complexity : O(n). One pass is used to put the numbers in the new array. And another pass to copy the new array to the original one.
         Space complexity : O(n). Another array of the same size is used.
        */
        public void RotateUsingExtraArray(int[] nums, int k)
        {
            int[] a = new int[nums.Length];
            for (int i = 0; i < nums.Length; i++)
            {
                a[(i + k) % nums.Length] = nums[i];
            }
            for (int i = 0; i < nums.Length; i++)
            {
                nums[i] = a[i];
            }
        }

        /*
        Approach: Using Reverse
        This approach is based on the fact that when we rotate the array k times, k elements from the back end of the array come to 
        the front and the rest of the elements from the front shift backwards.
        In this approach, we firstly reverse all the elements of the array. Then, reversing the first k elements followed
        by reversing the rest n-kn−k elements gives us the required result.
        Time complexity : O(n). n elements are reversed a total of three times.
        Space complexity : O(1). 
             */
        public int[] RotateUsingTheSameArray(int[] nums, int k)
        {
            k %= nums.Length;
            reverse(nums, 0, nums.Length - 1);
            reverse(nums, 0, k - 1);
            reverse(nums, k, nums.Length - 1);
            return nums;
        }

        public void reverse(int[] nums, int start, int end)
        {
            while (start < end)
            {
                int temp = nums[start];
                nums[start] = nums[end];
                nums[end] = temp;
                start++;
                end--;
            }
        }
    }
}
