using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode33.SearchinRotatedSortedArray
{
    class Program
    {
        //https://leetcode.com/problems/search-in-rotated-sorted-array/description/
        static void Main(string[] args)
        {
            var s = new Solution();
            var r = s.Search(new int[] { 4, 5, 6, 7, 8, 1, 2 }, 4);
            r = s.Search(new int[] { 1 }, 1);
            r = s.Search(new int[] { 4, 5, 6, 7, 8, 1, 2 }, 5);
            r = s.Search(new int[] { 4, 5, 6, 7, 8, 1, 2 }, 6);
            r = s.Search(new int[] { 4, 5, 6, 7, 8, 1, 2 }, 7);
            r = s.Search(new int[] { 4, 5, 6, 7, 8, 1, 2 }, 8);
            r = s.Search(new int[] { 4, 5, 6, 7, 8, 1, 2 }, 1);
            r = s.Search(new int[] { 4, 5, 6, 7, 8, 1, 2 }, 2);
            r = s.Search(new int[] { 5, 1, 2, 3, 4 }, 1);
            r = s.Search(new int[] { 4, 5, 6, 7, 0, 1, 2 }, 0);
        }

        public class Solution
        {
			public int Search(int[] nums, int target)
			{
				return Search(nums, target, 0, nums.Length - 1);
			}
			private int Search(int[] nums, int target, int l, int r)
			{
				if (l > r) return -1;
				while (l <= r)
				{
					var mid = l + (r - l) / 2;
					if (nums[mid] == target) return mid;
					if (nums[mid] < nums[r])
					{
						if (nums[mid] > target || nums[r] < target)
						{
							r = mid - 1;
						}
						else
						{
							l = mid + 1;
						}
					}
					else
					{
						// this solution also works, but worst case is O(n).
						//var ret = Search(nums, target, l, mid - 1);
						//if (ret != -1) return ret;
						//return Search(nums, target, mid + 1, r);
						if (target > nums[r] && target < nums[mid]) r = mid - 1;
						else r = mid - 1;
					}
				}
				return -1;
			}
		}
    }
}
