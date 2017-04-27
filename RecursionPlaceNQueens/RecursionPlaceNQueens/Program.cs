using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecursionPlaceNQueens
{
    class Program
    {
        static void Main(string[] args)
        {
            var r = PlaceQueens(4);
        }

        public static List<List<Tuple<int, int>>> PlaceQueens(int n)
        {
            var resp = new List<List<Tuple<int, int>>>();
            resp.Add(new List<Tuple<int, int>>());
            PlaceQueens(n, resp, 0);
            resp.RemoveAt(resp.Count - 1);
            return resp;
        }

        public static bool PlaceQueens(int n, List<List<Tuple<int, int>>> resp, int row)
        {
            if (row == n)
            {
                if(resp.LastOrDefault().Count == n) resp.Add(new List<Tuple<int, int>>());
                return true;
            } 

            for (int j = 0; j < n; ++j)
            {
                var t = new Tuple<int, int>(row, j);
                if (CanAdd(resp.LastOrDefault(), t))
                {
                    resp.LastOrDefault().Add(t);
                    PlaceQueens(n, resp, row + 1);
                    if (resp.LastOrDefault().Count > 0) resp.LastOrDefault().RemoveAt(resp.LastOrDefault().Count - 1);
                }
            }

            return false;
        }

        public static bool CanAdd(List<Tuple<int, int>> l, Tuple<int, int> t)
        {
            for(int i = 0; i < l.Count; ++i)
            {
                var diff = Math.Abs(t.Item2 - l[i].Item2);
                if (diff == 0 || diff ==  l.Count - i) return false;
            }
            return true;
        }
    }
}
