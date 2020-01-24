using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Test
{
	//https://leetcode.com/problems/n-ary-tree-postorder-traversal
	//Nary-Tree input serialization is represented in their level order traversal, each group of children is separated by the null value (See examples).
    public class NAryTreePostorderTraversal
    {		
		
	public class Node
	{
		public int val;
		public IList<Node> children;

		public Node() { }

		public Node(int _val)
		{
			val = _val;
		}

		public Node(int _val, IList<Node> _children)
		{
			val = _val;
			children = _children;
		}
	}

	public IList<int> PostorderRecursive(Node root, IList<int> finalResult)
	{
		if (root == null)
			return new List<int>();

		if (root.children != null)
		{
			foreach (var children in root.children)
			{
				PostorderRecursive(children, finalResult);
			}
		}

		finalResult.Add(root.val);
		return finalResult;
	}

	//Iterative Approach
	public IList<int> PostorderIterative(Node root)
	{
		var stack = new Stack<Node>();
		var finalResult = new List<int>();
		if (root == null)
			return finalResult;

		stack.Push(root);

		while (stack.Count > 0)
		{
			var node = stack.Pop();
			finalResult.Add(node.val);
			if (node.children != null)
			{
				foreach (var children in node.children)
				{
					stack.Push(children);
				}
			}
		}
		finalResult.Reverse();
		return finalResult;
	}
    }
}
