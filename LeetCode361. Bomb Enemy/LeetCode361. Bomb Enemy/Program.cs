using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode361.Bomb_Enemy
{
	//https://leetcode.com/problems/bomb-enemy/description/
	class Program
	{
		static void Main(string[] args)
		{
			var g = new char[,] {
				{ '0', 'E', '0', '0'},
				{ 'E', '0', 'W', 'E'},
				{ '0', 'E', '0', '0'}
			};
			//var g = new char[,] {
			//	{ '0', 'E'},
			//};
			//var g = new char[,] {
			//	{ 'W', 'E', 'E', 'E', 'E', '0'},
			//	{ 'E', 'E', 'E', 'E', 'E', 'W'},
			//};

			var s = new Solution();
			var r = s.MaxKilledEnemies(g);
		}
		public class Solution
		{
			public class Spot
			{
				public int left;
				public int top;
				public int right;
				public int bottom;
			}
			public int MaxKilledEnemies(char[,] grid)
			{
				var maxCol = grid.GetLength(1) - 1;
				var maxRow = grid.GetLength(0) - 1;
				var maxEnemies = 0;
				var counters = new Spot[grid.GetLength(0), grid.GetLength(1)];
				for (int row = 0; row < grid.GetLength(0); ++row)
				{
					for (int col = 0; col < grid.GetLength(1); ++col)
					{
						counters[row, col] = new Spot();
						if (grid[row, col] == 'W') continue;
						var enemy = grid[row, col] == 'E' ? 1 : 0;
						counters[row, col].top = (row == 0 ? 0 : counters[row - 1, col].top) + enemy;
						counters[row, col].left = (col == 0 ? 0 : counters[row, col-1].left) + enemy;
					}
				}
				for (int row = maxRow; row >=0; --row)
				{
					for (int col = maxCol; col >=0; --col)
					{
						if (grid[row, col] == 'W') continue;
						var enemy = grid[row, col] == 'E' ? 1 : 0;
						counters[row, col].bottom = (row == maxRow ? 0 : counters[row + 1, col].bottom) + enemy;
						counters[row, col].right = (col == maxCol ? 0 : counters[row, col + 1].right) + enemy;
						if(grid[row,col]=='0')
							maxEnemies = Math.Max(maxEnemies, counters[row, col].top + counters[row, col].left + counters[row, col].right + counters[row, col].bottom);
					}
				}
				return maxEnemies;
			}
		}
	}
}
