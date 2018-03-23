using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode746.Min_Cost_Climbing_Stairs
{
	//https://leetcode.com/problems/min-cost-climbing-stairs/description/
	class Program
	{
		static void Main(string[] args)
		{
		}
		public class Solution
		{
			public int MinCostClimbingStairs(int[] cost)
			{
				var f1 = 0;
				var f2 = 0;
				for (int i = cost.Length - 1; i >= 0; --i)
				{
					var f0 = cost[i] + Math.Min(f1, f2);
					f2 = f1;
					f1 = f0;
				}
				return Math.Min(f1, f2);
			}
		}
	}
}
