using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode456._132Pattern
{
    class Program
    {
        //https://leetcode.com/problems/132-pattern/description/
        static void Main(string[] args)
        {
            var s = new Solution();
            var r = s.Find132pattern(new int[] { 3,1,4,2});
        }
        public class Solution
        {
            public bool Find132pattern(int[] nums)
            {
                if (nums == null || nums.Length <= 2) return false;
                var mins = new int[nums.Length];
                mins[0] = nums[0];
                for (int i = 1; i < mins.Length; ++i)
                {
                    mins[i] = Math.Min(mins[i - 1], nums[i]);
                }

                var s = new Stack<int>();
                for (int i = nums.Length - 1; i >= 0; --i)
                {
                    // if there's anything that is smaller than current before curr
                    if (nums[i] > mins[i])
                    {
                        // remove everything that now is smaller than curr min
                        while (s.Count > 0 && s.Peek() <= mins[i])
                        {
                            s.Pop();
                        }

                        // if curr is bigger than the bigger that came after
                        if (s.Count > 0 && s.Peek() < nums[i]) return true;
                        s.Push(nums[i]);
                    }
                }
                return false;
            }
        }
    }
}
