using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode698.Partition_to_K_Equal_Sum_Subsets
{
	class Program
	{
		//https://leetcode.com/problems/partition-to-k-equal-sum-subsets/description/
		//my solution is time exceeding.
		static void Main(string[] args)
		{
			var s = new Solution();
			var r = s.CanPartitionKSubsets(new int[] { 5, 2, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 3 }, 15);
		}
		public class Solution
		{
			public bool CanPartitionKSubsets(int[] nums, int k)
			{
				var sum = nums.Sum();
				if (sum % k > 0) return false;
				var target = sum / k;
				nums = nums.OrderBy(x => x).ToArray();
				if (nums.Last() > target) return false;
				var i = nums.Length;
				nums = nums.Where(x => x < target).ToArray();
				k -= (i - nums.Length); 
				var sums = Enumerable.Repeat(0, k).ToArray();
				
				return CanPartitionKSubsets(nums, k, sums, 0, target, 0);
			}

			private bool CanPartitionKSubsets(int[] nums, int k, int[] sums, int index, int target, int found)
			{
				if (index == nums.Length)
				{
					return found == k;
				}

				for (int i = 0; i < k; ++i)
				{
					if (sums[i] + nums[index] <= target)
					{
						sums[i] += nums[index];
						if (sums[i] == target) ++found;
						if (CanPartitionKSubsets(nums, k, sums, index + 1, target, found)) return true;
						if (sums[i] == target) --found;
						sums[i] -= nums[index];
					}
				}
				return false;
			}
		}
	}
}
