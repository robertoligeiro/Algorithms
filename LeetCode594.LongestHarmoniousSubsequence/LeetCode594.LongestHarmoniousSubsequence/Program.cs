using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode594.LongestHarmoniousSubsequence
{
    //https://leetcode.com/problems/longest-harmonious-subsequence/#/description
    class Program
    {
        static void Main(string[] args)
        {
        }

        public class Solution
        {
            public int FindLHS(int[] nums)
            {
                var map = new Dictionary<int, int>();
                foreach (var i in nums)
                {
                    var count = 0;
                    if (!map.TryGetValue(i, out count))
                    {
                        map.Add(i, 1);
                    }
                    else map[i] = ++count;
                }
                var max = 0;
                foreach (var t in map)
                {
                    var count = 0;
                    if (map.TryGetValue(t.Key + 1, out count))
                    {
                        max = Math.Max(max, map[t.Key] + map[t.Key + 1]);
                    }
                }
                return max;
            }
        }
    }
}
