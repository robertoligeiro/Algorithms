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
				var memo = new Dictionary<string, int>();
                return FindTargetSumWays(nums, S, 0, 0, memo);
            }

            private int FindTargetSumWays(int[] nums, int tgt, int index, int acc, Dictionary<string, int> memo)
            {
				var encoding = index + "->" + acc;
				var ways = 0;
				if (memo.TryGetValue(encoding, out ways)) return ways; 
                if (index == nums.Length)
                {
                    return acc == tgt ? 1 : 0;
                }
                ways = FindTargetSumWays(nums, tgt, index + 1, acc + nums[index], memo);
                ways += FindTargetSumWays(nums, tgt, index + 1, acc - nums[index], memo);
				memo.Add(encoding, ways);
                return ways;
            }
        }
    }
}
