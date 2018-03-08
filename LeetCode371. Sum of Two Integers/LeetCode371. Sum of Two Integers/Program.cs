using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode371.Sum_of_Two_Integers
{
	class Program
	{
		//https://leetcode.com/problems/sum-of-two-integers/description/
		static void Main(string[] args)
		{
			var s = new Solution();
			var r = s.GetSum(1, 2);
		}
		public class Solution
		{
			public int GetSum(int a, int b)
			{
				while (b > 0)
				{
					var prevA = a;
					a = a ^ b;
					b = (prevA & b) << 1;
				}
				return a;
			}
		}
	}
}
