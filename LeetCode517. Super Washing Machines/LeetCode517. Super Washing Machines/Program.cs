using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode517.Super_Washing_Machines
{
	//https://leetcode.com/problems/super-washing-machines/description/
	class Program
	{
		static void Main(string[] args)
		{
			var s = new Solution();
			var r = s.FindMinMoves(new int[] { 1,0,5});
		}

		public class Solution
		{
			public int FindMinMoves(int[] machines)
			{
				var total = 0;
				foreach (var i in machines) total += i;
				if (total % machines.Length != 0) return -1;
				int avg = total / machines.Length, cnt = 0, max = 0;
				foreach (int load in machines)
				{
					cnt += load - avg; //load-avg is "gain/lose"
					max = Math.Max(Math.Max(max, Math.Abs(cnt)), load - avg);
				}
				return max;
			}
		}
	}
}
