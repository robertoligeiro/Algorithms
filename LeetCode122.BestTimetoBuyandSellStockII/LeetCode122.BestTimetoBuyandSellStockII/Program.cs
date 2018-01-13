using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode122.BestTimetoBuyandSellStockII
{
	class Program
	{
		//https://leetcode.com/problems/best-time-to-buy-and-sell-stock-ii/description/
		static void Main(string[] args)
		{
			var s = new Solution();
			var r = s.maxProfit(new int[] { 1, 7, 2, 3, 6, 7, 6, 7 });
		}
		public class Solution
		{
			public int maxProfit(int[] prices)
			{
				var resp = 0;
				for (int i = 1; i < prices.Length; ++i)
				{
					if (prices[i] > prices[i - 1]) resp += prices[i] - prices[i - 1];
				}
				return resp;
			}
		}
	}
}
