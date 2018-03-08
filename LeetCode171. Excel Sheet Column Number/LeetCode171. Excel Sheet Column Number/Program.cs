using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode171.Excel_Sheet_Column_Number
{
	class Program
	{
		//https://leetcode.com/problems/excel-sheet-column-number/description/
		static void Main(string[] args)
		{
		}
		public class Solution
		{
			public int TitleToNumber(string s)
			{
				var resp = 0;
				for (var i = 0; i < s.Length; ++i)
				{
					resp = resp * 26 + (s[i] - 'A' + 1);
				}
				return resp;
			}
		}
	}
}
