using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecursionPaint
{
    class Program
    {
        static void Main(string[] args)
        {
            var s = new int[,] { { 1, 6, 2 }, { 1, 6, 4 }, { 6, 6, 6 } };
            Paint(s, 2, 2, -1);
        }

        public static void Paint(int[,] s, int r, int c, int newColor)
        {
            if (s[r, c] == newColor) return;
            Paint(s, r, c, newColor, s[r, c]);
        }
        public static void Paint(int[,] s, int r, int c, int newColor, int oldColor)
        {
            if (r < 0 || c < 0 || r >= s.GetLength(0) || c >= s.GetLength(1)) return;
            if (s[r, c] == oldColor)
            {
                s[r, c] = newColor;
                Paint(s, r - 1, c, newColor, oldColor);
                Paint(s, r + 1, c, newColor, oldColor);
                Paint(s, r, c - 1, newColor, oldColor);
                Paint(s, r, c + 1, newColor, oldColor);
            }
        }
    }
}
