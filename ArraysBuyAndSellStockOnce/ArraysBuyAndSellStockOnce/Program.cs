using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArraysBuyAndSellStockOnce
{
    class Program
    {
        static void Main(string[] args)
        {
            var r = BuySell(new List<int>() { 310, 315, 275, 295, 260, 270, 290, 230, 255, 250});
        }

        public static int BuySell(List<int> s)
        {
            var minSoFar = s[0];
            var maxProfit = 0;
            for(int i =1; i < s.Count;++i)
            {
                var currProfit = s[i] - minSoFar;
                maxProfit = Math.Max(maxProfit, currProfit);
                minSoFar = Math.Min(minSoFar, s[i]);
            }
            return maxProfit;
        }
    }
}
