using System;
using System.Collections.Generic;
using System.Text;

namespace CCIChallenges.RecursiveAndDynamicProgramming
{
    public static class FindPermutationsWithoutDuplicates
    {
        #region ApproachOne
        /*Approach 1: Building from permutations of first n-1 characters*/
        public static List<string> GetPermsOne(string str)
        {
            if (str == null)
            {
                return null;
            }
            List<string> permutations = new List<string>();
            if (str.Length == 0)
            { // base case
                permutations.Add("");
                return permutations;
            }

            char first = str[0]; // get the first character
            string remainder = str.Substring(1); // remove the first character
            List<string> words = GetPermsOne(remainder);
            foreach (string word in words)
            {
                for (int j = 0; j <= word.Length; j++)
                {
                    string s = insertCharAt(word, first, j);
                    permutations.Add(s);
                }
            }
            return permutations;
        }

        public static string insertCharAt(string word, char c, int i)
        {
            string start = word.Substring(0, i);
            string end = word.Substring(i);
            return start + c + end;
        }
        #endregion

        #region ApproachTwo
        /*Approach 2: Building from permutations of all n-1 character substrings.*/
        public static List<string> GetPermsTwo(string remainder)
        {
            int len = remainder.Length;
            List<string> result = new List<string>();

            /* Base case. */
            if (len == 0)
            {
                result.Add(""); // Be sure to return empty string!
                return result;
            }

            for (int i = 0; i < len; i++)
            {
                /* Remove char i and find permutations of remaining characters.*/
                string before = remainder.Substring(0, i);
                string after = remainder.Substring(i + 1);
                List<string> partials = GetPermsTwo(before + after);

                /* Prepend char i to each permutation.*/
                foreach (string s in partials)
                {
                    result.Add(remainder[i] + s);
                }
            }

            return result;
        }
        #endregion

        #region ApproachThree 
        //Alternatively, instead of passing the permutations back up the stack, we can push the prefix down the stack. When we get to the bottom (base case),
        //prefix holds a full permutation.
        public static void GetPermsThree(string prefix, string remainder, List<string> result)
        {
            if (remainder.Length == 0)
            {
                result.Add(prefix);
            }
            int len = remainder.Length;
            for (int i = 0; i < len; i++)
            {
                string before = remainder.Substring(0, i);
                string after = remainder.Substring(i + 1, len);
                char c = remainder[i];
                GetPermsThree(prefix + c, before + after, result);
            }
        }

        public static List<string> GetPermsThree(string str)
        {
            List<string> result = new List<string>();
            GetPermsThree("", str, result);
            return result;
        }
        #endregion

        public static void Main()
        {
           var result = GetPermsTwo("abc");
        }
    }
}
