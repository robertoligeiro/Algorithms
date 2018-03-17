using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode565.Array_Nesting
{
	class Program
	{
		//https://leetcode.com/problems/array-nesting/description/
		static void Main(string[] args)
		{
			var s = new Solution();
			var r = s.ArrayNesting(new int[] { 5,4,0,3,1,6,2});
		}
		public class Solution
		{
			public int ArrayNesting(int[] nums)
			{
				var h = new HashSet<int>();
				var resp = 0;
				for (int i = 0; i < nums.Length; ++i)
				{
					var seed = i;
					var count = 0;
					while (h.Add(seed))
					{
						++count;
						seed = nums[seed];
					}
					resp = Math.Max(resp, count);
				}
				return resp;
			}
		}
	}
}
