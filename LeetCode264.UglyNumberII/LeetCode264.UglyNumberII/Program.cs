using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode264.UglyNumberII
{
    //https://leetcode.com/problems/ugly-number-ii/#/description
    //Solution: http://www.geeksforgeeks.org/ugly-numbers/
    class Program
    {
        static void Main(string[] args)
        {
            var s = new Solution();
            var r = s.NthUglyNumber(10);
        }
        public class Solution
        {
            public int NthUglyNumber(int n)
            {
                if (n == 1) return 1;
                var ugly = new List<int>();
                ugly.Add(1);
                var u2 = 0;
                var u3 = 0;
                var u5 = 0;
                var nextUgly2 = NextUglyForMult(ugly, 2, u2);
                var nextUgly3 = NextUglyForMult(ugly, 3, u3);
                var nextUgly5 = NextUglyForMult(ugly, 5, u5);
                while (ugly.Count < n)
                {
                    var sorted = new List<int>();
                    sorted.Add(nextUgly2);
                    sorted.Add(nextUgly3);
                    sorted.Add(nextUgly5);
                    sorted.Sort();
                    var next = sorted[0];
                    ugly.Add(next);
                    if (next == nextUgly2)
                    {
                        u2++;
                        nextUgly2 = NextUglyForMult(ugly, 2, u2);
                    }
                    if (next == nextUgly3)
                    {
                        u3++;
                        nextUgly3 = NextUglyForMult(ugly, 3, u3);
                    }
                    if (next == nextUgly5)
                    {
                        u5++;
                        nextUgly5 = NextUglyForMult(ugly, 5, u5);
                    }
                }
                return ugly.Last();
            }

            private int NextUglyForMult(List<int> ugly, int mult, int index)
            {
                return ugly[index] * mult;
            }
        }
    }
}
