using System.Collections.Generic;

namespace LeetCodeChallenges.Arrays
{
    public class TwoSum
    {
        public int[] TwoSumMethod(int[] nums, int target)
        {
            var dict = new Dictionary<int, int>();
            for (int i = 0; i < nums.Length; i++)
            {
                if (dict.ContainsKey(target - nums[i]))
                {
                    return new int[] { i, dict[target - nums[i]] };
                }
                else
                {
                    if (!dict.ContainsKey(nums[i]))
                    {
                        dict.Add(nums[i], i);
                    }
                }
            }
            return new int[2];
        }
    }
}
