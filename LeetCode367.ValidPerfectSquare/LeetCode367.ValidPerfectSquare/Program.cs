using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode367.ValidPerfectSquare
{
    class Program
    {
        //https://leetcode.com/problems/valid-perfect-square/#/description
        static void Main(string[] args)
        {
            var s = new Solution();
            var r = s.IsPerfectSquare(2);
            r = s.IsPerfectSquare(3);
            r = s.IsPerfectSquare(4);
            r = s.IsPerfectSquare(5);
            r = s.IsPerfectSquare(6);
            r = s.IsPerfectSquare(7);
            r = s.IsPerfectSquare(8);
            r = s.IsPerfectSquare(14);
            r = s.IsPerfectSquare(16);
            r = s.IsPerfectSquare(81);
            r = s.IsPerfectSquare(82);
            r = s.IsPerfectSquare(100);
        }

        public class Solution
        {
            public bool IsPerfectSquare(int num)
            {
                if (num == 0) return true;
                if (num == 1) return true;
                var l = 1;
                var r = num;
                while (l <= r)
                {
                    var mid = l + (r - l) / 2;
                    var sqr = mid * mid;
                    if (sqr == num) return true;
                    if (sqr > num) r = mid - 1;
                    else l = mid + 1;
                }
                return false;
            }
        }
    }
}
