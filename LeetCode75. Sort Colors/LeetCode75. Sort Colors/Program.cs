using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode75.Sort_Colors
{
	class Program
	{
		//https://leetcode.com/problems/sort-colors/description/
		static void Main(string[] args)
		{
		}
		public class Solution
		{
			public void SortColors(int[] nums)
			{
				var nextWrite = 0;
				for (int i = 0; i < nums.Length; ++i)
				{
					if (nums[i] == 0)
					{
						nums[i] = nums[nextWrite];
						nums[nextWrite++] = 0;
					}
				}
				nextWrite = nums.Length - 1;
				for (int i = nums.Length - 1; i >=0; --i)
				{
					if (nums[i] == 0) break;
					if (nums[i] == 2)
					{
						nums[i] = nums[nextWrite];
						nums[nextWrite--] = 2;
					}
				}
			}
		}
	}
}
