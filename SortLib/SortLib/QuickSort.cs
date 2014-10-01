using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SortLib
{
	public class QuickSort {

		public static int[] Sort(int[] arrayToSort)
		{
			return Sort(arrayToSort, 0, arrayToSort.Length-1);
		}

		private static int[] Sort(int[] elements, int left, int right)
		{
			int i = left, j = right;

			int centerpivot = (right - left > 2) ? elements[((left + right) / 2)] : elements[left];
			int leftpivot = elements[left];
			int rightpivot = elements[right];
			int medianpivot = GetMedian(leftpivot, centerpivot, rightpivot);

			int pivot = medianpivot;

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
				Sort(elements, left, j);
			}

			if (i < right)
			{
				Sort(elements, i, right);
			}

			return elements;
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


	}

}
