using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode390.Elimination_Game
{
	class Program
	{
		static void Main(string[] args)
		{
			var s = new Solution();
			var r = s.LastRemaining(9);
		}

		public class Solution
		{
			public int LastRemaining(int n)
			{
				return LeftToRight(n);
			}

			private int LeftToRight(int n)
			{
				if (n <= 2) return n;
				return 2 * RightToLeft(n / 2);
			}

			private int RightToLeft(int n)
			{
				if (n <= 2) return 1;
				if (n % 2 == 1) return 2 * LeftToRight(n / 2);
				return 2 * LeftToRight(n / 2) - 1;
			}
		}
	}
}
