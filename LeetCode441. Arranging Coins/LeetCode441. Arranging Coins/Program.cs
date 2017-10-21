using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode441.Arranging_Coins
{
	/https://leetcode.com/problems/arranging-coins/description/
	class Program
	{
		static void Main(string[] args)
		{
			var s = new Solution();
			var r = s.ArrangeCoins(5);
		}
		public class Solution
		{
			public int ArrangeCoins(int n)
			{
				var count = 1;
				var resp = 0;
				while (n - count >= 0)
				{
					n -= (count++);
					resp++;
				}
				return resp;
			}
		}
	}
}
