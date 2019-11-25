using System;
using System.Collections.Generic;
using System.Text;

namespace CCIChallenges.SearchAndSort
{
    /*
     *Given a Listy which contains sorted, positive integers, find the index at which an element x occurs. If x occurs multiple times, you may return any index.
    */
    public static class FindElementOnArrayBinarySearch
    {
        public static int FindElement(int[] array, int elementToFind)
        {
            var response = BinarySearchRecursive(array, elementToFind, 0, array.Length - 1);

            return response;
        }
        public static int BinarySearchRecursive(int[] array, int elementToFind, int start, int end)
        {
            int mid = (start + end) / 2;
            if (start > end)
            {
                return -1;
            }
            if (array[mid] == elementToFind)
            {
                return mid;
            }
            else if (array[mid] < elementToFind)
            {
                //Call Right
                return BinarySearchRecursive(array, elementToFind, mid + 1, end);
            }
            else
            {
                //Call Left
                return BinarySearchRecursive(array, elementToFind, start, mid - 1);
            }            
        }

        public static int BinarySearchIterative(int[] inputArray, int key)
        {
            int min = 0;
            int max = inputArray.Length - 1;
            while (min <= max)
            {
                int mid = (min + max) / 2;
                if (key == inputArray[mid])
                {
                    return ++mid;
                }
                else if (key < inputArray[mid])
                {
                    max = mid - 1;
                }
                else
                {
                    min = mid + 1;
                }
            }
            return -1;
        }

        public static void Main()
        {
            FindElement(new int[] { 1, 2, 3, 4, 5 }, 6);
        }
    }
}
