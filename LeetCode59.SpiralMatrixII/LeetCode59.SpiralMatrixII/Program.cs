using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode59.SpiralMatrixII
{
    class Program
    {
        //https://leetcode.com/problems/spiral-matrix-ii/description/
        static void Main(string[] args)
        {
            var s = new Solution();
            var r = s.GenerateMatrix(3);
        }

        public class Solution
        {
            public int[,] GenerateMatrix(int n)
            {
                var resp = new int[n, n];
                var rowStart = 0;
                var rowEnd = n - 1;
                var colStart = 0;
                var colEnd = n - 1;
                var num = 1;
                while (rowStart <= rowEnd && colStart <= colEnd)
                {

                    // Add ----->
                    for (int i = colStart; i <= colEnd; ++i)
                    {
                        resp[rowStart, i] = num++;
                    }
                    rowStart++;

                    // Add |
                    //     |
                    //     v
                    for (int i = rowStart; i <= rowEnd; ++i)
                    {
                        resp[i, colEnd] = num++;
                    }
                    colEnd--;

                    // Add <------
                    for (int i = colEnd; i >= colStart; --i)
                    {
                        if (rowStart <= rowEnd)
                        {
                            resp[rowEnd, i] = num++;
                        }
                    }
                    rowEnd--;

                    // Add ^
                    //     |
                    //     |
                    for (int i = rowEnd; i >= rowStart; --i)
                    {
                        if (colStart <= colEnd)
                        {
                            resp[i, colStart] = num++;
                        }
                    }
                    colStart++;
                }

                return resp;
            }
        }
    }
}
