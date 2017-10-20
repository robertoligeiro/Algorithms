using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode375.Guess_Number_Higher_or_Lower_II
{
	class Program
	{
		//https://leetcode.com/problems/guess-number-higher-or-lower-ii/description/
		static void Main(string[] args)
		{
			var s = new Solution();
			var r = s.GetMoneyAmount(10);
		}
		public class Solution
		{
			public int GetMoneyAmount(int n)
			{
				var memo = new int[n+1,n+1];
				return GetMoneyAmount(1, n, memo);
			}
			private int GetMoneyAmount(int start, int end, int[,] memo)
			{
				if (start >= end)
				{
					return 0;
				}
				if (memo[start, end] != 0)
				{
					return memo[start, end];
				}
				var minMoney = int.MaxValue;
				for (int i = start; i <= end; ++i)
				{
					var money = i + Math.Max(GetMoneyAmount(start, i - 1, memo), GetMoneyAmount(i + 1, end, memo));
					minMoney = Math.Min(minMoney, money);
				}
				memo[start, end] = minMoney;
				return minMoney;
			}
		}
	}
}
