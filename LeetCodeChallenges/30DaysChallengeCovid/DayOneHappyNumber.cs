using System;
using System.Collections.Generic;
using System.Text;

namespace LeetCodeChallenges._30DaysChallengeCovid
{
    public class DayOneHappyNumber
    {
        public bool IsHappy(int n)
        {
            var hashset = new HashSet<int>();
            int result = 0;
            while (result != 1)
            {
                if (!hashset.Add(n))
                    return false;
                result = 0;
                while (n != 0)
                {
                    var s = n % 10;
                    n = n / 10;
                    result += (int)Math.Pow(s, 2);
                }
                n = result;
            }
            return true;
        }


        public bool IsHappyOptimazedUsingFloyd(int n)
        {
            if (n < 0)
                return false;
            int fast = Calc(Calc(n));
            int slow = Calc(n);
            while (fast != slow)
            {
                fast = Calc(Calc(fast));
                slow = Calc(slow);
            }
            return fast == 1;
        }

        private int Calc(int n)
        {
            int sum = 0;
            while (n != 0)
            {
                int digit = n % 10;
                sum += (digit * digit);
                n /= 10;
            }
            return sum;
        }
    }
}
