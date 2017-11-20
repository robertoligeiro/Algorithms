using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode50.Pow_x__n_
{
	class Program
	{
		static void Main(string[] args)
		{
			var s = new Solution();
			var r = s.MyPow(2, -2147483648);
		}
		public class Solution
		{
			public double MyPow(double x, int n)
			{
				if (x == 1) return 1;
				if (x == -1 && n == int.MinValue) return 1;
				if (n == int.MinValue) return 0;
				var isNeg = false;
				if (n < 0)
				{
					isNeg = true;
					n = -n;
				}
				var ret = MyPowHelper(x, n);
				if (isNeg) return 1 / ret;
				return ret;
			}
			public double MyPowHelper(double x, int n)
			{
				if (n == 0) return 1;
				var ret = MyPow(x, n / 2);
				if (n % 2 == 0) return ret * ret;
				return x * ret * ret;
			}
		}
	}
}
