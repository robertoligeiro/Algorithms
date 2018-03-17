using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode84.Largest_Rectangle_in_Histogram
{
	class Program
	{
		//https://leetcode.com/problems/largest-rectangle-in-histogram/description/
		static void Main(string[] args)
		{
			var s = new Solution();
			var r = s.LargestRectangleArea(new int[] { 2, 1, 5, 6, 2, 3 });
		}
		public class Solution
		{
			public int LargestRectangleArea(int[] heights)
			{
				var maxArea = 0;
				var s = new Stack<int>();
				var len = heights.Length;
				for (int i = 0; i <= len; i++)
				{
					int h = (i == len ? 0 : heights[i]);
					if (s.Count == 0 || h >= heights[s.Peek()])
					{
						s.Push(i);
					}
					else
					{
						int tp = s.Pop();
						var localArea = heights[tp] * (s.Count == 0 ? i : i - 1 - s.Peek());
						maxArea = Math.Max(maxArea, localArea);
						i--;
					}
				}

				return maxArea;
			}
		}
	}
}
