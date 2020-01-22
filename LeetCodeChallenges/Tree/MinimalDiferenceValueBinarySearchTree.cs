using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Test
{
	//https://leetcode.com/problems/minimum-absolute-difference-in-bst
	//Given a binary search tree with non-negative values, find the minimum absolute difference between values of any two nodes.
    public class MinimalDiferenceValueBinarySearchTree
    {		public class TreeNode
        {
            public int val;
            public TreeNode left;
            public TreeNode right;
            public TreeNode(int x) { val = x; }
        }

        private int counter = int.MaxValue;
        private TreeNode prev = null;
        public int GetMinimumDifference(TreeNode root)
        {
            if (root == null)
                return counter;
          
            GetMinimumDifference(root.left);

            if(prev != null)
                counter = Math.Min(Math.Abs(prev.val - root.val), counter);

            prev = root;

            GetMinimumDifference(root.right);
            return counter;
        }
    }
}
