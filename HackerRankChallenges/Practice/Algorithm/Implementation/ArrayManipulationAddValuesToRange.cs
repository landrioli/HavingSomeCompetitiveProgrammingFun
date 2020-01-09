using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestConsole
{
    /*
     https://www.hackerrank.com/challenges/crush/problem?h_r=next-challenge&h_v=zen
         */
    public static class ArrayManipulationAddValuesToRange
    {
        //Brute force solution - Time not accepted
        static long ArrayManipulation(int n, int[][] queries)
        {
            int biggest = 0;
            var queriesList = BuildQueries(queries);
            var board = new int[n + 1];
            foreach (var query in queriesList)
            {
                for (int i = query.StartPosition; i <= query.EndPosition; i++)
                {
                    var value = board[i];
                    value += query.ValueToAdd;
                    board[i] = value;
                    biggest = Math.Max(biggest, value);
                }
            }

            return biggest;
        }

        private static List<Query> BuildQueries(int[][] queries)
        {
            List<Query> queriesList = new List<Query>();
            int mRows = queries.GetLength(0);
            for (int i = 0; i < mRows; i++)
            {
                queriesList.Add(new Query(queries[i][0], queries[i][1], queries[i][2]));
            }
            return queriesList;
        }

        public class Query
        {
            public Query(int start, int end, int valueToAdd)
            {
                StartPosition = start;
                EndPosition = end;
                ValueToAdd = valueToAdd;
            }
            public int StartPosition { get; set; }
            public int EndPosition { get; set; }
            public int ValueToAdd { get; set; }
        }


        //Explanation of optimized solution
        static long ArrayManipulationOptimized(int n, int[][] queries)
        {
            var arr = new int[n + 1];
            int mRows = queries.GetLength(0);
            // Utility method to add value val, 
            // to range [lo, hi] 
            for (int m = 0; m < mRows; m++)
            {
                var low = queries[m][0];
                var high = queries[m][1];
                var val = queries[m][2];
                arr[low] += val;
                if (high + 1 <= n)
                    arr[high + 1] -= val;
            }
            // convert array into 
            // prefix sum array
            long tempMax = 0;
            long max = 0;
            for (int i = 1; i <= n; i++)
            {
                tempMax += arr[i];
                if (tempMax > max) max = tempMax;
            }

            return max;
        }
    }
}
