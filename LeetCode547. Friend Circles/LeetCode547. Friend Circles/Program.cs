using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode547.Friend_Circles
{
	//https://leetcode.com/problems/friend-circles/description/
	class Program
	{
		static void Main(string[] args)
		{
			var f = new int[,] { { 1, 1, 0 }, { 1, 1, 0 }, { 0, 0, 1 } };
			var s = new Solution();
			var r = s.FindCircleNum(f);
		}

		public class Solution
		{
			public int FindCircleNum(int[,] M)
			{
				var visited = new HashSet<int>();
				var circles = 0;
				for (int row = 0; row<M.GetLength(0); ++row)
				{
					for (int col = 0; col < M.GetLength(1); ++col)
					{
						if (visited.Contains(row)) break;
						if (M[row, col] == 1)
						{
							circles++;
							var q = new Queue<int>();
							q.Enqueue(row);
							CheckCircle(M, visited, q);
						}
					}
				}
				return circles;
			}

			private void CheckCircle(int[,] M, HashSet<int> visited, Queue<int> rows)
			{
				while (rows.Count > 0)
				{
					var row = rows.Dequeue();
					if (visited.Add(row))
					{
						for (int col = 0; col < M.GetLength(1); ++col)
						{
							if (M[row, col] == 1)
							{
								M[row, col] = 0;
								rows.Enqueue(col);
							}
						}
					}
				}
			}
		}
	}
}
