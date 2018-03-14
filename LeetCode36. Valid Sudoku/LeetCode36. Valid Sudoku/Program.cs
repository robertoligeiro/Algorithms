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
				for (int row = 0; row < 9; row++)
				{
					var rowHash = new HashSet<char>();
					var colHash = new HashSet<char>();
					var regHash = new HashSet<char>();
					for (int col = 0; col < 9; col++)
					{
						//get row
						if (board[row, col] != '.' && !rowHash.Add(board[row, col])) return false;

						//get col
						if (board[col, row] != '.' && !colHash.Add(board[col, row])) return false;

						//get reg
						var rowIndex = 3 * (row / 3);
						var colIndex = 3 * (row % 3);
						var rowReg = rowIndex + (col / 3);
						var colReg = colIndex + (col % 3);
						if (board[rowReg, colReg] != '.' && !regHash.Add(board[rowReg, colReg])) return false;
					}
				}
				return true;
			}
		}
	}
}
