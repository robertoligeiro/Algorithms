using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode324.WiggleSortII
{
    class Program
    {
        //https://leetcode.com/problems/wiggle-sort-ii/#/description
        // solution is not working.
        static void Main(string[] args)
        {
            var s = new Solution();
			//var n = new int[] { 1, 5, 1, 1, 6, 4 };
			//s.WiggleSort(n);

			//var n = new int[] { 1, 3, 2, 2, 3, 1 };
			//var n = new int[] { 1, 2, 2, 1, 2, 1, 1, 1, 2, 2, 1, 2, 1, 2, 1, 1, 2};
			//            var n = new int[] { 1, 1, 2, 1, 2, 2, 1 };
			var n = new int[] { 3, 5, 2, 1, 6, 4 };
            s.WiggleSort(n);
        }

		//it's actually this: https://leetcode.com/problems/wiggle-sort/description/
		public class Solution
        {
            public void WiggleSort(int[] nums)
            {
				if (nums == null) return;
				Array.Sort(nums);
				for (int i = 1; i < nums.Length-1; i+=2)
				{
					var temp = nums[i];
					nums[i] = nums[i + 1];
					nums[i + 1] = temp;
				}
            }
        }
    }
}
