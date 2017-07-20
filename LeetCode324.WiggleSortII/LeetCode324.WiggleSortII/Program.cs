using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode324.WiggleSortII
{
    class Program
    {
        //https://leetcode.com/problems/wiggle-sort-ii/#/description
        // solution is not working.
        static void Main(string[] args)
        {
            var s = new Solution();
            //var n = new int[] { 1, 5, 1, 1, 6, 4 };
            //s.WiggleSort(n);

            var n = new int[] { 1, 3, 2, 2, 3, 1 };
            s.WiggleSort(n);
        }
        public class Solution
        {
            public void WiggleSort(int[] nums)
            {
                int median = FindK(nums, (nums.Length - 1) / 2);
                var l = 1;
                var r = nums.Length - 2;
                while (l < r)
                {
                    var t = nums[l];
                    nums[l] = nums[r];
                    nums[r] = t;
                    l += 2;
                    r -= 2;
                }
            }
            private int FindK(int[] a, int k)
            {
                return FindK(a, a.Length - k + 1, 0, a.Length - 1);
            }
            private int FindK(int[] a, int k, int left, int right)
            {
                int p = Partition(a, left, right);
                if (p == k - 1)
                {
                    return p;
                }
                if (p > k - 1)
                {
                    return FindK(a, k, left, p - 1);
                }

                return FindK(a, k, p + 1, right);
            }

            private int Partition(int[] nums, int l, int r)
            {
                var pivot = nums[l];
                var lo = l;
                var hi = r;
                lo++;
                while (true)
                {
                    while (lo < r)
                    {
                        if (nums[lo] > pivot) break;
                        lo++;
                    }
                    while (hi > l)
                    {
                        if (nums[hi] <= pivot) break;
                        hi--;
                    }

                    if (hi < lo) break;
                    var t = nums[hi];
                    nums[hi] = nums[lo];
                    nums[lo] = t;
                    hi--;
                    lo++;
                }

                nums[l] = nums[hi];
                nums[hi] = pivot;
                return hi;
            }
        }
    }
}
