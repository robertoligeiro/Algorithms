using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode88.Merge_Sorted_Array
{
	class Program
	{
		//https://leetcode.com/problems/merge-sorted-array/description/
		static void Main(string[] args)
		{
			var s = new Solution();
			var n1 = new int[] { 1, 2, 4, 5, 6, 0 };
			s.Merge(n1, 5, new int[] { 1 }, 1);
		}
		public class Solution
		{
			public void Merge(int[] nums1, int m, int[] nums2, int n)
			{
				if (nums1 == null ||
					nums2 == null ||
					nums1.Length == 0 ||
					nums2.Length == 0) return;
				--m;
				--n;
				var nextWrite = nums1.Length - 1;
				while (m >= 0 && n >= 0)
				{
					if (nums1[m] > nums2[n])
					{
						nums1[nextWrite--] = nums1[m--];
					}
					else
					{
						nums1[nextWrite--] = nums2[n--];
					}
				}
				while(n >= 0)
				{
					nums1[nextWrite--] = nums2[n--];
				}
			}
		}
	}
}
