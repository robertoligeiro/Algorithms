using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecursionPowXY
{
    class Program
    {
        static void Main(string[] args)
        {
            var r = Pow(2, 2);

            r = Pow(10, 2);
            r = Pow(2, 5);
            r = Pow(2, 10);
        }

        public static int Pow(int x, uint y)
        {
            if (y == 0) return 1;
            var temp = Pow(x, y / 2);

            if (y % 2 == 0) return temp * temp;
            else return x * temp * temp;
        }
    }
}
