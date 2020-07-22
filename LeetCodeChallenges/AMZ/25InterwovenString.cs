using System;
using System.Collections.Generic;
using System.Text;

namespace LeetCodeChallenges.AMZ
{
    public class InterwovenString
    {
        public bool IsInterleave(string s1, string s2, string s3)
        {
            if (s3.Length != s1.Length + s2.Length)
            {
                return false;
            }
            var dp = new bool[s1.Length + 1][];
            for (int i = 0; i< s1.Length + 1; i++)
            {
                dp[i] = new bool[s2.Length + 1];
            }
            for (int i = 0; i <= s1.Length; i++) {
                for (int j = 0; j <= s2.Length; j++) {
                    if (i == 0 && j == 0) {
                        dp[i][j] = true;
                    } else if (i == 0) {
                        dp[i][j] = dp[i][j - 1] && s2[j - 1] == s3[i + j - 1];
                    } else if (j == 0) {
                        dp[i][j] = dp[i - 1][j] && s1[i - 1] == s3[i + j - 1];
                    } else {
                        dp[i][j] = (dp[i - 1][j] && s1[i - 1] == s3[i + j - 1]) ||  // The first condition is for S1 (i - 1)
                                   (dp[i][j - 1] && s2[j - 1] == s3[i + j - 1]);  //and the second for an match for S2 (j - 1)
                    }
                }
            }
            return dp[s1.Length][s2.Length];
        }

        //BUGGED
        //public bool AreInterwoven(string one, string two, string three) {
        //    var cache = new bool?[two.Length + 1][];
        //    for (int i = 0; i < two.Length + 1; i++)
        //    {
        //        cache[i] = new bool?[one.Length + 1];
        //    }

        //    bool? result = AreInterwoven(one, two, three, 0, 0, cache);

        //    return (bool)result;
        //}

        //private bool? AreInterwoven(string one, string two, string three, int i, int j, bool?[][] cache)
        //{
        //    if (cache[i][j] != null)
        //        return cache[i][j];

        //    int k = i + j;
        //    if (k == three.Length)
        //        return true;

        //    if (i < two.Length && two[i] == three[k])
        //    {
        //        cache[i][j] = AreInterwoven(one, two, three, i + 1, j, cache);
        //        if (cache[i][j] == true)
        //        {
        //            return true;
        //        }
        //    }
        //    if (j < one.Length && one[j] == three[k])
        //    {
        //        cache[i][j] = AreInterwoven(one, two, three, i, j + 1, cache);
        //        if (cache[i][j] == true)
        //        {
        //            return true;
        //        }
        //    }

        //    cache[i][j] = false;
        //    return false;
        //}

        public void Main()
        {
            IsInterleave("aabcc", "dbbca", "aadbbcbcac");
            AreInterwoven("aabcc", "dbbca", "aadbbcbcac");
        }
    }
}
