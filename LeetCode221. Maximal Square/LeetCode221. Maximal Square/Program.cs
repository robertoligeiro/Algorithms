using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode221.Maximal_Square
{
	//https://leetcode.com/problems/maximal-square/description/
	class Program
	{
		static void Main(string[] args)
		{
			var s = new Solution();
			var r = s.MaximalSquare(new char[,] { { '1','0','1','0','0'},
												  { '1','0','1','1','1'},
												  { '1','1','1','1','1'},
												  { '1','0','0','1','0'}});
			//var m = new char[,] {{'1','1','1','1','1','1','1','1'},
			//{'1','1','1','1','1','1','1','0'},
			//{'1','1','1','1','1','1','1','0'},
			//{'1','1','1','1','1','0','0','0'},
			//{'0','1','1','1','1','0','0','0'}};
			//var m = new char[,] { { '1', '1' }, { '1', '1' } };
			//var m = new char[,] {{'0','0','1','0'},
			//					 {'1','1','1','1'},
			//					 {'1','1','1','1'},
			//					 {'1','1','1','0'},
			//					 {'1','1','0','0'},
			//					 {'1','1','1','1'},
			//					 {'1','1','1','0'}};
			//var r = s.MaximalSquare(m);
		}
		public class Solution
		{
			public int MaximalSquare(char[,] matrix)
			{
				var max = 0;
				for (int row = 0; row < matrix.GetLength(0); ++row)
				{
					for (int col = 0; col < matrix.GetLength(1); ++col)
					{
						if (matrix[row, col] == '1')
						{
							max = Math.Max(max, MaximalSquare(matrix, row, col));
						}
					}
				}
				return max;
			}
			private int MaximalSquare(char[,] matrix, int row, int col)
			{
				var maxCol = col;
				for (; maxCol < matrix.GetLength(1); ++maxCol)
				{
					if (matrix[row, maxCol] == '0') break;
				}
				--maxCol;
				var maxX = (maxCol - col) + 1;
				if (maxX == 1) return 1;
				var maxRow = row + 1;
				var max = 0;
				var min = 0;
				var maxY = maxRow - row;
				for (; maxRow < matrix.GetLength(0); ++maxRow)
				{
					int j = col;
					for (; j <= maxCol; ++j)
					{
						if (matrix[maxRow, j] == '0')
						{
							if (j == col) break;
							maxCol = --j;
						}
						else
						{
							maxY = maxRow - row + 1;
							maxX = j - col + 1;
							min = Math.Min(maxX, maxY);
							max = Math.Max(max, min * min);
						}
					}
					if (j == col) break;
				}
				maxY = maxRow - row;
				maxX = (maxCol - col) + 1;
				min = Math.Min(maxX, maxY);
				return Math.Max(max, min * min); ;
			}
		}
	}
}
