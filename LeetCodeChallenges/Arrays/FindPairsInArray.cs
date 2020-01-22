using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Test
{
	//https://leetcode.com/problems/generate-parentheses
	//Given n pairs of parentheses, write a function to generate all combinations of well-formed parentheses.
    public class FindPairs
    {		
        //https://leetcode.com/problems/k-diff-pairs-in-an-array/
        //Given an array of integers and an integer k, you need to find the number of unique k-diff pairs in the array. 
        //Here a k-diff pair is defined as an integer pair (i, j), where i and j are both numbers in the array and their absolute difference is k.
        //O(N)
        public int FindPairsMethod(int[] nums, int k)
        {
            int count = 0;
            var numbers = new Dictionary<int,int>();
            // Load DIctionary with frequency
            for (int i = 0; i < nums.Length; i++)
            {
                int element = nums[i];
                if (numbers.ContainsKey(element))
                    numbers[element] = numbers[element] + 1;
                else
                    numbers.Add(element, 1);
            }

            foreach (var item in numbers)
            {
                if (k == 0) {
                    if (numbers[item.Value] >= 2)
                        count++;
                }
                else if (k < 0) { //We just can consider the absolute diff, so negative K is not a valid scenario
                    return 0;
                }
                else
                {
                    if (numbers.ContainsKey(item.Key + k))
                    {
                        count++;
                    }
                }
            }
            return count;
        }
    }
}
