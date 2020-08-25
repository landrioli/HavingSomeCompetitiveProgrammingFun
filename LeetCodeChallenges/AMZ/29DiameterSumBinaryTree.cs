using System;
using System.Collections.Generic;
using System.Text;

namespace LeetCodeChallenges.AMZ
{
    //https://leetcode.com/problems/diameter-of-binary-tree
    //Given a binary tree, you need to compute the length of the diameter of the tree. 
    //The diameter of a binary tree is the length of the longest path between any two nodes in a tree. 
    //This path may or may not pass through the root.
    public class _29DiameterSumBinaryTree
    {
        private int maxValue = 0;

        public int DiameterOfBinaryTree(TreeNode root)
        {
            DiameterOfBinaryTreeRecursive(root);

            return maxValue;
        }

        public int DiameterOfBinaryTreeRecursive(TreeNode root)
        {
            if (root == null)
                return 0;

            int leftCount = DiameterOfBinaryTreeRecursive(root.left);
            int rightCount = DiameterOfBinaryTreeRecursive(root.right);

            maxValue = Math.Max(maxValue, leftCount + rightCount);

            return Math.Max(leftCount, rightCount) + 1;
        }
    }
}
