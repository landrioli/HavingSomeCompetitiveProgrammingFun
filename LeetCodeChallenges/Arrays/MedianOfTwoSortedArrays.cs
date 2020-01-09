using System;
using System.Collections.Generic;
using System.Text;

namespace LeetCodeChallenges.Arrays
{
    //TODO:ONGOING
    public static class MedianOfTwoSortedArrays
    {
        public static void GetMedianOfTwoSortedArrays(int[] arrayOne, int[] arrayTwo)
        {

            int size = arrayOne.Length > arrayTwo.Length ? arrayOne.Length : arrayTwo.Length;
            int[] finalArray = new int[arrayOne.Length + arrayTwo.Length];
            for (int i = 0, j = 0, k = 0; i < size; i++)
            {
                if (j < arrayOne.Length)
                {
                    if (arrayOne[j] < arrayTwo[k])
                    {
                        finalArray[i] = arrayOne[j];
                        j++;
                    }
                }
                if (k < arrayOne.Length)
                {
                    if (arrayOne[k] >= arrayTwo[j])
                    {
                        finalArray[i] = arrayOne[k];
                        k++;
                    }
                }
            }
        }

        public static void Main()
        {
            GetMedianOfTwoSortedArrays(new int[] { 1, 3, 5, 7, 8 }, new int[] { 2, 4, 5, 6, 10 });
        }


    }
}
