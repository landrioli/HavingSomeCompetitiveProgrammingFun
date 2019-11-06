using System;
using System.Collections.Generic;
using System.Text;

namespace CCIChallenges.Common
{
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
