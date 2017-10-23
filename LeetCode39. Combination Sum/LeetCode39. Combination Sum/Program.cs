using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode39.Combination_Sum
{
	class Program
	{
		//https://leetcode.com/problems/combination-sum/description/
		static void Main(string[] args)
		{
			var s = new Solution();
			var r = s.CombinationSum(new int[] { 2,3,6,7}, 7);
		}

		public class Solution
		{
			public IList<IList<int>> CombinationSum(int[] candidates, int target)
			{
				var parcial = new List<int>();
				var resp = new List<IList<int>>();
				CombinationSum(candidates, target, parcial, resp, 0);
				return resp;
			}
			private void CombinationSum(int[] candidates, int target, List<int> parcial, List<IList<int>> resp, int start)
			{
				if (target < 0) return;
				if (target == 0)
				{
					resp.Add(new List<int>(parcial));
					return;
				}
				for (int i = start; i < candidates.Length; ++i)
				{
					parcial.Add(candidates[i]);
					CombinationSum(candidates, target - candidates[i], parcial, resp,i);
					parcial.RemoveAt(parcial.Count - 1);
				}
			}
		}
	}
}
