using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode639.Decode_Ways_II
{
	class Program
	{
		static void Main(string[] args)
		{
			var s = new Solution();
			var r = s.NumDecodings("1*9");
		}
		public class Solution
		{
			public int NumDecodings(string s)
			{
				if (string.IsNullOrEmpty(s) || s[0] == '0') return 0;
				if (s.Length == 1) return s == "*" ? 9 : 1;
				var resp = new int[s.Length + 1];
				resp[0] = 1;
				resp[1] = s[1] == '0' ? 0 : 1;
				for (int i = 2; i <= s.Length; ++i)
				{
					if (s[i - 1] == '*' || s[i - 2] == '*')
					{
						if(s[i - 1] == '*') resp[i] = (resp[i - 1] + resp[i - 2]) * 9;
						if (s[i - 2] == '*')
						{
							if (s[i - 1] - '0' <= 6) resp[i] = resp[i - 1] * 4;
							else resp[i] = resp[i - 1] * 2;
						}
					}
					else
					{
						var second = int.Parse(s.Substring(i - 2, 2));
						if (s[i - 1] != '0')
						{
							resp[i] += resp[i - 1];
						}
						if (second >= 10 && second <= 26)
						{
							resp[i] += resp[i - 2];
						}
					}
				}
				return resp[s.Length] % 1000000007;
			}
		}
	}
}
