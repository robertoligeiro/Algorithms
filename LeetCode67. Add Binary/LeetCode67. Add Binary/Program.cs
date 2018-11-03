using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode67.Add_Binary
{
	class Program
	{
		//https://leetcode.com/problems/add-binary/
		static void Main(string[] args)
		{
			var s = new Solution();
			var r = s.AddBinary("0", "1");
		}
		public class Solution
		{
			public string AddBinary(string a, string b)
			{
				var indexA = a.Length - 1;
				var indexB = b.Length - 1;
				var resp = new StringBuilder();
				var carry = 0;
				while (indexA >= 0 || indexB >= 0)
				{
					var sum = carry;
					if (indexA >= 0)
					{
						sum += a[indexA--] - '0';
					}
					if (indexB >= 0)
					{
						sum += b[indexB--] - '0';
					}

					var digit = sum % 2 == 0 ? '0' : '1';
					resp.Insert(0, digit);
					carry = sum >= 2 ? 1 : 0;
				}
				if (carry == 1) resp.Insert(0,'1');
				
				return resp.ToString();
			}
		}
	}
}
