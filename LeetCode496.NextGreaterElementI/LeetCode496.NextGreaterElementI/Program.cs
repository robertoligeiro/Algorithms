using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode496.NextGreaterElementI
{
    //https://leetcode.com/problems/next-greater-element-i/#/description
    class Program
    {
        static void Main(string[] args)
        {
            var s = new Solution();
            var r = s.NextGreaterElement(new int[] { 2, 4}, new int[] { 1, 2, 3, 4 });
        }

        public class Solution
        {
            public int[] NextGreaterElement(int[] findNums, int[] nums)
            {
                var resp = Enumerable.Repeat(-1, findNums.Length).ToArray();
                var map = new Dictionary<int, int>();
                var s = new Stack<int>();
                for (int i = 0; i < nums.Length; ++i)
                {
                    if (s.Count == 0 || s.Peek() > nums[i])
                    {
                        s.Push(nums[i]);
                        continue;
                    }
                    while (s.Count > 0 && s.Peek() < nums[i])
                    {
                        map.Add(s.Pop(), nums[i]);
                    }
                    s.Push(nums[i]);
                }

                for (var i = 0; i < findNums.Length; ++i)
                {
                    var val = 0;
                    if (map.TryGetValue(findNums[i], out val))
                    {
                        resp[i] = val;
                    }
                }

                return resp;
            }
        }
    }
}
