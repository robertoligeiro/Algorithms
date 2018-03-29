using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode801.MinSwapsToMakeSequencesIncreasing
{
	class Program
	{
		// code is wrong, problem is DP, not implemented.
		static void Main(string[] args)
		{
			var s = new Solution();
			var r = s.MinSwap(new int[] { 1,3,5,4}, new int[] { 1,2,3,7});
		}
		public class Solution
		{
			public int MinSwap(int[] A, int[] B)
			{
				var resp= 0;
				for (int i = 1; i < A.Length; ++i)
				{
					if (A[i] < A[i - 1])
					{
						var temp = A[i];
						A[i] = B[i];
						B[i] = temp;
						resp++;
					}
				}
				for (int i = 1; i < B.Length; ++i)
				{
					if (B[i] < B[i - 1])
					{
						var temp = B[i];
						B[i] = A[i];
						A[i] = temp;
						resp++;
					}
				}
				return resp;
			}
		}
	}
}
