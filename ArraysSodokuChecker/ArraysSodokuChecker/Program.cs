using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArraysSodokuChecker
{
    class Program
    {
        static void Main(string[] args)
        {
            var s = new int[9, 9] { { 1, 0, 0, 0, 0, 0, 0, 0, 0 }, 
                                    { 0, 0, 0, 0, 0, 0, 0, 0, 0 }, 
                                    { 0, 0, 0, 1, 0, 0, 0, 0, 0 }, 
                                    { 0, 0, 0, 0, 0, 0, 0, 0, 0 }, 
                                    { 0, 0, 0, 0, 0, 0, 0, 0, 0 }, 
                                    { 0, 0, 0, 0, 0, 0, 0, 0, 0 }, 
                                    { 0, 0, 0, 0, 0, 0, 0, 0, 0 }, 
                                    { 0, 0, 0, 0, 0, 0, 0, 1, 0 }, 
                                    { 0, 0, 0, 0, 0, 0, 0, 0, 2 } };

            var b = SodokuChecker(s);
        }

        public static bool SodokuChecker(int[,] s)
        {
            for (int i = 0; i < s.GetLength(0); ++i)
            {
                if (!CheckLine(i, s)) return false;
            }
            for (int i = 0; i < s.GetLength(0); ++i)
            {
                if (!CheckCol(i, s)) return false;
            }

            double p = Math.Sqrt(s.GetLength(0));
            for (int i = 0; i < p; ++i)
            {
                for (int j = 0; j < p; ++j)
                {
                    if (!CheckRegion(i*(int)p, j*(int)p, s)) return false;
                }
            }
            return true;
        }

        public static bool CheckLine(int l, int[,] s)
        {
            var h = new HashSet<int>();
            for (int i = 0; i < s.GetLength(0); ++i)
            {
                if (s[l, i] != 0 && !h.Add(s[l, i])) return false;
            }
            return true;
        }
        public static bool CheckCol(int c, int[,] s)
        {
            var h = new HashSet<int>();
            for (int i = 0; i < s.GetLength(0); ++i)
            {
                if (s[c, i] != 0 && !h.Add(s[i, c])) return false;
            }
            return true;
        }
        public static bool CheckRegion(int l, int c, int[,] s)
        {
            var h = new HashSet<int>();
            var maxL = l + Math.Sqrt(s.GetLength(0));
            var maxC = c + Math.Sqrt(s.GetLength(0));
            for (int i = l; i < maxL; ++i)
            {
                for (int j = c; j < maxC; ++j)
                {
                    if (s[i, j] != 0 && !h.Add(s[i, j])) return false;
                }
            }
            return true;
        }
    }
}
