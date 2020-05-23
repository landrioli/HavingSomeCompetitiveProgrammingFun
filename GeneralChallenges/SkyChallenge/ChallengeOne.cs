using System;
using System.Collections.Generic;
using System.Text;

namespace GeneralChallenges.SkyChallenge
{
    class ChallengeOne
    {
        private readonly Dictionary<char, int> _cardsValues = new Dictionary<char, int>()
        {
            { 'A', 14},
            { 'K', 13},
            { 'Q', 12},
            { 'J', 11},
            { 'T', 10},
            { '9', 9},
            { '8', 8},
            { '7', 7},
            { '6', 6},
            { '5', 5},
            { '4', 4},
            { '3', 3},
            { '2', 2},
        };
        public int solution(string A, string B)
        {
            if (string.IsNullOrEmpty(A) || string.IsNullOrEmpty(B))
                return 0;

            int deckLenght = A.Length;
            int alexWins = 0;
            for (int i = 0; i < deckLenght; i++)
            {
                int alecCardValue = _cardsValues[A[i]];
                int bobCardValue = _cardsValues[B[i]];
                if (alecCardValue > bobCardValue)
                    alexWins++;
            }

            return alexWins;
        }
    }
}
