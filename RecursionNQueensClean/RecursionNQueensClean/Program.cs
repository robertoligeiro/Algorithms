using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecursionNQueensClean
{
    class Program
    {
        static void Main(string[] args)
        {
            var r = GetNQueens(4);
        }

        public static List<List<Tuple<int, int>>> GetNQueens(int n)
        {
            var resp = new List<List<Tuple<int, int>>>();
            var parc = new List<Tuple<int, int>>();
            GetNQueens(n, 0, parc, resp);
            return resp;
        }

        public static void GetNQueens(int n, int row, List<Tuple<int, int>> parc, List<List<Tuple<int, int>>> resp)
        {
            if (row == n)
            {
                resp.Add(new List<Tuple<int, int>>(parc));
                return;
            }

            for (int col = 0; col < n; ++col)
            {
                var t = new Tuple<int, int>(row, col);
                if (CanAttack(t, parc))
                {
                    parc.Add(t);
                    GetNQueens(n, row + 1, parc, resp);
                    parc.RemoveAt(parc.Count - 1);
                }
            }
        }

        public static bool CanAttack(Tuple<int,int> curr, List<Tuple<int, int>> placed)
        {
            foreach (var t in placed)
            {
                var diff = Math.Abs(curr.Item2 - t.Item2);
                if (diff == 0 || diff == curr.Item1 - t.Item1) return false;
            }
            return true;
        }
    }
}
