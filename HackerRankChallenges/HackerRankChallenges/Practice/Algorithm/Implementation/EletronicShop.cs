using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestConsole
{
    //https://www.hackerrank.com/challenges/electronics-shop/problem
    public class EletronicShop
    {
        static int getMoneySpent(int[] keyboards, int[] drives, int b)
        {
            int biggest = -1;
            for (int i = 0; i < keyboards.Length; i++)
            {
                for (int j = 0; j < drives.Length; j++)
                {
                    int total = keyboards[i] + drives[j];
                    if (total <= b && total > biggest)
                    {
                        biggest = total;
                    }
                }
            }

            return biggest;
        }

        public static int getMoneySpentTwo(int[] keyboards, int[] drives, int b)
        {
            keyboards = keyboards.OrderByDescending(p => p).ToArray();
            drives = drives.OrderBy(p => p).ToArray();


            int max = -1;
            for (int i = 0, j = 0; i < keyboards.Length; i++)
            {
                for (; j < drives.Length; j++)
                {
                    if (keyboards[i] + drives[j] > b) break; //This prevents j from incrementing
                    if (keyboards[i] + drives[j] > max)
                        max = keyboards[i] + drives[j];
                }
            }

            return max;
        }
    }
}
