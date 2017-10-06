using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode29.Divide_Two_Integers
{
    class Program
    {
        static void Main(string[] args)
        {
            var snaive = new SolutionNaive();
            var r = snaive.Divide(8, 2);

            var s = new Solution();
            var r1 = s.Divide(-2147483648, -1);
        }
        public class SolutionNaive
        {
            public int Divide(int dividend, int divisor)
            {
                var resp = 0;
                while (dividend >= divisor)
                {
                    dividend -= divisor;
                    resp++;
                }
                return resp;
            }
        }

        public class Solution
        {
            public int Divide(int dividend, int divisor)
            {
                long tdividend = dividend;
                long tdivisor = divisor;
                var isNeg = false;
                if (dividend < 0 && divisor < 0)
                {
                    tdividend = Math.Abs(tdividend);
                    tdivisor = Math.Abs(tdivisor);
                }
                else if (dividend < 0 || divisor < 0)
                {
                    tdividend = Math.Abs(tdividend);
                    tdivisor = Math.Abs(tdivisor);
                    isNeg = true;
                }
                if (tdivisor == 1)
                {
                    if (isNeg)
                    {
                        return (int)-tdividend;
                    }
                    return (int)tdividend;
                }
                var resp = 0;
                while (tdividend >= tdivisor)
                {
                    var tempDivisor = tdivisor;
                    var mult = 1;
                    while (tdividend >= (tempDivisor << 1))
                    {
                        tempDivisor <<= 1;
                        mult <<= 1;
                    }
                    tdividend -= tempDivisor;
                    resp += mult;
                }
                return isNeg? -resp:resp;
            }
        }
    }
}
