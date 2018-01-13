using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode121.Best_Time_to_Buy_and_Sell_Stock
{
	//https://leetcode.com/problems/best-time-to-buy-and-sell-stock/description/
	class Program
	{
		static void Main(string[] args)
		{
		}

		public class Solution
		{
			public int MaxProfit(int[] prices)
			{
				if (prices == null || prices.Length == 0) return 0;
				var min = prices[0];
				var maxProfit = int.MinValue;
				for (int i = 1; i < prices.Length; ++i)
				{
					maxProfit = Math.Max(maxProfit, prices[i] - min);
					min = Math.Min(min, prices[i]);
				}
				return maxProfit >= 0 ? maxProfit : 0;
			}
		}
	}
}
