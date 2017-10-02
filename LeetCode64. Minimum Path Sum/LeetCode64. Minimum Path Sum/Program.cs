using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode64.Minimum_Path_Sum
{
    class Program
    {
        static void Main(string[] args)
        {
            //var g = new int[,] { { 0, 0, 0, 5 }, { 1, 1, 1, 0 }, { 2, 2, 2, 0 }, { 3, 3, 3, 0 } };
            var g = new int[,] { { 0, 0}, { 0, 1 } };
            var s = new Solution();
            var r = s.MinPathSum(g);
        }
        public class Solution
        {
            public int MinPathSum(int[,] grid)
            {
                var memo = new int[grid.GetLength(0),grid.GetLength(1)];
                for (int r = 0; r < memo.GetLength(0); ++r)
                {
                    for (int c = 0; c < memo.GetLength(1); ++c) memo[r, c] = -1;
                }
                return MinPathSum(grid, 0, 0, memo);
            }
            private int MinPathSum(int[,] grid, int r, int c, int[,] memo)
            {
                if (r == grid.GetLength(0) - 1 && c == grid.GetLength(1) - 1)
                {
                    return grid[r, c];
                }
                if (memo[r, c] != -1) return memo[r, c];
                var right = -1;
                if (c + 1 < grid.GetLongLength(1))
                {
                    right = MinPathSum(grid, r, c + 1, memo);
                }
                var down = -1;
                if (r + 1 < grid.GetLength(0))
                {
                    down = MinPathSum(grid, r + 1, c, memo);
                }
                var min = 0;
                if (right != -1 && down != -1)
                {
                    min = Math.Min(right, down);
                }
                else if (right != -1)
                {
                    min = right;
                }
                else min = down;
                memo[r, c] = min + grid[r,c];
                return memo[r, c];
            }
        }

        // solution above performs betters, since it's better use the memo data structure - more optimized.
        // but solution is pretty much the same.
        public class Solution1
        {
            public int MinPathSum(int[,] grid)
            {
                var memo = new Dictionary<Tuple<int, int>, int>();
                return MinPathDsf(grid, new Tuple<int, int>(0, 0), memo);
            }

            private int MinPathDsf(int[,] grid, Tuple<int, int> curr, Dictionary<Tuple<int, int>, int> memo)
            {
                if (curr.Item1 == grid.GetLength(0) - 1 && curr.Item2 == grid.GetLength(1) - 1)
                {
                    memo.Add(curr, grid[curr.Item1, curr.Item2]);
                    return grid[curr.Item1, curr.Item2];
                }

                var next = GetNext(curr, grid);
                var minPath = int.MaxValue;
                foreach (var child in next)
                {
                    var min = 0;
                    if (!memo.TryGetValue(child, out min))
                    {
                        min = MinPathDsf(grid, child, memo);
                    }
                    minPath = Math.Min(min, minPath);
                }
                var cost = minPath + grid[curr.Item1, curr.Item2];
                memo.Add(curr, cost);
                return cost;
            }

            private List<Tuple<int, int>> GetNext(Tuple<int, int> curr, int[,] grid)
            {
                var right = curr.Item2 + 1;
                var down = curr.Item1 + 1;
                var resp = new List<Tuple<int, int>>();
                if (right < grid.GetLength(1))
                {
                    resp.Add(new Tuple<int, int>(curr.Item1, right));
                }
                if (down < grid.GetLength(0))
                {
                    resp.Add(new Tuple<int, int>(down, curr.Item2));
                }
                return resp;
            }
        }
    }
}
