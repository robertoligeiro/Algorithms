using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecursionCalcPowXY
{
    class Program
    {
        static void Main(string[] args)
        {
            var r = Pow(2, 1);
            r = Pow(2, 2);
            r = Pow(2, 3);
            r = Pow(3, 0);
            r = Pow(5, 2);
            r = Pow(5, 3);
            r = Pow(5, 4);
            r = Pow(10, 10);
        }

        public static long Pow(long x, long y)
        {
            if (y == 0) return 1;
            var parc = Pow(x, y / 2);
            if (y % 2 == 0) return parc * parc;
            return parc * parc * x;
        }
    }
}
