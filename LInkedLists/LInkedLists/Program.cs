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
			TestList();
		}


		private static void TestList()
		{
			// Initialize an array of size ElemCnt;

			Console.Write("How many items do you want in the list: ");
			var Size = Console.ReadLine();
			if (string.IsNullOrWhiteSpace(Size))
				return;

			int ElemCnt = int.Parse(Size);
			int ElemMax = ElemCnt;
			
			List<int> LinkedList = GetRandomList(ElemCnt, ElemMax);

			while (true)
			{
				DumpList(LinkedList);

				Console.Write("\nEnter +/- followed by the value to add/delete from the list: ");
				var s = Console.ReadLine();
				if (s.Length == 0 || (s[0] != '-' && s[0] != '+'))
					break;

				int Val = int.Parse(s.Substring(1));
				if (s.StartsWith("-")) 
				{
					if (LinkedList.Delete(Val) == true)
						Console.WriteLine("The value {0} was deleted from the list.\n", Val);
					else
						Console.WriteLine("The value {0} was not found in the list.\n", Val);
				}
				else if (s.StartsWith("+")) 
				{
					LinkedList.Insert(Val);
					Console.WriteLine("The value {0} was inserted in the list.\n", Val);
				}
			}
		}


		private static List<int> GetRandomList(int count, int max)
		{
			List<int> SortedList = new List<int>();

			// Initialize the items to random numbers
			Random RGen = new Random(DateTime.Now.Millisecond);

			for (int i = 0; i < count; i++)
				SortedList.Insert(RGen.Next(max));

			return SortedList;
		}


		private static void DumpList(List<int> list)
		{
			int x = 0;

			Console.WriteLine("==================================================");
			foreach (int i in list)
			{ 
				Console.Write("{0,4},", i);

				if (++x % 10 == 0)
					Console.WriteLine("");
			}
			Console.WriteLine("\n==================================================");
		}
	}
}

