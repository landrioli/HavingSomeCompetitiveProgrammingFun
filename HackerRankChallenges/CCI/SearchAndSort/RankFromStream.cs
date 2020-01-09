using System;
using System.Collections.Generic;
using System.Text;

namespace CCIChallenges.SearchAndSort
{
    /*10.10 Rank from Stream: Imagine you are reading in a stream of integers. Periodically, you wish
        to be able to look up the rank of a number x (the number of values less than or equal to x).
        Implement the data structures and algorithms to support these operations. That is, implement
        the method track(int x), which is called when each number is generated, and the method
        getRankOfNumber(int x), which returns the number of values less than or equal to x (not
        including x itself).
        EXAMPLE
        Stream (in order of appearance): 5 J 1 J 4 J 4 J 5 J 9 J 7 J 13 J 3
        getRankOfNumber(l) e
        getRankOfNumber(3) 1
        getRankOfNumber(4) 3
     */
    //The track method and the getRankOfNumber method will both operate in O(log N) on a balanced tree and 0 (N) on an unbalanced tree.
    public class RankFromStream
    {
        private static RankNode root = null;

        public static void Track(int number)
        {
            if (root == null)
            {
                root = new RankNode(number);
            }
            else
            {
                root.Insert(number);
            }
        }

        public static int GetRankOfNumber(int number)
        {
            return root.GetRank(number);
        }

        public class RankNode
        {
            public int left_size = 0;
            public RankNode left;
            public RankNode right;
            public int data = 0;

            public RankNode(int d)
            {
                data = d;
            }

            public void Insert(int d)
            {
                if (d <= data)
                {
                    if (left != null)
                    {
                        left.Insert(d);
                    }
                    else
                    {
                        left = new RankNode(d);
                    }
                    left_size++;
                }
                else
                {
                    if (right != null)
                    {
                        right.Insert(d);
                    }
                    else
                    {
                        right = new RankNode(d);
                    }
                }
            }

            public int GetRank(int d)
            {
                if (d == data)
                {
                    return left_size;
                }
                else if (d < data)
                {
                    if (left == null)
                    {
                        return -1;
                    }
                    else
                    {
                        return left.GetRank(d);
                    }
                }
                else
                {
                    int right_rank = right?.GetRank(d) ?? -1;
                    if (right_rank == -1)
                    {
                        return -1;
                    }
                    else
                    {
                        return left_size + 1 + right_rank;
                    }
                }
            }
        }

        public static void Main()
        {
            int size = 8;
            int[] list = new int[size];
            for (int i = 0; i < size; i++)
            {
                list[i] = new Random().Next(1, 500);
            }
            for (int i = 0; i < list.Length; i++)
            {
                Track(list[i]);
            }

            int[] tracker = new int[size];
            for (int i = 0; i < list.Length; i++)
            {
                int v = list[i];
                int rank1 = root.GetRank(list[i]);
                tracker[rank1] = v;
            }

            for (int i = 0; i < tracker.Length - 1; i++)
            {
                if (tracker[i] != 0 && tracker[i + 1] != 0)
                {
                    if (tracker[i] > tracker[i + 1])
                    {
                        Console.WriteLine("ERROR at " + i);
                    }
                }
            }
        }
    }
}
