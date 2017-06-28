using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode152.MaximumProductSubarray
{
    class Program
    {
        //https://leetcode.com/problems/maximum-product-subarray/#/description
        //solution is based from here: https://leetcode.com/problems/maximum-product-subarray/#/solutions
        //
        static void Main(string[] args)
        {
            var s = new Solution();
            var r = s.MaxProduct(new int[] { 2,3,-2,-1});
        }

        public class Solution
        {
            public int MaxProduct(int[] nums)
            {
                if (nums.Length == 0)
                {
                    return 0;
                }

                int maxherepre = nums[0];
                int minherepre = nums[0];
                int maxsofar = nums[0];
                int maxhere, minhere;

                for (int i = 1; i < nums.Length; i++)
                {
                    maxhere = Math.Max(Math.Max(maxherepre * nums[i], minherepre * nums[i]), nums[i]);
                    minhere = Math.Min(Math.Min(maxherepre * nums[i], minherepre * nums[i]), nums[i]);
                    maxsofar = Math.Max(maxhere, maxsofar);
                    maxherepre = maxhere;
                    minherepre = minhere;
                }
                return maxsofar;
            }
        }
    }
}
