using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode645.Set_Mismatch
{
	class Program
	{
		//https://leetcode.com/problems/set-mismatch/description/
		static void Main(string[] args)
		{
			var s = new Solution();
			var r = s.FindErrorNums(new int[] { 1, 2, 2, 4 }); 
		}
		public class Solution
		{
			public int[] FindErrorNums(int[] nums)
			{
				var resp = new int[2];
				for (int i = 0; i < nums.Length; ++i)
				{
					var index = Math.Abs(nums[i]) - 1;
					if (nums[index] < 0)
					{
						resp[0] = index + 1;
					}
					else
					{
						nums[index] = -nums[index];
					}
				}

				for (int i = 0; i < nums.Length; ++i)
				{
					if (nums[i] > 0)
					{
						resp[1] = i + 1;
						return resp;
					}
				}
				return resp;
			}
		}
	}
}
