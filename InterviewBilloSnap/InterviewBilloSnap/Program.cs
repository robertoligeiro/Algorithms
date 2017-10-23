using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InterviewBilloSnap
{
	class Program
	{
		static void Main(string[] args)
		{
			var board = new int[,] { 
				{ 1, 2, 2 },
				{ 1, 3, 4 },
				{ 2, 4, 4 }
			};
			var r = Solution.GetClusterGreatCount(board);
		}

		public class Solution
		{
			public static int GetClusterGreatCount(int[,] board)
			{
				var max = 0;
				for (var r = 0; r < board.GetLength(0); ++r)
				{
					for (var c = 0; c < board.GetLength(1); ++c)
					{
						if (board[r, c] != -1)
						{
							max =  Math.Max(max, GetClusterCount(board, new Tuple<int, int>(r, c), board[r, c]));
						}
					}
				}
				return max;
			}
			public static int GetClusterCount(int[,] board, Tuple<int, int> curr, int val)
			{
				var clusterCount = 0;
				var q = new Queue<Tuple<int, int>>();
				var v = new HashSet<Tuple<int, int>>();
				q.Enqueue(curr);
				while (q.Count > 0)
				{
					curr = q.Dequeue();
					if (v.Add(curr) && board[curr.Item1, curr.Item2] == val)
					{
						clusterCount++;
						board[curr.Item1, curr.Item2] = -1;
						GetAdj(board, curr, q);
					}
				}
				return clusterCount;
			}

			public static void GetAdj(int[,] board, Tuple<int, int> curr, Queue<Tuple<int, int>> q)
			{
				var left = curr.Item2 - 1;
				var right = curr.Item2 + 1;
				var up = curr.Item1 - 1;
				var down = curr.Item1 + 1;
				if (left >= 0) q.Enqueue(new Tuple<int, int>(curr.Item1, left));
				if (right < board.GetLength(1)) q.Enqueue(new Tuple<int, int>(curr.Item1, right));
				if (up >= 0) q.Enqueue(new Tuple<int, int>(up, curr.Item2));
				if (down < board.GetLength(0)) q.Enqueue(new Tuple<int, int>(down, curr.Item2));
			}
		}
	}
}
