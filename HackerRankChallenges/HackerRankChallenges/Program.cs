using CCI.ArrayAndStrings;
using CCIChallenges.ArrayAndStrings;
using CCIChallenges.LinkedList;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;

namespace HackerRankChallenges
{
    public class Program
    {
        static void Main(string[] args)
        {
            LinkedListNode<int> a = new LinkedListNode<int>(1);
            LinkedListNode<int> b = new LinkedListNode<int>(2);
            LinkedListNode<int> c = new LinkedListNode<int>(3);

            LinkedList<int> ll = new LinkedList<int>();
            ll.AddLast(a);
            ll.AddLast(b);
            ll.AddLast(c);

            KthToLastLinkedList.PrintKthToLast(ll.First, 2);
        }
    }
}
