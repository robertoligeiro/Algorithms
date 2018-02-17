using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode410.SplitArrayLargestSum
{
    class Program
    {
		//https://leetcode.com/problems/split-array-largest-sum/description/
		static void Main(string[] args)
        {
            var s = new Solution();
            var a = new int[] { 7, 2, 5, 10, 8 };
            var s2 = s.SplitArray(a,2);
            var s3 = s.SplitArray(a, 3);
            var a1 = new int[] { 1, 2147483647 };
            s2 = s.SplitArray(a1, 2);
        }

		public class Solution
		{
			public int SplitArray(int[] nums, int m)
			{
				var nLen = nums.Length;
				var f = new int[nLen + 1, m + 1];
				var sub = new int[nLen + 1];
				for (int row = 0; row < f.GetLength(0); ++row)
				{
					for (int col = 0; col < f.GetLength(1); ++col)
					{
						f[row, col] = int.MaxValue;
					}
				}
				f[0, 0] = 0;

				for (int i = 0; i < nLen; ++i)
				{
					sub[i + 1] = sub[i] + nums[i];
				}

				for (int row = 1; row <= nLen; ++row)
				{
					for (int col = 1; col <= m; ++col)
					{
						for (int k = 0; k < row; ++k)
						{
							f[row, col] = Math.Min(f[row, col], Math.Max(f[k, col - 1], sub[row] - sub[k]));
						}
					}
				}
				return f[nLen, m];
			}
		}
		// method using recursion, less effient O(nM)
		//public class Solution
		//{
		//    public int SplitArray(int[] nums, int m)
		//    {
		//        var resp = new List<List<int>>();
		//        var parc = new List<int>();
		//        return SplitArray(new List<int>(nums), m, resp);
		//    }
		//    public int SplitArray(List<int> nums, int m, List<List<int>> resp)
		//    {
		//        var localSum = 0;
		//        if (m == 1)
		//        {
		//            foreach (var i in nums) localSum += i;
		//            return localSum;
		//        }
		//        long maxSum = 0;
		//        long maxSub = long.MaxValue;
		//        for (int i = 0; i < nums.Count; ++i)
		//        {
		//            localSum += nums[i];
		//            var sub = nums.GetRange(0, i + 1);
		//            var rest = nums.GetRange(i + 1, nums.Count - i - 1);
		//            long localSub = SplitArray(rest, m - 1, resp);
		//            long max = Math.Max(maxSum, maxSub);
		//            if (localSum < max && localSub < max)
		//            {
		//                maxSum = localSum;
		//                maxSub = localSub;
		//            }
		//        }
		//        return Math.Max((int)maxSum, (int)maxSub);
		//    }
		//}
	}
}
