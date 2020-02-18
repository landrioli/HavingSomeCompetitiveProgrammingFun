using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Test
{
	//https://leetcode.com/problems/3sum-closest/
	//Nary-Tree input serialization is represented in their level order traversal, each group of children is separated by the null value (See examples).
    public class ThreeSumClosestClass
    {		
		
        //O(n^3)
        public int ThreeSumClosestBruteForce(int[] nums, int target)
        {
            int bestSum = nums[0] + nums[1] + nums[2];
            for (int i = 0; i < nums.Length; i++)
            {
                for (int j = i + 1; j < nums.Length; j++)
                {
                    for (int k = j + 1; k < nums.Length; k++)
                    {
                        var currentSum = nums[i] + nums[j] + nums[k];
                        if (Math.Abs(currentSum - target) < Math.Abs(bestSum - target))
                            bestSum = currentSum;
                    }
                }
            }
            return bestSum;
        }
        //Optimized O(N^2)
        public int ThreeSumClosest(int[] nums, int target)
        {
            int bestSum = nums[0] + nums[1] + nums[2];
			Array.Sort(nums);
            for (int i = 0; i < nums.Length; i++)
            {
                int begin = i + 1;
                int end = nums.Length - 1;
                while (begin < end)
                {
                    int currentSum = nums[i] + nums[begin] + nums[end];
                    if(currentSum > target)
                        end--;
                    else
                        begin++;
                    if (Math.Abs(currentSum - target) < Math.Abs(bestSum - target))
                        bestSum = currentSum;
                }
            }
            return bestSum;
        }
    }
}
