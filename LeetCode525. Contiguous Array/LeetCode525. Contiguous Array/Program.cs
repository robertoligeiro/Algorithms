using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode525.Contiguous_Array
{
	class Program
	{
		//https://leetcode.com/problems/contiguous-array/description/
		static void Main(string[] args)
		{
			var s = new Solution();
			var r = s.FindMaxLength(new int[] { 0,1,0});
		}
		public class Solution
		{
			public int FindMaxLength(int[] nums)
			{
				var map = new Dictionary<int, int>() { { 0, -1 } };
				var count = 0;
				var max = 0;
				for (int i = 0; i < nums.Length; ++i)
				{
					count += nums[i] == 1 ? 1 : -1;
					var index = 0;
					if (map.TryGetValue(count, out index))
					{
						max = Math.Max(max, i - index);
					}
					else
					{
						map.Add(count, i);
					}
				}
				return max;
			}
		}
	}
}
