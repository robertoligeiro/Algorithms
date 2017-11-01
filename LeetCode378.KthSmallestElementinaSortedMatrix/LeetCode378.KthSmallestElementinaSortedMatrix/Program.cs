using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode378.KthSmallestElementinaSortedMatrix
{
	class Program
	{
		//https://leetcode.com/problems/kth-smallest-element-in-a-sorted-matrix/description/
		static void Main(string[] args)
		{
			var m = new int[,] { { 1, 5, 9 }, { 10, 11, 13 }, { 12, 13, 15 } };
			var s = new Solution();
			var r = s.KthSmallest(m, 8);
		}

		public class Solution
		{
			public int KthSmallest(int[,] matrix, int k)
			{
				var l = matrix[0, 0];
				var r = matrix[matrix.GetLength(0) - 1, matrix.GetLength(1) - 1] + 1;

				while (l < r)
				{
					var mid = l + (r - l) / 2;
					int count = 0;
					for(int row = 0; row < matrix.GetLength(0); ++row)
					{
						var col = matrix.GetLength(1) - 1;
						while (col >= 0 && matrix[row, col] > mid)
						{
							--col;
						}
						count += (col + 1);
					}
					if (count < k) l = mid + 1;
					else r = mid;
				}
				return l;
			}
		}
	}
}
