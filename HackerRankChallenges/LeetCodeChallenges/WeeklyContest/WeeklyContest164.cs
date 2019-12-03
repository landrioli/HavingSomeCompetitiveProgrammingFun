using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;

namespace LeetCodeChallenges.WeeklyContest
{
    public class WeeklyContest164
    {
        /*https://leetcode.com/contest/weekly-contest-164/problems/minimum-time-visiting-all-points/
         *Minimum Time Visiting All Points
           Difficulty:Easy
           On a plane there are n points with integer coordinates points[i] = [xi, yi]. Your task is to find the minimum time in seconds to visit all points.
           
           You can move according to the next rules:
           
           In one second always you can either move vertically, horizontally by one unit or diagonally (it means to move one unit vertically and one unit horizontally in one second).
           You have to visit the points in the same order as they appear in the array.
         */
        public int MinTimeToVisitAllPoints(int[][] points)
        {
            int totalTime = 0;
            int currentX = points[0][0];
            int currentY = points[0][1];
            for (int i = 1; i < points.Length; i++)
            {
                int targetX = points[i][0];
                int targetY = points[i][1];

                var totalOperationsX = Math.Abs(targetX - currentX);
                var totalOperationsY = Math.Abs(targetY - currentY);

                totalTime += Math.Min(totalOperationsY,totalOperationsX);
                totalTime += Math.Abs(totalOperationsY - totalOperationsX);

                currentX = targetX;
                currentY = targetY;
            }

            return totalTime;
        }

        /*https://leetcode.com/contest/weekly-contest-164/problems/count-servers-that-communicate/
         *1267. Count Servers that Communicate
        Difficulty:Medium
        You are given a map of a server center, represented as a m * n integer matrix grid, where 1 means that on that cell there is a server and 0 means that it is no server. Two servers are said to communicate if they are on the same row or on the same column.
        Return the number of servers that communicate with any other server.
         *
         */
        public int CountServers(int[][] grid)
        {
            int totalNodesConnected = 0;
            var rows = new int[250];
            var columns = new int[250];

            for (int r = 0; r < grid.Length; r++)
            {
                for (int c = 0; c < grid[0].Length; c++)
                {
                    if (grid[r][c] == 1)
                    {
                        rows[r]++;
                        columns[c]++;
                    }
                }
            }

            for (int r = 0; r < grid.Length; r++)
            {
                for (int c = 0; c < grid[0].Length; c++)
                {
                    if (grid[r][c] == 1 && (rows[r] > 1 || columns[c] > 1))
                    {
                        totalNodesConnected++;
                    }
                }
            }

            return totalNodesConnected;
        }

        /*https://leetcode.com/contest/weekly-contest-164/problems/search-suggestions-system/
         *1268. Search Suggestions System
           Difficulty:Medium
           Given an array of strings products and a string searchWord. We want to design a system that suggests at most three product names from products after each character of searchWord is typed. Suggested products should have common prefix with the searchWord. If there are more than three products with a common prefix return the three lexicographically minimums products.
           Return list of lists of the suggested products after each character of searchWord is typed. 
         */
        //Slow Solution - Brute Force
        public IList<IList<string>> SuggestedProductsBruteForce(string[] products, string searchWord)
        {
            products = products.OrderBy(p => p).ToArray();
            var finalList = new List<IList<string>>();
            var letters = searchWord.ToCharArray();
            var currentWord = string.Empty;

            for (int i = 0; i < letters.Length; i++)
            {
                var currentlist = new List<string>();
                currentWord += letters[i];
                for (int j = 0; j < products.Length; j++)
                {
                    if (products[j].StartsWith(currentWord))
                    {
                        currentlist.Add(products[j]);
                    }

                    if (currentlist.Count == 3 || j+1 == products.Length)
                    {
                        finalList.Add(currentlist);
                        break;
                    }
                }
            }
            return finalList;
        }

        /*As the products arrays will be ordered, we can binary search to find the first ocurrency and after that we try to get the index plus 2 + words that match
         O(n logn)*/
        public List<List<String>> SuggestedProducts(String[] products, String searchWord)
        {
            products = products.OrderBy(p => p).ToArray();
            List<List<String>> ans = new List<List<String>>();
            for (int i = 1; i <= searchWord.Length; i++)
            {
                int index = binarySearch(products, searchWord, i);
                if (index == -1)
                {
                    ans.Add(new List<string>());
                    continue;
                }
                List<String> prefixes = new List<string>();
                for (int j = 0; j < 3 && index + j < products.Length; j++)
                {
                    if (compare(products[j + index], searchWord, i) == 0)
                    {
                        prefixes.Add(products[j + index]);
                    }
                }
                ans.Add(prefixes);
            }
            return ans;
        }

        public int binarySearch(String[] p, String s, int len)
        {
            int l = 0;
            int r = p.Length- 1;
            while (l < r)
            {
                int m = (l + r) / 2;
                if (compare(p[m], s, len) < 0)
                {
                    l = m + 1;
                }
                else
                {
                    r = m;
                }
            }
            if (compare(p[l], s, len) == 0)
            {
                return l;
            }
            else
            {
                return -1;
            }
        }

        public int compare(String a, String b, int prefix)
        {
            for (int i = 0; i < prefix; i++)
            {
                if (a.Length == i)
                {
                    return -1;
                }
                if (a[i] != b[i])
                {
                    return a[i] - b[i];
                }
            }
            return 0;
        }
    }
}
