using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode161.One_Edit_Distance
{
	//https://leetcode.com/problems/one-edit-distance/description/
	class Program
	{
		static void Main(string[] args)
		{
			var s = new Solution();
			//var r = s.IsOneEditDistance("abcd", "abc");
			//var r = s.IsOneEditDistance("ab", "ba");
			//var r = s.IsOneEditDistance("c", "c");
			var r = s.IsOneEditDistance("acd", "ab");
		}
		public class Solution
		{
			public bool IsOneEditDistance(string s, string t)
			{
				if (Math.Abs(s.Length - t.Length) > 1) return false;
				if (s.Length == t.Length)
				{
					return CheckSameSize(s,t);
				}
				if (s.Length > t.Length)
				{
					return CheckDiffSize(s, t);
				}
				return CheckDiffSize(t, s);
			}

			private bool CheckSameSize(string s, string t)
			{
				var edit = 0;
				for (int i = 0; i < s.Length; ++i)
				{
					if (s[i] != t[i] && ++edit > 1) return false;
				}
				return edit == 1;
			}

			private bool CheckDiffSize(string bigger, string smaller)
			{
				for (int i = 0; i < smaller.Length; ++i)
				{
					if (smaller[i] != bigger[i])
					{
						return smaller.Substring(i, smaller.Length - i).Equals(bigger.Substring(i + 1, bigger.Length - i - 1));
					}
				}
				return true;
			}
		}
	}
}
