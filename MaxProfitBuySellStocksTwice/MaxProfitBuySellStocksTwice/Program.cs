using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MaxProfitBuySellStocksTwice
{
	class Program
	{
		static void Main(string[] args)
		{
			var r = MaxProfit(new int[] { 12,11,13,9,12,8,14,13,15});
		}

		public static int MaxProfit(int[] prices)
		{
			var min = prices[0];
			var profit = 0;
			var firstProfit = new List<int>() { 0 };
			for (int i = 0; i < prices.Length; ++i)
			{
				profit = Math.Max(profit, prices[i] - min);
				min = Math.Min(min, prices[i]);
				firstProfit.Add(profit);
			}

			profit = 0;
			var max = prices.Last();
			var secondProfit = new List<int>() { 0 };
			for (int i = prices.Length - 2; i >=0; --i)
			{
				profit = Math.Max(profit, max - prices[i]);
				max = Math.Max(max, prices[i]);
				secondProfit.Add(profit);
			}
			profit = 0;
			for (int i = 0, j = secondProfit.Count - 1; j >= 0; ++i, --j)
			{
				profit = Math.Max(profit, firstProfit[i] + secondProfit[j]);
			}
			return profit;
		}
	}
}
