using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode18._4Sum
{
	class Program
	{
		//https://leetcode.com/problems/4sum/description/
		static void Main(string[] args)
		{
			var s = new Solution();
//			var r = s.FourSum(new int[] { 1, 0, -1, 0, -2, 2 }, 0);
//			var r = s.FourSum(new int[] { -1, 0, 1, 2, -1,-4 }, -1);
			var r = s.FourSum(new int[] { -1, -5, -5, -3, 2, 5, 0, 4 }, -7);
		}

		public class Solution
		{
			public IList<IList<int>> FourSum(int[] nums, int target)
			{
				nums = nums.OrderBy(x => x).ToArray();
				var resp = new List<IList<int>>();
				for (int i = 0; i <= nums.Length - 4; ++i)
				{
					for (int j = i + 1; j < nums.Length - 1; ++j)
					{
						var parc = new List<int>() { nums[i], nums[j] };
						resp.AddRange(FindSum(nums, j + 1, target, nums[i] + nums[j], parc));
						while (j < nums.Length - 1 && nums[j] == nums[j + 1]) ++j;
					}
					while (i < nums.Length - 1 && nums[i] == nums[i + 1]) ++i;
				}
				return resp;
			}

			private IList<IList<int>> FindSum(int[] nums, int l, int target, int sum, List<int> parc)
			{
				var r = nums.Length - 1;
				var resp = new List<IList<int>>();
				while (l < r)
				{
					var binSum = nums[l] + nums[r] + sum;
					if (binSum == target)
					{
						var found = new List<int>(parc);
						found.Add(nums[l]);
						found.Add(nums[r]);
						resp.Add(found);
						++l;
						while ((l < r) && nums[l - 1] == nums[l]) l++;
						--r;
						while ((l < r) && nums[r] == nums[r + 1]) r--;
					}
					else
					{
						if (binSum < target)
						{
							++l;
							while ((l < r) && nums[l-1] == nums[l]) l++;
						}
						else
						{
							--r;
							while ((l < r) && nums[r] == nums[r + 1]) r--;
						}
					}
				}
				return resp;
			}
		}
	}
}
