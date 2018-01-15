using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode215.Kth_Largest_Element_in_an_Array
{
	class Program
	{
		static void Main(string[] args)
		{
			var s = new Solution();
			var r = s.FindKthLargest(new int[] { 3, 2, 1, 5, 6, 4}, 2);
			//var r = s.FindKthLargest(new int[] { 99,99}, 1);
			//var r = s.FindKthLargest(new int[] { -1,2,0}, 1);
		}

		public class Solution
		{
			public int FindKthLargest(int[] nums, int k)
			{
				var l = 0;
				var r = nums.Length - 1;
				while (l <= r)
				{
					var partition = Partition(nums, l, r);
					if (partition == k - 1) return nums[partition];
					if (partition > k - 1)
					{
						r = partition - 1;
					}
					else
					{
						l = partition + 1;
					}
				}
				return -1;
			}
			private int Partition(int[] nums, int left, int right)
			{
				var l = left+1;
				var r = right;
				while (l <= r)
				{
					while (l < right && nums[l] > nums[left]) l++;
					while (r > left && nums[r] <= nums[left]) r--;
					if (r <= l) break;
					var t = nums[l];
					nums[l] = nums[r];
					nums[r] = t;
				}

				var temp = nums[left];
				nums[left] = nums[r];
				nums[r] = temp;
				return r;
			}
		}

		// using heap, time exceed in leetcode.
		public class SolutionNew
		{
			public int FindKthLargest(int[] nums, int k)
			{
				var sorted = new List<int>();
				for (int i = 0; i < nums.Length; ++i)
				{
					if (sorted.Count < k)
					{
						sorted.Add(nums[i]);
						sorted.Sort();
						continue;
					}

					if (nums[i] > sorted[0])
					{
						sorted[0] = nums[i];
						sorted.Sort();
					}
				}
				return sorted[0];
			}
		}
	}
}
