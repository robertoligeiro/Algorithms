using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode52.NQueensII
{
    class Program
    {
        //https://leetcode.com/problems/n-queens-ii/#/description
        static void Main(string[] args)
        {
            var s = new Solution();
            var r = s.TotalNQueens(4);
        }

        public class Solution
        {
            public int TotalNQueens(int n)
            {
                var queens = new List<Tuple<int,int>>();
                var count = 0;
                TotalQueens(n, 0, queens, ref count);
                return count;
            }

            public void TotalQueens(int n, int row, List<Tuple<int, int>> queens, ref int count)
            {
                if (row == n)
                {
                    count++;
                    return;
                } 

                for (int i = 0; i < n; ++i)
                {
                    var t = new Tuple<int, int>(row, i);
                    if (CanAdd(t, queens))
                    {
                        queens.Add(t);
                        TotalQueens(n, row + 1, queens, ref count);
                        queens.RemoveAt(queens.Count - 1);
                    }
                }
            }

            public bool CanAdd(Tuple<int, int> t, List<Tuple<int, int>> queens)
            {
                foreach (var q in queens)
                {
                    var diff = Math.Abs(t.Item2 - q.Item2);
                    if (diff == 0 || diff == t.Item1 - q.Item1) return false;
                }
                return true;
            }
        }
    }
}
