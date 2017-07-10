using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode507.PerfectNumber
{
    class Program
    {
        //https://leetcode.com/problems/perfect-number/#/description
        static void Main(string[] args)
        {
            var s = new Solution();
            var r = s.CheckPerfectNumber(28);
            r = s.CheckPerfectNumber(100000000);
        }
        public class Solution
        {
            public bool CheckPerfectNumber(int num)
            {
                if (num == 1) return false;
                if (num % 2 == 1) return false;
                var sum = 1;
                for (int i = 2; i <= Math.Sqrt(num); ++i)
                {
                    if (num % i == 0)
                    {
                        sum += (i + num / i);
                    }
                    if (sum > num) return false;
                }
                return sum == num;
            }
        }
    }
}
