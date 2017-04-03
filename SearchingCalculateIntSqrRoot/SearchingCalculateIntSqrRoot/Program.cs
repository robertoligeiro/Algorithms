using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SearchingCalculateIntSqrRoot
{
    class Program
    {
        static void Main(string[] args)
        {
            var r = CalculateSqrRoot(16);
            r = CalculateSqrRoot(25);
            r = CalculateSqrRoot(32);
            r = CalculateSqrRoot(37);
            r = CalculateSqrRoot(300);
        }

        public static int CalculateSqrRoot(int k)
        {
            var left = 0;
            var right = k / 2;
            while (left <= right)
            {
                var mid = left + (right - left) / 2;
                var sqr = mid * mid;
                if (sqr == k) return mid;
                if (sqr > k)
                {
                    right = mid - 1;
                }
                else
                {
                    left = mid + 1;
                }
            }

            return right;
        }
    }
}
