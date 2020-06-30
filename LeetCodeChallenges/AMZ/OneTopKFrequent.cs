using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LeetCodeChallenges.AMZ
{
    //https://leetcode.com/problems/top-k-frequent-words
    public class OneTopKFrequent
    {
        //Time Complexity: O(N \log{N}), where N is the length of words. We count the frequency of each word in O(N) time, then we sort the given words in O(NlogN) time.
        //Space Complexity: O(N), the space used to store our candidates.
        public IList<string> TopKFrequent(string[] words, int k)
        {
            var dict = new Dictionary<string, int>();
            foreach (var word in words)
            {
                if (dict.ContainsKey(word))
                {
                    dict[word] = ++dict[word];
                }
                else
                {
                    dict.Add(word, 1);
                }
            }

            return dict.OrderByDescending(key => key.Value).ThenBy(key => key.Key).Take(k).Select(p=>p.Key).ToList();
        }
    }
}
