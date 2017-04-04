using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SearchingCalcRealSquareRoot
{
    class Program
    {
        static void Main(string[] args)
        {
            var r = SqrRoot.CalcSqrRoot(4);
            r = SqrRoot.CalcSqrRoot(16);
            r = SqrRoot.CalcSqrRoot(25);
            r = SqrRoot.CalcSqrRoot(30);
        }

        public class SqrRoot
        {
            private static List<double> inc = new List<double>() { 0.1, 0.2, 0.3, 0.4, 0.5, 0.6, 0.7, 0.8, 0.9 };
            public static bool IsSqr(double tgt, double sqr)
            {
                return Math.Abs(tgt - sqr) < 0.3;
            }
            public static bool HasReachedSqr(double tgt, double sqr, out double v)
            {
                v = sqr;
                var left = 0;
                var right = 8;
                while (left <= right)
                {
                    var mid = left + (right - left) / 2;
                    sqr = v + inc[mid];
                    sqr *= sqr;
                    if (IsSqr(tgt, sqr))
                    {
                        v = sqr;
                        return true;
                    }
                    if (sqr > tgt)
                    {
                        right = mid - 1;
                    }
                    else {
                        left = mid + 1;
                    }
                }

                return false;
            }

            public static double CalcSqrRoot(double d)
            {
                double left = 0;
                double right = d / 2;
                while (true)
                {
                    var mid = left + (right - left) / 2;
                    var sqr = mid * mid;
                    if (IsSqr(d, sqr)) return mid;
                    double sqrWithDecimals;
                    if (HasReachedSqr(d, sqr, out sqrWithDecimals))
                    {
                        return sqrWithDecimals;
                    }

                    if (sqr > d)
                    {
                        right = mid - 1;
                    }
                    else
                    {
                        left = mid + 1;
                    }
                }
            }
        }
    }
}
