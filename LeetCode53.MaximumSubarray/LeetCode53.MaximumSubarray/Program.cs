using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode53.MaximumSubarray
{
    class Program
    {
        //https://leetcode.com/problems/maximum-subarray/#/description
        static void Main(string[] args)
        {
            var s = new Solution();
            var r = s.MaxSubArray(new int[] { -2,1,-3,4,-1,2,1,-5,4});
            r = s.MaxSubArray(new int[] { -2,-3, -1, -5 });
            r = s.MaxSubArray(new int[] { -2, 0 });
        }

        public class Solution
        {
            public int MaxSubArray(int[] nums)
            {
                var maxSofar = int.MinValue;
                var localMax = 0;
                foreach (var i in nums)
                {
                    var sum = i + localMax;
                    if (sum > 0)
                    {
                        localMax = sum;
                    }
                    else
                    {
                        localMax = 0;
                    }
                    maxSofar = Math.Max(sum, maxSofar);
                }
                return maxSofar;
            }
        }
    }
}
