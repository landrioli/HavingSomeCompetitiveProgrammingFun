using System;
using System.Collections.Generic;
using System.Text;

namespace LeetCodeChallenges._30DaysChallengeCovid
{
    public class DayFourMoveZeroesInArray
    {
        public void MoveZeroes(int[] nums)
        {
            int lastUpdatedPosition = 0;
            for (int i = 0; i < nums.Length; i++)
            {
                if (nums[i] == 0)
                {
                    var clearPosition = i;
                    while (nums[i] == 0)
                    {
                        if (i + 1 < nums.Length)
                            i++;
                        else
                            break;
                    }
                }
                nums[lastUpdatedPosition] = nums[i];
                lastUpdatedPosition++;
            }
            for (int i = lastUpdatedPosition; i < nums.Length; i++)
            {
                nums[i] = 0;
            }
        }
    }
}
