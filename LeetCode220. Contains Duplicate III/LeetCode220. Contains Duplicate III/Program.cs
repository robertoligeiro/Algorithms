using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode220.Contains_Duplicate_III
{
    //https://leetcode.com/problems/contains-duplicate-iii/description/
    class Program
    {
        static void Main(string[] args)
        {
            var s = new Solution();
            var r = s.ContainsNearbyAlmostDuplicate(new int[] { 4, 2, 0, 5, 6 }, 2, 1);
            r = s.ContainsNearbyAlmostDuplicate(new int[] { -2147483648, -2147483647 }, 3, 3);
            r = s.ContainsNearbyAlmostDuplicate(new int[] { 4,1,6,3 }, 100, 1);
        }

        public class Solution
        {
            public bool ContainsNearbyAlmostDuplicate(int[] nums, int k, int t)
            {
                if (k == 0) return false;
                var m = new SortedSet<long>();

                for (int i = 0; i < nums.Length; ++i)
                {
                    long max = 0;
                    long min = 0;
                    var hasMin = false;
                    var hasMax = false;
                    if (m.Count > 0)
                    {
                        var l = m.Where(x => x <= nums[i] + t);
                        min = l.LastOrDefault();
                        if (l.ToList().Count > 0) hasMin = true; 
                    }
                    if (m.Count > 0)
                    {
                        var l = m.Where(x => x >= nums[i] - t);
                        max = l.FirstOrDefault();
                        if (l.ToList().Count > 0) hasMax = true;
                    }

                    if ((hasMin && min >= nums[i]) || (hasMax && max <= nums[i])) return true;
                    if (m.Count >= k)
                    {
                        m.Remove(nums[i - k]);
                    }
                    if (!m.Contains(nums[i])) m.Add(nums[i]);
                }
                return false;
            }
        }
    }
}
