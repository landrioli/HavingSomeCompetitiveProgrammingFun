using System;
using System.Collections.Generic;
using System.Text;

namespace LeetCodeChallenges.Arrays
{
    public static class LongestPalindromeInstring
    {
        public static string LongestPalindrome(string s)
        {
            int n = s.Length;
            string res = null;
            int palindromeStartsAt = 0, maxLen = 0;

            bool[][] dp = new bool[n][];
            // dp[i][j] indicates whether substring s starting at index i and ending at j is palindrome
            //initialize DP
            for (int i = 0; i < n; i++)
            {
                dp[i] = new bool[n];
            }

            for (int i = n - 1; i >= 0; i--)
            { // keep increasing the possible palindrome string
                for (int j = i; j < n; j++)
                { // find the max palindrome within this window of (i,j)

                    //check if substring between (i,j) is palindrome
                    dp[i][j] = (s[i] == s[j]) // chars at i and j should match
                               &&
                               (j - i < 3  // if window is less than or equal to 3, just end chars should match
                                || dp[i + 1][j - 1]); // if window is > 3, substring (i+1, j-1) should be palindrome too

                    //update max palindrome string
                    if (dp[i][j] && (j - i + 1 > maxLen))
                    {
                        palindromeStartsAt = i;
                        maxLen = j - i + 1;
                    }

                    PrintMatrix(dp);
                }
            }
            return s.Substring(palindromeStartsAt, palindromeStartsAt + maxLen);
        }

        private static void PrintMatrix(bool[][] matrix)
        {
            for (int i = 0; i < matrix.Length; i++)
            {
                for (int j = 0; j < matrix.Length; j++)
                {
                    Console.Write(matrix[i][j] + " ");
                }
                Console.WriteLine();
            }
            Console.WriteLine("====================================");
        }
    }
}
