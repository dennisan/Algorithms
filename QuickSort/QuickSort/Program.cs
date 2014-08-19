using System;
using System.Diagnostics;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

// Quick sort is a divid and concur algorithm the works by recursively arranging the elements of the array arount a pivot
// such that the elements left of the pivot are less than the pivot value and the elements right of the pivot are greater than
// the pivot value.  the quicksort has the advantage of sorting the array without requiring additional space. 

// Quick sort runs beteen O(N) and O(N lg N) and requires no additonal space

namespace Quicksort
{
	class Program
	{
		static void Main(string[] args)
		{
			SortRandoms();
			SortFromFile();

			Console.WriteLine("Press any key to exit...");
			Console.ReadKey();
		}

		private static void SortFromFile()
		{
			string filename = "QuickSort.txt";
			Console.WriteLine(string.Format("Reading input array from file [{0}]", filename));

			int CompCount = 0;

			int[] ArrayToSort = GetArrayFromFile(filename);

			// Time MergeSort using watch1
			Stopwatch watch1 = new Stopwatch();
			Console.WriteLine("Beginning Sort");

			watch1.Start();
			Quicksort(ArrayToSort, 0, ArrayToSort.Length - 1, ref CompCount);
			watch1.Stop();

			Console.WriteLine(String.Format("Sort complete in {0:f3} sec with [{1:n0}] comparisons", watch1.ElapsedMilliseconds/1000.0, CompCount));
		}


		private static void SortRandoms()
		{
			// Initialize an array of size ElemCnt;
			int CompCount = 0;
			const int ElemCnt = 5000000;
			const int ElemMax = 1000000;

			int[] ArrayToSort = GetRandomArray(ElemCnt, ElemMax);

			// Time MergeSort using watch1
			Stopwatch watch1 = new Stopwatch();
			Console.WriteLine("Beginning Sort");

			watch1.Start();
			Quicksort(ArrayToSort, 0, ArrayToSort.Length - 1, ref CompCount);
			watch1.Stop();

			Console.WriteLine(String.Format("Sort complete in {0:f3} sec with [{1:n0}] comparisons", watch1.ElapsedMilliseconds/1000.0, CompCount));
		}


		public static int Quicksort(int[] elements, int left, int right, ref int CompCount)
		{
			int i = left, j = right;

			int centerpivot = (right - left > 2) ? elements[((left + right) / 2)] : elements[left];
			int leftpivot = elements[left];
			int rightpivot = elements[right];
			int medianpivot = GetMedian(leftpivot, centerpivot, rightpivot);

			int pivot = medianpivot;

			CompCount += right - left;
			;

			while (i <= j)
			{
				while (elements[i].CompareTo(pivot) < 0)
				{
					i++;
				}

				while (elements[j].CompareTo(pivot) > 0)
				{
					j--;
				}

				if (i <= j)
				{
					// Swap
					int tmp = elements[i];
					elements[i] = elements[j];
					elements[j] = tmp;

					i++;
					j--;
				}
			}


			// Recursive calls
			if (left < j)
			{
				Quicksort(elements, left, j, ref CompCount);
			}

			if (i < right)
			{
				Quicksort(elements, i, right, ref CompCount);
			}

			return CompCount;
		}


		private static int GetMedian(int a, int b, int c)
		{
			if (a < b && b < c)
				return b;
			if (c < b && b < a)
				return b;
			if (b < a && a < c)
				return a;
			if (c < a && a < b)
				return a;
			else
				return c;
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
