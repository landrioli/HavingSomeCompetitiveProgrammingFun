using System;
using System.Collections.Generic;
using System.Text;

namespace CCIChallenges.BinaryTree
{
    public class TreeNode
    {
        public TreeNode(int data)
        {
            this.Data = data;
        }
        public TreeNode LeftNode { get; set; }
        public TreeNode RightNode { get; set; }
        public int Data { get; set; }
    }
}
