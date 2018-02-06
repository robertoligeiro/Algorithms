using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode311.Sparse_Matrix_Multiplication
{
	class Program
	{
		//https://leetcode.com/problems/sparse-matrix-multiplication/
		static void Main(string[] args)
		{
			var A = new int[,] { { 1, 0, 0 }, { -1, 0, 3 } };
			var B = new int[,] { { 7, 0, 0 }, { 0, 0, 0 }, { 0, 0, 1 } };
			var s = new Solution();
			var r = s.Multiply(A, B);
		}
		public class Solution
		{
			public int[,] Multiply(int[,] A, int[,] B)
			{
				var rowsA = A.GetLength(0);
				var colsA = A.GetLength(1);
				var colsB = B.GetLength(1);
				var resp = new int[rowsA, colsB];

				for (int rowsInA = 0; rowsInA < rowsA; ++rowsInA)
				{
					for (int colsIsA = 0; colsIsA < colsA; ++colsIsA)
					{
						if (A[rowsInA, colsIsA] != 0)
						{
							for (int colsInB = 0; colsInB < colsB; ++colsInB)
							{
								resp[rowsInA, colsInB] += A[rowsInA, colsIsA] * B[colsIsA, colsInB];
							}
						}
					}
				}
				return resp;
			}
		}
	}
}
