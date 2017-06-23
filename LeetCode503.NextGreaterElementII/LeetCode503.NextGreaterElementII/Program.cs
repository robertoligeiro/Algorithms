using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode503.NextGreaterElementII
{
    //https://leetcode.com/problems/next-greater-element-ii/#/description
    class Program
    {
        static void Main(string[] args)
        {
            var s = new Solution();
            var r = s.NextGreaterElements(new int[] { 1, 2, 1 });
        }
        public class Solution
        {
            public int[] NextGreaterElements(int[] nums)
            {
                var map = new Dictionary<int, int>();
                var resp = Enumerable.Repeat(-1, nums.Length).ToArray();
                var s = new Stack<int>();
                for (int i = 0; i < nums.Length * 2; ++i)
                {
                    if (s.Count == 0 || nums[s.Peek()] > nums[i % nums.Length])
                    {
                        s.Push(i % nums.Length);
                        continue;
                    }

                    while (s.Count > 0 && nums[s.Peek()] < nums[i % nums.Length])
                    {
                        var index = s.Pop();
                        if (!map.ContainsKey(index))
                        {
                            map.Add(index, nums[i % nums.Length]);
                        }
                    }
                    s.Push(i % nums.Length);
                }

                for (var i = 0; i < resp.Length; ++i)
                {
                    var val = 0;
                    if (map.TryGetValue(i, out val))
                    {
                        resp[i] = val;
                    }
                }

                return resp;
            }
        }
    }
}
