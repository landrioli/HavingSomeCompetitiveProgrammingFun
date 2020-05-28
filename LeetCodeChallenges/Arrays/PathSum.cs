using System;
using System.Collections.Generic;
using System.Text;

namespace LeetCodeChallenges.Arrays
{
    //https://leetcode.com/problems/path-sum/
    //Given a binary tree and a sum, determine if the tree has a root-to-leaf path such that adding up all the values along the path equals the given sum.
    public class PathSum
    {
        private bool isValid = false;
        public bool HasPathSum(TreeNode root, int sum)
        {
            if (root == null)
                return false;

            HasPathSumRecursive(root, sum, 0);
            return isValid;
        }

        public void HasPathSumRecursive(TreeNode root, int expectedSum, int currentSum)
        {
            currentSum += root.val;
            if (root.left == null && root.right == null)
            {
                Console.WriteLine(currentSum);
                if (currentSum == expectedSum)
                {
                    isValid = true;
                }
            }
            if (root.left != null)
                HasPathSumRecursive(root.left, expectedSum, currentSum);

            if (root.right != null)
                HasPathSumRecursive(root.right, expectedSum, currentSum);
        }
    }

    public class TreeNode
    {
        public int val;
        public TreeNode left;
        public TreeNode right;
        public TreeNode(int val = 0, TreeNode left = null, TreeNode right = null)
        {
            this.val = val;
            this.left = left;
            this.right = right;
        }
    }
}