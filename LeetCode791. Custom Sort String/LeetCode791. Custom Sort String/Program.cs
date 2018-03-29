using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode791.Custom_Sort_String
{
	class Program
	{
		//https://leetcode.com/problems/custom-sort-string/description/
		static void Main(string[] args)
		{
			var s = new Solution();
			var r = s.CustomSortString("cba", "abcd");
		}

		public class Solution
		{
			public string CustomSortString(string S, string T)
			{
				var mT = new Dictionary<char, int>();
				foreach (var c in T)
				{
					var count = 0;
					if (mT.TryGetValue(c, out count))
					{
						mT[c] = ++count;
					}
					else
					{
						mT.Add(c, 1);
					}
				}

				var sb = new StringBuilder();
				foreach (var c in S)
				{
					var count = 0;
					if (mT.TryGetValue(c, out count))
					{
						sb.Append(new string(Enumerable.Repeat(c, count).ToArray()));
						mT[c] = -1;
					}
				}
				foreach (var c in T)
				{
					if (mT[c] > 0) sb.Append(c);
				}
				return sb.ToString();
			}
		}
	}
}
