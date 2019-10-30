using System;
using System.Collections.Generic;
using System.Text;

namespace CCIChallenges.BinaryTree
{
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
