using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode414.ThirdMaximumNumber
{
    class Program
    {
        //https://leetcode.com/problems/third-maximum-number/#/description
        static void Main(string[] args)
        {
            var s = new Solution();
            var r = s.ThirdMax(new int[] { 5,4,6,7,1,3});
            r = s.ThirdMax(new int[] { 1, 2, 2, 5, 3, 5});
        }

        public class Solution
        {
            public int ThirdMax(int[] nums)
            {
                var max = new SortedSet<int>();
                foreach (var i in nums)
                {
                    if (max.Count < 3)
                    {
                        if (!max.Contains(i)) max.Add(i);
                        continue;
                    }

                    if (max.Min < i && !max.Contains(i))
                    {
                        max.Remove(max.Min);
                        max.Add(i);
                    }
                }

                return max.Count == 3 ? max.Min : max.Max;
            }
        }
    }
}
