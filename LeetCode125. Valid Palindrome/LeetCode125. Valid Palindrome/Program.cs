using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode125.Valid_Palindrome
{
	class Program
	{
		//https://leetcode.com/problems/valid-palindrome/description/
		static void Main(string[] args)
		{
		}

		public class Solution
		{
			public bool IsPalindrome(string s)
			{
				if (string.IsNullOrEmpty(s)) return true;
				var l = 0;
				var r = s.Length - 1;
				s = s.ToLower();
				while (l < r)
				{
					while (l < r && !char.IsLetterOrDigit(s[l])) l++;
					while (r > l && !char.IsLetterOrDigit(s[r])) r--;
					if (s[l] != s[r]) return false;
					l++;
					r--;
				}
				return true;
			}
		}
	}
}
