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
		public static T[] Sort<T>(T[] arrayToSort) where T : IComparable
		{
			int Len = arrayToSort.Length;
			int LLen = Len / 2;
			int RLen = (Len + 1) / 2;

			// base case with array of len 1
			if (Len == 1) 
				return arrayToSort;

			// Split array into left and right halves
			T[] LArray = new T[LLen];
			Array.Copy(arrayToSort, LArray, LLen);  // Buffer.BlockCopy() is slightly faster than Array.Copy()

			T[] RArray = new T[RLen];
			Array.Copy(arrayToSort, LLen, RArray, 0, RLen);

			// Recurse on both halves
			LArray = Sort(LArray);
			RArray = Sort(RArray);

			return Merge(LArray, RArray);
		}

		private static T[] Merge<T>(T[] LArray, T[] RArray) where T : IComparable
		{
			int Len = LArray.Length + RArray.Length;
			T[] SortedArray = new T[Len];

			for (int i = 0, l = 0, r = 0; i < Len ; i++)
			{
				if (l >= LArray.Length)				// Left array is empty
					SortedArray[i] = RArray[r++];
				else if (r >= RArray.Length)		// right array is empty
					SortedArray[i] = LArray[l++];
				else if (LArray[l].CompareTo(RArray[r]) < 0)			
					SortedArray[i] = LArray[l++];
				else
					SortedArray[i] = RArray[r++];
			}
			
			return SortedArray;
		}
	}
}
