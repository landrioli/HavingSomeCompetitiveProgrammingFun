using System;
using System.Collections.Generic;
using System.Text;

namespace LeetCodeChallenges.Arrays
{
    /*https://leetcode.com/problems/longest-common-prefix/
     Write a function to find the longest common prefix string amongst an array of strings.
    If there is no common prefix, return an empty string "".
     */
    public class LongestCommonPrefix
    {
        /*The ideia here is to Find the LCP of each string from strs comparing one by one
         *Time complexity : O(S) , where S is the sum of all characters in all strings.
            Space complexity : O(1) We only used constant extra space.
         */
        public string LongestCommonPrefixHorizontalScanning(string[] strs)
        {
            if (strs.Length == 0) return "";
            string prefix = strs[0];
            for (int i = 1; i < strs.Length; i++)
                while (strs[i].IndexOf(prefix) != 0)
                {
                    prefix = prefix.Substring(0, prefix.Length - 1);
                    if (string.IsNullOrEmpty(prefix)) return "";
                }
            return prefix;
        }


        /*Approach 2: Divide and conquer
         */
        public string LongestCommonPrefixDivideAndConquer(string[] strs)
        {
            if (strs == null || strs.Length == 0) return "";
            return LongestCommonPrefixDivideAndConquer(strs, 0, strs.Length - 1);
        }
        private string LongestCommonPrefixDivideAndConquer(string[] strs, int l, int r)
        {
            if (l == r)
            {
                return strs[l];
            }
            else
            {
                int mid = (l + r) / 2;
                string lcpLeft = LongestCommonPrefixDivideAndConquer(strs, l, mid);
                string lcpRight = LongestCommonPrefixDivideAndConquer(strs, mid + 1, r);
                return CommonPrefix(lcpLeft, lcpRight);
            }
        }
        string CommonPrefix(string left, string right)
        {
            int min = Math.Min(left.Length, right.Length);
            for (int i = 0; i < min; i++)
            {
                if (left[i] != right[i])
                    return left.Substring(0, i);
            }
            return left.Substring(0, min);
        }


        /*Approach 3: Binary search: The idea is to apply binary search method to find the string with maximum value L, which is common prefix of all of the strings.
         * In the worst case we have nn equal strings with length mm
            Time complexity : O(S \cdot \log n)O(S⋅logn), where SS is the sum of all characters in all strings.
            The algorithm makes \log nlogn iterations, for each of them there are S = m \cdot nS=m⋅n comparisons, which gives in total O(S \cdot \log n)O(S⋅logn) time complexity.
            Space complexity : O(1)O(1). We only used constant extra space.
         */
        public string LongestCommonPrefixBinarySearch(string[] strs)
        {
            if (strs == null || strs.Length == 0)
                return "";
            int minLen = int.MaxValue;
            foreach (string str in strs)
                minLen = Math.Min(minLen, str.Length);
            int low = 1;
            int high = minLen;
            while (low <= high)
            {
                int middle = (low + high) / 2;
                if (IsCommonPrefix(strs, middle))
                    low = middle + 1;
                else
                    high = middle - 1;
            }
            return strs[0].Substring(0, (low + high) / 2);
        }

        private bool IsCommonPrefix(string[] strs, int len)
        {
            string str1 = strs[0].Substring(0, len);
            for (int i = 1; i < strs.Length; i++)
                if (!strs[i].StartsWith(str1))
                    return false;
            return true;
        }

        public void Main()
        {
            LongestCommonPrefixHorizontalScanning(new string[4] { "leetcode", "leets", "leet", "leeds" });
            LongestCommonPrefixDivideAndConquer(new string[4] { "leetcode", "leets", "leet", "leeds" });
        }
    }
}
