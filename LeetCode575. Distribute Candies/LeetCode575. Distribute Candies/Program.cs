using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode575.Distribute_Candies
{
    class Program
    {
        static void Main(string[] args)
        {
            var s = new Solution();
            var r = s.DistributeCandies(new int[] { 0, 0, 14, 0, 10, 0, 0, 0});
        }

        public class Solution
        {
            public int DistributeCandies(int[] candies)
            {
                var k1 = new HashSet<int>();
                foreach(var i in candies)
                {
                    k1.Add(i);
                }
                return Math.Min(k1.Count, candies.Length / 2);
            }
        }
    }
}
