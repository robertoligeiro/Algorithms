using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode69.Sqrt_x_
{
	//https://leetcode.com/problems/sqrtx/description/
	class Program
	{
		static void Main(string[] args)
		{
			var s = new Solution();
			//var r = s.MySqrt(2147395599);
			var r = s.MySqrt(1);
		}

		public class Solution
		{
			public int MySqrt(int x)
			{
				if (x == 1) return 1;
				long l = 1;
				long r = x/2;
				while (l <= r)
				{
					long mid = l + (r - l) / 2;
					long sqr = mid * mid;
					if (sqr == x) return (int)mid;
					if (sqr < x) l = mid + 1;
					else r = mid - 1;
				}
				return (int)r;
			}
		}
	}
}
