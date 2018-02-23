using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode682.Baseball_Game
{
	class Program
	{
		//https://leetcode.com/problems/baseball-game/description/
		static void Main(string[] args)
		{
			var s = new Solution();
			var r = s.CalPoints(new string[] { "5", "2", "C", "D", "+"});
		}
		public class Solution
		{
			public int CalPoints(string[] ops)
			{
				var acc = new List<int>();
				var sum = 0;
				foreach (var s in ops)
				{
					if (s == "+")
					{
						if (acc.Count >= 2)
						{
							sum += acc[acc.Count - 1] + acc[acc.Count - 2];
							acc.Add(acc[acc.Count - 1] + acc[acc.Count - 2]);
						}
					}
					else if (s == "D")
					{
						sum += acc.Last() * 2;
						acc.Add(acc.Last() * 2);
					}
					else if (s == "C")
					{
						if (acc.Count >= 1)
						{
							sum -= acc.Last();
							acc.RemoveAt(acc.Count - 1);
						}
					}
					else
					{
						sum += int.Parse(s);
						acc.Add(int.Parse(s));
					}
				}
				return sum;
			}
		}
	}
}
