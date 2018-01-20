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
				var resp = new List<char>();
				var carry = 0;
				while (indexA >= 0 || indexB >= 0)
				{
					var v = carry;
					if (indexA >= 0)
					{
						v += a[indexA--] - '0';
					}
					if (indexB >= 0)
					{
						v += b[indexB--] - '0';
					}
					switch (v)
					{
						case 3:
							carry = 1;
							resp.Add('1');
							break;
						case 2:
							carry = 1;
							resp.Add('0');
							break;
						case 1:
							carry = 0;
							resp.Add('1');
							break;
						case 0:
							carry = 0;
							resp.Add('0');
							break;

					}
				}
				if (carry == 1) resp.Add('1');
				resp.Reverse();
				return new string(resp.ToArray());
			}
		}
	}
}
