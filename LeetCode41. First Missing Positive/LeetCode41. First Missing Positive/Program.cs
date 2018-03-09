using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode41.First_Missing_Positive
{
    class Program
    {
        //https://leetcode.com/problems/first-missing-positive/description/
        static void Main(string[] args)
        {
			var ss = new SolutionNew();
			var rr = ss.FirstMissingPositive(new int[] { 3, 4, -1, -2, -3, 1, 2 });
			//var rr = ss.FirstMissingPositive(new int[] { 1,1 });

		}

		public class SolutionNew
		{
			public int FirstMissingPositive(int[] nums)
			{
				if (nums.Length == 0) return 1;
				for (int i = 0; i < nums.Length; ++i)
				{
					var seed = nums[i];
					while (seed > 0 && seed < nums.Length && nums[seed-1] != nums[i])
					{
						var temp = nums[seed - 1];
						nums[seed - 1] = seed;
						nums[i] = temp;
						seed = nums[i];
					}
				}
				for (int i = 0; i < nums.Length; ++i)
					if (nums[i] != i + 1)
						return i + 1;

				return nums.Length + 1;
			}
		}
    }
}
