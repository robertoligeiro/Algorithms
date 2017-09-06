using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode41.First_Missing_Positive
{
    class Program
    {
        //https://leetcode.com/problems/first-missing-positive/description/
        static void Main(string[] args)
        {
            var s = new Solution();
            var r = s.FirstMissingPositive(new int[] { 3,4,-1,-2, -3, 1,2 });
        }

        public class Solution
        {
            public int FirstMissingPositive(int[] nums)
            {
                if (nums.Length == 0) return 1;
                for (int i = 0; i < nums.Length; ++i)
                {
                    var swapIndex = nums[i] - 1;
                    while (nums[i] > 0 && nums[i] <= nums.Length && nums[swapIndex] != nums[i])
                    {
                        swapIndex = nums[i] - 1;
                        var t = nums[i];
                        nums[i] = nums[swapIndex];
                        nums[swapIndex] = t;
                    }
                }
                for (int i = 0; i < nums.Length; ++i)
                    if (nums[i] != i + 1)
                        return i + 1;

                return nums.Length +  1;
            }
        }
    }
}
