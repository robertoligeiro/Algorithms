using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode38.Count_and_Say
{
	class Program
	{
		static void Main(string[] args)
		{
			var s = new Solution();
			var r = s.CountAndSay(4);
		}

		public class Solution
		{
			public string CountAndSay(int n)
			{
				if (n == 0) return string.Empty;
				var resp = "1";
				while (--n > 0)
				{
					resp = CountAndSay(resp);
				}
				return resp;
			}

			private string CountAndSay(string n)
			{
				var count = 1;
				var sb = new StringBuilder();
				for (int i = 1; i < n.Length; ++i)
				{
					if (n[i] == n[i - 1]) count++;
					else
					{
						sb.Append(count);
						sb.Append(n[i - 1]);
						count = 1;
					}
				}
				sb.Append(count);
				sb.Append(n[n.Length - 1]);
				return sb.ToString();
			}
		}
	}
}
