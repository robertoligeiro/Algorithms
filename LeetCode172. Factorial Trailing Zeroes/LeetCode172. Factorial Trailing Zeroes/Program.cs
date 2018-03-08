using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode172.Factorial_Trailing_Zeroes
{
	class Program
	{
		//https://leetcode.com/problems/factorial-trailing-zeroes/description/
		static void Main(string[] args)
		{
			var s = new Solution();
			var r = s.TrailingZeroes(100);
		}

		public class Solution
		{
			public int TrailingZeroes(int n)
			{
				var resp = 0;
				while (n >= 5)
				{
					n /= 5;
					resp += n;
				}
				return resp;
			}
		}
	}
}
