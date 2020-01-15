using System;
using System.Collections.Generic;
using System.Text;

namespace HackerRankChallenges.Practice.Algorithm.Implementation
{
    public class ClimbingTheLeaderboard
    {
        //Tring to improve the timecomplexity from O(N logN) to O(n)
        // Is  not completely correct yet..
        public int[] climbingLeaderboard(int[] scores, int[] alice)
        {
            var result = new int[alice.Length];
            var positions = new int[scores.Length];

            //Fill the positions based on scores
            int currentPosition = 1;
            positions[0] = currentPosition;
            for (int i = 1; i < scores.Length; i++)
            {
                if (scores[i] != scores[i - 1])
                    currentPosition++;
                positions[i] = currentPosition;
            }

            int alicePosition = 0;
            for (int i = scores.Length - 1; i >= 0; i--)
            {
                if (alicePosition == alice.Length)
                    return result;
                if (alice[alicePosition] > scores[0])
                {
                    result[alicePosition] = 1;
                    alicePosition++;
                }
                else if (alice[alicePosition] == scores[i])
                {
                    result[alicePosition] = positions[i];
                    alicePosition++;
                }
                else if(alice[alicePosition] < scores[i])
                {
                    result[alicePosition] = positions[i] + 1;
                    alicePosition++;
                }
            }

            return result;
        }

        //O(n log n) - All test cases are passing
        public int[] climbingLeaderboardWithBinarySearch(int[] scores, int[] alice)
        {
            var result = new int[alice.Length];
            var positions = new int[scores.Length];

            //Fill the positions based on scores
            int currentPosition = 1;
            positions[0] = currentPosition;
            for (int i = 1; i < scores.Length; i++)
            {
                if (scores[i] != scores[i - 1])
                    currentPosition++;
                positions[i] = currentPosition;
            }

            for (int i = 0; i < alice.Length; i++)
            {
                if (alice[i] > scores[0])
                {
                    result[i] = 1;
                }
                else if (alice[i] < scores[scores.Length - 1])
                {
                    result[i] = positions[positions.Length - 1] + 1;
                }
                else
                {
                    int index = GetPositionWithBinarySearch(scores, alice[i]);
                    result[i] = positions[index];
                }
            }

            return result;
        }
        private int GetPositionWithBinarySearch(int[] scores, int scoreTarget)
        {
            int low = 0;
            int high = scores.Length - 1;

            while (low <= high)
            {
                int middle = low + (high - low) / 2;
                if (scores[middle] == scoreTarget)
                {
                    return middle;
                }
                else if (scoreTarget < scores[middle] && scoreTarget > scores[middle + 1])
                {
                    return middle + 1;
                }
                else if (scoreTarget > scores[middle] && scoreTarget < scores[middle - 1])
                {
                    return middle;
                }
                else if (scoreTarget < scores[middle])
                {
                    low = middle + 1;
                }
                else
                {
                    high = middle - 1;
                }

            }
            return -1;
        }
    }
}
    