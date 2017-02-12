using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrimitiveTypesReverseDigitis
{
    class Program
    {
        static void Main(string[] args)
        {
            int r = Reverse(314);
            r = Reverse(-192);
        }

        public static int Reverse(int a)
        {
            var neg = a < 0 ? true : false;
            int r = 0;
            a = Math.Abs(a);
            while (a > 0)
            {
                r = r * 10 + a % 10;
                a /= 10;
            }

            return neg?-r:r;
        }
    }
}
