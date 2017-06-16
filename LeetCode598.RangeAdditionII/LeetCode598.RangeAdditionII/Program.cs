using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode598.RangeAdditionII
{
    class Program
    {
        //https://leetcode.com/problems/range-addition-ii/#/description
        static void Main(string[] args)
        {
            var s = new Solution();
            var r = s.MaxCount(3, 3, new int[,] { { 2, 2 }, { 3, 3 } });
        }
        public class Solution
        {
            public int MaxCount(int m, int n, int[,] ops)
            {
                if (ops.Length == 0) return m * n;
                var minRow = int.MaxValue;
                var minCol = int.MaxValue;
                for (int i = 0; i < ops.GetLength(0); ++i)
                {
                    minRow = Math.Min(minRow, ops[i, 0]);
                    minCol = Math.Min(minCol, ops[i, 1]);
                }

                return minRow * minCol;
            }
        }
    }
}
