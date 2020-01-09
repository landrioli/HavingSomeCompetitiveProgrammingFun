using CCIChallenges.BinaryTree;
using CCIChallenges.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace CCIChallenges.Tree
{
    //Check Subtree: Tl and T2 are two very large binary trees, with Tl much bigger than T2. Create an algorithm to determine if T2 is a subtree of Tl.
    public static class IsSubTree
    {
        #region Solution Simpler
        //Time O(N + M)  and Space O(N + M)
        /*There's a simple fix though. We can store NULL nodes in the pre-order traversal string as a special character,
            like an 'X: (We'll assume that the binary trees contain only integers.) The left tree would have the traversal
            {3, 4, X} and the right tree will have the traversal {3, X, 4}
            Observe that, as long as we represent the NULL nodes, the pre-order traversal of a tree is unique. That is, if
            two trees have the same pre-order traversal, then we know they are identical trees in values and structure.
         */
        public static bool containsTree(TreeNode t1, TreeNode t2)
        {
            StringBuilder string1 = new StringBuilder();
            StringBuilder string2 = new StringBuilder();

            getOrderString(t1, string1);
            getOrderString(t2, string2);

            return string1.ToString().IndexOf(string2.ToString()) != -1;
        }

        public static void getOrderString(TreeNode node, StringBuilder sb)
        {
            if (node == null)
            {
                sb.Append("X");             // Add null indicator
                return;
            }
            sb.Append(node.Data);           // Add root 
            getOrderString(node.LeftNode, sb);  // Add left
            getOrderString(node.RightNode, sb); // Add right
        }
        #endregion

        #region Solution Two
        //Time O(N + M) and space O(log (n) + log (m) )
        /*
         * An alternative approach is to search through the larger tree, T1. Each time a node in T1 matches the rootof T 2, call matchTree. 
         * The matchTree method will compare the two subtrees to see ifthey are identical.
         */
        public static bool containsTreeAlternative(TreeNode t1, TreeNode t2)
        {
            if (t2 == null)
            {
                return true; // The empty tree is a subtree of every tree.
            }
            return subTree(t1, t2);
        }

        /* Checks if the binary tree rooted at r1 contains the binary tree 
         * rooted at r2 as a subtree somewhere within it.
         */
        public static bool subTree(TreeNode r1, TreeNode r2)
        {
            if (r1 == null)
            {
                return false; // big tree empty & subtree still not found.
            }
            else if (r1.Data == r2.Data && matchTree(r1, r2))
            {
                return true;
            }
            return subTree(r1.LeftNode, r2) || subTree(r1.RightNode, r2);
        }

        /* Checks if the binary tree rooted at r1 contains the 
         * binary tree rooted at r2 as a subtree starting at r1.
         */
        public static bool matchTree(TreeNode r1, TreeNode r2)
        {
            if (r1 == null && r2 == null)
            {
                return true; // nothing left in the subtree
            }
            else if (r1 == null || r2 == null)
            {
                return false; // exactly one tree is empty, therefore trees don't match
            }
            else if (r1.Data != r2.Data)
            {
                return false;  // data doesn't match
            }
            else
            {
                return matchTree(r1.LeftNode, r2.LeftNode) && matchTree(r1.RightNode, r2.RightNode);
            }
        }
        #endregion

        public static void Main()
        {
            
        }
    }
}
