using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode198.House_Robber
{
	class Program
	{
		static void Main(string[] args)
		{
			var s = new Solution();
			var r = s.Rob(new int[] { 11, 8, 2, 10 });
		}

		//optimal solution, from here: https://discuss.leetcode.com/topic/12024/java-dp-solution-o-n-runtime-and-o-1-space-with-inline-comment
		public class Solution
		{
			public int Rob(int[] num)
			{
				int rob = 0; //max monney can get if rob current house
				int notrob = 0; //max money can get if not rob current house
				for (int i = 0; i < num.Length; i++)
				{
					int currob = notrob + num[i]; //if rob current value, previous house must not be robbed
					notrob = Math.Max(notrob, rob); //if not rob ith house, take the max value of robbed (i-1)th house and not rob (i-1)th house
					rob = currob;
				}
				return Math.Max(rob, notrob);
			}
		}
	public class Solution1
		{
			public int Rob(int[] nums)
			{
				return Math.Max(Rob(nums, 0, 0, true), Rob(nums, 0, 0, false));
			}
			private int Rob(int[] nums, int index, int acc, bool canTake)
			{
				if (index == nums.Length) return acc;
				var taken = 0;
				if (canTake) taken = Rob(nums, index + 1, acc + nums[index], false);
				var notTaken = Rob(nums, index + 1, acc, true);
				return Math.Max(taken, notTaken);
			}
		}
	}
}
