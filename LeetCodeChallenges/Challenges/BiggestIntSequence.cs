using System;
using System.Collections.Generic;
using System.Text;

namespace LeetCodeChallenges.Challenges
{
    /*You are given a matrix A consisting of N rows and M columns, where each cell contains a digit. 
     * Your task is to find a continuous sequence of neighbouring cells, starting in the top-left corner and ending in 
     * the bottom-right corner (going only down and right), that creates the biggest possible integer by concatenation of digits on the path. 
     * By neighbouring cells we mean cells that have exactly one common side.*/
    public class BiggestIntSequence
    {
        public static void Main(string[] args)
        {
            int[][] matrix = new int[4][];
            matrix[0] = new int[3] { 9, 9, 7 };
            matrix[1] = new int[3] { 9, 7, 2 };
            matrix[2] = new int[3] { 6, 9, 5 };
            matrix[3] = new int[3] { 9, 1, 2 };
            var resu = new BiggestIntSequence().FindTheBiggestIntSequenceUsingDownRightOperations(matrix);

        }

        public string FindTheBiggestIntSequenceUsingDownRightOperations(int[][] A)
        {
            int nRows = A.Length;
            int mColumns = A[0].Length;

            string result = string.Empty;
            int[][] memo = new int[nRows][];
            //Initilize Aux Array
            for (int i = 0; i < nRows; i++)
            {
                memo[i] = new int[mColumns];
            }

            //Initilize all first columns
            memo[0][0] = A[0][0];
            for (int i = 1; i < nRows; i++)
            {
                //memo[i][0] = memo[i - 1][0] + A[i][0];
                memo[i][0] = int.Parse(memo[i - 1][0].ToString() + A[i][0].ToString());
            }
            //Initilize all first rows
            for (int j = 1; j < mColumns; j++)
            {
                memo[0][j] = int.Parse(memo[0][j - 1].ToString() + A[0][j].ToString());
                // memo[0][j] = memo[0][j - 1] + A[0][j];
            }

            for (int n = 1; n < nRows; n++)
            {
                for (int m = 1; m < mColumns; m++)
                {
                    //int.Parse(a.ToString() + b.ToString())
                    //memo[n][m] = A[n][m] + Math.Max(memo[n - 1][m], memo[n][m - 1])
                    memo[n][m] = int.Parse(Math.Max(memo[n - 1][m], memo[n][m - 1]).ToString() + A[n][m].ToString());
                }
            }
            return memo[nRows - 1][mColumns - 1].ToString();
        }
        void printMatrix(int[][] A)
        {
            int nRows = A.Length;
            int mColumns = A[0].Length;

            for (int n = 0; n < nRows; n++)
            {
                for (int m = 0; m < mColumns; m++)
                {
                    Console.Write(A[n][m] + " ");
                }
                Console.WriteLine();
            }
            Console.WriteLine();
        }
    }
}
