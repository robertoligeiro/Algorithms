using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SearchingFindNumInSorted2dArray
{
    class Program
    {
        static void Main(string[] args)
        {
            var a = new int[6][]
            {
                new int[]{ -1, 2, 4, 4, 6},
                new int[]{ 1, 5, 5, 9, 21},
                new int[]{ 3, 6, 6, 9, 22},
                new int[]{ 3, 6, 8, 10, 24},
                new int[]{ 6, 8, 9, 12, 25},
                new int[]{ 8, 10, 12, 13, 40}
            };

            var b = FindNum(a, 7); // false
            b = FindNum(a, 8); // true
            b = FindNum(a, 40); // true
        }

        public static bool FindNum(int[][] a, int n)
        {
            var col = a[0].Length - 1;
            var row = 0;
            while (row < a.GetLength(0) && col >= 0)
            {
                if (a[row][col] == n) return true;
                if (a[row][col] < n)
                {
                    row++;
                }
                else
                {
                    col--;
                }
            }
            return false;
        }
    }
}
