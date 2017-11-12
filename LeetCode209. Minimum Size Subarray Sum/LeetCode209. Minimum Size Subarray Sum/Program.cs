using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode209.Minimum_Size_Subarray_Sum
{
	class Program
	{
		static void Main(string[] args)
		{
			var s = new Solution();
			var r = s.MinSubArrayLen(7, new int[] { 2,3,1,2,4,3});
			//var r = s.MinSubArrayLen(15, new int[] {1, 2, 3,4,5 });
		}

		public class Solution
		{
			public int MinSubArrayLen(int s, int[] nums)
			{
				if (nums.Length == 0) return 0;
				var sums = new List<int>();
				sums.Add(0);
				var min = int.MaxValue;
				for (int i = 1; i <= nums.Length; ++i)
				{
					sums.Add(sums[i - 1] + nums[i-1]);
				}
				for (int i = 1; i < sums.Count; ++i)
				{
					var j = BinSearch(sums, s + sums[i-1], 0, sums.Count - 1);
					if(j != -1)
						min = Math.Min(min, j - i + 1);
				}
				return min == int.MaxValue ? 0 : min;
			}

			private int BinSearch(List<int> sums, int tgt, int l, int r)
			{
				while (l < r)
				{
					var mid = l + (r - l) / 2;
					if (sums[mid] < tgt)
					{
						l = mid + 1;
					}
					else
					{
						r = mid;
					}
				}
				return sums[l] >= tgt ? l : -1;
			}
		}
		public class Solution2
		{
			public int MinSubArrayLen(int s, int[] nums)
			{
				if (nums.Length == 0) return 0;
				var sums = new List<int>();
				sums.Add(nums[0]);
				var min = int.MaxValue;
				for (int i = 1; i < nums.Length; ++i)
				{
					sums.Add(sums[i - 1] + nums[i]);
				}
				for (int i = 0; i < sums.Count; ++i)
				{
					for (int j = i; j < sums.Count; ++j)
					{
						var sum = sums[j] - sums[i] + nums[i];
						if (sum >= s)
						{
							min = Math.Min(min, j - i + 1);
						}
					}
				}
				return min == int.MaxValue?0:min;
			}
		}
	}
}
