using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode494.Target_Sum
{
    class Program
    {
        //https://leetcode.com/problems/target-sum/description/
        //memoization would help, but not implemented, leetcode accepts without it.
        static void Main(string[] args)
        {
            var s = new Solution();
            var r = s.FindTargetSumWays(new int[] { 1, 1, 1 }, 1);
        }

        public class Solution
        {
            public int FindTargetSumWays(int[] nums, int S)
            {
                return FindTargetSumWays(nums, S, 0, 0);
            }

            private int FindTargetSumWays(int[] nums, int tgt, int index, int acc)
            {
                if (index == nums.Length)
                {
                    return acc == tgt ? 1 : 0;
                }
                var ways = FindTargetSumWays(nums, tgt, index + 1, acc + nums[index]);
                ways += FindTargetSumWays(nums, tgt, index + 1, acc - nums[index]);
                return ways;
            }
        }
    }
}
