using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DistToZero
{
	class Program
	{
		static void Main(string[] args)
		{
			var m = new int[,] { { 0,0,0},
								 { 0,0,0},
								 { 1,1,1},
								 { 1,1,1} };
			var r = GetDistMatrix(m);
		}

		public static int[,] GetDistMatrix(int[,] input)
		{
			for (int row = 0; row < input.GetLength(0); ++row)
			{
				for (int col = 0; col < input.GetLength(1); ++col)
				{
					if (input[row, col] == 1)
					{
						GetDistMatrix(input, row, col);
					}
				}
			}
			return input;
		}

		public static void GetDistMatrix(int[,] input, int row, int col)
		{
			var q1 = new Queue<Tuple<int, int>>();
			var q2 = new Queue<Tuple<int, int>>();
			var visited = new HashSet<Tuple<int, int>>();
			q1.Enqueue(new Tuple<int, int>(row, col));
			var dist = 0;
			while (q1.Count > 0 || q2.Count > 0)
			{
				if (HasZero(q1, q2, visited, input))
				{
					input[row, col] = dist;
					return;
				}
				++dist;
				if (HasZero(q2, q1, visited, input))
				{
					input[row, col] = dist;
					return;
				}
				++dist;
			}
		}

		public static bool HasZero(Queue<Tuple<int, int>> from, Queue<Tuple<int, int>> to, HashSet<Tuple<int,int>> v, int[,]input)
		{
			while (from.Count > 0)
			{
				var curr = from.Dequeue();
				if (input[curr.Item1, curr.Item2] == 0) return true;
				if (v.Add(curr))
				{
					GetAdj(curr.Item1, curr.Item2, input.GetLength(0) - 1, input.GetLength(1) - 1, to);
				}
			}
			return false;
		}

		public static void GetAdj(int row, int col, int maxRow, int maxCol, Queue<Tuple<int,int>> q)
		{
			for (int i = row - 1; i <= row + 1; i++)
			{
				for (int j = col - 1; j < col + 1; ++j)
				{
					if (i >= 0 && i <= maxRow && j >= 0 && j <= maxCol)
					{
						q.Enqueue(new Tuple<int, int>(i, j));
					}
				}
			}
		}
	}
}
