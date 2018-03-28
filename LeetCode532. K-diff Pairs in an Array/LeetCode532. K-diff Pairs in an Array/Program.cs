using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode532.K_diff_Pairs_in_an_Array
{
	//https://leetcode.com/problems/k-diff-pairs-in-an-array/description/
	class Program
	{
		static void Main(string[] args)
		{
		}
		public class Solution
		{
			public int FindPairs(int[] nums, int k)
			{
				var resp = 0;
				if (nums == null || nums.Length == 0) return resp;

				var m = new Dictionary<int, int>();
				foreach (var i in nums)
				{
					var count = 0;
					if (m.TryGetValue(i, out count)) m[i] = ++count;
					else m.Add(i, 1);
				}
				foreach (var t in m)
				{
					if (k == 0)
					{
						if (t.Value >= 2) resp++;
					}
					else
					{
						if (m.ContainsKey(t.Key + k)) resp++;
					}
				}
				return resp;
			}
		}
	}
}
