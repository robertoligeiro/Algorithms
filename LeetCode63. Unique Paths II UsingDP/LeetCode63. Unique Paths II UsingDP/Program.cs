using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode63.Unique_Paths_II_UsingDP
{
	class Program
	{
		//https://leetcode.com/problems/unique-paths-ii/discuss/
		static void Main(string[] args)
		{
		}
		class Solution
		{
			public int UniquePaths(int[,] obstacleGrid)
			{
				var m = obstacleGrid.GetLength(0);
				var n = obstacleGrid.GetLength(1);
				var dp = new int[m, n];
				for (int i = 0; i < n; ++i) if(obstacleGrid[0,i] == 0) dp[0, i] = 1;
				for (int i = 0; i < m; ++i) if (obstacleGrid[i,0] == 0) dp[i, 0] = 1;
				for (int row = 1; row < m; ++row)
				{
					for (int col = 1; col < n; ++col)
					{
						if (obstacleGrid[row,col] == 0)
							dp[row, col] = dp[row - 1, col] + dp[row, col - 1];
					}
				}
				return dp[m - 1, n - 1];
			}
		}
	}
}
