using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode78.Subsets
{
	class Program
	{
		//https://leetcode.com/problems/subsets/description/
		static void Main(string[] args)
		{
			var s = new Solution();
			var r = s.Subsets(new int[] { 1,2,3});
		}
		public class Solution
		{
			public IList<IList<int>> Subsets(int[] nums)
			{
				var resp = new List<IList<int>>();
				var parc = new List<int>();
				Subsets(nums, resp, parc, 0);
				return resp;
			}

			private void Subsets(int[] nums, List<IList<int>> resp, List<int> parc, int pos)
			{
				resp.Add(new List<int>(parc));
				if (pos == nums.Length) return;
				for (int i = pos; i < nums.Length; ++i)
				{
					parc.Add(nums[i]);
					Subsets(nums, resp, parc, i + 1);
					parc.RemoveAt(parc.Count - 1);
				}
			}
		}
	}
}
