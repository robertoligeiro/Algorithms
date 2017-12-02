using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode54.Spiral_Matrix
{
	//https://leetcode.com/problems/spiral-matrix/description/
	class Program
	{
		static void Main(string[] args)
		{
			//var g = new int[,] { { 1, 2, 3 }, { 4, 5, 6 }, { 7, 8, 9 } };
			var g = new int[,] { { 2, 3 } };
			var s = new Solution();
			var r = s.SpiralOrder(g);
		}

		public class Solution
		{
			public IList<int> SpiralOrder(int[,] matrix)
			{
				var topRow = 0;
				var bottomRow = matrix.GetLength(0) - 1;
				var topCol = 0;
				var bottomCol = matrix.GetLength(1) - 1;
				var resp = new List<int>();
				while (resp.Count < matrix.Length)
				{
					// -->
					for (int i = topCol; i <= bottomCol; ++i) resp.Add(matrix[topRow, i]);
					topRow++;

					if (resp.Count == matrix.Length) return resp;

					// |
					// V
					for (int i = topRow; i <= bottomRow; ++i) resp.Add(matrix[i, bottomCol]);
					bottomCol--;
					if (resp.Count == matrix.Length) return resp;

					// <--
					for (int i = bottomCol; i >= topCol; --i) resp.Add(matrix[bottomRow, i]);
					bottomRow--;
					if (resp.Count == matrix.Length) return resp;

					// ^
					// |
					for (int i = bottomRow; i >= topRow; --i) resp.Add(matrix[i, topCol]);
					topCol++;
				}
				return resp;
			}
		}
	}
}
