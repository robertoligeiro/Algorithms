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
			var r = s.LastRemaining(24);
		}

		public class Solution
		{
			public int LastRemaining(int n)
			{
				var left = true;
				var head = 1;
				var step = 1;
				while (n > 1)
				{
					if (left || n % 2 == 1)
					{
						head += step;
					}
					left = !left;
					n /= 2;
					step *= 2;
				}
				return head;
			}
		}
		public class SolutionOld
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
