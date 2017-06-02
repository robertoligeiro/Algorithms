using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecursionRobotInGrid
{
    class Program
    {
        static void Main(string[] args)
        {
            var m = new int[4, 4] { { 0, 0, 0, 0 }, { 0, -1, -1, 0 }, { 0, 0, -1, 0 }, { -1, 0, -1, 0 } };
            var r = GetPath(m);
        }

        public static List<Tuple<int, int>> GetPath(int[,] m)
        {
            var resp = new List<Tuple<int, int>>();
            var start = new Tuple<int, int>(0,0);
            var end = new Tuple<int, int>(m.GetLength(0) - 1, m.GetLength(1) - 1);
            GetPath(m, start, end, resp);
            return resp;
        }
        public static bool GetPath(int[,] m, Tuple<int, int> curr, Tuple<int, int> end, List<Tuple<int, int>> resp)
        {
            if (m[curr.Item1, curr.Item2] == -1) return false;
            if (curr.Equals(end)) return true;
            var next = GetNext(m, curr);
            foreach (var c in next)
            {
                resp.Add(c);
                if (!GetPath(m, c, end, resp)) resp.RemoveAt(resp.Count - 1);
                else return true;
            }
            return false;
        }

        public static List<Tuple<int, int>> GetNext(int[,] m, Tuple<int, int> c)
        {
            var resp = new List<Tuple<int, int>>();
            if (c.Item1 < m.GetLength(0) - 1) resp.Add(new Tuple<int, int>(c.Item1 + 1, c.Item2));
            if (c.Item2 < m.GetLength(1) - 1) resp.Add(new Tuple<int, int>(c.Item1, c.Item2 + 1));
            return resp;
        }
    }
}
