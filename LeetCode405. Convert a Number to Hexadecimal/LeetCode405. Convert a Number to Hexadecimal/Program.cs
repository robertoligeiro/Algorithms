using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode405.Convert_a_Number_to_Hexadecimal
{
	class Program
	{
		static void Main(string[] args)
		{
			var s = new Solution();
			var r = s.ToHex(-1);
		}

		public class Solution
		{
			public string ToHex(int num)
			{
				if (num == 0) return "0";
				var hex = "0123456789abcdef";
				long lnum = num;
				if (num < 0) lnum = long.MaxValue + num + 1;
				var resp = string.Empty;
				var count = 0;
				while (lnum > 0 && count++ < 8)
				{
					resp = hex[((int)lnum & 0xf)] + resp;
					lnum >>= 4;
				}
				return resp;
			}
		}
	}
}
