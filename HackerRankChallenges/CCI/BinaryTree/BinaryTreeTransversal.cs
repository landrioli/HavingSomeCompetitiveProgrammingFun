using System;
using System.Collections.Generic;
using System.Text;

namespace CCIChallenges.BinaryTree
{
    /*
     * Traversal is a process to visit all the nodes of a tree. In this example, I implemented three method which we use to traverse a tree.
        PreOrder Traversal:
            Visit the root
            Traverse the left subtree
            Traverse the right subtree
        InOrder Traversal:
            Traverse the left subtree
            Visit the root
            Traverse the right subtree
        PostOrder Traversal:
            Traverse the left subtree
            Traverse the right subtree
            Visit the root
     */
    public static class BinaryTreeTransversal
    {
        public static void TraversePreOrder(TreeNode parent)
        {
            if (parent != null)
            {
                Console.Write(parent.Data + " ");
                TraversePreOrder(parent.LeftNode);
                TraversePreOrder(parent.RightNode);
            }            
        }

        public static void TraverseInOrder(TreeNode parent)
        {
            if (parent != null)
            {
                TraverseInOrder(parent.LeftNode);
                Console.Write(parent.Data + " ");
                TraverseInOrder(parent.RightNode);
            }
        }

        public static void TraversePostOrder(TreeNode parent)
        {
            if (parent != null)
            {
                TraversePostOrder(parent.LeftNode);
                TraversePostOrder(parent.RightNode);
                Console.Write(parent.Data + " ");
            }
        }
    }
}
