using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode85.MaximalRectangle
{
    class Program
    {
        static void Main(string[] args)
        {
            var s = new Solution();
            //var m = new char[5, 8]
            //    {
            //        {'1','1','1','1','1','1','1','1'},
            //        {'1','1','1','1','1','1','1','0'},
            //        {'1','1','1','1','1','1','1','0'},
            //        {'1','1','1','1','1','0','0','0'},
            //        {'0','1','1','1','1','0','0','0'}
            //    };
            var m = new char[4, 5]
            {
                { '1', '0', '1', '0', '0' },
                {'1', '0', '1', '1', '1'},
                { '1', '1', '1', '1', '1'},
                {'1', '0', '0', '1', '0'},
            };
            var r = s.MaximalRectangle(m);
        }

        public class Solution
        {
            public int MaximalRectangle(char[,] matrix)
            {
                var max = 0;
                for (int i = 0; i < matrix.GetLongLength(0); ++i)
                {
                    for (int j= 0; j < matrix.GetLongLength(1); ++j)
                    {
                        if (matrix[i, j] == '1')
                        {
                            var s = IsRectangleGetSize(matrix, i, j);
                            if (s > max) max = s;
                        }
                    }
                }

                return max;
            }

            public int IsRectangleGetSize(char[,] m, int r, int c)
            {
                var countW = 0;
                var countH = 0;
                var maxArea = 0;
                for (int i = r; i < m.GetLongLength(0); ++i)
                {
                    var lw = 0;
                    for (int j = c; j < m.GetLongLength(1); ++j)
                    {
                        if (m[i, j] == '1') lw++;
                        else
                        {
                            if (j == c) return maxArea;
                            break;
                        }
                    }
                    if (countW == 0 || lw < countW)
                    {
                        countW = lw;
                    }
                    countH++;
                    var localArea = countH * countW;
                    maxArea = Math.Max(maxArea, localArea);
                }
                return maxArea;
            }
        }
    }
}
