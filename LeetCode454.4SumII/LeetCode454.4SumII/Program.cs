using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode454._4SumII
{
	class Program
	{
		//https://leetcode.com/problems/4sum-ii/description/
		static void Main(string[] args)
		{
			var s = new Solution();
			var r = s.FourSumCount(new int[] { 1,2}, new int[] { -2,-1}, new int[] { -1,2}, new int[] { 0,2});
		}
		public class Solution
		{
			public int FourSumCount(int[] A, int[] B, int[] C, int[] D)
			{
				var mapAB = new Dictionary<int, int>();
				foreach(var a in A)
				{
					foreach (var b in B)
					{
						var count = 0;
						var sum = a + b;
						if (mapAB.TryGetValue(sum, out count)) mapAB[sum] = ++count;
						else mapAB.Add(sum, 1);
					}
				}
				var res = 0;
				foreach (var c in C)
				{
					foreach (var d in D)
					{
						var count = 0;
						var sum = -1 * (c + d);
						if (mapAB.TryGetValue(sum, out count)) res += count;
					}
				}
				return res;
			}
		}
	}
}
