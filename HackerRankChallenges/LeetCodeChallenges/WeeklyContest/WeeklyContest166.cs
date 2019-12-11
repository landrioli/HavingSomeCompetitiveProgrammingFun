using System;
using System.Collections.Generic;
using System.Text;

namespace LeetCodeChallenges.WeeklyContest
{
    public class WeeklyContest166
    {
        /*1281. Subtract the Product and Sum of Digits of an Integer
        Difficulty:Easy
        Given an integer number n, return the difference between the product of its digits and the sum of its digits.*/
        public int SubtractProductAndSum(int n)
        {
            int product = 1;
            int sum = 0;
            while (n != 0)
            {
                int digit = n % 10;
                product *= digit;
                sum += digit;
                n = (int)n / 10;
            }
            return product - sum;
        }

        /*1282. Group the People Given the Group Size They Belong To
        Difficulty:Medium
        There are n people whose IDs go from 0 to n - 1 and each person belongs exactly to one group. Given the array groupSizes of length n telling the group size each person belongs to, return the groups there are and the people's IDs each group includes.
        You can return any solution in any order and the same applies for IDs. Also, it is guaranteed that there exists at least one solution.*/
        public IList<IList<int>> GroupThePeople(int[] groupSizes)
        {
            Dictionary<int, List<int>> dic = new Dictionary<int, List<int>>();
            var finalList = new List<IList<int>>();

            for (int i = 0; i < groupSizes.Length; i++)
            {
                int currentSize = groupSizes[i];
                if (dic.ContainsKey(groupSizes[i]))
                {
                    if (dic[currentSize].Count < currentSize)
                    {
                        dic[currentSize].Add(i);
                    }
                    if (dic[currentSize].Count == currentSize)
                    {
                        finalList.Add(dic[currentSize]);
                        dic.Remove(currentSize);
                    }
                }
                else
                {
                    dic.Add(currentSize, new List<int>() { i });
                    if (dic[currentSize].Count == currentSize)
                    {
                        finalList.Add(dic[currentSize]);
                        dic.Remove(currentSize);
                    }
                }
            }

            return finalList;
        }

        /*1283. Find the Smallest Divisor Given a Threshold
        Difficulty:Medium
        Given an array of integers nums and an integer threshold, we will choose a positive integer divisor and divide all the array by it and sum the result of the division. Find the smallest divisor such that the result mentioned above is less than or equal to threshold.
        Each result of division is rounded to the nearest integer greater than or equal to that element. (For example: 7/3 = 3 and 10/2 = 5).
        It is guaranteed that there will be an answer.*/
        /*Use (n + divisor - 1) / divisor to get the ceil of n / divisor (Because the challenge says: Each result of division is rounded to the nearest integer greater than or equal to that element);
        Binary search to get the correct divisor: if the trial sum
            a) <= threshold, divisor >= solution, decrease right bould;
            b) > threshold, divisor < solution, increase left bound.*/
        public int SmallestDivisor(int[] nums, int threshold)
        {
            int left = 1, right = (int)1e6;
            while (left < right)
            {
                int m = (left + right) / 2, sum = 0;
                foreach (int i in nums)
                    sum += (i + m - 1) / m; //Using simple maths, we can add the denominator to the numerator and subtract 1 from it and then divide it by denominator to get the ceiling value.
                if (sum > threshold)
                    left = m + 1;
                else
                    right = m;
            }
            return left;
        }


        /*1284. Minimum Number of Flips to Convert Binary Matrix to Zero Matrix
        Difficulty:Hard
        Given a m x n binary matrix mat. In one step, you can choose one cell and flip it and all the four neighbours of it if they exist (Flip is changing 1 to 0 and 0 to 1). A pair of cells are called neighboors if they share one edge.
        Return the minimum number of steps required to convert mat to a zero matrix or -1 if you cannot.
        Binary matrix is a matrix with all cells equal to 0 or 1 only.
        Zero matrix is a matrix with all cells equal to 0.*/
        public int MinFlips(int[][] mat)
        {

            int n = mat.Length;
            int m = mat[0].Length;
            var dp = new Dictionary<string, int>();
            int ans = func(mat, n, m, new HashSet<string>(), dp);
            return ans == int.MaxValue ? -1 : ans;

        }
        public static bool check(int[][] mat, int n, int m)
        {

            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < m; j++)
                {
                    if (mat[i][j] == 1) return false;
                }
            }

            return true;
        }
        public static int func(int[][] mat, int n, int m, HashSet<String> set, Dictionary<String, int> dp)
        {
            if (check(mat, n, m)) return 0;

            String t = "";
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < m; j++)
                {
                    t += mat[i][j].ToString();
                }
            }

            if (dp.ContainsKey(t)) return dp[t];
            if (set.Contains(t)) return int.MaxValue;

            set.Add(t);

            int min = int.MaxValue;

            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < m; j++)
                {

                    mat[i][j] = mat[i][j] ^ 1;
                    if (i - 1 >= 0) mat[i - 1][j] = mat[i - 1][j] ^ 1;
                    if (i + 1 < n) mat[i + 1][j] = mat[i + 1][j] ^ 1;
                    if (j - 1 >= 0) mat[i][j - 1] = mat[i][j - 1] ^ 1;
                    if (j + 1 < m) mat[i][j + 1] = mat[i][j + 1] ^ 1;

                    int small = func(mat, n, m, set, dp);
                    if (small != int.MaxValue) min = Math.Min(min, 1 + small);

                    mat[i][j] = mat[i][j] ^ 1;
                    if (i - 1 >= 0) mat[i - 1][j] = mat[i - 1][j] ^ 1;
                    if (i + 1 < n) mat[i + 1][j] = mat[i + 1][j] ^ 1;
                    if (j - 1 >= 0) mat[i][j - 1] = mat[i][j - 1] ^ 1;
                    if (j + 1 < m) mat[i][j + 1] = mat[i][j + 1] ^ 1;
                }
            }

            set.Remove(t);
            dp[t]= min;
            return min;

        }
       

        public void Main()
        {
            SmallestDivisor(new int[3] { 1, 2, 3 }, 6);

            var matrix = new int[2][];
            for (int i = 0; i < matrix.Length; i++)
            {
                matrix[i] = new int[matrix.Length];
            }

            matrix[1][1] = 1;
            MinFlips(matrix);
        }
    }
}
