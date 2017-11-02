using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode213.House_Robber_II
{
	class Program
	{
		//https://leetcode.com/problems/house-robber-ii/discuss/
		static void Main(string[] args)
		{
		}
		public class Solution
		{
			public int Rob(int[] nums)
			{
				if (nums.Length == 1) return nums[0];
				return Math.Max(Rob(nums, 0, nums.Length - 2), Rob(nums, 1, nums.Length - 1));
			}

			public int Rob(int[] num, int l, int r)
			{
				int rob = 0; //max monney can get if rob current house
				int notrob = 0; //max money can get if not rob current house
				for (int i = l; i <= r; i++)
				{
					int currob = notrob + num[i]; //if rob current value, previous house must not be robbed
					notrob = Math.Max(notrob, rob); //if not rob ith house, take the max value of robbed (i-1)th house and not rob (i-1)th house
					rob = currob;
				}
				return Math.Max(rob, notrob);
			}
		}
	}
}
