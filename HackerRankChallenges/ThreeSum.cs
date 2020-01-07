﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestConsole
{
    class ThreeSum
    {
        /*The idea is to sort an input array and then run through all indices of a possible first element of a triplet. 
        * For each possible first element we make a standard bi-directional 2Sum sweep of the remaining part of the array. 
        * Also we want to skip equal elements to avoid duplicates in the answer without making a set or smth like that.
        O(n2)*/
        public IList<IList<int>> ThreeSumMethod(int[] num)
        {
            num = num.OrderBy(p => p).ToArray();
            var res = new List<IList<int>>();
            for (int i = 0; i < num.Length - 2; i++)
            {
                if (i == 0 || (i > 0 && num[i] != num[i - 1]))
                {
                    int lo = i + 1, hi = num.Length - 1, sum = 0 - num[i];
                    while (lo < hi)
                    {
                        if (num[lo] + num[hi] == sum)
                        {
                            res.Add(new List<int>() { num[i], num[lo], num[hi] });
                            while (lo < hi && num[lo] == num[lo + 1]) lo++;
                            while (lo < hi && num[hi] == num[hi - 1]) hi--;
                            lo++; hi--;
                        }
                        else if (num[lo] + num[hi] < sum) lo++;
                        else hi--;
                    }
                }
            }
            return res;
        }
    }
}
