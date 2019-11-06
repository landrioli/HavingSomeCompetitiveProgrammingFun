using System;
using System.Collections.Generic;
using System.Text;

namespace LeetCodeChallenges.Arrays
{
    //Given two sorted arrays, the task is to merge them in a sorted manner.
    public static class MergeTwoSortedArrays
    {
        // Merge arr1[0..n1-1] and arr2[0..n2-1] into arr3[0..n1+n2-1] 
        // O(n1 + n2) Time and O(n1 + n2) Extra Space
        public static void MergeArrays(int[] arr1, int[] arr2,
                                       int n1, int n2, int[] arr3)
        {
            int i = 0, j = 0, k = 0;

            // Traverse both array 
            while (i < n1 && j < n2)
            {
                // Check if current element of first array is smaller than current element of second array. If yes,  
                // store first array element and increment first array index. Otherwise do same with second array 
                if (arr1[i] < arr2[j])
                    arr3[k++] = arr1[i++];
                else
                    arr3[k++] = arr2[j++];
            }

            // Store remaining elements of first array 
            while (i < n1)
                arr3[k++] = arr1[i++];

            // Store remaining elements of second array 
            while (j < n2)
                arr3[k++] = arr2[j++];
        }


        /*The idea is to begin from last element of ar2[] and search it in ar1[]. If there is a greater element in ar1[], then we move 
        last element of ar1[] to ar2[]. To keep ar1[] and ar2[] sorted, we need to place last element of ar2[] at correct place in ar1[].
        We can use Insertion Sort type of insertion for this.
        IMplementing with O(n1 * n2) Time and O(1) Extra Space.*/
        public static void MergeArrays2LowExtraSpace(int m, int n, int[] arr1, int[] arr2)
        {
            // Iterate through all elements of ar2[] starting from  
            // the last element  
            for (int i = n - 1; i >= 0; i--)
            {
                /* Find the smallest element greater than ar2[i]. Move all  
                elements one position ahead till the smallest greater  
                element is not found */
                int j, last = arr1[m - 1];
                for (j = m - 2; j >= 0 && arr1[j] > arr2[i]; j--)
                    arr1[j + 1] = arr1[j];

                // If there was a greater element  
                if (j != m - 2 || last > arr2[i])
                {
                    arr1[j + 1] = arr2[i];
                    arr2[i] = last;
                }
            }
        }

        public static void Main()
        {
            int[] arr1 = { 1, 3, 5, 7 };
            int n1 = arr1.Length;

            int[] arr2 = { 2, 4, 6, 8 };
            int n2 = arr2.Length;

            int[] arr3 = new int[n1 + n2];
            MergeArrays2LowExtraSpace(4,4,arr1,arr2);
            MergeArrays(arr1, arr2, n1, n2, arr3);

            Console.Write("Array after merging\n");
            for (int i = 0; i < n1 + n2; i++)
                Console.Write(arr3[i] + " ");
        }
    }
}
