using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestConsole
{
    //The height of a binary tree is the number of edges between the tree's root and its furthest leaf.
    public class HeightBinaryTree
    {
        public class Node
        {
            public int data;
            public Node left, right;

            public Node(int item)
            {
                data = item;
            }
        }
        static int biggestHeightValue;
        //Improviment in sintax
        public static int height(Node root, int currentCounter)
        {
            if (root == null)
            {
                return -1;
            }
            height(root.left, currentCounter + 1);
            height(root.right, currentCounter + 1);
            biggestHeightValue = Math.Max(biggestHeightValue, currentCounter);
            return biggestHeightValue;
        }
        
        //First version
        public static int MaxDepth(Node node)
        {
            if (node == null)
            {
                return 0;
            }
            int totalCountLeft = 1 + MaxDepth(node.left);
            int totalCountRight = 1 + MaxDepth(node.right);

            var finalResult = Math.Max(totalCountLeft, totalCountRight);
            return finalResult;
        }

        public static int GetLevel(Node node)
        {
            var levels = MaxDepth(node);
            var height = levels - 1;
            return height;
        }
    }
}
