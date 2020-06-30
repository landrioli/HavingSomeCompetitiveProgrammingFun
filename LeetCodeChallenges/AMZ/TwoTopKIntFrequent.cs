using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LeetCodeChallenges.AMZ
{
    public class TwoTopKIntFrequent
    {
        //O(n) Solution
        public int[] TopKFrequent(int[] nums, int k)
        {
            Dictionary<int, int> countsMap = new Dictionary<int, int>();
            int maxCount = 0;
            foreach (int x in nums)
            {
                int currCount = countsMap.ContainsKey(x) ? countsMap[x] + 1 : 1;
                countsMap[x] = currCount;
                maxCount = currCount > maxCount ? currCount : maxCount;
            }

            // build array containing a list of elements with a given count
            IList<int>[] countsArr = new IList<int>[maxCount + 1];
            foreach (int x in countsMap.Keys)
            {
                int currCount = countsMap[x];
                if (countsArr[currCount] == null) countsArr[currCount] = new List<int>();
                countsArr[currCount].Add(x);
            }

            // work from largest and accumulate result
            IList<int> topK = new List<int>();
            for (int i = countsArr.Length - 1; i >= 0 && k > 0; i--)
            {
                if (countsArr[i] != null)
                {
                    foreach (int x in countsArr[i]) topK.Add(x);
                    k -= countsArr[i].Count;
                }
            }
            return topK.ToArray();
        }
    }
}
