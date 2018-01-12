using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode330.Patching_Array
{
	class Program
	{
		static void Main(string[] args)
		{
			var s = new Solution();
			var r = s.MinPatches(new int[] { 1, 5, 10 }, 20);
		}

		public class Solution
		{
			public int MinPatches(int[] nums, int n)
			{
				long miss = 1, i = 0;
				var added = 0;
				while (miss <= n)
				{
					if (i < nums.Length && nums[i] <= miss)
					{
						miss += nums[i++];
					}
					else
					{
						miss += miss;
						added++;
					}
				}
				return added;
			}
		}
				//public class Solution
				//{
				//	public int MinPatches(int[] nums, int n)
				//	{
				//		var sums = new HashSet<int>();
				//		GetPermut(nums, 0, sums, 0, n);
				//		var resp = 0;
				//		for (int i = 1; i <= n; ++i)
				//		{
				//			if (sums.Add(i))
				//			{
				//				resp++;
				//				sums = AddNum(sums, i);
				//			}
				//		}
				//		return resp;
				//	}

				//	private HashSet<int> AddNum(HashSet<int> sums, int num)
				//	{
				//		var newSums = new HashSet<int>(sums);
				//		foreach (var v in sums)
				//		{
				//			newSums.Add(v + num);
				//		}
				//		return newSums;
				//	}
				//	private void GetPermut(int[] nums, int index, HashSet<int> sums, int acc, int tgt)
				//	{
				//		if (acc > tgt) return;

				//		sums.Add(acc);
				//		if (index == nums.Length) return;
				//		for (int i = index; i < nums.Length; ++i)
				//		{
				//			acc += nums[i];
				//			GetPermut(nums, index + 1, sums, acc, tgt);
				//			acc -= nums[i];
				//		}
				//	}
				//}
			}
		}
