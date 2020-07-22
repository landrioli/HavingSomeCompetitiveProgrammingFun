using System;
using System.Collections.Generic;
using System.Text;

namespace LeetCodeChallenges.AMZ
{
    /*
     *https://leetcode.com/problems/01-matrix
     *Given a matrix consists of 0 and 1, find the distance of the nearest 0 for each cell.
        The distance between two adjacent cells is 1.
     */
    public class MatrixDistanceOfEachOneZero
    {
        // time == Space == O(R x C)
        public int[][] updateMatrix(int[][] matrix)
        {
            int m = matrix.Length;
            int n = matrix[0].Length;

            var queue = new Queue<int[]>();
            for (int i = 0; i < m; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    if (matrix[i][j] == 0)
                    {
                        queue.Enqueue(new int[] { i, j });
                    }
                    else
                    {
                        matrix[i][j] = int.MaxValue;
                    }
                }
            }

            var dirs = new int[4][] {
                new[] { -1, 0 },
                new[] { 1, 0 },
                new[] { 0, -1 },
                new[] { 0, 1 } };

            while (queue.Count != 0)
            {
                int[] cell = queue.Dequeue();
                foreach (var direction in dirs)
                {
                    int r = cell[0] + direction[0];
                    int c = cell[1] + direction[1];
                    if (r < 0 || r >= m || c < 0 || c >= n ||
                        matrix[r][c] <= matrix[cell[0]][cell[1]] + 1)
                        continue;
                    queue.Enqueue(new int[] { r, c });
                    matrix[r][c] = matrix[cell[0]][cell[1]] + 1; // Get the original position that we came from to arrive in the targe
                }
            }

            return matrix;
        }

        public void Main() {
            var matrix = new int[4][] {
                new[] { 0, 0,0 },
                new[] { 0, 1, 0 },
                new[] { 1, 1, 1 },
                new[] { 1, 1, 1 }};
            updateMatrix(matrix);
        }
    }
}
