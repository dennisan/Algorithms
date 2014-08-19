using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BinaryTree
{
	public class BinaryTree
	{
		private class TreeNode {
			public int Value;
			public TreeNode Left;
			public TreeNode Right;

			public TreeNode (int value)
			{
				Value = value;
			}
		}

		private TreeNode _Root;

		public BinaryTree()
		{
			_Root = null;
		}
		public void Insert(int value)
		{
			TreeNode newNode = new TreeNode(value);

			if (_Root == null)
				_Root = newNode;
			else
				Insert(_Root, newNode);
		}
		public bool Delete(int value)
		{
			return false;
		}
		public bool SearchBFS(int value)
		{
			Queue<TreeNode> queue = new Queue<TreeNode>();
			return SearchBFS(_Root, value, queue);
		}
		public bool SearchDFS(int value)
		{
			return SearchDFS(_Root, value);
		}
		public void Display()
		{
			Display(_Root, 0);
		}


		private TreeNode Insert(TreeNode thisNode, TreeNode newNode)
		{
			if (newNode.Value < thisNode.Value)
				if (thisNode.Left == null)
					thisNode.Left = newNode;
				else
					Insert(thisNode.Left, newNode);
			else
				if (thisNode.Right == null)
					thisNode.Right = newNode;
				else
					Insert(thisNode.Right, newNode);

			return newNode;

		}
		private bool SearchBFS(TreeNode thisNode, int value, Queue<TreeNode> queue)
		{
			queue.Enqueue(thisNode);

			while (queue.Count > 0)
			{
				TreeNode node = queue.Dequeue();

				Console.Write(".");
				if (node.Value == value)
					return true;
				else
				{
					if (node.Left != null) queue.Enqueue(node.Left);
					if (node.Right != null) queue.Enqueue(node.Right);
				}
			}

			return false;		
		}
		private bool SearchDFS(TreeNode thisNode, int value)
		{
			Console.Write(".");
			if (thisNode.Value == value)
				return true;
			else
			{
				if (value < thisNode.Value) 
				{
					if (thisNode.Left != null)
						return SearchDFS(thisNode.Left, value);
				}
				else
				{
					if (thisNode.Right != null) 
						return SearchDFS(thisNode.Right, value);
				}
			}

			return false;
		}
		private void Display(TreeNode node, int level)
		{
			// in order tree traversal
			if (node.Left != null)
				Display(node.Left, level+1);
				
			for (int i=0; i < level; i++)
				Console.Write(". . .");
			Console.WriteLine(node.Value);

			if (node.Right != null )
				Display(node.Right, level+1);

		}
	}
}
