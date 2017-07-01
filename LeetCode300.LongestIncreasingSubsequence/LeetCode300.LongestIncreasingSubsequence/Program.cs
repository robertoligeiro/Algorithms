using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode300.LongestIncreasingSubsequence
{
    class Program
    {
        //https://leetcode.com/problems/longest-increasing-subsequence/#/description
        static void Main(string[] args)
        {
            var s = new Solution();
            var r = s.LengthOfLIS(new int[] { 10, 9, 2, 5, 3, 7, 101, 18 });
        }

        public class Solution
        {
            public int LengthOfLIS(int[] nums)
            {
                if (nums.Length == 0) return 0;
                var max = 1;
                var increaseCounterArray = Enumerable.Repeat(1, nums.Length).ToArray();
                var i = 1;
                while (i < nums.Length)
                {
                    var j = 0;
                    while (j < i)
                    {
                        if (nums[j] < nums[i])
                        {
                            increaseCounterArray[i] = Math.Max(increaseCounterArray[i], increaseCounterArray[j] + 1);
                            max = Math.Max(max, increaseCounterArray[i]);
                        }
                        ++j;
                    }
                    ++i;
                }
                return max;
            }
        }
    }
}
