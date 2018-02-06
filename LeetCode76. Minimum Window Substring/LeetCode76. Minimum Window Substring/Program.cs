using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode76.Minimum_Window_Substring
{
	class Program
	{
		//https://leetcode.com/problems/minimum-window-substring/description/
		static void Main(string[] args)
		{
			var s = new Solution();
			var r = s.MinWindow("abcadajjjjae", "aa");
		}
		public class Solution
		{
			public string MinWindow(string s, string t)
			{
				if (string.IsNullOrEmpty(s) || string.IsNullOrEmpty(t)) return string.Empty;
				var map = new int[128];
				foreach (var c in t)
				{
					map[c]++;
				}
				var start = 0;
				var end = 0;
				var head = 0;
				var min = int.MaxValue;
				var tCount = t.Length;

				while (end < s.Length)
				{
					if (map[s[end++]]-- > 0) tCount--;
					while (tCount == 0)
					{
						if (end - start < min)
						{
							min = end - start;
							head = start;
						}
						if (map[s[start++]]++ == 0)
						{
							tCount++;
						}
					}
				}
				return min == int.MaxValue ? string.Empty : s.Substring(head, min);
			}
		}
	}
}
