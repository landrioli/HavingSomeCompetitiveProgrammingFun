using System;
using System.Collections.Generic;
using System.Text;

namespace LeetCodeChallenges.WeeklyContest
{
    public class WeeklyContest165
    {
        public string Tictactoe(int[][] moves)
        {
            var matrix = new char[3][];
            matrix[0] = new char[3];
            matrix[1] = new char[3];
            matrix[2] = new char[3];

            for (int i = 0; i < moves.Length; i++)
            {
                if (i % 2 == 0)
                {
                    matrix[moves[i][0]][moves[i][1]] = 'A';
                }
                else
                {
                    matrix[moves[i][0]][moves[i][1]] = 'B';
                }

                if (CheckIfWin('A', matrix))
                {
                    return "A";

                }
                if (CheckIfWin('B', matrix))
                {
                    return "B";
                }
            }

            if (moves.Length < 9)
                return "Pending";
            return "Draw";
        }
        private bool CheckIfWin(char team, char[][] matrix)
        {
            if (matrix[0][0] == team && matrix[0][1] == team && matrix[0][2] == team || //rows
                matrix[1][0] == team && matrix[1][1] == team && matrix[1][2] == team || //rows
                matrix[2][0] == team && matrix[2][1] == team && matrix[2][2] == team || //rows
                matrix[0][0] == team && matrix[1][0] == team && matrix[2][0] == team || //columns
                matrix[0][1] == team && matrix[1][1] == team && matrix[2][1] == team || //columns
                matrix[0][2] == team && matrix[1][2] == team && matrix[2][2] == team || //columns
                matrix[0][0] == team && matrix[1][1] == team && matrix[2][2] == team || //diagonal
                matrix[0][2] == team && matrix[1][1] == team && matrix[2][0] == team)   //diagonal
            {
                return true;
            }

            return false;
        }

        //jumbo Burger: 4 tomato slices and 1 cheese slice.
        // Small Burger: 2 Tomato slices and 1 cheese slice.
        public IList<int> NumOfBurgers(int tomatoSlices, int cheeseSlices)
        {
            if (tomatoSlices == 0 && cheeseSlices == 0)
            {
                return new List<int>() { 0, 0 };
            }

            int totalhamburgueres = cheeseSlices;

            for (int i = 0; i <= totalhamburgueres; i++)
            {
                for (int j = 0; j <= totalhamburgueres; j++)
                {
                    if (4 * i + 2 * j == tomatoSlices && i + j == cheeseSlices)
                        return new List<int>() { i, j };
                }
            }

            return new List<int>();
        }

        public void Main()
        {
            var matrix = new int[7][];
            matrix[0] = new int[2] { 1, 2 };
            matrix[1] = new int[2] { 1, 1 };
            matrix[2] = new int[2] { 0, 2 };
            matrix[3] = new int[2] { 2, 2 };
            matrix[4] = new int[2] { 2, 1 };
            matrix[5] = new int[2] { 0, 1 };
            matrix[6] = new int[2] { 0, 0 };
            Tictactoe(matrix);

            NumOfBurgers(2, 1);
        }
    }
}
