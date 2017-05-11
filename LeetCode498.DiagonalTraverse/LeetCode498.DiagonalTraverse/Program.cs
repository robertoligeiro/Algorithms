using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode498.DiagonalTraverse
{
    class Program
    {
        static void Main(string[] args)
        {
            //var m = new int[,] { {1,2,3 }, { 4,5,6 }, {7,8,9 }, { 10,11,12} };
            //var m = new int[,] { { 1, 2, 3 }, { 4, 5, 6 }, { 7, 8, 9 } };
            var m = new int[,] { { 1, 2, 3, 4 }, { 5, 6, 7, 8 }, { 9, 10, 11, 12 }, { 13, 14, 15, 16 } };
            var s = new Solution();
            var r = s.FindDiagonalOrder(m);
        }

        public class Solution
        {
            public int[] FindDiagonalOrder(int[,] matrix)
            {
                var r = 0;
                var c = 0;
                var resp = new List<int>();
                while (Down(matrix, ref r, ref c, resp))
                {
                    Up(matrix, ref r, ref c, resp);
                }
                return resp.ToArray();
            }

            public void Up(int[,] m, ref int r, ref int c, List<int> resp)
            {
                if (resp.Count == m.GetLength(0) * m.GetLength(1)) return;
                while (c < m.GetLength(1) - 1 && r > 0)
                {
                    resp.Add(m[r, c]);
                    c++;
                    r--;
                }
            }
            public bool Down(int[,] m, ref int r, ref int c, List<int> resp)
            {
                if (resp.Count == m.GetLength(0) * m.GetLength(1)) return false;
                resp.Add(m[r, c]);
                if (c + 1 < m.GetLength(1))
                {
                    c++;
                }
                else if (r + 1 < m.GetLength(0))
                {
                    r++;
                }

                while (c > 0 && r < m.GetLength(0) - 1)
                {
                    resp.Add(m[r, c]);
                    r++;
                    c--;
                }
                if (resp.Count == m.GetLength(0) * m.GetLength(1)) return false;
                resp.Add(m[r, c]);

                if (r + 1 < m.GetLength(0)) r++;
                else if (c + 1 < m.GetLength(1)) c++;
                else return false;
                return true;
            }
        }
    }
}
