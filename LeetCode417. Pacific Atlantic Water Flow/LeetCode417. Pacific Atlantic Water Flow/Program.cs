using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode417.Pacific_Atlantic_Water_Flow
{
	//https://leetcode.com/problems/pacific-atlantic-water-flow/description/
	class Program
	{
		static void Main(string[] args)
		{
			var b = new int[,] {
				{ 1,2,2,3,5},
				{ 3,2,3,4,4},
				{ 2,4,5,3,1},
				{ 5,1,1,2,4},
			};
			var s = new Solution();
			var r = s.PacificAtlantic(b);
		}

		public class Solution
		{
			public IList<int[]> PacificAtlantic(int[,] matrix)
			{
				var resp = new List<int[]>();
				var map = new Dictionary<Tuple<int, int>, bool>();
				for (var r = 0; r < matrix.GetLength(0); ++r)
				{
					for (var c = 0; c < matrix.GetLength(1); ++c)
					{
						if (TouchBoth(r, c, matrix, map))
						{
							resp.Add(new int[] { r, c });
						}
					}
				}
				return resp;
			}

			private bool TouchBoth(int r, int c, int[,] matrix, Dictionary<Tuple<int, int>, bool> map)
			{
				var atlantic = false;
				var pacific = false;
				var visited = new HashSet<Tuple<int, int>>();
				var q = new Queue<Tuple<int, int>>();
				var root = new Tuple<int, int>(r, c);
				q.Enqueue(root);
				while (q.Count > 0)
				{
					var curr = q.Dequeue();
					var cache = false;
					if (map.TryGetValue(curr, out cache))
					{
						if (cache) return true;
					}
					if (visited.Add(curr))
					{
						var currVal = matrix[curr.Item1, curr.Item2];
						var up = curr.Item1 - 1;
						var down = curr.Item1 + 1;
						var left = curr.Item2 - 1;
						var right = curr.Item2 + 1;
						if (down >= matrix.GetLength(0) || right >= matrix.GetLength(1))
						{
							atlantic = true;
						}
						if (up < 0 || left < 0)
						{
							pacific = true;
						}

						if (pacific && atlantic)
						{
							map.Add(root, true);
							return true;
						} 
						if (down < matrix.GetLength(0) && matrix[down, curr.Item2] <= currVal)
						{
							q.Enqueue(new Tuple<int, int>(down, curr.Item2));
						}
						if (up >= 0 && matrix[up, curr.Item2] <= currVal)
						{
							q.Enqueue(new Tuple<int, int>(up, curr.Item2));
						}
						if (right < matrix.GetLength(1) && matrix[curr.Item1, right] <= currVal)
						{
							q.Enqueue(new Tuple<int, int>(curr.Item1, right));
						}
						if (left >= 0 && matrix[curr.Item1, left] <= currVal)
						{
							q.Enqueue(new Tuple<int, int>(curr.Item1, left));
						}
					}
				}
				map.Add(root, false);
				return false;
			}
		}
	}
}
