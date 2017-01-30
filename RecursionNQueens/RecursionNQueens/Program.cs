using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecursionNQueens
{
    class Program
    {
        static void Main(string[] args)
        {
            var r = GetNQueens(4);
        }

        public static List<List<Tuple<int, int>>> GetNQueens(int n)
        {
            var r = new List<List<Tuple<int, int>>>();
            GetNQueensRec(n, r, new List<Tuple<int,int>>(), 0);
            return r;
        }

        public static void GetNQueensRec(int n, List<List<Tuple<int, int>>> r, List<Tuple<int, int>> l, int row)
        {
            if (l != null && l.Count == n)
            {

                r.Add(new List<Tuple<int,int>>(l));
                return;
            }

            var tempL = new List<Tuple<int, int>>(l);
            for (int j = 0; j < n; ++j)
            {
                var tempT = new Tuple<int, int>(row,j);
                if (CanAdd(tempL, tempT))
                {
                    tempL.Add(tempT);
                    GetNQueensRec(n, r, tempL, row + 1);
                    tempL.RemoveAt(tempL.Count - 1);
                }
            }
        }

        public static bool CanAdd(List<Tuple<int, int>> l, Tuple<int, int> t)
        {
            foreach (var e in l)
            {
                var diff = Math.Abs(e.Item2 - t.Item2);
                if (diff == 0 || diff == t.Item1 - e.Item1)
                {
                    return false;
                }
            }

            return true;
        }
    }
}
