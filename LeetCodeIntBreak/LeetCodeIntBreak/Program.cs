using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCodeIntBreak
{
    class Program
    {
        static void Main(string[] args)
        {
            var s = new Solution();
            var r = s.IntegerBreak(10);
        }
        // https://leetcode.com/problems/integer-break/#/description

        //Given a positive integer n, break it into the sum of at least two positive integers and maximize the product of those integers.Return the maximum product you can get.
        //For example, given n = 2, return 1 (2 = 1 + 1); given n = 10, return 36 (10 = 3 + 3 + 4).
        //Note: You may assume that n is not less than 2 and not larger than 58.
        public class Solution
        {
            public int IntegerBreak(int n)
            {
                if (n == 2) return 1;
                if (n == 3) return 2;
                var visited = new Dictionary<int, int>();
                visited.Add(1, 1);
                visited.Add(2, 2);
                visited.Add(3, 3);
                return GetIntBreak(n, 4, visited);
            }

            public int GetIntBreak(int n, int curr, Dictionary<int, int> visited)
            {
                if (curr == n + 1) return visited[n];
                var maxSoFar = 0;
                for (int i = 1; i <= curr / 2; ++i)
                {
                    var x = visited[i];
                    var y = visited[curr - i];
                    var prod = x * y;
                    maxSoFar = Math.Max(prod, maxSoFar);
                }

                visited.Add(curr, maxSoFar);
                return GetIntBreak(n, curr + 1, visited);
            }
        }
    }
}
