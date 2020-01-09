using System;
using System.Collections.Generic;
using System.Text;

namespace HackerRankChallenges.Practice.Algorithm.Implementation
{
    public class DrawingBook
    {
        static int pageCount(int n, int p)
        {
            int total = n / 2;
            int right = p / 2;
            int left = total - right;
            if (right < left)
            {
                return right;
            }
            else
            {
                return left;
            }
        }
    }
}
