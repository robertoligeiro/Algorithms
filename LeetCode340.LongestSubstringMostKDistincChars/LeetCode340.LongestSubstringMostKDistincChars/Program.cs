using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode340.LongestSubstringMostKDistincChars
{
	class Program
	{
		static void Main(string[] args)
		{
			var s = new Solution();
			var r = s.LengthOfLongestSubstringKDistinct("eceba",2);
		}

		public class Solution
		{
			//https://leetcode.com/problems/longest-substring-with-at-most-k-distinct-characters/description/
			public int LengthOfLongestSubstringKDistinct(string s, int k)
			{
				var charsFound = new char[256];
				var l = 0;
				var r = 0;
				var max = 0;
				var distinctChars = 0;
				while (r < s.Length)
				{
					if (charsFound[s[r++]]++ == 0) distinctChars++;
					if (distinctChars > k)
					{
						while (l < r)
						{
							if (--charsFound[s[l++]] == 0)
							{
								distinctChars--;
								break;
							}
						}
					}
					max = Math.Max(max, r - l);
				}
				return max;
			}
		}
	}
}
