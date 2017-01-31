using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GraphsPaintBooleanPath
{
    class Program
    {
        static void Main(string[] args)
        {
            var m = new bool[4, 4] { { false, true, false, false}, { true, true, false, false},{ false, true, false, false},{ false, true, false, true} };
            PaintMatrix(m, new Tuple<int, int>(2,0));
            PaintMatrix(m, new Tuple<int, int>(0, 1));
            PaintMatrix(m, new Tuple<int, int>(3, 3));
        }

        public static void PaintMatrix(bool[,] m, Tuple<int, int> s)
        {
            var v = new HashSet<Tuple<int, int>>() { s };
            GetPath(m, s, v);
            bool b = !m[s.Item1, s.Item2];
            foreach (var n in v)
            {
                m[n.Item1, n.Item2] = b;
            }
        }

        public static void GetPath(bool[,] m, Tuple<int, int> s, HashSet<Tuple<int, int>> v)
        {
            var sPath = new Stack<Tuple<int, int>>();
            sPath.Push(s);
            while (sPath.Count > 0)
            {
                var curr = sPath.Pop();
                GetPath(m, curr, v, sPath);
            }
        }
        public static void GetPath(bool[,] m, Tuple<int, int> s, HashSet<Tuple<int, int>> v, Stack<Tuple<int, int>> st)
        {
            var l = GetPath(m, s);
            foreach (var c in l)
            {
                if (v.Add(c))
                {
                    st.Push(c);
                }
            }
        }
        public static List<Tuple<int, int>> GetPath(bool[,] m, Tuple<int, int> c)
        {
            var l = new List<Tuple<int, int>>();
            if (c.Item1 - 1 >= 0 && m[c.Item1, c.Item2] == m[c.Item1 - 1, c.Item2]) l.Add(new Tuple<int, int>(c.Item1 - 1, c.Item2));
            if (c.Item1 + 1 < m.GetLength(0) && m[c.Item1, c.Item2] == m[c.Item1 + 1, c.Item2]) l.Add(new Tuple<int, int>(c.Item1 + 1, c.Item2));
            if (c.Item2 - 1 >= 0 && m[c.Item1, c.Item2] == m[c.Item1, c.Item2 - 1]) l.Add(new Tuple<int, int>(c.Item1, c.Item2 - 1));
            if (c.Item2 + 1 < m.GetLength(1) && m[c.Item1, c.Item2] == m[c.Item1, c.Item2 + 1]) l.Add(new Tuple<int, int>(c.Item1, c.Item2 + 1));
            return l;
        }
    }
}
