using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SortLib
{
	// Merge sort is a recursive algorithm the works by breaking an array into two halves and then merging
	// the two halves back into a new sorted array.  Recursion continues until the array has only a single elment.  

	// Merge sort runs in O(N lg N) but requires N additional space

	public class MergeSort
	{
		public static int[] Sort(int[] arrayToSort)
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
			LArray = Sort(LArray);
			RArray = Sort(RArray);

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


	}
}
