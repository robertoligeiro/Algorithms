using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecursionCalcFactorial
{
    class Program
    {
        static void Main(string[] args)
        {
            var r = Fact(4);
        }

        public static int Fact(int n)
        {
            if (n == 1) return 1;
            return n * Fact(n - 1);
        }
    }
}
