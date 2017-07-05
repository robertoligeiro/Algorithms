using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode29.DivideTwoIntegers
{
    class Program
    {
        //https://leetcode.com/problems/divide-two-integers/#/description
        //https://leetcode.com/problems/divide-two-integers/#/solutions
        static void Main(string[] args)
        {
            var s = new Solution();
            var r = s.Divide(15, 3);
        }

        public class Solution
        {
            public int Divide(int dividend, int divisor)
            {
                var resp = 0;

                while (dividend >= divisor)
                {
                    var temp = divisor;
                    var mult = 1;
                    while (dividend >= (temp << 1))
                    {
                        temp <<= 1;
                        mult <<= 1;
                    }

                    dividend -= temp;
                    resp += mult;
                }
                return resp;
            }
        }
    }
}
