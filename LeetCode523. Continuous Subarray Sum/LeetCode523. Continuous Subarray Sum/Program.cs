using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode523.Continuous_Subarray_Sum
{
	class Program
	{
		static void Main(string[] args)
		{
			var s = new Solution();
			var r = s.CheckSubarraySum(new int[] { 23,2,6,4,7}, 6);
		}

		public class Solution
		{
			public bool CheckSubarraySum(int[] nums, int k)
			{
				var map = new Dictionary<int, int>();
				map.Add(0, -1);
				var sum = 0;
				for (int i = 0; i < nums.Length; ++i)
				{
					sum += nums[i];
					if (k != 0)
					{
						sum = sum % k;
					}
					var index = 0;
					if (map.TryGetValue(sum, out index))
					{
						if (i - index > 1) return true;
					}
					else
					{
						map.Add(sum, i);
					}
				}
				return false;
			}
		}
	}
}
