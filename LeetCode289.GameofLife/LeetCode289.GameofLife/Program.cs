using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode289.GameofLife
{
    class Program
    {
        //https://leetcode.com/problems/game-of-life/#/description
        static void Main(string[] args)
        {
            var s = new Solution();
            var b = new int[,] { { 1, 1 }, { 1, 1 } };
            s.GameOfLife(b);
        }
        public class Solution
        {
            public void GameOfLife(int[,] board)
            {
                var toOne = new List<Tuple<int, int>>();
                var toZero = new List<Tuple<int, int>>();
                for (int row = 0; row < board.GetLength(0); ++row)
                {
                    for (int col = 0; col < board.GetLength(1); ++col)
                    {
                        var neighborsCount = GetCountNeighbors(board, row, col, 1);
                        if (board[row, col] == 0)
                        {
                            if (neighborsCount == 3) toOne.Add(new Tuple<int, int>(row, col));
                        }
                        if (board[row, col] == 1)
                        {
                            if (neighborsCount <= 1 || neighborsCount > 3) toZero.Add(new Tuple<int, int>(row, col));
                        }
                    }
                }

                foreach (var t in toZero)
                {
                    board[t.Item1, t.Item2] = 0;
                }
                foreach (var t in toOne)
                {
                    board[t.Item1, t.Item2] = 1;
                }
            }
            public int GetCountNeighbors(int[,] board, int row, int col, int neighbor)
            {
				var countNeighbors = 0;
				for (int i = -1; i <= 1; ++i)
				{
					for (int j = -1; j <= 1; ++j)
					{
						if (i == 0 && j == 0) continue;
						var r = row + i;
						var c = col + j;
						if (r >= 0 && r < board.GetLength(0) &&
							c >= 0 && c < board.GetLength(1) &&
							board[r, c] == neighbor)
						{
							countNeighbors++;
						}
					}
				}

				return countNeighbors;
            }
        }

    }
}
