﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SortLib
{
	public class InsertionSort
	{
		public static int[] Sort(int[] arrayToSort)
		{
			int comparisons = 1;

			if (arrayToSort.Length < 1)
				return arrayToSort;

			for (int i = 1; i < arrayToSort.Length; i++)
			{
				for (int j = i; j > 0 && arrayToSort[j] < arrayToSort[j - 1]; j--)
				{
					comparisons++;
					int temp = arrayToSort[j - 1];
					arrayToSort[j - 1] = arrayToSort[j];
					arrayToSort[j] = temp;
				}
			}

			return arrayToSort;
		}
	}
}