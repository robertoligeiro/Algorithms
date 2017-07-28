using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode153.FindMinimumInRotatedSortedArray
{
    //https://leetcode.com/problems/find-minimum-in-rotated-sorted-array/tabs/description
    class Program
    {
        static void Main(string[] args)
        {
            var s = new Solution();
            var r = s.FindMin(new int[] { 4, 5, 6, 7, 0, 1, 2 }); //resp: 0
        }
        public class Solution
        {
            public int FindMin(int[] nums)
            {
                var l = 0;
                var r = nums.Length - 1;
                while (l < r)
                {
                    var mid = l + (r - l) / 2;
                    if (nums[mid] > nums[r]) l = mid + 1;
                    else r = mid;
                }
                return nums[l];
            }
        }
    }
}
