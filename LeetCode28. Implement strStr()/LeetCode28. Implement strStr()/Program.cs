using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode28.Implement_strStr__
{
	class Program
	{
		//https://leetcode.com/problems/implement-strstr/description/
		static void Main(string[] args)
		{
			var s = new Solution();
			var r = s.StrStr("hello", "ll");
		}

		public class Solution
		{
			public int StrStr(string haystack, string needle)
			{
				if (string.IsNullOrEmpty(needle)) return 0;
				if (string.IsNullOrEmpty(haystack) ||
					haystack.Length < needle.Length) return -1;

				var deck = new StringBuilder(haystack.Substring(0,needle.Length));
				if (deck.ToString() == needle) return 0;
				for (int i = needle.Length; i < haystack.Length; ++i)
				{
					deck.Remove(0, 1);
					deck.Append(haystack[i]);
					if (deck.ToString() == needle) return i - needle.Length + 1;
				}
				return -1;
			}
		}
	}
}
