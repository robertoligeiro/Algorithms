using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode63.Unique_Paths_II
{
	class Program
	{
		//https://leetcode.com/problems/unique-paths-ii/description/
		static void Main(string[] args)
		{
			var board = new int[,] { { 0,0,0}, { 0,1,0}, { 0,0,0} };
			var s = new Solution();
			var r = s.UniquePathsWithObstacles(board);
		}
		public class Solution
		{
			public int UniquePathsWithObstacles(int[,] obstacleGrid)
			{
				var memo = new int[obstacleGrid.GetLength(0), obstacleGrid.GetLength(1)];
				return UniquePathsWithObstacles(obstacleGrid, 0, 0, memo);
			}

			public int UniquePathsWithObstacles(int[,] obstacleGrid, int r, int c, int[,] memo)
			{
				if (r >= obstacleGrid.GetLength(0) || c >= obstacleGrid.GetLength(1) || obstacleGrid[r, c] == 1) return 0;
				if (r == obstacleGrid.GetLength(0) - 1 && c == obstacleGrid.GetLength(1) - 1) return 1;
				if (memo[r, c] != 0) return memo[r, c];
				var count = UniquePathsWithObstacles(obstacleGrid, r + 1, c, memo);
				count += UniquePathsWithObstacles(obstacleGrid, r, c + 1, memo);
				memo[r, c] = count;
				return count;
			}
		}
	}
}
