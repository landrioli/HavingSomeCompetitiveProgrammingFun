using System;
using System.Collections.Generic;
using System.Text;

namespace LeetCodeChallenges.AMZ
{
    public class RightSibblingTree
    {
        public Node Connect(Node root)
        {
            if (root == null)
                return root;

            var queue = new Queue<Node>();
            queue.Enqueue(root);

            while (queue.Count > 0)
            {
                var cur = queue.Dequeue();
                if (cur.left != null && cur.right != null)
                {
                    cur.left.next = cur.right;
                    if (cur.next != null && cur.next.left != null)
                        cur.right.next = cur.next.left;

                    queue.Enqueue(cur.left);
                    queue.Enqueue(cur.right);
                }
            }

            return root;
        }
    }
    public class Node
    {
        public int val;
        public Node left;
        public Node right;
        public Node next;

        public Node() { }

        public Node(int _val)
        {
            val = _val;
        }

        public Node(int _val, Node _left, Node _right, Node _next)
        {
            val = _val;
            left = _left;
            right = _right;
            next = _next;
        }
    }

}
