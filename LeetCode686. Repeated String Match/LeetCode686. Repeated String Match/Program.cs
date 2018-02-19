using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode686.Repeated_String_Match
{
	class Program
	{
		//https://leetcode.com/problems/repeated-string-match/description/
		static void Main(string[] args)
		{
		}
		public class Solution
		{
			public int RepeatedStringMatch(string A, string B)
			{
				var sb = new StringBuilder(;
				int resp = 0;
				for (; sb.Length < B.Length; ++resp)
				{
					sb.Append(A);
				}
				if (sb.ToString().IndexOf(B) >= 0) return resp;
				sb.Append(A);
				if (sb.ToString().IndexOf(B) >= 0) return ++resp;
				return -1;
			}
		}
	}
}
