using System;
using System.Collections.Generic;
using System.Text;

namespace CCIChallenges.BinaryTree
{
    public static class BinarySearchTreeMinimalInsert
    {
        public static TreeNode CreateMinimalBST(int[] array) {
            return CreateMinimalBST(array, 0, array.Length - 1);
        }

        private static TreeNode CreateMinimalBST(int[] array, int start, int end)
        {
            if (end < start)
            {
                return null; 
            }
            var middle = (start + end) / 2;
            var root = new TreeNode(array[middle]);
            root.LeftNode = CreateMinimalBST(array, start, middle - 1);
            root.RightNode = CreateMinimalBST(array, middle + 1, end);
            return root;
        }
    }
}
