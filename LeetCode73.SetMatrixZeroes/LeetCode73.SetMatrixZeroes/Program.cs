using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//https://leetcode.com/problems/set-matrix-zeroes/#/description
namespace LeetCode73.SetMatrixZeroes
{
    class Program
    {
        static void Main(string[] args)
        {
            var m = new int[,] { { 1, 3, 0 }, { 2, 0, 1 }, { 1, 1, 3 } };
            var s = new Solution();
            s.SetZeroes(m);
        }

        public class Solution
        {
            private int[,] m;
            public void SetZeroes(int[,] matrix)
            {
                m = matrix;
                var zeros = new List<Tuple<int, int>>();
                for (int row = 0; row < matrix.GetLength(0); ++row)
                {
                    for (int col = 0; col < matrix.GetLength(1); ++col)
                    {
                        if (matrix[row, col] == 0) zeros.Add(new Tuple<int, int>(row, col));
                    }
                }
                foreach (var t in zeros) SetZeroes(t.Item1, t.Item2);
            }

            private void SetZeroes(int row, int col)
            {
                for (int i = 0; i < m.GetLength(1); ++i) m[row, i] = 0;
                for (int i = 0; i < m.GetLength(0); ++i) m[i, col] = 0;
            }
        }
    }
}
