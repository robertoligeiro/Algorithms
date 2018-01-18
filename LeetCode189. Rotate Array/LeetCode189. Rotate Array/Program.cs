using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode189.Rotate_Array
{
	class Program
	{
		//https://leetcode.com/problems/rotate-array/description/
		static void Main(string[] args)
		{
		}

		public class Solution
		{
			public void Rotate(int[] nums, int k)
			{
				if (k == 0 || nums == null || nums.Length == 0 || nums.Length == 1) return;
				k = k % nums.Length;
				Rotate(nums, 0, nums.Length - 1);
				Rotate(nums, 0, k - 1);
				Rotate(nums, k, nums.Length - 1);
			}

			private void Rotate(int[] nums, int l, int r)
			{
				while (l < r)
				{
					var t = nums[l];
					nums[l] = nums[r];
					nums[r] = t;
					++l;--r;
				}
			}
		}
	}
}
