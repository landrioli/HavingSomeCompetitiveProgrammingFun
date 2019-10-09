using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HackerRankChallenges.Practice.InterviewPreparationKit.WarnUp
{
    //https://www.hackerrank.com/challenges/repeated-string/problem?h_l=interview&playlist_slugs%5B%5D=interview-preparation-kit&playlist_slugs%5B%5D=warmup
    class RepeatedString
    {
        // Complete the repeatedString function below.
        static long repeatedString(string s, long n)
        {
            int quantityOfLetterA = 0;
            var inputChars = s.ToCharArray();

            long completedWordsOcurrence = (long)n / inputChars.Length;
            long rest = n % inputChars.Length;
            for (int i = 0; i < rest; i++)
            {
                if (inputChars[i] == 'a')
                {
                    quantityOfLetterA++;
                }
            }

            return quantityOfLetterA + completedWordsOcurrence * inputChars.Count(p => p == 'a');
        }
    }
}
