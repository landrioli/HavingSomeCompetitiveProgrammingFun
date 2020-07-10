using System;
using System.Collections.Generic;

namespace LeetCodeChallenges
{
    public class LowestCommonAncestor
    {
        /* Iterative using parent pointers Approach
         * Start from the root node and traverse the tree.
        Until we find p and q both, keep storing the parent pointers in a dictionary.
        Once we have found both p and q, we get all the ancestors for p using the parent dictionary and add to a set called ancestors.
        Similarly, we traverse through ancestors for node q. If the ancestor is present in the ancestors set for p, this means this is the first ancestor common between p and q (while traversing upwards) and hence this is the LCA node.
         */
        public TreeNode LowestCommonAncestorIterativeUsingParentPointers(TreeNode root, TreeNode p, TreeNode q)
        {

            // Stack for tree traversal
            var stack = new Stack<TreeNode>();

            // HashMap for parent pointers
            var parent = new Dictionary<TreeNode, TreeNode>();

            parent[root] = null;
            stack.Push(root);

            // Iterate until we find both the nodes p and q
            while (!parent.ContainsKey(p) || !parent.ContainsKey(q))
            {

                TreeNode node = stack.Pop();

                // While traversing the tree, keep saving the parent pointers.
                if (node.left != null)
                {
                    parent[node.left] = node;
                    stack.Push(node.left);
                }
                if (node.right != null)
                {
                    parent[node.right]= node;
                    stack.Push(node.right);
                }
            }

            // Ancestors set() for node p.
            var ancestors = new HashSet<TreeNode>();

            // Process all ancestors for node p using parent pointers.
            while (p != null)
            {
                ancestors.Add(p);
                p = parent[p];
            }

            // The first ancestor of q which appears in
            // p's ancestor set() is their lowest common ancestor.
            while (!ancestors.Contains(q))
                q = parent[q];
            return q;
        }


        /* Recursive Approach
         * Start traversing the tree from the root node.
            If the current node itself is one of p or q, we would mark a variable mid as True and continue the search for the other node in the left and right branches.
            If either of the left or the right branch returns True, this means one of the two nodes was found below.
            If at any point in the traversal, any two of the three flags left, right or mid become True, this means we have found the lowest common ancestor for the nodes p and q.
         */
        private TreeNode ans;
        private bool recurseTree(TreeNode currentNode, TreeNode p, TreeNode q)
        {
            // If reached the end of a branch, return false.
            if (currentNode == null)
            {
                return false;
            }

            // Left Recursion. If left recursion returns true, set left = 1 else 0
            int left = this.recurseTree(currentNode.left, p, q) ? 1 : 0;

            // Right Recursion
            int right = this.recurseTree(currentNode.right, p, q) ? 1 : 0;

            // If the current node is one of p or q
            int mid = (currentNode == p || currentNode == q) ? 1 : 0;


            // If any two of the flags left, right or mid become True
            if (mid + left + right >= 2)
            {
                this.ans = currentNode;
            }

            // Return true if any one of the three bool values is True.
            return (mid + left + right > 0);
        }
        public TreeNode lowestCommonAncestoRecursive(TreeNode root, TreeNode p, TreeNode q)
        {
            // Traverse the tree
            this.recurseTree(root, p, q);
            return this.ans;
        }

        public class TreeNode
        {
            public int val;
            public TreeNode left;
            public TreeNode right;
            public TreeNode(int x) { val = x; }
        }

        public void Main() {
            var node1 = new TreeNode(1);
            var node2 = new TreeNode(2);
            var node3 = new TreeNode(3);
            var node4 = new TreeNode(4);
            var node5 = new TreeNode(5);
            var node6 = new TreeNode(6);
            var node7 = new TreeNode(7);
            var node8 = new TreeNode(8);

            node3.left = node5;
            node3.right = node6;
            node4.left = node7;
            node4.right = node8;
            node2.left = node3;
            node2.right = node3;
            node1.left = node2;

            lowestCommonAncestoRecursive(node1, node6, node7);
        }
    }
}