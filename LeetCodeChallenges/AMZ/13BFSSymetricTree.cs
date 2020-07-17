using System;
using System.Collections.Generic;
using System.Text;

namespace LeetCodeChallenges.AMZ
{
    //https://leetcode.com/problems/symmetric-tree/
    /*Given a binary tree, check whether it is a mirror of itself (ie, symmetric around its center).
        For example, this binary tree [1,2,2,3,4,4,3] is symmetric:
            1
           / \
          2   2
         / \ / \
        3  4 4  3
     */
    public class BFSSymetricTree
    {
        //Each two consecutive nodes in the queue should be equal, and their subtrees a mirror of each other. Initially, the queue contains root and root. 
        //Then the algorithm works similarly to BFS, with some key differences. 
        //Each time, two nodes are extracted and their values compared. Then, the right and left children of the two nodes are inserted in the queue in opposite order. 
        //The algorithm is done when either the queue is empty, or we detect that the tree is not symmetric (i.e. we pull out two consecutive nodes from the queue that are unequal).
        //Time O(N)
        // Space O(N)
        public bool IsSymmetricBfs(TreeNode root)
        {
            var q = new Queue<TreeNode>();
            q.Enqueue(root);
            q.Enqueue(root);
            while(q.Count != 0) {
                TreeNode t1 = q.Dequeue();
                TreeNode t2 = q.Dequeue();
                if (t1 == null && t2 == null) continue;
                if (t1 == null || t2 == null) return false;
                if (t1.val != t2.val) return false;
                q.Enqueue(t1.left);
                q.Enqueue(t2.right);
                q.Enqueue(t1.right);
                q.Enqueue(t2.left);
            }
            return true;
        }

        /*
         A tree is symmetric if the left subtree is a mirror reflection of the right subtree.
         Therefore, the question is: when are two trees a mirror reflection of each other?
         Two trees are a mirror reflection of each other if:
            Their two roots have the same value.
            The right subtree of each tree is a mirror reflection of the left subtree of the other tree.*/
        public bool IsSymmetricRecursive(TreeNode root)
        {
            return isMirror(root, root);
        }

        public bool isMirror(TreeNode t1, TreeNode t2)
        {
            if (t1 == null && t2 == null) return true;
            if (t1 == null || t2 == null) return false;
            return (t1.val == t2.val)
                && isMirror(t1.right, t2.left)
                && isMirror(t1.left, t2.right);
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
