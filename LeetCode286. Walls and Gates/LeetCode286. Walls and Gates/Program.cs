using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode286.Walls_and_Gates
{
	class Program
	{
		//https://leetcode.com/problems/walls-and-gates/description/
		static void Main(string[] args)
		{
			var r = new int[,] {	{ 2147483647, -1, 0, 2147483647 }, 
									{ 2147483647, 2147483647, 2147483647, -1 }, 
									{ 2147483647, -1, 2147483647, -1 }, 
									{ 0, -1, 2147483647, 2147483647 } };
			var s = new Solution();
			s.WallsAndGates( r);
		}
		public class Solution
		{
			private static int EMPTY = int.MaxValue;
			private static int GATE = 0;
			private static List<int[]> DIRECTIONS = new List<int[]> {
					new int[] { 1, 0 },
					new int[] { -1, 0 },
					new int[] { 0, 1 },
					new int[] { 0, -1 }
			};
			public void WallsAndGates(int[,] rooms)
			{
				var q = new Queue<Tuple<int, int>>();
				for (int row = 0; row < rooms.GetLength(0); ++row)
				{
					for (int col = 0; col < rooms.GetLength(1); ++col)
					{
						if (rooms[row, col] == GATE)
						{
							q.Enqueue(new Tuple<int, int>(row,col));
						}
					}
				}

				while (q.Count > 0)
				{
					var curr = q.Dequeue();
					foreach (var d in DIRECTIONS)
					{
						var row = curr.Item1 + d[0];
						var col = curr.Item2 + d[1];
						if (row < 0 || col < 0 || row == rooms.GetLength(0) || col == rooms.GetLength(1) || rooms[row,col] !=EMPTY)
						{
							continue;
						}
						rooms[row, col] = rooms[curr.Item1, curr.Item2] + 1;
						q.Enqueue(new Tuple<int, int>(row, col));
					}
				}
			}
		}
	}
}
