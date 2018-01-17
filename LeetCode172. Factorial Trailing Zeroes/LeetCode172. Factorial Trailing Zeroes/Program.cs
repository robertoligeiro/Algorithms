using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode172.Factorial_Trailing_Zeroes
{
	class Program
	{
		static void Main(string[] args)
		{
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
