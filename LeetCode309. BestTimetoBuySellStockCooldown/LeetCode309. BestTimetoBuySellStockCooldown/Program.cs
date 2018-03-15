using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode309.BestTimetoBuySellStockCooldown
{
	class Program
	{
		static void Main(string[] args)
		{
		}
		//https://leetcode.com/problems/best-time-to-buy-and-sell-stock-with-cooldown/description/
		public class Solution
		{
			public int MaxProfit(int[] prices)
			{
				if (prices == null || prices.Length <= 1) return 0;
				var s0 = new int[prices.Length];
				var s1 = new int[prices.Length];
				var s2 = new int[prices.Length];
				s1[0] = -prices[0];
				s2[0] = int.MinValue;
				for (int i = 1; i < prices.Length; ++i)
				{
					s0[i] = Math.Max(s0[i - 1], s2[i-1]);
					s1[i] = Math.Max(s1[i - 1], s0[i - 1] - prices[i]);
					s2[i] = s1[i - 1] + prices[i];
				}
				return Math.Max(s0.Last(), s2.Last());
			}
		}
	}
}
