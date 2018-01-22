using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode322.Coin_Change
{
	class Program
	{
		//https://leetcode.com/problems/coin-change/description/
		static void Main(string[] args)
		{
			var s = new Solution();
			//var r = s.CoinChange(new int[] { 1, 2, 5 }, 11);
			//var r = s.CoinChange(new int[] { 2, 5,10,1 }, 27);
			var r = s.CoinChange(new int[] { 2 }, 3);
		}

		public class Solution
		{
			public int CoinChange(int[] coins, int amount)
			{
				var memo = new int[amount+1];
				var resp = CoinChange(coins, amount, memo);

				return resp == int.MaxValue?-1:resp; //for cases there's no answer. i.e. coins:[2], amt:3
			}
			private int CoinChange(int[] coins, int amt, int[] memo)
			{
				if (amt == 0) return 0;
				if (memo[amt] != 0) return memo[amt];
				var min = int.MaxValue;
				foreach(var c in coins)
				{
					if (amt-c >=0)
					{
						var localMin = CoinChange(coins, amt - c, memo);
						if (localMin == int.MaxValue) continue;
						min = Math.Min(localMin+1, min);
					}
				}
				memo[amt] = min; 
				return min;
			}
		}

		public class SolutionOld
		{
			public int CoinChange(int[] coins, int amount)
			{
				var memo = new Dictionary<int, int>();
				return CoinChange(coins, amount, memo);
			}
			private int CoinChange(int[] coins, int amt, Dictionary<int, int> memo)
			{
				if (amt < 0) return -1;
				if (amt == 0) return 0;
				var memoCount = 0;
				if (memo.TryGetValue(amt, out memoCount)) return memoCount;
				var min = int.MaxValue;
				for (int i = 0; i < coins.Length; ++i)
				{
					var localMin = CoinChange(coins, amt - coins[i], memo);
					if (localMin != -1)
					{
						localMin++;
						min = Math.Min(localMin, min);
					}
				}
				if (min == int.MaxValue) min = -1;
				memo.Add(amt, min);
				return min;
			}
		}
	}
}
