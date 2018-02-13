using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode334.Increasing_Triplet_Subsequence
{
	class Program
	{
		//https://leetcode.com/problems/increasing-triplet-subsequence/description/
		static void Main(string[] args)
		{
			var s = new Solution();
			var r = s.IncreasingTriplet(new int[] { 2, 1, 5, 0, 4, 4 });
		}

		public class Solution
		{
			public bool IncreasingTriplet(int[] nums)
			{
				if (nums == null || nums.Length < 3) return false;

				var first = int.MaxValue;
				var second = int.MaxValue;

				foreach (var i in nums)
				{
					if (i <= first) first = i;
					else if (i <= second) second = i;
					else return true;
				}

				return false;
			}
		}
	}
}
