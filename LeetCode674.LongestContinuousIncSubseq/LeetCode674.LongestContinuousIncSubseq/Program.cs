using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode674.LongestContinuousIncSubseq
{
	class Program
	{
		//https://leetcode.com/problems/longest-continuous-increasing-subsequence/description/
		static void Main(string[] args)
		{
		}
		public class Solution
		{
			public int FindLengthOfLCIS(int[] nums)
			{
				if (nums == null || nums.Length == 0) return 0;
				var count = 1;
				var maxCount = 1;
				for (int i = 1; i < nums.Length; ++i)
				{
					if (nums[i] > nums[i - 1]) count++;
					else
					{
						maxCount = Math.Max(maxCount, count);
						count = 1;
					}
				}
				return Math.Max(maxCount, count);
			}
		}
	}
}
