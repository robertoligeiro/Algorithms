using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode7.Reverse_Integer
{
	class Program
	{
		static void Main(string[] args)
		{
			var s = new Solution();
			var r = s.Reverse(-11123);
		}
		public class Solution
		{
			public int Reverse(int x)
			{
				var isNeg = false;
				if (x < 0) { x = -x; isNeg = true; }
				var resp = 0;
				while (x > 0)
				{
					var v = x % 10;
					int newResp = resp * 10 + v;
					if ((newResp - v) / 10 != resp)
					{ return 0; }
					resp = newResp;
					x /= 10;
				}
				if (isNeg) return -resp;
				return resp;
			}
		}
	}
}
