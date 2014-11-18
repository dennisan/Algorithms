using System;
using System.Diagnostics;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

//test

namespace Sorting
{
	class Program
	{
		static void Main(string[] args)
		{
			SortRandoms();
		}

		private static void SortRandoms()
		{
			Console.Write("Choose size of array to sort: ");
			string ArraySize = Console.ReadLine();

			if (ArraySize.Length == 0)
				return;

			int ElemCnt = int.Parse(ArraySize);
			int ElemMax = ElemCnt;


			while (true)
			{
				int[] ArrayToSort = GetRandomArray(ElemCnt, ElemMax);
				int[] SortedArray = null;

				Console.Write("\nChoose sort algorithm (I)nsertion, (M)erge, (Q)uick:  ");
				string SortType = Console.ReadLine();
				string SortName = "";

				if (SortType.Length == 0)
					break;

				Stopwatch Timer = new Stopwatch();
				Console.Write("\nBeginning Sort...");
				Timer.Start();

				switch (SortType)
				{
					case "I":
					case "i":
						SortName = "Insertion";
						SortedArray = SortLib.InsertionSort.Sort(ArrayToSort);
						break;

					case "M":
					case "m":
						SortName = "Merge";
						SortedArray = SortLib.MergeSort.Sort(ArrayToSort);
						break;

					case "Q":
					case "q":
						SortName = "Quick";
						SortedArray = SortLib.QuickSort.Sort(ArrayToSort);
						break;
				}

				Timer.Stop();
				Console.WriteLine(String.Format("{0} sort complete in {1:n5} Seconds\n\n", SortName, Timer.ElapsedMilliseconds/1000.00));

				for (int i = 1; i < SortedArray.Length; i++)
				{
					if (SortedArray[i] < SortedArray[i-1])
						throw new InvalidDataException();
				}
			}
		}


		private static int[] GetRandomArray(int count, int max)
		{
			int[] RandomArray = new int[count];

			// Initialize the element to random numbers
			Console.WriteLine(String.Format("Initializing array with {0:n0} random values", count));
			Random RGen = new Random(DateTime.Now.Millisecond);
			for (int i = 0; i < count; i++)
				RandomArray[i] = RGen.Next(max);

			return RandomArray;
		}

		private static int[] GetArrayFromFile(string filename)
		{
			StreamReader file = new StreamReader(filename);
			List<int> Numbers = new List<int>(10000);
			string line;

			while ((line = file.ReadLine()) != null)
				Numbers.Add(int.Parse(line));

			file.Close();

			return Numbers.ToArray();
		}

	}
}
