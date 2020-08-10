using System;
using System.Collections.Generic;
using System.Text;

namespace LeetCodeChallenges.AMZ
{
    public class DepthOfBinaryTree
    {
        private int MaximiumDepth = 0;

        //https://leetcode.com/problems/maximum-depth-of-binary-tree
        /*
         * Given a binary tree, find its maximum depth.
            The maximum depth is the number of nodes along the longest path from the root node down to the farthest leaf node.
         */
        public int MaxDepth(TreeNode root)
        {
            Dfs(root, 1);

            return MaximiumDepth;
        }

        private void Dfs(TreeNode root, int currentDepth)
        {
            if (root != null)
            {
                MaximiumDepth = Math.Max(MaximiumDepth, currentDepth);
                Dfs(root.left, currentDepth + 1);
                Dfs(root.right, currentDepth + 1);
            }
        }

        //https://leetcode.com/problems/maximum-depth-of-n-ary-tree
        private int MaximiumDeapth = 0;
        public int MaxDepthkTree(Node root)
        {
            if (root == null)
                return 0;

            Dfs(root, 1);
            return MaximiumDeapth;
        }

        private void Dfs(Node root, int currentDepth)
        {
            MaximiumDeapth = Math.Max(MaximiumDeapth, currentDepth);
            if (root != null)
            {
                foreach (var node in root.children)
                {
                    Dfs(node, currentDepth + 1);
                }
            }
        }

        public class Node
        {
            public int val;
            public IList<Node> children;

            public Node() { }

            public Node(int _val)
            {
                val = _val;
            }

            public Node(int _val, IList<Node> _children)
            {
                val = _val;
                children = _children;
            }
        }
    }
}
