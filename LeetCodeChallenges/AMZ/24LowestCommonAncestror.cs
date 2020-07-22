using System;
using System.Collections.Generic;
using System.Text;

namespace LeetCodeChallenges.AMZ
{
    public class LowestCommonAncestror
    {
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

        //O(N) and O(N)
        public TreeNode LowestCommonAncestorInABinaryTree(TreeNode root, TreeNode p, TreeNode q)
        {
            // Value of current node or parent node.
            int parentVal = root.val;
            int pVal = p.val;
            int qVal = q.val;

            if (pVal > parentVal && qVal > parentVal)
            {
                // If both p and q are greater than parent
                return LowestCommonAncestorInABinaryTree(root.right, p, q);
            }
            else if (pVal < parentVal && qVal < parentVal)
            {
                // If both p and q are lesser than parent
                return LowestCommonAncestorInABinaryTree(root.left, p, q);
            }
            else
            {
                // We have found the split point, because if one is lees and other bigger we use the 
                //binary tree property to shows that the current is the ancestor
                return root;
            }
        }

        public class TreeNode
        {
            public int val;
            public TreeNode left;
            public TreeNode right;
            public TreeNode(int x) { val = x; }
        }
    }
}
