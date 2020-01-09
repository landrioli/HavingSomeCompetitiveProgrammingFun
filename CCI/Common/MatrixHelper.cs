using System;
using System.Collections.Generic;
using System.Text;

namespace CCIChallenges.Common
{
    public static class MatrixHelper
    {
        public static int[][] RandomMatrix(int m, int n, int min, int max)
        {
            int[][] matrix = new int[m][];
            for (int i = 0; i < m; i++)
            {
                matrix[i] = new int[n];
                for (int j = 0; j < n; j++)
                {
                    matrix[i][j] = RandomIntInRange(min, max);
                }
            }
            return matrix;
        }

        public static bool[][] RandomBoolMatrix(int M, int N, int percentTrue)
        {
            var matrix = new bool[M][];
            for (int i = 0; i < M; i++)
            {
                matrix[i] = new bool[N];
                for (int j = 0; j < N; j++)
                {
                    matrix[i][j] = RandomBoolean(percentTrue);
                }
            }
            return matrix;
        }
        public static bool[][] BoolMatrix(int M, int N)
        {
            var matrix = new bool[M][];
            for (int i = 0; i < M; i++)
            {
                matrix[i] = new bool[N];
                for (int j = 0; j < N; j++)
                {
                    matrix[i][j] = true;
                }
            }
            return matrix;
        }

        public static void PrintMatrix(int[][] matrix)
        {
            for (int i = 0; i < matrix.Length; i++)
            {
                for (int j = 0; j < matrix[i].Length; j++)
                {
                    if (matrix[i][j] < 10 && matrix[i][j] > -10)
                    {
                        Console.Write(" ");
                    }
                    if (matrix[i][j] < 100 && matrix[i][j] > -100)
                    {
                        Console.Write(" ");
                    }
                    if (matrix[i][j] >= 0)
                    {
                        Console.Write(" ");
                    }
                    Console.Write(" " + matrix[i][j]);
                }
                Console.WriteLine();
            }
        }

        public static void PrintMatrix(bool[][] matrix)
        {
            for (int i = 0; i < matrix.Length; i++)
            {
                for (int j = 0; j < matrix[i].Length; j++)
                {
                    if (matrix[i][j])
                    {
                        Console.Write("1");
                    }
                    else
                    {
                        Console.Write("0");
                    }
                }
                Console.WriteLine();
            }
        }

        private static bool RandomBoolean(int percentTrue)
        {
            return RandomIntInRange(1, 100) <= percentTrue;
        }

        private static int RandomIntInRange(int min, int max)
        {
            return RandomInt(max + 1 - min) + min;
        }

        private static int RandomInt(int n)
        {
            return (int)(new Random().Next() * n);
        }
    }
}
