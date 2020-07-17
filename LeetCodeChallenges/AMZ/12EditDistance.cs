using System;
using System.Collections.Generic;
using System.Text;

namespace LeetCodeChallenges.AMZ
{
    //https://leetcode.com/problems/edit-distance/
    /*
     Given two words word1 and word2, find the minimum number of operations required to convert word1 to word2.
    You have the following 3 operations permitted on a word:
    Insert a character
    Delete a character
    Replace a character
                Input: word1 = "horse", word2 = "ros"
                Output: 3
                Explanation: 
                horse -> rorse (replace 'h' with 'r')
                rorse -> rose (remove 'r')
                rose -> ros (remove 'e')
         */
    public class EditDistance
    {
        // j == x == represent the row number
        // i == y == represent the column number
        // new int[columns][rows]; 4 columns 2 rows == [4][2]
        public int MinDistance(string word1, string word2)
        {
            var dp = new int[word2.Length + 1][];
            for (int i = 0; i < word2.Length + 1; i++)
                dp[i] = new int[word1.Length + 1];

            // Fill first colum with base case
            for (int i = 1; i < word2.Length + 1; i++)
                dp[i][0] = dp[i - 1][0] + 1;

            // Fill first row with base case
            for (int i = 1; i < word1.Length + 1; i++)
                dp[0][i] = dp[0][i - 1] + 1;

            for (int i = 1; i < dp.Length; i++)
            {
                for (int j = 1; j < dp[0].Length; j++)
                {
                    if (word1[j - 1] == word2[i - 1]) // Base case, here if is the same letter, we get the last calculated value
                    {
                        dp[i][j] = dp[i - 1][j - 1];
                        continue;
                    }
                    // if letter is different, get the last better choince plus one more operation
                    dp[i][j] = 1 + Math.Min(Math.Min(dp[i - 1][j - 1], dp[i - 1][j]), dp[i][j - 1]);
                }
            }

            return dp[word2.Length][word1.Length];
        }

        public void Main() {
            MinDistance("host","ros");
        }
    }
}
