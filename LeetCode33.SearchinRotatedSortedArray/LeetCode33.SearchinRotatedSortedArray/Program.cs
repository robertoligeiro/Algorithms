using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode33.SearchinRotatedSortedArray
{
    class Program
    {
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
                if (nums == null || nums.Length == 0) return -1;
                var l = 0;
                var r = nums.Length - 1;
                int mid = 0;
                while (l < r)
                {
                    mid = l + (r - l) / 2;
                    if (nums[mid] > nums[r])
                    {
                        l = mid + 1;
                    }
                    else
                    {
                        r = mid;
                    }
                }
                int turn = l;
                if (turn > 0 && target >= nums[0] && target <= nums[turn - 1])
                {
                    l = 0; r = turn - 1;
                }
                else
                {
                    l = turn;
                    r = nums.Length - 1;
                }

                while (l <= r)
                {
                    mid = l + (r - l) / 2;
                    if (nums[mid] == target)
                    {
                        return mid;
                    }
                    else
                    if (nums[mid] > target)
                    {
                        r = mid - 1;
                    }
                    else l = mid + 1;
                }


                return -1;
            }
        }
    }
}
