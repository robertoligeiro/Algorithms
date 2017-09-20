using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode363.MaxSumRectangleNoLargerThanK
{
    //https://leetcode.com/problems/max-sum-of-rectangle-no-larger-than-k/description/
    //not working.
    //need to implement algo from here: https://www.youtube.com/watch?v=yCQN096CwWM
    class Program
    {
        static void Main(string[] args)
        {
            var s = new Solution();
            //var r = s.MaxSumSubmatrix(new int[,] { { 1,0,1}, { 0,-2,3} }, 2);
            var r = s.MaxSumSubmatrix(new int[,] { { 2, 2, -1 } }, 3);
        }
        public class Solution
        {
            public int MaxSumSubmatrix(int[,] matrix, int k)
            {
                var max = int.MinValue;
                for (int r = 0; r < matrix.GetLength(0); ++r)
                {
                    for (int c = 0; c < matrix.GetLength(1); ++c)
                    {
                        var localMax = MaxFrom(matrix, r, c, k);
                        max = Math.Max(localMax, max);
                    }
                }
                return max;
            }

            private int MaxFrom(int[,] matrix, int r, int c, int k)
            {
                var stepR = 1;
                var stepC = 1;
                var max = Enumerable.Repeat(int.MinValue,3).ToArray();
                max[2] = matrix[r, c] <= k ? matrix[r, c] : int.MinValue;
                while (stepR <= matrix.GetLength(0) || stepC <= matrix.GetLength(1))
                {
                    var maxRec = 0;
                    for (int i = r; i < stepR + r && i < matrix.GetLength(0); ++i)
                    {
                        for (int j = c; j < stepC + c && j < matrix.GetLength(1); ++j)
                        {
                            maxRec += matrix[i, j];
                        }
                    }

                    var maxRecrow = 0;
                    if (stepR <= matrix.GetLength(0))
                    {
                        for (int i = r; i < stepR + r && i < matrix.GetLength(0); ++i)
                        {
                            maxRecrow += matrix[i, c];
                        }
                        stepR++;
                    }

                    var maxReccol = 0;
                    if (stepC <= matrix.GetLength(1))
                    {
                        for (int i = c; i < stepC + c && i < matrix.GetLength(1); ++i)
                        {
                            maxReccol += matrix[r, i];
                        }
                        stepC++;
                    }

                    if (stepR < matrix.GetLength(0) && maxRecrow <= k)
                    {
                        max[0] = Math.Max(max[0], maxRecrow);
                    }
                    if (stepC < matrix.GetLength(0) && maxReccol <= k)
                    {
                        max[1] = Math.Max(max[1], maxReccol);
                    }
                    if (maxRec <= k)
                    {
                        max[2] = Math.Max(max[2], maxRec);
                    }
                }
                Array.Sort(max);
                return max.Last();
            }
        }
    }
}
