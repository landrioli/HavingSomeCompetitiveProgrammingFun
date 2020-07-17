using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LeetCodeChallenges.AMZ
{
    public class Permutations
    {
        public IList<IList<int>> Permute(int[] nums)
        {
            IList<IList<int>> returnable = new List<IList<int>>();
            PermuteHelper(nums.ToList(), new List<int>(), returnable);
            return returnable;
        }

        public void PermuteHelper(List<int> nums, List<int> choose, IList<IList<int>> result)
        {
            if (nums.Count == 0)
            {
                result.Add(choose.ToArray());
            }
            else
            {
                for (int index = 0; index < nums.Count; index++)
                {
                    //Choose
                    int num = nums[index];
                    nums.RemoveAt(index);
                    choose.Add(num);

                    //Explore
                    PermuteHelper(nums, choose, result);

                    //Roolback to starting point
                    choose.Remove(num);
                    nums.Insert(index, num);
                }
            }
        }

        public void Main()
        {
            Permute(new int[] { 1, 2, 3});
        }

    }
}
