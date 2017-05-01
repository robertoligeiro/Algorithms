using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecursionSudokuSolver
{
    class Program
    {
        static void Main(string[] args)
        {
            int[][] board = new int[9][] 
            {
                new int[] { 7, 6, 0, 8, 0, 3, 0, 0, 2 },
                new int[] { 0, 2, 5, 0, 0, 9, 7, 0, 6 },
                new int[] { 0, 0, 1, 0, 6, 0, 0, 0, 3 },
                new int[] { 0, 9, 0, 0, 0, 0, 8, 3, 1 },
                new int[] { 2, 0, 0, 0, 0, 0, 0, 0, 4 },
                new int[] { 4, 5, 3, 0, 0, 0, 0, 6, 0 },
                new int[] { 1, 0, 0, 0, 7, 0, 3, 0, 0 },
                new int[] { 5, 0, 2, 3, 0, 0, 6, 1, 0 },
                new int[] { 8, 0, 0, 1, 0, 5, 0, 4, 7 }
            };

            var b = SudokuSolver(board);
        }

        public static bool SudokuSolver(int[][] board)
        {

            for (int i = 0; i < board.GetLength(0); ++i)
            {
                for (int j = 0; j < board.GetLength(0); ++j)
                {
                    if (board[i][j] == 0)
                    {
                        for (int x = 1; x <= 9; ++x)
                        {
                            if (CanAdd(board, i, j, x))
                            {
                                board[i][j] = x;
                                if (SudokuSolver(board)) return true;
                                board[i][j] = 0;
                            }
                        }
                        return false;
                    }
                }
            }
            return true;
        }

        public static bool CanAdd(int[][] board, int r, int c, int x)
        {
            var h = new HashSet<int>() { x };
            for (int i = 0; i < 9; ++i)
            {
                if (board[r][i] != 0 && !h.Add(board[r][i])) return false;
            }
            h.Clear();
            h.Add(x);
            for (int i = 0; i < 9; ++i)
            {
                if (board[i][c] != 0 && !h.Add(board[i][c])) return false;
            }
            h.Clear();
            h.Add(x);
            int l, j;
            if (r <= 2)
            {
                r = 2;
                l = 0;
            }
            else if (r <= 5)
            {
                r = 5;
                l = 3;
            }
            else
            {
                r = 8;
                l = 6;
            }
            if (c <= 2)
            {
                c = 2;
                j = 0;
            }
            else if (c <= 5)
            {
                c = 5;
                j = 3;
            }
            else
            {
                c = 8;
                j = 6;
            }

            for (; l <= r; ++l)
            {
                for (; j <= c; ++j)
                {
                    if (board[l][j] != 0 && !h.Add(board[l][j])) return false;
                }
            }
            return true;
        }
    }
}
