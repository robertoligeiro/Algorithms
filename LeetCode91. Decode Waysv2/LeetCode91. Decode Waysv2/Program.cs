using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode91.Decode_Waysv2
{
	class Program
	{
		//https://leetcode.com/problems/decode-ways/description/
		static void Main(string[] args)
		{
			var s = new Solution();
			var r = s.NumDecodings("123");
		}
		public class Solution
		{
			public int NumDecodings(string s)
			{
				if (string.IsNullOrEmpty(s) || s[0] == '0') return 0;
				if (s.Length == 1) return 1;
				var resp = new int[s.Length + 1];
				resp[0] = 1;
				resp[1] = s[1] == '0' ? 0 : 1;
				for (int i = 2; i <= s.Length; ++i)
				{
					var first = int.Parse(s.Substring(i - 1, 1));
					var second = int.Parse(s.Substring(i - 2, 2));
					if (first >= 1 && first <= 9)
					{
						resp[i] += resp[i - 1];
					}
					if (second >= 10 && second <= 26)
					{
						resp[i] += resp[i - 2];
					}
				}
				return resp[s.Length];
			}
		}
	}
}
