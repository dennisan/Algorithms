using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SortLib
{
	// Quick sort is a divid and concur algorithm the works by recursively arranging the elements of the array around a pivot
	// such that the elements left of the pivot are less than the pivot value and the elements right of the pivot are greater than
	// the pivot value.  the quicksort has the advantage of sorting the array without requiring additional space. 

	// Quick sort runs beteen O(N) and O(N lg N) and requires no additonal space


	public class QuickSort 
	{

		public static T[] Sort<T>(T[] arrayToSort) where T : IComparable 
		{
			return Sort(arrayToSort, 0, arrayToSort.Length-1);
		}

		private static T[] Sort<T>(T[] elements, int left, int right) where T : IComparable 
		{
			int i = left, j = right;

			T centerpivot = (right - left > 2) ? elements[((left + right) / 2)] : elements[left];
			T leftpivot = elements[left];
			T rightpivot = elements[right];
			T medianpivot = GetMedian(leftpivot, centerpivot, rightpivot);

			T pivot = medianpivot;

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
					T tmp = elements[i];
					elements[i] = elements[j];
					elements[j] = tmp;

					i++;
					j--;
				}
			}


			// Recursive calls
			if (left < j)
			{
				Sort(elements, left, j);
			}

			if (i < right)
			{
				Sort(elements, i, right);
			}

			return elements;
		}


		private static T GetMedian<T>(T a, T b, T c) where T : IComparable 
		{
			if (a.CompareTo(b) < 0 && b.CompareTo(c) < 0)
				return b;
			if (c.CompareTo(b) < 0 && b.CompareTo(a) < 0)
				return b;
			if (b.CompareTo(a) < 0 && a.CompareTo(c) < 0)
				return a;
			if (c.CompareTo(a) < 0 && a.CompareTo(b) < 0)
				return a;
			else
				return c;
		}


	}

}
