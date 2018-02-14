using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode168.Excel_Sheet_Column_Title
{
	class Program
	{
		//https://leetcode.com/problems/excel-sheet-column-title/description/
		static void Main(string[] args)
		{
			var s = new Solution();
			var r = s.ConvertToTitle(52);
		}
		public class Solution
		{
			public string ConvertToTitle(int n)
			{
				var resp = new StringBuilder();
				while (n > 0)
				{
					n--;
					resp.Insert(0,(char)('A' + n % 26));
					n /= 26;
				}
				return resp.ToString();
			}
		}
	}
}
