using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode48.Rotate_Image
{
	class Program
	{
		//https://leetcode.com/problems/rotate-image/description/
		static void Main(string[] args)
		{
			//var m = new int[,] { { 1, 2, 3 }, { 4, 5, 6 }, { 7, 8, 9 } };
			var m = new int[,] {
							 { 5, 1, 9, 11},
							  {2, 4, 8, 10},
							  {13, 3, 6, 7},
							  {15, 14, 12, 16 }
							  };
			var s = new Solution();
			s.Rotate(m);
		}
		public class Solution
		{
			public void Rotate(int[,] matrix)
			{
				//1st swap down from 1st row and last row
				var lastRow = matrix.GetLength(0) - 1;
				for (int row = 0; row < matrix.GetLength(0) / 2; ++row)
				{
					for (int col = 0; col < matrix.GetLength(1); ++col)
					{
						var temp = matrix[row, col];
						matrix[row, col] = matrix[lastRow, col];
						matrix[lastRow, col] = temp;
					}
					lastRow--;
				}

				//2nd swap the symetries
				for (int row = 0; row < matrix.GetLength(0); ++row)
				{
					for (int col = row + 1; col < matrix.GetLength(1); ++col)
					{
						var temp = matrix[row, col];
						matrix[row, col] = matrix[col, row];
						matrix[col, row] = temp;
					}
				}
			}
		}
	}
}
