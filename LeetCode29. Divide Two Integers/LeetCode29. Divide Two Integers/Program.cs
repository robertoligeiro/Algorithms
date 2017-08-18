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
            var r1 = s.Divide(8, 2);
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
                var resp = 0;
                while (dividend >= divisor)
                {
                    var tempDivisor = divisor;
                    var mult = 1;
                    while (dividend >= (tempDivisor << 1))
                    {
                        tempDivisor <<= 1;
                        mult <<= 1;
                    }
                    dividend -= tempDivisor;
                    resp += mult;
                }
                return resp;
            }
        }
    }
}
