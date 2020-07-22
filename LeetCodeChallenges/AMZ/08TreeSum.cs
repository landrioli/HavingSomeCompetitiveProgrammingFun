using System;
using System.Collections.Generic;
using System.Text;

namespace LeetCodeChallenges.AMZ
{
    public class TreeSum
    {
        public IList<IList<int>> ThreeSum(int[] nums)
        {
            if (nums.Length < 3)
            {
                return new List<IList<int>>();
            }
            var result = new List<IList<int>>();
            Array.Sort(nums);
            for (int i = 0; i < nums.Length; i++)
            {
                if (i == 0 || (i > 0 && nums[i] != nums[i - 1]))  //Here I am checking that I will not repeat the element again
                {
                    int left = i;
                    int right = nums.Length - 1;
                    while (left < right)
                    {
                        int currentSum = nums[i] + nums[left] + nums[right];
                        if (currentSum == 0)
                        {
                            result.Add(new List<int>() { nums[i], nums[left], nums[right] });
                            while (left < right && nums[left] == nums[left + 1]) left++;  //Here I am checking that I will not repeat the element again
                            while (left < right && nums[right] == nums[right - 1]) right--;  //Here I am checking that I will not repeat the element again
                            left++;
                            right--;
                        }
                        else if (currentSum < 0)
                        {
                            left++;
                        }
                        else
                        {
                            right--;
                        }
                    }
                }
            }
            return result;
        }

        public void Main()
        {
            ThreeSum(new int[] { 0, 0, 0, 0});
        }
    }
}
