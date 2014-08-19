using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinkedLists
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
			const int ElemCnt = 60;
			const int ElemMax = 1000;


			// Time Sort using watch1
			Stopwatch watch1 = new Stopwatch();

			watch1.Start();
			List LinkedList = GetRandomList(ElemCnt, ElemMax);
			watch1.Stop();
			Console.WriteLine(String.Format("List Loaded in {0:f3} sec\n", watch1.ElapsedMilliseconds / 1000.0));
			LinkedList.Dump();

			while (true)
			{
				Console.Write("\nEnter a value to delete from the list... ");
				var s = Console.ReadLine();
				if (string.IsNullOrWhiteSpace(s))
					break; 

				if (LinkedList.Delete(int.Parse(s)) == true)
					Console.WriteLine("The value {0} was deleted from the list.\n", s);
				else
					Console.WriteLine("The value {0} was not found in the list.\n", s);

				LinkedList.Dump();
			}

		}


		private static List GetRandomList(int count, int max)
		{
			List SortedList = new List();

			// Initialize the items to random numbers
			Console.WriteLine(String.Format("Initializing list with {0:n0} random values", count));
			Random RGen = new Random(DateTime.Now.Millisecond);
			for (int i = 0; i < count; i++)
				SortedList.Insert(RGen.Next(max));

			return SortedList;
		}

	}
}

