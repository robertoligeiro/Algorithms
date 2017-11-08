using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Uber1
{
	class Program
	{
		static void Main(string[] args)
		{
			var game = new MineGame(5, 6);
			Console.ReadKey();
			game.PrintBoard(true);
			Console.ReadKey();
			game.Open(1,1);
			Console.ReadKey();
			game.Open(2, 0);
			Console.ReadKey();
		}

		public class MineGame
		{
			private int[,] board;
			private bool[,] boardOutput;

			public MineGame(int size, int mineCount)
			{
				board = new int[size, size];
				boardOutput = new bool[size, size];
				var rand = new Random(1);
				while (mineCount > 0)
				{
					var r = rand.Next(0, size);
					var c = rand.Next(0, size);
					if (board[r, c] != -1)
					{
						board[r, c] = -1;
						mineCount--;
					}
				}

				SetNumbers(this.board);
				PrintBoard(false);
			}

			public void Open(int r, int c)
			{
				Console.WriteLine();
				if (this.board[r, c] == -1)
				{
					Console.WriteLine("GameOver");
					return;
				}


				var q = new Queue<Tuple<int, int>>();
				var visited = new HashSet<Tuple<int, int>>();
				this.boardOutput[r, c] = true;
				GetNeibouhs(r, c, q);

				while (q.Count > 0)
				{
					var curr = q.Dequeue();
					if (visited.Add(curr))
					{
						if (this.board[curr.Item1, curr.Item2] != -1)
						{
							this.boardOutput[curr.Item1, curr.Item2] = true;
						}
						if (this.board[curr.Item1, curr.Item2] == 0)
						{
							this.GetNeibouhs(curr.Item1, curr.Item2, q);
						}
					}
				}

				PrintBoard(true);
			}

			private void GetNeibouhs(int r, int c, Queue<Tuple<int,int>> q)
			{
				for (int cR = r - 1; cR <= (r + 1); ++cR)
				{
					for (int cC = c - 1; cC <= (c + 1); ++cC)
					{
						if ((cR >= 0 && cR < board.GetLength(0)) && (cC >= 0 && cC < board.GetLength(1)))
						{
							q.Enqueue(new Tuple<int, int>(cR, cC));
						}
					}
				}
			}
			private void SetNumbers(int[,] board)
			{
				for (int r = 0; r < board.GetLength(0); ++r)
				{
					for (int c = 0; c < board.GetLength(1); ++c)
					{
						if (board[r, c] == -1) continue;
						var countMines = 0;
						for (int cR = r - 1; cR <= (r+1); ++cR)
						{
							for (int cC = c - 1; cC <= (c + 1); ++cC)
							{
								if ((cR >= 0 && cR < board.GetLength(0)) && (cC >= 0 && cC < board.GetLength(1)))
								{
									if (board[cR, cC] == -1) countMines++;
								}
							}
						}

						board[r, c] = countMines;
					}
				}
			}

			public void PrintBoard(bool printQuestionMark)
			{
				for (int r = 0; r < board.GetLength(0); ++r)
				{
					var col = string.Empty;
					for (int c = 0; c < board.GetLength(1); ++c)
					{
						if (!printQuestionMark)
						{
							if (board[r, c] == -1)
							{
								col += ("* ");
							}
							else
								col += (board[r, c] + " ");
						}
						else
						{
							if (this.boardOutput[r, c])
							{
								col += (board[r, c] + " ");
							}else col += ("? ");
						}
					}
					Console.WriteLine(col);
				}
			}
		}
	}
}
