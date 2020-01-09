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
            this.Size = 1;
        }
        public TreeNode LeftNode { get; set; }
        public TreeNode RightNode { get; set; }
        public int Data { get; set; }
        public int Size { get; set; }

        public void insertInOrder(int d)
        {
            if (d <= Data)
            {
                if (LeftNode == null)
                {
                    LeftNode = new TreeNode(d);
                }
                else
                {
                    LeftNode.insertInOrder(d);
                }
            }
            else
            {
                if (RightNode == null)
                {
                    RightNode = new TreeNode(d);
                }
                else
                {
                    RightNode.insertInOrder(d);
                }
            }
            Size++;
        }
        
        public TreeNode find(int d)
        {
            if (d == Data)
            {
                return this;
            }
            else if (d <= Data)
            {
                return LeftNode != null ? LeftNode.find(d) : null;
            }
            else if (d > Data)
            {
                return RightNode != null ? RightNode.find(d) : null;
            }
            return null;
        }

        //In a balanced tree, this method will be a (log N), where N is the number of nodes.
        public TreeNode getRandomNode()
        {
            int LeftNodeSize = LeftNode == null ? 0 : LeftNode.Size;
            Random random = new Random();
            int index = random.Next(Size);
            if (index < LeftNodeSize)
            {
                return LeftNode.getRandomNode();
            }
            else if (index == LeftNodeSize)
            {
                return this;
            }
            else
            {
                return RightNode.getRandomNode();
            }
        }

        /*Another way to think about what we're doing is that the initial random number call indicates which node
            (i) to return, and then we're locating the ith node in an in-order traversal. Subtracting LEFT_SIZE +1
            from i reflects that, when we go right, we skip over LEFT_SIZE + 1 nodes in the in-order traversal.*/
        public TreeNode getIthNode(int i)
        {
            int leftNodeSize = LeftNode == null ? 0 : LeftNode.Size;
            if (i < leftNodeSize)
            {
                return LeftNode.getIthNode(i);
            }
            else if (i == leftNodeSize)
            {
                return this;
            }
            else
            {
                //Skipping over leftSize + 1 nodes, so subtract them
                return RightNode.getIthNode(i - (leftNodeSize + 1));
            }
        }
    }
}
