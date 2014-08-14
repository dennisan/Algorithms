using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;


namespace Quicksort
{
	class Program
	{
		static void Main(string[] args)
		{
			int CompCount = 0;
			string filename = "QuickSort.txt";

			Console.WriteLine(string.Format("Reading input array from file [{0}]", filename));
			int[] unsorted = GetArrayFromFile(filename);

			// Sort the array
			Quicksort(unsorted, 0, unsorted.Length - 1, ref CompCount);

			Console.WriteLine(string.Format("Array sorted with [{0}] comparisons", CompCount));

			Console.WriteLine("Press any key to continue...");

			Console.ReadLine();
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
