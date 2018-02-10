using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode209.Minimum_Size_Subarray_Sum
{
	class Program
	{
		static void Main(string[] args)
		{
			var s = new Solution();
			var r = s.MinSubArrayLen(7, new int[] { 2,3,1,2,4,3});
			//var r = s.MinSubArrayLen(15, new int[] {1, 2, 3,4,5 });
		}

		public class Solution
		{
			public int MinSubArrayLen(int s, int[] nums)
			{
				if (nums.Length == 0) return 0;
				int i = 0, j = 0, sum = 0, min = int.MaxValue;

				while (j < nums.Length)
				{
					sum += nums[j++];

					while (sum >= s)
					{
						min = Math.Min(min, j - i);
						sum -= nums[i++];
					}
				}
				return min == int.MaxValue ? 0 : min;
			}
		}
	}
}
