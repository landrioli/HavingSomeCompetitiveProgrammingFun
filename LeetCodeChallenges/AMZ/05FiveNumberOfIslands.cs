using System;
using System.Collections.Generic;
using System.Text;

namespace LeetCodeChallenges.AMZ
{
    /*
     https://leetcode.com/problems/number-of-islands/
     Given a 2d grid map of '1's (land) and '0's (water), count the number of islands. 
     An island is surrounded by water and is formed by connecting adjacent lands horizontally or vertically. 
     You may assume all four edges of the grid are all surrounded by water.
            11110
            11010
            11000
            00000
            == 1 Island
    */
    public class FiveNumberOfIslands
    {
        /*
         The algorithm works as follow:
            Scan each cell in the grid.
            If the cell value is '1' explore that island (go into all the directions <-  ^  \/  ->).
                Mark the explored island cells with 'x'.
                Once finished exploring that island, increment islands counter.
                The arrays dx[], dy[] store the possible moves from the current cell. 
                Two land cells ['1'] are considered from the same island if they are horizontally or vertically adjacent (possible moves (-1,0),(0,1),(0,-1),(1,0)). 
                Two '1' diagonally adjacent are not considered from the same island.
             */
        private readonly int[] dx = { -1, 0, 0, 1 };
        private readonly int[] dy = { 0, 1, -1, 0 };
        private int NumIslands(char[][] grid)
        {
            if (grid == null || grid.Length == 0) return 0;
            int islands = 0;
            for (int i = 0; i < grid.Length; i++)
            {
                for (int j = 0; j < grid[i].Length; j++)
                {
                    if (grid[i][j] == '1')
                    {
                        Explore(grid, i, j);
                        islands++;
                    }
                }
            }
            return islands;
        }           
        /*
            x1110
            x1010
            x1000
            00000
                */
        private void Explore(char[][] grid, int i, int j)
        {
            grid[i][j] = 'x';
            for (int d = 0; d < dx.Length; d++)
            {
                if (i + dy[d] < grid.Length && 
                    i + dy[d] >= 0 && 
                    j + dx[d] < grid[0].Length && 
                    j + dx[d] >= 0 && 
                    grid[i + dy[d]][j + dx[d]] == '1')
                {
                    Explore(grid, i + dy[d], j + dx[d]);
                }
            }
        }

        public void Main() {
            /*
            11110
            11010
            11000
            00000
                */
            var grid = new char[4][];
            grid[0] = new char[5] { '1', '1', '1', '1', '0' };
            grid[1] = new char[5] { '1', '1', '0', '1', '0' };
            grid[2] = new char[5] { '1', '1', '0', '0', '0' };
            grid[3] = new char[5] { '0', '0', '0', '0', '0' };
            NumIslands(grid);
        }
    }
}
