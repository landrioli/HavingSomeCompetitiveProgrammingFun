using System;
using System.Collections.Generic;
using System.Text;

namespace CCIChallenges.SearchAndSort
{
    /*
        Sorted Search, No Size: You are given an array-like data structure Listy which lacks a size
        method. It does, however, have an e lementAt (i) method that returns the element at index i in
        0(1) time. If i is beyond the bounds of the data structure, it returns - 1. (For this reason, the data  structure only supports positive integers.) 
        Given a Listy which contains sorted, positive integers, find the index at which an element x occurs. If x occurs multiple times, you may return any index.
    */
    public static class FindElementOnArrayBinarySearchWithoutLength
    {
        public static int BinarySearch(Listy list, int value, int low, int high)
        {
            int mid;

            while (low <= high)
            {
                mid = (low + high) / 2;
                int middle = list.elementAt(mid);
                if (middle > value || middle == -1)
                {
                    high = mid - 1;
                }
                else if (middle < value)
                {
                    low = mid + 1;
                }
                else
                {
                    return mid;
                }
            }
            return -1;
        }

        public static int Search(Listy list, int value)
        {
            int index = 1;
            while (list.elementAt(index) != -1 && list.elementAt(index) < value)
            {
                index *= 2;
            }
            return BinarySearch(list, value, index / 2, index);
        }


        public class Listy
        {
            int[] array;

            public Listy(int[] arr)
            {
                array = arr;
            }

            public int elementAt(int index)
            {
                if (index >= array.Length)
                {
                    return -1;
                }
                return array[index];
            }
        }

        public static void Main()
        {
            int[] array = { 1, 2, 4, 5, 6, 7, 9, 10, 11, 12, 13, 14, 16, 18 };
            Listy list = new Listy(array);
            Search(list, 18);
        }
    }
}
