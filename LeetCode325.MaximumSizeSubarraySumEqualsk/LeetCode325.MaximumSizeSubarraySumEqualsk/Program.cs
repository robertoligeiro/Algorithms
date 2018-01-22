using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode325.MaximumSizeSubarraySumEqualsk
{
	class Program
	{
		//https://leetcode.com/problems/maximum-size-subarray-sum-equals-k/description/
		static void Main(string[] args)
		{
		}

		public class Solution
		{
			public int MaxSubArrayLen(int[] nums, int k)
			{
				var max = 0;
				var sum = 0;
				var m = new Dictionary<int,int>();
				for (int i = 0; i < nums.Length; ++i)
				{
					sum += nums[i];
					if (sum == k)
					{
						max = i + 1;
					}
					else if(m.ContainsKey(sum-k))
					{
						max = Math.Max(max, i - m[sum - k]);
					}
					if (!m.ContainsKey(sum)) m.Add(sum, i);
				}
				return max;
			}
		}
	}
}
