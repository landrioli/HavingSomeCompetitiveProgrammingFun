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

    public class TreeNodeWithParent
    {
        public TreeNodeWithParent(int data)
        {
            this.Data = data;
        }
        public TreeNodeWithParent ParentNode { get; set; }
        public TreeNodeWithParent LeftNode { get; set; }
        public TreeNodeWithParent RightNode { get; set; }
        public int Data { get; set; }
    }
}
