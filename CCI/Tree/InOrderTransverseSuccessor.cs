using CCIChallenges.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace CCIChallenges.BinaryTree
{
    /*Successor: Write an algorithm to find the "next" node (i.e., in-order successor) of a given node in a
    binary search tree.You may assume that each node has a link to its parent.
    Recall that an in-order traversal traverses the left subtree, then the current node, then the right subtree.
    */
    public static class InOrderTransverseSuccessor
    {
        public static TreeNodeWithParent GetInOrderSuccessor(TreeNodeWithParent node) {
            if (node == null)
                return node;

            if (node.RightNode != null)
            {
                return GetLeftMostChild(node.LeftNode);
            }
            else
            {
                TreeNodeWithParent q = node;
                TreeNodeWithParent x = q.ParentNode;
                //Go up until we're on left instead of right
                // We know that we change from left to root when the left is the same as q.
                while (x != null && x.LeftNode!=q)
                {
                    q = x;
                    x = x.ParentNode; 
                }
                return x;
            }
        }

        private static TreeNodeWithParent GetLeftMostChild(TreeNodeWithParent node)
        {
            if (node == null)
            {
                return null;
            }
            while (node.LeftNode != null)
            {
                node = node.LeftNode;
            }
            return node;
        }
    }
}
