using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode130.Surrounded_Regions
{
	class Program
	{
		// Solution using BSF.
		// Easier way could be:
		// from here: https://leetcode.com/problems/surrounded-regions/discuss/
		//First, check the four border of the matrix.If there is a element is
		//'O', alter it and all its neighbor 'O' elements to '1'.
		//Then ,alter all the 'O' to 'X'
		//At last, alter all the '1' to 'O'
		static void Main(string[] args)
		{
			var board = new char[,] {
				{ 'X', 'X', 'X', 'X'},
				{ 'X', 'O', 'O', 'X'},
				{ 'X', 'X', 'O', 'X'},
				{ 'X', 'O', 'X', 'X'}
			};
			//var board = new char[,] {
			//	{ 'X', 'X', 'X'},
			//	{ 'X', 'O', 'X'},
			//	{ 'X', 'X', 'X'}
			//};
			//var board = new char[,] {
			//	{'X','X','X','X','X','X','X','X','X','X','X','X','X','X','X','X','X','X','X','X'},
			//	{ 'X','X','X','X','X','X','X','X','X','O','O','O','X','X','X','X','X','X','X','X'},
			//	{ 'X','X','X','X','X','O','O','O','X','O','X','O','X','X','X','X','X','X','X','X'},
			//	{ 'X','X','X','X','X','O','X','O','X','O','X','O','O','O','X','X','X','X','X','X'},
			//	{ 'X','X','X','X','X','O','X','O','O','O','X','X','X','X','X','X','X','X','X','X'},
			//	{ 'X','X','X','X','X','O','X','X','X','X','X','X','X','X','X','X','X','X','X','X'}
			//};
			var s = new Solution();
			s.Solve(board);
		}
		public class Solution
		{
			public void Solve(char[,] board)
			{
				var maxRow = board.GetLength(0)-1;
				var maxCol = board.GetLength(1)-1;

				//turn limits to 1 using dfs
				for (var r = 0; r < board.GetLength(0); ++r)
				{
					if (board[r, 0] == 'O')
					{
						CheckAndTurn(board, r, 0);
					}
					if (maxCol > 1 && board[r, maxCol] == 'O')
					{
						CheckAndTurn(board, r, maxCol);
					}
				}
				for (var c = 0; c < board.GetLength(1); ++c)
				{
					if (board[0, c] == 'O')
					{
						CheckAndTurn(board, 0, c);
					}
					if (maxRow > 1 && board[maxRow, c] == 'O')
					{
						CheckAndTurn(board, maxRow, c);
					}
				}

				for (int row = 1; row < maxRow; ++row)
				{
					for (int col = 1; col < maxCol; ++col)
					{
						if (board[row, col] == 'O') board[row, col] = 'X';
					}
				}
				for (int row = 0; row <= maxRow; ++row)
				{
					for (int col = 0; col <= maxCol; ++col)
					{
						if (board[row, col] == '1') board[row, col] = 'O';
					}
				}
			}
			private void CheckAndTurn(char[,] board, int row, int col)
			{
				if (row < 0 || col < 0 || row >= board.GetLength(0) || col >= board.GetLength(1)) return;
				if (board[row, col] == 'O')
				{
					board[row, col] = '1';
					CheckAndTurn(board, row + 1, col);
					CheckAndTurn(board, row - 1, col);
					CheckAndTurn(board, row, col + 1);
					CheckAndTurn(board, row, col - 1);
				}
			}
		}
	}
}
