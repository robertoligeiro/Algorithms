using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecursionMultiply
{
    class Program
    {
        static void Main(string[] args)
        {
            var r = Multiply(4, 4);
            r = Multiply(4, 5);
        }

        public static int Multiply(int x, int y)
        {
            var smaller = x > y ? y : x;
            var bigger = x > y ? x : y;
            return MultiplyRec(smaller, bigger);
        }

        public static int MultiplyRec(int smaller, int bigger)
        {
            if (smaller == 0) return 0;
            var s = smaller >> 1;
            var half = MultiplyRec(s, bigger);
            if (smaller % 2 == 0) return half + half;
            return bigger + half + half;
        }
    }
}
