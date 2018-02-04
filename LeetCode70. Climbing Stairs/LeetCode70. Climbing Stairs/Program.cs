using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode70.Climbing_Stairs
{
	//https://leetcode.com/problems/climbing-stairs/description/
	class Program
	{
		static void Main(string[] args)
		{
		}

		public class Solution
		{
			public int ClimbStairs(int n)
			{
				if (n == 0) return 0;
				if (n == 1) return 1;
				if (n == 2) return 2;
				var s = new int[] { 1, 2 };
				var i = 3;
				while (i <= n)
				{
					var t = s[0] + s[1];
					s[0] = s[1];
					s[1] = t;
					++i;
				}
				return s[1];
			}
		}
	}
}
