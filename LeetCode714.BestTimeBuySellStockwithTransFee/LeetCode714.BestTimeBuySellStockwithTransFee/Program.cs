using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode714.BestTimeBuySellStockwithTransFee
{
	class Program
	{
		static void Main(string[] args)
		{
			var s = new Solution();
			var r = s.MaxProfit(new int[] { 1, 2,3,4,1,5,2,28 },2);
		}

		public class Solution
		{
			public int MaxProfit(int[] prices, int fee)
			{
				var cash = 0;
				var hold = -prices[0];
				for (int i = 0; i < prices.Length; ++i)
				{
					cash = Math.Max(cash, hold + prices[i] - fee);
					hold = Math.Max(hold, cash-prices[i]);
				}
				return cash;
			}
		}
	}
}
