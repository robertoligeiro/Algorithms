using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StringLongestCommonSubsequence
{
	class Program
	{
		static void Main(string[] args)
		{
			var r = LongestCommonSubsequence("sea", "eat");
		}

		public static int LongestCommonSubsequence(string a, string b)
		{
			return LongestCommonSubsequence(a, b, a.Length, b.Length);
		}
		public static int LongestCommonSubsequence(string a, string b, int sizeA, int sizeB)
		{
			if (sizeA == 0 || sizeB == 0) return 0;

			if (a[sizeA-1] == b[sizeB-1])
			{
				return LongestCommonSubsequence(a, b, sizeA - 1, sizeB - 1) + 1;
			}
			return Math.Max(LongestCommonSubsequence(a,b, sizeA - 1, sizeB), LongestCommonSubsequence(a,b,sizeA, sizeB-1));
		}
	}
}
