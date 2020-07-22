using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LeetCodeChallenges.AMZ
{
    public class WaterArea
    {
        public int Trap(int[] height)
        {
            var maxes = new int[height.Length];
            int maxHeightLeft = 0;
            for (int i = 0; i < height.Length; i++)
            {
                var currentHeight = height[i];
                maxes[i] = maxHeightLeft;
                maxHeightLeft = Math.Max(maxHeightLeft, currentHeight);
            }

            int maxHeightRight = 0;
            for (int i = height.Length - 1; i >= 0; i--)
            {
                var currentHeight = height[i];
                var minHeigth = Math.Min(maxHeightRight, maxes[i]); //THis point maxes[i] represents the max right at the i position
                if (currentHeight < minHeigth)
                    maxes[i] = minHeigth - currentHeight;
                else
                    maxes[i] = 0;
                maxHeightRight = Math.Max(maxHeightRight, currentHeight);
            }

            return maxes.Sum(p => p);
        }

        public void Main()
        {
            Trap(new int[] { 2, 0, 2 });

        }
    }
}
