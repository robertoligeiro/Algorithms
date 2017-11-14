using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode80.RemoveDuplicatesfromSortedArrayII
{
	class Program
	{
		//https://leetcode.com/problems/remove-duplicates-from-sorted-array-ii/description/
		static void Main(string[] args)
		{
			var s = new Solution();
			var i = new int[] { 1, 1, 1, 2, 2, 3 };
			var r = s.RemoveDuplicates(i);
		}
		public class Solution
		{
			public int RemoveDuplicates(int[] nums)
			{
				if (nums.Length == 0) return 0;
				var nextWrite = 1;
				var isSame = false;
				var prev = nums[0];
				for (int i = 1; i < nums.Length; ++i)
				{
					if (nums[i] != prev)
					{
						nums[nextWrite++] = nums[i];
						isSame = false;
					}
					else if (nums[i] == prev && !isSame)
					{
						nums[nextWrite++] = nums[i];
						isSame = true;
					}
					prev = nums[i];
				}
				return nextWrite;
			}
		}
	}
}
