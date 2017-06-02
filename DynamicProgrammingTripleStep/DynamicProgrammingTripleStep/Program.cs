using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DynamicProgrammingTripleStep
{
    class Program
    {
        static void Main(string[] args)
        {
            var r0 = CountWays(8);
            var r1 = CountWaysRecursive(8);
        }

        public static int CountWays(int n)
        {
            var ways = new int[] { 1, 2, 4 };
            if (n == 1) return 1;
            if (n == 2) return 2;
            if (n == 3) return 4;
            for (int i = 4; i <= n; ++i)
            {
                var c = ways[0] + ways[1] + ways[2];
                ways[0] = ways[1];
                ways[1] = ways[2];
                ways[2] = c;
            }
            return ways[2];
        }

        public static int CountWaysRecursive(int n)
        {
            if (n < 0) return 0;
            if (n == 0) return 1;
            return CountWaysRecursive(n - 1) + CountWaysRecursive(n - 2) + CountWaysRecursive(n - 3);
        }
    }
}
