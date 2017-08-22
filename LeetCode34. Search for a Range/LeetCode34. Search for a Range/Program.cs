using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode34.Search_for_a_Range
{
    class Program
    {
        //https://leetcode.com/problems/search-for-a-range/description/
        static void Main(string[] args)
        {
            var s = new Solution();
            var r = s.SearchRange(new int[] { 5, 7, 7, 8, 8, 10 }, 8);
        }

        public class Solution
        {
            public int[] SearchRange(int[] nums, int target)
            {
                var resp = new int[] { -1, -1 };
                var l = 0;
                var r = nums.Length - 1;
                while (l <= r)
                {
                    var mid = l + (r - l) / 2;
                    if (nums[mid] == target)
                    {
                        if (mid == 0 || nums[mid - 1] != target) resp[0] = mid;
                        if (mid == nums.Length - 1 || nums[mid + 1] != target) resp[1] = mid;
                        if (resp[0] == -1) resp[0] = FindStart(nums, l, mid - 1, target);
                        if (resp[1] == -1) resp[1] = FindEnd(nums, mid + 1, r, target);
                        return resp;
                    }
                    else if (nums[mid] > target) r = mid - 1;
                    else l = mid + 1;
                }
                return resp;
            }

            public int FindStart(int[] nums, int l, int r, int target)
            {
                while (l <= r)
                {
                    var mid = l + (r - l) / 2;
                    if (nums[mid] == target)
                    {
                        if (mid == 0 || nums[mid - 1] != target)
                            return mid;
                        r = mid - 1;
                    }
                    else if (nums[mid] > target) r = mid - 1;
                    else l = mid + 1;
                }
                return -1;
            }
            public int FindEnd(int[] nums, int l, int r, int target)
            {
                while (l <= r)
                {
                    var mid = l + (r - l) / 2;
                    if (nums[mid] == target)
                    {
                        if (mid == nums.Length - 1 || nums[mid + 1] != target)
                            return mid;
                        l = mid + 1;
                    }
                    else if (nums[mid] > target) r = mid - 1;
                    else l = mid + 1;
                }
                return -1;
            }
        }
    }
}
