using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ubert
{
	class Program
	{
		static void Main(string[] args)
		{
			var inputTrans = new List<Transaction>()
			{
				new Transaction("BoA", 132, "Chase"),
				new Transaction("BoA", 827, "Chase"),
				new Transaction("Well Fargo", 751, "BoA"),
				new Transaction("BoA", 585, "Chase"),
				new Transaction("Chase", 877, "Well Fargo"),
				new Transaction("Well Fargo", 157, "Chase"),
				new Transaction("Well Fargo", 904, "Chase"),
				new Transaction("Chase", 548, "Well Fargo"),
				new Transaction("Chase", 976, "BoA"),
				new Transaction("BoA", 872, "Well Fargo"),
				new Transaction("Well Fargo", 571, "Chase"),
			};

			var r = Solution.CalcCreditBetweenBanks(inputTrans);
			foreach (var t in r)
			{
				Console.WriteLine(t.payee + " " + t.amount + " "+ t.payer);
			}
		}

		public class Transaction
		{
			public string payee;
			public string payer;
			public int amount;
			public Transaction(string payee, int amount, string payer)
			{
				this.payee = payee;
				this.amount = amount;
				this.payer = payer;
			}
		}

		public class Solution
		{
			public static List<Transaction> CalcCreditBetweenBanks(List<Transaction> transactions)
			{
				var resp = new List<Transaction>();
				var map = new Dictionary<Tuple<string, string>, int>();

				foreach (var t in transactions)
				{
					var bankTuple = new Tuple<string, string>(t.payee, t.payer);
					var bankOwesTuple = new Tuple<string, string>(t.payer, t.payee);
					var credit = 0;
					if (map.TryGetValue(bankOwesTuple, out credit))
					{
						map[bankOwesTuple] = (credit - t.amount);
					}
					else
					{
						if (map.TryGetValue(bankTuple, out credit))
						{
							map[bankTuple] = (credit + t.amount);
						}
						else
						{
							map.Add(bankTuple, t.amount);
						}
					}
				}

				foreach (var pair in map)
				{
					var t = new Transaction(pair.Key.Item1, pair.Value, pair.Key.Item2);
					resp.Add(t);
				}
				return resp;
			}
		}
	}
}
