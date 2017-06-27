using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode376.WiggleSubsequence
{
    class Program
    {
        //https://leetcode.com/problems/wiggle-subsequence/#/description
        static void Main(string[] args)
        {
            var s = new Solution();
            var r = s.WiggleMaxLength(new int[] { 1, 7, 4, 9, 2, 5 }); //5
            r = s.WiggleMaxLength(new int[] { 1, 17, 5, 10, 13, 15, 10, 5, 16, 8 });
            r = s.WiggleMaxLength(new int[] { 1,2,3,4,5,6,7,8,9 });
            r = s.WiggleMaxLength(new int[] { 0,0 });
        }
        public class Solution
        {
            public int WiggleMaxLength(int[] nums)
            {
                if (nums.Length <= 1) return nums.Length;
                var alt = new List<bool>();
                for (int i = nums.Length - 1; i >= 1; --i)
                {
                    if (nums[i] == nums[i - 1]) continue;
                    if (nums[i] - nums[i - 1] > 0) alt.Add(true);
                    else alt.Add(false);
                }
                if (alt.Count <= 1) return alt.Count + 1;
                var resp = 1;
                var prev = alt.FirstOrDefault();
                for (int i = 1; i < alt.Count; ++i)
                {
                    if (alt[i] != prev)
                    {
                        prev = alt[i];
                        resp++;
                    }
                }
                return resp + 1;
            }
        }
    }
}
