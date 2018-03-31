using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode762.PrimeNumSetBitsinBinRep
{
	class Program
	{
		//https://leetcode.com/problems/prime-number-of-set-bits-in-binary-representation/description/
		static void Main(string[] args)
		{
		}
		public class Solution
		{
			public int CountPrimeSetBits(int L, int R)
			{
				var resp = 0;
				for (int i = L; i <= R; ++i)
				{
					if (IsSmallPrime(CountBits(i))) resp++;
				}
				return resp;
			}

			private int CountBits(int n)
			{
				var resp = 0;
				while (n > 0)
				{
					if ((n & 1) == 1) resp++;
					n >>= 1;
				}
				return resp;
			}
			private bool IsSmallPrime(int x)
			{
				return (x == 2 || x == 3 || x == 5 || x == 7 ||
						x == 11 || x == 13 || x == 17 || x == 19);
			}
		}
	}
}
