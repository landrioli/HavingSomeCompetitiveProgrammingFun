using System;
using System.Collections.Generic;
using System.Text;

namespace CCIChallenges.SearchAndSort
{
    /*Sparse Search: Given a sorted array of strings that is interspersed with empty strings, write a
    method to find the location of a given string.*/
    public static class SparceSearchArrayWithEmptyStrings
    {

        public static int Search(String[] strings, String str)
        {
            if (strings == null || string.IsNullOrEmpty(str))
            {
                return -1;
            }
            return SearchIterative(strings, str, 0, strings.Length - 1);
        }

        public static int SearchIterative(String[] strings, String str, int first, int last)
        {
            while (first <= last)
            {
                /* Move mid to the middle */
                int mid = (last + first) / 2;

                /* If mid is empty, find closest non-empty string */
                if (string.IsNullOrEmpty(strings[mid]))
                {
                    int left = mid - 1;
                    int right = mid + 1;
                    while (true)
                    {
                        if (left < first && right > last)
                        {
                            return -1;
                        }
                        else if (right <= last && !string.IsNullOrEmpty(strings[right]))
                        {
                            mid = right;
                            break;
                        }
                        else if (left >= first && !string.IsNullOrEmpty(strings[left]))
                        {
                            mid = left;
                            break;
                        }
                        right++;
                        left--;
                    }
                }

                int res = strings[mid].CompareTo(str);
                if (res == 0)
                { // Found it!
                    return mid;
                }
                else if (res < 0)
                { // Search right
                    first = mid + 1;
                }
                else
                { // Search left
                    last = mid - 1;
                }
            }
            return -1;
        }

        public static int SearchRecursive(String[] strings, String str, int first, int last)
        {
            if (first > last)
            {
                return -1;
            }

            /* Move mid to the middle */
            int mid = (last + first) / 2;

            /* If mid is empty, find closest non-empty string. */
            if (string.IsNullOrEmpty(strings[mid]))
            {
                int left = mid - 1;
                int right = mid + 1;
                while (true)
                {
                    if (left < first && right > last)
                    {
                        return -1;
                    }
                    else if (right <= last && !string.IsNullOrEmpty(strings[right]))
                    {
                        mid = right;
                        break;
                    }
                    else if (left >= first && !string.IsNullOrEmpty(strings[left]))
                    {
                        mid = left;
                        break;
                    }
                    right++;
                    left--;
                }
            }

            /* Check for string, and recurse if necessary */
            if (str.Equals(strings[mid]))
            { // Found it!
                return mid;
            }
            else if (strings[mid].CompareTo(str) < 0)
            { // Search right
                return SearchRecursive(strings, str, mid + 1, last);
            }
            else
            { // Search left
                return SearchRecursive(strings, str, first, mid - 1);
            }
        }

        public static int Search2(String[] strings, String str)
        {
            if (strings == null || string.IsNullOrEmpty(str))
            {
                return -1;
            }
            return SearchRecursive(strings, str, 0, strings.Length - 1);
        }

        public static void Main()
        {
            String[] stringList = { "apple", "", "", "banana", "", "", "", "carrot", "duck", "", "", "eel", "", "flower" };

            Console.WriteLine(Search(stringList, "duck"));

            Console.WriteLine(Search2(stringList, "duck"));
        }
    }
}
