using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode202.Happy_Number
{
	class Program
	{
		//https://leetcode.com/problems/happy-number/description/
		static void Main(string[] args)
		{
			var r = itoa(56142);
			var s = atoi(r);
		}

		public class Solution
		{
			public bool IsHappy(int n)
			{
				var visited = new HashSet<int>();
				while (n != 1 && visited.Add(n))
				{
					var num = n.ToString();
					n = 0;
					foreach (var c in num)
					{
						n += (int)Math.Pow(c - '0', 2);
					}
				}
				return n == 1;
			}
		}

		public static string itoa(int n)
		{
			var resp = new List<char>();
			while (n > 0)
			{
				resp.Add((char)(n % 10 + '0'));
				n /= 10;
			}
			resp.Reverse();
			return new string(resp.ToArray());
		}

		public static int atoi(string n)
		{
			var resp = 0;
			foreach (var c in n)
			{
				resp = (c - '0' + (resp * 10));
			}
			return resp;
		}
	}
}
