using System;
using System.Collections.Generic;
using System.Text;

namespace CCIChallenges.BinaryTree
{
    public static class IsValidBinarySearchTree
    {
        public static bool checkBST(TreeNode n, int? min, int? max)
        {
            if (n == null)
            {
                return true;
            }
            if ((min != null && n.Data <= min) || (max != null && n.Data > max))
            {
                return false;
            }
            if (!checkBST(n.LeftNode, min, n.Data) || !checkBST(n.RightNode, n.Data, max))
            {
                return false;
            }
            return true;
        }
    }
}
