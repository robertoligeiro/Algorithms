using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode402.Remove_K_Digits
{
	class Program
	{
		static void Main(string[] args)
		{
			var s = new Solution();
			var r = s.RemoveKdigits("112", 1);
		}

		public class Solution
		{
			public string RemoveKdigits(string num, int k)
			{
				if (num.Length == k) return string.Empty;
				var stk = new Stack<char>();
				foreach (var c in num)
				{
					while (stk.Count > 0 && k > 0 && stk.Peek() > c)
					{
						stk.Pop();
						--k;
					}
					stk.Push(c);
				}
				//corner case: 111
				while (k > 0)
				{
					stk.Pop();
					--k;
				}
				var sb = new StringBuilder();
				var allZero = true;
				while (stk.Count > 0)
				{
					var c = stk.Pop();
					sb.Append(c);
					if (c != '0') allZero = false; 
				}
				var resp = sb.ToString();
				resp = new string(resp.Reverse().ToArray());
				if (allZero) return "0";
				return resp.TrimStart('0');
			}
		}
	}
}
