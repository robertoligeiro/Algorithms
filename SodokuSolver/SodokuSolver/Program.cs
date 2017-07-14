using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SodokuSolver
{
    class Program
    {
        static void Main(string[] args)
        {
            int [,] sudoku = new int[,] { 
                { 7, 6, 0, 8, 0, 3, 0, 0, 2 }, 
                { 0, 2, 5, 0, 0, 9, 7, 0, 6 }, 
                { 0, 0, 1, 0, 6, 0, 0, 0, 3 }, 
                { 0, 9, 0, 0, 0, 0, 8, 3, 1 }, 
                { 2, 0, 0, 0, 0, 0, 0, 0, 4 }, 
                { 4, 5, 3, 0, 0, 0, 0, 6, 0 }, 
                { 1, 0, 0, 0, 7, 0, 3, 0, 0 }, 
                { 5, 0, 2, 3, 0, 0, 6, 1, 0 }, 
                { 8, 0, 0, 1, 0, 5, 0, 4, 7 } };

            var s = new SudokuSolver(sudoku);
            var r = s.Solve();
        }

        public class SudokuSolver
        {
            public int[,] sudoku { get; set; }
            public SudokuSolver(int[,] board)
            {
                sudoku = board;
            }
            public bool Solve()
            {
                for (int r = 0; r < this.sudoku.GetLength(0); ++r)
                {
                    for (int c = 0; c < this.sudoku.GetLength(1); ++c)
                    {
                        if (this.sudoku[r, c] == 0)
                        {
                            for (int v = 1; v <= 9; ++v)
                            {
                                this.sudoku[r, c] = v;
                                if (this.CanPut(r, c))
                                {
                                    if (this.Solve())
                                    {
                                        return true;
                                    }
                                }
                            }
                            this.sudoku[r, c] = 0;
                            return false;
                        }
                    }
                }
                return true;
            }
            private bool CanPut(int row, int col)
            {
                return this.CanPutRow(row) && this.CanPutCol(col) && this.CanPutBox(row, col);
            }
            private bool CanPutRow(int row)
            {
                var h = new HashSet<int>();
                for (int i = 0; i < this.sudoku.GetLength(0); ++i)
                {
                    if (this.sudoku[row, i] != 0 && !h.Add(this.sudoku[row, i])) return false;
                }
                return true;
            }
            private bool CanPutCol(int col)
            {
                var h = new HashSet<int>();
                for (int i = 0; i < this.sudoku.GetLength(1); ++i)
                {
                    if (this.sudoku[i,col] != 0 && !h.Add(this.sudoku[i, col])) return false;
                }
                return true;
            }
            private bool CanPutBox(int row, int col)
            {
                var h = new HashSet<int>();
                var rowStart = row - row % 3;
                var colStart = col - col % 3;
                for (int r = 0; r < 3; ++r)
                {
                    for (int c = 0; c < 3; ++c)
                    {
                        if (this.sudoku[rowStart + r, colStart + c] != 0 && !h.Add(this.sudoku[rowStart + r, colStart + c])) return false;
                    }
                }
                return true;
            }
        }
    }
}
