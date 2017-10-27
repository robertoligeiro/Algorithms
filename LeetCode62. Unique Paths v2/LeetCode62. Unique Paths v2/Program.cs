using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode62.Unique_Paths_v2
{
	//https://leetcode.com/problems/unique-paths/description/
	class Program
	{
		static void Main(string[] args)
		{
			var s = new Solution();
			var r = s.UniquePaths(3,3);
		}

		class Solution
		{
			public int UniquePaths(int m, int n)
			{
				var memo = new int[m, n];
				return UniquePaths(0, 0, m, n, memo);
			}
			private int UniquePaths(int r, int c, int m, int n, int[,] memo)
			{
				if (r >= m || c >= n) return 0;
				if (r == m-1 && c == n-1) return 1;
				if (memo[r, c] != 0) return memo[r, c];
				var count = UniquePaths(r + 1, c, m, n, memo);
				count += UniquePaths(r, c + 1, m, n, memo);
				memo[r, c] = count;
				return count;
			}
		}
	}
}
