using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode764.Largest_Plus_Sign
{
	class Program
	{
		//https://leetcode.com/problems/largest-plus-sign/description/
		static void Main(string[] args)
		{
			var s = new Solution();
			var r = s.OrderOfLargestPlusSign(5, new int[,] { { 4,2} });
			//var r = s.OrderOfLargestPlusSign(2, new int[,] { { 0, 0 }, { 0,1}, { 1,0}, { 1,1} });
		}
		public class Solution
		{
			public int OrderOfLargestPlusSign(int N, int[,] mines)
			{
				var dp = new int[N, N];
				var minesHash = new HashSet<int>();
				for (int r = 0; r < mines.GetLength(0); ++r)
				{
					minesHash.Add(mines[r,0] * N + mines[r,1]);
				}

				for (int r = 0; r < N; ++r)
				{
					var count = 0;
					for (int c = 0; c < N; ++c)
					{
						count = minesHash.Contains(r * N + c) ? 0 : count + 1;
						dp[r, c] = count;
					}

					count = 0;
					for (int c = N-1; c >= 0; --c)
					{
						count = minesHash.Contains(r * N + c) ? 0 : count + 1;
						dp[r, c] = Math.Min(count, dp[r, c]);
					}
				}

				var max = 0;

				for (int c = 0; c < N; ++c)
				{
					var count = 0;
					for (int r = 0; r < N; ++r)
					{
						count = minesHash.Contains(r * N + c) ? 0 : count + 1;
						dp[r, c] = Math.Min(count, dp[r, c]);
					}

					count = 0;
					for (int r = N - 1; r >= 0; --r)
					{
						count = minesHash.Contains(r * N + c) ? 0 : count + 1;
						dp[r, c] = Math.Min(count, dp[r, c]);
						max = Math.Max(max, dp[r, c]);
					}
				}

				return max;
			}
		}
	}
}
