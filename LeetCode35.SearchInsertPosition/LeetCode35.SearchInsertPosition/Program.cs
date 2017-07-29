using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode35.SearchInsertPosition
{
    class Program
    {
        //https://leetcode.com/problems/search-insert-position/description/
        static void Main(string[] args)
        {
            var s = new Solution();
            var a = new int[] { 1, 3, 5, 6 };
            var r = s.SearchInsert(a, 5);
            r = s.SearchInsert(a, 2);
            r = s.SearchInsert(a, 7);
            r = s.SearchInsert(a, 0);
        }
        public class Solution
        {
            public int SearchInsert(int[] nums, int target)
            {
                var l = 0;
                var r = nums.Length - 1;
                while (l <= r)
                {
                    var mid = l + (r - l) / 2;
                    if (nums[mid] == target) return mid;
                    if (nums[mid] > target)
                    {
                        r = mid - 1;
                    }
                    else l = mid + 1;
                }

                return l;
            }
        }
    }
}
