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
            var r = s.MaxSlidingWindow(new int[] { 1, 3, -1, -3, 5, 3, 6, 7 }, 3);
			//var r = s.MaxSlidingWindow(new int[] { 1,3,1,2,0,5 }, 3);
			//var r = s.MaxSlidingWindow(new int[] { 4,-2 }, 2);
			//var r = s.MaxSlidingWindow(new int[] { 7, 2, 4 }, 2);
			//var r = s.MaxSlidingWindow(new int[] { 1}, 1);
			//var r = s.MaxSlidingWindow(new int[] { 1 , -1}, 1);
		}

		public class Solution
		{
			private LinkedList<int> deque = new LinkedList<int>();
			public int[] MaxSlidingWindow(int[] nums, int k)
			{
				if (nums == null || nums.Length == 0 || k == 0) return new int[0];
				
				for (int i = 0; i < k; ++i)
				{
					AddToDeque(nums[i]);
				}

				var resp = new List<int>() { deque.First() };
				for (int i = k; i < nums.Length; ++i)
				{
					if (deque.First() == nums[i-k]) deque.RemoveFirst();
					AddToDeque(nums[i]);
					resp.Add(deque.First());
				}
				return resp.ToArray();
			}

			private void AddToDeque(int i)
			{
				if (deque.Count == 0 || i <= deque.Last())
				{
					deque.AddLast(i);
				}
				else
				{
					var newDeque = new LinkedList<int>();
					foreach(var e in deque)
					{
						if (e >= i)
						{
							newDeque.AddLast(e);
						}
						else break;
					}
					newDeque.AddLast(i);
					deque = newDeque;
				}
			}
		}
    }
}
