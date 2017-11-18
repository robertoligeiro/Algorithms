using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode475.Heaters
{
	//https://leetcode.com/problems/heaters/description/
	// not passing.s
	class Program
	{
		static void Main(string[] args)
		{
			var s = new Solution();
			var r = s.FindRadius(new int[] { 1, 2, 3 }, new int[] { 1 });
		}
		public class Solution
		{
			public int FindRadius(int[] houses, int[] heaters)
			{
				houses.OrderBy(x => x);
				heaters.OrderBy(x => x);
				var res = Enumerable.Repeat(int.MaxValue, houses.Length).ToList();

				//distance to right heater
				for (int iHouse = 0, iHeater = 0; iHouse < houses.Length && iHeater < heaters.Length;)
				{
					if (houses[iHouse] <= heaters[iHeater])
					{
						res[iHouse] = heaters[iHeater] - houses[iHouse];
						iHouse++;
					}
					else
					{
						iHeater++;
					}
				}
				//distance to left heater
				for (int iHouse = houses.Length-1, iHeater = heaters.Length-1; iHouse >=0 && iHeater >=0;)
				{
					if (houses[iHouse] >= heaters[iHeater])
					{
						res[iHouse] = Math.Min(res[iHouse], houses[iHouse] - heaters[iHeater]);
						iHouse--;
					}
					else
					{
						iHeater--;
					}
				}

				//resp is the bigger differece
				return res.Max();
			}
		}
	}
}
