using System;
using System.Diagnostics;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace MergeSort
{
	class Program
	{
		static void Main(string[] args)
		{
			SortRandoms();
			//SortAndCountInvesions();

			Console.WriteLine("Press any key to exit...");
			Console.ReadKey();
		}


		private static void SortAndCountInvesions()
		{
			long InversionCount = 0;
			string filename = "IntegerArray.txt";

			Console.WriteLine(string.Format("Reading input array from file [{0}]", filename));
			int[] Array = GetArrayFromFile(filename);

			int[] SortedArray = MergeSortAndCountInversions(Array, ref InversionCount);
			Console.WriteLine(String.Format("The Array has {0:n0} elements and {1:n0} inversions", Array.Length, InversionCount));
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
			int[] MergeSortedArray = MergeSort(ArrayToSort);
			watch1.Stop();
			Console.WriteLine(String.Format("Merge sort complete in {0:n0} Milliseconds", watch1.ElapsedMilliseconds));
		}

		private static int[] MergeSort(int[] arrayToSort)
		{
			int len = arrayToSort.Length;
			int LLen = len / 2;
			int RLen = (len + 1) / 2;

			// base case with array of len 1
			if (len == 1) return arrayToSort;

			// Split array into left and right halves
			int[] LArray = new int[LLen];
			Array.Copy(arrayToSort, LArray, LLen);  // Buffer.BlockCopy() is slightly faster than Array.Copy()

			int[] RArray = new int[RLen];
			Array.Copy(arrayToSort, LLen, RArray, 0, RLen);

			// Recurse on both halves
			LArray = MergeSort(LArray);
			RArray = MergeSort(RArray);

			// Merge the result into SortedArray
			int l = 0, r = 0, i = 0;
			int[] SortedArray = new int[len];

			while (l < LLen && r < RLen)
			{
				if (LArray[l] <= RArray[r])
					SortedArray[i++] = LArray[l++];
				else
					SortedArray[i++] = RArray[r++];
			}

			// pick up remaining elements in either array
			while (l < LLen)
				SortedArray[i++] = LArray[l++];

			while (r < RLen)
				SortedArray[i++] = RArray[r++];

			return SortedArray;
		}

		private static int[] MergeSortAndCountInversions(int[] arrayToSort, ref long InversionCount)
		{
			int len = arrayToSort.Length;
			int LLen = len / 2;
			int RLen = (len + 1) / 2;

			// base case with array of len 1
			if (len == 1) return arrayToSort;

			// Split array into left and right halves
			int[] LArray = new int[LLen];
			Array.Copy(arrayToSort, LArray, LLen);  // Buffer.BlockCopy() is slightly faster than Array.Copy()

			int[] RArray = new int[RLen];
			Array.Copy(arrayToSort, LLen, RArray, 0, RLen);

			// Recurse on both halves
			LArray = MergeSortAndCountInversions(LArray, ref InversionCount);
			RArray = MergeSortAndCountInversions(RArray, ref InversionCount);

			// Merge the result into SortedArray
			int l = 0, r = 0, i = 0;
			int[] SortedArray = new int[len];

			while (l < LLen && r < RLen)
			{
				if (LArray[l] <= RArray[r])
					SortedArray[i++] = LArray[l++];
				else
				{
					SortedArray[i++] = RArray[r++];
					InversionCount += LLen - l;
				}
			}

			// pick up remaining elements in either array
			while (l < LLen)
				SortedArray[i++] = LArray[l++];

			while (r < RLen)
			{
				SortedArray[i++] = RArray[r++];
				InversionCount += LLen - l;
			}

			return SortedArray;
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
