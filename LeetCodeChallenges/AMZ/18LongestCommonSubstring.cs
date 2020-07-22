using System;
using System.Collections.Generic;
using System.Text;

namespace LeetCodeChallenges.AMZ
{
    public class LongestCommonSubstring
    {
        // i == y == represent the column number
        // j == x == represent the row number
        // new int[columns][rows]; 4 columns 2 rows == [4][2]
        public int LongestCommonSubsequence(string text1, string text2)
        {
            var dp = new int[text2.Length + 1][];
            for (int i = 0; i < text2.Length + 1; i++)
                dp[i] = new int[text1.Length + 1];

            for (int i = 1; i < text2.Length + 1; i++)
            {
                for (int j = 1; j < text1.Length + 1; j++)
                {
                    var lastMax = Math.Max(Math.Max(dp[i - 1][j - 1], dp[i - 1][j]), dp[i][j - 1]);
                    if (text2[i - 1] == text1[j - 1])
                        dp[i][j] = lastMax + 1;
                    else
                    {
                        dp[i][j] = lastMax;
                    }
                }
            }

            return dp[text2.Length][text1.Length];
        }

        public void Main() {
            LongestCommonSubsequence("abcde", "ace");
        }
    }
}
