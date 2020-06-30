using System;
using System.Collections.Generic;
using System.Text;

namespace GeneralChallenges.Codility
{
    //https://app.codility.com/programmers/challenges/
    ////There are N rectangular buildings standing along the road next to each other. The K-th building is of size H[K] × 1.
    //Because a renovation of all of the buildings is planned, we want to cover them with rectangular banners until the renovations are finished.Of course, to cover a building, the banner has to be at least as high as the building.We can cover more than one building with a banner if it is wider than 1.
    //For example, to cover buildings of heights 3, 1, 4 we could use a banner of size 4×3 (i.e.of height 4 and width 3), marked here in blue:
    //We can order at most two banners and we want to cover all of the buildings.Also, we want to minimize the amount of material needed to produce the banners.
    //What is the minimum total area of at most two banners which cover all of the buildings?
    //Examples:
    //1. Given H = [3, 1, 4], the function should return 10.
    //      The result can be achieved by covering the first two buildings with a banner of size 3×2 and the third building with a banner of size 4×1:
    //2. Given H = [5, 3, 2, 4], the function should return 17.
    //      The result can be achieved by covering the first building with a banner of size 5×1 and the other buildings with a banner of size 4×3:
    public class Palladium2020RectangularBuildingsBannersSize
    {
        // HEre I pre-compute the hights from Left to right and I will use to compare the right side with the left side. (avoiding the N * N complexity)
        //O(N)
        public int SolutionOptimized(int[] A)
        {
            if (A.Length <= 1)
                return A[0];

            int[] B = new int[A.Length];
            int val = B[A.Length - 1];
            for (int i = A.Length - 1; i >= 0; i--)
            {
                val = Math.Max(val, A[i]);
                B[i] = val;
            }

            int min = int.MaxValue;
            int lHeight = A[0];
            int rHeight = int.MinValue;
            for (int i = 0; i < A.Length - 1; i++)
            {
                lHeight = Math.Max(lHeight, A[i]);
                rHeight = B[i + 1];
                int result = (lHeight * (i + 1)) + (rHeight * (A.Length - i - 1));
                rHeight = int.MinValue;

                min = Math.Min(min, result);
            }
            return min;
        }

        //O(N * max(H)) or O(N*2)
        public int SolutionBruteForce(int[] H)
        {
            int bestBannerArea = int.MaxValue;
            for (int i = 0; i < H.Length; i++)
            {
                var bannerOne = GetTotalSize(H, 0, i);
                var bannerTwo = GetTotalSize(H, i + 1, H.Length - 1);
                bestBannerArea = Math.Min(bestBannerArea, bannerOne + bannerTwo);
            }

            return bestBannerArea;
        }
        private int GetTotalSize(int[] buildings, int firstBuildingPosition, int lastBuildingPosition)
        {
            int higherBuilding = 0;
            for (int i = firstBuildingPosition; i <= lastBuildingPosition; i++)
            {
                higherBuilding = Math.Max(higherBuilding, buildings[i]);
            }
            return higherBuilding * (lastBuildingPosition - firstBuildingPosition + 1);
        }

        

        public void Main()
        {
            var result = SolutionOptimized(new int[] {5, 3, 5, 2, 1});
             result = SolutionOptimized(new int[] { 7, 7, 3, 7, 7 });
            
        }
    }
}
