using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode315.CountofSmallerNumbersAfterSelf
{
	class Program
	{
		static void Main(string[] args)
		{
			var s = new Solution();
			var r = s.CountSmaller(new int[] { 5, 2, 6, 1 });
		}

		public class Solution
		{
			public class Pair
			{
				public int index;
				public int val;
				public Pair(int index, int val)
				{
					this.index = index;
					this.val = val;
				}
			}
			public IList<int> CountSmaller(int[] nums)
			{
				List<int> res = new List<int>();
				if (nums == null || nums.Length == 0)
				{
					return res;
				}
				Pair[] arr = new Pair[nums.Length];
				int[] smaller = new int[nums.Length];
				for (int i = 0; i < nums.Length; i++)
				{
					arr[i] = new Pair(i, nums[i]);
				}
				mergeSort(arr, smaller);
				res.AddRange(smaller);
				return res;
			}
			private Pair[] mergeSort(Pair[] arr, int[] smaller)
			{
				if (arr.Length <= 1)
				{
					return arr;
				}
				int mid = arr.Length / 2;
				var l = new Pair[mid];
				Array.Copy(arr, l, mid);
				var r = new Pair[arr.Length - mid];
				Array.Copy(arr, mid, r, 0, arr.Length - mid);
				Pair[] left = mergeSort(l, smaller);
				Pair[] right = mergeSort(r, smaller);
				for (int i = 0, j = 0; i < left.Length || j < right.Length;)
				{
					if (j == right.Length || i < left.Length && left[i].val <= right[j].val)
					{
						arr[i + j] = left[i];
						smaller[left[i].index] += j;
						i++;
					}
					else
					{
						arr[i + j] = right[j];
						j++;
					}
				}
				return arr;
			}
		}
	}
}
