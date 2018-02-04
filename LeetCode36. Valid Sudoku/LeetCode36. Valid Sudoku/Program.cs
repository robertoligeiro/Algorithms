using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode36.Valid_Sudoku
{
	//https://leetcode.com/problems/valid-sudoku/description/
	class Program
	{
		static void Main(string[] args)
		{
			var b = new char[,] {
			{'.','.','9','7','4','8','.','.','.'},
			{'7','.','.','.','.','.','.','.','.'},
			{'.','2','.','1','.','9','.','.','.'},
			{'.','.','7','.','.','.','2','4','.'},
			{'.','6','4','.','1','.','5','9','.'},
			{'.','9','8','.','.','.','3','.','.'},
			{'.','.','.','8','.','3','.','2','.'},
			{'.','.','.','.','.','.','.','.','6'},
			{'.','.','.','2','7','5','9','.','.'}
			};

			var s = new Solution();
			var  r = s.IsValidSudoku(b);
		}
		public class Solution
		{
			public bool IsValidSudoku(char[,] board)
			{
				for (int row = 0; row < board.GetLength(0); ++row)
				{
					for (int col = 0; col < board.GetLength(1); ++col)
					{
						if (board[row, col] != '.')
						{
							if (!CanAdd(board, row, col)) return false;
						}
					}
				}
				return true;
			}

			public bool CanAdd(char[,] b, int row, int col)
			{
				return CanAddRow(b,row) && CanAddCol(b, col) && CanAddSqr(b, row - row%3, col - col%3);
			}
			public bool CanAddRow(char[,] b, int row)
			{
				var h = new HashSet<char>();
				for (int col = 0; col < b.GetLength(1); ++col)
				{
					if (b[row, col] != '.' && !h.Add(b[row, col])) return false;
				}
				return true;
			}
			public bool CanAddCol(char[,] b, int col)
			{
				var h = new HashSet<char>();
				for (int row = 0; row < b.GetLength(1); ++row)
				{
					if (b[row, col] != '.' && !h.Add(b[row, col])) return false;
				}
				return true;
			}
			public bool CanAddSqr(char[,] b, int rowStart, int colStart)
			{
				var h = new HashSet<char>();
				for (int row = rowStart; row < rowStart + 3; row++)
				{
					for (int col = colStart; col < colStart + 3; col++)
					{
						if (b[row, col] != '.' && !h.Add(b[row, col])) return false;
					}
				}
				return true;
			}
		}
	}
}
