using System;
using System.Collections.Generic;
using System.Text;

namespace LeetCodeChallenges._30DaysChallengeCovid
{
    public class DayEightBackspaceStringCompare
    {
        public bool BackspaceCompare(string S, string T)
        {
            var s = Build(S);
            var t = Build(T);

            if (s.Count != t.Count)
                return false;

            while (s.Count != 0)
            {
                if (s.Pop() != t.Pop())
                    return false;
            }
            return true;
        }

        public Stack<char> Build(string s)
        {
            var ans = new Stack<char>();
            foreach (char c in s)
            {
                if (c != '#')
                    ans.Push(c);
                else if (ans.Count != 0)
                    ans.Pop();
            }
            return ans;
        }
    }
}
