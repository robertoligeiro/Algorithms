using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode675.Cut_Off_Trees_for_Golf_Event
{
	//https://leetcode.com/problems/cut-off-trees-for-golf-event/description/
	class Program
	{
		static void Main(string[] args)
		{
			var f = new List<IList<int>>();
			f.Add(new List<int>() { 3, 2, 4 });
			f.Add(new List<int>() { 0, 0, 5 });
			f.Add(new List<int>() { 8, 7, 6 });
			var s = new Solution();
			var r = s.CutOffTree(f);
		}
		public class Solution
		{
			public int CutOffTree(IList<IList<int>> forest)
			{
				var trees = new List<Tuple<int, Tuple<int, int>>>();
				for (int row = 0; row < forest.Count; ++row)
				{
					for (int col = 0; col < forest[0].Count; ++col)
					{
						if (forest[row][col] > 1)
						{
							trees.Add(new Tuple<int, Tuple<int, int>>(forest[row][col], new Tuple<int, int>(row, col)));
						}
					}
				}
				trees.Sort(CompTrees);
				var startRow = 0;
				var startCol = 0;
				var resp = 0;
				foreach (var t in trees)
				{
					var d = Bfs(forest, startRow, startCol, t.Item2.Item1, t.Item2.Item2);
					if (d == -1) return -1;
					resp += d;
					startRow = t.Item2.Item1;
					startCol = t.Item2.Item2;
				}
				return resp;
			}

			public int CompTrees(Tuple<int, Tuple<int, int>> a, Tuple<int, Tuple<int, int>> b)
			{
				return a.Item1.CompareTo(b.Item1);
			}

			private int[] dr = new int[] { 1, -1, 0, 0 };
			private int[] dc = new int[] { 0, 0, 1, -1};
			private int Bfs(IList<IList<int>> forest, int sr, int sc, int tr, int tc)
			{
				int R = forest.Count, C = forest[0].Count;
				Queue<int[]> queue = new Queue<int[]>();
				queue.Enqueue(new int[] { sr, sc, 0 });
				bool[,] seen = new bool[R,C];
				seen[sr,sc] = true;
				while (queue.Count>0)
				{
					int[] cur = queue.Dequeue();
					if (cur[0] == tr && cur[1] == tc) return cur[2];
					for (int di = 0; di < 4; ++di)
					{
						int r = cur[0] + dr[di];
						int c = cur[1] + dc[di];
						if (0 <= r && r < R && 0 <= c && c < C &&
								!seen[r,c] && forest[r][c]> 0)
						{
							seen[r,c] = true;
							queue.Enqueue(new int[] { r, c, cur[2] + 1 });
						}
					}
				}
				return -1;
			}
		}
	}
}
