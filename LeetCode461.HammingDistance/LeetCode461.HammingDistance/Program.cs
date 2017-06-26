using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode461.HammingDistance
{
    class Program
    {
        /https://leetcode.com/problems/hamming-distance/#/description
        static void Main(string[] args)
        {
            var s = new Solution();
            var r = s.HammingDistance(1, 4);
        }
        public class Solution
        {
            public int HammingDistance(int x, int y)
            {
                var xor = x ^ y;
                var count = 0;
                while (xor > 0)
                {
                    count += (xor & 1); 
                    xor >>= 1;
                }
                return count;
            }
        }
    }
}
