using CCI.ArrayAndStrings;
using CCIChallenges.ArrayAndStrings;
using CCIChallenges.LinkedList;
using System;
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
            LinkedListNode<int> a = new LinkedListNode<int>(7);
            LinkedListNode<int> b = new LinkedListNode<int>(1);
            LinkedListNode<int> c = new LinkedListNode<int>(6);

            LinkedListNode<int> d = new LinkedListNode<int>(1);
            LinkedListNode<int> e = new LinkedListNode<int>(2);
            LinkedListNode<int> f = new LinkedListNode<int>(3);
            LinkedListNode<int> g = new LinkedListNode<int>(4);
            a.Next = b;
            b.Next = c;

            d.Next = e;
            e.Next = f;
            f.Next = g;

            PalindromeLinkedList.ReverseAndClone(d);
        }
    }
}
