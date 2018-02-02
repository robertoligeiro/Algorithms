using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode10.Regular_Expression_Matching
{
	class Program
	{
		//https://leetcode.com/problems/regular-expression-matching/description/
		static void Main(string[] args)
		{
			var s = new Solution();
			//var r = s.IsMatch("aab", "c*a*b");
			var r = s.IsMatch("aa", "a*");
		}

		public class Solution
		{
			public bool IsMatch(string s, string p)
			{
				if (string.IsNullOrWhiteSpace(p)) return string.IsNullOrWhiteSpace(s);

				var firstMatch = !string.IsNullOrEmpty(s) && (s[0] == p[0] || p[0] == '.');

				if (p.Length >= 2 && p[1] == '*')
				{
					return IsMatch(s, p.Substring(2)) || (firstMatch && IsMatch(s.Substring(1), p));
				}
				else 
				{
					return firstMatch && IsMatch(s.Substring(1), p.Substring(1));
				}
			}
		}
	}
}
