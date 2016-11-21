using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SodokuSolver
{
    class Program
    {
        public static class SodokuSolver
        {
            public static bool SolveSodoku(int[][] board)
            {
                return SolveSodokuRec(board);
            }

            private static bool SolveSodokuRec(int[][] board)
            {
                for (int r = 0; r <= 8; ++r)
                {
                    for (int c = 0; c <= 8; ++c)
                    {
                        if (board[r][c] == 0)
                        {
                            for (int x = 1; x <= 9; ++x)
                            {
                                board[r][c] = x;
                                if (IsValidSodoku(board, r, c))
                                {
                                    if (SolveSodokuRec(board))
                                    {
                                        return true;
                                    }
                                }
                            }
                            board[r][c] = 0;
                            return false;
                        }
                    }
                }
                return true;
            }

            private static bool IsValidSodoku(int[][] board, int row, int col)
            {
                var h = new HashSet<int>();
                for (int i = 0; i <= 8; ++i)
                {
                    if (board[row][i] != 0 && !h.Add(board[row][i])) return false;
                }

                h.Clear();
                for (int i = 0; i <= 8; ++i)
                {
                    if (board[i][col] != 0 && !h.Add(board[i][col])) return false;
                }

                h.Clear();
                if (row <= 2) row = 0;
                else
                if (row > 2 && row <= 5 ) row = 3;
                else
                if (row > 5) row = 6;

                if (col <= 2) col = 0;
                else
                if (col > 2 && col <= 5) col = 3;
                else
                if (col > 5) col = 6;
                for (int i = row; i <= row + 2; ++i)
                {
                    for (int j = col; j <= col + 2; ++j)
                    {
                        if (board[i][j] != 0 && !h.Add(board[i][j])) return false;
                    }
                }

                return true;
            }
        }

        static void Main(string[] args)
        {
            int [][]board = new int[9][] {new int[] { 7, 6, 0, 8, 0, 3, 0, 0, 2 }, new int[] { 0, 2, 5, 0, 0, 9, 7, 0, 6 }, new int[] { 0, 0, 1, 0, 6, 0, 0, 0, 3 }, new int[] { 0, 9, 0, 0, 0, 0, 8, 3, 1 }, new int[] { 2, 0, 0, 0, 0, 0, 0, 0, 4 }, new int[] { 4, 5, 3, 0, 0, 0, 0, 6, 0 }, new int[] { 1, 0, 0, 0, 7, 0, 3, 0, 0 }, new int[] { 5, 0, 2, 3, 0, 0, 6, 1, 0 }, new int[] { 8, 0, 0, 1, 0, 5, 0, 4, 7 } };

            var b = SodokuSolver.SolveSodoku(board);
        }
    }
}
