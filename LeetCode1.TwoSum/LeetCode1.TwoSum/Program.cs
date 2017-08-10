using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode1.TwoSum
{
    class Program
    {
        //https://leetcode.com/problems/two-sum/description/
        static void Main(string[] args)
        {
            var s = new Solution();
            var r = s.TwoSum(new int[] { 2, 7, 11, 15 }, 9);
            r = s.TwoSum(new int[] { 230, 863, 916, 585, 981, 404, 316, 785, 88, 12, 70, 435, 384, 778, 887, 755, 740, 337, 86, 92, 325, 422, 815, 650, 920, 125, 277, 336, 221, 847, 168, 23, 677, 61, 400, 136, 874, 363, 394, 199, 863, 997, 794, 587, 124, 321, 212, 957, 764, 173, 314, 422, 927, 783, 930, 282, 306, 506, 44, 926, 691, 568, 68, 730, 933, 737, 531, 180, 414, 751, 28, 546, 60, 371, 493, 370, 527, 387, 43, 541, 13, 457, 328, 227, 652, 365, 430, 803, 59, 858, 538, 427, 583, 368, 375, 173, 809, 896, 370, 789 }, 542);
        }
        public class Solution
        {
            public int[] TwoSum(int[] nums, int target)
            {
                var m = new Dictionary<int, int>();
                for (int i = 0; i < nums.Length; ++i)
                {
                    var index = 0;
                    var diff = target - nums[i];
                    if (m.TryGetValue(diff, out index))
                    {
                        return new int[] { index, i };
                    }
                    if(!m.ContainsKey(nums[i])) m.Add(nums[i], i);
                }
                return null;
            }
        }
    }
}
