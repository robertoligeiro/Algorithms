using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode416.PartitionEqualSubsetSum
{
    class Program
    {
        //https://leetcode.com/submissions/detail/112647069/
        // my version is non optimal, best solution is DP similar to knapsack
        static void Main(string[] args)
        {
            var s = new Solution();
			var r = s.CanPartition(new int[] { 2, 2, 3, 5 }); //false
			r = s.CanPartition(new int[] { 2, 5, 11, 5 }); //false
            r = s.CanPartition(new int[] { 1, 5, 11, 5 }); //true
            r = s.CanPartition(new int[] { 1, 1, 1, 1 }); //true
            r = s.CanPartition(new int[] { 1, 2, 3, 4, 5, 6, 7 }); //true
        }
        public class Solution
        {
            public bool CanPartition(int[] nums)
            {
                var targetValue = 0;
                foreach (var i in nums)
                {
                    targetValue += i;
                }
                if (targetValue % 2 != 0) return false;
				nums = nums.OrderBy(x => x).ToArray();
                return CanPartition(nums, 0, targetValue/2);
            }

			private bool CanPartition(int[] nums, int i, int sum)
			{
				if (i == nums.Length) return false;
				if (sum == nums[i]) return true;
				if (sum < nums[i]) return false;
				return CanPartition(nums, i + 1, sum - nums[i]) || CanPartition(nums, i + 1, sum);
			}
        }
    }
}
