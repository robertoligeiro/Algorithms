using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode329.LongestIncreasingPathaInAMatrix
{
    class Program
    {
        static void Main(string[] args)
        {
            var s = new Solution();
            var matrix = new int[,] { { 9, 9, 4 }, { 6, 6, 8 }, { 2, 1, 1 } };
            var r = s.LongestIncreasingPath(matrix);

            matrix = new int[,] { { 7, 8, 9 }, { 9, 7, 6 }, { 7, 2, 3 } };
            r = s.LongestIncreasingPath(matrix);
        }

        public class Solution
        {
            public int LongestIncreasingPath(int[,] matrix)
            {
                var maxPath = new HashSet<Tuple<int, int>>();
                for (int row = 0; row < matrix.GetLength(0); ++row)
                {
                    for (int col = 0; col < matrix.GetLength(1); ++col)
                    {
                        var localMax = new List<Tuple<int, int>>() { new Tuple<int, int>(row,col)};
                        var visitedPath = new HashSet<Tuple<int, int>>() { new Tuple<int, int>(row, col) };
                        localMax = GetMaxPathIncreasingFrom(matrix, localMax, visitedPath);
                        if (localMax.Count > maxPath.Count)
                        {
                            maxPath = new HashSet<Tuple<int, int>>(localMax);
                        }
                    }
                }
                return maxPath.Count;
            }

            private List<Tuple<int, int>> GetMaxPathIncreasingFrom(int[,] matrix, List<Tuple<int, int>> path, HashSet<Tuple<int, int>> visitedPath)
            {
                var nextIncreasingCells = GetNextIncreasing(path.LastOrDefault(), matrix);
                var maxPath = new List<Tuple<int, int>>(path);
                foreach (var t in nextIncreasingCells)
                {
                    if (visitedPath.Add(t))
                    {
                        var localMaxPath = new List<Tuple<int, int>>(path);
                        localMaxPath.Add(t);
                        localMaxPath = GetMaxPathIncreasingFrom(matrix, localMaxPath, visitedPath);
                        if (localMaxPath.Count > maxPath.Count)
                        {
                            maxPath = new List<Tuple<int, int>>(localMaxPath);
                        }
                        visitedPath.Remove(t);
                    }
                }
                return maxPath;
            }

            private List<Tuple<int, int>> GetNextIncreasing(Tuple<int, int> here, int[,] matrix)
            {
                var resp = new List<Tuple<int, int>>();
                var val = matrix[here.Item1, here.Item2];
                if (here.Item1 + 1 < matrix.GetLength(0) && val < matrix[here.Item1 + 1, here.Item2])
                {
                    resp.Add(new Tuple<int, int>(here.Item1 + 1, here.Item2));
                }
                if (here.Item1 - 1 >= 0 && val < matrix[here.Item1 - 1, here.Item2])
                {
                    resp.Add(new Tuple<int, int>(here.Item1 - 1, here.Item2));
                }
                if (here.Item2 + 1 < matrix.GetLength(1) && val < matrix[here.Item1, here.Item2 + 1])
                {
                    resp.Add(new Tuple<int, int>(here.Item1, here.Item2 + 1));
                }
                if (here.Item2 - 1 >= 0 && val < matrix[here.Item1, here.Item2 - 1])
                {
                    resp.Add(new Tuple<int, int>(here.Item1, here.Item2 - 1));
                }
                return resp;
            }
        }
    }
}
