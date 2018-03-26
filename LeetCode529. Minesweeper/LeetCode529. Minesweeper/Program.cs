using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode529.Minesweeper
{
	class Program
	{
		//https://leetcode.com/problems/minesweeper/description/
		static void Main(string[] args)
		{
			var b = new char[,]
				{
					{ 'E','E','E','E','E'},
					{ 'E','E','M','E','E'},
					{ 'E','E','E','E','E'},
					{ 'E','E','E','E','E'},
				};

			var s = new Solution();
			var r = s.UpdateBoard(b, new int[] { 3, 0 });
		}

		public class Solution
		{
			public char[,] UpdateBoard(char[,] board, int[] click)
			{
				if (board[click[0], click[1]] == 'M')
				{
					board[click[0], click[1]] = 'X';
					return board;
				}

				var adj = new List<Tuple<int, int>>();
				var mines = GetAdjAndCountMines(click[0], click[1], board, adj);
				if (mines > 0)
				{
					board[click[0], click[1]] = mines.ToString()[0];
					return board;
				}
				board[click[0], click[1]] = 'B';
				var q = new Queue<Tuple<int, int>>(adj);
				var v = new HashSet<Tuple<int, int>>() { new Tuple<int, int>(click[0], click[1])};
				while (q.Count > 0)
				{
					var curr = q.Dequeue();
					if (!v.Add(curr) || board[curr.Item1, curr.Item2] == 'M') continue;
					adj.Clear();
					mines = GetAdjAndCountMines(curr.Item1, curr.Item2, board, adj);
					if (mines == 0)
					{
						board[curr.Item1, curr.Item2] = 'B';
						foreach (var c in adj) q.Enqueue(c);
					}
					else
					{
						board[curr.Item1, curr.Item2] = mines.ToString()[0];
					}
				}
				return board;
			}

			private int GetAdjAndCountMines(int row, int col, char[,] board, List<Tuple<int, int>> adj)
			{
				var mines = 0;
				for (int i = -1; i <= 1; ++i)
				{
					for (int j = -1; j <= 1; ++j)
					{
						var r = row + i;
						var c = col + j;
						if (r == row && c == col) continue;

						if (r >= 0 && r < board.GetLength(0) && c >= 0 && c < board.GetLength(1))
						{
							if (board[r, c] == 'M') mines++;
							adj.Add(new Tuple<int, int>(r, c));
						}
					}
				}
				return mines;
			}
		}
	}
}
