using System;
using System.Collections.Generic;
using System.Text;

namespace HackerRankChallenges.Practice.InterviewPreparationKit.QueueAndStack
{
    public static class BalancedBrackets
    {
        private const string _bad = "NO";
        private const string _good = "YES";
        private static readonly Dictionary<char, char> _mappingBrackets = new Dictionary<char, char>() {
            { '[', ']' },
            { '{', '}' },
            { '(', ')' }
        };

        public static string isBalanced(string s)
        {
            char[] input = s.ToCharArray();
            Stack<char> stack = new Stack<char>();
            for (int i = 0; i < s.Length; i++)
            {
                if (_mappingBrackets.ContainsKey(s[i]))
                {
                    //Its a opening bracket
                    stack.Push(_mappingBrackets[s[i]]);
                }
                else
                {
                    //Its a closing bracket
                    if (stack.Count > 0)
                    {
                        var bracket = stack.Pop();
                        if (bracket != s[i])
                        {
                            return _bad;
                        }
                    }
                    else
                    {
                        return _bad;
                    }
                }
            }
            return stack.Count == 0 ? _good : _bad;
        }
    }
}
