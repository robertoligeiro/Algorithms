using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode689.MaximumSumof3NonOverlapSubarrays
{
	class Program
	{
		static void Main(string[] args)
		{
			var s = new Solution();
			var r = s.MaxSumOfThreeSubarrays(new int[] { 1, 2, 1, 2, 6, 7, 5, 1 }, 2);
		}

		public class Solution
		{
			public int[] MaxSumOfThreeSubarrays(int[] nums, int k)
			{
				//get sum window
				var sum = 0;
				var W = new List<int>();
				for (int i = 0; i < nums.Length; ++i)
				{
					sum += nums[i];
					if (i >= k)
					{
						sum -= nums[i - k];
					}
					if (i >= k - 1)
					{
						W.Add(sum);
					}
				}

				var left = new List<int>();
				var best = 0;
				for (int i = 0; i < W.Count; ++i)
				{
					if (W[i] > W[best])
					{
						best = i;
					}
					left.Add(best);
				}

				var right = new List<int>();
				best = W.Count - 1;
				for (int i = W.Count - 1; i >= 0; --i)
				{
					if (W[i] >= W[best])
					{
						best = i;
					}
					right.Add(best);
				}
				// remember, right has to be in reversed order
				right.Reverse(); 

				var resp = new int[] { -1, -1, -1 };
				for (int first = k; first < W.Count - k; ++first)
				{
					var second = left[first - k];
					var third = right[first + k];
					if (resp[0] == -1 ||
						W[second] + W[first] + W[third] > W[resp[0]] + W[resp[1]] + W[resp[2]])
					{
						resp[0] = second;
						resp[1] = first;
						resp[2] = third;
					}
				}
				return resp;
			}
		}
	}
}
