using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LeetCodeChallenges.BiWeeklyContext
{
    //https://leetcode.com/contest/biweekly-contest-13/ranking
    public static class BiWeeklyContextSolutions
    {
        /*
         5108. Encode Number
            Difficulty:Medium
            Given a non-negative int num, Return its encoding string.
            The encoding is done by converting the int to a string using a secret function that you should deduce from the following table
             */
        public static string Encode(int num)
        {
            if (num == 0)
                return "";

            // OR We can use the APi to do the abve steps: var result2 = Convert.ToString(num + 1, 2).Substring(1);
            num++;
            string ans = "";
            while (num > 0)
            {
                ans = (num % 2) + ans;
                num /= 2;
            }
            
            return ans.Substring(1);
        }


        /*
         1257. Smallest Common Region
            Difficulty:Medium
            You are given some lists of regions where the first region of each list includes all other regions in that list.
            Naturally, if a region X contains another region Y then X is bigger than Y.
            Given two regions region1, region2, find out the smallest region that contains both of them.
            If you are given regions r1, r2 and r3 such that r1 includes r3, it is guaranteed there is no r2 such that r2 includes r3.
             */
        public static String FindSmallestRegion(List<List<String>> regions, String region1, String region2)
        {
            var map = new Dictionary<String, String>();
            foreach (List<String> region in regions)
            {
                for (int i = 1; i < region.Count; i++)
                {
                    map[region[i]] = region[0];
                }
            }
            var hash = new HashSet<String>();
            while (region1 != null)
            {
                hash.Add(region1);
                if (map.ContainsKey(region1))
                {
                    region1 = map[region1];
                }
                else
                {
                    region1 = null;
                }
            }
            while (!hash.Contains(region2))
            {
                region2 = map[region2];
            }
            return region2;
        }


        /*
         1259. Handshakes That Don't Cross
        Difficulty:Hard
        You are given an even number of people num_people that stand around a circle and each person shakes hands with someone else, so that there are num_people / 2 handshakes total.
        Return the number of ways these handshakes could occur such that none of the handshakes cross.
        Since this number could be very big, return the answer mod 10^9 + 7
             */
        static Dictionary<int, int> cache = new Dictionary<int, int>();
        public static int NumberOfWays(int n)
        {
            if (cache.ContainsKey(n))
            {
                return cache[n];
            }
            if (n % 2 == 1) return 0;
            if (n == 0)
            {
                return 1;
            }
            long sum = 0;
            for (int i = 0; i < n; i += 2)
            {
                // Calculate the number of way of elft part and number of way of the right part
                sum += ((long)NumberOfWays(i)) * NumberOfWays(n - 2 - i);
                sum %= 1_000_000_007;
            }
            cache[n]= (int)sum;
            return (int)sum;
        }


        //private static void dfs(Dictionary<String, HashSet<String>> map, String[] col, List<String> result, int index)
        //{
        //    if (index == col.Length)
        //    {
        //        result.Add(String.Join(" ", col));
        //        return;
        //    }
        //    if (map.ContainsKey(col[index]))
        //    {
        //        String s = col[index];
        //        foreach (String sub in map[col[index]])
        //        {
        //            col[index] = sub;
        //            dfs(map, col, result, index + 1);
        //        }
        //        col[index] = s;
        //    }
        //    else
        //    {
        //        dfs(map, col, result, index + 1);
        //    }
        //}
        //public static List<String> GenerateSentences(List<List<String>> synonyms, String text)
        //{
        //    Dictionary<String, HashSet<String>> map = new Dictionary<String, HashSet<String>>();

        //    foreach (List<String> synonym in synonyms)
        //    {
        //        HashSet<String> s1 = map[synonym[0]] = new HashSet<String>();
        //        HashSet<String> s2 = map[synonym[1]] = new HashSet<String>();
        //        if (s1 == s2)
        //        {
        //            continue;
        //        }
        //        HashSet<String> ret = new HashSet<String>();
        //        ret.UnionWith(s1);
        //        ret.UnionWith(s2);
        //        ret.Add(synonym[0]);
        //        ret.Add(synonym[1]);

        //        foreach (String sub in ret)
        //        {
        //            map[sub] = ret;
        //        }
        //    }

        //    String[] col = text.Split(" ");
        //    List<String> result = new List<String>();
        //    dfs(map, col, result, 0);

        //    var resultOrdered = result.OrderBy(p=>p);
        //    return resultOrdered.ToList<string>();
        //}
    }
}
