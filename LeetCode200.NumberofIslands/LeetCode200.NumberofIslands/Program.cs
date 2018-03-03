using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode200.NumberofIslands
{
    class Program
    {
        //https://leetcode.com/problems/number-of-islands/tabs/description
        static void Main(string[] args)
        {
			var g = new char[,] { 
				{ '1', '1', '0', '0', '0'},
				{ '1', '1', '0', '0', '0'},
				{ '0', '0', '1', '0', '0'},
				{ '0', '0', '0', '1', '1'},
			};
			var s = new Solution();
			var r = s.NumIslands(g);
        }
        public class Solution
        {
            public int NumIslands(char[,] grid)
            {
                var resp = 0;
                for (int row = 0; row < grid.GetLength(0); ++row)
                {
                    for (int col = 0; col < grid.GetLength(1); ++col)
                    {
                        if (grid[row, col] == '1')
                        {
                            GetIsland(row, col, grid);
                            resp++;
                        }
                    }
                }
                return resp;
            }

            private void GetIsland(int row, int col, char[,] grid)
            {
				var maxR = grid.GetLength(0) - 1;
				var maxC = grid.GetLength(1) - 1;
                var start = new Tuple<int, int>(row, col);
                var q = new Queue<Tuple<int, int>>();
                q.Enqueue(start);
                while (q.Count > 0)
                {
                    var curr = q.Dequeue();
					if (grid[curr.Item1, curr.Item2] == '1')
					{
						grid[curr.Item1, curr.Item2] = '2';
						GetAdj(grid, curr, maxR, maxC, q);
					}
				}
            }
			private readonly int[,] directions = new int[,] { { 1, 0 }, { -1, 0 }, { 0, 1 }, { 0, -1 } };
            private void GetAdj(char[,] grid, Tuple<int,int> curr, int maxR, int maxC, Queue<Tuple<int, int>> q)
            {
				for (int i = 0; i < directions.GetLength(0); ++i)
				{
					var r = curr.Item1 + directions[i, 0];
					var c = curr.Item2 + directions[i, 1];
					if (r >= 0 && r <= maxR && c >= 0 && c <= maxC)
					{
						q.Enqueue(new Tuple<int, int>(r, c));
					}
				}
			}
        }
    }
}
