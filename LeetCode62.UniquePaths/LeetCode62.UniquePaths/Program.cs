using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode62.UniquePaths
{
    class Program
    {
        //problem: https://leetcode.com/problems/unique-paths/description/
        static void Main(string[] args)
        {
            var s = new Solution();
            var r = s.UniquePaths(23, 12);
        }

		class Solution
		{
			public int UniquePaths(int m, int n)
			{
				var memo = new int[m,n];
				return UniquePaths(m, n, 0, 0, memo);
			}

			private int UniquePaths(int m, int n, int r, int c, int[,] memo)
			{
				if (r == m - 1 && c == n - 1) return 1;
				if (memo[r, c] != 0) return memo[r, c];
				var right = 0;
				var down = 0;
				if (c + 1 < n) right = UniquePaths(m, n, r, c + 1, memo);
				if (r + 1 < m) down = UniquePaths(m, n, r + 1, c, memo);
				var total = right + down;
				memo[r, c] = total;
				return total;
			}
		}
    }
}
