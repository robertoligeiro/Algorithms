using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArraysPrintSpiral
{
    class Program
    {
        static void Main(string[] args)
        {
            var s = new int[9, 9] { { 1, 2, 3, 4, 5, 6, 7, 8, 9 },
                                    { 32, 33, 34, 35, 36, 37, 38, 39, 10 },
                                    { 31, 56, 57, 58, 59, 60, 61, 40, 11 },
                                    { 30, 55, 72, 73, 74, 75, 62, 41, 12 },
                                    { 29, 54, 71, 80, 81, 76, 63, 42, 13 },
                                    { 28, 53, 70, 79, 78, 77, 64, 43, 14 },
                                    { 27, 52, 69, 68, 67, 66, 65, 44, 15 },
                                    { 26, 51, 50, 49, 48, 47, 46, 45, 16 },
                                    { 25, 24, 23, 22, 21, 20, 19, 18, 17 } };

            var b = GetSpiralArray(s);
        }

        public static List<List<int>> GetSpiralArray(int[,] m)
        {
            var r = new List<List<int>>();
            float contIter = m.GetLength(0)/2;
            int count = (int) Math.Ceiling(contIter);
            var startLine = 0;
            var startCol = 0;
            var endLine = m.GetLength(0) - 1;
            var endCol = m.GetLength(0) - 1;
            for (int i = 0; i < contIter; ++i)
            {
                var l = LeftToRight(startLine++, startCol, endCol, m);
                r.Add(l);
                l = TopToBottom(endCol--, startLine, endLine, m);
                r.Add(l);
                l = RightToLeft(endLine--, endCol, startCol, m);
                r.Add(l);
                l = BottomToTop(startCol++, endLine, startLine, m);
                r.Add(l);
            }

            return r;
        }

        public static List<int> LeftToRight(int l, int startCol, int endCol, int[,] m)
        {
            var r = new List<int>();
            for (int i = startCol; i <= endCol; ++i)
            {
                r.Add(m[l, i]);
            }
            return r;
        }
        public static List<int> TopToBottom(int c, int startLine, int endLine, int[,] m)
        {
            var r = new List<int>();
            for (int i = startLine; i <= endLine; ++i)
            {
                r.Add(m[i, c]);
            }
            return r;
        }
        public static List<int> RightToLeft(int l, int startCol, int endCol, int[,] m)
        {
            var r = new List<int>();
            for (int i = startCol; i >= endCol; --i)
            {
                r.Add(m[l, i]);
            }
            return r;
        }
        public static List<int> BottomToTop(int c, int startLine, int endLine, int[,] m)
        {
            var r = new List<int>();
            for (int i = startLine; i >= endLine; --i)
            {
                r.Add(m[i, c]);
            }
            return r;
        }
    }
}
