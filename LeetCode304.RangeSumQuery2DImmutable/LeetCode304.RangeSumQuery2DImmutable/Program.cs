using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode304.RangeSumQuery2DImmutable
{
    //https://leetcode.com/problems/range-sum-query-2d-immutable/#/description
    // solution is based from here: https://leetcode.com/problems/range-sum-query-2d-immutable/#/solutions
    class Program
    {
        static void Main(string[] args)
        {
        }

        public class NumMatrix
        {
            private int row;
            private int col;
            private int[,]sums;
            public NumMatrix(int[,] matrix)
            {
                row = matrix.GetLength(0);
                col = row > 0 ? matrix.GetLength(1) : 0;
                sums = new int[row+1,col+1];
                for (int i = 1; i <= row; i++)
                {
                    for (int j = 1; j <= col; j++)
                    {
                        sums[i,j] = matrix[i - 1,j - 1] +
                                     sums[i - 1,j] + sums[i,j - 1] - sums[i - 1,j - 1];
                    }
                }
            }

            public int SumRegion(int row1, int col1, int row2, int col2)
            {
                return sums[row2 + 1,col2 + 1] - sums[row2 + 1,col1] - sums[row1,col2 + 1] + sums[row1,col1];
            }
        }
    }
}
