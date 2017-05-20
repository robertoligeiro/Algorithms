using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MatrixPaintToZero
{
    class Program
    {
        static void Main(string[] args)
        {
            var m = new int[3][]
            {
                new int[] { 1, 2, 0 },
                new int[] { 3, 0, 1 },
                new int[] { 4, 5, 6 }
            };

            PaintZero(m);
        }

        public static void PaintZero(int[][] m)
        {
            var l = new List<Tuple<int, int>>();
            for (int i = 0; i < m.GetLength(0); ++i)
            {
                for (int j = 0; j < m[i].GetLength(0); ++j)
                {
                    if (m[i][j] == 0) l.Add(new Tuple<int, int>(i, j));
                }
            }

            foreach (var t in l)
            {
                PaintZero(t, m);
            }
        }

        public static void PaintZero(Tuple<int, int> t, int[][] m)
        {
            for (int j = 0; j < m[t.Item1].GetLength(0); ++j)
            {
                m[t.Item1][j] = 0;
            }
            for (int j = 0; j < m.GetLength(0); ++j)
            {
                m[j][t.Item2] = 0;
            }
        }
    }
}
