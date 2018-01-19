using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode16._3Sum_Closest
{
	class Program
	{
		//https://leetcode.com/problems/3sum-closest/description/
		static void Main(string[] args)
		{
		}

		public class Solution
		{
			public int ThreeSumClosest(int[] nums, int target)
			{
				nums = nums.OrderBy(x => x).ToArray();
				var minDiff = int.MaxValue;
				var respSum = 0;
				var i = 0;
				var last = nums.Length - 1;
				while (i < last)
				{
					var l = i + 1;
					var r = last;
					while (l < r)
					{
						var sum = nums[i] + nums[l] + nums[r];
						var diff = Math.Abs(target - sum);
						if (diff < minDiff)
						{
							respSum = sum;
							minDiff = diff;
						}
						if (diff == 0) return respSum;
						if (sum > target)
						{
							r--;
						}
						else
						{
							l++;
						}
					}
					++i;
				}
				return respSum;
			}
		}
	}
}
