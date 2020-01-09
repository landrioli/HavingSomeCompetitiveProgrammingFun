using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestConsole
{
    public class NumberIsBiggerThanNeighborns
    {
        /*An array element is peak if it is NOT smaller than its neighbors. For corner elements, we need to consider only one neighbor
         A simple solution is to do a linear scan of array and as soon as we find a peak element, we return it. 
         * The worst case time complexity of this method would be O(n).
        We can use Divide and Conquer to find a peak in O(Logn) time. The idea is Binary Search based,
         * we compare middle element with its neighbors. If middle element is not smaller than any of its neighbors, 
         * then we return it. If the middle element is smaller than the its left neighbor, then there is always a peak in left half 
         * (Why? take few examples). 
         * If the middle element is smaller than the its right neighbor, then there is always a peak in right half (due to same reason as left half). Following are C and Java implementations of this approach.
         */
        int GetBiggestBetweenTwoNumbers(int[] arr, int low, int high, int n)
        {
            int m = low + high / 2;
            // Compare middle element with its neighbours (if neighbours exist) 
            if ((m == 0 || arr[m - 1] <= arr[m]) &&
                (m == n - 1 || arr[m + 1] <= arr[m]))
            {
                return arr[m];
            }
            // If middle element is not  peak and its left neighbor is greater than it,then  
            // left half must have a peak element
            else if (m > 0 && arr[m - 1] > arr[m])
            {
                GetBiggestBetweenTwoNumbers(arr, low, m - 1, arr.Length);
            }
            else
                return GetBiggestBetweenTwoNumbers(arr, (m + 1), high, n);

            return 0;
        }
    }
}
