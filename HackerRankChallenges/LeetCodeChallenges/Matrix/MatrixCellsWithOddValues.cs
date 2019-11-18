using System;
using System.Collections.Generic;
using System.Text;

namespace LeetCodeChallenges.Matrix
{
    /*
     https://leetcode.com/contest/weekly-contest-162/problems/cells-with-odd-values-in-a-matrix/
     1252. Cells with Odd Values in a Matrix
    Given n and m which are the dimensions of a matrix initialized by zeros and given an array indices where indices[i] = [ri, ci]. 
    For each pair of [ri, ci] you have to increment all cells in row ri and column ci by 1.
    Return the number of cells with odd values in the matrix after applying the increment to all indices.
         */
    class MatrixCellsWithOddValues
    {
        public static int OddCells(int n, int m, int[][] indices)
        {
            var finalMatrix = new int[n, m];
            for (int i = 0; i < indices.Length; i++)
            {
                var currentN = indices[i][0];
                var currentM = indices[i][1];

                //Update rows
                for (int j = 0; j < m; j++)
                {
                    ++finalMatrix[currentN, j];
                }
                //Update Columns
                for (int j = 0; j < n; j++)
                {
                    ++finalMatrix[j, currentM];
                }
            }

            int totalOdds = 0;
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < m; j++)
                {
                    if (finalMatrix[i, j] % 2 != 0)
                        totalOdds++;
                }
            }
            return totalOdds;
        }
    }
}
