using System;
using System.Diagnostics;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;



namespace Sorting
{
	class Program
	{
		static void Main(string[] args)
		{
			SortRandoms();

			Console.WriteLine("Press any key to exit...");
			Console.ReadKey();
		}

		private static void SortRandoms()
		{
			// Initialize an array of size ElemCnt;
			const int ElemCnt = 5000000;
			const int ElemMax = 1000000;

			int[] ArrayToSort = GetRandomArray(ElemCnt, ElemMax);

			// Time MergeSort using watch1
			Stopwatch watch1 = new Stopwatch();
			Console.WriteLine("Beginning Merge Sort");

			watch1.Start();
			int[] MergeSortedArray = SortLib.MergeSort.Sort(ArrayToSort);
			watch1.Stop();

			Console.WriteLine(String.Format("Merge sort complete in {0:n0} Milliseconds", watch1.ElapsedMilliseconds));
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
