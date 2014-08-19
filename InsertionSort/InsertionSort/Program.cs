using System;
using System.Diagnostics;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

// Insertion sort is a brute force algorithm the works by travesing the elements of the array swappng the pivot element into position
// on the left side of the array

// Insertion sort runs beteen O(N) and O(N lg N) and requires no additonal space

namespace Insertionsort
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
			const int ElemCnt = 200000;
			const int ElemMax = 1000000;

			int[] ArrayToSort = GetRandomArray(ElemCnt, ElemMax);

			// Time MergeSort using watch1
			Stopwatch watch1 = new Stopwatch();
			Console.WriteLine("Beginning Sort");

			watch1.Start();
			int CompCount = InsertionSort(ArrayToSort);
			watch1.Stop();

			foreach (int i in ArrayToSort)
				Console.WriteLine(i);
			Console.WriteLine(String.Format("Sort complete in {0:f3} sec with [{1:n0}] comparisons", watch1.ElapsedMilliseconds / 1000.0, CompCount));
		}


		public static int InsertionSort(int[] elements)
		{
			int comparisons = 1;

			if (elements.Length < 1)
				return comparisons;

			for (int i = 1; i < elements.Length; i++)
			{
				for (int j = i; j > 0 && elements[j] < elements[j-1]; j--)
				{
					comparisons++;
					int temp = elements[j-1];
					elements[j-1] = elements[j];
					elements[j] = temp;
				}
			}

			return comparisons;
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
	}
}
