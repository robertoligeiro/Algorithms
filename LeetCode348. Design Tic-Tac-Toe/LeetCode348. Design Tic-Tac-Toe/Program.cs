using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode348.Design_Tic_Tac_Toe
{
	class Program
	{
		//https://leetcode.com/problems/design-tic-tac-toe/description/
		static void Main(string[] args)
		{
		}
		public class TicTacToe
		{
			public int[] _row;
			public int[] _col;
			public int diagonal;
			public int antiDiagonal;

			/** Initialize your data structure here. */
			public TicTacToe(int n)
			{
				_row = new int[n];
				_col = new int[n];
			}

			/** Player {player} makes a move at ({row}, {col}).
				@param row The row of the board.
				@param col The column of the board.
				@param player The player, can be either 1 or 2.
				@return The current winning condition, can be either:
						0: No one wins.
						1: Player 1 wins.
						2: Player 2 wins. */
			public int Move(int row, int col, int player)
			{
				var toSum = player == 1 ? 1 : -1;

				_row[row] += toSum;
				if (Math.Abs(_row[row]) == _row.Length) return player;

				_col[col] += toSum;
				if (Math.Abs(_col[col]) == _col.Length) return player;

				if (row == col)
				{
					diagonal += toSum;
					if (Math.Abs(diagonal) == _row.Length) return player;
				}

				if (col == _row.Length - row - 1)
				{
					antiDiagonal += toSum;
					if (Math.Abs(antiDiagonal) == _row.Length) return player;
				}

				return 0;
			}
		}
	}
}
