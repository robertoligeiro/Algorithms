using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode62.Unique_Paths_DPversion
{
	class Program
	{
		//https://leetcode.com/problems/unique-paths/description/
		static void Main(string[] args)
		{
			var solution = new Solution();
			var r = solution.UniquePaths(3, 3);
		}
		class Solution
		{
			public int UniquePaths(int m, int n)
			{
				var dp = new int[m, n];
				for (int i = 0; i < n; ++i) dp[0, i] = 1;
				for (int i = 0; i < m; ++i) dp[i,0] = 1;
				for (int row = 1; row < m; ++row)
				{
					for (int col = 1; col < n; ++col)
					{
						dp[row, col] = dp[row - 1, col] + dp[row, col - 1];
					}
				}
				return dp[m - 1, n - 1];
			}
		}
	}
}
