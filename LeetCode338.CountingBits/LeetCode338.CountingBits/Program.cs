using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode338.CountingBits
{
    class Program
    {
        static void Main(string[] args)
        {
            var s = new Solution();
            var r = s.CountBits(5);
        }

        public class Solution
        {
            public int[] CountBits(int num)
            {
                var r = new List<int>();
                for (int i = 0; i <= num; ++i)
                {
                    r.Add(GetBits(i));
                }
                return r.ToArray();
            }

            public int GetBits(int n)
            {
                var count = 0;
                while (n > 0)
                {
                    if ((n & 1) == 1) count++;
                    n = n >> 1;
                }
                return count;
            }
        }
    }
}
