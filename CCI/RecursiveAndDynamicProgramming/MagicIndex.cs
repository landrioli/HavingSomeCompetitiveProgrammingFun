using System;
using System.Collections.Generic;
using System.Text;

namespace CCIChallenges.RecursiveAndDynamicProgramming
{
    public static class MagicIndex
    {
        //rute Force
        public static int MagicBruteForce(int[] array)
        {
            for (int i = 0; i < array.Length; i++)
            {
                if (array[i] == i)
                {
                    return i;
                }
            }
            return -1;
        }

        //Magic optimized for non repeated elements
        public static int MagicNonRepeatedElements(int[] array, int start, int end)
        {
            if (end < start)
            {
                return -1;
            }
            int mid = (start + end) / 2;
            if (array[mid] == mid)
            {
                return mid;
            }
            else if (array[mid] > mid)
            {
                return MagicNonRepeatedElements(array, start, mid - 1);
            }
            else
            {
                return MagicNonRepeatedElements(array, mid + 1, end);
            }
        }
        public static int MagicNonRepeatedElements(int[] array)
        {
            return MagicNonRepeatedElements(array, 0, array.Length - 1);
        }


        //Magic Optimized For reapeated elements
        public static int MagicRepeatedElements(int[] array, int start, int end)
        {
            if (end < start)
            {
                return -1;
            }
            int midIndex = (start + end) / 2;
            int midValue = array[midIndex];
            if (midValue == midIndex)
            {
                return midIndex;
            }
            /* Min because if the lef item is smaller then the index position, it only can be in thar excatly position... */
            int leftIndex = Math.Min(midIndex - 1, midValue);
            int left = MagicRepeatedElements(array, start, leftIndex);
            if (left >= 0)
            {
                return left;
            }

            /* Search right */
            int rightIndex = Math.Max(midIndex + 1, midValue);
            int right = MagicRepeatedElements(array, rightIndex, end);

            return right;
        }
        public static int MagicRepeatedElements(int[] array)
        {
            return MagicRepeatedElements(array, 0, array.Length - 1);
        }

        public static void Main()
        {
            for (int i = 0; i < 1000; i++)
            {
                int size = 10;
                int[] array = new int[] { 1, 1, 1, 1, 2, 11, 13, 15, 17 };
                int v2 = MagicRepeatedElements(array);

            }
        }
    }
}
