using System;
using System.Collections.Generic;
using System.Text;

namespace CCIChallenges.RecursiveAndDynamicProgramming
{
    public static class GetAllSubsets
    {
        public static List<List<int>> getSubsets(List<int> set, int index)
        {
            List<List<int>> allsubsets;
            if (set.Count == index)
            { // Base case - add empty set
                allsubsets = new List<List<int>>();
                allsubsets.Add(new List<int>());
            }
            else
            {
                allsubsets = getSubsets(set, index + 1);
                int item = set[index];
                List<List<int>> moresubsets = new List<List<int>>();
                foreach (var subset in allsubsets)
                {
                    List<int> newsubset = new List<int>();
                    newsubset.AddRange(subset);
                    newsubset.Add(item);
                    moresubsets.Add(newsubset);
                }
                allsubsets.AddRange(moresubsets);
            }
            return allsubsets;
        }

        public static void Main()
        {
            List<int> list = new List<int>();
            for (int i = 1; i <= 3; i++)
            {
                list.Add(i);
            }
            var subsets = getSubsets(list, 0);           
        }

    }
}
