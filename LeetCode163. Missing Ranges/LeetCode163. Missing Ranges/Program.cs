using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode163.Missing_Ranges
{
	class Program
	{
		//https://leetcode.com/problems/missing-ranges/description/
		static void Main(string[] args)
		{
			var s = new Solution();
			//var r = s.FindMissingRanges(new int[] { 0,1,3,50,75}, 0,75);
			//var r = s.FindMissingRanges(new int[] { 1, 1, 1}, 1, 1);
			var r = s.FindMissingRanges(new int[] { -2147483648, -2147483648, 0, 2147483647, 2147483647 }, -2147483648, 2147483647);
		}
		public class Solution
		{
			public IList<string> FindMissingRanges(int[] nums, int lower, int upper)
			{
				var resp = new List<string>();
				if (nums == null || nums.Length == 0)
				{
					if (lower != upper) resp.Add(lower + "->" + upper);
					else resp.Add(lower.ToString());
					return resp;
				}

				if (lower < nums[0])
				{
					if (nums[0] - 1 != lower) resp.Add(lower + "->" + (nums[0] - 1));
					else resp.Add(lower.ToString());
				}

				for (int i = 1; i < nums.Length; ++i)
				{
					if (nums[i] > upper) break;
					if (nums[i] == nums[i - 1])
					{
						continue;
					}
					if (nums[i] != nums[i - 1] + 1)
					{
						var l = nums[i - 1] + 1;
						var r = nums[i] - 1;
						if (l > r) continue;
						if (l != r) resp.Add(l + "->" + r);
						else resp.Add(l.ToString());
					}
				}

				if (nums.Last() < upper)
				{
					if (nums.Last() + 1 != upper) resp.Add(nums.Last() + 1 + "->" + upper);
					else resp.Add(upper.ToString());
				}
				return resp;
			}
		}
	}
}
