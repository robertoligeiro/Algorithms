using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode542._01Matrix
{
    class Program
    {
        //https://leetcode.com/problems/01-matrix/#/description
        static void Main(string[] args)
        {
//            var m = new int[,] { {0,0,0 }, {0,1,0 }, {1,1,1 } };
            var m = new int[,] { { 0 }, { 0 }, { 0 }, {1 }, { 1} };
            var s = new Solution();
            var r = s.UpdateMatrix(m);
        }

        public class Solution
        {
            public int[,] UpdateMatrix(int[,] matrix)
            {
                for (int row = 0; row < matrix.GetLength(0); ++row)
                {
                    for (int col = 0; col < matrix.GetLength(1); ++col)
                    {
                        if (matrix[row, col] != 0)
                        {
                            matrix[row, col] = FindDist(matrix, new Tuple<int, int>(row, col));
                        }
                    }
                }

                return matrix;
            }

            public int FindDist(int[,] m, Tuple<int, int> pos)
            {
                var dist = 0;
                var visited = new HashSet<Tuple<int, int>>();
                var q1 = new Queue<Tuple<int, int>>();
                var q2 = new Queue<Tuple<int, int>>();
                q1.Enqueue(pos);

                while (q1.Count > 0 || q2.Count > 0)
                {
                    while (q1.Count > 0)
                    {
                        var curr = q1.Dequeue();
                        if (!visited.Add(curr)) continue;
                        if (m[curr.Item1, curr.Item2] == 0) return dist;
                        GetAdj(m, curr, q2);
                    }
                    dist++;
                    while (q2.Count > 0)
                    {
                        var curr = q2.Dequeue();
                        if (!visited.Add(curr)) continue;
                        if (m[curr.Item1, curr.Item2] == 0) return dist;
                        GetAdj(m, curr, q1);
                    }
                    dist++;
                }
                return -1;
            }

            public void GetAdj(int[,] m, Tuple<int, int> curr, Queue<Tuple<int, int>> q)
            {
                if (curr.Item1 + 1 < m.GetLength(0))
                {
                    q.Enqueue(new Tuple<int, int>(curr.Item1+1, curr.Item2));
                }
                if (curr.Item1 - 1 >=0)
                {
                    q.Enqueue(new Tuple<int, int>(curr.Item1 - 1, curr.Item2));
                }
                if (curr.Item2 + 1 < m.GetLength(1))
                {
                    q.Enqueue(new Tuple<int, int>(curr.Item1, curr.Item2 + 1));
                }
                if (curr.Item2 - 1 >= 0)
                {
                    q.Enqueue(new Tuple<int, int>(curr.Item1, curr.Item2 - 1));
                }
            }
        }
    }
}
