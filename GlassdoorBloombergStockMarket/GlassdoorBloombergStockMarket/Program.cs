using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GlassdoorBloombergStockMarket
{
	class Program
	{
		static void Main(string[] args)
		{
			var stockMarket = new StockMarket();
			stockMarket.AddStock("google", 50);
			stockMarket.AddStock("apple", 150);
			stockMarket.AddStock("google", 100);
			stockMarket.AddStock("msft", 250);
			stockMarket.AddStock("google", 200);
			var t = stockMarket.GetTopStocks(2);
			stockMarket.AddStock("msft", 100);
			t = stockMarket.GetTopStocks(2);
		}

		public class StockMarket
		{
			private Dictionary<string, int> stocks = new Dictionary<string, int>();
			private SortedDictionary<int, HashSet<string>> topStocks = new SortedDictionary<int, HashSet<string>>();

			public void AddStock(string stock, int amt)
			{
				var lastAmt = 0;
				if (stocks.TryGetValue(stock, out lastAmt))
				{
					topStocks[lastAmt].Remove(stock);
					if (topStocks[lastAmt].Count == 0)
					{
						topStocks.Remove(lastAmt);
					}
					stocks[stock] = lastAmt + amt;
				}
				else stocks.Add(stock, amt);

				HashSet<string> hashStocks = null;
				if (topStocks.TryGetValue(stocks[stock], out hashStocks))
				{
					hashStocks.Add(stock);
				}
				else topStocks.Add(stocks[stock], new HashSet<string>() { stock });
			}

			public List<Tuple<string, int>> GetTopStocks(int top)
			{
				var resp = new List<Tuple<string, int>>();
				var i = topStocks.Count - 1;
				while (i >= 0 && resp.Count < top)
				{
					foreach (var s in topStocks.ElementAt(i).Value)
					{
						resp.Add(new Tuple<string, int>(s, topStocks.ElementAt(i).Key));
					}
					--i;
				}
				return resp;
			}
		}
	}
}
