using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Test
{
	//https://leetcode.com/problems/generate-parentheses
	//Given n pairs of parentheses, write a function to generate all combinations of well-formed parentheses.
    public class GenerateParenthesis
    {
		//To generate all sequences, we use a recursion. All sequences of length n is just '(' plus all sequences of length n-1, and then ')' plus all sequences of length n-1.
        //Time Complexity : O(2^2n * n). For each of 2^2n sequences, we need to create and validate the sequence, which takes O(n) work.
        public List<String> GenerateParenthesisBruteForce(int n)
        {
            var combinations = new List<string>();
            GenerateAllBruteForce(new char[2 * n], 0, combinations);
            return combinations;
        }

        public void GenerateAllBruteForce(char[] current, int pos, List<String> result)
        {
            if (pos == current.Length)
            {
                if (IsValid(current))
                    result.Add(new string(current));
            }
            else
            {
                current[pos] = '(';
                GenerateAllBruteForce(current, pos + 1, result);
                current[pos] = ')';
                GenerateAllBruteForce(current, pos + 1, result);
            }
        }
        public bool IsValid(char[] current)
        {
            int balance = 0;
            foreach (char c in current)
            {
                if (c == '(') balance++;
                else balance--;
                if (balance < 0) return false;
            }
            return (balance == 0);
        }

        //Instead of adding '(' or ')' every time as in Brute Force Approach, let's only add them when we know it will remain a valid sequence. 
        //We can do this by keeping track of the number of opening and closing brackets we have placed so far.
        //We can start an opening bracket if we still have one (of n) left to place. And we can start a closing bracket if it would not exceed the number of opening brackets.
        public IList<string> GenerateParenthesis(int n)
        {
            var list = new List<string>();
            GenerateParenthesisBackTracking(list, "", 0, 0, n);
            return list;
        }

        private void GenerateParenthesisBackTracking(List<string> list, string s, int open, int close, int n)
        {
            if (s.Length == n * 2)
            {
                list.Add(s);
                return;
            }
            if (open < n)
                GenerateParenthesisBackTracking(list, s + "(", open + 1, close, n);
            if (close < open)
                GenerateParenthesisBackTracking(list, s + ")", open, close + 1, n);
        }

    }
}
