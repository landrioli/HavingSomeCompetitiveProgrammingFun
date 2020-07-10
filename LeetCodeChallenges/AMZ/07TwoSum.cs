using System;
using System.Collections.Generic;
using System.Text;

namespace LeetCodeChallenges.AMZ
{
    public class SevenTwoSumsVariations
    {
        /*
         https://leetcode.com/problems/two-sum/submissions/
         Given an array of integers, return indices of the two numbers such that they add up to a specific target.
         You may assume that each input would have exactly one solution, and you may not use the same element twice.
         O(N)  O(N)
             */
        public class TwoSums {
            // x + y = target
            // x = target - y
            public int[] TwoSum(int[] nums, int target)
            {
                var dict = new Dictionary<int, int>();
                for (int i = 0; i < nums.Length; i++)
                {
                    var x = target - nums[i];
                    if (dict.ContainsKey(x))
                    {
                        return new int[] { dict[x], i };
                    }
                    if (!dict.ContainsKey(nums[i]))
                        dict.Add(nums[i], i);
                }
                return null;
            }
        }

        /*
         653. Two Sum IV - Input is a BST
         https://leetcode.com/problems/two-sum-iv-input-is-a-bst/
         Given a Binary Search Tree and a target number, return true if there exist two elements in the BST such that their sum is equal to the given target.
         */
        public class TwoSumsBST
        {
            private bool _exists = false;
            public bool FindTarget(TreeNode root, int k)
            {
                var hash = new HashSet<int>();
                FindTargetRecursive(root, k, hash);

                return _exists;
            }

            public void FindTargetRecursive(TreeNode root, int target, HashSet<int> hash)
            {
                if (root != null)
                {
                    var current = root.val;
                    var x = target - current;
                    if (hash.Contains(x))
                    {
                        _exists = true;
                    }
                    if (!hash.Contains(current))
                        hash.Add(current);

                    FindTargetRecursive(root.left, target, hash);
                    FindTargetRecursive(root.right, target, hash);
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

    }
}
