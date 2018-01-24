using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode463.Island_Perimeter
{
	class Program
	{
		//https://leetcode.com/problems/island-perimeter/description/
		static void Main(string[] args)
		{
		}

		public class Solution
		{
			public int IslandPerimeter(int[,] grid)
			{
				var resp = 0;
				for (int row = 0; row < grid.GetLength(0); ++row)
				{
					for (int col = 0; col < grid.GetLength(1); ++col)
					{
						if (grid[row, col] == 1)
						{
							if (row == 0 || grid[row - 1, col] == 0) resp++;
							if (row == grid.GetLength(0) - 1 || grid[row + 1, col] == 0) resp++;
							if (col == 0 || grid[row, col - 1] == 0) resp++;
							if (col == grid.GetLength(1) - 1 || grid[row, col + 1] == 0) resp++;
						}
					}
				}
				return resp;
			}
		}
	}
}
