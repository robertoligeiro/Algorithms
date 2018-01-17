using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode8.String_to_Integer__atoi_
{
	class Program
	{
		//https://leetcode.com/problems/string-to-integer-atoi/
		static void Main(string[] args)
		{
			var s = new Solution();
			var r = s.MyAtoi("-2147483649");
			r = s.MyAtoi("-123");
			r = s.MyAtoi("123$45");
		}
		public class Solution
		{
			public int MyAtoi(string str)
			{
				str = CleanString(str);
				if (str == null) return 0;
				var resp = 0;
				var i = 0;
				if (str[0] == '-' || str[0] == '+') ++i;
				for (; i < str.Length; ++i)
				{
					if (resp > int.MaxValue / 10 || (resp == int.MaxValue / 10 && str[i] - '0' > 7))
					{
						if (str[0] == '-') return int.MinValue;
						else return int.MaxValue;
					}

					resp = resp * 10 + str[i] - '0';
				}
				if (str[0] == '-') return -resp;
				return resp;
			}

			private string CleanString(string str)
			{
				if (string.IsNullOrWhiteSpace(str)) return null;
				str = str.Trim();
				var sb = new StringBuilder();
				int i = 0;
				if (str[0] == '-' || str[0] == '+') { sb.Append(str[0]); ++i; }
				for (; i < str.Length; ++i)
				{
					if (char.IsDigit(str[i])) sb.Append(str[i]);
					else break;
				}

				var resp = sb.ToString();
				if (string.IsNullOrWhiteSpace(resp) || (resp.Length == 1 && (resp[0] == '-' || str[0] == '+'))) return null;
				return resp;
			}
		}
	}
}
