using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestConsole
{
    /*https://leetcode.com/problems/count-square-submatrices-with-all-ones/
     * Given a m * n matrix of ones and zeros, return how many square submatrices have all ones.
     */
    public class CountSquaresInMatrix
    {
        public int countSquares(int[][] matrix)
        {
            int n = matrix.Length;
            int m = matrix[0].Length;
            int[][] dp = new int[n][];
            for (int i = 0; i < n; i++)
            {
                dp[i] = new int[m];
            }
            int count = 0;
            for (int i = 0; i < n; i++) if (matrix[i][0] == 1) dp[i][0] = 1;
            for (int j = 0; j < m; j++) if (matrix[0][j] == 1) dp[0][j] = 1;

            // dp[i][j] will tell you the max side of the square with bottom right corner at (i, j).
            for (int i = 1; i < n; i++)
            {
                for (int j = 1; j < m; j++)
                {
                    if (matrix[i][j] == 1)
                    {
                        int min = 1 + Math.Min(dp[i - 1][j], Math.Min(dp[i][j - 1], dp[i - 1][j - 1]));
                        dp[i][j] = min;
                    }
                }
            }

            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < m; j++) count += dp[i][j];
            }

            return count;
        }
    }
}
