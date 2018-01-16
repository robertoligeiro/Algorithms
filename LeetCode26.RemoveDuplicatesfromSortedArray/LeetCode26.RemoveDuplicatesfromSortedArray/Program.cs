using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode26.RemoveDuplicatesfromSortedArray
{
	//https://leetcode.com/problems/remove-duplicates-from-sorted-array/
	class Program
	{
		static void Main(string[] args)
		{
		}
		public class Solution
		{
			public int RemoveDuplicates(int[] nums)
			{
				if (nums == null || nums.Length == 0) return 0;
				var nextWrite = 1;
				for (int i = 1; i < nums.Length; ++i)
				{
					if (nums[i] != nums[i - 1]) nums[nextWrite++] = nums[i];
				}
				return nextWrite;
			}
		}
	}
}
