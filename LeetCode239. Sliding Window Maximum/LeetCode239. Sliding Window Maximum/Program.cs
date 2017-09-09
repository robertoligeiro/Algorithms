using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode239.Sliding_Window_Maximum
{
    class Program
    {
        //https://leetcode.com/problems/sliding-window-maximum/description/
        static void Main(string[] args)
        {
            var s = new Solution();
            //var r = s.MaxSlidingWindow(new int[] { 1, 3, -1, -3, 5, 3, 6, 7 }, 3);
            //var r = s.MaxSlidingWindow(new int[] { 4,-2 }, 2);
            var r = s.MaxSlidingWindow(new int[] { 1}, 1);
            var r = s.MaxSlidingWindow(new int[] { 1 , -1}, 1);
        }

        public class Solution
        {
            public int[] MaxSlidingWindow(int[] nums, int k)
            {
                if (nums == null || nums.Length == 0 || k == 0) return new int[0];
                var deque = new LinkedList<Tuple<int,int>>();
                var max = int.MinValue;
                for (int i = 0; i < k; ++i)
                {
                    deque.AddLast(new Tuple<int, int>(nums[i], i));
                    max = Math.Max(max, nums[i]);
                }
                var resp = new List<int>();
                for (int i = k; i <= nums.Length; ++i)
                {
                    while (deque.Count > 0 && deque.First().Item1 < max)
                    {
                        deque.RemoveFirst();
                    }
                    resp.Add(max);

                    if (deque.Count > 0 && deque.First().Item2 == i - k)
                    {
                        deque.RemoveFirst();
                        max = int.MinValue;
                        if(deque.Count > 0)
                            max = deque.Max().Item1;
                    }
                    if (i < nums.Length)
                    {
                        deque.AddLast(new Tuple<int, int>(nums[i], i));
                        max = Math.Max(max, nums[i]);
                    }
                }
                return resp.ToArray();
            }
        }

        public class Solution2
        {
            public int[] MaxSlidingWindow(int[] nums, int k)
            {
                if (nums == null || nums.Length == 0 || k == 0) return new int[0];
                var heap = new List<int>();
                var deque = new LinkedList<int>();
                for (int i = 0; i < k; ++i)
                {
                    heap.Add(nums[i]);
                    deque.AddLast(nums[i]);
                }
                var resp = new List<int>();
                for (int i = k; i <= nums.Length; ++i)
                {
                    heap.Sort();
                    resp.Add(heap.Last());
                    var toRemove = deque.First();
                    deque.RemoveFirst();
                    heap.Remove(toRemove);
                    if (i < nums.Length)
                    {
                        heap.Add(nums[i]);
                        deque.AddLast(nums[i]);
                    }
                }
                return resp.ToArray();
            }
        }
    }
}
