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
			// Initialize an array of size ElemCnt;
			const int ElemCnt = 1000;
			const int ElemMax = 5000;

			BinaryTree Tree = GetRandomTree(ElemCnt, ElemMax);
			Console.WriteLine(String.Format("Tree Loaded with {0:f0} elements\n", ElemCnt));
			Tree.Display();

			while (true)
			{
				Console.Write("\nEnter a value to search for... ");
				var s = Console.ReadLine();
				if (string.IsNullOrWhiteSpace(s))
					break;

				if (Tree.SearchDFS(int.Parse(s)) == true)
					Console.WriteLine("\nThe value {0} was found in the tree.\n", s);
				else
					Console.WriteLine("\nThe value {0} was not found in the tree.\n", s);

				//Tree.Display();
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
