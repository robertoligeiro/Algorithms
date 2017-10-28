using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode241.DifferentWaystoAddParentheses
{
	class Program
	{
		//https://leetcode.com/problems/different-ways-to-add-parentheses/description/
		static void Main(string[] args)
		{
			var s = new Solution();
			var r = s.DiffWaysToCompute("2*3-4*5");
		}
		public class Solution
		{
			public IList<int> DiffWaysToCompute(string input)
			{
				var ret = new List<int>();
				for (int i = 0; i < input.Length; ++i)
				{
					if (input[i] == '+' || input[i] == '-' || input[i] == '*')
					{
						var part1 = DiffWaysToCompute(input.Substring(0, i));
						var part2 = DiffWaysToCompute(input.Substring(i + 1, input.Length - i - 1));
						foreach (var p1 in part1)
						{
							foreach (var p2 in part2)
							{
								if (input[i] == '+') ret.Add(p1 + p2);
								if (input[i] == '-') ret.Add(p1 - p2);
								if (input[i] == '*') ret.Add(p1 * p2);
							}
						} 
					}
				}
				if (ret.Count == 0) ret.Add(int.Parse(input));
				return ret;
			}
		}
	}
}
