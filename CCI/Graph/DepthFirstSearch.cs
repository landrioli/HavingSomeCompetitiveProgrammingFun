using System;
using System.Collections.Generic;
using System.Text;

namespace CCIChallenges.BinaryTree
{
    public static class DepthFirstSearch
    {
        public static void DfsSearch(Node root) {
            if (root == null)
                return;

            Console.WriteLine(root.Value);
            root.Visited = true;
            foreach (var node in root.Adjacents)
            {
                if (!node.Visited)
                {
                    DfsSearch(node);
                }
            }            
        }

        public class Node
        {
            public Node()
            {
                Adjacents = new List<Node>();
                Visited = false;
            }

            public int Value { get; set; }
            public bool Visited { get; set; }
            public IList<Node> Adjacents { get; set; }
        }
    }
}
