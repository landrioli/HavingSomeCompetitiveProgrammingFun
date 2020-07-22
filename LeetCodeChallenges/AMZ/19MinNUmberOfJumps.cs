using System;
using System.Collections.Generic;
using System.Text;

namespace LeetCodeChallenges.AMZ
{
    public class MinNUmberOfJumps
    {
        public int Jump(int[] nums)
        {
            var dp = new int[nums.Length];
            for (int i = 1; i < nums.Length; i++)
                dp[i] = int.MaxValue;
            dp[0] = 0; //the first position has zero of cost to jump
            for (int i = 1; i < nums.Length; i++) //Start at one because the first position has zero of cost to jump
            {
                for (int j = 0; j < i; j++)
                {
                    if (nums[j] + j >= i) // This means that we can jumpo from index J to I
                        dp[i] = Math.Min(dp[j] + 1, dp[i]); //The last better + 1 step OR Current previuos calculated 
                }
            }
            return dp[nums.Length - 1];
        }

        public bool CanJump(int[] nums)
        {
            var dp = new int[nums.Length];
            for (int i = 1; i < nums.Length; i++)
                dp[i] = int.MaxValue;
            dp[0] = 0; //the first position has zero of cost to jump
            for (int i = 1; i < nums.Length; i++) //Start at one because the first position has zero of cost to jump
            {
                for (int j = 0; j < i; j++)
                {
                    if (nums[j] + j >= i) // This means that we can jumpo from index J to I
                        dp[i] = Math.Min(dp[j] == int.MaxValue ? dp[j] : dp[j] + 1, dp[i]); //The last better + 1 step OR Current previuos calculated  //ternary toa void maxint became min int
                }
            }
            return dp[nums.Length - 1] != int.MaxValue;
        }

        public void Main()
        {
            Jump(new int[] { 3, 4, 2, 1, 2, 3, 7 });
        }
    }
}
