using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//https://leetcode.com/problems/is-subsequence/description/
namespace LeetCode392.Is_Subsequence
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
				var curr = 0;
				for (int i = 0; i < t.Length; ++i)
				{
					if (t[i] == s[curr]) curr++;
					if (curr == s.Length) return true;
				}
				return false;
			}
		}
	}
}
