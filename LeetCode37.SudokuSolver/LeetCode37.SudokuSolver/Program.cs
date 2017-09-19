using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode37.SudokuSolver
{
    //https://leetcode.com/problems/sudoku-solver/discuss/
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
            s.SolveSudoku(b);
        }

        public class Solution
        {
            public void SolveSudoku(char[,] board)
            {
                SolveSudokuRec(board);
            }

            private bool SolveSudokuRec(char[,] board)
            {
                for (int row = 0; row < board.GetLength(0); ++row)
                {
                    for (int col = 0; col < board.GetLength(0); ++col)
                    {
                        if (board[row, col] == '.')
                        {
                            for (char i = '1'; i <= '9'; ++i)
                            {
                                if (CanAdd(board, row, col, i))
                                {
                                    board[row, col] = i;
                                    if (SolveSudokuRec(board)) return true;
                                    board[row, col] = '.';
                                }
                            }
                            return false;
                        }
                    }
                }
                return true;
            }

            private bool CanAdd(char[,] board, int row, int col, char value)
            {
                return CanAddRow(board, row, value) && CanAddCol(board, col, value) && CanAddBox(board, row, col, value);
            }
            private bool CanAddRow(char[,] board, int row, char value)
            {
                var h = new HashSet<char>() { value };
                for (int i = 0; i < 9; ++i)
                {
                    if (board[row,i] != '.' && !h.Add(board[row, i]))
                    {
                        return false;
                    }
                }
                return true;
            }
            private bool CanAddCol(char[,] board, int col, char value)
            {
                var h = new HashSet<char>() { value };
                for (int i = 0; i < 9; ++i)
                {
                    if (board[i, col] != '.' && !h.Add(board[i, col]))
                    {
                        return false;
                    }
                }
                return true;
            }
            private bool CanAddBox(char[,] board, int row, int col, char value)
            {
                var startRow = row - row % 3;
                var startCol = col - col % 3;
                var h = new HashSet<char>() { value };
                for (int r = startRow; r < startRow + 3; ++r)
                {
                    for (int c = startCol; c < startCol + 3; ++c)
                    {
                        if (board[r, c] != '.' && !h.Add(board[r, c]))
                        {
                            return false;
                        }
                    }
                }
                return true;
            }
        }
    }
}
