using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LeetCodeChallenges._30DaysChallengeCovid
{
    public class DaySixGroupAnagrams
    {
        //Given an array of strings, group anagrams together.
        //Example:
        //Input: ["eat", "tea", "tan", "ate", "nat", "bat"],
        //Output:
        //[
        //  ["ate","eat","tea"],
        //  ["nat","tan"],
        //  ["bat"]
        //]
        public IList<IList<string>> GroupAnagrams(string[] strs)
        {
            var result = new List<IList<string>>();
            if (strs.Length == 0)
                return result;

            var dic = new Dictionary<string, List<string>>();
            foreach (var str in strs)
            {
                var strArray = str.ToCharArray();
                Array.Sort(strArray);
                var key = new string(strArray);
                if (!dic.ContainsKey(key))
                    dic.Add(key, new List<string>());
                dic[key].Add(str);
            }

            foreach (var item in dic)
            {
                result.Add(item.Value);
            }

            return result;
        }
    }
}
