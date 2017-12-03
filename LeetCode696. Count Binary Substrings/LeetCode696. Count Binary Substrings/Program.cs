using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode696.Count_Binary_Substrings
{
	class Program
	{
		//https://leetcode.com/problems/count-binary-substrings/description/
		static void Main(string[] args)
		{
			var s = new Solution();
			var r = s.CountBinarySubstrings("00110011");
		}
		public class Solution
		{
			public int CountBinarySubstrings(string s)
			{
				if (string.IsNullOrEmpty(s)) return 0;
				var groupBlocks = new List<int>();
				var prev = s[0];
				var block = 1;
				for (int i = 1; i < s.Length; ++i)
				{
					if (s[i] == prev) block++;
					else
					{
						groupBlocks.Add(block);
						prev = s[i];
						block = 1;
					}
				}
				groupBlocks.Add(block);

				if (groupBlocks.Count == 1) return 0;
				var resp = 0;
				for (int i = 1; i < groupBlocks.Count; ++i)
				{
					resp += Math.Min(groupBlocks[i], groupBlocks[i - 1]);
				}
				return resp;
			}
		}
	}
}
