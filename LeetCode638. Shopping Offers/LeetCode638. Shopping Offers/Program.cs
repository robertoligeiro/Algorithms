using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode638.Shopping_Offers
{
	class Program
	{
		static void Main(string[] args)
		{
			var s = new Solution();
			var r = s.ShoppingOffers(new List<int>() { 2, 5 },
				new List<IList<int>>() { new List<int>() { 3,0,5}, new List<int>() { 1,2,10} },
				new List<int>() {3,2});
		}

		public class ConsolidatedItems
		{
			public List<int> needs = new List<int>();
			public int cost;
			public int totalItems;
			public ConsolidatedItems() { }
			public ConsolidatedItems(ConsolidatedItems c)
			{
				this.cost = c.cost;
				this.totalItems = c.totalItems;
				this.needs = new List<int>(c.needs);
			}
		}

		public class Solution
		{
			public int ShoppingOffers(IList<int> price, IList<IList<int>> special, IList<int> needs)
			{
				var items = new ConsolidatedItems();
				var totalPriceNoSpecial = 0;
				for(var i = 0; i < needs.Count; ++i)
				{
					items.needs.Add(needs[i]);
					items.totalItems += needs[i];
					totalPriceNoSpecial += needs[i] * price[i];
				}

				return ShoppingOffers(price, special, items, 0).cost;
			}
			private ConsolidatedItems ShoppingOffers(IList<int> price, IList<IList<int>> special, ConsolidatedItems items, int index)
			{
				if (items.totalItems == 0 || index >= special.Count)
				{
					if (items.totalItems == 0) return items;
					for (int i = 0; i < items.needs.Count; ++i)
					{
						if (items.needs[i] > 0)
						{
							items.cost += items.needs[i] * price[i];
						}
					}
					return items;
				}
				var copyItems = new ConsolidatedItems(items);
				var newItems = CanGetSpecial(special[index], items);
				if (newItems != null)
				{
					newItems = ShoppingOffers(price, special, newItems, index);
				}
				copyItems = ShoppingOffers(price, special, copyItems, index + 1);

				if (newItems != null && newItems.cost < copyItems.cost) return newItems;
				return copyItems;
			}

			private ConsolidatedItems CanGetSpecial(IList<int> special, ConsolidatedItems items)
			{
				var resp = new ConsolidatedItems(items);
				for (int i = 0; i < resp.needs.Count; ++i)
				{
					var diff = resp.needs[i] - special[i];
					if (diff >= 0) resp.needs[i] = diff;
					else return null;
					resp.totalItems -= special[i];
				}
				resp.cost += special.Last();
				return resp;
			}
		}
	}
}
