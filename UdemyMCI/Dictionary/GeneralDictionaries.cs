using System;
using System.Collections.Generic;
using System.Text;

namespace UdemyMCI.Dictionary
{
    public static class GeneralDictionaries
    {
        public static int FindFirstDuplicateOccurrenceInArray(int[] arr)
        {
            var hash = new HashSet<int>();
            for (int i = 0; i < arr.Length; i++)
            {
                if (hash.Contains(arr[i]))
                {
                    return arr[i];
                }

                hash.Add(arr[i]);
            }
            throw new Exception("Invalid input");
        }

        public static int FindFirstDuplicateOccurrenceInArraySlow(int[] arr)
        {
            var list = new List<int>();
            for (int i = 0; i < arr.Length; i++)
            {
                if (list.Contains(arr[i]))
                {
                    return arr[i];
                }

                list.Add(arr[i]);
            }
            throw new Exception("Invalid input");
        }
    }
}
