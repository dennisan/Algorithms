using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BinaryTree
{
	class Program
	{
		static void Main(string[] args)
		{
			LoadRandoms();
		}


		private static void LoadRandoms()
		{
			BinaryTree Tree = GetRandomTree(500, 999);
			
			Tree.Display();

			while (true)
			{
				Console.Write("\nEnter a value to search for... ");
				var s = Console.ReadLine();
				if (string.IsNullOrWhiteSpace(s))
					break;

				if (s == "c" || s == "C")
				{ 
					BinaryTree.TreeNode Node = Tree.ConvertToOrderedList();

					if (Node != null)
					{
						Console.Write("\nTraversing List in ascending order\n");

						Console.Write(Node.Value);

						while (Node.Right != null)
						{
							Node = Node.Right;
							Console.Write(", ");
							Console.Write(Node.Value);
						}

						Console.Write("\n\nTraversing List in descending order\n");

						Console.Write(Node.Value);

						while (Node.Left != null)
						{
							Node = Node.Left;
							Console.Write(", ");
							Console.Write(Node.Value);
						}

						Console.Write("\n\n");
					}
				}
				else
				{
					if (Tree.DepthFirstSearch(int.Parse(s)) == true)
						Console.WriteLine("\nThe value {0} was found in the tree.\n", s);
					else
						Console.WriteLine("\nThe value {0} was not found in the tree.\n", s);
				}
			}
		}

		private static BinaryTree GetRandomTree(int count, int max)
		{
			BinaryTree Tree = new BinaryTree();

			// Initialize the items to random numbers
			Console.WriteLine(String.Format("Initializing list with {0:n0} random values", count));
			Random RGen = new Random(DateTime.Now.Millisecond);
			for (int i = 0; i < count; i++)
				Tree.Insert(RGen.Next(max));

			return Tree;
		}
	}
}
