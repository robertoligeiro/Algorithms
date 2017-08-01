using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode81.SearchinRotatedSortedArrayII
{
    class Program
    {
        //https://leetcode.com/problems/search-in-rotated-sorted-array-ii/description/
        static void Main(string[] args)
        {
            var s = new Solution();
            var r = false;
            r = s.Search(new int[] { 4, 5, 6, 7, 0, 1, 2 }, 4); //true
            r = s.Search(new int[] { 4, 5, 6, 7, 0, 1, 2 }, 5); //true
            r = s.Search(new int[] { 4, 5, 6, 7, 0, 1, 2 }, 6); //true
            r = s.Search(new int[] { 4, 5, 6, 7, 0, 1, 2 }, 7); //true
            r = s.Search(new int[] { 4, 5, 6, 7, 0, 1, 2 }, 0); //true
            r = s.Search(new int[] { 4, 5, 6, 7, 0, 1, 2 }, 1); //true
            r = s.Search(new int[] { 4, 5, 6, 7, 0, 1, 2 }, 2); //true
            r = s.Search(new int[] { 4, 5, 6, 7, 0, 1, 2 }, 3); //false

            r = s.Search(new int[] { 6, 7, 1, 2, 2, 2, 2, 2, 2, 3, 4, 5 }, 8); //false
            r = s.Search(new int[] { 6, 7, 1, 2, 2, 2, 2, 2, 2, 3, 4, 5 }, 6); //true
            r = s.Search(new int[] { 6, 7, 1, 2, 2, 2, 2, 2, 2, 3, 4, 5 }, 7); //true
            r = s.Search(new int[] { 6, 7, 1, 2, 2, 2, 2, 2, 2, 3, 4, 5 }, 1); //true
            r = s.Search(new int[] { 6, 7, 1, 2, 2, 2, 2, 2, 2, 3, 4, 5 }, 2); //true
            r = s.Search(new int[] { 6, 7, 1, 2, 2, 2, 2, 2, 2, 3, 4, 5 }, 3); //true
            r = s.Search(new int[] { 6, 7, 1, 2, 2, 2, 2, 2, 2, 3, 4, 5 }, 4); //true
            r = s.Search(new int[] { 6, 7, 1, 2, 2, 2, 2, 2, 2, 3, 4, 5 }, 5); //true
        }
        public class Solution
        {
            public bool Search(int[] nums, int target)
            {
                return Search(nums, target, 0, nums.Length - 1);
            }
            private bool Search(int[] nums, int target, int l, int r)
            {
                if (l > r) return false;
                while (l <= r)
                {
                    var mid = l + (r - l) / 2;
                    if (nums[mid] == target) return true;
                    if (nums[mid] < nums[r])
                    {
                        if (nums[mid] < target && nums[r] >= target)
                        {
                            l = mid + 1;
                        }
                        else
                        {
                            r = mid - 1;
                        }
                    }
                    else
                    {
                        return Search(nums, target, l, mid - 1) || Search(nums, target, mid + 1, r);
                    }
                }
                return false;
            }
        }
    }
}
