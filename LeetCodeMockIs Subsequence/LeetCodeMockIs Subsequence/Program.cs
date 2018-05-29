using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCodeMockIs_Subsequence
{
	class Program
	{
		static void Main(string[] args)
		{
		}

		public class Solution
		{
			public bool IsSubsequence(string s, string t)
			{
				if (string.IsNullOrEmpty(s)) return true;
				if (string.IsNullOrEmpty(t)) return false;
				var count = 0;
				foreach (var c in t)
				{
					if (c == s[count])
					{
						count++;
						if (count == s.Length) return true;
					}
				}
				return false;
			}
		}
	}
}
