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
            var g = new int[,] { { 0, 0, 0, 5 }, { 1, 1, 1, 0 }, { 2, 2, 2, 0 }, { 3, 3, 3, 0 } };
            //var g = new int[,] { { 0, 0}, { 0, 1 } };
            var s = new Solution();
            var r = s.MinPathSum(g);
        }
        public class Solution
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
