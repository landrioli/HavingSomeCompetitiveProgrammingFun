using System;

namespace GeneralChallenges
{
    public static class FactorialChallenge
    {
        //Iterative
        public static int GetFactorialIterative(int number) {
            int result = 1;
            for (int i = 1; i < number; i++)
            {
                result = result * i;
            }

            return result;
        }

        //Recursive
        public static int GetFactorial(int number)
        {
            if (number <= 1)
            {
                return 1;
            }

            int total = number * GetFactorial(number - 1);

            return total;
        }
    }
}
