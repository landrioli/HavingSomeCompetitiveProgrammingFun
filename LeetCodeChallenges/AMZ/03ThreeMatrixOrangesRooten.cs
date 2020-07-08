using System;
using System.Collections.Generic;
using System.Text;

namespace LeetCodeChallenges.AMZ
{
    //https://leetcode.com/problems/rotting-oranges/
    //In a given grid, each cell can have one of three values:
    //the value 0 representing an empty cell;
    //the value 1 representing a fresh orange;
    //the value 2 representing a rotten orange.
    //Every minute, any fresh orange that is adjacent (4-directionally) to a rotten orange becomes rotten.
    //Return the minimum number of minutes that must elapse until no cell has a fresh orange.If this is impossible, return -1 instead.
    public class ThreeMatrixOrangesRooten
    {
        /*# Time complexity: O(rows * cols) -> each cell is visited at least once
            Space complexity: O(rows * cols) -> in the worst case if all the oranges are rotten they will be added to the queue*/
        public int orangesRotting(int[][] grid)
        {
            if (grid == null || grid.Length == 0) return 0;
            int rows = grid.Length;
            int cols = grid[0].Length;
            Queue<int[]> queueRooten = new Queue<int[]>();
            int freshCount = 0;
            //Put the position of all rotten oranges in queue
            //count the number of fresh oranges
            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < cols; j++)
                {
                    if (grid[i][j] == 2)
                    {
                        queueRooten.Enqueue(new int[] { i, j });
                    }
                    else if (grid[i][j] == 1)
                    {
                        freshCount++;
                    }
                }
            }
            //if count of fresh oranges is zero --> return 0 
            if (freshCount == 0) return 0;
            int count = 0;
            var dirs = new List<KeyValuePair<int, int>>() {
                new KeyValuePair<int, int>(1, 0),
                new KeyValuePair<int, int>(-1, 0),
                new KeyValuePair<int, int>(0, 1),
                new KeyValuePair<int, int>(0, -1),
            };
            //bfs starting from initially rotten oranges
            while (queueRooten.Count != 0)
            {
                ++count;
                int size = queueRooten.Count;
                for (int i = 0; i < size; i++)
                {
                    int[] point = queueRooten.Dequeue();
                    foreach(var dir in dirs)
                    {
                        int x = point[0] + dir.Key;
                        int y = point[1] + dir.Value;
                        //if x or y is out of bound
                        //or the orange at (x , y) is already rotten
                        //or the cell at (x , y) is empty
                        //we do nothing
                        if (x < 0 || y < 0 || x >= rows || y >= cols || grid[x][y] == 0 || grid[x][y] == 2) continue;
                        //mark the orange at (x , y) as rotten and put the new rotten orange at (x , y) in queue
                        grid[x][y] = 2;
                        queueRooten.Enqueue(new int[] { x, y });
                        //decrease the count of fresh oranges because the fresh become rooten
                        freshCount--;
                    }
                }
            }
            return freshCount == 0 ? count - 1 : -1;
        }
    }
}
