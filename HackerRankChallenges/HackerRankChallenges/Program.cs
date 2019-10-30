using CCI.ArrayAndStrings;
using CCIChallenges.ArrayAndStrings;
using CCIChallenges.BinaryTree;
using CCIChallenges.LinkedList;
using CCIChallenges.Stack;
using GeneralChallenges;
using HackerRankChallenges.Practice.InterviewPreparationKit.QueueAndStack;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using static CCIChallenges.BinaryTree.BreadthFirstSearch;

namespace HackerRankChallenges
{
    public class Program
    {
        static void Main(string[] args)
        {
            Node root1 = new Node() { Value = 1 };
            Node root2 = new Node() { Value = 2 };
            Node root3 = new Node() { Value = 3 };
            Node root4 = new Node() { Value = 4 };
            Node root5 = new Node() { Value = 5 };
            Node root6 = new Node() { Value = 6 };
            Node root7 = new Node() { Value = 7 };
            Node root8 = new Node() { Value = 8 };
            Node root9 = new Node() { Value = 9 };
            Node root10 = new Node() { Value = 10 };
            root1.Adjacents = new List<Node>() { root2, root3, root4 };
            root2.Adjacents = new List<Node>() { root5, root6 };
            root3.Adjacents = new List<Node>() { root7, root8 };
            root4.Adjacents = new List<Node>() { root9, root10 };

            //BreadthFirstSearch.BfsSearch(root1);
            Console.WriteLine("========================");
            DepthFirstSearch.DfsSearch(root1);

        }
    }
}
