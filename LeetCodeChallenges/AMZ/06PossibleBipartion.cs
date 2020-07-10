using System;
using System.Collections.Generic;
using System.Text;

namespace LeetCodeChallenges.AMZ
{
    //https://leetcode.com/problems/possible-bipartition/
    /*Given a set of N people (numbered 1, 2, ..., N), we would like to split everyone into two groups of any size.
        Each person may dislike some other people, and they should not go into the same group. 
        Formally, if dislikes[i] = [a, b], it means it is not allowed to put the people numbered a and b into the same group.
        Return true if and only if it is possible to split everyone into two groups in this way.
    */
    public class PossibleBipartion
    {
        /*
            Time Complexity: O(N + E)
            Space Complexity: O(N + E)
            where N is the number of people and E is the number of dislike pairs.
            https://www.youtube.com/watch?v=0ACfAqs8mm0
             */
        public bool PossibleBipartition(int N, int[][] dislikes)
        {
            bool[][] g = new bool[N][];
            for (int i = 0; i < g.Length; i++)
            {
                g[i] = new bool[N];
            }

            foreach (int[] d in dislikes)
            {
                g[d[0] - 1][d[1] - 1] = true;
                g[d[1] - 1][d[0] - 1] = true;
            }
            int[] colors = new int[N];
            for (int i = 0; i < N; i++)
                if (colors[i] == 0 && !PaintDfs(i, 1, colors, g))
                    return false;
            return true;
        }

        private bool PaintDfs(int posicao, int color, int[] colors, bool[][] g)
        {   
            if (colors[posicao] != 0)
                return colors[posicao] == color;
            colors[posicao] = color;
            for (int v = 0; v < colors.Length; v++)
                if (g[posicao][v] && !PaintDfs(v, -color, colors, g))
                    return false;
            return true;
        }

        public void Main()
        {
            var dislikePairs = new int[3][];
            dislikePairs[0] = new int[] { 1, 2 };
            dislikePairs[1] = new int[] { 1, 3 };
            dislikePairs[2] = new int[] { 2, 4 };
            PossibleBipartition(4, dislikePairs);
        }
    }
}
