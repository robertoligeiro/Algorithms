using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode134.Gas_Station
{
	class Program
	{
		//https://leetcode.com/problems/gas-station/description/
		static void Main(string[] args)
		{
			var s = new Solution();
			var r = s.CanCompleteCircuit(new int[] { 10,20,10,40}, new int[] {20,5,30,5 });
		}
		public class Solution
		{
			public int CanCompleteCircuit(int[] gas, int[] cost)
			{
				if (gas.Length == 1) return gas[0] > cost[0] ? 0 : -1;
				var money = 0;
				var lowestMoney = int.MaxValue;
				var indexLowest = -1;
				for (int i = 0; i < gas.Length; ++i)
				{
					money += (gas[i] - cost[i]);
					if (money < lowestMoney)
					{
						lowestMoney = money;
						indexLowest = i;
					}
				}

				var startIndex = (indexLowest + 1) % gas.Length;
				var count = 0;
				money = 0;
				while(count < gas.Length)
				{
					money += (gas[startIndex%gas.Length] - cost[startIndex % gas.Length]);
					startIndex++;
					count++;
				}
				return money >= 0 ? (indexLowest + 1) % gas.Length : -1;
			}
		}
	}
}
