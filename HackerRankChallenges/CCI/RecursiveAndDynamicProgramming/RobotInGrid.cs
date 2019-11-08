using CCIChallenges.Common;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Text;

namespace CCIChallenges.RecursiveAndDynamicProgramming
{
    public static class RobotInGrid
    {
        /*To find a path to (r-1, c) or (r, c -1), we need to move to one
            of its adjacent cells. So, we need to find a path to a spot adjacent to (r -1, c), which are coordinates
            (r-2,c) and (r-1,c -1),ora spot adjacent to (r,c-1),which are spots (r - 1,c-1) and (r,c-2).
            This solution is 0 (2r+( ), since each path has r+c steps and there are two choices we can make at each step.
         */
        public static List<Point> GetPath(bool[][] maze)
        {
            if (maze == null || maze.Length == 0) return null;
            var path = new List<Point>();
            if (GetPath(maze, maze.Length - 1, maze[0].Length - 1, path))
            {
                return path;
            }
            return null;
        }
        public static bool GetPath(bool[][] maze, int row, int col, List<Point> path)
        {
            // If out of bounds or not available, return.
            if (col < 0 || row < 0)
            {
                return false;
            }

            bool isAtOrigin = (row == 0) && (col == 0);

            // If there's a path from the start to my current location, add my location.
            if (isAtOrigin || GetPath(maze, row, col - 1, path) || GetPath(maze, row - 1, col, path))
            {
                Point p = new Point(row, col);
                path.Add(p);
                return true;
            }

            return false;
        }


        //The algorithm will now take O(XY) time because we hit each cell just once
        public static List<Point> GetPathOptimizedWithDynamicProgramming(bool[][] maze)
        {
            if (maze == null || maze.Length == 0) return null;
            List<Point> path = new List<Point>();
            HashSet<Point> failedPoints = new HashSet<Point>();
            if (GetPathWithDynamicProgramming(maze, maze.Length - 1, maze[0].Length - 1, path, failedPoints))
            {
                return path;
            }
            return null;
        }
        public static bool GetPathWithDynamicProgramming(bool[][] maze, int row, int col, List<Point> path, HashSet<Point> failedPoints)
        {
            /* If out of bounds or not available, return.*/
            if (col < 0 || row < 0)
            {
                return false;
            }

            Point p = new Point(row, col);

            /* If we've already visited this cell, return. */
            if (failedPoints.Contains(p))
            {
                return false;
            }

            bool isAtOrigin = (row == 0) && (col == 0);

            /* If there's a path from the start to my current location, add my location.*/
            if (isAtOrigin || GetPathWithDynamicProgramming(maze, row, col - 1, path, failedPoints) || GetPathWithDynamicProgramming(maze, row - 1, col, path, failedPoints))
            {
                path.Add(p);
                return true;
            }

            failedPoints.Add(p); // Cache result
            return false;
        }

        public static void Main()
        {
            int size = 1000;
            bool[][] maze = MatrixHelper.BoolMatrix(size, size, 70);

            //MatrixHelper.PrintMatrix(maze);

            var watch = new Stopwatch();
            watch.Start();
            List<Point> path = GetPath(maze);
            watch.Stop();
            var time = watch.ElapsedMilliseconds;

            watch.Restart();
            var path2 = GetPathOptimizedWithDynamicProgramming(maze);
            watch.Stop();
            var optimizedTime = watch.ElapsedMilliseconds;
        }
    }
}
