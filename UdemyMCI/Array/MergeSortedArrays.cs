using System;
using System.Collections.Generic;
using System.Text;

namespace UdemyMCI.Array
{
    public static class MergeSortedArrays
    {
        public static void Main()
        {
            var re = MergeSortedArraysMethod(new int[3] { 2, 4, 6 }, new int[4] { 3, 5, 8, 9 });
            for (int i = 0; i < re.Length; i++)
            {
                Console.WriteLine(re[i]);
            }

        }

        public static int[] MergeSortedArraysMethod(int[] a, int[] b)
        {
            if (a.Length == 0)
                return b;
            if (b.Length == 0)
                return a;

            if (a.Length < b.Length)
            {
                MergeSortedArraysMethod(b, a);
            }

            int indexA = 0;
            int indexB = 0;
            var mergedArray = new int[a.Length + b.Length];
            for (int i = 0; i < mergedArray.Length; i++)
            {
                if (indexA >= a.Length)
                {
                    while (i < mergedArray.Length)
                    {
                        mergedArray[i] = b[indexB];
                        indexB++;
                        i++;
                    }
                    return mergedArray;
                }
                else if (indexB >= b.Length)
                {
                    while (i < mergedArray.Length)
                    {
                        mergedArray[i] = a[indexA];
                        indexA++;
                        i++;
                    }
                    return mergedArray;
                }
                else if (a[indexA] <= a[indexB])
                {
                    mergedArray[i] = a[indexA];
                    indexA++;
                }
                else
                {
                    mergedArray[i] = b[indexB];
                    indexB++;
                }
            }
            return mergedArray;
        }
    }
}
