using System;
using System.Collections.Generic;
using System.Text;

namespace GeneralChallenges.Codility
{
    /*
     This is a demo task.
        Write a function:
        class Solution { public int solution(int[] A); }
        that, given an array A of N integers, returns the smallest positive integer (greater than 0) that does not occur in A.
        For example, given A = [1, 3, 6, 4, 1, 2], the function should return 5.
        Given A = [1, 2, 3], the function should return 4.
        Given A = [−1, −3], the function should return 1.

        Write an efficient algorithm for the following assumptions:
        N is an integer within the range [1..100,000];
        each element of array A is an integer within the range [−1,000,000..1,000,000].
         */
    public static class FindSmallestIntUnsortedArray
    {
        /*
         A naive method to solve this problem is to search all positive integers, starting from 1 in the given array. 
         We may have to search at most n+1 numbers in the given array. So this solution takes O(n^2) in worst case.  

        We can use sorting to solve it in lesser time complexity. We can sort the array in O(nLogn) time.
        Once the array is sorted, then all we need to do is a linear scan of the array. So this approach takes O(nLogn + n) time which is O(nLogn).

        We can also use hashing. We can build a hash table of all positive elements in the given array. Once the hash table is built. 
        We can look in the hash table for all positive integers, starting from 1. As soon as we find a number which is not there in hash table, 
        we return it. This approach may take O(n) time on average, but it requires O(n) extra space.
        */
        public static int FindSmallesInt(int[] A)
        {
            HashSet<int> set = new HashSet<int>(A);

            int smallest = 1;
            int maxRange = 100000;
            while (smallest <= maxRange)
            {
                if (!set.Contains(smallest))
                {
                    return smallest;
                }
                smallest++;
            }

            return smallest;
        }
    }
}
