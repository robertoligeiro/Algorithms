using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode43.Multiply_Strings
{
	class Program
	{
		//https://leetcode.com/problems/multiply-strings/description/
		static void Main(string[] args)
		{
			var s = new Solution();
			//var r = s.Multiply("102", "24");
			var r = s.Multiply("123", "456");
			}
		public class Solution
		{
			public string Multiply(string num1, string num2)
			{
				var resp = new int[num1.Length + num2.Length];
				for (int i = num1.Length - 1; i >= 0; --i)
				{
					for (int j = num2.Length - 1; j >= 0; --j)
					{
						var mult = (num1[i] - '0') * (num2[j] - '0');
						var p1 = i + j;
						var p2 = i + j + 1;
						var sum = mult + resp[p2];
						resp[p1] += sum / 10;
						resp[p2] = sum % 10;
					}
				}

				var sb = new StringBuilder();
				foreach (var i in resp)
				{
					if (!(i == 0 && sb.Length == 0)) //discard leading zeros
					{
						sb.Append(i);
					}
				}
				return sb.Length > 0 ? new string(sb.ToString().ToArray()) : "0";
			}
		}
	}
}
