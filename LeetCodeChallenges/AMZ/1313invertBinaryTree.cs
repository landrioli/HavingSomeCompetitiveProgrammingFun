using System;
using System.Collections.Generic;
using System.Text;

namespace LeetCodeChallenges.AMZ
{
    //https://leetcode.com/problems/invert-binary-tree/
    public class InvertBinaryTree
    {
        //O(N) and O(N)
        public TreeNode InvertTreeBfs(TreeNode root)
        {
            var queue = new Queue<TreeNode>();
            queue.Enqueue(root);

            while (queue.Count != 0)
            {
                var current = queue.Dequeue();
                if (current == null)
                    continue;
                SwapNodes(current);
                queue.Enqueue(current.left);
                queue.Enqueue(current.right);
            }
            return root;
        }

        private void SwapNodes(TreeNode node)
        {
            var temp = node.left;
            node.left = node.right;
            node.right = temp;
        }

        //Recursive
        //O(N) and O(d)
        public TreeNode InvertTreeRecursive(TreeNode root)
        {
            InvertTreeRecursiveFunc(root);
            return root;
        }

        public void InvertTreeRecursiveFunc(TreeNode root)
        {
            if (root == null)
                return;

            SwapNodes(root);
            InvertTreeRecursiveFunc(root.left);
            InvertTreeRecursiveFunc(root.right);
        }
    }
}
