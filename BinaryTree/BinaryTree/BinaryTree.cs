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
		////////////////////////////////////
		// public interface
		////////////////////////////////////

		public BinaryTree()
		{
		}

		public void Insert(IComparable value)
		{
			TreeNode newNode = new TreeNode(value);

			if (_Root == null)
				_Root = newNode;
			else
				Insert(_Root, newNode);
		}

		public bool Delete(IComparable value)
		{
			return false;
		}

		public bool BreathFirstSearch(IComparable value)
		{
			return SearchBFS(_Root, value);
		}

		public bool DepthFirstSearch(IComparable value)
		{
			return SearchDFS(_Root, value);
		}
		public TreeNode ConvertToOrderedList()
		{
			return ConvertToOrderedList(_Root);
		}

		public void Display()
		{
			Display(_Root, 0);
		}

		////////////////////////////////////
		// private members
		////////////////////////////////////

		public class TreeNode
		{
			public IComparable Value;
			public TreeNode Left;
			public TreeNode Right;

			public TreeNode(IComparable value)
			{
				Value = value;
			}
		}

		private TreeNode _Root = null;

		private TreeNode Insert(TreeNode thisNode, TreeNode newNode)
		{
			if (newNode.Value.CompareTo(thisNode.Value) < 0)
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

		private bool SearchBFS(TreeNode thisNode, IComparable value)
		{
			Queue<TreeNode> queue = new Queue<TreeNode>();

			queue.Enqueue(thisNode);

			while (queue.Count > 0)
			{
				TreeNode node = queue.Dequeue();

				Console.Write(".");
				if (node.Value.CompareTo(value) == 0)
					return true;
				else
				{
					if (node.Left != null) queue.Enqueue(node.Left);
					if (node.Right != null) queue.Enqueue(node.Right);
				}
			}

			return false;		
		}

		private bool SearchDFS(TreeNode thisNode, IComparable value)
		{
			Console.Write(".");
			if (thisNode.Value.CompareTo(value) == 0)
				return true;
			else
			{
				if (value.CompareTo(thisNode.Value) < 0) 
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


		private TreeNode ConvertToOrderedList(TreeNode thisNode)
		{
			// Converts the binary tree to a ordered linked list and returns the head of the list
			// Reuse the TreeNode Left and Right value for Prev and Next value in linked list

			TreeNode HeadNode;
			TreeNode LeftTailNode;
			TreeNode RghtHeadNode;

			if (thisNode.Left != null)
			{
				// the left list becomes the head
				HeadNode = ConvertToOrderedList(thisNode.Left);
				HeadNode.Left = null;

				// Find the tail of the left list
				LeftTailNode = HeadNode;
				while (LeftTailNode.Right != null)
					LeftTailNode = LeftTailNode.Right;

				// Add thisNode to the tail of the left list
				LeftTailNode.Right = thisNode;
				thisNode.Left = LeftTailNode;
			}
			else
				// thisNode becomes head if left is null
				HeadNode = thisNode;

			if (thisNode.Right != null)
			{
				// find the head of the right list
				RghtHeadNode = ConvertToOrderedList(thisNode.Right);

				// Add this node to the head of the right list
				thisNode.Right = RghtHeadNode;
				RghtHeadNode.Left = thisNode;
			}
			else
				// thisNode becomes tail if right list is null
				thisNode.Right = null;

			return HeadNode;
		}

		private void Display(TreeNode node, int level)
		{
			// in order tree traversal
			if (node.Left != null)
				Display(node.Left, level+1);
				
			for (int i=0; i < level; i++)
				Console.Write("+---");
			Console.WriteLine(node.Value);

			if (node.Right != null )
				Display(node.Right, level+1);

		}
	}
}
