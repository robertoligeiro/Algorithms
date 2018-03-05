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
				var left = SearchRange(nums, target, true);
				if (left == nums.Length || nums[left] != target) return resp;
				var right = SearchRange(nums, target, false) - 1;
				resp[0] = left;
				resp[1] = right;
				return resp;
            }

            private int SearchRange(int[] nums, int target, bool goLeft)
            {
				var l = 0;
				var r = nums.Length - 1;
                while (l <= r)
                {
                    var mid = l + (r - l) / 2;
					if (nums[mid] > target) r = mid - 1;
					else if (nums[mid] < target) l = mid + 1;
					else // ==
					{
						if (goLeft)
						{
							r = mid - 1;
						}
						else l = mid + 1;
					}
                }
                return l;
            }
        }
    }
}
