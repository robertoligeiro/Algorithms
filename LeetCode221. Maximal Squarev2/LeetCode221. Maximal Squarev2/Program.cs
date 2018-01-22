using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode221.Maximal_Squarev2
{
	class Program
	{
		//https://leetcode.com/problems/maximal-square/description/
		static void Main(string[] args)
		{
			var m = new char[,] { { '0', '1', '1' }, { '0', '1', '1' }, { '0', '0', '0' } };
			var s = new Solution();
			var r = s.MaximalSquare(m);
		}
		public class Solution
		{
			public int MaximalSquare(char[,] matrix)
			{
				var max = 0;
				var maxSquare = new int[matrix.GetLength(0), matrix.GetLength(1)];
				for (int row = 0; row < matrix.GetLength(0); ++row)
				{
					if (matrix[row, 0] == '1') { maxSquare[row, 0] = 1; max = 1; }
				}
				for (int col = 0; col < matrix.GetLength(1); ++col)
				{
					if (matrix[0, col] == '1') { maxSquare[0, col] = 1; max = 1; };
				}

				for (int row = 1; row < matrix.GetLength(0); ++row)
				{
					for (int col = 1; col < matrix.GetLength(1); ++col)
					{
						if (matrix[row, col] == '1')
						{
							var sorted = new List<int>() { maxSquare[row, col - 1], maxSquare[row - 1, col - 1], maxSquare[row - 1, col] };
							sorted.Sort();
							maxSquare[row, col] = sorted[0] + 1;
							max = Math.Max(max, maxSquare[row, col]);
						}
					}
				}
				return max * max;
			}
		}
	}
}
