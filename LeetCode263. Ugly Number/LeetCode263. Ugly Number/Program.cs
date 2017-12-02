using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode263.Ugly_Number
{
	//https://leetcode.com/submissions/detail/130455218/
	class Program
	{
		static void Main(string[] args)
		{
		}
		public class Solution
		{
			public bool IsUgly(int num)
			{
				if (num <= 0) return false;
				if (num == 1) return true;
				if (num % 2 == 0) return IsUgly(num / 2);
				if (num % 3 == 0) return IsUgly(num / 3);
				if (num % 5 == 0) return IsUgly(num / 5);
				return false;
			}
		}
	}
}
