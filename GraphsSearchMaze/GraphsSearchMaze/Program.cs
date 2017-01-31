using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GraphsSearchMaze
{
    class Program
    {
        static void Main(string[] args)
        {
            var m = new int[4, 4] { { 1, 1, 1, 1}, { 1, 1, 1, 1 }, { 1, 0, 0, 0 }, { 1, 1, 1, 1 } };
            var r = SeachMazeExit(m, new Tuple<int, int>(0, 0), new Tuple<int, int>(3, 3));
        }

        public static List<Tuple<int,int>> SeachMazeExit(int[,] m, Tuple<int, int> s, Tuple<int, int> e)
        {
            var r = new List<Tuple<int, int>>();
            if (s == e) { r.Add(s); return r; }
            var visited = new Dictionary<Tuple<int, int>, Tuple<int, int>>() { { s, s } };

            if (FindExit(m, s, e, visited, r)) { r.Reverse(); return r; }
            return null;
        }

        public static bool FindExit(int[,] m, Tuple<int, int> s, Tuple<int, int> e, Dictionary<Tuple<int, int>, Tuple<int, int>> v, List<Tuple<int, int>> r)
        {
            var sPath = new Stack<Tuple<int, int>>();
            sPath.Push(s);
            var found = false;
            while (sPath.Count > 0)
            {
                var curr = sPath.Pop();
                if (curr.Equals(e))
                {
                    found = true;
                    break;
                }

                GetPath(m, sPath, v, curr);
            }

            if (found)
            {
                r.Add(e);
                var curr = v[e];
                while (curr != s)
                {
                    r.Add(curr);
                    curr = v[curr];
                }
                r.Add(s);
                return true;
            }
            return false;
        }

        public static void GetPath(int[,] m, Stack<Tuple<int, int>> s, Dictionary<Tuple<int, int>, Tuple<int, int>> v, Tuple<int, int> curr)
        {
            var l = GetPath(m, curr);
            foreach (var c in l)
            {
                if (m[c.Item1, c.Item2] != 0 && !v.ContainsKey(c))
                {
                    v.Add(c, curr);
                    s.Push(c);
                }
            }
        }

        public static List<Tuple<int, int>> GetPath(int[,] m, Tuple<int, int> curr)
        {
            var r = new List<Tuple<int, int>>();
            if (curr.Item1 - 1 >= 0)
            {
                r.Add(new Tuple<int, int>(curr.Item1 - 1, curr.Item2));
            }
            if (curr.Item1 + 1 < m.GetLength(0))
            {
                r.Add(new Tuple<int, int>(curr.Item1 + 1, curr.Item2));
            }
            if (curr.Item2 - 1 >= 0)
            {
                r.Add(new Tuple<int, int>(curr.Item1, curr.Item2 - 1));
            }
            if (curr.Item2 + 1 < m.GetLength(1))
            {
                r.Add(new Tuple<int, int>(curr.Item1, curr.Item2 + 1));
            }
            return r;
        }
    }
}
