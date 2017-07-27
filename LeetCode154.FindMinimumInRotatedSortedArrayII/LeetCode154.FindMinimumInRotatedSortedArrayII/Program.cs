using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode154.FindMinimumInRotatedSortedArrayII
{
    class Program
    {
        //https://leetcode.com/problems/find-minimum-in-rotated-sorted-array-ii/tabs/description
        static void Main(string[] args)
        {
            var s = new Solution();
            var r = s.FindMin(new int[] { 4, 5, 6, 7, 0, 1, 2 });
            r = s.FindMin(new int[] { 5,0,1,2,3,4});
            r = s.FindMin(new int[] { 1,3,3 });
        }

        public class Solution
        {
            public int FindMin(int[] nums)
            {
                var l = 0;
                var r = nums.Length - 1;
                return FindMin(nums, l, r);
            }

            public int FindMin(int[] nums, int l, int r)
            {
                if (l >= nums.Length) return nums[r];
                while (l < r)
                {
                    var mid = l + (r - l) / 2;
                    if (nums[mid] > nums[r])
                    {
                        l = mid + 1;
                    }
                    else if (nums[mid] < nums[r])
                    {
                        r = mid;
                    }
                    else // mid == r
                    {
                        return Math.Min(FindMin(nums, l, mid), FindMin(nums, mid + 1, r));
                    }
                }
                return nums[l];
            }
        }
    }
}
