using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArraysRotateArrayInPlace
{
    class Program
    {
        static void Main(string[] args)
        {
            var m = new int[,] { { 1, 2, 3 }, { 4, 5, 6 }, { 7, 8, 9 } };
            RotateArray(m);
        }

        public static void RotateArray(int[,] m)
        {
            var len = m.GetLength(0) - 1;
            for (int i = 0; i < m.GetLength(0) / 2; ++i)
            {
                for (int j = i; j < len - i; ++j)
                {
                    var t1 = m[len - j, i];
                    var t2 = m[len - i, len - j];
                    var t3 = m[j, len - i];
                    var t4 = m[i, j];
                    m[i, j] = t1;
                    m[len - j, i] = t2;
                    m[len - i, len - j] = t3;
                    m[j, len - i] = t4; 
                }
            }
        }
    }
}
