using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode287.Find_the_Duplicate_Number
{
	class Program
	{
		static void Main(string[] args)
		{
			var s = new Solution();
			var r = s.FindDuplicate(new int[] { 2,2,2});
		}

		public class Solution
		{
			public int FindDuplicate(int[] nums)
			{
				if (nums == null || nums.Length == 0) return -1;
				int slow = nums[0];
				int fast = nums[nums[0]];
				while (fast != slow)
				{
					slow = nums[slow];
					fast = nums[nums[fast]];
				}
				fast = 0;
				while (fast != slow)
				{
					slow = nums[slow];
					fast = nums[fast];
				}
				return fast;
			}
		}
	}
}
