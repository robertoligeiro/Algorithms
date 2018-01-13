using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode283.Move_Zeroes
{
	class Program
	{
		static void Main(string[] args)
		{
		}

		public class Solution
		{
			public void MoveZeroes(int[] nums)
			{
				var nextWrite = 0;
				for (int i = 0; i < nums.Length; ++i)
				{
					if (nums[i] != 0) nums[nextWrite++] = nums[i];
				}
				for (int i = nextWrite; i < nums.Length; ++i)
				{
					nums[i] = 0;
				}
			}
		}
	}
}
