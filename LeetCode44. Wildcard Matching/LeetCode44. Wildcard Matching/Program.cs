using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode44.Wildcard_Matching
{
	class Program
	{
		//https://leetcode.com/problems/wildcard-matching/description/
		static void Main(string[] args)
		{
			var s = new Solution();
			var r = s.IsMatch("ho", "**ho");
		}
		public class Solution
		{
			public bool IsMatch(string s, string p)
			{
				if (string.IsNullOrEmpty(s) || string.IsNullOrEmpty(p))
				{
					return string.IsNullOrEmpty(s) && (string.IsNullOrEmpty(p) || p=="*");
				}
				var dpTable = new bool[s.Length + 1, p.Length + 1];
				dpTable[0,0] = true;

				//if patern starts with '*', set second  (and so on) col to true
				if (p[0] == '*')
				{
					dpTable[0, 1] = true;
					int i = 1;
					while(i<p.Length && p[i]=='*')
					{
						i++;
						dpTable[0, i] = true;
					}
				}

				for (int row = 1; row < dpTable.GetLength(0); ++row)
				{
					for (int col = 1; col < dpTable.GetLength(1); ++col)
					{
						//3 cases to check
						//1. If s and p match, or p == ?, get diagonal, table[r-1,c-1]
						if (s[row - 1] == p[col - 1] || p[col - 1] == '?')
						{
							dpTable[row, col] = dpTable[row - 1, col - 1];
						}
						//2. If pattern is == '*', get prev row OR prev col.
						else if (p[col - 1] == '*')
						{
							dpTable[row, col] = dpTable[row - 1, col] || dpTable[row, col - 1];
						}
						//3. All other cases, get false
						else
						{
							dpTable[row, col] = false;
						}
					}
				}
				return dpTable[dpTable.GetLength(0) - 1, dpTable.GetLength(1) - 1];
			}
		}
	}
}
