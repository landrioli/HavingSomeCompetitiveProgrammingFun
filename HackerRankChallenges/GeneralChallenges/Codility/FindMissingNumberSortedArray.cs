using System;
using System.Collections.Generic;
using System.Text;

namespace GeneralChallenges.Codility
{
    public static class FindMissingNumberSortedArray
    {
        /*
         METHOD 1(Use sum formula)
            Algorithm:

            1. Get the sum of numbers which is total = n*(n+1)/2
            2. Subtract all the numbers from sum and
               you will get the missing number
             Time Complexity: O(n)
             PS: Take care with big number because it can put in overflow state.... (The next approach we will fix it) int total = (n + 1) * (n + 2) / 2;
             PS: It will work for nonordered arrays
         */
        static int GetMissingNo(int[] a, int n)
        {
            int total = (n + 1) * (n + 2) / 2;

            for (int i = 0; i < n; i++)
                total -= a[i];

            return (int)total;
        }

        /*There can be overflow if n is large. In order to avoid Integer Overflow, we can pick one number from known numbers and subtract one number from given numbers. 
         * This way we won’t have Integer Overflow ever. Thanks to Sahil Rally for suggesting this improvement.
         PS: It will work for nonordered arrays*/
        static int GetMissingNoHandlingOverflow(int[] a, int n)
        {
            int i, total = 1;

            for (i = 2; i <= (n + 1); i++)
            {
                total += i;
                total -= a[i - 2];
            }
            return total;
        }


        /*An efficient solution is based on the divide and conquer algorithm that we have seen in binary search, 
         * the concept behind this solution is that the elements appearing before the missing element will have ar[i] – i = 1 and 
         * those appearing after the missing element will have ar[i] – i = 2.
            This solution has a time complexity of O(log n)
            PS: It only works for ordered arrays*/
        static int Search(int[] ar,
                  int size)
        {
            int a = 0, b = size - 1;
            int mid = 0;
            while ((b - a) > 1)
            {
                mid = (a + b) / 2;
                if ((ar[a] - a) != (ar[mid] - mid))
                    b = mid;
                else if ((ar[b] - b) != (ar[mid] - mid))
                    a = mid;
            }
            return (ar[mid] + 1);
        }

        static public void Main()
        {
            int[] ar = { 1, 2, 3, 4, 5, 7 };
            GetMissingNo(ar, ar.Length);

            GetMissingNoHandlingOverflow(ar, ar.Length);

            
            int size = ar.Length;
            Console.WriteLine("Missing number: " +
                                Search(ar, size));

        }
    }
}
