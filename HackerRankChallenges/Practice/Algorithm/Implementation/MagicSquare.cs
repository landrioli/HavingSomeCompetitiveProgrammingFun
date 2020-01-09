using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestConsole
{
    class MagicSquare
    {
        // Complete the formingMagicSquare function below.
        /* 3x3 magic square unique
         * magic sum = 15
         * 8 reflections/rotations
         * base [8,1,6][3,5,7][4,9,2]
         * Centre must be 5
         * Corners are even
         * Edges are odd
         * https://mindyourdecisions.com/blog/2015/11/08/how-many-3x3-magic-squares-are-there-sunday-puzzle/
         */

        static readonly List<List<int>> squares = new List<List<int>>
            { new List<int> {8,1,6,3,5,7,4,9,2 },
              new List<int> {6,1,8,7,5,3,2,9,4 },
              new List<int> {4,9,2,3,5,7,8,1,6 },
              new List<int> {2,9,4,7,5,3,6,1,8 },
              new List<int> {8,3,4,1,5,9,6,7,2 },
              new List<int> {4,3,8,9,5,1,2,7,6 },
              new List<int> {6,7,2,1,5,9,8,3,4 },
              new List<int> {2,7,6,9,5,1,4,3,8 }};
        //There is an easier way to see that 15 is the only sum: notice that in a completed magic square with the numbers 1 to 9, the sum of all the numbers is 1 + 2 + ... + 9 = 45, and this sum is split evenly into the 3 rows / columns, so each row and column must have sum 15.
        static int formingMagicSquare(int[][] s)
        {
            int smallestCOunter = int.MaxValue;
            foreach (var square in squares)
            {
                int currentCount = 0;
                int listPositionCount = 0;
                for (int i = 0; i < 3; i++)
                {
                    for (int j = 0; j < 3; j++)
                    {
                        if (s[i][j] != square[listPositionCount])
                        {
                            currentCount += Math.Abs(s[i][j] - square[listPositionCount]);
                        }
                        listPositionCount++;
                    }
                }
                if (currentCount < smallestCOunter)
                {
                    smallestCOunter = currentCount;
                }
            }
            return smallestCOunter;
        }

    }
}
