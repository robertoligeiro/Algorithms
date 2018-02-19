using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode246.Strobogrammatic_Number
{
	//https://leetcode.com/problems/strobogrammatic-number/description/
	class Program
	{
		static void Main(string[] args)
		{
		}

		public class Solution
		{
			public bool IsStrobogrammatic(string num)
			{
				var strobogrammaticNumbers = "00 11 69 88 96";

				for (int i = 0, j = num.Length - 1; i < j; i++, --j)
				{
					if (!strobogrammaticNumbers.Contains(num[i] + "" + num[j])) return false;
				}
				return true;
			}
		}
	}
}
