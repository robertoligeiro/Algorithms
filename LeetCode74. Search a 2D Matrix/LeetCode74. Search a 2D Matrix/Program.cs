using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode74.Search_a_2D_Matrix
{
    class Program
    {
        //https://leetcode.com/problems/search-a-2d-matrix/description/
        static void Main(string[] args)
        {
        }
        public class Solution
        {
            public bool SearchMatrix(int[,] matrix, int target)
            {
                var row = 0;
                var col = matrix.GetLength(1) - 1;
                while (row < matrix.GetLength(0) && col >= 0)
                {
                    if (matrix[row, col] == target) return true;
                    if (matrix[row, col] > target) col--;
                    else row++;
                }
                return false;
            }
        }
    }
}
