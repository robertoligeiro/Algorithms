using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode560.Subarray_Sum_Equals_K
{
	class Program
	{
		//https://leetcode.com/problems/subarray-sum-equals-k/description/
		static void Main(string[] args)
		{
			var s = new Solution();
			var r = s.SubarraySum(new int[] { 1, 1, 1 }, 2);
			//var r = s.SubarraySum(new int[] { 1, 2, 3 }, 3);
		}
		public class Solution
		{
			public int SubarraySum(int[] nums, int k)
			{
				var resp = 0;
				var m = new Dictionary<int,int>() { { 0, 1 } };
				var sum = 0;
				for (int i = 0; i < nums.Length; ++i)
				{
					sum += nums[i];
					var count = 0;
					if (m.TryGetValue(sum - k, out count))
					{
						resp+=count;
					}

					if (m.TryGetValue(sum, out count))
					{
						m[sum] = ++count;
					}
					else
					{
						m.Add(sum,1);
					}
				}
				return resp;
			}
		}
	}
}
