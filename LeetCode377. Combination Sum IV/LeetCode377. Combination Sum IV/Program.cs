using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode377.Combination_Sum_IV
{
	class Program
	{
		//https://leetcode.com/problems/combination-sum-iv/description/
		static void Main(string[] args)
		{
			var s = new Solution();
			var r = s.CombinationSum4(new int[] { 1, 2, 3 }, 4);
		}
		public class Solution
		{
			public int CombinationSum4(int[] nums, int target)
			{
				var memo = new Dictionary<int, int>();
				return CombinationSum4Rec(nums, target,memo);
			}

			private int CombinationSum4Rec(int[] nums, int target, Dictionary<int, int> memo)
			{
				var memoValue = 0;
				if (memo.TryGetValue(target, out memoValue)) return memoValue;
				if (target == 0)
				{
					return 1;
				}
				var count = 0;
				for (int i = 0; i < nums.Length; ++i)
				{
					if (target - nums[i] >= 0)
					{
						target -= nums[i];
						count += CombinationSum4Rec(nums, target,memo);
						target += nums[i];
					}
				}
				memo.Add(target, count);
				return count;
			}
		}
	}
}
