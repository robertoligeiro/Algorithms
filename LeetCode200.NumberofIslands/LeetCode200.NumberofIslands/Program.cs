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
                var start = new Tuple<int, int>(row, col);
                var visited = new HashSet<Tuple<int, int>>() { start};
                var q = new Queue<Tuple<int, int>>();
                q.Enqueue(start);
                while (q.Count > 0)
                {
                    var curr = q.Dequeue();
                    grid[curr.Item1, curr.Item2] = '2';
                    GetAdj(grid, curr, visited, q);
                }
            }
            private void GetAdj(char[,] grid, Tuple<int,int> curr, HashSet<Tuple<int, int>> visited, Queue<Tuple<int, int>> q)
            {
                var down = curr.Item1 + 1;
                var up = curr.Item1 - 1;
                var left = curr.Item2 - 1;
                var right = curr.Item2 + 1;
                if (down < grid.GetLength(0) && grid[down, curr.Item2] == '1')
                {
                    AddAdj(new Tuple<int, int>(down, curr.Item2), visited, q);
                }
                if (up >=0 && grid[up, curr.Item2] == '1')
                {
                    AddAdj(new Tuple<int, int>(up, curr.Item2), visited, q);
                }
                if (right < grid.GetLength(1) && grid[curr.Item1, right] == '1')
                {
                    AddAdj(new Tuple<int, int>(curr.Item1, right), visited, q);
                }
                if (left >= 0 && grid[curr.Item1, left] == '1')
                {
                    AddAdj(new Tuple<int, int>(curr.Item1, left), visited, q);
                }
            }
            private void AddAdj(Tuple<int, int> candidate, HashSet<Tuple<int, int>> visited, Queue<Tuple<int, int>> q)
            {
                if (visited.Add(candidate)) q.Enqueue(candidate);
            }
        }
    }
}
