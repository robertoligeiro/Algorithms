using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode268.Missing_Number
{
	class Program
	{
		static void Main(string[] args)
		{
		}
		public class Solution
		{
			public int MissingNumber(int[] nums)
			{
				var sum = 0;
				var sumArray = 0;
				for (int i = 0; i <= nums.Length; ++i)
				{
					if (i < nums.Length) sumArray += nums[i];
					sum += i;
				}
				return sum - sumArray;
			}
		}
	}
}
