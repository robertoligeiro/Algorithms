using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode238.Product_of_Array_Except_Self
{
	class Program
	{
		//https://leetcode.com/problems/product-of-array-except-self/description/
		static void Main(string[] args)
		{
		}
		public class Solution
		{
			public int[] ProductExceptSelf(int[] nums)
			{
				var resp = new int[nums.Length];
				resp[0] = 1;
				for (int i = 1; i < nums.Length; ++i)
				{
					resp[i] = resp[i - 1] * nums[i - 1];
				}
				var r = 1;
				for (int i = nums.Length - 1; i >= 0; --i)
				{
					resp[i] = resp[i] * r;
					r *= nums[i];
				}
				return resp;
			}
		}
	}
}
