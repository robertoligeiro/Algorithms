using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArraysBuyAndSellStocksTwice
{
    class Program
    {
        static void Main(string[] args)
        {
            var r = BuySell(new List<int>() { 12, 11, 13, 9, 12, 8, 14, 13, 15 });
        }

        public static int BuySell(List<int> stocks)
        {
            var minSoFar = stocks[0];
            var maxProfit = 0;
            var firstBuy = new List<int>() { 0 };
            for (int i = 1; i < stocks.Count; ++i)
            {
                var currProfit = stocks[i] - minSoFar;
                maxProfit = Math.Max(maxProfit, currProfit);
                minSoFar = Math.Min(minSoFar, stocks[i]);
                firstBuy.Add(maxProfit);
            }

            var maxSoFar = stocks[stocks.Count - 1];
            maxProfit = 0;
            var secondBuy = new List<int>() { 0 };
            for (int i = stocks.Count - 2; i >= 0; --i)
            {
                var currProfit = maxSoFar - stocks[i];
                maxProfit = Math.Max(maxProfit, currProfit);
                maxSoFar = Math.Max(maxSoFar, stocks[i]);
                secondBuy.Add(maxProfit);
            }

            maxProfit = 0;
            int f = 0;
            int s = stocks.Count - 1;
            for (;s>=0;--s,++f)
            {
                maxProfit = Math.Max(maxProfit, firstBuy[f] + secondBuy[s]);
            }

            return maxProfit;
        }
    }
}
