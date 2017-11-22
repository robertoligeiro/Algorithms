using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode420.Strong_Password_Checker
{
	class Program
	{
		//https://leetcode.com/problems/strong-password-checker/discuss/
		// only implement half of it, where pass < 20.
		static void Main(string[] args)
		{
			var s = new Solution();
			var r = s.StrongPasswordChecker("");
			r = s.StrongPasswordChecker("a");
			r = s.StrongPasswordChecker("aaaaa");
			r = s.StrongPasswordChecker("aaa111");
		}
		public class Solution
		{
			public int StrongPasswordChecker(string s)
			{
				if (string.IsNullOrEmpty(s)) return 6;
				if(s.Length <=20) return InsCheck(s);
				return -1;
			}

			private int InsCheck(string s)
			{
				var hasCaps = false;
				var hasLower = false;
				var hasDigit = false;
				var insCount = 0;
				var prev = s[0];
				var countRep = 1;
				var diff = s.Length < 6 ? 6 - s.Length : 0;
				var diffIns = diff;
				for (int i = 1; i < s.Length; ++i)
				{
					if (char.IsDigit(s[i])) hasDigit = true;
					if (char.IsLower(s[i])) hasLower = true;
					if (char.IsUpper(s[i])) hasCaps = true;
					if (s[i] == prev)
					{
						if (++countRep == 3)
						{
							insCount++;
							if(diffIns > 0)diffIns--;
							countRep = 0;
						}
					}
					else
					{
						countRep = 1;
					}
					prev = s[i];
				}

				var missing = 0;
				if (!hasCaps) missing++;
				if (!hasLower) missing++;
				if (!hasDigit) missing++;
				if (diff < missing) diff = missing;
				return Math.Max(insCount + diffIns, diff);
			}
		}
	}
}
